import { Component, OnInit } from '@angular/core';
import { BundleItem, OrderItem, ShoppingCart } from '../model/available-tour-model';
import { AuthService } from 'src/app/infrastructure/auth/auth.service';
import { User } from 'src/app/infrastructure/auth/model/user.model';
import { MarketplaceService } from '../marketplace.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

@Component({
  selector: 'xp-shopping-cart',
  templateUrl: './shopping-cart.component.html',
  styleUrls: ['./shopping-cart.component.css'],
})
export class ShoppingCartComponent implements OnInit {
  cart: ShoppingCart;
  user: User;
  totalPrice: number;
  couponCode: string;

  columnsToDisplay = ['image', 'tourName', 'price', 'quantity', 'remove'];
  footerColumnsToDisplay = ['totalPrice'];
  dataSource: OrderItem[];
  bundleItems: BundleItem[];

  constructor(
    private authService: AuthService,
    private marketPlaceService: MarketplaceService,
    private toastr: ToastrService,
    private router : Router
  ) {}

  ngOnInit(): void {
    this.authService.user$.subscribe((user) => {
      this.user = user;
      if (user) {
        const id = user.id;
        this.marketPlaceService.getCart(id).subscribe({
          next: (result: ShoppingCart) => {
            this.cart = result;
            this.countTotalPrice();
            this.dataSource = result.items;
            this.bundleItems = result.bundleItems;
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

    this.marketPlaceService.addDiscount(applyCouponRequest).subscribe({
      next: (isCouponApplied: boolean) => {
        if (isCouponApplied) {
          alert('Coupon applied successfully.');
          // Reload the cart to reflect the updated price
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
    this.marketPlaceService.getCart(userId).subscribe({
      next: (result: ShoppingCart) => {
        this.cart = result;
        this.countTotalPrice();
        this.dataSource = result.items;
      },
      error: (err: any) => {
        console.error(err);
      },
    });
  }

  removeFromCart(tourId: number) {
    const id = tourId;
    this.marketPlaceService.removeFromCart(this.cart.id, id).subscribe({
      next: (result: ShoppingCart) => {
        this.cart = result;
        this.dataSource = result.items;
        this.countTotalPrice();
      },
      error: (err: any) => {
        console.error(err);
      },
    });
  }

  removeBundleFromCart(bundleId : number){
    console.log(`Removing bundle with ID: ${bundleId}`);
    this.marketPlaceService.removeBundleFromCart(this.cart.id, bundleId).subscribe({
      next: (result: ShoppingCart)=>{
        this.cart = result;
        this.bundleItems = result.bundleItems;
        console.log(this.cart);
        this.countTotalPrice();
      },
      error: (err: any) => {
        console.error(err);
      },
    })
  }

  countTotalPrice() {
    let total = 0;
  
    if (this.cart && this.cart.items) {
      total += this.cart.items.reduce((subtotal, item) => {
        return subtotal + item.price * (item.quantity ? item.quantity : 1);
      }, 0);
    }
  
    if (this.cart && this.cart.bundleItems) {
      total += this.cart.bundleItems.reduce((subtotal, bundleItem) => {
        return subtotal + bundleItem.price;
      }, 0);
    }
  
    this.totalPrice = total;
  }
  

  goToCheckout() {
    this.router.navigate(['checkout-page'])
  }

  onItemQuantityChanged(tourId: number, quantity: number) {
    console.log(tourId);
    console.log(quantity);

    let foundTour = this.cart.items.find((e) => e.tourId === tourId);
    if (foundTour) {
      foundTour.quantity = quantity;
    }

    this.countTotalPrice();
  }
}
