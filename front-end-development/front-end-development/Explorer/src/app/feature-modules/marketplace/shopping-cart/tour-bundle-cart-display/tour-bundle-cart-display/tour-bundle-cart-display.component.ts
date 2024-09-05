import { Component, EventEmitter, Input, Output } from '@angular/core';
import { BundleItem } from '../../../model/available-tour-model';
import { MarketplaceService } from '../../../marketplace.service';

@Component({
  selector: 'xp-tour-bundle-cart-display',
  templateUrl: './tour-bundle-cart-display.component.html',
  styleUrls: ['./tour-bundle-cart-display.component.css']
})
export class TourBundleCartDisplayComponent {
  @Input() bundles : BundleItem[];
  @Output() removeFromCart : EventEmitter<number> = new EventEmitter<number>();

  constructor(
    private service : MarketplaceService
  ){}


  removeFromCart_click(bundleId: number) {
    this.removeFromCart.emit(bundleId);
  }
}
