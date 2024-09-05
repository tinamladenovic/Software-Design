import { Component } from '@angular/core';
import { MarketplaceService } from '../marketplace.service';
import { User } from 'src/app/infrastructure/auth/model/user.model';
import { AuthService } from 'src/app/infrastructure/auth/auth.service';
import { TourAuthoringService } from '../../tour-authoring/tour-authoring.service';
import { Tour } from '../../tour-authoring/model/tour.model';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { CompositeTour } from '../model/composite-tour.model';
import { Router } from '@angular/router';

@Component({
  selector: 'xp-create-campaign',
  templateUrl: './create-campaign.component.html',
  styleUrls: ['./create-campaign.component.css']
})
export class CreateCampaignComponent {

  user : User;
  touristTours : Tour[] = [];
  compositeTourTours : Tour[] = [];
  pageSize : number = 0;
  pageIndex : number = 0;

  isAllValid : boolean = false;

  constructor(
    private service : MarketplaceService,
    private authService : AuthService,
    private tourAuthoringService : TourAuthoringService,
    private router : Router,
    ){}

  compositeTourForm = new FormGroup({
    name: new FormControl('',[Validators.required]),
  });


  ngOnInit(){
    this.authService.user$.subscribe((user) => {
      this.user = user;
      this.service.getTouristOrders(user.id).subscribe({
        next : (result) =>{
          result.results.forEach((order, index) => {
            this.tourAuthoringService.getTourById(order.tourId).subscribe({
              next : (result) =>{
                  this.touristTours.push(result);
              }
            })
          });
        }
      })


    });

    this.compositeTourForm.get('name')?.valueChanges.subscribe(() => this.updateIsAllValid());
  }

  updateIsAllValid(){
    const ime = this.compositeTourForm.get('name')?.value;
    if(ime !== "" && this.compositeTourTours.length >=2){
      this.isAllValid = true;
    }
    else{
      this.isAllValid = false;
    }
  }

  addTourToArray(tour : Tour){
    this.compositeTourTours.push(tour);
    this.updateIsAllValid();

  }

  removeTourFromArray(tour : Tour){
    let temp = this.compositeTourTours.filter(t => t.id !== tour.id);
    this.compositeTourTours = temp;
    this.updateIsAllValid();
  }


  createCompositeTour(){
    let compositeTour : CompositeTour;
    compositeTour = {
      id : 0,
      touristId : this.user.id,
      name : this.compositeTourForm.value.name || "",
      tours : this.compositeTourTours,
      distance : 0,
      difficult : 0,
      equipments : [],
      checkpoints : []
    }

    if(compositeTour.touristId != 0 && compositeTour.name != "" && compositeTour.tours.length >= 2){
      this.service.createCompositeTour(compositeTour).subscribe({
        next : () =>{
          this.router.navigate(['tourist/tourist-campaigns']);
        }
      })
    }

    
  }

  
}
