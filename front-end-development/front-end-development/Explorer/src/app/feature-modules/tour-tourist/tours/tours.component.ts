import { Component } from '@angular/core';
import { Tour } from '../../tour-authoring/model/tour.model';
import { TourAuthoringService } from '../../tour-authoring/tour-authoring.service';
import { AuthService } from 'src/app/infrastructure/auth/auth.service';
import { User } from 'src/app/infrastructure/auth/model/user.model';

@Component({
  selector: 'xp-tours',
  templateUrl: './tours.component.html',
  styleUrls: ['./tours.component.css']
})
export class ToursComponent {
  
    constructor(
      private tourService: TourAuthoringService,
      private authService: AuthService) { }
  
    ngOnInit(): void {
      this.authService.user$.subscribe(user => {
        this.user = user;
      });
      this.tourService.getAuthorTours(this.user.id).subscribe((result) => {
        this.tours = result.results;
      });

    }
    user: User;
    tours: Tour[] = [];

    start(tour: Tour): void {
    }

}
