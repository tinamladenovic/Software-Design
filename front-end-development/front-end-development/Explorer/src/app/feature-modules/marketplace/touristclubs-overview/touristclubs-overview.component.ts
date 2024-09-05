import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { TouristClub } from '../model/touristclub.model';
import { TouristclubService } from '../touristclub.service';
import { PagedResults } from 'src/app/shared/model/paged-results.model';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/infrastructure/auth/auth.service'
@Component({
  selector: 'xp-touristclubs-overview',
  templateUrl: './touristclubs-overview.component.html',
  styleUrls: ['./touristclubs-overview.component.css']
})
export class TouristclubsOverviewComponent implements OnInit{

  @Output() selectedClub = new EventEmitter<TouristClub>();
  
  touristClubs: TouristClub[] = [];

  constructor(private service: TouristclubService, private router: Router, private authService : AuthService) { }

  ngOnInit(): void {
    this.service.getTouristClubs().subscribe({
      next: (result: PagedResults<TouristClub>) => {
        this.touristClubs = result.results;
      },
      error: (err: any) => {
      }
    })
  }
  getFullImageUrl(filePath: File): string {
    if (filePath.size !== 0) {
      return `https://localhost:44333/Resources/Images/${filePath}`;
    }
    return '';
  }


  showClubDetails(id: number | undefined):void {
    if(id !== undefined){
      this.router.navigate(['/club-overview', id]);
    }
  }
}