import { GarageCardContent } from './../models/garage-card-content';
import { ItemDetails } from './../models/item-detail';
import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class OfferService {

  public garageCardContentArray: GarageCardContent[] = [];
  constructor(
    private http: HttpClient
  ) {
    // GEt all garages offer details
    this.getGarageOfferDetails();
  }

  getGarageOfferDetails(): Observable<GarageCardContent[]> {

    // TODO use env here
    const getGaragesOfferDetailsUrl = 'http://localhost:51950/garages/GetGarageOfferDetails';
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type':  'application/json'
      })
    };

   return this.http.get<GarageCardContent[]>(getGaragesOfferDetailsUrl, httpOptions);
    }
}
