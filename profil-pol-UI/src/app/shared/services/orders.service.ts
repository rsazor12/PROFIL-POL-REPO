import { SheetColor } from './../dictionaries/sheet-color.enum';
import { Injectable } from '@angular/core';
import { Order } from '../../shared/models/order';

@Injectable()
export class OrdersService {

  constructor(
  ) { }

  public getFakeOrders(): Order[] {

    const orders: Order[] = [
      {
      id: '10123320230139231031230',
      sheetColor: SheetColor.ciemnyDab,
      // here should be direct path
      imagePath: '../../../assets/images/garages/20160602_085134_HDR.jpg',
      description: 'Garaz dwuspadowy',
      date: '28-08-12',
      name: 'Jan',
      surname: 'Kowalski',
      email: 'jankowalski@gmail.com',
      postCode: '34-640',
      loacation: 'Kmiecie',
      price: 1200,
      productionStatus: 'ZLOZONO ZAMOWIENIE'
    },
  ];
  return orders;
  }



}
