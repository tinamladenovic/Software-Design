import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Component, EventEmitter, Inject, Input, OnChanges, OnInit, Output, SimpleChanges } from '@angular/core';
import { TourPreferences } from '../model/tour-preferences.model';
import { MarketplaceService } from '../marketplace.service';

@Component({
  selector: 'xp-tour-preferences-form',
  templateUrl: './tour-preferences-form.component.html',
  styleUrls: ['./tour-preferences-form.component.css']
})
export class TourPreferencesFormComponent implements OnChanges{

  @Output() tourPreferencesUpdated = new EventEmitter<null>();
  @Input() tourpreferences: TourPreferences;
  @Input() shouldEdit: boolean = false;

  constructor(private service: MarketplaceService) {
  }

  ngOnChanges(changes: SimpleChanges): void {
    this.tourPreferencesForm.reset();
    console.log(this.tourpreferences);
    if(this.shouldEdit){
      this.tourPreferencesForm.patchValue(this.tourpreferences);
    }
  }

  tourPreferencesForm = new FormGroup({
    tourDifficult: new FormControl('', [Validators.required]),
    tourTravelMethod: new FormControl('', [Validators.required]),
    rating: new FormControl('', [Validators.required]),
    tags: new FormControl('', [Validators.required]),
  });

addTourPreferences(): void {
  const tourpreferences: TourPreferences = {
    id: 0,
    touristId: 0,
    tourDifficult: this.tourPreferencesForm.value.tourDifficult || "",
    tourTravelMethod: this.tourPreferencesForm.value.tourTravelMethod || "",
    rating: this.tourPreferencesForm.value.rating || "",
    tags: this.tourPreferencesForm.value.tags || "",
  };
  this.service.addTourPreferences(tourpreferences).subscribe({
    next: () => { this.tourPreferencesUpdated.emit() }
  });
}
updateTourPreferences(): void {
  const tourpreferences: TourPreferences = {
    id: this.tourpreferences.id,
    touristId: 0,
    tourDifficult: this.tourPreferencesForm.value.tourDifficult || "",
    tourTravelMethod: this.tourPreferencesForm.value.tourTravelMethod || "",
    rating: this.tourPreferencesForm.value.rating || "",
    tags: this.tourPreferencesForm.value.tags || "",
  }
  tourpreferences.id = this.tourpreferences.id;
  this.service.updateTourPreferences(tourpreferences).subscribe({
    next: () => { 
      this.tourPreferencesUpdated.emit();
    }
  })
}
}
