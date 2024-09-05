import { Component, Input,Output} from '@angular/core';
import { CompositeTour } from '../model/composite-tour.model';
import { Router } from '@angular/router';

@Component({
  selector: 'xp-single-campaign',
  templateUrl: './single-campaign.component.html',
  styleUrls: ['./single-campaign.component.css']
})
export class SingleCampaignComponent {

  @Input() compositeTour : CompositeTour;

  constructor(private router : Router){}

  transformDifficult(numberValue: number): string {
    if(numberValue === 0){
      return "Easy";
    }
    else if(numberValue === 1){
      return "Medium";
    }
    else return "Hard";
  }

  startClick(){
    this.router.navigate(['/position-simulator/'+ this.compositeTour.id+'/1']);
  }
}
