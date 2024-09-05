import { Component, Input } from '@angular/core';
import { TourReview } from 'src/app/feature-modules/tour-authoring/model/tour.review.model';

@Component({
  selector: 'xp-tour-review',
  templateUrl: './tour-review.component.html',
  styleUrls: ['./tour-review.component.css'],
})
export class TourReviewComponent {
  @Input() review: TourReview;
}
