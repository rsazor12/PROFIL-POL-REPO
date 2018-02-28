import { SheetColor } from './../dictionaries/sheet-color.enum';
export interface Order {
  id: string;
  sheetColor: SheetColor;
  imagePath: string;
  description: string;
  date: string;
  name: string;
  surname: string;
  email: string;
  postCode: string;
  loacation: string;
  price: number;
  productionStatus: string;
}

