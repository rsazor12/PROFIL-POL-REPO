import { SheetColor } from '../dictionaries/sheet-color.enum';
import { ProductionStatus } from '../dictionaries/production-status';

export interface GetOrderInfo {
  // item details
  GarageId: string;
  GarageName: string;
  GarageSizeX: string;
  GarageSizeY: string;
  GarageSizeZ: string;
  Price: number;
  SheetColor: SheetColor;
  ProductionStatus: ProductionStatus;
  ImagePath: string;
  Description: string;
  OrderDate: string;
  // user details
  UserName: string;
  UserSurname: string;
  UserEmail: string;
  Adress: string;
  City: string;
  Location: string;
}

