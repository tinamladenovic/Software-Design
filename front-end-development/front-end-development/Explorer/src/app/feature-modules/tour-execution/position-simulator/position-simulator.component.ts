declare global {
  interface Window { activateEncounter: (id: number) => void; }
}


import { AfterViewInit, Component, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { LatLng } from 'leaflet';
import { CheckpointService } from 'src/app/feature-modules/tour-authoring/checkpoint.service';
import { AddressTest } from 'src/app/feature-modules/tour-authoring/model/address-test.model';
import { Checkpoint } from 'src/app/feature-modules/tour-authoring/model/checkpoint.model';
import { MapComponent } from 'src/app/shared/map/map.component';
import { PagedResults } from 'src/app/shared/model/paged-results.model';
import { TourExecution, TourExecutionStatus } from '../model/tour-execution';
import { CheckpointStatus } from '../model/checkpoint-status';
import { TourExecutionService } from '../tour-execution.service';
import { EMPTY, Observable, Subject, catchError, finalize, forkJoin, from, interval, of, startWith, switchMap, takeUntil, takeWhile, tap, timer } from 'rxjs';
import { Coordinate } from '../model/coordinate';
import { ToastContainerDirective, ToastrService } from 'ngx-toastr';
import { TourProgressService } from '../tour-progress.service';
import * as L from 'leaflet';
import { TransferValue } from '../../tour-authoring/model/transfer-value.model';
import { EncounterExecutionService } from '../../encounters/encounter-execution.service';
import { EncounterService } from '../../encounters/encounter.service';
import { EncounterDrawService } from '../../encounters/encounter-draw.service';
import { Encounter, EncounterStatistics } from '../../encounters/model/encounters.model';
import { EncounterExecution, EncounterExecutionStatus } from '../../encounters/model/encounter-execution.model';
import { CountryCode } from '../model/country-code.model';
import { EmergencyNumbers } from '../model/emergency-numbers.model';
import { AvailableTourPreviewComponent } from '../../marketplace/available-tour-preview/available-tour-preview.component';
import { AuthService } from 'src/app/infrastructure/auth/auth.service';
import { Tour } from '../../tour-authoring/model/tour.model';
import { HttpErrorResponse } from '@angular/common/http';


@Component({
  selector: 'xp-position-simulator',
  templateUrl: './position-simulator.component.html',
  styleUrls: ['./position-simulator.component.css']
})
export class PositionSimulatorComponent implements OnInit {

  tourId: number = 0;
  user: any;
  tours: any[];
  areToursRecommended: boolean = false;
  isComposite: number = 0;
  checkpoints: Checkpoint[];
  encounters: Encounter[];
  tourExecution: TourExecution;
  currentPosition: Coordinate;
  checkpointCounter: number = 0;
  tourStarted: boolean = false;
  tourFinished: boolean = false;
  markers: L.Marker[];
  coveredDistance: number = 0;
  routeControl: any = null;


  encounterExecution: EncounterExecution;
  encounterActive: boolean = false;
  encounter: Encounter;


  police: string = "";
  ambulance: string = "";
  fireService: string = "";


  @ViewChild(MapComponent) mapComponent: MapComponent;
  @ViewChild(ToastContainerDirective, { static: true }) toastContainer: ToastContainerDirective;


  @Input() shouldRenderAddToCartButton: boolean = true;
  @Output() addToCartClick: EventEmitter<Tour> = new EventEmitter<Tour>();


  constructor(
    private checkpointService: CheckpointService,
    private route: ActivatedRoute,
    private tourExecutionService: TourExecutionService,
    private toastr: ToastrService,
    private tourProgressService: TourProgressService,
    private router: Router,
    private executionService: EncounterExecutionService,
    private encounterService: EncounterService,
    private encounterDrawService: EncounterDrawService,
    private authService: AuthService,
  ) { }


  ngOnInit() {
    this.route.paramMap.subscribe((params) => {
      if (params) {
        this.tourId = +params.get('tourId')!;
        this.isComposite = +params.get('isComposite')!;
        if (!isNaN(this.tourId) && this.isComposite === 0) {


          this.getCheckpoints(this.tourId);


          this.getEncounters();
        }
        else if (!isNaN(this.tourId) && this.isComposite === 1) {
          this.getCompositeTourCheckpoints(this.tourId);
        }
        else {
          this.showFailure();
        }
      }
    });
    this.toastr.overlayContainer = this.toastContainer;
    this.showInfo();
  }


  ngAfterViewInit(): void {
    window['activateEncounter'] = (id: number) => this.mapComponent.activateEncounter(id);
  }


  checkpointCompleted() {
    this.checkpointCounter++;
    this.tourProgressService.updateCompletionPercentage(this.checkpointCounter * 25);
  }


  getCheckpoints(id: number): void {
    this.checkpointService.getCheckpoints(id).subscribe({
      next: (result: PagedResults<Checkpoint>) => {
        this.checkpoints = result.results;
        this.drawCheckpoints();
      },
      error: (err: any) => {
        console.log(err);
        this.showFailure();
      },
    });
  }

  sendEmailWithLink(): void {
    console.log("email sent");
  }

  availableTours(): void {
    this.router.navigate([`available-tours`]);
  }

  getRecommendedTours(): void {
    const userId = this.authService.user$.getValue().id;


    this.tourExecutionService.getRecommendedTours(this.tourId, userId).subscribe(
      (response: Tour) => {
        console.log('Recommended tours:', response);
        this.tours = [
          {
            "Id": 102,
            "AuthorId": 103,
            "Name": "Okeanska tura",
            "Description": "Opis okeanske ture",
            "Difficult": "Medium",
            "Status": "PUBLISHED",
            "Price": 200.0,
            "Tags": "okean,ostrvo",
            "Distance": 100.0,
            "PublishTime": "2023-11-09T15:00:25.421614+01:00",
            "ArchiveTime": null,
            "TravelTimeAndMethod": [
              { "TravelTime": 15, "TravelMethod": 0 },
              { "TravelTime": 30, "TravelMethod": 1 },
              { "TravelTime": 10, "TravelMethod": 2 }
            ],
            "TourEquipment": []
          },
          {
            "Id": 103,
            "AuthorId": 102,
            "Name": "Pustinjska tura",
            "Description": "Opis pustinjske ture",
            "Difficult": "Medium",
            "Status": "PUBLISHED",
            "Price": 20.0,
            "Tags": "pustinja,pesak",
            "Distance": 150.0,
            "PublishTime": "2023-11-09T15:00:25.421614+01:00",
            "ArchiveTime": null,
            "TravelTimeAndMethod": [
              { "TravelTime": 40, "TravelMethod": 0 },
              { "TravelTime": 70, "TravelMethod": 1 },
              { "TravelTime": 20, "TravelMethod": 2 }
            ],
            "TourEquipment": []
          }
        ]
        console.log(this.tours);


        this.areToursRecommended = true;
      },
      (error: any) => {
        console.error('Error fetching recommended tours:', error);
        if (error instanceof HttpErrorResponse) {
          console.log('Response body:', error.error);
        }
      }
    );


  }






  getEncounters(): void {
    this.encounterService.getAllForCheckpoint().subscribe({
      next: (result: PagedResults<Encounter>) => {
        this.encounters = result.results;
      },
      error: (err: any) => {
        console.log(err);
        this.showFailure();
      },
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
        switchMap(() => this.updateEncounterProgress()),
        catchError((error: any) => this.handleError(error))
      ).subscribe((result) => this.handleEncounterResult(result));
    }
  }


  updateEncounterProgress(): Observable<any> {
    if (this.encounterActive && this.currentPosition) {
      return this.executionService.checkIfCompleted(this.encounterExecution.id, this.currentPosition);
    }
    return EMPTY;
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


  getFullImageUrl(imageURL?: string): string {
    return this.encounterDrawService.getFullImageUrl(imageURL);
  }


  handleEncounterResult(result: any): void {
    if (!this.encounterExecution.locationEntryTimestamp && result.locationEntryTimestamp) {
      this.encounterDrawService.showHiddenLocationFound();
    }
    if (this.encounterExecution.locationEntryTimestamp && !result.locationEntryTimestamp) {
      this.encounterDrawService.showHiddenLocationExited();
    }
    this.checkIfEncounterCompleted(result);
  }


  checkIfEncounterCompleted(result: any): void {
    this.encounterExecution = result;
    if (result.status === EncounterExecutionStatus.Completed) {
      this.encounterActive = false;
      this.encounterDrawService.showEncounterCompleted();
    }
  }


  getCompositeTourCheckpoints(id: number): void {
    this.checkpointService.getCompositeTourCheckpoints(id).subscribe({
      next: (result: PagedResults<Checkpoint>) => {
        this.checkpoints = result.results;
        this.drawCheckpoints();
      }
    })


  }


  showAllTours(): void {
    this.router.navigate([`purchased-tours`]);
  }


  drawCheckpoints(): void {
    this.markers = this.mapComponent.drawCheckpoints(this.checkpoints);
  }


  onPinPlaced(event: AddressTest): void {
    this.getEmergencyNumbers(event);
    this.currentPosition = { latitude: event.lat, longitude: event.lng };
    this.mapComponent.calculateDistance(this.createRouteWaypoints());
  }


  getEmergencyNumbers(position: AddressTest) {


    const parts = position.address.split(',');


    if (parts.length > 0) {
      const lastPart = parts.pop()!.trim();


      this.tourExecutionService.getCountryCode(lastPart).subscribe({
        next: (result: CountryCode[]) => {
          console.log(result[0].ccn3);
          this.tourExecutionService.getEmergencyNumbers(result[0].ccn3).subscribe({
            next: (res: EmergencyNumbers) => {


              this.ambulance = res.data.ambulance.all[0];
              this.police = res.data.police.all[0];
              this.fireService = res.data.fire.all[0];


            }
          })
        }
      })
    }
    else {
      this.police = "";
      this.ambulance = "";
      this.fireService = "";
    }






  }


  startTour(): void {


    this.encounters = this.encounters.filter((enc: Encounter) => {
      return this.checkpoints.includes(this.checkpoints.find((ch: Checkpoint) => ch.id == enc.checkpointId)!)
    });


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


    this.tourExecutionService.createTourExecution(this.tourId).subscribe({
      next: (result) => {
        this.tourExecution = result;
        this.tourStarted = true;
        this.checkPosition();
        this.mapComponent.setRoute();
      },
      error: (error) => {
        console.log(error);
      }
    })


    if (this.isComposite === 1) {
      this.tourExecutionService.createTourExecutionForCompositeTour(this.tourId).subscribe({
        next: (result) => {
          this.tourExecution = result;
          this.tourStarted = true;
          this.checkPosition();
          this.mapComponent.setRoute();
        },
        error: (error) => {
          console.log(error);
        }
      });


    }
    else {
      this.tourExecutionService.createTourExecution(this.tourId).subscribe({
        next: (result) => {
          this.tourExecution = result;
          this.tourStarted = true;
          this.checkPosition();
          this.mapComponent.setRoute();
        },
        error: (error) => {
          console.log(error);
        }
      });
    }
  }


  abandonTour(): void {
    this.tourExecutionService.abandonTourExecution(this.tourExecution.id).subscribe({
      next: (result) => {
        this.tourExecution = result;
        this.tourFinished = true;
        this.showAbandonedTour();
        this.mapComponent.removeRoute();
      },
      error: (error) => {
        console.log(error);
      }
    })
  }


  getOrdinalSuffix(counter: number): string {
    const lastDigit = counter % 10;
    const secondLastDigit = Math.floor(counter / 10) % 10;


    if (secondLastDigit === 1) {
      return 'th';
    }


    if (lastDigit === 1) {
      return 'st';
    } else if (lastDigit === 2) {
      return 'nd';
    } else if (lastDigit === 3) {
      return 'rd';
    } else {
      return 'th';
    }
  }


  showInfo(): void {
    this.toastr.info('Please start the tour to continue.', 'Start tour');
  }
  showFinishedTour(): void {
    this.toastr.success('You finished the tour successfully.', 'Tour Finished');
    //this.tourProgressService.completeTour();
  }
  showAbandonedTour(): void {
    this.toastr.success('You abandoned the tour successfully.', 'Tour Abandoned');
  }
  showFailure(): void {
    this.toastr.error('Something went wrong.', 'Error');
  }
  showCheckpointReached(): void {
    const suffix = this.getOrdinalSuffix(this.checkpointCounter);
    this.toastr.info(
      `You successfully completed ${this.checkpointCounter}${suffix} checkpoint`,
      'Checkpoint reached!'
    );
    this.tourProgressService.incrementCompletionPercentageBy25();
  }


  private calculateNewPercentage(): number {
    const incrementPercentage = 25;
    const currentPercentage = 0;
    const newPercentage = Math.min(currentPercentage + incrementPercentage, 100);
    return newPercentage;
  }


  checkPosition(): void {
    const intervalMs = 10000;


    if (this.tourStarted) {
      interval(intervalMs).pipe(
        startWith(0),
        takeWhile(() => !this.tourFinished),
        switchMap(() => this.updateProgress()),
        catchError((error: any) => this.handleError(error))
      ).subscribe((result) => this.handleResult(result));
    }
  }


  updateCoveredDistance(transferObject: TransferValue): void {
    this.coveredDistance = transferObject.distance;
  }


  updateProgress(): Observable<any> {
    console.log("I'm checking...");
    if (this.tourExecution && this.tourExecution.id && this.currentPosition) {
      return this.tourExecutionService.updateProgress(
        this.tourExecution.id,
        this.tourExecution.checkpointStatuses[this.checkpointCounter].checkpointId,
        this.currentPosition,
        this.coveredDistance
      );
    }
    return EMPTY;
  }


  createRouteWaypoints(): L.Routing.Waypoint[] {
    let routeWaypoints: L.Routing.Waypoint[] = [];
    for (let i = 0; i < this.checkpointCounter; i++) {
      routeWaypoints.push(
        new L.Routing.Waypoint(L.latLng(this.checkpoints[i].latitude, this.checkpoints[i].longitude), 'Waypoint ' + (i + 1), { allowUTurn: true })
      );
    }
    if (this.currentPosition) {
      routeWaypoints.push(
        new L.Routing.Waypoint(L.latLng(this.currentPosition.latitude, this.currentPosition.longitude), 'Waypoint ' + (this.checkpointCounter + 1), { allowUTurn: true })
      );
    }
    return routeWaypoints;
  }


  handleError(error: any): Observable<any> {
    console.error(error);
    return EMPTY;
  }


  handleResult(result: any): void {
    this.tourExecution = result;
    if (this.tourExecution.checkpointStatuses[this.checkpointCounter].isCompleted) 
    {
      this.mapComponent.bindMarkerPopup(this.markers[this.checkpointCounter], this.generateReachedCheckpointPopup());
      this.checkpointCounter++;
      if (this.tourExecution.status != TourExecutionStatus.Completed)
      {
        this.showCheckpointReached();
        this.mapComponent.increaseMarkerSize(this.markers[this.checkpointCounter]);
      }
    }
    if (this.tourExecution.status == TourExecutionStatus.Completed) 
    {
      this.tourFinished = true;
      this.mapComponent.removeRoute();
      this.showFinishedTour();
    }
  }

  generateReachedCheckpointPopup(): string {
    let checkpoint = this.checkpoints[this.checkpointCounter];
    return `
    <div style="text-align: center; font-size: 1.15em;">
      <h3 style="font-weight: bold;">${checkpoint.name}</h3>
      <p style="margin-bottom: 5px;">${checkpoint.description}</p>
      <p style="margin-bottom: 5px;"><strong>Checkpoint num:</strong> ${this.checkpointCounter + 1}</p>
    </div>
  `;
  }

  addToCart_tour(tour: Tour) {
    this.addToCartClick.emit(tour);
    this.shouldRenderAddToCartButton = false;
  }
}
