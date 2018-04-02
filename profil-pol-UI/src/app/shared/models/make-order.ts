import { SheetType } from './../dictionaries/sheet-type.enum';
import { SheetColor } from './../dictionaries/sheet-color.enum';
export interface MakeOrder {
  // item details
  GarageId: string;
  Price: number;
  SheetColor: number;
  XLength: number;
  YLength: number;
  ZLength: number;
  // user details
  UserName: string;
  UserSurname: string;
  Password: string;
  UserEmail: string;
  Adress: string;
  City: string;
  Location: string;
}

