import { Component, OnInit } from '@angular/core';
import { TouristclubService } from '../touristclub.service';
import { TouristClub } from '../model/touristclub.model';
import { PagedResults } from 'src/app/shared/model/paged-results.model';
import { AuthService } from 'src/app/infrastructure/auth/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'xp-owner-view-clubs',
  templateUrl: './owner-view-clubs.component.html',
  styleUrls: ['./owner-view-clubs.component.css']
})
export class OwnerViewClubsComponent implements OnInit{
  
  ownerClubs: TouristClub[] = [];
  userId: number;

constructor(private tService: TouristclubService,private authService : AuthService, private router: Router) {
    
  }
  ngOnInit(): void {
    this.userId = this.authService.user$.getValue().id;
    this.getClubs();
  }
 getClubs(): void{
  this.tService.getTouristClubs().subscribe({
    next: (result: PagedResults<TouristClub>) => {
      this.ownerClubs = result.results.filter(tc =>tc.ownerId === this.userId);
      //this.ownerClubs = result.results;
    },
    error: () => {
    }
  })
 }
 navigateToOwnerClubOptions(id: number | undefined):void {
  if(id !== undefined){
    this.router.navigate(['/author/club-options', id]);
  }
}
}
