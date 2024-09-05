import { Component, Input, OnInit } from '@angular/core';
import { Blog, Status } from '../model/blog.model';
import { Router } from '@angular/router';

@Component({
  selector: 'xp-blog-item',
  templateUrl: './blog-item.component.html',
  styleUrls: ['./blog-item.component.css'],
})
export class BlogItemComponent implements OnInit {
  @Input() blog: {
    id?: number;
    name: string;
    author: string;
    images: Array<string>;
    status?: Status;
  };
  cover: string = './assets/images/blog/';

  constructor(private router: Router) {}

  ngOnInit(): void {
    this.cover += this.blog.images[0];
  }

  openBlog() {
    this.router.navigate(['blog/' + this.blog.id]);
  }
}
