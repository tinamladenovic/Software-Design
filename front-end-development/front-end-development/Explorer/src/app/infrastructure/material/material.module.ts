import { NgModule } from '@angular/core';
import {MatCard, MatCardModule} from '@angular/material/card';
import { CommonModule } from '@angular/common';
import {MatToolbar, MatToolbarModule,} from '@angular/material/toolbar';
import {MatButton, MatButtonModule, MatIconButton} from '@angular/material/button';
import {MatFormField, MatFormFieldModule, MatLabel} from '@angular/material/form-field';
import {MatInput, MatInputModule} from '@angular/material/input';
import {MatTable, MatTableModule} from '@angular/material/table';
import {MatIcon, MatIconModule} from '@angular/material/icon';
import {MatSelectModule} from "@angular/material/select";
import { MatTab, MatTabsModule } from '@angular/material/tabs';

@NgModule({
  declarations: [],
  imports: [
    MatToolbarModule,
    CommonModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    MatTableModule,
    MatCardModule,
    MatSelectModule,
    MatIconModule,
    MatTabsModule
  ],
  exports: [
    MatToolbar,
    MatButton,
    MatFormField,
    MatLabel,
    MatInput,
    MatTable,
    MatIconButton,
    MatIcon,
    MatCard,
    MatSelectModule,
    MatTab
  ]
})
export class MaterialModule { }
