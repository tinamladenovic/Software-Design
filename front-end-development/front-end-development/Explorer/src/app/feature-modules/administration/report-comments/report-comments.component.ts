import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PagedResults } from 'src/app/shared/model/paged-results.model';
import { AdministrationService } from '../administration.service';
import { ReportComment } from '../model/report-comments';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { User } from '../model/user.model';
import { AuthService } from 'src/app/infrastructure/auth/auth.service';

@Component({
  selector: 'xp-report-comments',
  templateUrl: './report-comments.component.html',
  styleUrls: ['./report-comments.component.css']
})
export class ReportCommentsComponent implements OnInit {

  issueId: number;
  reportComments: ReportComment[] = [];
  commentForm: FormGroup;
  @Output() reportCommentsUpdated = new EventEmitter<null>();
  @Input() reportComment: ReportComment;

  constructor(private service: AdministrationService, private authService: AuthService, private route: ActivatedRoute) {
    this.commentForm = new FormGroup({
      note: new FormControl('', [Validators.required])
    });
   }

  ngOnInit(): void {
    const idParam = this.route.snapshot.paramMap.get('id');
        if (idParam !== null) {
            this.issueId = +idParam;
        } else {
            console.error('Issue ID parameter is missing');
        }
        this.getReportComments(this.issueId);

        this.reportCommentsUpdated.subscribe(() => {
          this.getReportComments(this.issueId);
        });
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

  addReportComment(): void {
    const reportComment: ReportComment = {
      reportId: this.issueId,
      commentText: this.authService.user$.getValue().username + ": " + this.commentForm.value.note || "",
    };
  
    this.service.addReportComment(reportComment).subscribe({
      next: () => { 
        this.reportCommentsUpdated.emit(); // Emit the event
      },
      error: (error) => { 
        console.error(error);
      },
    });
  }

}
