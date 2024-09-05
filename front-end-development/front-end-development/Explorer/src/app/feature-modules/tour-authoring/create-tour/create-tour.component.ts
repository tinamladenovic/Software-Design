import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Tour } from '../model/tour.model';
import { TourAuthoringService } from '../tour-authoring.service';
import { PagedResults } from 'src/app/shared/model/paged-results.model';
import { AuthService } from 'src/app/infrastructure/auth/auth.service';
import { User } from 'src/app/infrastructure/auth/model/user.model';
import { Equipment } from '../../administration/model/equipment.model';
import { ActivatedRoute, NavigationExtras, Router } from '@angular/router';
import { TourDataService } from '../tourData.service';



@Component({
  selector: 'xp-create-tour',
  templateUrl: './create-tour.component.html',
  styleUrls: ['./create-tour.component.css']
})
export class CreateTourComponent implements OnInit {
  
  @Output() equimpentUpdated = new EventEmitter<null>();
  constructor(
    private service: TourAuthoringService,
    private authService: AuthService,
    private router: Router,
    private route: ActivatedRoute,
    private tourDataService: TourDataService
    ){
      this.tourId = tourDataService.getTourId();
    };
  
  user: User 

  tourId : number;
  tour : Tour;

   
  isFormFull : boolean = false;

  tourForm = new FormGroup({
    name: new FormControl('',[Validators.required]),
    description: new FormControl('', [Validators.required]),
    difficult: new FormControl(0),
    tags: new FormControl([])
  });


  ngOnInit(): void {

    this.authService.user$.subscribe(user => {
      this.user = user;
    });

    if(this.tourId != 0){
      this.service.getTourById(this.tourId).subscribe((result) => {
        if(result.status === 0){

          this.tour = result;


          

          var alltags = result.tags.split(',');

          this.tourForm = new FormGroup({
            name: new FormControl(result.name,[Validators.required]),
            description: new FormControl(result.description, [Validators.required]),
            difficult: new FormControl(result.difficult),
            tags: new FormControl(alltags as never[] | null)
          });

          this.updateIsFormFull();
        }
      })
    }

    this.tourForm.get('name')?.valueChanges.subscribe(() => this.updateIsFormFull());
    this.tourForm.get('description')?.valueChanges.subscribe(() => this.updateIsFormFull());
  }

  updateIsFormFull() {
    const name = this.tourForm.get('name')?.value;
    const description = this.tourForm.get('description')?.value;
    this.isFormFull = !!(name && description);
  }

  

  allTags: string[] = [
    "adventure", "family", "nature", "urban", "action", "relaxation", "culture", "education",
   "mountain", "hiking", "historical", "eco","winter", "summer", "extreme","solo", "group",
   "photography", "art", "architectural","wildlife", "food", "river", "city"
  ];
  


  submitForm(): Tour {

    let tour: Tour;
    if(this.tourId != 0){
      tour = {
        id: this.tour.id,
        authorId : this.user?.id,
        name : this.tourForm.value.name || "",
        description : this.tourForm.value.description || "",
        tags : this.tourForm.value.tags?.join(",") || "",
        difficult : Number(this.tourForm.value.difficult) || 0,
        status : this.tour.status,
        price : this.tour.price,
        distance: this.tour.distance,
        travelTimeAndMethod : this.tour.travelTimeAndMethod,
        checkpoints : this.tour.checkpoints,
        publishTime : this.tour.publishTime,
        archiveTime : this.tour.archiveTime,
        tourEquipment: this.tour.tourEquipment,
      }
    }
    else{
      tour = {
        id: 0,
        authorId : this.user?.id,
        name : this.tourForm.value.name || "",
        description : this.tourForm.value.description || "",
        tags : this.tourForm.value.tags?.join(",") || "",
        difficult : Number(this.tourForm.value.difficult) || 0,
        status : 0,
        price : 0,
        distance: 0,
        travelTimeAndMethod : [],
        checkpoints : [],
        publishTime : new Date(),
        archiveTime : new Date(),
        tourEquipment : [],
      }
    }

    return tour;
  }

  saveAndContinueLater(): void{
    

    this.service.updateTour(this.submitForm()).subscribe({
      next : () => {
        this.router.navigate(['/author/tour-checkpoints'])
      }
    })
  }



  goToNextPage(){

    this.service.updateTour(this.submitForm()).subscribe((addedTour : Tour) => {
      this.tourDataService.setTourId(addedTour.id);

      this.router.navigate(['/author/tour-checkpoints'])
    })

    

     
  }
}
