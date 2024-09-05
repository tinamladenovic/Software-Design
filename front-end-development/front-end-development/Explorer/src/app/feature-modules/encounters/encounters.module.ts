import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EncounterComponent } from './encounter/encounter.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { EncounterFormComponent } from './encounter-form/encounter-form.component';
import { MaterialModule } from 'src/app/infrastructure/material/material.module';
import {MatCheckboxModule} from '@angular/material/checkbox';
import { MatFormFieldModule } from '@angular/material/form-field';
import {MatIconModule} from '@angular/material/icon';
import { MatSelectModule } from '@angular/material/select';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatTabsModule } from '@angular/material/tabs';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { EncountersExecutionComponent } from './encounters-execution/encounters-execution.component';



@NgModule({
  declarations: [
    EncounterComponent,
    EncounterFormComponent,
    EncountersExecutionComponent
  ],
  imports: [
    CommonModule,
    MaterialModule,
    ReactiveFormsModule,
    MatSelectModule,
    SharedModule,
    MatFormFieldModule,
    FormsModule,
    MatCheckboxModule,
    MatTabsModule,
  ],
  exports: [
    EncounterComponent,
    EncounterFormComponent,
    EncountersExecutionComponent
  ]
})
export class EncountersModule { }
