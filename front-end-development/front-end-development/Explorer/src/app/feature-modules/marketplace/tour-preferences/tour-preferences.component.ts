import { OnInit } from '@angular/core';
import { Component } from '@angular/core';
import { PagedResults } from '../../../shared/model/paged-results.model';
import { MarketplaceService } from '../marketplace.service';
import { TourPreferences } from '../model/tour-preferences.model';


@Component({
  selector: 'xp-tour-preferences',
  templateUrl: './tour-preferences.component.html',
  styleUrls: ['./tour-preferences.component.css']
})
export class TourPreferencesComponent implements OnInit {

  tourpreferences: TourPreferences[] = [];
  selectedTourPreferences: TourPreferences;
  shouldRenderTourPreferencesForm: boolean;
  shouldEdit: boolean = false;
  

  constructor(private service: MarketplaceService) { }

  ngOnInit(): void {
    this.getTourPreferences();
  }
  deleteTourPreferences(id: number): void {
    this.service.deleteTourPreferences(id).subscribe({
      next: () => {
        this.getTourPreferences();
      },
    })
  }

  getTourPreferences(): void {
    this.service.getTourPreferences().subscribe({
      next: (result: PagedResults<TourPreferences>) => {
        this.tourpreferences = result.results;
      },
      error: () => {
      }
    })
  }

  onEditClicked(tourpreferences: TourPreferences): void {
    this.selectedTourPreferences = tourpreferences;
    this.shouldRenderTourPreferencesForm = true;
    this.shouldEdit = true;
  }

  onAddClicked(): void {
    this.shouldEdit = false;
    this.shouldRenderTourPreferencesForm = true;
  }
}
  

