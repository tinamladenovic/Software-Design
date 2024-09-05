import { Component, Input } from '@angular/core';
import { AuthService } from 'src/app/infrastructure/auth/auth.service';
import { User } from 'src/app/infrastructure/auth/model/user.model';
import { TourAuthorService } from '../../tourAuthorService';
import { Router } from '@angular/router';

@Component({
  selector: 'xp-tour-author',
  templateUrl: './tour-author.component.html',
  styleUrls: ['./tour-author.component.css']
})
export class TourAuthorComponent {

  constructor(
    private userService : AuthService,
    private tourAuthorService : TourAuthorService,
    private router : Router,
    ){}

  @Input() authorid : number;

  user : User = {id:0, username : "", role: ""}

  ngOnInit(){
    this.userService.getUserById(this.authorid).subscribe({
      next : (user) =>{
        this.user = user;
      }
    })
  }

  goToAuthorProfile(){
    this.tourAuthorService.setAuthorId(this.user.id);
    this.router.navigate(['/author/profile']);

  }

}
