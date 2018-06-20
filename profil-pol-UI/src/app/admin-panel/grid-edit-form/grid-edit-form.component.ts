import { Component, OnInit } from '@angular/core';
import { Input, Output, EventEmitter } from '@angular/core';
import { Validators, FormGroup, FormControl } from '@angular/forms';
// import { Product } from './model';

@Component({
  selector: 'app-grid-edit-form',
  templateUrl: './grid-edit-form.component.html',
  styleUrls: ['./grid-edit-form.component.scss']
})
export class GridEditFormComponent {

  // public active = false;
  // public editForm: FormGroup = new FormGroup({
  //     'ProductID': new FormControl(),
  //     'ProductName': new FormControl('', Validators.required),
  //     'UnitPrice': new FormControl(0),
  //     'UnitsInStock': new FormControl('', Validators.compose([Validators.required, Validators.pattern('^[0-9]{1,3}')])),
  //     'Discontinued': new FormControl(false)
  // });

  // @Input() public isNew = false;

  // @Input() public set model(product: Product) {
  //     this.editForm.reset(product);

  //     this.active = product !== undefined;
  // }

  // @Output() cancel: EventEmitter<any> = new EventEmitter();
  // @Output() save: EventEmitter<Product> = new EventEmitter();

  // public onSave(e): void {
  //     e.preventDefault();
  //     this.save.emit(this.editForm.value);
  //     this.active = false;
  // }

  // public onCancel(e): void {
  //     e.preventDefault();
  //     this.closeForm();
  // }

  // private closeForm(): void {
  //     this.active = false;
  //     this.cancel.emit();
  // }

}
