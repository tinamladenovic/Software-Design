import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MapComponent } from './map/map.component';
import { ErrorPageComponent } from './error-page/error-page.component';
import { CarouselComponent } from './carousel/carousel.component';
import { MatTabsModule } from '@angular/material/tabs';
import { MatTableModule } from '@angular/material/table';
import { MatIconModule } from '@angular/material/icon';
import { MatTooltipModule } from '@angular/material/tooltip';



@NgModule({
  declarations: [
    MapComponent,
    ErrorPageComponent,
    CarouselComponent
  ],
  imports: [
    CommonModule
  ],
  exports: [
    MapComponent,
    CarouselComponent,
    MatTabsModule,
    MatTableModule,
    MatIconModule,
    MatTooltipModule
  ]
})
export class SharedModule { }
