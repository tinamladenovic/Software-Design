import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Tour } from '../model/tour.model';
import { TourReview } from '../model/tour.review.model';
import { TourAuthoringService } from '../tour-authoring.service';
import { PagedResults } from 'src/app/shared/model/paged-results.model';
import { AuthService } from 'src/app/infrastructure/auth/auth.service';
import { User } from 'src/app/infrastructure/auth/model/user.model';
import { MatDatepickerInputEvent } from '@angular/material/datepicker';

@Component({
  selector: 'xp-review-tour',
  templateUrl: './review-tour.component.html',
  styleUrls: ['./review-tour.component.css']
})
export class ReviewTourComponent implements OnInit {
  userId: number;
  date: Date | null = null;

  tourReviews: TourReview[] = [];
  user: User 

  constructor(private service: TourAuthoringService, private authService: AuthService){
    this.userId = this.authService.user$.getValue().id;
  }
  
  ngOnInit(): void {
    this.getReviews();
  }

  getReviews(): void{
    this.service.getAuthorTourReviews(this.userId).subscribe({
      next: (result) => {
        this.tourReviews = result.results;
      }
    })
  }

 
  tourReviewForm = new FormGroup({
    grade: new FormControl('',[Validators.required]),
    comment: new FormControl('', [Validators.required]),
    timeOfTour: new FormControl('', [Validators.required])
  });

  addEvent(type: string, event: MatDatepickerInputEvent<Date>) {
    this.date = event.value;
  }

  submitTourReviewForm(): void{
    var now = Date.now();
    const tourReview: TourReview = {
      userId: this.userId,
      tourId: 1,
      grade : Number(this.tourReviewForm.value.grade),
      comment : this.tourReviewForm.value.comment || "",
      timeOfComment : new Date(now),
      timeOfTour : this.date!,
     }

    this.service.addTourReview(tourReview).subscribe({
      next : () => {
        this.getReviews();
      }
    })
  }


}
