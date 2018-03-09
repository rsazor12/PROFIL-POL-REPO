import { SheetColor } from './../dictionaries/sheet-color.enum';
export interface MakeOrder {
  // item details
  GarageId: string;
  Price: number;
  SheetColor: number;
  // user details
  UserName: string;
  UserSurname: string;
  Password: string;
  UserEmail: string;
  Adress: string;
  City: string;
  Location: string;
}

