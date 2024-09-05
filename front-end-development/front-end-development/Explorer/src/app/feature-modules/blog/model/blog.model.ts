import { Rating } from './rating.model';

export enum Status {
  Draft,
  Published,
  Active,
  Famous,
  Closed,
}

export interface Blog {
  id?: number;
  name: string;
  description: string;
  dateCreated?: Date;
  images: Array<string>;
  status?: Status;
  authorId: number;
  author: string;
  comments: Array<Comment>;
  ratings: Array<Rating>;
  rating: number;
}
