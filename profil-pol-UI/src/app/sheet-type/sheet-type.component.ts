import { SelectSheetColor } from './../shared/models/select-sheet-color/select-sheet-color';
import { SheetType } from './../shared/dictionaries/sheet-type.enum';
import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { SelectSheetType } from '../shared/models/select-sheet-type/select-sheet-type';

@Component({
  selector: 'app-sheet-type',
  templateUrl: './sheet-type.component.html',
  styleUrls: ['./sheet-type.component.scss']
})
export class SheetTypeComponent implements OnInit {

  public selectedColor: SheetType;
  // @Input() colorsAndPaths: SelectSheetColor[];
  @Output() select = new EventEmitter<SheetType>();

  public typesAndPaths: SelectSheetType[] = [
    { sheetType: SheetType.Polysk, imagePath: '../../assets/images/sheetType/polysk.PNG', selected: true },
    { sheetType: SheetType.Matowy, imagePath: '../../assets/images/sheetType/mat.PNG', selected: false },
    { sheetType: SheetType.Ocynk, imagePath: '../../assets/images/sheetType/ocynk.PNG', selected: false },

  ];

  constructor(

  ) { }

  ngOnInit() {
    this.selectedColor = SheetType.Polysk;
  }

  public onSheetTypeSelect(colorAndPath: SelectSheetType) {

    // unselect last selected item
    this.typesAndPaths.find(x => x.selected === true).selected = false;

    // select new
    colorAndPath.selected = !colorAndPath.selected;

    this.select.emit(colorAndPath.sheetType);
  }

  public getKeyFromSheetColor(sheetType: SheetType) {
    return SheetType[sheetType];
  }

}
