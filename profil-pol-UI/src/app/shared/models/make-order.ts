import { SheetColor } from './../dictionaries/sheet-color.enum';
export interface MakeOrder {
  // item details
  garageId: string;
  price: number;
  sheetColor: SheetColor;
  // user details
  name: string;
  surname: string;
  userEmail: string;
  adres: string;
  city: string;
  location: string;
}

