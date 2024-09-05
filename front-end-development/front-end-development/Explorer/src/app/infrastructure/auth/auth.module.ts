import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login/login.component';
import { MaterialModule } from '../material/material.module';
import { ReactiveFormsModule } from '@angular/forms';
import { RegistrationComponent } from './registration/registration.component';
import {MatProgressSpinnerModule} from '@angular/material/progress-spinner';
import { UserLocationComponent } from './user-location/user-location.component';
import { MapComponent } from 'src/app/shared/map/map.component';
import { SharedModule } from 'src/app/shared/shared.module';



@NgModule({
  declarations: [
    LoginComponent,
    RegistrationComponent,
    UserLocationComponent
  ],
  imports: [
    CommonModule,
    MaterialModule,
    ReactiveFormsModule,
    MatProgressSpinnerModule,
    SharedModule
    
  ],
  exports: [
    LoginComponent
  ]
})
export class AuthModule { }
