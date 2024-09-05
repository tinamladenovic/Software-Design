import { Component } from '@angular/core';
import { AuthService } from 'src/app/infrastructure/auth/auth.service';
import { MarketplaceService } from '../marketplace.service';
import { User } from 'src/app/infrastructure/auth/model/user.model';
import { Tour } from '../../tour-authoring/model/tour.model';
import { PagedResults } from 'src/app/shared/model/paged-results.model';
import { TourAuthorService } from '../tourAuthorService';
import { Router } from '@angular/router';

@Component({
  selector: 'xp-author-profile',
  templateUrl: './author-profile.component.html',
  styleUrls: ['./author-profile.component.css']
})
export class AuthorProfileComponent {
  constructor(
    private service : MarketplaceService,
    private userService : AuthService,
    private tourAuthorService : TourAuthorService,
    private router : Router,
  ){}

  userId : number;
  user : User = {id : 0, username : "", role : ""}
  tours : Tour[] = [];

  

  ngOnInit(){
    this.userId = this.tourAuthorService.getAuthorId();

    this.userService.getUserById(this.userId).subscribe({
      next: (user) => {
        this.user = user;
        this.service.getPublishedAuthorTours(user.id).subscribe({
          next: (result: PagedResults<Tour>) => {
            this.tours = result.results;
          }
        });

      }
    })
  }

  trensformDifficulty(num : number) : string{
    if(num === 0){
      return "Easy";
    }
    else if(num === 1){
      return "Medium";
    }
    else{
      return "Hard";
    }
  }
}
