import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EquipmentFormComponent } from './equipment-form/equipment-form.component';
import { EquipmentComponent } from './equipment/equipment.component';
import { MaterialModule } from 'src/app/infrastructure/material/material.module';
import { ReactiveFormsModule } from '@angular/forms';
import { TouristNotesComponent } from './tourist-notes/tourist-notes.component';
import { TouristNotesFormComponent } from './tourist-notes-form/tourist-notes-form.component';
import { IssueReportsComponent } from './issue-reports/issue-reports.component';
import { MatTable, MatTableModule } from '@angular/material/table';
import { MatDialogModule } from '@angular/material/dialog';
import { MatPaginatorModule } from '@angular/material/paginator';
import { ApplicationRateFormComponent } from './application-rates/application-rate-form/application-rate-form.component';
import { ApplicationRatesTableComponent } from './application-rates/application-rates-table/application-rates-table.component';
import { ReportCommentsComponent } from './report-comments/report-comments.component';
import { UmComponent } from './um/um.component';
import { UserDialogComponent } from './user-dialog/user-dialog.component';

@NgModule({
  declarations: [
    EquipmentFormComponent,
    EquipmentComponent,
    TouristNotesComponent,
    TouristNotesFormComponent,
    IssueReportsComponent,
    ApplicationRateFormComponent,
    ApplicationRatesTableComponent,
    ReportCommentsComponent,
    UmComponent,
    UserDialogComponent,
  ],
  imports: [
    CommonModule,
    MaterialModule,
    ReactiveFormsModule,
    MatTableModule,
    MatDialogModule,
    MatPaginatorModule,
  ],
  exports: [
    EquipmentComponent,
    EquipmentFormComponent,
    TouristNotesComponent,
    TouristNotesFormComponent,
    IssueReportsComponent,
    ReportCommentsComponent
  ]
})
export class AdministrationModule {}
