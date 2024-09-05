declare global {
  interface Window { activateEncounter: (id: number) => void; }
}

import { AfterViewInit, Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { Coordinate } from '../../tour-execution/model/coordinate';
import { AddressTest } from '../../tour-authoring/model/address-test.model';
import { EncounterExecutionService } from '../encounter-execution.service';
import { EncounterService } from '../encounter.service';
import { Encounter, EncounterStatistics, EncounterType } from '../model/encounters.model';
import { PagedResults } from 'src/app/shared/model/paged-results.model';
import { MapComponent } from 'src/app/shared/map/map.component';
import { EncounterExecution, EncounterExecutionStatus } from '../model/encounter-execution.model';
import { ToastrService } from 'ngx-toastr';
import { EMPTY, Observable, catchError, forkJoin, interval, switchMap, takeWhile } from 'rxjs';
import { EncounterDrawService } from '../encounter-draw.service';

@Component({
  selector: 'xp-encounters-execution',
  templateUrl: './encounters-execution.component.html',
  styleUrls: ['./encounters-execution.component.css']
})
export class EncountersExecutionComponent implements AfterViewInit, OnDestroy {
  currentPosition: Coordinate;
  encounters: Encounter[] = [];
  encounterActive: boolean = false;
  encounter: Encounter;
  encounterExecution: EncounterExecution;
  renderMisc: boolean = true;
  renderSocial: boolean = true;
  renderHiddenLoc: boolean = true;

  @ViewChild(MapComponent) mapComponent: MapComponent;

  constructor(
    private executionService: EncounterExecutionService,
    private encounterService: EncounterService,
    private encounterDrawService: EncounterDrawService,
    private toastr: ToastrService
  ) { }

  ngOnDestroy(): void {
    if (this.encounterActive){
      this.abandonEncounter();
    }
  }

  ngAfterViewInit(): void {
    window['activateEncounter'] = (id: number) => this.mapComponent.activateEncounter(id);
    this.loadEncounters();
  }

  loadEncounters(): void {
    this.encounterService.getActiveEncounters().subscribe((result: PagedResults<Encounter>) => {
      this.encounters = result.results;
    
      let requests = this.encounters.map(encounter =>
        this.encounterService.getStatisticsForEncounter(encounter.id!)
      );
    
      forkJoin(requests).subscribe((results: EncounterStatistics[]) => {
        let popUps = this.encounters.reduce((map, encounter, index) => {
          map.set(encounter.id!, this.encounterDrawService.generateEncounterPopUp(encounter, results[index]));
          return map;
        }, new Map<number, string>());
    
        this.mapComponent.drawEncounters(this.encounters, popUps);
      });
    });
  }

  drawEncounters(): void {
    let encountersToDraw: Encounter[] = [];
    if (this.renderMisc) {
      encountersToDraw = encountersToDraw.concat(this.encounters.filter(e => e.type === EncounterType.Misc));
    }
    if (this.renderSocial) {
      encountersToDraw = encountersToDraw.concat(this.encounters.filter(e => e.type === EncounterType.Social));
    }
    if (this.renderHiddenLoc) {
      encountersToDraw = encountersToDraw.concat(this.encounters.filter(e => e.type === EncounterType.HiddenLocation));
    }
    let requests = encountersToDraw.map(encounter =>
      this.encounterService.getStatisticsForEncounter(encounter.id!)
    );
  
    forkJoin(requests).subscribe((results: EncounterStatistics[]) => {
      let popUps = encountersToDraw.reduce((map, encounter, index) => {
        map.set(encounter.id!, this.encounterDrawService.generateEncounterPopUp(encounter, results[index]));
        return map;
      }, new Map<number, string>());
  
      this.mapComponent.drawEncounters(encountersToDraw, popUps);
    });
  }

  abandonEncounter(): void {
    this.executionService.abandon(this.encounterExecution.id).subscribe({
      next: (result) => {
        this.encounterExecution = result;
        if (this.encounterExecution.status === EncounterExecutionStatus.Abandoned) {
          this.encounterActive = false;
          this.encounterDrawService.showEncounterAbandoned();
        }
      },
      error: (error) => {
        console.log(error);
      }
    });
  }

  activateEncounter(encounterId: number): void {
    if (this.encounterActive) {
      this.toastr.error('You must finish your active encounter before starting another one.', 'Encounter already active');
      return;
    }
    if (!this.currentPosition) {
      this.toastr.error('You need to place a pin on the map first.', 'No position selected');
      return;
    }
    this.executionService.activate(encounterId, this.currentPosition).subscribe({
      next: (result) => {
        console.log(result);
        this.encounterExecution = result;
        this.encounter = this.encounters.find(e => e.id === encounterId)!;
        this.encounterActive = true;
        this.trackProgress();
        this.encounterDrawService.showEncounterActivated();
        this.mapComponent.closePopupAt(this.encounter.coordinates.latitude, this.encounter.coordinates.longitude);
      },
      error: (error) => {
        if (error.error.status === 400) {
          console.log(error.error.detail.split('\r\n')[1].split('=')[1]);
          this.encounterDrawService.showUnableToActivate(error.error.detail.split('\r\n')[1].split('=')[1]);
        }
      }
    });
  }

  trackProgress(): void {
    const intervalMs = 5000;

    if (this.encounterActive) {
      interval(intervalMs).pipe(
        takeWhile(() => this.encounterActive),
        switchMap(() => this.updateProgress()),
        catchError((error: any) => this.handleError(error))
      ).subscribe((result) => this.handleResult(result));
    }
  }

  handleError(error: any): Observable<any> {
    console.error(error);
    return EMPTY;
  }


  updateProgress(): Observable<any> {
    if (this.encounterActive && this.currentPosition) {
      return this.executionService.checkIfCompleted(this.encounterExecution.id, this.currentPosition);
    }
    return EMPTY;
  }


  handleResult(result: any): void {
    if (!this.encounterExecution.locationEntryTimestamp && result.locationEntryTimestamp) {
      this.encounterDrawService.showHiddenLocationFound();
    }
    if (this.encounterExecution.locationEntryTimestamp && !result.locationEntryTimestamp) {
      this.encounterDrawService.showHiddenLocationExited();
    }
    this.checkEncounterStatus(result);
  }

  checkEncounterStatus(result: any): void {
    this.encounterExecution = result;
    if (result.status === EncounterExecutionStatus.Abandoned) {
      this.encounterActive = false;
      this.encounterDrawService.showForcedEncounterAbandon();
    }
    if (result.status === EncounterExecutionStatus.Completed) {
      this.encounterActive = false;
      this.encounterDrawService.showEncounterCompleted();
    }
  }


  finishMiscEncounter(): void {
    this.executionService.completeMiscEncounter(this.encounterExecution.id).subscribe({
      next: (result) => {
        this.encounterExecution = result;
        if (this.encounterExecution.status === EncounterExecutionStatus.Completed) {
          this.encounterActive = false;
          this.encounterDrawService.showEncounterCompleted();
        }
      },
      error: (error) => {
        console.log(error);
      }
    });
  }

  getFullImageUrl(imageURL?: string): string {
    return this.encounterDrawService.getFullImageUrl(imageURL);
  }

  onPinPlaced(event: AddressTest): void {
    this.currentPosition = { latitude: event.lat, longitude: event.lng };
  }
}
