import { SheetType } from './../dictionaries/sheet-type.enum';
import { SheetColor } from './../dictionaries/sheet-color.enum';

// tslint:disable-next-line:class-name
export interface ItemDetails {
  garageId: string;
  itemName: string;
  imagePath: string;
  price: number;
  available: boolean;
  deliveryDays: number;
  sheetColor: SheetColor;
  sheetType: SheetType;
  sizes: string;
}
