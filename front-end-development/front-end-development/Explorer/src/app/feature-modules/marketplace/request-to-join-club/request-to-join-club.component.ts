import { Component,EventEmitter,Input,OnInit, Output } from '@angular/core';
import { RequestToJoinClubService } from './request-to-join-club.service';
import { TouristclubService } from '../touristclub.service';
import { PagedResults } from 'src/app/shared/model/paged-results.model';
import { TouristClub } from '../model/touristclub.model';
import { RequestToJoinClub } from './request-to-join-club.model';
import { AuthService } from 'src/app/infrastructure/auth/auth.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'xp-request-to-join-club',
  templateUrl: './request-to-join-club.component.html',
  styleUrls: ['./request-to-join-club.component.css'],
})

export class RequestToJoinClubComponent {

  requestToJoinClub : RequestToJoinClub;
  userId: number;

  @Output() requestAdded = new EventEmitter<null>();
  selectedClubId: number;

  touristClubs: TouristClub[] = [];
  requests : RequestToJoinClub[] = [];

  constructor(private service: RequestToJoinClubService,
     private tService: TouristclubService,
     private authService : AuthService,
     private route: ActivatedRoute ) {
       
  }

  ngOnInit(): void {
    
    this.userId = this.authService.user$.getValue().id;


    this.selectedClubId = 0;
    this.getTouristClubs();
    this.getRequests();
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

  getTouristClubs(): void{
    this.tService.getTouristClubs().subscribe({
      next: (result: PagedResults<TouristClub>) => {
        this.touristClubs = result.results;
      },
      error: () => {
      }
    })
  }

   getRequests(): void{
     this.service.getRequest().subscribe({
       next: (result: PagedResults<RequestToJoinClub>) => {
         //this.requests = result.results;
         this.requests = result.results.filter(req => req.touristId === this.userId);
       },
       error: () => {
       }
     })
   }

   addRequest() {
    if (this.selectedClubId === 0) {
      alert('Please select a tourist club.');
      return;
    }
  
    const request: RequestToJoinClub = {
      status: 0, // ON HOLD WHEN ADDING
      touristClubId: this.selectedClubId,
      touristId: this.userId
    };
  
    this.service.addRequest(request).subscribe({
      next: (addedRequest: RequestToJoinClub) => {
        this.requests.push(addedRequest); 
        this.requestAdded.emit();
        alert('Success');
      },
      error: (error) => {
        console.error('Error adding request:', error);
      }
    });
  }
  
    deleteRequest(id: number): void {
      this.service.getRequestById(id).subscribe({
        next: (request: RequestToJoinClub) => {
          if (request.status === 0) {
            this.service.deleteRequest(id).subscribe({
              next: () => {
                this.getRequests();
                alert('Request deleted successfully.');
              },
              error: (error) => {
                console.error('Error deleting request:', error);
              }
            });
          } else {
            alert('This request cannot be deleted because its status is not "On Hold".');
          }
        },
        error: (error) => {
          console.error('Error getting request:', error);
        }
      });
    }
    
  }



