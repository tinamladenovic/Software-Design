import { Component, Input, OnInit } from '@angular/core';
import { BundleItem, OrderItem, ShoppingCart } from '../model/available-tour-model';
import { MarketplaceService } from '../marketplace.service';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from 'src/app/infrastructure/auth/auth.service';
import { User } from 'src/app/infrastructure/auth/model/user.model';
import { Router } from '@angular/router';
import { Location } from '@angular/common';

@Component({
  selector: 'xp-checkout-page',
  templateUrl: './checkout-page.component.html',
  styleUrls: ['./checkout-page.component.css']
})
export class CheckoutPageComponent implements OnInit{

  items: OrderItem[];
  bundleItems: BundleItem[];
  user: User;
  cart: ShoppingCart;
  couponCode: string;
  couponApplied: boolean = false;
  totalPrice: number;
  subtotalPrice: number;
  oldSubtotal: number;
  
  constructor(
    private service: MarketplaceService,
    private authService: AuthService,
    private toastr: ToastrService,
    private router: Router,
    private location: Location
  ) {}
  ngOnInit(): void {
    this.authService.user$.subscribe((user) => {
      this.user = user;
      if (user) {
        const id = user.id;
        this.service.getCart(id).subscribe({
          next: (result: ShoppingCart) => {
            this.cart = result;
            this.items = result.items;
            this.bundleItems = result.bundleItems;
            this.countTotalPrice();
            this.subtotalPrice = this.totalPrice;
            this.oldSubtotal = this.subtotalPrice;
            console.log(this.bundleItems);
          },
          error: (err: any) => {
            console.error(err);
          },
        });
      }
    });
  }
  applyCoupon() {
    if (!this.couponCode) {
      alert('Please enter a coupon code.');
      return;
    }

    const applyCouponRequest = {
      couponCode: this.couponCode,
    };

    this.service.addDiscount(applyCouponRequest).subscribe({
      next: (isCouponApplied: boolean) => {
        if (isCouponApplied) {
          alert('Coupon applied successfully.');
          this.couponApplied = true;
          this.loadCart();
        } else {
          alert('Failed to apply the coupon.');
        }
      },
      error: (err: any) => {
        console.error(err);
        alert('Failed to apply coupon.');
      },
    });
  }

  loadCart() {
    const userId = this.user.id; 
    this.service.getCart(userId).subscribe({
      next: (result: ShoppingCart) => {
        this.cart = result;
        this.items = result.items;
        this.bundleItems = result.bundleItems;
        this.countTotalPrice();
      },
      error: (err: any) => {
        console.error(err);
      },
    });
  }

  countTotalPrice() {
    let total = 0;
    
    console.log(this.items);
    if (this.items) {
      total += this.items.reduce((sum, item) => {
        return sum + (item.price * (item.quantity || 1));
      }, 0);
    }
  
    if (this.bundleItems) {
      total += this.bundleItems.reduce((sum, bundle) => {
        return sum + bundle.price;
      }, 0);
    }
    this.totalPrice = total;
    this.subtotalPrice = total;
  }

  goToCart(){
    this.router.navigate(['shopping-cart'])
  }

  refreshPage() {
    window.location.reload();
  }

  createOrder(){
    if (this.cart && this.cart.items) {
      const tourIds: number[] = this.items.map((item) => item.tourId);
      this.bundleItems.forEach((bundleItem) => {
        tourIds.push(...bundleItem.tours.map((tour) => tour.tourId));
      });
      console.log(tourIds);
      this.service.createOrder(tourIds, this.user.id).subscribe({
        next: (result: ShoppingCart) => {
          this.service.removeCoinsFromUser(this.totalPrice);
          this.cart = result;
          this.totalPrice = 0;
          this.toastr.success('Tour successfully bought.');
          this.router.navigate(['available-tours']);
        },
        error: (err: any) => {
          console.error(err);
          this.toastr.error('You do not have enough money to buy these tours.');
        },
      });
    }
  }

}
