import { Component, EventEmitter, OnInit } from '@angular/core';

import { PageEvent } from '@angular/material/paginator';
import { MatDialog } from '@angular/material/dialog';
import { PagedResults } from 'src/app/shared/model/paged-results.model';
import { TourAuthoringService } from '../../tour-authoring/tour-authoring.service';
import { AuthService } from 'src/app/infrastructure/auth/auth.service';
import { User } from 'src/app/infrastructure/auth/model/user.model';

import { Observable } from 'rxjs/internal/Observable';
import { FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { TourSale } from '../model/tour-sale.model';
import { TourSaleConnection } from '../model/tour-sale-connection.model';
import { __values } from 'tslib';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'xp-tour-sale',
  templateUrl: './tour-sale.component.html',
  styleUrls: ['./tour-sale.component.css']
})
export class TourSaleComponent implements OnInit {


  dateRangeForm: FormGroup;
  tours$: Observable<any>;
  tours: any;
  userId: number;
  discount: any;
  endDate: any;
  startDate: any;
  sale: any;
  sale$: Observable<any>;
  saleId: any;
  isDisabledCreate: boolean;


  constructor(private tourService: TourAuthoringService, private authService: AuthService, private toastr: ToastrService,) {
    this.userId = this.authService.user$.getValue().id;
  }
  ngOnInit(): void {
    this.dateRangeForm = new FormGroup({
      startDate: new FormControl(''),
      endDate: new FormControl(''),
      percent: new FormControl(''),
    });
    this.saleId = 1;
  }

  onSubmit() {
    this.tours$ = this.tourService.getAllTours();
    this.tours$.subscribe(
      (data) => {
        this.tours = data.results;
        console.log('Received data:', this.tours);
      },
      (error) => {
        console.error('Error fetching data:', error);
      }
    );
    if (this.dateRangeForm.valid) {
      const tourSale: TourSale = {
        id: this.saleId,
        startDate: this.startDate,
        endDate: this.endDate,
        discount: this.discount,
        authorId: this.userId,
      };
      this.tourService.addTourSale(tourSale);
      this.isDisabledCreate == true;
      console.log('Form submitted:', tourSale);
    } else {
      console.log('Form is invalid. Please check the inputs.');
    }

  }

  onDelete() {
    this.tourService.deleteSale(this.saleId);
  }

  addTourToSale(id: any) {
    const tourSaleConnection: TourSaleConnection = {
      saleId: this.saleId,
      tourId: id,
    };
    console.log(tourSaleConnection);
    this.tourService.addTourToSale(tourSaleConnection).subscribe(
      (result) => {
        // Handle success
        console.log('Tour added to sale successfully:', result);
      },
      (error) => {
        console.error('Error adding tour to sale:', error);
      }
    );

    console.log(tourSaleConnection);
  }
}
