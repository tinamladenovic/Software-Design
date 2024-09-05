import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AuthService } from 'src/app/infrastructure/auth/auth.service';
import { Coupon } from './coupon.model';
import { Observable } from 'rxjs';
import { Tour } from '../model/tour.model';
import { PagedResults } from 'src/app/shared/model/paged-results.model';

@Injectable({
  providedIn: 'root',
})
export class CouponService {
  constructor(private http: HttpClient, private authService: AuthService) {}

  addCoupon(coupon: Coupon): Observable<Coupon> {
    return this.http.post<Coupon>(
      'https://localhost:44333/api/author/coupons/createCoupon',
      coupon
    );
  }

  deleteCoupon(hash: string): Observable<Coupon> {
    return this.http.delete<Coupon>(
      'https://localhost:44333/api/author/coupons/deleteCoupon?CouponHash=' +
        hash
    );
  }

  updateCoupon(coupon: Coupon, hash: string): Observable<Coupon> {
    return this.http.put<Coupon>(
      'https://localhost:44333/api/author/coupons/updateCoupon?couponHash=' +
        hash,
      coupon
    );
  }

  getAuthorTours(authorId: number): Observable<PagedResults<Tour>> {
    return this.http.get<PagedResults<Tour>>(
      'https://localhost:44333/api/tour/authortours?authorId=' + authorId
    );
  }

  createGiftCoupon(coupon: Coupon): Observable<Coupon> {
    return this.http.post<Coupon>(
      'https://localhost:44333/api/author/coupons/createGiftCoupon',
      coupon
    );
  }
}
