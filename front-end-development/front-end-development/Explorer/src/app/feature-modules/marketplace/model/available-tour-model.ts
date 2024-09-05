import { Checkpoint } from '../../tour-authoring/model/checkpoint.model';
import { TourStatus } from '../../tour-authoring/model/tour-status';
import { TourReview } from '../../tour-authoring/model/tour.review.model';

export interface AvailableTour {
  id: number;
  authorId: number;
  name: string;
  description: string;
  distance: number;
  startTime: string;
  checkpoints: Checkpoint[];
  price: number;
  tourReviews: TourReview[];
  images: string[];
  isFavorite: boolean;
}

export interface OrderItem {
  tourId: number;
  tourName: string;
  price: number;
  quantity: number;
}

export interface BundleItem {
  id: number;
  bundleName: string;
  price: number;
  tours: TourStatus[];
}

export interface ShoppingCart {
  id: number;
  userId: number;
  items: OrderItem[];
  bundleItems: BundleItem[];
}
