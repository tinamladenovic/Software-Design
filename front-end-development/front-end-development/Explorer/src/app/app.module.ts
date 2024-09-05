import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './infrastructure/routing/app-routing.module';
import { AppComponent } from './app.component';
import { LayoutModule } from './feature-modules/layout/layout.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from './infrastructure/material/material.module';
import { AdministrationModule } from './feature-modules/administration/administration.module';
import { BlogModule } from './feature-modules/blog/blog.module';
import { MarketplaceModule } from './feature-modules/marketplace/marketplace.module';
import { TourAuthoringModule } from './feature-modules/tour-authoring/tour-authoring.module';
import { TourExecutionModule } from './feature-modules/tour-execution/tour-execution.module';
import { AuthModule } from './infrastructure/auth/auth.module';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { JwtInterceptor } from './infrastructure/auth/jwt/jwt.interceptor';

import { SharedModule } from './shared/shared.module';
import { ConfirmationDialogComponent } from './shared/confirmation-dialog/confirmation-dialog.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatTabsModule } from '@angular/material/tabs';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MarkdownModule } from 'ngx-markdown';


import { MatSelectModule } from '@angular/material/select';
import { MatTableModule } from '@angular/material/table';
import { ToastrModule } from 'ngx-toastr';
import { EncountersModule } from './feature-modules/encounters/encounters.module';
import { TourTouristModule } from './feature-modules/tour-tourist/tour-tourist.module';

@NgModule({
  declarations: [AppComponent, ConfirmationDialogComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    LayoutModule,
    BrowserAnimationsModule,
    MaterialModule,
    AdministrationModule,
    TourAuthoringModule,
    BlogModule,
    MarketplaceModule,
    EncountersModule,
    TourExecutionModule,
    AuthModule,
    HttpClientModule,
    SharedModule,
    MatSelectModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    ReactiveFormsModule,
    FormsModule,
    MatInputModule,
    MatTableModule,
    MatTabsModule,
    MatCardModule,
    MatButtonModule,

    MarkdownModule.forRoot(),
    ToastrModule.forRoot({
      positionClass: 'toast-bottom-right',
      preventDuplicates: true,
      countDuplicates: true,
      closeButton: true,
      progressBar: true,
      progressAnimation: 'decreasing',
      timeOut: 3000,
    }),
    BrowserAnimationsModule,
    TourTouristModule,
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: JwtInterceptor,
      multi: true,
    },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
