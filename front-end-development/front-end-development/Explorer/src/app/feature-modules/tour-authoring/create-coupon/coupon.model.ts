export interface Coupon {
  id?: number;
  discountPercentage: number;
  tourId?: number;
  ExpirationDate: Date;
  couponHash: string;
}
