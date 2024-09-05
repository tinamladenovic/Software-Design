import {
  Component,
  EventEmitter,
  OnInit,
  ViewEncapsulation,
} from '@angular/core';

import { PageEvent } from '@angular/material/paginator';
import { PagedResults } from 'src/app/shared/model/paged-results.model';
import { TourAuthoringService } from '../../tour-authoring/tour-authoring.service';
import { AuthService } from 'src/app/infrastructure/auth/auth.service';
import { User } from 'src/app/infrastructure/auth/model/user.model';
import { MarketplaceService } from '../marketplace.service';
import { AvailableTour, OrderItem } from '../model/available-tour-model';
import { Tour } from '../../tour-authoring/model/tour.model';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

@Component({
  selector: 'xp-available-tour-preview',
  templateUrl: './available-tour-preview.component.html',
  styleUrls: ['./available-tour-preview.component.css'],
  encapsulation: ViewEncapsulation.None,
})
export class AvailableTourPreviewComponent implements OnInit {
  recommendedToursSliderConfig: any = {
    slidesToShow: 3,
    slidesToScroll: 1,
    infinite: true,
    autoplay: true,
    autoplaySpeed: 2000,
    arrows: true,
  };
  user: User;
  orderItem: OrderItem;
  displayedColumns: string[] = [
    'id',
    'name',
    'description',
    'length',
    'startTime',
    'checkpoint',
    'price',
    'tourReview',
  ];

  availableTours: AvailableTour[] = [];
  length = 0;
  pageSize = 10;
  pageIndex = 0;
  pageSizeOptions = [1, 5, 10, 25];
  pageEvent: PageEvent;
  recommendedTours: Tour[] = [];
  recommendedActiveTours: Tour[] = [];

  constructor(
    private tourAuthoringService: TourAuthoringService,
    private authService: AuthService,
    private marketplaceService: MarketplaceService,
    private toastr: ToastrService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.authService.user$.subscribe((user) => {
      this.user = user;
      this.recommendedToursSliderConfig = {
        slidesToShow: 3,
        slidesToScroll: 1,
        infinite: true,
        autoplay: true,
        autoplaySpeed: 2000,
        arrows: true,
      };
      this.getAllAvailableTours();
      this.getRecommendedTours();
      this.getRecommendedActiveTours();
    });
  }

  handlePageEvent(e: PageEvent) {
    this.pageEvent = e;
    this.length = e.length;
    this.pageSize = e.pageSize;
    this.pageIndex = e.pageIndex;
    this.getAllAvailableTours();
  }

  getAllAvailableTours(): void {
    this.tourAuthoringService
      .getAllAvailableTours(this.pageSize, this.pageIndex, this.user.id)
      .subscribe({
        next: (result: PagedResults<AvailableTour>) => {
          this.availableTours = result.results;
          this.length = result.totalCount;
        },
        error: () => {},
      });
  }

  addToFavorite(tour: AvailableTour) {
    this.tourAuthoringService.addToFavorite(tour.id, this.user.id).subscribe({
      next: () => {
        this.getAllAvailableTours();
      },
      error: (err: any) => {
        console.error(err);
      },
    });
  }

  removeFromFavorite(tour: AvailableTour) {
    this.tourAuthoringService.removeFromFavorite(tour.id, this.user.id).subscribe({
      next: () => {
        this.getAllAvailableTours();
      },
      error: (err: any) => {
        console.error(err);
      },
    });
  }

  getRecommendedTours(): void {
    this.marketplaceService.getRecommendedTours().subscribe({
      next: (result: PagedResults<Tour>) => {
        this.recommendedTours = result.results;
      },
      error: () => {},
    });
  }

  getRecommendedActiveTours(): void {
    this.marketplaceService.getRecommendedActiveTours().subscribe({
      next: (result: PagedResults<Tour>) => {
        this.recommendedActiveTours = result.results;
      },
      error: () => {},
    });
  }

  addToCart(tour: AvailableTour) {
    console.log(tour);
    this.orderItem = {
      tourId: tour.id,
      tourName: tour.name,
      price: tour.price,
      quantity: 1,
    };
    this.marketplaceService.addToCart(this.orderItem, this.user.id).subscribe({
      next: (result: OrderItem) => {
        const index = this.availableTours.findIndex((t) => t.id === tour.id);
        if (index !== -1) {
          this.availableTours.splice(index, 1);
        }
      },
      error: (err: any) => {
        console.error(err);
      },
    });
  }

  addToCart_Tour(tour: Tour) {
    this.orderItem = {
      tourId: tour.id,
      tourName: tour.name,
      price: tour.price,
      quantity: 1,
    };
    this.marketplaceService.addToCart(this.orderItem, this.user.id).subscribe({
      next: (result: OrderItem) => {
        this.toastr.success(
          'Tour successfully added to Your shopping cart.',
          'Item added to cart'
        );
      },
      error: (err: any) => {
        console.error(err);
      },
    });
  }

  shouldRenderAttribute(tourId: number): boolean {
    return this.availableTours.some((t) => t.id === tourId);
  }

  redirectToTourOverview(tourId: number) {
    if(this.shouldRenderAttribute(tourId)){
      this.router.navigate(['/tour-overview', tourId]);
    }
  }
}
