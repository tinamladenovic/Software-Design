import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ToastContainerDirective, ToastrService } from 'ngx-toastr';
import { TourSearch } from '../model/tour-search.model';
import { TourSearchService } from './tour-search.service';
import { LatLng } from 'src/app/shared/map/latLng.model';
import { MapComponent } from 'src/app/shared/map/map.component';
import { AddressTest } from '../../tour-authoring/model/address-test.model';
import { Tour } from '../../tour-authoring/model/tour.model';


@Component({
  selector: 'xp-tour-search',
  templateUrl: './tour-search.component.html',
  styleUrls: ['./tour-search.component.css']
})
export class TourSearchComponent implements OnInit {
  @ViewChild(ToastContainerDirective, { static: true }) toastContainer: ToastContainerDirective;
  @ViewChild(MapComponent) mapComponent: MapComponent;

  constructor(
    private tourSearchService: TourSearchService,
    private toastr: ToastrService,
  ) {}

  isDisabled: boolean = false;
  clickedLatLng: LatLng;
  clickedAddress: string;
  tours: any = [];

  ngOnInit(): void {
    this.clickedAddress = '';
    this.toastr.overlayContainer = this.toastContainer;
  }

  searchForm = new FormGroup({
    range: new FormControl('', [Validators.required]),
  });

  search(): void {
    const tourSearch: TourSearch = {
      range: parseInt(this.searchForm.value.range || ""),
      latitude: this.clickedLatLng?.lat || 0,
      longitude: this.clickedLatLng?.lng || 0,
    };

    if (this.searchForm.valid && this.clickedLatLng) {
      this.isDisabled = true;
      this.tourSearchService.getTourSearch(tourSearch).subscribe({
        next: (result) => {
          this.tours = result;
          this.isDisabled = false;
        },
        error: (err) => {
          console.error(err);
          this.isDisabled = false;
        }
      });
    } else {
      console.log("missing pin");
    }
  }

  onPinPlaced(event: AddressTest): void {
    this.clickedAddress = event.address;
    this.clickedLatLng = { lat: event.lat, lng: event.lng };
  }
}
