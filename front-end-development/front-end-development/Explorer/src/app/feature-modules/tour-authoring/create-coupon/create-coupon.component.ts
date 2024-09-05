import { Component,EventEmitter,Input,OnInit, Output } from '@angular/core';
import { Coupon } from './coupon.model';
import { CouponService } from './coupon.service';
import { Tour } from '../model/tour.model';
import { PagedResults } from 'src/app/shared/model/paged-results.model';
import { AuthService } from 'src/app/infrastructure/auth/auth.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'xp-create-coupon',
  templateUrl: './create-coupon.component.html',
  styleUrls: ['./create-coupon.component.css']
})
export class CreateCouponComponent implements OnInit  {
  
  selectedTourId: number;
  discount : number;
  expDate: Date;
  userId: number;
  hashToDelete: string;

  tours: Tour[] = [];
  

constructor( private couponService: CouponService,
   private authService : AuthService,
    private router : Router,
    private toastr: ToastrService,) {
    
  }

  ngOnInit(): void {
    this.userId = this.authService.user$.getValue().id;
    this.getTours();
  }


   getTours(): void{
    this.couponService.getAuthorTours(this.userId).subscribe({
      next: (result: PagedResults<Tour>) => {
        this.tours = result.results;
      },
      error: () => {
      }
    })
  }

  addCoupon() {
    const coupon: Coupon = {
    discountPercentage: this.discount,
      tourId: this.selectedTourId,
      ExpirationDate: this.expDate,
      couponHash : 'proba'
    };
  
    this.couponService.addCoupon(coupon).subscribe({
      next: (response: any) => {
        const hashFromResponse = response.couponHash;
        this.toastr.success(hashFromResponse);
        this.router.navigate(['/author/tours'])
      },
      error: (error) => {
        console.error('Error adding request:', error);
      }
    });
  }

  isSelectDisabled = false;

  toggleSelect() {
    this.isSelectDisabled = !this.isSelectDisabled;
  }


  removeCoupon(hash: string){
    
          this.couponService.deleteCoupon(hash).subscribe({
            next: () => {
              this.hashToDelete = '';
              this.toastr.success('Request deleted successfully.');
            },
            error: (error) => {
              console.error('Error deleting request:', error);
              this.toastr.error('Not found')
            }
          });

  }


}
