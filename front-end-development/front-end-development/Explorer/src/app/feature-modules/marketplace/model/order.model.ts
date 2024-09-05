import { Tour } from "../../tour-authoring/model/tour.model";

export interface Order {
    userId: number;
    tours: Tour[];
    tourId : number;
    price : number;
    paymenttime : Date;
  }