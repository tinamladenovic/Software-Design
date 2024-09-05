import { Component, OnInit } from '@angular/core';
import { AdministrationService } from '../../administration.service';
import { MatDialog } from '@angular/material/dialog';
import { PageEvent } from '@angular/material/paginator';
import { PagedResults } from 'src/app/shared/model/paged-results.model';
import { User } from '../../model/user.model';
import { ApplicationRate } from 'src/app/infrastructure/auth/model/application-rate.model';

@Component({
  selector: 'xp-application-rates-table',
  templateUrl: './application-rates-table.component.html',
  styleUrls: ['./application-rates-table.component.css'],
})
export class ApplicationRatesTableComponent implements OnInit {
  displayedColumns: string[] = [
    'id',
    'name',
    'surname',
    'rate',
    'comment',
    'creationTime',
  ];
  applicationRates: ApplicationRate[] = [];
  length = 0;
  pageSize = 10;
  pageIndex = 0;
  pageSizeOptions = [1, 5, 10, 25];
  pageEvent: PageEvent;

  constructor(
    private service: AdministrationService,
    private dialog: MatDialog
  ) {}

  ngOnInit(): void {
    this.getApplicationRates();
  }

  handlePageEvent(e: PageEvent) {
    this.pageEvent = e;
    this.length = e.length;
    this.pageSize = e.pageSize;
    this.pageIndex = e.pageIndex;
    this.getApplicationRates();
  }

  getApplicationRates(): void {
    this.service.getApplicationRates(this.pageSize, this.pageIndex).subscribe({
      next: (result: PagedResults<ApplicationRate>) => {
        console.log(result);
        this.applicationRates = result.results;
        this.length = result.totalCount;
      },
      error: () => {},
    });
  }
}
