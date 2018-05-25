import { OfferDetails } from './../models/garage-card-content';
import { ItemDetails } from './../models/item-detail';
import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { environment } from '../../../environments/environment';

@Injectable()
export class OfferService {

  // TODO clean
  public garageCardContentArray: OfferDetails[] = [];


  constructor(
    private http: HttpClient
  ) {
    // TODO it is necesarry ?
    // GEt all garages offer details
    // this.getGarageOfferDetails();
  }

  getGarageOfferDetails() {

    // TODO use env here
    const getGaragesOfferDetailsUrl = environment.apiUrl + '/offers';
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type':  'application/json'
      })
    };

   return this.http.get<OfferDetails[]>(getGaragesOfferDetailsUrl, httpOptions).subscribe(
    res => {
      this.garageCardContentArray = res;
    });

    }
}
