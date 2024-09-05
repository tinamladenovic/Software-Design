import {
  Component,
  Input,
  EventEmitter,
  Output,
  OnInit,
  ViewChild,
} from '@angular/core';
import { BlogService } from '../../blog.service';
import { Comment } from '../../model/comment.model';
import { ActivatedRoute } from '@angular/router';
import { async, map } from 'rxjs';
import { AuthService } from 'src/app/infrastructure/auth/auth.service';
import { CommentComponent } from '../comment/comment.component';

@Component({
  selector: 'xp-comment-crud',
  templateUrl: './comment-crud.component.html',
  styleUrls: ['./comment-crud.component.css'],
})
export class CommentCrudComponent implements OnInit {
  @Output() commentAdded = new EventEmitter<null>();
  constructor(
    private service: BlogService,
    private router: ActivatedRoute,
    private authService: AuthService
  ) {}

  @ViewChild(CommentComponent, { static: true })
  commentComponent!: CommentComponent;

  blogId: number = 0;

  comment: Comment = {
    context: '',
    author: '',
    creationTime: new Date(),
    lastUpdateTime: new Date(),
    userId: 0,
  };

  ngOnInit(): void {
    this.router.params.subscribe((param) => (this.blogId = param['id']));
  }
  createComment() {
    this.comment.creationTime = new Date(Date.now());
    this.comment.lastUpdateTime = new Date(Date.now());
    this.comment.author = this.authService.user$.getValue().username;
    this.comment.userId = this.authService.user$.getValue().id;

    this.service.postComment(this.blogId, this.comment).subscribe({
      next: () => {
        this.commentAdded.emit();
      },
    });
  }
}
