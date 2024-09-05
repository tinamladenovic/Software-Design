import { Component, Input } from '@angular/core';
import { Blog } from '../model/blog.model';
import { ActivatedRoute } from '@angular/router';
import { BlogService } from '../blog.service';
import { Observable } from 'rxjs';
import { Rating } from '../model/rating.model';
import { AuthService } from 'src/app/infrastructure/auth/auth.service';
import { PagedResults } from 'src/app/shared/model/paged-results.model';
import { Comment } from '../model/comment.model';

@Component({
  selector: 'xp-blog-page',
  templateUrl: './blog-page.component.html',
  styleUrls: ['./blog-page.component.css'],
})
export class BlogPageComponent {
  @Input() blog: Observable<Blog>;

  blogValue: Blog;
  blogId: number;
  comments: any;
  editForm: boolean = false;
  commentEditingIndex: number = -1;
  userUpvoted: boolean = false;
  userDownvoted: boolean = false;
  userRole: string;

  constructor(
    private route: ActivatedRoute,
    private blogService: BlogService,
    private authService: AuthService
  ) {}

  ngOnInit(): void {
    this.blogId = Number(this.route.snapshot.paramMap.get('id')) || -1;
    this.blog = this.blogService.getBlogById(this.blogId);
    this.getBlogInfo();
    this.userRole = this.authService.user$.getValue().role;
    console.log('Role: ', this.userRole);
  }

  getBlogInfo(): void {
    this.blog = this.blogService.getBlogById(this.blogId);

    this.blog.subscribe((blog: Blog) => {
      this.blogValue = blog;
      console.log(blog);
      // Now you can modify properties of this.blogValue as needed
      this.comments = this.blogValue.comments;
      let ratings = this.blogValue.ratings;
      ratings.forEach((rating) => {
        if (rating.userId === this.authService.user$.getValue().id) {
          if (rating.ratingType === 0) {
            this.userUpvoted = true;
          } else {
            this.userDownvoted = true;
          }
          return;
        }
      });
    });
    this.editForm = false;
    this.commentEditingIndex = -1;
  }

  upvote(): void {
    const rating: Rating = {
      userId: this.authService.user$.value.id,
      author: this.authService.user$.value.username,
      ratingType: 0,
    };
    this.blogService.voteBlog(this.blogId, rating).subscribe({
      next: () => {
        this.blog = this.blogService.getBlogById(this.blogId);
        console.log(this.blog);
        this.userUpvoted = true;
        this.userDownvoted = false;
      },
      error: () => {},
    });
  }

  editComment(i: number): void {
    this.editForm = true;
    this.commentEditingIndex = i;
  }

  downvote(): void {
    const rating: Rating = {
      userId: this.authService.user$.value.id,
      author: this.authService.user$.value.username,
      ratingType: 1,
    };
    this.blogService.voteBlog(this.blogId, rating).subscribe({
      next: () => {
        this.userUpvoted = false;
        this.userDownvoted = true;
        this.blog = this.blogService.getBlogById(this.blogId);
      },
      error: () => {},
    });
  }

  removeUpvote() {
    const rating: Rating = {
      userId: this.authService.user$.value.id,
      author: this.authService.user$.value.username,
      ratingType: 0,
    };
    this.blogService.removeVote(this.blogId, rating.userId).subscribe({
      next: () => {
        this.blog = this.blogService.getBlogById(this.blogId);
        this.userUpvoted = false;
        this.userDownvoted = false;
      },
      error: () => {},
    });
  }

  removeDownvote() {
    console.log('remove downvote usao');
    const rating: Rating = {
      userId: this.authService.user$.value.id,
      author: this.authService.user$.value.username,
      ratingType: 1,
    };
    this.blogService.removeVote(this.blogId, rating.userId).subscribe({
      next: () => {
        this.blog = this.blogService.getBlogById(this.blogId);
        this.userUpvoted = false;
        this.userDownvoted = false;
      },
      error: () => {},
    });
  }
}
