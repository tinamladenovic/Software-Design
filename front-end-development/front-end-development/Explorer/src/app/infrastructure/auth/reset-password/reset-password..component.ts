import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../auth.service';
import { Router } from '@angular/router';
import { Login } from '../model/login.model';
import { ToastContainerDirective, ToastrService } from 'ngx-toastr';

@Component({
  selector: 'xp-reset-password.',
  templateUrl: './reset-password..component.html',
  styleUrls: ['./reset-password.component.css']
})
export class ResetPasswordComponent implements OnInit {
  @ViewChild(ToastContainerDirective, { static: true }) toastContainer: ToastContainerDirective;

  constructor(
    private authService: AuthService,
    private router: Router,
    private toastr: ToastrService,
  ) {}

  isDisabled: boolean = false;

  ngOnInit(): void {
    this.toastr.overlayContainer = this.toastContainer;
  }

  resetForm = new FormGroup({
    username: new FormControl('', [Validators.required]),
    password: new FormControl('', [Validators.required]),
  });

  login(): void {
    const login: Login = {
      username: this.resetForm.value.username || "",
      password: this.resetForm.value.password || "",
    };

    if (this.resetForm.valid) {
      this.isDisabled = true;
      this.authService.login(login).subscribe({
        next: () => {
          this.router.navigate(['/']);
          this.toastr.success('Login successful');
          this.isDisabled = false;
        },
        error: (err) => {
          this.toastr.error("Please try again", "Login failed");
          this.isDisabled = false;
        }
      });
    }
    else{
      this.toastr.error("Please enter username and password");
    }
  }
}
