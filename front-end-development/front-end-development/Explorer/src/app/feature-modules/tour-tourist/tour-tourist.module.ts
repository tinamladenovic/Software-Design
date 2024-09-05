import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TourCreationComponent } from './tour-creation/tour-creation.component';
import { MaterialModule } from 'src/app/infrastructure/material/material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatSelectModule } from '@angular/material/select';
import { SharedModule } from 'src/app/shared/shared.module';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatTabsModule } from '@angular/material/tabs';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatDialogModule } from '@angular/material/dialog';
import { MatTableModule } from '@angular/material/table';
import { ToursComponent } from './tours/tours.component';

@NgModule({
  declarations: [TourCreationComponent, ToursComponent],
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
    MatCheckboxModule,
    MatDialogModule,
    MatTableModule,
  ],
})
export class TourTouristModule {}
