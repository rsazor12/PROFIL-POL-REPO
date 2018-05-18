import { SheetColor } from '../dictionaries/sheet-color.enum';
import { ProductionStatus } from '../dictionaries/production-status';

export interface GetOrderInfo {
  // item details
  orderId: string;
  garageId: string;
  garageName: string;
  garageSizeX: string;
  garageSizeY: string;
  garageSizeZ: string;
  price: number;
  sheetColor: SheetColor;
  productionStatus: ProductionStatus;
  imagePath: string;
  description: string;
  orderDate: string;
  // user details
  userName: string;
  userSurname: string;
  userEmail: string;
  adress: string;
  city: string;
  location: string;
}

