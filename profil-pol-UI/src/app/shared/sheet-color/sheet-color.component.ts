import { SheetColor } from './../dictionaries/sheet-color.enum';
import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { SelectSheetColor } from '../models/select-sheet-color/select-sheet-color';


@Component({
  selector: 'app-sheet-color',
  templateUrl: './sheet-color.component.html',
  styleUrls: ['./sheet-color.component.scss']
})
export class SheetColorComponent implements OnInit {

  // public selectedColor: SelectSheetColor = { sheetColor: SheetColor.zlotyDab, imagePath: '../../../assets/images/sheetColor/Zloty_dab.PNG'};

  public selectedColor: SheetColor;
  // @Input() colorsAndPaths: SelectSheetColor[];
  @Output() select = new EventEmitter<SheetColor>();

  public colorsAndPaths: SelectSheetColor[] = [
    { sheetColor: SheetColor.zlotyDab, imagePath: '../../../assets/images/sheetColor/Zloty_dab.PNG', selected: true },
    { sheetColor: SheetColor.ciemnyDab, imagePath: '../../../assets/images/sheetColor/Ciemny_dab.PNG', selected: false },
    { sheetColor: SheetColor.ocynk, imagePath: '../../../assets/images/sheetColor/Ocynk.PNG', selected: false },

  ];

  constructor(

  ) { }

  ngOnInit() {
    this.selectedColor = SheetColor.zlotyDab;
  }

  public onSheetColorSelect(colorAndPath: SelectSheetColor) {

    // unselect last selected item
    this.colorsAndPaths.find(x => x.selected === true).selected = false;

    // select new
    colorAndPath.selected = !colorAndPath.selected;

    this.select.emit(colorAndPath.sheetColor);
  }

  public getKeyFromSheetColor(sheetColor: SheetColor) {
    return SheetColor[sheetColor];
  }


}
