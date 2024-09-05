import { Component, OnInit,OnDestroy } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { NotificationService } from './notification.service';
import { PagedResults } from 'src/app/shared/model/paged-results.model';
import { AuthService } from 'src/app/infrastructure/auth/auth.service';
import { NotificationModel } from './notification.model';
import { User } from 'src/app/infrastructure/auth/model/user.model';


@Component({
  selector: 'xp-notification-dialog',
  templateUrl: './notification-dialog.component.html',
  styleUrls: ['./notification-dialog.component.css']
})

export class NotificationDialogComponent implements OnInit, OnDestroy {

  userId: number;
  notifications : NotificationModel[] = [];
  senderUsernames: { [key: number]: string } = {};

  constructor(public dialogRef: MatDialogRef<NotificationDialogComponent>,
              private authService: AuthService,
              private notificationService: NotificationService) {}
  
  ngOnInit(): void {
    this.userId = this.authService.user$.getValue().id;
    this.getNotifications();
  }

  ngOnDestroy(): void {
    this.markNotificationsAsRead();
  }

  getNotifications(): void{
    this.notificationService.getNotifications().subscribe({
      next: (result: PagedResults<NotificationModel>) => {
        this.notifications = result.results.filter(req => req.receiverId === this.userId);
        this.notifications.forEach((notification)=>{
               this.authService.getUserById(notification.senderId).subscribe({
       next: (result: User) => {
         this.senderUsernames[notification.senderId] = result.username;
            }
          });
        })
      }
    }) 
  }

  markNotificationsAsRead(): void {
    this.notificationService.getNotifications().subscribe({
      next: (result: PagedResults<NotificationModel>) => {
        this.notifications = result.results.filter(req => req.receiverId === this.userId);
        const newNotifications: NotificationModel[] = this.notifications.filter(notification => notification.isRead === false);
        for (const notification of newNotifications) {
          notification.isRead = true;
          this.notificationService.updateNotification(notification).subscribe();
        }
      }
    }) 
  }
}

