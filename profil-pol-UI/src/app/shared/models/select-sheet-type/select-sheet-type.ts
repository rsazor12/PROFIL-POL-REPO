import { SheetType } from './../../dictionaries/sheet-type.enum';
export interface SelectSheetType {
  sheetType: SheetType;
  imagePath: string;
  selected: boolean;
}
