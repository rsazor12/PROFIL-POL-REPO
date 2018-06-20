import { SheetType } from './../dictionaries/sheet-type.enum';
import { SheetColor } from './../dictionaries/sheet-color.enum';
export interface MakeOrder {
  // user details
  UserName: string;
  UserSurname: string;
  UserEmail: string;
  Password: string;
  City: string;
  PostCity: string;
  Location: string;
  ZipCode: string;
  HouseNumber: string;
  TelephoneNumber: string;
  // item details
  OfferId: string;
  Price: number;
  XLength: number;
  YLength: number;
  ZLength: number;
  SheetColor: string;
  SheetType: string;
  DoorType: string;
  DoorXLength: number;
  DoorYLength: number;
}

