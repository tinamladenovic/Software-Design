import { Component } from '@angular/core';
import { AuthService } from 'src/app/infrastructure/auth/auth.service';
import { User } from 'src/app/infrastructure/auth/model/user.model';
import { MarketplaceService } from '../marketplace.service';
import { CompositeTour } from '../model/composite-tour.model';

@Component({
  selector: 'xp-tourist-campaigns',
  templateUrl: './tourist-campaigns.component.html',
  styleUrls: ['./tourist-campaigns.component.css']
})
export class TouristCampaignsComponent {

  constructor(
    private authService : AuthService,
    private service : MarketplaceService,
    ){}

  user : User;
  compositeTours : CompositeTour[] = []

  ngOnInit(){
    this.authService.user$.subscribe((user) => {
      this.user = user;
      this.service.getTouristsCompositeToursTours(user.id).subscribe(
        (result) =>{
          this.compositeTours = result.results;
      })
    })
  }

}
