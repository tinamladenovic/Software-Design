import { OnInit } from '@angular/core';
import { Component } from '@angular/core';
import { PagedResults } from '../../../shared/model/paged-results.model';
import { TourExecutionService } from '../tour-execution.service';
import { TourRating } from '../model/tour-rating.model';
import { TourProgressService } from '../tour-progress.service';
import { Review } from '../model/tour-rating.model';



@Component({
  selector: 'xp-tour-rating',
  templateUrl: './tour-rating.component.html',
  styleUrls: ['./tour-rating.component.css']
})
export class TourRatingComponent implements OnInit {
  isReviewAdded: boolean[] = [];

  index: number = 0;
  editedIndex: number | null = null;
  isEditing: boolean[] = [];
  canLeaveReviewResult: boolean = false;
  selectedReview: Review | null = null;
  completionPercentage: number = 0;
  tourRatings: TourRating[] = [];
  newReview = {
    rating: 1, 
    comment: '',
    editable: false
  };
  // userReviewIndex: number | null = null; 

  constructor(private service: TourExecutionService, public tourProgressService: TourProgressService) {}

  ngOnInit(): void {
    if (this.tourRatings.length === 0) {
      this.service.getTourRating().subscribe({
        next: (result: PagedResults<TourRating>) => {
          this.tourRatings = result.results;
          // this.setUserReviewIndex(); // Set the index of the user's review
        },
        error: (err: any) => {
          console.log(err);
        }
      });
    }

    this.tourProgressService.completionPercentage$.subscribe(completionPercentage => {
      if (this.tourRatings.length > 0) {
        const tour = this.tourRatings[0];
        tour.completionPercentage = completionPercentage;
        this.updateLastActivity(tour); // Update last activity
        // this.setUserReviewIndex(); // Update the index when completionPercentage changes
      }
    });

  }
  

  toggleEdit(index: number) {
    this.isEditing[index] = !this.isEditing[index];
    this.editedIndex = this.isEditing[index] ? index : null;
  }

  saveEdit(index: number) {
    this.editedIndex = null;
  }

  getCurrentDateTime(): Date {
    return new Date(); // Vraćanje trenutnog vremena i datuma
  }

  calculateAverageRating(tourRatings: any[]): number {
    if (!tourRatings || tourRatings.length === 0) {
      return 0;
    }
  
    const totalRating = tourRatings.reduce((acc, rating) => acc + rating.rating, 0);
    return totalRating / tourRatings.length;
  }
  
  checkCanLeaveReview(tour: TourRating): void {
    this.canLeaveReviewResult = this.canLeaveReview(tour);
  }
    
  canLeaveReview(tour: TourRating): boolean {
    if (!tour) {
      return false;
    }

    const completionCondition = tour.completionPercentage > 35;

    const lastActivityCondition =
      tour.lastActivity &&
      (new Date().getTime() - new Date(tour.lastActivity).getTime()) / (1000 * 60 * 60 * 24) <= 7;

    this.newReview.editable = completionCondition && lastActivityCondition;

    return completionCondition && lastActivityCondition;
  }

  editReview(tour: TourRating, review: Review): void {
    this.newReview.editable = true;
    this.newReview.rating = review.rating;
    this.newReview.comment = review.comment;
  }
  
  // private setUserReviewIndex(): void {
  //   // Set the index of the user's review
  //   if (this.tourRatings.length > 0) {
  //     const userReview = this.tourRatings[0].reviews.find(review => review.user === true);
  //     this.userReviewIndex = userReview ? this.tourRatings[0].reviews.indexOf(userReview) : null;
  //   }
  // }

  updateLastActivity(tour: TourRating): void {
    tour.lastActivity = new Date();
  }

  addReview(): void {
    if (!this.newReview.rating || !this.newReview.comment) {
      alert('Please enter both rating and comment.');
      return;
      
    }
  
    const newReview = {
      tourId: 1, // Postavite odgovarajuću vrednost za tourId
      touristId: 1, // Postavite odgovarajuću vrednost za touristId
      rating: this.newReview.rating,
      review: this.newReview.comment,
      created: new Date(),
      completionPercentage: 0,
      lastActivity: new Date(),
      reviews: []
    };

    
  
    this.tourRatings.push(newReview); // Dodajemo novu recenziju u listu
    
    this.newReview.rating = 0; // Resetujemo rating nakon dodavanja recenzije
    this.newReview.comment = ''; // Resetujemo comment nakon dodavanja recenzije

    this.isReviewAdded.push(true);

    
  }
  
  checkIfReviewAdded(index: number): boolean {
    return this.isReviewAdded[index] ?? false;
  }
  
  
  
  
}
