import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { TouristCompletedTours } from '../model/tourist-completed-tours';
import { TouristCoveredDistance } from '../model/tourist-covered-distance';
import { TourExecutionStatsService } from '../tour-execution-stats.service';
import { DateTimeService } from 'src/app/shared/date-time.service';
import { TokenStorage } from 'src/app/infrastructure/auth/jwt/token.service';
import { JwtHelperService } from '@auth0/angular-jwt';

@Component({
  selector: 'xp-tour-execution-leaderboards',
  templateUrl: './tour-execution-leaderboards.component.html',
  styleUrls: ['./tour-execution-leaderboards.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class TourExecutionLeaderboardsComponent implements OnInit{
  completedToursCurrentMonth: TouristCompletedTours[] = [];
  completedToursCurrentWeek: TouristCompletedTours[] = [];
  coveredDistancesCurrentMonth: TouristCoveredDistance[] = [];
  coveredDistancesCurrentWeek: TouristCoveredDistance[] = [];
  weekEndTime: Date;
  monthEndTime: Date;
  weekCountdown: string;
  monthCountdown: string;
  userId: number;
  completedToursCurrentMonthDisplayed: TouristCompletedTours[] = [];
  completedToursCurrentMonthIndex: number = 0;
  completedToursCurrentWeekDisplayed: TouristCompletedTours[] = [];
  completedToursCurrentWeekIndex: number = 0;
  coveredDistancesCurrentMonthDisplayed: TouristCoveredDistance[] = [];
  coveredDistaceCurrentMonthIndex: number = 0;
  coveredDistancesCurrentWeekDisplayed: TouristCoveredDistance[] = [];
  coveredDistaceCurrentWeekIndex: number = 0;

  constructor(
    private tourExecutionStatsService: TourExecutionStatsService,
    private dateTimeService: DateTimeService,
    private tokenStorage: TokenStorage
  ) { }

  ngOnInit(): void {
    this.loadCompletedToursCurrentMonth();
    this.loadCompletedToursCurrentWeek();
    this.loadCoveredDistancesCurrentMonth();
    this.loadCoveredDistancesCurrentWeek();
    this.weekEndTime = this.dateTimeService.getEndOfWeek();
    this.monthEndTime = this.dateTimeService.getEndOfMonth();
    this.updateCountdown();
    this.getUserId();
  }

  getUserId(): void {
    const jwtHelperService = new JwtHelperService();
    const accessToken = this.tokenStorage.getAccessToken();
    if (accessToken == null) {
      return;
    }
    const decodedToken = jwtHelperService.decodeToken(accessToken);
    this.userId = decodedToken.id;
  }

  updateCountdown(): void {
    setInterval(() => {
      this.weekCountdown = this.dateTimeService.getCountdown(this.weekEndTime);
      this.monthCountdown = this.dateTimeService.getCountdown(this.monthEndTime);
    }, 1000);
  }

  loadCompletedToursCurrentMonth(): void {
    this.tourExecutionStatsService.getTouristsRankedByCompletedToursCurrentMonth().subscribe((result) => {
      this.completedToursCurrentMonth = result.results;
      this.loadCompletedToursCurrentMonthDisplayed();
    });
  }

  loadCompletedToursCurrentWeek(): void {
    this.tourExecutionStatsService.getTouristsRankedByCompletedToursCurrentWeek().subscribe((result) => {
      this.completedToursCurrentWeek = result.results;
      this.loadCompletedToursCurrentWeekDisplayed();
    });
  }

  loadCoveredDistancesCurrentMonth(): void {
    this.tourExecutionStatsService.getTouristsRankedByCoveredDistanceCurrentMonth().subscribe((result) => {
      this.coveredDistancesCurrentMonth = result.results;
      this.loadCoveredDistancesCurrentMonthDisplayed();
    });
  }

  loadCoveredDistancesCurrentWeek(): void {
    this.tourExecutionStatsService.getTouristsRankedByCoveredDistanceCurrentWeek().subscribe((result) => {
      this.coveredDistancesCurrentWeek = result.results;
      this.loadCoveredDistancesCurrentWeekDisplayed();
    });
  }

  loadCompletedToursCurrentMonthDisplayed(): void {
    const index = this.completedToursCurrentMonthIndex;
    this.completedToursCurrentMonthDisplayed = this.completedToursCurrentMonth.slice(index * 5, index * 5 + 5);
  }

  onPrevCompletedToursMonthly() : void {
    if (this.completedToursCurrentMonthIndex > 0) {
      this.completedToursCurrentMonthIndex--;
      this.loadCompletedToursCurrentMonthDisplayed();
    }
  }

  onNextCompletedToursMonthly() : void {
    if (this.completedToursCurrentMonthIndex < this.completedToursCurrentMonth.length / 5 - 1) {
      this.completedToursCurrentMonthIndex++;
      this.loadCompletedToursCurrentMonthDisplayed();
    }
  }

  loadCompletedToursCurrentWeekDisplayed(): void {
    const index = this.completedToursCurrentWeekIndex;
    this.completedToursCurrentWeekDisplayed = this.completedToursCurrentWeek.slice(index * 5, index * 5 + 5);
  }

  onPrevCompletedToursWeekly() : void {
    if (this.completedToursCurrentWeekIndex > 0) {
      this.completedToursCurrentWeekIndex--;
      this.loadCompletedToursCurrentWeekDisplayed();
    }
  }

  onNextCompletedToursWeekly() : void {
    if (this.completedToursCurrentWeekIndex < this.completedToursCurrentWeek.length / 5 - 1) {
      this.completedToursCurrentWeekIndex++;
      this.loadCompletedToursCurrentWeekDisplayed();
    }
  }

  loadCoveredDistancesCurrentMonthDisplayed(): void {
    const index = this.coveredDistaceCurrentMonthIndex;
    this.coveredDistancesCurrentMonthDisplayed = this.coveredDistancesCurrentMonth.slice(index * 5, index * 5 + 5);
  }

  onPrevCoveredDistanceMonthly() : void {
    if (this.coveredDistaceCurrentMonthIndex > 0) {
      this.coveredDistaceCurrentMonthIndex--;
      this.loadCoveredDistancesCurrentMonthDisplayed();
    }
  }

  onNextCoveredDistanceMonthly() : void {
    if (this.coveredDistaceCurrentMonthIndex < this.coveredDistancesCurrentMonth.length / 5 - 1) {
      this.coveredDistaceCurrentMonthIndex++;
      this.loadCoveredDistancesCurrentMonthDisplayed();
    }
  }

  loadCoveredDistancesCurrentWeekDisplayed(): void {
    const index = this.coveredDistaceCurrentWeekIndex;
    this.coveredDistancesCurrentWeekDisplayed = this.coveredDistancesCurrentWeek.slice(index * 5, index * 5 + 5);
  }

  onPrevCoveredDistanceWeekly() : void {
    if (this.coveredDistaceCurrentWeekIndex > 0) {
      this.coveredDistaceCurrentWeekIndex--;
      this.loadCoveredDistancesCurrentWeekDisplayed();
    }
  }

  onNextCoveredDistanceWeekly() : void {
    if (this.coveredDistaceCurrentWeekIndex < this.coveredDistancesCurrentWeek.length / 5 - 1) {
      this.coveredDistaceCurrentWeekIndex++;
      this.loadCoveredDistancesCurrentWeekDisplayed();
    }
  }

}
