import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DestinationFormComponent } from './destination-form/destination-form.component';
import { DestinationComponent } from './destination/destination.component';
import { MaterialModule } from 'src/app/infrastructure/material/material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatSelectModule } from '@angular/material/select';
import { CheckpointAddComponent } from './checkpoint-add/checkpoint-add.component';
import { SharedModule } from '../../shared/shared.module';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatTabsModule } from '@angular/material/tabs';
import { MatIconModule } from '@angular/material/icon';
import { CreateTourComponent } from './create-tour/create-tour.component';
import { ReviewTourComponent } from './review-tour/review-tour.component';
import {
  MatDatepicker,
  MatDatepickerModule,
} from '@angular/material/datepicker';
import { AuthorToursDisplayComponent } from './author-tours-display/author-tours-display.component';
import { TourCheckpointsDisplayComponent } from './tour-checkpoints-display/tour-checkpoints-display.component';
import { TourCheckpointComponent } from './tour-checkpoint/tour-checkpoint.component';
import { PublishTourComponent } from './publish-tour/publish-tour.component';
import { AuthorTourComponent } from './author-tour/author-tour.component';
import { TourSaleComponent } from './tour-sale/tour-sale.component';
import { TourSalePreviewComponent } from './tour-sale-preview/tour-sale-preview.component';

import { EncountersModule } from '../encounters/encounters.module';
import {MatCheckboxModule} from '@angular/material/checkbox';
import {MatDialogModule} from '@angular/material/dialog';
import { TourBundleDialogComponent } from './tour-bundle-dialog/tour-bundle-dialog.component';
import { TourBundlesOverviewComponent } from './tour-bundles-overview/tour-bundles-overview.component';
import {MatTableModule} from '@angular/material/table';
import { CreateCouponComponent } from './create-coupon/create-coupon.component';
import { TourStatisticModule } from './tour-statistic/tour-statistic.module';

@NgModule({
  declarations: [
    DestinationFormComponent,
    DestinationComponent,
    CheckpointAddComponent,
    CreateTourComponent,
    ReviewTourComponent,
    AuthorToursDisplayComponent,
    TourCheckpointsDisplayComponent,
    TourCheckpointComponent,
    PublishTourComponent,
    AuthorTourComponent,
    TourSaleComponent,
    TourSalePreviewComponent,
    TourBundleDialogComponent,
    TourBundlesOverviewComponent,
    CreateCouponComponent,
  ],
  imports: [
    CommonModule,
    MaterialModule,
    ReactiveFormsModule,
    MatSelectModule,
    SharedModule,
    MatFormFieldModule,
    MatInputModule,
    FormsModule,
    MatTabsModule,
    MatDatepickerModule,
    EncountersModule,
    MatCheckboxModule,
    MatDialogModule,
    MatTableModule,
    TourStatisticModule,
  ],
  exports: [
    DestinationFormComponent,
    DestinationComponent,
    CreateTourComponent,
    AuthorToursDisplayComponent,
  ],
})
export class TourAuthoringModule {}
