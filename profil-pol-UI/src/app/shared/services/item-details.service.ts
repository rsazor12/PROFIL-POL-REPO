import { HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { SheetType } from './../dictionaries/sheet-type.enum';
import { SheetColor } from './../dictionaries/sheet-color.enum';
import { ItemDetails } from './../models/item-detail';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class ItemDetailsService {

  constructor(
    private http: HttpClient
  ) { }

  public getMockDetails(): ItemDetails {
    return {
      id_garage: '00000000000000000000000000000001',
      itemName: 'Garaz jednospadowy',
      imagePath: '../../../assets/images/garages/20160603_084340_HDR.jpg',
      price: 1200,
      available: true,
      deliveryDays: 5,
      sheetColor: SheetColor.zlotyDab,
      sheetType: SheetType.ocynk
    } as ItemDetails;
  }

  getItemDetails(garageId: string): Observable<ItemDetails> {

    // TODO use env here
    const getItemDetailsUrl = 'http://localhost:51950/garages/GetItemDetails/' + garageId;
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type':  'application/json'
      })
    };

   return this.http.get<ItemDetails>(getItemDetailsUrl, httpOptions);
  }


}
