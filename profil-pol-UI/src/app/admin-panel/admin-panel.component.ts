import { ProductionStatus } from './../shared/dictionaries/production-status';
import { SheetColor } from './../shared/dictionaries/sheet-color.enum';
import { GetOrderInfo } from './../shared/models/get-order-info';
import { UserService } from './../shared/services/user.service';
import { OrdersService } from './../shared/services/orders.service';
import { Observable } from 'rxjs/Observable';
import { Component, OnInit, Inject } from '@angular/core';
import { Validators, FormBuilder, FormGroup } from '@angular/forms';

import { GridDataResult } from '@progress/kendo-angular-grid';
import { State, process } from '@progress/kendo-data-query';

import { GetOrderInfoClass } from './grid-edit-form/model';
import { EditService } from './edit.service';

import { map } from 'rxjs/operators/map';

@Component({
  selector: 'app-admin-panel',
  templateUrl: './admin-panel.component.html',
  styleUrls: ['./admin-panel.component.scss']
})
export class AdminPanelComponent implements OnInit {

  public listItemsToDropDown: Array<string> = ['Rozpoczete', 'W trakcie', 'Wykonane'];
  public formGroup: FormGroup;

  public view: Observable<GridDataResult>;
  public gridState: State = {
      sort: [],
      skip: 0,
      take: 10,
      group: []
  };

  public changes: any = {};
  private orders: GetOrderInfo[];

  constructor(
    private formBuilder: FormBuilder,
    // private ordersService: OrdersService,
    // private userService: UserService,
    public editService: EditService) {

  }

  public ngOnInit(): void {
      this.view = this.editService.pipe(map(data => process(data, this.gridState)));

    //   this.ordersService
    // .getOrdersInfo(this.userService.userDetails.id)
    // .subscribe(
    //   res => this.orders = res
    // );

      this.editService.read();
  }

  public onChangeDropDown(newValue) {
         this.formGroup.get('productionStatus').setValue(newValue);
         this.formGroup.markAsDirty();
         this.view['destination']['value'][0]['productionStatus'] = newValue;
         // this.orderForm.get('postCity').value
    }

  public onStateChange(state: State) {
      this.gridState = state;

      this.editService.read();
  }

  public cellClickHandler({ sender, rowIndex, columnIndex, dataItem, isEdited }) {
      if (!isEdited) {
          sender.editCell(rowIndex, columnIndex, this.createFormGroup(dataItem));
      }
  }

  public cellCloseHandler(args: any) {
      const { formGroup, dataItem } = args;

      if (!formGroup.valid) {
           // prevent closing the edited cell if there are invalid values.
          args.preventDefault();
      } else if (formGroup.dirty) {
          this.editService.assignValues(dataItem, formGroup.value);
          this.editService.update(dataItem);
      }
  }

  public addHandler({ sender }) {
      sender.addRow(this.createFormGroup(new GetOrderInfoClass()));
  }

  public cancelHandler({ sender, rowIndex }) {
      sender.closeRow(rowIndex);
  }

  public saveHandler({ sender, formGroup, rowIndex }) {
      if (formGroup.valid) {
          this.editService.create(formGroup.value);
          sender.closeRow(rowIndex);
      }
  }

  public removeHandler({ sender, dataItem }) {
      this.editService.remove(dataItem);

      sender.cancelCell();
  }

  public saveChanges(grid: any): void {
      grid.closeCell();
      grid.cancelCell();

      this.editService.saveChanges();
  }

  public cancelChanges(grid: any): void {
      grid.cancelCell();

      this.editService.cancelChanges();
  }

  // TODO change model of this function
  public createFormGroup(dataItem: GetOrderInfo): FormGroup {
      return this.formGroup = this.formBuilder.group({
          'itemName': dataItem.itemName,
          'userName': dataItem.userName,
          'surname': dataItem.surname,
          'street': dataItem.street,
          'houseNumber': dataItem.houseNumber,
          'zipNumber': dataItem.zipNumber,
          'location': dataItem.location,
          'city': dataItem.city,
          'telephoneNumber': dataItem.telephoneNumber,
          'doorType': dataItem.doorType,
          'email': dataItem.email,
          'xLength': dataItem.xLength,
          'yLength': dataItem.yLength,
          'zLength': dataItem.zLength,
          'colorName': dataItem.colorName,
          'sheetType': dataItem.sheetType,
          'price': dataItem.price,
          'productionStatus': dataItem.productionStatus,
          'kindOfPayment': dataItem.kindOfPayment,
          'paymentStatus': dataItem.paymentStatus,

          // 'garageName': dataItem.garageName,
          // 'garageSizeX': dataItem.garageSizeX, // [dataItem.garageSizeX, Validators.required],
          // 'garageSizeY': dataItem.garageSizeY, // [dataItem.garageSizeY, Validators.required],
          // 'garageSizeZ': dataItem.garageSizeZ, // [dataItem.garageSizeZ, Validators.required],
          // 'price': dataItem.price,
          // // tslint:disable-next-line:max-line-length
          // 'sheetColor': dataItem.SheetColor, // [dataItem.sheetColor, Validators.compose([Validators.required/*, Validators.pattern('')]*/])], // TODO values from enum
          // 'productionStatus': dataItem.productionStatus,
          // 'orderDate': dataItem.orderDate,
          // 'userName': dataItem.userName,
          // 'userSurname': dataItem.userSurname,
          // 'userEmail': dataItem.userEmail,
          // 'adress': dataItem.adress,
          // 'city': dataItem.city,
          // 'location' : dataItem.location
      });
  }

}
