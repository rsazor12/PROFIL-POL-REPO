import { UserDetails } from './../models/userDetails';
import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';

@Injectable()
export class UserService {

  public userDetails: UserDetails;
  constructor(
    private http: HttpClient
  ) { }

  getUserDetailsByEmail(email: string) {

  // TODO use env here
  const getUserDetailsUrl = 'http://localhost:51950/Account/';
  const httpOptions = {
    headers: new HttpHeaders({
      'Content-Type':  'application/json',
      'Authorization': localStorage.getItem('auth_token')
    })
  };

  const getUserDetailsCommand = JSON.stringify({ Email: email});

    return this.http.post<UserDetails>(getUserDetailsUrl, getUserDetailsCommand, httpOptions)
    .subscribe(resp => {
      this.userDetails = resp;
    });
  }
}
