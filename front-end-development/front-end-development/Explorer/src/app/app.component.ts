import { Component, OnInit } from '@angular/core';
import { AuthService } from './infrastructure/auth/auth.service';
import 'leaflet-routing-machine';
import { MarketplaceService } from './feature-modules/marketplace/marketplace.service';
import { TouristWallet } from './feature-modules/layout/model/userProfile.model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  title = 'Explorer';

  constructor(
    private authService: AuthService,
    private marketService: MarketplaceService
  ) {}

  ngOnInit(): void {
    this.checkIfUserExists();

    const user = this.authService.user$.getValue();
    if (user.id !== 0 && user.role === 'tourist') {
      this.marketService.getWallet(user.id).subscribe();
    }
  }

  private checkIfUserExists(): void {
    this.authService.checkIfUserExists();
  }
}
