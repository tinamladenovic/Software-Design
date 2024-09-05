import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PagedResults } from 'src/app/shared/model/paged-results.model';
import { Comment } from './model/comment.model';
import { environment } from 'src/env/environment';
import { Blog } from './model/blog.model';
import { Rating } from './model/rating.model';

@Injectable({
  providedIn: 'root',
})
export class BlogService {
  constructor(private http: HttpClient) {}

  getCommentsForBlog(blogId: number): Observable<PagedResults<Comment>> {
    console.log('usao u getcommentsforblog');
    return this.http.get<PagedResults<Comment>>(
      `${environment.apiHost}blogs/${blogId}/comments`
    );
  }

  postComment(blogId: number, comment: Comment) {
    return this.http.post<Comment>(
      environment.apiHost + 'blogs/' + blogId + '/comments',
      comment
    );
  }

  deleteComment(blogId: number, commentCreationTime: any) {
    console.log('EEE');
    return this.http.delete<Comment>(
      `${environment.apiHost}blogs/${blogId}/comments/${commentCreationTime}`
    );
  }

  updateComment(blogId: number, comment: any) {
    return this.http.patch<Comment>(
      environment.apiHost + 'blogs/' + blogId + '/comments',
      comment
    );
  }

  addBlog(blog: Blog): Observable<Blog> {
    return this.http.post<Blog>(environment.apiHost + 'blogs', blog);
  }

  getBlogs(): Observable<PagedResults<Blog>> {
    return this.http.get<PagedResults<Blog>>(environment.apiHost + 'blogs');
  }

  getBlogById(id: number): Observable<Blog> {
    return this.http.get<Blog>(environment.apiHost + 'blogs/' + id);
  }

  voteBlog(blogId: number, rating: Rating) {
    console.log(rating);
    return this.http.post<Blog>(
      environment.apiHost + 'blogs/' + blogId + '/ratings',
      rating
    );
  }

  removeVote(blogId: number, userRated: number) {
    return this.http.delete<Rating>(
      `${environment.apiHost}blogs/${blogId}/ratings/${userRated}`
    );
  }
}
