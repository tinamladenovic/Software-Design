import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Tour } from '../model/tour.model';
import { TourAuthoringService } from '../tour-authoring.service';
import { AuthService } from 'src/app/infrastructure/auth/auth.service';
import { Equipment } from '../../administration/model/equipment.model';
import { FormControl, FormGroup, Validators } from '@angular/forms';

import { PagedResults } from 'src/app/shared/model/paged-results.model';
import { User } from 'src/app/infrastructure/auth/model/user.model';
import { Router } from '@angular/router';
import { TourDataService } from '../tourData.service';
import { Location } from '@angular/common';
import { MatDialog } from '@angular/material/dialog';
import { TourBundleDialogComponent } from '../tour-bundle-dialog/tour-bundle-dialog.component';
import { TourStatus } from '../model/tour-status';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'xp-author-tours-display',
  templateUrl: './author-tours-display.component.html',
  styleUrls: ['./author-tours-display.component.css']
})
export class AuthorToursDisplayComponent {
  
  constructor(
    private authService : AuthService,
    private service: TourAuthoringService,
    private router : Router,
    private tourDataService: TourDataService,
    private location : Location,
    private dialog: MatDialog,
    private toastr: ToastrService,
    ){};

  equipment: Equipment [] = []; 
  selectedTours: TourStatus [] = [];
  isSelectMode : boolean = false;
  equipmentItem : Equipment;
  selectedTour : Tour;
  selectedToursPrice: number;
  equipmentForm = new FormGroup({
    name: new FormControl('', [Validators.required]),
    description: new FormControl('', [Validators.required])
  })

  tours: Tour[] = [];
  user: User

  showAddEquipmentForm : boolean = false;

  ngOnInit() : void {
    
    this.authService.user$.subscribe(user => {
      this.user = user;
    });

    this.selectedToursPrice = 0;

    this.service.getAuthorTours(this.user.id).subscribe({
      next: (result: PagedResults<Tour>) => {
        this.tours = result.results;
      }
    });
  }

  manageEquipment(tour : Tour) {

    this.equipment = tour.tourEquipment;
    this.selectedTour = tour;

    // this.service.getEquipmentForTour(tour.id, 0, 0).subscribe({
    //   next: (result) => {
    //     // Assuming 'result' is an array of tourists
    //     this.equipment = result.results;
    //     this.selectedTour = tour;
    //   },
    //   error: (error) => {
    //     console.error('Error loading equipment:', error);
    //   }
    // });  
  } 

  deleteEquipment(equipmentItem: Equipment) {
    if (equipmentItem.id !== undefined) {
      this.service.deleteEquipment(equipmentItem.id).subscribe({
        next: () => {
          this.service.getEquipmentForTour(this.selectedTour.id, 0, 0).subscribe({
            next: (result) => {
              // Assuming 'result' is an array of tourists
              this.equipment = result.results;
              
            }
          });
        }
      });
    } else {
      console.error('Cannot delete equipment with undefined ID');
    }
  }


  addEquipment(){
    const newEquipment: Equipment = {
      name: this.equipmentForm.value.name || "",
      description: this.equipmentForm.value.description || "",
      id: 0,
    };
    this.service.addEquipment(newEquipment);
    this.service.addEquipment(newEquipment).subscribe({
      next: () => {
        this.manageEquipment(this.selectedTour);
      }
    });
    }

  addEquipmentClick(clickedTour : Tour){
    this.selectedTour = clickedTour;
    this.showAddEquipmentForm = !this.showAddEquipmentForm;
  }

  editSelectedTour(tour : Tour){
    this.tourDataService.setTourId(tour.id)
    this.router.navigate(['/author/create-new-tour'])
  }

  addNewTour(){
    this.tourDataService.setTourId(0);
    this.router.navigate(['/author/create-new-tour'])
  }

  archiveSelectedTour(tour : Tour){
    this.service.archiveTour(tour.id).subscribe({
      next : () =>{
        this.toastr.success("Tour is succesfully archived")
        //alert("Tour is seccesfully archived")
        this.reloadComponent();
      }
    })
  }

  publishSelectedTour(tour : Tour){
    this.service.publishTour(tour.id).subscribe({
      next : () =>{
        this.toastr.success("Tour is seccesfully published")
        //alert("Tour is seccesfully published");
        this.reloadComponent();
      }
    })
  }

  addSelected(event : Tour) : void{
    const newTour : TourStatus = {
      tourId: event.id,
      status: event.status,
      tourName: event.name
    }
    this.selectedTours.push(newTour);
    this.selectedToursPrice += event.price;
    console.log("Tours: ", this.selectedTours, " ------------ price: ", this.selectedToursPrice);
  }
  deselectTour(event: Tour) : void {
    const tourToRemoveIndex = this.selectedTours.findIndex((tourStatus) => tourStatus.tourId === event.id);
    if (tourToRemoveIndex !== -1) {
      const removedTour = this.selectedTours.splice(tourToRemoveIndex, 1)[0];
      this.selectedToursPrice -= event.price;
    }
    console.log("Tours: ", this.selectedTours, " ------------ price: ", this.selectedToursPrice);
  }

  reloadComponent() {
    window.location.reload();
  }

  createBundle() {
    this.isSelectMode = true;
  }

  createCoupon(){
    this.router.navigate(['author/create-coupon']);
  }

  cancelCreatingBundle() : void
  {
    this.isSelectMode = false;
  }
  proceedBundle() : void{
    const dialogRef = this.dialog.open(TourBundleDialogComponent, {
      data: {
        selectedTourPrice: this.selectedToursPrice,
        selectedTours: this.selectedTours
      }
    });
  }

}
