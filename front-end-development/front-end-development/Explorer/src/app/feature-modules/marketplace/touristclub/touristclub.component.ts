import { Component, OnInit } from '@angular/core';
import { TouristClub } from '../model/touristclub.model';
import { TouristclubService } from '../touristclub.service';
import { PagedResults } from 'src/app/shared/model/paged-results.model';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from 'src/app/infrastructure/auth/auth.service';

@Component({
  selector: 'app-touristclub',
  templateUrl: './touristclub.component.html',
  styleUrls: ['./touristclub.component.css']
})
export class TouristclubComponent implements OnInit{

  touristClub: TouristClub;
  userId: number;
  isEditMode: boolean = false; 
  
  constructor(
    private service: TouristclubService, 
    private route: ActivatedRoute, 
    private authService : AuthService, 
    private router: Router) { }

  ngOnInit(): void {
    this.userId = this.authService.user$.getValue().id;
    this.route.paramMap.subscribe(params =>{
      if(params){
        const id = +params.get('id')!;
        if (!isNaN(id)) {
          this.service.getClubDetails(id).subscribe({
            next: (result: TouristClub) => {
              this.touristClub = result;
            },
            error: (err: any) => {
              console.log(err)
            }
          })
        } else {
        }
      }else{
      }
    })
  }
  showEditMode() : void {
    this.isEditMode = true;
  }
  editingComplete(): void {
    this.isEditMode = false;
  }
}
