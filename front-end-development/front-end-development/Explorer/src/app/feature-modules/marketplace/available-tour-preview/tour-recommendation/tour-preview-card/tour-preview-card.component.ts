import { Component, EventEmitter, Input, OnInit, Output, ViewEncapsulation } from '@angular/core';
import { Tour } from 'src/app/feature-modules/tour-authoring/model/tour.model';
import { MarketplaceService } from '../../../marketplace.service';
import { PagedResults } from 'src/app/shared/model/paged-results.model';
import { Checkpoint } from 'src/app/feature-modules/tour-authoring/model/checkpoint.model';
import { TourStatisticsService } from '../../../tour-statistics.service';

@Component({
  selector: 'xp-tour-preview-card',
  templateUrl: './tour-preview-card.component.html',
  styleUrls: ['./tour-preview-card.component.css'],
})
export class TourPreviewCardComponent implements OnInit{
  @Input() tour : Tour;
  @Input() isActiveTourCard : boolean = false;
  @Input() shouldRenderAddToCartButton : boolean = true;
  @Output() addToCartClick: EventEmitter<Tour> = new EventEmitter<Tour>();

  tags : string[] = [];
  checkpoints: Checkpoint[] = []
  averageRating: number = 0;
  ratingCount: number = 0;
  orderCount: number = 0;

  constructor(
    private marketplaceService : MarketplaceService,
    private statsService: TourStatisticsService
    ) {}

  ngOnInit(): void {
    this.tags = this.tour.tags.split(',');
    this.getCheckpoints(this.tour.id);
    this.getTourStatistics();
  }

  getTourStatistics() {
    this.getAverageRating();
    this.getRatingCount();
    this.getOrderCount();
  }

  getOrderCount() : void {
    this.statsService.getTourOrderCount(this.tour.id).subscribe({
      next: (result: number) => {
        this.orderCount = result;
      },
      error: () => {}
    })
  }

  getRatingCount() : void {
    this.statsService.getTourRatingCountForPastWeek(this.tour.id).subscribe({
      next: (result: number) => {
        this.ratingCount = result;
      },
      error: () => {}
    })
  }
  
  getAverageRating() : void {
    this.statsService.getTourAverageRatingForPastWeek(this.tour.id).subscribe({
      next: (result: number) => {
        this.averageRating = result;
      },
      error: () => {}
    })
  }

  getCheckpoints(tourid : number) : void {
    this.marketplaceService.getCheckpoints(tourid).subscribe({
      next: (result: PagedResults<Checkpoint>) => {
        this.checkpoints = result.results;
      },
      error: () => {}
    })
  }

  getDifficultyClass() : string {
    switch(this.tour.difficult){
      case 0:
      return 'easy-chip';
    case 1:
      return 'medium-chip';
    case 2:
      return 'hard-chip';
    default:
      return 'default-chip'; 
    }
  }

  addToCart_tour(tour: Tour){
    this.addToCartClick.emit(tour);
    this.shouldRenderAddToCartButton = false;
  }
}
