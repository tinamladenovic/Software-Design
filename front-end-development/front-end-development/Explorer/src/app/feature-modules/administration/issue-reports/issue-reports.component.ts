import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Report } from '../model/issue-reports.model';
import { ReportE } from '../model/issue-reports-extended';
import { AdministrationService } from '../administration.service';
import { PagedResults } from 'src/app/shared/model/paged-results.model';
import { Equipment } from '../model/equipment.model';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/infrastructure/auth/auth.service';
import { ReportComment } from '../model/report-comments';

@Component({
  selector: 'xp-issue-reports',
  templateUrl: './issue-reports.component.html',
  styleUrls: ['./issue-reports.component.css']
})
export class IssueReportsComponent implements OnInit {
  
  issues: Report[] = [];
  issuesE: ReportE[] = [];
  reportComments: ReportComment[] = [];
  currentDate: Date = new Date();
  @Output() reportsUpdated = new EventEmitter<null>();

  constructor(private service: AdministrationService, private authService: AuthService, private router: Router) { }

  ngOnInit(): void {
    this.getIssues()
  }

  getIssues(): void {
    this.service.getIssue().subscribe({
      next: (result: PagedResults<Report>) => {
        this.issues = result.results;
        this.issuesE = this.issues.map(issue => {
          const extendedIssue: ReportE = {
            id: issue.id,
            category: issue.category,
            priority: issue.priority,
            description: issue.description,
            dateCreated: issue.dateCreated,
            isPastDue: this.isPastDue(issue.dateCreated),
          };
          return extendedIssue;
        });
      },
    });
  }

  isPastDue(reportDate: Date | string): boolean {
    if (typeof reportDate === 'string') {
        reportDate = new Date(reportDate);
    }

    if (reportDate instanceof Date && !isNaN(reportDate.getTime())) {
        const daysDifference = Math.floor((this.currentDate.getTime() - reportDate.getTime()) / (1000 * 60 * 60 * 24));
        return this.authService.user$.getValue().role.toLowerCase() === 'administrator' && daysDifference > 5;
    }
    return false;
  }

  isTourist(): boolean {
    return this.authService.user$.getValue().role === 'tourist';
  } 
  
  handleTouristAction(issueId: number): void {
    console.log(`Tourist action for issue ID ${issueId}`);
    this.deleteIssue(issueId)
  }

  deleteIssue(id: number): void {
    this.getReportComments(id);
    this.service.deleteIssue(id).subscribe({
      next: () => {
        this.getIssues();
      },
    })
  }

  getReportComments(id: number): void {
    this.service.getReportComments(id).subscribe({
      next: (result: PagedResults<ReportComment>) => {
        this.reportComments = result.results;
      },
      error: () => {
      }
    })
  }

  redirectToCommentsPage(issueId: number | undefined) {
    if (issueId !== undefined) {
      
      this.router.navigate(['author/report', issueId, 'comments']);
    } else {
      console.error('Issue ID is undefined');
    }
  }
  
}
