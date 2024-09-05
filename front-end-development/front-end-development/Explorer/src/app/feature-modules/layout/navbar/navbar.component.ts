import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/infrastructure/auth/auth.service';
import { User } from 'src/app/infrastructure/auth/model/user.model';
import { MarketplaceService } from '../../marketplace/marketplace.service';
import { TouristWallet } from '../model/userProfile.model';

@Component({
  selector: 'xp-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css'],
})
export class NavbarComponent implements OnInit {
  isDropdownOpen: boolean = false;
  user: User | undefined;
  wallet: TouristWallet = {
    id: -1,
    adventureCoins: 0,
    userId: -1,
  };

  constructor(
    private authService: AuthService,
    private marketService: MarketplaceService
  ) {}

  toggleDropdown(event: Event) {
    event.stopPropagation();
    this.isDropdownOpen = !this.isDropdownOpen;
  }

  ngOnInit(): void {
    this.authService.user$.subscribe((user) => {
      this.user = user;

      if (this.user && this.user.role === 'tourist') {
        this.marketService.getWallet(this.user.id).subscribe({
          next: (result: TouristWallet) => {
            this.wallet = result;
          },
          error: (err: any) => {
            console.log(err);
          },
        });
      }
    });
  }

  onLogout(): void {
    this.authService.logout();
  }
}
