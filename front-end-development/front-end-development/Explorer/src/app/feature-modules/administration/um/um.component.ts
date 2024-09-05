import { ChangeDetectorRef, Component, OnInit, ViewChild } from '@angular/core';
import { AdministrationService } from '../administration.service';
import { MatDialog } from '@angular/material/dialog';
import { ToastContainerDirective, ToastrService } from 'ngx-toastr';
import { MarketplaceService } from '../../marketplace/marketplace.service';
import { User } from '../model/user.model';
import { User as AdminUser } from 'src/app/infrastructure/auth/model/user.model';
import { PageEvent } from '@angular/material/paginator';
import { PagedResults } from 'src/app/shared/model/paged-results.model';
import { UserDialogComponent } from '../user-dialog/user-dialog.component';
import {
  MatDialogRef,
  MAT_DIALOG_DATA,
  MatDialogContent,
} from '@angular/material/dialog';
import { AuthService } from 'src/app/infrastructure/auth/auth.service';

@Component({
  selector: 'xp-um',
  templateUrl: './um.component.html',
  styleUrls: ['./um.component.css'],
})
export class UmComponent implements OnInit {
  displayedColumns: string[] = ['id', 'name', 'role', 'isActive'];

  admin: AdminUser;
  users: User[] = [];
  length = 0;
  pageSize = 10;
  pageIndex = 0;
  pageSizeOptions = [1, 5, 10, 25];
  pageEvent: PageEvent;

  constructor(
    private service: AdministrationService,
    private dialog: MatDialog,
    private toastr: ToastrService,
    private authService: AuthService
  ) {}

  @ViewChild(ToastContainerDirective, { static: true })
  toastContainer: ToastContainerDirective;

  ngOnInit(): void {
    this.authService.user$.subscribe((admin) => {
      this.admin = admin;
      if (admin) {
        console.log(admin.id);
        this.getUsers();
        this.toastr.overlayContainer = this.toastContainer;
      }
    });
  }

  getUsers(): void {
    this.service.getUsers(this.pageSize, this.pageIndex).subscribe({
      next: (result: PagedResults<User>) => {
        this.users = result.results;
        this.length = result.totalCount;
      },
      error: () => {},
    });
  }

  handlePageEvent(e: PageEvent) {
    this.pageEvent = e;
    this.length = e.length;
    this.pageSize = e.pageSize;
    this.pageIndex = e.pageIndex;
    this.getUsers();
  }

  getRole(role: number): string {
    switch (role) {
      case 0:
        return 'Admin';
      case 1:
        return 'Author';
      case 2:
        return 'Tourist';
      default:
        return 'Unknown';
    }
  }

  openUserDialog(user: User): void {
    const dialogRef = this.dialog.open(UserDialogComponent, {
      width: '700px', // Postavite širinu dijaloga prema potrebi
      data: { user, adminId: this.admin.id },
    });
    dialogRef.afterClosed().subscribe({
      next: (result: User) => {
        this.getUsers();
      },
    });
  }
}
