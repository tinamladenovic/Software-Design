import { Component, OnInit } from '@angular/core';
import { BlogService } from '../blog.service';
import { Blog } from '../model/blog.model';
import { Observable } from 'rxjs';
import { PagedResults } from 'src/app/shared/model/paged-results.model';
import { MatSelectChange } from '@angular/material/select';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/infrastructure/auth/auth.service';

@Component({
  selector: 'xp-blog-list',
  templateUrl: './blog-list.component.html',
  styleUrls: ['./blog-list.component.css'],
})
export class BlogListComponent implements OnInit {
  blogs: Blog[] = [];
  filteredBlogs: Blog[] = [];
  selectedValue: string = 'all';
  userRole: string;

  constructor(
    private blogService: BlogService,
    private router: Router,
    private authService: AuthService
  ) {}

  ngOnInit() {
    this.getAllBlogs();
    this.userRole = this.authService.user$.getValue().role;
  }

  onSelectionChange() {
    this.filteredBlogs = this.blogs;
    if (this.selectedValue === 'all') return;
    if (this.selectedValue === 'active') {
      this.filteredBlogs = this.blogs.filter((blog) => blog.status == 2);
      return;
    }
    if (this.selectedValue === 'famous') {
      this.filteredBlogs = this.blogs.filter((blog) => blog.status == 3);
      return;
    }
  }

  getAllBlogs(): void {
    this.blogService.getBlogs().subscribe({
      next: (result: PagedResults<Blog>) => {
        this.blogs = result.results;
        this.filteredBlogs = result.results;
      },
      error: () => {},
    });
  }

  navigateCreateBlog() {
    // Navigate to the route specified in your app-routing.module.ts
    this.router.navigate(['author/create-blog']); // Replace 'another-page' with the actual route
  }
}
