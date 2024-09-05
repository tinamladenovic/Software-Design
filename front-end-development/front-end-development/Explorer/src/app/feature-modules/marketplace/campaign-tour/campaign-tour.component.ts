import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Tour } from '../../tour-authoring/model/tour.model';

@Component({
  selector: 'xp-campaign-tour',
  templateUrl: './campaign-tour.component.html',
  styleUrls: ['./campaign-tour.component.css']
})
export class CampaignTourComponent {

  @Input() tour : Tour;
  @Output() addTour = new EventEmitter<Tour>;
  @Output() removeTour = new EventEmitter<Tour>;

  isAdded : boolean = false;


  addButtonClick(){
    this.isAdded = true;
    this.addTour.emit(this.tour);
  }

  removeButtonClick(){
    this.isAdded = false;
    this.removeTour.emit(this.tour);
  }

}
