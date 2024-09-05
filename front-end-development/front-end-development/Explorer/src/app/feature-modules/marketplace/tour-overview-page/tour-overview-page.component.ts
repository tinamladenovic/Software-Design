import { Component, Input, OnInit } from '@angular/core';
import { Tour } from '../../tour-authoring/model/tour.model';
import { Checkpoint } from '../../tour-authoring/model/checkpoint.model';
import { MarketplaceService } from '../marketplace.service';
import { TourStatisticsService } from '../tour-statistics.service';
import { AvailableTour, OrderItem } from '../model/available-tour-model';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from 'src/app/infrastructure/auth/auth.service';
import { User } from '../../administration/model/user.model';
import { ActivatedRoute } from '@angular/router';
import TourBundle from '../../tour-authoring/model/tour-bundle';
import { TourStatus } from '../../tour-authoring/model/tour-status';

@Component({
  selector: 'xp-tour-overview-page',
  templateUrl: './tour-overview-page.component.html',
  styleUrls: ['./tour-overview-page.component.css']
})

export class TourOverviewPageComponent implements OnInit{
  tour: Tour;
  tourId: number;
  checkpoints: Checkpoint[];
  orderItem: OrderItem;
  user: User;
  userId: number;
  tags : string[] = [];
  averageRating: number;
  bundles: TourBundle[] = [];
  selectedBundle: TourBundle;

  constructor(
    private marketplaceService : MarketplaceService,
    private statsService: TourStatisticsService,
    private toastr: ToastrService,
    private authService: AuthService,
    private route: ActivatedRoute, 
  ) {}


  ngOnInit(): void {
    this.userId = this.authService.user$.getValue().id;
    this.route.params.subscribe(params => {
        if (params) {
            this.tourId = params['tourId'];
        }
    }); 
    console.log(this.tourId);
    this.getCheckpoints(this.tourId);
    this.getTour(this.tourId);
    this.getAverageRating();
    this.getBundles();
  }
  getCheckpoints(id: number) : void{
    this.marketplaceService.getCheckpoints(id).subscribe({
      next: (result: any) => {
        this.checkpoints = result.results as Checkpoint[];
      },
      error: (err: any) => {
        console.error(err);
      },
    });
  }
  getTour(id : number) : void{
    this.marketplaceService.getTour(id).subscribe({
      next: (result: Tour) => {
        this.tour = result;
        this.tags = this.tour.tags.split(',');
      },
      error: (err: any) => {
        console.error(err);
      },
    });
  }

  getBundles() : void{
    this.marketplaceService.getBundlesForTour(this.tourId).subscribe({
      next: (result: any) => {
        this.bundles = result.results as TourBundle[];
        console.log(result);
      },
      error: (err: any) => {
        console.error(err);
      },
    });
  }


  getDifficultyClass() : string {
    switch(this.tour.difficult){
      case 0:
      return 'easy-chip';
    case 1:
      return 'medium-chip';
    case 2:
      return 'hard-chip';
    default:
      return 'default-chip'; 
    }
  }

  addToCart(tour: Tour) {
    console.log(tour);
    if(this.selectedBundle){
      this.marketplaceService.addBundleToCart(this.selectedBundle, this.userId).subscribe({
        next: (result: OrderItem) => {
          this.toastr.success('Added bundle cart');
        },
        error: (err: any) => {
          console.error(err);
        },
      });
    }
    else{
      this.orderItem = {
        tourId: tour.id,
        tourName: tour.name,
        price: tour.price,
        quantity: 1,
      };
      this.marketplaceService.addToCart(this.orderItem, this.userId).subscribe({
        next: (result: OrderItem) => {
          this.toastr.success('Added to cart');
        },
        error: (err: any) => {
          console.error(err);
        },
      });
    }
  }

  getAverageRating() : void {
    this.statsService.getTourAverageRatingForPastWeek(this.tourId).subscribe({
      next: (result: number) => {
        this.averageRating = result;
      },
      error: () => {}
    })
  }
}
