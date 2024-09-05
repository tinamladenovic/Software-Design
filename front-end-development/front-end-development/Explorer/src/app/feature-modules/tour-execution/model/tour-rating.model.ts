export interface Review {
  id?: number;
  rating: number;
  comment: string;
  createdAt: Date;
  user: boolean;
}

export interface TourRating {
  id?: number;
  tourId: number;
  touristId: number;
  rating: number;
  review: string;
  created: Date;
  completionPercentage: number;
  lastActivity: Date;
  reviews: Review[];
}

