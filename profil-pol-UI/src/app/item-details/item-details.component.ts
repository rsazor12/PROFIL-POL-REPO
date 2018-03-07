import { OrdersService } from './../shared/services/orders.service';
import { LoginService } from './../shared/services/login.service';
import { UserService } from './../shared/services/user.service';
import { Router } from '@angular/router';
import { CommonPageService } from './../shared/services/common-page.service';
import { SheetColor } from './../shared/dictionaries/sheet-color.enum';
import { MakeOrder } from './../shared/models/make-order';
import { ItemDetailsService } from './../shared/services/item-details.service';
import { ItemDetails } from './../shared/models/item-detail';
import { Component, OnInit } from '@angular/core';
import { NgIf } from '@angular/common';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';


@Component({
  selector: 'app-item-details',
  templateUrl: './item-details.component.html',
  styleUrls: ['./item-details.component.scss']
})
export class ItemDetailsComponent implements OnInit {

  public itemDetails: ItemDetails;
  public showForm: boolean;
  public orderForm: FormGroup;
  public selectedSheetColor: SheetColor;

  constructor(
    private itemDetailsService: ItemDetailsService,
    private formBuilder: FormBuilder,
    private commonPageService: CommonPageService,
    private router: Router,
    private userService: UserService,
    private loginService: LoginService,
    private ordersService: OrdersService
  ) { }

  ngOnInit() {
    this.itemDetails = this.itemDetailsService.getMockDetails();
    this.showForm = false;

    this.orderForm = this.buildOrderForm();
  }

  getCommonService(): CommonPageService {
    return this.commonPageService;
  }

  gotoKontaktPage() {
    this.router.navigate(['kontakt']);
  }

  showAlert(content: string) {
    alert(content);
  }

  public showOrderForm() {
    this.showForm = !this.showForm;
  }

  public onSelectSheetColor(sheetColor: SheetColor) {
    // this.setValueOfOrderProperty('SheetColor', sheetColor);
    this.selectedSheetColor = sheetColor;
  }

  buildOrderForm() {
    if (this.loginService.isLogedIn) {
      return this.formBuilder.group({
        email: ['', [Validators.required, Validators.email]],
        password: ['', [Validators.required]],
        address: ['', Validators.required],
        city: ['', Validators.required],
        location: ['', Validators.required],

      });

    } else {
      return this.formBuilder.group({
        email: [this.userService.userDetails.email, [Validators.required, Validators.email]],
        password: ['', [Validators.required]],
        address: [this.userService.userDetails.adress, Validators.required],
        city: [this.userService.userDetails.city, Validators.required],
        location: [this.userService.userDetails.location, Validators.required]
      });
    }
  }

  public makeOrder() {
    const order: MakeOrder = {} as MakeOrder;
    order.user_email = this.orderForm.get('email').value;
    order.id_garage = this.itemDetails.id_garage;
    order.price = this.itemDetails.price;
    order.sheetColor = this.selectedSheetColor;
    order.adres = this.orderForm.get('address').value;
    order.city = this.orderForm.get('city').value;
    order.location = this.orderForm.get('location').value;

    this.ordersService.CreateOrder(order);
  }


}
