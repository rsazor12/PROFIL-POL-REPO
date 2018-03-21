import { ProductionStatusComponent } from './../../production-status/production-status.component';
import { Injectable } from '@angular/core';
// import { Http, Response, Headers, RequestOptions} from '@angular/http';
import { Observable } from 'rxjs/Observable';
// import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { Login } from '../models/login/login';
// import { RequestOptionsArgs } from '@angular/http/src/interfaces';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { ErrorObservable } from 'rxjs/observable/ErrorObservable';
import { catchError, retry } from 'rxjs/operators';


@Injectable()
export class LoginService {

  baseUrl = 'http://localhost:51950';
  public isLogedIn: boolean = undefined;


  constructor(
    private http: HttpClient
  ) { }

  login(email, password) {

    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type':  'application/json'
      })};

      const loginCommand: Login = { Email: email, Password: password};
      const loginData = JSON.stringify(loginCommand);
      const url = 'http://localhost:51950/Account/login';

      return this.http.post(url, loginData, httpOptions);
  }

  // private handleError(error: HttpErrorResponse) {
  //   // TODO toast here
  //   this.isLogedIn = false;
  //   console.log('unsuccesfully loged');
  //   if (error.error instanceof ErrorEvent) {
  //     // A client-side or network error occurred. Handle it accordingly.
  //     console.error('An error occurred:', error.error.message);
  //   } else {
  //     // The backend returned an unsuccessful response code.
  //     // The response body may contain clues as to what went wrong,
  //     console.error(
  //       `Backend returned code ${error.status}, ` +
  //       `body was: ${error.error}`);
  //   }
  //   // return an ErrorObservable with a user-facing error message
  //   return new ErrorObservable(
  //     'Something bad happened; please try again later.');
  // }

//   getUser(): Observable<User> {
//  return null as User;
//   }



  // public login(email, password) {
  //   // const headers = new Headers();
  //   // headers.append('Content-Type', 'application/json');

  //   const loginCommand: Login = { Email: email, Password: password};
  //   const loginData = JSON.stringify(loginCommand);
  //   const url = this.baseUrl + '/Account/login';


  //   const headers = new Headers({ 'Content-Type': 'application/json' });
  //   const options = new RequestOptions({ headers: headers });
  //   return this.http.post(url, loginData, options)
  //              .map(res => alert(res));
  //   // return this.http
  //   //   .post(
  //   //   url,
  //   //   loginData,
  //   //   { headers })
  //   //   .map(res => res.json())
  //   //   .map(res => {
  //   //     alert(res);
  //   //     localStorage.setItem('auth_token', res.auth_token);
  //   //     this.isLogedIn = true;
  //   //     return true;
  //   //   });
  // }


  // handleError() {
  //   alert('blad');
  // }
}
