import { environment } from './../../../environments/environment';
import { HttpHeaders } from '@angular/common/http';
import { Email } from './../models/contact/email';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class ContactService {

  constructor(
    private http: HttpClient
  ) { }

  sendEmail(email: Email) {

    // TODO use env here
    const sendEmailUrl = environment.apiUrl + '/users/SendEmail';
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type':  'application/json'
      })
    };

    const sendEmailCommand = JSON.stringify(email);

      return this.http.post<any>(sendEmailUrl, sendEmailCommand, httpOptions);
    }

}
