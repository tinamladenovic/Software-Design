import { Component, EventEmitter, Input, Output } from '@angular/core';
import { AvailableTour } from '../../model/available-tour-model';
import { TourAuthoringService } from 'src/app/feature-modules/tour-authoring/tour-authoring.service';

@Component({
  selector: 'xp-tour-header',
  templateUrl: './tour-header.component.html',
  styleUrls: ['./tour-header.component.css'],
})
export class TourHeaderComponent {
  @Input() tour: AvailableTour;
  @Output() addToCartClick: EventEmitter<AvailableTour> =
    new EventEmitter<AvailableTour>();
  @Output() addToFavoriteClick: EventEmitter<AvailableTour> =
    new EventEmitter<AvailableTour>();
  @Output() removeFromFavouriteClick: EventEmitter<AvailableTour> =
    new EventEmitter<AvailableTour>();

  addToFavorite(tour: AvailableTour) {
    this.addToFavoriteClick.emit(tour);
  }
  removeFromFavorite(tour: AvailableTour) {
    this.removeFromFavouriteClick.emit(tour);
  }
  addToCart(tour: AvailableTour) {
    console.log(tour);
    this.addToCartClick.emit(tour);
  }
}
