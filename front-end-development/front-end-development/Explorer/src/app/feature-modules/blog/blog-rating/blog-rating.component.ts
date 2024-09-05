import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'xp-blog-rating',
  templateUrl: './blog-rating.component.html',
  styleUrls: ['./blog-rating.component.css'],
})
export class BlogRatingComponent {
  @Input() userUpvoted: boolean;
  @Input() userDownvoted: boolean;
  @Input() rating: number;
  @Output() upvoted = new EventEmitter<null>();
  @Output() downvoted = new EventEmitter<null>();
  @Output() removedUpvote = new EventEmitter<null>();
  @Output() removedDownvote = new EventEmitter<null>();

  upvote() {
    this.upvoted.emit();
  }
  downvote() {
    this.downvoted.emit();
  }

  removeUpvote() {
    this.removedUpvote.emit();
  }

  removeDownvote() {
    this.removedDownvote.emit();
  }
}
