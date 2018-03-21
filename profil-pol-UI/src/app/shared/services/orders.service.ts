import { GetOrderInfo } from './../models/get-order-info';
import { MakeOrder } from './../models/make-order';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { SheetColor } from './../dictionaries/sheet-color.enum';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { ProductionStatus } from '../dictionaries/production-status';
// import { Order } from '../../shared/models/order';

@Injectable()
export class OrdersService {

  constructor(
    private http: HttpClient
  ) { }

  public CreateOrder(order: MakeOrder): Observable<any> {

      // TODO use env here
      const getUserDetailsUrl = 'http://localhost:51950/Order/';
      const httpOptions = {
        headers: new HttpHeaders({
          'Content-Type':  'application/json'
        })
      };

        const createOrderCommand = JSON.stringify(order);

        return this.http.post<any>(getUserDetailsUrl, createOrderCommand, httpOptions);
    }

    public getOrdersInfo(userId: string): Observable<GetOrderInfo[]> {

     // TODO use env here
     const getUserDetailsUrl = 'http://localhost:51950/Order/GetOrdersInfo';
     const httpOptions = {
       headers: new HttpHeaders({
         'Content-Type':  'application/json'
       })
     };

       const createOrderCommand = JSON.stringify({UserId: userId});

       return this.http.post<any>(getUserDetailsUrl, createOrderCommand, httpOptions);

      }

  public getFakeOrders(): GetOrderInfo[] {

    const orders: GetOrderInfo[] = [
      {
      GarageId: '10123320230139231031230',
      GarageName: 'Garaz Dwuspadowy',
      GarageSizeX: '5',
      GarageSizeY: '4',
      GarageSizeZ: '3',
      SheetColor: SheetColor.ciemnyDab,
      ImagePath: '../../../assets/images/garages/20160602_085134_HDR.jpg',
      Description: 'Garaz dwuspadowy',
      OrderDate: '28-08-12',
      UserName: 'Jan',
      UserSurname: 'Kowalski',
      UserEmail: 'jankowalski@gmail.com',
      Adress: 'Kmiecie 132',
      City: 'Kmiecie',
      Location: 'Malopolska',
      Price: 1200,
      ProductionStatus: ProductionStatus.ZamowienieZlozone
    },
    {
      GarageId: '10123320230139231031230',
      GarageName: 'Garaz Dwuspadowy',
      GarageSizeX: '5',
      GarageSizeY: '4',
      GarageSizeZ: '3',
      SheetColor: SheetColor.ciemnyDab,
      ImagePath: '../../../assets/images/garages/20160602_085134_HDR.jpg',
      Description: 'Garaz dwuspadowy',
      OrderDate: '28-08-12',
      UserName: 'Jan',
      UserSurname: 'Kowalski',
      UserEmail: 'jankowalski@gmail.com',
      Adress: 'Kmiecie 132',
      City: 'Kmiecie',
      Location: 'Malopolska',
      Price: 1200,
      ProductionStatus: ProductionStatus.WTrakcieProdukcji
    },
    {
      GarageId: '10123320230139231031230',
      GarageName: 'Garaz Dwuspadowy',
      GarageSizeX: '5',
      GarageSizeY: '4',
      GarageSizeZ: '3',
      SheetColor: SheetColor.ciemnyDab,
      ImagePath: '../../../assets/images/garages/20160602_085134_HDR.jpg',
      Description: 'Garaz dwuspadowy',
      OrderDate: '28-08-12',
      UserName: 'Jan',
      UserSurname: 'Kowalski',
      UserEmail: 'jankowalski@gmail.com',
      Adress: 'Kmiecie 132',
      City: 'Kmiecie',
      Location: 'Malopolska',
      Price: 1200,
      ProductionStatus: ProductionStatus.Skonczone
    },
  ];
  return orders;
  }



}
