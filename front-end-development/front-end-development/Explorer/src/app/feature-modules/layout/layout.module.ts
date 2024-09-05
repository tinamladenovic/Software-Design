import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home/home.component';
import { NavbarComponent } from './navbar/navbar.component';
import { MaterialModule } from 'src/app/infrastructure/material/material.module';
import { RouterModule } from '@angular/router';
import { SharedModule } from 'src/app/shared/shared.module';
import { UserProfileComponent } from './user-profile/user-profile.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { UpdateUserProfileComponent } from './user-profile/update-user-profile/update-user-profile.component';
import { MatIconModule } from '@angular/material/icon';
import { NotificationDialogComponent } from './user-profile/notification-dialog/notification-dialog.component';
import { FilterPipe } from './user-profile/notification-dialog/filter.pipe';
import { FollowersDialogComponent } from './user-profile/followers-dialog/followers-dialog.component';
import { QuestionnaireDialogComponent } from './user-profile/questionnaire-dialog/questionnaire-dialog.component';

@NgModule({
  declarations: [
    HomeComponent,
    NavbarComponent,
    UserProfileComponent,
    UpdateUserProfileComponent,
    NotificationDialogComponent,
    FilterPipe,
    FollowersDialogComponent,
    QuestionnaireDialogComponent
  ],
  imports: [
    CommonModule,
    MaterialModule,
    RouterModule,
    SharedModule,
    ReactiveFormsModule,
    MatIconModule,
    FormsModule    
  ],
  exports: [
    NavbarComponent,
    HomeComponent,
    UserProfileComponent
  ]
})
export class LayoutModule {}
