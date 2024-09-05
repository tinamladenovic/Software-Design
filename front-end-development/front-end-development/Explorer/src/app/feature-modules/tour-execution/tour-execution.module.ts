import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReportFormComponent } from './report-form/report-form.component';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatSelectModule } from '@angular/material/select';
import { MatDatepickerModule} from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MaterialModule } from 'src/app/infrastructure/material/material.module';
import { PositionSimulatorComponent } from './position-simulator/position-simulator.component';
import { SharedModule } from "../../shared/shared.module";
import { TourRatingComponent } from './tour-rating/tour-rating.component';
import { TourExecutionLeaderboardsComponent } from './tour-execution-leaderboards/tour-execution-leaderboards.component';




@NgModule({
    declarations: [
        ReportFormComponent,
        PositionSimulatorComponent,
        TourRatingComponent,
        TourExecutionLeaderboardsComponent
    ],
    imports: [
        CommonModule,
        MatInputModule,
        MatFormFieldModule,
        FormsModule,
        ReactiveFormsModule,
        MatSelectModule,
        MatDatepickerModule,
        MatNativeDateModule,
        MaterialModule,
        SharedModule,
    ]
})
export class TourExecutionModule { }
