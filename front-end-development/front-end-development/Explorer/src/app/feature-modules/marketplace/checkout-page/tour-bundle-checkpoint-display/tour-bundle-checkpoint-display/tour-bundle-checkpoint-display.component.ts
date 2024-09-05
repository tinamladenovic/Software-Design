import { Component, Input } from '@angular/core';
import { BundleItem } from '../../../model/available-tour-model';

@Component({
  selector: 'xp-tour-bundle-checkpoint-display',
  templateUrl: './tour-bundle-checkpoint-display.component.html',
  styleUrls: ['./tour-bundle-checkpoint-display.component.css']
})
export class TourBundleCheckpointDisplayComponent {
  @Input() bundleItem: BundleItem;
}
