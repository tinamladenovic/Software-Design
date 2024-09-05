import { Component } from '@angular/core';
import { RequestToJoinClubService } from '../request-to-join-club/request-to-join-club.service';
import { RequestToJoinClub } from '../request-to-join-club/request-to-join-club.model';
import { PagedResults } from 'src/app/shared/model/paged-results.model';
import { TouristClub } from '../model/touristclub.model';
import { AuthService } from 'src/app/infrastructure/auth/auth.service';
import { TouristclubService } from '../touristclub.service';
import { ClubUsersService } from '../club-users/club-users.service';
import { ClubUsersComponent } from '../club-users/club-users.component';
import { ClubUsers } from '../club-users/club-users.model';

@Component({
  selector: 'xp-manage-request-to-join-club',
  templateUrl: './manage-request-to-join-club.component.html',
  styleUrls: ['./manage-request-to-join-club.component.css']
})
export class ManageRequestToJoinClubComponent {
  requestToJoinClub: RequestToJoinClub;
  userId: number;
  requests: RequestToJoinClub[] = [];
  touristClubs: TouristClub[] = [];
  clubsOwnedByUser: TouristClub[] = [];
  clubuser : ClubUsers;

  constructor(private service: RequestToJoinClubService,
              private tService: TouristclubService,
              private authService : AuthService,
              private csService : ClubUsersService) 
              {}

  ngOnInit(): void {
    this.userId = this.authService.user$.getValue().id;
    this.getRequests();
    this.getTouristClubs();
  }

  getTouristClubs(): void {
    this.tService.getTouristClubs().subscribe({
      next: (result: PagedResults<TouristClub>) => {
        this.touristClubs = result.results;
        this.clubsOwnedByUser = this.touristClubs.filter(club => club.ownerId === this.userId);
        this.getRequests(); 
      }
    });
  }
  
  getRequests(): void {
    this.service.getRequest().subscribe({
      next: (result: PagedResults<RequestToJoinClub>) => {
        this.requests = result.results.filter(req => this.userOwnsClub(req.touristClubId));
      },
      error: () => {
      }
    });
  }
  
  userOwnsClub(touristClubId: number): boolean {
    return this.touristClubs.some(club => club.id === touristClubId && club.ownerId === this.userId);
  }
  
  

  getStatusDisplay(status: number): string {
    switch (status) {
      case 0:
        return 'On Hold';
      case 1:
        return 'Accepted';
      case 2:
        return 'Declined';
      default:
        return 'Unknown Status';
    }
  }



  canAcceptOrDecline(request: RequestToJoinClub): boolean {
    return request.status === 0;
  }

  acceptRequest(request: RequestToJoinClub): void {
    if (!this.canAcceptOrDecline(request)) {
      alert(`This request cannot be accepted.`);
      return;
    }
    
    if (this.canAcceptOrDecline(request)) {
      const clubUser: ClubUsers = {
        touristClubId: request.touristClubId,
        touristId: request.touristId,
      };
      this.csService.addUserToClub(clubUser).subscribe({
        next: () => {}
      });
    }

    const updatedRequest: RequestToJoinClub = { ...request, status: 1 };
  
    this.service.updateRequest(updatedRequest).subscribe({
      next: () => {
        request.status = 1;
        alert(`Successfully accepted.`);     
      },
      error: (error) => {
        console.error('Error accepting request:', error);
      }
    });
  }
  
  declineRequest(request: RequestToJoinClub): void {
    if (!this.canAcceptOrDecline(request)) {
      alert(`This request cannot be declined.`);
      return;
    }
  
    const updatedRequest: RequestToJoinClub = { ...request, status: 2 };
  
    this.service.updateRequest(updatedRequest).subscribe({
      next: () => {
        request.status = 2;
        alert(`Successfully declined.`);
      },
      error: (error) => {
        console.error('Error declining request:', error);
      }
    });
  }
  
}
