import { Component, Input } from '@angular/core';
import { OrderItem } from '../../../model/available-tour-model';

@Component({
  selector: 'xp-tour-display-checkout',
  templateUrl: './tour-display-checkout.component.html',
  styleUrls: ['./tour-display-checkout.component.css']
})
export class TourDisplayCheckoutComponent {
  @Input() item : OrderItem;
  

}
