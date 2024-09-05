import { Component, OnInit } from '@angular/core';
import { ClubGuests } from './clubguests.model';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from 'src/app/infrastructure/auth/auth.service';
import { UserService } from './owner-club-options.service';
import { ClubUsersService } from '../club-users/club-users.service';
import { ClubRequestService } from '../club-request/club-request.service';
import { ClubRequest } from '../club-request/club-request.model';

@Component({
  selector: 'xp-owner-club-options',
  templateUrl: './owner-club-options.component.html',
  styleUrls: ['./owner-club-options.component.css']
})
export class OwnerClubOptionsComponent implements OnInit{
  clubGuests: ClubGuests[] = [];
  nonClubGuests: ClubGuests[] = [];
  userId: number;
  clubId: number;

  constructor(private uService: UserService,private authService : AuthService, private router: Router,private route: ActivatedRoute,private cService: ClubUsersService,private rService:ClubRequestService){
    
  }
  ngOnInit(): void {
    this.userId = this.authService.user$.getValue().id;
    this.route.paramMap.subscribe(params =>{
      if(params){
        this.clubId = +params.get('clubId')!;
      }else{
        this.router.navigate(['author/clubs-overview']);
      }
    })
    this.getClubGuests();
    this.getNonClubGuests();
  }

  getClubGuests(): void {
    this.uService.getClubGuests(this.clubId, this.userId).subscribe({
      next: (result: ClubGuests[]) => {
        this.clubGuests = result;
      },
      error: () => {
      }
    })
  }

  getNonClubGuests(): void {
    this.uService.getNonClubGuests(this.clubId, this.userId).subscribe({
      next: (result: ClubGuests[]) => {
        this.nonClubGuests = result;
      },
      error: () => {
      }
    })
  }
  delete(id?:number):void{
    this.cService.deleteUserFromClub(this.clubId,id!).subscribe({
      next:()=>{
        this.getClubGuests();
        this.getNonClubGuests();
      }
    })
  }
  invite(id?:number):void{
    const clubRequest: ClubRequest = {
      id: 0,
      touristId: id!,
      touristClubId: this.clubId,
      status: 0,
    }
    this.rService.sendRequest(clubRequest).subscribe({
      next:()=>{
        this.getNonClubGuests();
      }
    })
  }
  

}
