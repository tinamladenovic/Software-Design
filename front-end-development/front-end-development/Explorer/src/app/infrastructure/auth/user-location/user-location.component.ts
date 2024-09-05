import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { AuthService } from '../auth.service';
import { Router } from '@angular/router';
import { User } from '../model/user.model';
import { MapComponent } from 'src/app/shared/map/map.component';
import { AddressTest } from 'src/app/feature-modules/tour-authoring/model/address-test.model';
import { Observable } from 'rxjs';
import { People } from 'src/app/feature-modules/marketplace/model/person.model';

@Component({
  selector: 'xp-user-location',
  templateUrl: './user-location.component.html',
  styleUrls: ['./user-location.component.css']
})
export class UserLocationComponent implements AfterViewInit{

  @ViewChild(MapComponent) mapComponent: MapComponent;

  constructor(
    private authService: AuthService,
    private router: Router,
    ){}

  currentLat: number
  currentLng: number

  person: People = {id : 0,
    userId : 0,
    name: "",
    surname: "",
    email: "",
    motto: "",
    biography: "",
    image: "",
    latitude: 0,
    longitude: 0}

  ngAfterViewInit(): void {


    this.authService.getNameById(this.authService.user$.value.id).subscribe(user => {
      this.person = user;
      this.currentLat = user.latitude;
      this.currentLng = user.longitude;
      this.mapComponent.addMarker(this.currentLat, this.currentLng)
    })
  }

  onPinPlaced(event: AddressTest): void {
    this.currentLat = event.lat;
    this.currentLng = event.lng
  }

  changeLocation(): void {
    this.person.latitude = this.currentLat;
    this.person.longitude = this.currentLng;

    console.log('Person: ', this.person)

    this.authService.updateUserLocation(this.person).subscribe({
      next: (result : People) => {
        this.router.navigate(['/home'])
      },
      error: (err: any) => {
      }
    })
  }
}
