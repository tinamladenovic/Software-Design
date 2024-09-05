import { Component, OnInit,OnDestroy  } from '@angular/core';
import { AuthService } from 'src/app/infrastructure/auth/auth.service';
import { User } from 'src/app/infrastructure/auth/model/user.model';
import { UserProfile } from '../model/userProfile.model';
import { LayoutService } from '../layout.service';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { NotificationDialogComponent } from './notification-dialog/notification-dialog.component';
import { FollowersDialogComponent } from './followers-dialog/followers-dialog.component';
import { ToastrService } from 'ngx-toastr';
import { NotificationService } from './notification-dialog/notification.service';
import { PagedResults } from 'src/app/shared/model/paged-results.model';
import { NotificationModel } from './notification-dialog/notification.model';
import { Followers } from './followers-dialog/followers.model';
import { FollowersService } from './followers-dialog/followers.service';
import { Observable, Subscription, of } from 'rxjs';
import { TourExecutionStatsService } from '../../tour-execution/tour-execution-stats.service';
import { EncounterExecutionService } from '../../encounters/encounter-execution.service';
import { EncounterStatistics } from '../../encounters/model/encounters.model';

@Component({
  selector: 'xp-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css'],
})
export class UserProfileComponent implements OnInit,OnDestroy {

  private userProfileSubscription: Subscription;
  user: User | undefined;
  userId: number;
  userProfile: UserProfile;
  notifications : NotificationModel[] = [];
  newNotifications: NotificationModel[] = [];
  followers: Followers[] = [];
  numOfFollowers: number;
  following: Followers[] = [];
  numOfFollowing: number;
  notFollowingUsers$: Observable<User[]>;
  notFollowing: User[] = [];
  completedTourCount: number;
  completedEncounters: number = 0;
  totalCoveredDistance: string;
  xp: number;
  level: number;


  constructor(private authService: AuthService,
              private layoutService: LayoutService,
              private notificationService: NotificationService,
              private followersService: FollowersService,
              private tourExecutionStatsService: TourExecutionStatsService,
              private dialog: MatDialog,
              private toastr: ToastrService,
              private encounterExecService: EncounterExecutionService
    ) {}

    ngOnInit(): void {
      this.userId = this.authService.user$.getValue().id;
      this.checkNewNotifications();
      this.getFollowers();
      this.getFollowing();
      this.getNotFollowing();
      this.getTourExecutionStats();
      this.calculateLevel();
  
      this.authService.user$.subscribe((user) => {
        this.user = user;
        if (user) {
          const { id } = user;
          this.encounterExecService.getEncounterStatsForTourist(id).subscribe((result: EncounterStatistics) =>{
            this.completedEncounters = result.completedCount;
          });
          
          if(id != 0){
            this.layoutService.getProfile(id).subscribe({
              next: (result: UserProfile) => {
                this.userProfile = result;
              },
              error: (err: any) => {
                console.error(err);
              },
            });
          }
        }

      });


    }

    ngOnDestroy(): void {
      if (this.userProfileSubscription) {
        this.userProfileSubscription.unsubscribe();
      }
    }

    getFullImageUrl(filePath: File | string | null | undefined): string {
      if (filePath && typeof filePath === 'string' && filePath.trim() !== '') {
        return `https://localhost:44333/Resources/Images/${filePath}`;
      } else if (filePath instanceof File && filePath.size !== 0) {
        return `https://localhost:44333/Resources/Images/${filePath.name}`;
      } 
      return '../../../../assets/images/profile.png';
    }

    checkNewNotifications(): void{
      this.notificationService.getNotifications().subscribe({
        next: (result: PagedResults<NotificationModel>) => {
          this.notifications = result.results.filter(req => req.receiverId === this.user?.id);
          this.newNotifications = this.notifications.filter(notification => notification.isRead === false);
          if(this.newNotifications.length>0)
          {
            const audio = new Audio();
            audio.src='../../../../assets/audio/whistle.mp3';
            audio.load();
            audio.play();
            this.toastr.info("You have new notifications"); 
          }
        }
      })
    }

    getFollowers():void{
      this.followersService.getFollowers().subscribe({
        next: (result: PagedResults<Followers>) => {
          this.followers = result.results.filter(fol => fol.followedId === this.user?.id);
          this.numOfFollowers = this.followers.length;
        }
      }) 
    }
  
    getFollowing():void{
      this.followersService.getFollowers().subscribe({
        next: (result: PagedResults<Followers>) => {
          this.following = result.results.filter(fol => fol.followingId === this.user?.id);
          this.numOfFollowing = this.following.length;
        }
      }) 
    }

    getTourExecutionStats(): void {
      this.tourExecutionStatsService.getTouristCompletedToursCount().subscribe((count) => {
        this.completedTourCount = count;
      });
  
      this.tourExecutionStatsService.getTouristCoveredDistance().subscribe((distance) => {
        this.totalCoveredDistance = distance.toFixed(2);
      });
    }

    openNotificationsDialog(): void {
      const dialogConfig = new MatDialogConfig();
      dialogConfig.autoFocus = true;
      dialogConfig.hasBackdrop = true;
      dialogConfig.position = { bottom: '79px',right: '230px' };
  
      this.dialog.open(NotificationDialogComponent, dialogConfig);
    }

    openFollowersDialog(type: string): void {
      const dialogConfig = new MatDialogConfig();
      dialogConfig.autoFocus = true;
      dialogConfig.hasBackdrop = true;
      dialogConfig.position = { bottom: '90px' };
      dialogConfig.data = { type: type };
    
      const dialogRef = this.dialog.open(FollowersDialogComponent, dialogConfig);
    
      dialogRef.afterClosed().subscribe(result => {
        if (result && result.refreshFollowers) {
          this.getFollowers();
          this.getFollowing();
          this.getNotFollowing();
        }
      });
    }
    
    getNotFollowing(): void{
      this.notFollowingUsers$ = this.followersService.getNotFollowing(this.userId);
      this.notFollowingUsers$.subscribe(
        users => {
          this.notFollowing = users;
        })
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
                this.notFollowing = this.notFollowing.filter(user => user.id !== folId);
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

    //getXp(){}

    /* 
    //TRY THIS IF WORKS WELL IT IS MORE OPTIMIZED
calculateLevel(xp: number) {
  this.level = Math.min(Math.ceil(xp / 2), 10);
  return this.level;
} */
calculateLevel() {
  this.xp = 10;
  if (this.xp < 2) {
    this.level = 1;
  } else if (this.xp < 4) {
    this.level = 2;
  } else if (this.xp < 6) {
    this.level = 3;
  } else if (this.xp < 8) {
    this.level = 4;
  } else if (this.xp < 10) {
    this.level = 5;
  } else if (this.xp < 12) {
    this.level = 6;
  } else if (this.xp < 14) {
    this.level = 7;
  } else if (this.xp < 16) {
    this.level = 8;
  } else if (this.xp < 18) {
    this.level = 9;
  } else {
    this.level = 10;
  }

  return this.level;
}

    
}
