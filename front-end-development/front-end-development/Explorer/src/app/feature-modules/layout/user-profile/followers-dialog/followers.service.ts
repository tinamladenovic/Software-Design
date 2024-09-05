import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AuthService } from 'src/app/infrastructure/auth/auth.service';
import { PagedResults } from 'src/app/shared/model/paged-results.model';
import { Followers } from './followers.model';
import { User } from 'src/app/infrastructure/auth/model/user.model';

@Injectable({
  providedIn: 'root'
})
export class FollowersService {

  constructor(private http: HttpClient, private authService : AuthService) { }

  getFollowers() : Observable<PagedResults<Followers>> {
    return this.http.get<PagedResults<Followers>>('https://localhost:44333/api/followers/users');
  } 

  createFollower(follower:Followers) : Observable<Followers> {
    return this.http.post<Followers>('https://localhost:44333/api/followers/users',follower);
  }

  deleteFollower(followedId: number,followingId:number): Observable<Followers> {
    return this.http.delete<Followers>('https://localhost:44333/api/followers/users/' + followedId +'/' + followingId);
  }

  getFollowerById(followedId: number,followingId:number) : Observable<Followers>{
    return this.http.get<Followers>('https://localhost:44333/api/followers/users/GetFollowersById/' + followedId +'/' + followingId);
  }


  getNotFollowing(loggedUserId: number): Observable<User[]> {
    return this.http.get<User[]>('https://localhost:44333/api/users/allUsers/NotFollowing/' + loggedUserId);
  }

}
 