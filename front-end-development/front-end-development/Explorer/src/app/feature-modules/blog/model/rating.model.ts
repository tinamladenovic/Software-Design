enum RatingType {
  Upvote,
  Downvote,
}

export interface Rating {
  userId: number;
  author: string;
  ratingType: RatingType;
}
