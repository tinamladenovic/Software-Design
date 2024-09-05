import { Component, Input, Output, EventEmitter } from '@angular/core';
import { Comment } from '../../model/comment.model';
import { BlogService } from '../../blog.service';

@Component({
  selector: 'xp-comment-edit',
  templateUrl: './comment-edit.component.html',
  styleUrls: ['./comment-edit.component.css'],
})
export class CommentEditComponent {
  @Input() index: number;
  @Input() editedText: string;
  @Input() comment: Comment;
  @Input() blogId: number;
  @Output() commentEdited = new EventEmitter<null>();

  constructor(private service: BlogService) {}

  editComment() {
    this.comment.context = this.editedText;
    this.comment.lastUpdateTime = new Date();

    this.service.updateComment(this.blogId, this.comment).subscribe({
      next: () => {
        this.commentEdited.emit();
      },
    });
  }
}
