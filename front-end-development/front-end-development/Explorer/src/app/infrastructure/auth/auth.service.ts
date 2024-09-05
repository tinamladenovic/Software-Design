import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, switchMap, tap } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { TokenStorage } from './jwt/token.service';
import { environment } from 'src/env/environment';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Login } from './model/login.model';
import { AuthenticationResponse } from './model/authentication-response.model';
import { User } from './model/user.model';
import { Registration } from './model/registration.model';
import { PagedResults } from 'src/app/shared/model/paged-results.model';
import { MarketplaceService } from 'src/app/feature-modules/marketplace/marketplace.service';
import { People } from 'src/app/feature-modules/marketplace/model/person.model';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  user$ = new BehaviorSubject<User>({ username: '', id: 0, role: ''});

  constructor(
    private http: HttpClient,
    private tokenStorage: TokenStorage,
    private marketplaceService: MarketplaceService,
    private router: Router
  ) {}

  login(login: Login): Observable<AuthenticationResponse> {
    return this.http
      .post<AuthenticationResponse>(environment.apiHost + 'users/login', login)
      .pipe(
        tap((authenticationResponse) => {
          this.tokenStorage.saveAccessToken(authenticationResponse.accessToken);
          this.setUser();
        })
      );
  }

  register(registration: Registration): Observable<AuthenticationResponse> {
    return this.http
      .post<AuthenticationResponse>(environment.apiHost + 'users', registration)
      .pipe(
        tap((authenticationResponse) => {
          this.tokenStorage.saveAccessToken(authenticationResponse.accessToken);
          this.setUser();
        })
      );
  }

  logout(): void {
    this.router.navigate(['/home']).then((_) => {
      this.tokenStorage.clear();
      this.user$.next({ username: '', id: 0, role: ''});
    });
  }

  checkIfUserExists(): void {
    const accessToken = this.tokenStorage.getAccessToken();
    if (accessToken == null) {
      return;
    }
    this.setUser();
  }

  private setUser(): void {
    const jwtHelperService = new JwtHelperService();
    const accessToken = this.tokenStorage.getAccessToken() || '';
    const user: User = {
      id: +jwtHelperService.decodeToken(accessToken).id,
      username: jwtHelperService.decodeToken(accessToken).username,
      role: jwtHelperService.decodeToken(accessToken)[
        'http://schemas.microsoft.com/ws/2008/06/identity/claims/role'
      ],
    };
    this.user$.next(user);
  }

  getNameById(id: number): Observable<People> {
    return this.http.get<People>('https://localhost:44333/api/person/'+id); 
  }

  updateUserLocation(person: People): Observable<People> {
    return this.http.put<People>('https://localhost:44333/api/person/updateLocation/', person);
  }

  getAllUsers(loggedId: number): Observable<PagedResults<User>> {
    return this.http.get<PagedResults<User>>(
      'https://localhost:44333/api/users/allUsers/GetAll/' + loggedId
    );
  }

  getUserById(id: number): Observable<User> {
    return this.http.get<User>(
      'https://localhost:44333/api/users/allUsers/GetById/' + id
    );
  }
}
