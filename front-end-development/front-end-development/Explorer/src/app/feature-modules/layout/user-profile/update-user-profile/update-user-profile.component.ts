import { Component, OnChanges, OnInit } from '@angular/core';
import { UserProfile } from '../../model/userProfile.model';
import { LayoutService } from '../../layout.service';
import { AuthService } from 'src/app/infrastructure/auth/auth.service';
import { User } from 'src/app/infrastructure/auth/model/user.model';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'xp-update-user-profile',
  templateUrl: './update-user-profile.component.html',
  styleUrls: ['./update-user-profile.component.css'],
})
export class UpdateUserProfileComponent implements OnInit {
  userProfile: UserProfile;
  user: User;
  isVisible: boolean = false;

  selectedFile: File | null = null;

  profileForm = new FormGroup({
    name: new FormControl('', [Validators.required]),
    surname: new FormControl('', [Validators.required]),
    motto: new FormControl('', [Validators.required]),
    biography: new FormControl('', [Validators.required]),
    //image: new FormControl(''),
  });

  constructor(
    private service: LayoutService,
    private authService: AuthService
  ) {}

  ngOnInit(): void {
    this.authService.user$.subscribe((user) => {
      this.user = user;
      this.profileForm.disable();
      this.isVisible = false;
      if (user) {
        const { id } = user;
        this.service.getProfile(id).subscribe({
          next: (result: UserProfile) => {
            this.userProfile = result;
            this.profileForm.patchValue(result);
          },
          error: (err: any) => {
            console.error(err);
          },
        });
      }
    });
  }

  enableForm(): void {
    this.profileForm.enable();
    this.isVisible = true;
  }
  cancelUpdate(): void {
    this.profileForm.patchValue(this.userProfile);
    this.isVisible = false;
    this.profileForm.disable();
  }

  updateProfile(): void {
    if (this.profileForm.valid) {
      const profile: UserProfile = {
        id: this.userProfile.id,
        userId: this.user.id,
        name: this.profileForm.value.name || '',
        surname: this.profileForm.value.surname || '',
        email: this.userProfile.email,
        motto: this.profileForm.value.motto || '',
        biography: this.profileForm.value.biography || '',
        image: this.userProfile.image,
      };

      this.service.updateProfile(profile, this.selectedFile!).subscribe({
        next: (result: UserProfile) => {
          this.userProfile = profile;
          this.profileForm.disable();
          this.isVisible = false;
          console.log(result);
        },
        error: (err: any) => {
          console.error(err);
        },
      });
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

  onFileSelected(event: any): void {
    this.selectedFile = event.target.files[0] ?? null;
    this.userProfile.image = this.selectedFile;
    console.log(this.userProfile);
  }
}
