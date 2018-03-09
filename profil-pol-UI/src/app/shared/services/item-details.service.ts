import { SheetType } from './../dictionaries/sheet-type.enum';
import { SheetColor } from './../dictionaries/sheet-color.enum';
import { ItemDetails } from './../models/item-detail';
import { Injectable } from '@angular/core';

@Injectable()
export class ItemDetailsService {

  constructor() { }

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


}
