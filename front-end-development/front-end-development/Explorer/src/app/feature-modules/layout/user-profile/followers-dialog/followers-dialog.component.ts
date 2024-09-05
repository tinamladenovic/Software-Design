import { Component, EventEmitter, Inject, OnInit,OnDestroy, Output } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { AuthService } from 'src/app/infrastructure/auth/auth.service';
import { Followers } from './followers.model';
import { FollowersService } from './followers.service';
import { PagedResults } from 'src/app/shared/model/paged-results.model';
import { User } from 'src/app/infrastructure/auth/model/user.model';
import Swal from 'sweetalert2';
import { ToastrService } from 'ngx-toastr';
import { NotificationModel } from '../notification-dialog/notification.model';
import { NotificationService } from '../notification-dialog/notification.service';
import {MatIconModule} from'@angular/material/icon';
import { MatTooltipModule } from '@angular/material/tooltip';

@Component({
  selector: 'xp-followers-dialog',
  templateUrl: './followers-dialog.component.html',
  styleUrls: ['./followers-dialog.component.css']
})
export class FollowersDialogComponent implements OnInit,OnDestroy{
 
  user: User | undefined;
  userId: number;
  followers: Followers[] = [];
  following: Followers[] = [];
  followersUsernames: { [key: number]: string } = {};
  followingUsernames: { [key: number]: string } = {};
  allFollowers: Followers[] = [];

  showFollowers: boolean = true; 
  showFollowing: boolean = false;
  showInputField: { [key: number]: boolean } = {};
  @Output() refreshFollowers = new EventEmitter<boolean>();

  constructor(public dialogRef: MatDialogRef<FollowersDialogComponent>,
    private followersService: FollowersService,
    private notificationService: NotificationService,
    private authService: AuthService,
    private toastr: ToastrService,
    @Inject(MAT_DIALOG_DATA) public data: any
    ) {
      if (data && data.type === 'following') {
      this.toggleFollowing();
      }
    }

  

  ngOnInit(): void {
    this.userId = this.authService.user$.getValue().id;
    this.getAllFollowers();
    this.getFollowers();
    this.getFollowing();

    this.authService.user$.subscribe((user) => {
      this.user = user;})
  }

  ngOnDestroy(): void {
    this.dialogRef.close({ refreshFollowers: true });
  }

  
  getFollowers():void{
    this.followersService.getFollowers().subscribe({
      next: (result: PagedResults<Followers>) => {
        this.followers = result.results.filter(fol => fol.followedId === this.userId);
        this.getUsernamesForFollowers();
      }
    }) 
  }

  getUsernamesForFollowers(): void {
    this.followers.forEach((follower) => {
      this.authService.getUserById(follower.followingId).subscribe({
        next: (result: User) => {
          this.followersUsernames[follower.followingId] = result.username;
        }
      });
    });
  }

  getFollowing():void{
    this.followersService.getFollowers().subscribe({
      next: (result: PagedResults<Followers>) => {
        this.following = result.results.filter(fol => fol.followingId === this.userId);
        this.getUsernamesForFollowing();
      }
    }) 
  }

  getUsernamesForFollowing(): void {
    this.following.forEach((follower) => {
      this.authService.getUserById(follower.followedId).subscribe({
        next: (result: User) => {
          this.followingUsernames[follower.followedId] = result.username;
        }
      });
    });
  }

  followUser(folId: number) {

    const newFollower: Followers = {
      followedId: folId,
      followingId: this.userId
    };

    const newNotification : NotificationModel={
      senderId: this.userId,
      receiverId: folId,
      message: this.user?.username + ' followed you!',
      isRead: false
    }
  
    this.followersService.getFollowerById(folId,this.userId).subscribe({
      next: (res: Followers)=>{
        if(res.id === 0)
        {
          this.followersService.createFollower(newFollower).subscribe({
            next: () => {
              this.getFollowers();
              this.getFollowing();
              this.toastr.success('Followed successfully')
              this.getFollowers();
              this.notificationService.createNotification(newNotification).subscribe({
                next:()=>{}
              })
            },
            error: (err) => {
              console.error('Error following user: ', err);
            }
          });
        }
        else{
          console.log(res);
          this.toastr.error('YOU ALREADY FOLLOW IT')
        }  
      }
    })
  }

  getAllFollowers(): void {
    this.followersService.getFollowers().subscribe({
      next: (result: PagedResults<Followers>) => {
        this.allFollowers = result.results;
      }
    });
  }
  
isFollowing(followingId: number){
return false;
}

  
  unfollowUser(folId: number): void {
    this.followersService.deleteFollower(folId,this.userId).subscribe({
      next:()=>{
        this.getFollowers();
        this.getFollowing();
      }
    })
  }

  unfollowConfirmation(folId: number): void {
    Swal.fire({
      title: 'Are you sure?',
      text: 'You are about to unfollow this user.',
      icon: 'question',
      showCancelButton: true,
      confirmButtonText: 'Unfollow',
      cancelButtonText: 'Cancel'
    }).then((result) => {
      if (result.isConfirmed) {
        this.unfollowUser(folId); 
      }
    });
  }


  toggleFollowers(): void {
    this.showFollowers = true;
    this.showFollowing = false;
  }

  toggleFollowing(){
    this.showFollowers = false;
    this.showFollowing = true;
  }


  toggleInput(followingId: number) {
    this.showInputField[followingId] = !this.showInputField[followingId];
  }
  
  showInput(followingId: number): boolean {
    return this.showInputField[followingId];
  }

  closeInput(followingId: number): void {
    this.toggleInput(followingId); 
    this.userMessage = '';
  }
  

userMessage: string = '';
sendMessage(recId: number) {
  const newMessage: NotificationModel = {
    senderId: this.userId,
    receiverId: recId,
    message: this.userMessage,
    isRead: false,
  };

  if(newMessage.message !='')
  {
    this.notificationService.createNotification(newMessage).subscribe({
      next: () => {
        this.toastr.success('Message sent successfully');
        this.userMessage = '';
        this.showInputField[recId] = false;
      },
    });
  }
  else
  {
    this.toastr.error('You need to enter message!')
  }
}

onClose(): void {

}


}