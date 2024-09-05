import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { ToastContainerDirective, ToastrService } from 'ngx-toastr';
import { LayoutService } from '../../layout.service';
import { AnswerDate, Questionnaire } from '../../model/userProfile.model';
import { NotificationModel } from '../notification-dialog/notification.model';
import { Coupon } from 'src/app/feature-modules/tour-authoring/create-coupon/coupon.model';
import { CouponService } from 'src/app/feature-modules/tour-authoring/create-coupon/coupon.service';
import { NotificationService } from '../notification-dialog/notification.service';

@Component({
  selector: 'xp-questionnaire-dialog',
  templateUrl: './questionnaire-dialog.component.html',
  styleUrls: ['./questionnaire-dialog.component.css'],
})
export class QuestionnaireDialogComponent implements OnInit {
  questionnaire: Questionnaire;
  userAnswer: string = '';
  Correct: boolean = false;
  remainingTime: number = 10;
  answerDate: AnswerDate;

  Cupon: Coupon = {
    discountPercentage: 0,
    tourId: 0,
    ExpirationDate: new Date(),
    couponHash: '',
  };

  newNotification: NotificationModel = {
    senderId: 101,
    receiverId: this.data.userId,
    message: '',
    isRead: false,
  };
  dialogClosed: boolean = false;

  @ViewChild(ToastContainerDirective, { static: true })
  toastContainer: ToastContainerDirective;

  constructor(
    public dialogRef: MatDialogRef<QuestionnaireDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: { userId: number },

    private layoutService: LayoutService,
    private toastr: ToastrService,
    private couponService: CouponService,
    private notificationService: NotificationService
  ) {}

  ngOnInit(): void {
    this.remainingTime = 10;
    if (this.data.userId) {
      this.layoutService.getQuestion().subscribe({
        next: (result: Questionnaire) => {
          this.questionnaire = result;
          this.startTimer();
        },
        error: (err: any) => {
          console.error(err);
        },
      });
      this.toastr.overlayContainer = this.toastContainer;
    }
  }

  SubmitAnswer(answer: string): void {
    this.remainingTime = 10;
    if (answer.toLowerCase() === this.questionnaire.answer.toLowerCase()) {
      this.Correct = true;
    } else {
      this.Correct = false;
    }
    this.closeDialog();
  }

  startTimer(): void {
    const timerInterval = setInterval(() => {
      this.remainingTime--;

      if (this.remainingTime === 0) {
        clearInterval(timerInterval);
        if (!this.dialogClosed) {
          this.closeDialog();
        }
      }
    }, 1000);
  }

  showSuccess(): void {
    this.toastr.success('Succes', 'You just won a free coupon!');
  }
  showFailure(): void {
    this.toastr.error('Fail', 'Your answer was incorrect!');
  }

  closeDialog(): void {
    if (this.Correct) {
      const today = new Date();
      const expirationDate = new Date(today);
      expirationDate.setDate(today.getDate() + 10);
      this.Cupon.ExpirationDate = expirationDate;
      this.Cupon.couponHash = 'Kupon za tacan odgovor!#12345';
      this.Cupon.discountPercentage = 10;
      this.couponService.createGiftCoupon(this.Cupon).subscribe({
        next: (response: any) => {
          const hashFromResponse = response.couponHash;
          this.newNotification.message =
            'Your free coupon : ' + hashFromResponse;
          this.notificationService
            .createNotification(this.newNotification)
            .subscribe({
              next: () => {},
            });
        },
      });
      this.showSuccess();
    } else {
      this.showFailure();
    }
    this.layoutService.newAnswerDate(this.data.userId).subscribe({
      next: () => {},
    });
    this.dialogClosed = true;
    this.dialogRef.close();
  }
}
