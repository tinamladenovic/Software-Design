import { Component, OnInit } from '@angular/core';

import * as paginator from '@angular/material/paginator';
import { TourAuthoringService } from '../../tour-authoring/tour-authoring.service';
import { AuthService } from 'src/app/infrastructure/auth/auth.service';
import { User } from 'src/app/infrastructure/auth/model/user.model';
import { PagedResults } from 'src/app/shared/model/paged-results.model';
import { DatePipe } from '@angular/common';
import { AvailableTour } from '../model/available-tour-model';
import { Router } from '@angular/router';

@Component({
  selector: 'xp-tourist-bought-tours',
  templateUrl: './tourist-bought-tours.component.html',
  styleUrls: ['./tourist-bought-tours.component.css'],
  providers: [DatePipe],
})
export class TouristBoughtToursComponent implements OnInit {
  user: User;
  availableTours: AvailableTour[] = [];

  constructor(
    private tourService: TourAuthoringService,
    private authService: AuthService,
    private datePipe: DatePipe,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.authService.user$.subscribe((user) => {
      this.user = user;
      this.getTouristTours(user.id);
    });
  }

  getTouristTours(userId: number) {
    this.tourService.getTouristTours(userId).subscribe({
      next: (result: PagedResults<AvailableTour>) => {
        this.availableTours = result.results;
      },
      error: (err: any) => {
        console.error(err);
      },
    });
  }

  navigateToTourExecution(tourId: number) {
    this.router.navigate([`position-simulator/${tourId}`]);
  }

  formatDate(date: string | Date): string {
    return this.datePipe.transform(date, 'dd.MM.yyyy HH:mm:ss') || '';
  }
}
