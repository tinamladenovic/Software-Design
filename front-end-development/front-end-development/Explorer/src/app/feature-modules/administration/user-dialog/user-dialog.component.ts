import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import {
  MatDialogRef,
  MAT_DIALOG_DATA,
  MatDialogContent,
  MatDialog,
} from '@angular/material/dialog';
import { User } from '../model/user.model';
import {
  TouristWallet,
  UserProfile,
} from '../../layout/model/userProfile.model';
import { LayoutService } from '../../layout/layout.service';
import { MarketplaceService } from '../../marketplace/marketplace.service';
import { AdministrationService } from '../administration.service';
import { ToastContainerDirective, ToastrService } from 'ngx-toastr';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { NotificationModel } from '../../layout/user-profile/notification-dialog/notification.model';
import { NotificationService } from '../../layout/user-profile/notification-dialog/notification.service';
import { ConfirmationDialogComponent } from 'src/app/shared/confirmation-dialog/confirmation-dialog.component';

@Component({
  selector: 'xp-user-dialog',
  templateUrl: './user-dialog.component.html',
  styleUrls: ['./user-dialog.component.css'],
})
export class UserDialogComponent implements OnInit {
  profile: UserProfile;
  wallet: TouristWallet;
  coinsForm = new FormGroup({
    coinsToAdd: new FormControl(0, [Validators.min(0)]),
  });
  newNotification: NotificationModel = {
    senderId: this.data.adminId,
    receiverId: this.data.user.id,
    message: '',
    isRead: false,
  };

  @ViewChild(ToastContainerDirective, { static: true })
  toastContainer: ToastContainerDirective;

  constructor(
    public dialogRef: MatDialogRef<UserDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: { user: User; adminId: number },

    private layoutService: LayoutService,
    private toastr: ToastrService,
    private dialog: MatDialog,
    private marketService: MarketplaceService,
    private adminService: AdministrationService,
    private notifiService: NotificationService
  ) {}

  ngOnInit(): void {
    if (this.data.user) {
      this.layoutService.getProfile(this.data.user.id).subscribe({
        next: (result: UserProfile) => {
          this.profile = result;
          console.log(this.profile);
          if (this.profile && this.data.user.role === 2) {
            this.marketService.getWallet(this.data.user.id).subscribe({
              next: (result: TouristWallet) => {
                this.wallet = result;
                console.log(this.wallet);
              },
              error: (err: any) => {
                console.error(err);
              },
            });
          }
        },
        error: (err: any) => {
          console.error(err);
        },
      });
      this.toastr.overlayContainer = this.toastContainer;
    }
  }

  blockUser(id: number): void {
    const confirmDialog = this.dialog.open(ConfirmationDialogComponent, {
      data: {
        title: 'Block user',
        message: 'Are you sure you want to block this user?',
      },
    });
    confirmDialog.afterClosed().subscribe((result) => {
      if (result) {
        this.adminService.blockUser(id).subscribe({
          next: (result: User) => {
            this.showSuccessForBlock();
            this.data.user = result;
          },
          error: () => {
            this.showFailure();
          },
        });
      }
    });
  }

  onClose(): void {
    this.dialogRef.close(this.data.user);
  }

  showSuccessForBlock(): void {
    this.toastr.success('Succes', 'User blocked successfully');
  }

  showSuccessForCoins(): void {
    this.toastr.success('Succes', 'Adventure coins added to wallet');
  }

  showFailure(): void {
    this.toastr.error('Error', 'Something went wrong');
  }

  addCoins(): void {
    const coinsToAdd = this.coinsForm.value.coinsToAdd || 0;
    if (coinsToAdd) {
      this.marketService
        .addCoinsToUser(this.data.user.id, coinsToAdd)
        .subscribe({
          next: (result: TouristWallet) => {
            this.showSuccessForCoins(); // Dodajte ovu funkciju ako želite prikazati poruku o uspehu
            this.wallet = result;
            this.newNotification.message =
              'U vas novcanik je dodato ' + coinsToAdd + ' Adventure coinsa!'; // Ažurirajte korisnike nakon dodavanja kovanica
            this.notifiService
              .createNotification(this.newNotification)
              .subscribe({
                next: () => {},
              });
          },
          error: () => {
            this.showFailure(); // Dodajte ovu funkciju ako želite prikazati poruku o grešci
          },
        });
    }
  }
}
