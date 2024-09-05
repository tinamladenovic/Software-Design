import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { EncounterService } from '../encounter.service';
import { Encounter, EncounterType } from '../model/encounters.model';
import { PagedResults } from 'src/app/shared/model/paged-results.model';
import { ImageService } from 'src/app/shared/image.service';
import { EncounterDrawService } from '../encounter-draw.service';

@Component({
  selector: 'xp-encounter',
  templateUrl: './encounter.component.html',
  styleUrls: ['./encounter.component.css']
})
export class EncounterComponent implements OnInit {
 
  socialEncounters: Encounter[];
  hiddenLocationEncounters: Encounter[];
  miscEncounters: Encounter[];
  selectedEncounter: Encounter;
  shouldRenderEncounterForm: boolean = false;
  shouldEdit: boolean = false;
  formEncounterType: number;
  

  constructor(
    private service: EncounterService,
    private imageService: ImageService,
    private drawService: EncounterDrawService,
    private changeDetector: ChangeDetectorRef
    ) {}

  ngOnInit(): void {
    this.getAllEncounters();
  }

  getAllEncounters(): void {
    this.service.getAllEncounters().subscribe(
      (pagedResults: PagedResults<Encounter>) => {
        this.socialEncounters = pagedResults.results.filter((e) => e.type === EncounterType.Social);
        this.hiddenLocationEncounters = pagedResults.results.filter((e) => e.type === EncounterType.HiddenLocation);
        this.miscEncounters = pagedResults.results.filter((e) => e.type === EncounterType.Misc);
      },
      (error) => {
        console.error('Error fetching encounters:', error);
      }
    );
  }

  getFullImageUrl(imageURL?: string): string {
    if(imageURL)
      return this.imageService.getFullImageUrl(imageURL);
    else
      return "No Image";
  }

  deleteEncounter(id: number): void {
    this.service.deleteEncounter(id).subscribe({
      next: () => {
        this.getAllEncounters();
        this.drawService.showEncounterDeleted();
      },
    })
  }

  onEditClicked(encounter: Encounter): void {
    this.selectedEncounter = encounter;
    this.shouldEdit = true;
    this.formEncounterType = encounter.type;
    this.shouldRenderEncounterForm = true;

    this.changeDetector.detectChanges();
  }

  onAddClicked(encounterType: number): void {
    this.shouldEdit = false;
    this.formEncounterType = encounterType;
    this.shouldRenderEncounterForm = true;

    this.changeDetector.detectChanges();
  }

  closeForm(): void {
    this.shouldRenderEncounterForm = false;
  }

  getStatusString(status: number): string {
    switch(status) {
      case 0: return "Active";
      case 1: return "Draft";
      case 2: return "Archived";
      default: return "Error";
    }
  }
  
}
