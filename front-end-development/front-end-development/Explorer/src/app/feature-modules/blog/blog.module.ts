import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CommentComponent } from './comments/comment/comment.component';
import { CommentCrudComponent } from './comments/comment-crud/comment-crud.component';
import { MaterialModule } from 'src/app/infrastructure/material/material.module';
import { FormsModule } from '@angular/forms';
import { AuthModule } from 'src/app/infrastructure/auth/auth.module';
import { BlogFormComponent } from './blog-form/blog-form.component';
import { ReactiveFormsModule } from '@angular/forms';
import { SecurityContext } from '@angular/core';
import { MarkdownModule } from 'ngx-markdown';
import { BlogItemComponent } from './blog-item/blog-item.component';
import { BlogListComponent } from './blog-list/blog-list.component';
import { BlogPageComponent } from './blog-page/blog-page.component';
import { CommentEditComponent } from './comments/comment-edit/comment-edit.component';
import { BlogRatingComponent } from './blog-rating/blog-rating.component';
import { MatCardModule } from '@angular/material/card';
import { MatInputModule } from '@angular/material/input';

@NgModule({
  declarations: [
    CommentComponent,
    CommentCrudComponent,
    BlogFormComponent,
    BlogItemComponent,
    BlogListComponent,
    BlogPageComponent,
    CommentEditComponent,
    BlogRatingComponent,
  ],
  imports: [
    CommonModule,
    MaterialModule,
    FormsModule,
    AuthModule,
    ReactiveFormsModule,
    MatCardModule,
    MatInputModule,
    MarkdownModule.forRoot({
      sanitize: SecurityContext.NONE,
    }),
    MarkdownModule.forChild(),
  ],
  exports: [BlogFormComponent],
})
export class BlogModule {}
