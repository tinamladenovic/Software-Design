import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/infrastructure/auth/auth.service';
import { User } from 'src/app/infrastructure/auth/model/user.model';
import { TourExecutionStatsService } from '../../tour-execution/tour-execution-stats.service';
import { MatDialog } from '@angular/material/dialog';
import { QuestionnaireDialogComponent } from '../user-profile/questionnaire-dialog/questionnaire-dialog.component';
import { AnswerDate } from '../model/userProfile.model';
import { LayoutService } from '../layout.service';

@Component({
  selector: 'xp-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit {
  user: User | undefined;
  completedTourCount: number;
  totalCoveredDistance: number;
  answerDate: AnswerDate;
  daysTimer: boolean = false;

  constructor(
    private authService: AuthService,
    private layoutService: LayoutService,
    private tourExecutionStatsService: TourExecutionStatsService,
    private dialog: MatDialog
  ) {}

  ngOnInit(): void {
    this.authService.user$.subscribe((user) => {
      this.user = user;
    });

    this.tourExecutionStatsService
      .getCompletedToursCount()
      .subscribe((count) => {
        this.completedTourCount = count;
      });

    this.tourExecutionStatsService
      .getTotalCoveredDistance()
      .subscribe((distance) => {
        this.totalCoveredDistance = distance;
      });

    this.layoutService.getLastAnswerDate(this.user?.id).subscribe((date) => {
      this.answerDate = date;
      if (
        !this.answerDate ||
        this.isMoreThan30DaysAgo(this.answerDate.lastAnswerDate)
      ) {
        this.daysTimer = true;
      }
    });
  }

  isMoreThan30DaysAgo(lastAnswerDate: Date): boolean {
    const thirtyDaysAgo = new Date();
    thirtyDaysAgo.setDate(thirtyDaysAgo.getDate() - 30);
    return lastAnswerDate < thirtyDaysAgo;
  }

  openQuestionnaireDialog(): void {
    if (this.user) {
      const dialogRef = this.dialog.open(QuestionnaireDialogComponent, {
        width: '700px',
        data: { userId: this.user.id },
      });
      dialogRef.afterClosed().subscribe({
        next: () => {
          this.daysTimer = false;
        },
      });
    }
  }
}
