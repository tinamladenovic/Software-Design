import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { TourDataService } from '../tourData.service';
import { TourAuthoringService } from '../tour-authoring.service';
import { Tour } from '../model/tour.model';
import { CheckpointService } from '../checkpoint.service';

@Component({
  selector: 'xp-publish-tour',
  templateUrl: './publish-tour.component.html',
  styleUrls: ['./publish-tour.component.css']
})
export class PublishTourComponent {

  tourId: number;
  tour: Tour;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private tourDataService : TourDataService,
    private service : TourAuthoringService,
    private checkpointService: CheckpointService,
  ){
    this.tourId = tourDataService.getTourId();
  };

  ngOnInit(): void{

    if(!isNaN(this.tourId) && this.tourId != 0){
      this.service.getTourById(this.tourId).subscribe({
        next: (result) =>{
          this.tour = result;
          this.checkpointService.getCheckpoints(this.tourId).subscribe({
            next : (checkpoints) =>{
              this.tour.checkpoints = checkpoints.results;
            }
          })

        }
      })
      
    }
    else{
      this.router.navigate(['/author/tours'])
    }

    

  }

  publish(){
    var isOk = true;
    if(!this.tour.name){
      isOk = false;
    }
    if(!this.tour.description){
      isOk = false;
    }
    if(this.tour.checkpoints.length < 2){
      isOk = false;
    }
    if(!this.tour.tags){
      isOk = false;
    }
    if(this.tour.travelTimeAndMethod.length === 0){
      isOk = false;
    }

    if(isOk){
      this.service.publishTour(this.tourId).subscribe({
        next : () =>{
          this.router.navigate(['/author/tours'])
        }
      })
    }
    else{
      alert("Error. The tour was not created correctly, please try again ");
    }

  }

  saveForLater(){
    this.router.navigate(['/author/tours']) 
  }
}
