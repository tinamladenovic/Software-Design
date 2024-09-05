import { Component, Input,Output,EventEmitter, SimpleChanges } from '@angular/core';
import { Tour } from '../model/tour.model';
import { Router } from '@angular/router';
import { TourAuthoringService } from '../tour-authoring.service';
import { Equipment } from '../../administration/model/equipment.model';
import { FormControl, FormGroup } from '@angular/forms';
import {MatIconModule} from'@angular/material/icon';
import { MatTooltipModule } from '@angular/material/tooltip';

@Component({
  selector: 'xp-author-tour',
  templateUrl: './author-tour.component.html',
  styleUrls: ['./author-tour.component.css']
})
export class AuthorTourComponent {
  @Input() tour : Tour;
  @Input() isSelectMode: boolean;
  @Output() showEquipments = new EventEmitter<Tour>
  @Output() addEquipment = new EventEmitter<Tour>
  @Output() editTour = new EventEmitter<Tour>
  @Output() archiveTour = new EventEmitter<Tour>
  @Output() publishTour = new EventEmitter<Tour>
  @Output() selectTour = new EventEmitter<Tour>
  @Output() deselectTour = new EventEmitter<Tour>

  constructor(private service : TourAuthoringService, private router : Router){};


  allEquipments : Equipment[];
  isPublished : boolean;
  isArchived : boolean;


  isAddEquipment : boolean = false;
  

  equipmentForm = new FormGroup({
    equipments: new FormControl([])
  });
  

  ngOnInit() : void{

    this.updateStatusFlags();
  }

  private updateStatusFlags(): void {
    if (this.tour.status === 0) {
      this.isPublished = false;
      this.isArchived = false;
    } else if (this.tour.status === 1) {
      this.isPublished = true;
      this.isArchived = false;
    } else {
      this.isPublished = false;
      this.isArchived = true;
    }
  }




  transformStatus(numberValue: number): string{
    if(numberValue === 0){
      return "Draft";
    }
    else if(numberValue === 1){
      return "Published"
    }
    else return "Archived"
  }

  transformDifficult(numberValue: number): string {
    if(numberValue === 0){
      return "Easy";
    }
    else if(numberValue === 1){
      return "Medium";
    }
    else return "Hard";
  }

  checkEquipmentClick(){
    this.showEquipments.emit(this.tour);
  }

  addEquipmentClick(){
    this.isAddEquipment = true;
    this.service.getAllEquipments().subscribe({
      next : (result) =>{
        this.allEquipments = result.results;


        const remainingEquipments = this.allEquipments.filter(
          (equipment) => this.tour.tourEquipment.some((tourEquipment) => tourEquipment.id === equipment.id)
        );

        this.equipmentForm = new FormGroup({
          equipments: new FormControl(remainingEquipments as never[] | null),
        });
        
      }
    })

    //this.addEquipment.emit(this.tour);
  }

  editTourClick(){
    this.editTour.emit(this.tour);
  }

  archiveTourClick(){
    this.archiveTour.emit(this.tour);
  }

  publishTourClick(){
    this.publishTour.emit(this.tour);
  }

  checkSelected(event : any) : void{
    if(event.checked){
      this.selectTour.emit(this.tour);
    }else{
      this.deselectTour.emit(this.tour);
    }
  }
  saveEquipments(){
    this.isAddEquipment = false;

  // Assuming 'equipments' is the name of the form control in equipmentForm
    const selectedEquipments = this.equipmentForm.get('equipments')?.value;

    let tempTour : Tour = this.tour;

    tempTour.tourEquipment = [];
    
    if (selectedEquipments) {
      for (const equipment of selectedEquipments) {
        tempTour.tourEquipment.push(equipment);
      }
    }


    this.service.updateTour(tempTour).subscribe({
      next : () =>{

      }
    })
  }

  goToStatistic(){
    this.router.navigate(['single-tour-statistic/'+ this.tour.id]);
  }

  

}
