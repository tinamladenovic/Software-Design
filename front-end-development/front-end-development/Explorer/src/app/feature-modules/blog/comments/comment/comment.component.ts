import { Component, Input, Output, OnInit, EventEmitter } from '@angular/core';
import { Comment } from '../../model/comment.model';
import { BlogService } from '../../blog.service';
import { Blog } from '../../model/blog.model';
import { DatePipe } from '@angular/common';
import { AuthService } from 'src/app/infrastructure/auth/auth.service';

@Component({
  selector: 'xp-comment',
  templateUrl: './comment.component.html',
  styleUrls: ['./comment.component.css'],
  providers: [DatePipe],
})
export class CommentComponent implements OnInit {
  comments: any;
  loggedUserId: number;
  editedCommentText: string;

  @Input() blog: any;
  @Output() commentDeleted = new EventEmitter<null>();
  editMode: number = -1;

  constructor(
    private service: BlogService,
    private datePipe: DatePipe,
    private authService: AuthService
  ) {}

  ngOnInit(): void {
    this.comments = this.blog.comments;
    this.comments.forEach((comment: any) => {
      // comment.creationTime = this.formatTime(comment.creationTime);
      // comment.lastUpdateTime = this.formatTime(comment.lastUpdateTime);
    });
    this.loggedUserId = this.authService.user$.getValue().id;
  }

  formatTime(time: Date): string {
    return this.datePipe.transform(time, 'dd MMM yyyy HH:mm') || 'Invalid Date';
  }

  getFormattedCreationTime(comment: Comment): string {
    return this.formatTime(comment.creationTime);
  }

  onEdit(i: number): void {
    if (this.editMode != i) {
      this.editMode = i;
    } else {
      this.editMode = -1;
    }
    this.editedCommentText = this.comments[i].context;
  }

  saveEditedComment(comment: Comment): void {
    // Save the edited comment and update the lastUpdateTime
    comment.context = this.editedCommentText;
    comment.lastUpdateTime = new Date();

    this.service.updateComment(this.blog.id, comment).subscribe({
      next: () => {
        this.blog = this.service.getBlogById(this.blog.id);
      },
      error: () => {},
    });

    // Reset editMode and editedCommentText
    this.editMode = -1;
    this.editedCommentText = '';
  }

  onDelete(comment: any) {
    this.service.deleteComment(this.blog.id, comment.creationTime).subscribe({
      next: () => {
        this.blog = this.service.getBlogById(this.blog.id);
        this.commentDeleted.emit();
      },
      error: () => {},
    });
  }
}
