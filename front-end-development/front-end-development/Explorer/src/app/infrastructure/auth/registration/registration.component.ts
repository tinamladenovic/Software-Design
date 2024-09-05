import { Component, OnInit, ViewChild } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Registration } from '../model/registration.model';
import { AuthService } from '../auth.service';
import { Router } from '@angular/router';
import { ToastContainerDirective, ToastrService } from 'ngx-toastr';

@Component({
  selector: 'xp-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css'],
})
export class RegistrationComponent implements OnInit {

  @ViewChild(ToastContainerDirective, { static: true }) toastContainer: ToastContainerDirective;

  constructor(
    private authService: AuthService,
    private router: Router,
    private toastr: ToastrService
  ) {}

  isDisabled: boolean = false;

  ngOnInit(): void {
    this.toastr.overlayContainer = this.toastContainer;
  }

  registrationForm = new FormGroup({
    name: new FormControl('', [Validators.required]),
    surname: new FormControl('', [Validators.required]),
    email: new FormControl('', [Validators.required]),
    username: new FormControl('', [Validators.required]),
    password: new FormControl('', [Validators.required]),
    role: new FormControl('', Validators.required),
  });

  register(): void {
    const registration: Registration = {
      name: this.registrationForm.value.name || "",
      surname: this.registrationForm.value.surname || "",
      email: this.registrationForm.value.email || "",
      username: this.registrationForm.value.username || "",
      password: this.registrationForm.value.password || "",
      role: Number(this.registrationForm.value.role),
    };
    

    if (this.registrationForm.valid) {
      this.isDisabled = true;
      this.authService.register(registration).subscribe({
        next: () => {
          this.router.navigate(['user-location']);
          this.toastr.success('Registration successful');
        this.isDisabled = false;

        },
        error: (err) => {
          this.toastr.error("Registration failed", "Please try again");
          this.isDisabled = false;

        }
      });
    }
    else{
      this.toastr.error("Invalid data");
    }
  }
}
