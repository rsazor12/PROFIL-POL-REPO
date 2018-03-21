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
import { ActivatedRoute } from '@angular/router';
import { OnDestroy } from '@angular/core/src/metadata/lifecycle_hooks';
import { error } from 'selenium-webdriver';

@Component({
  selector: 'app-item-details',
  templateUrl: './item-details.component.html',
  styleUrls: ['./item-details.component.scss']
})
export class ItemDetailsComponent implements OnInit, OnDestroy {

  public garageId: number;

  public itemDetails: ItemDetails;
  public showForm: boolean;
  public orderForm: FormGroup;
  public selectedSheetColor: SheetColor = SheetColor.zlotyDab;

  private sub: any;
  private subItemDetails: any;

  constructor(
    private itemDetailsService: ItemDetailsService,
    private formBuilder: FormBuilder,
    private commonPageService: CommonPageService,
    private router: Router,
    private userService: UserService,
    private loginService: LoginService,
    private ordersService: OrdersService,
    private routeLink: ActivatedRoute
  ) { }

  ngOnInit() {
    // TODO clean here and add error handling
    this.showForm = false;
    this.orderForm = this.buildOrderForm();

    this.sub = this.routeLink.params.subscribe(params => {
          this.subItemDetails = this.itemDetailsService.getItemDetails(params['id'])
            .subscribe(res =>
              this.itemDetails = res
              );
    });
  }

  ngOnDestroy() {
    this.sub.unsubscribe();
    this.subItemDetails.unsubscribe();
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
      return this.formBuilder.group({
        email: ['', [Validators.required, Validators.email]],
        password: ['', [Validators.required]],
        address: ['', Validators.required],
        city: ['', Validators.required],
        location: ['', Validators.required],
      });
  }

  public makeOrder() {
    // TODO change this values
    const order: MakeOrder = {} as MakeOrder;
    order.UserEmail = this.orderForm.get('email').value;
    order.UserName = 'kamil',
    order.UserSurname = 'bielski',
    order.Password = '123456',
    order.GarageId = this.itemDetails.id_garage;
    order.Price = this.itemDetails.price;
    order.SheetColor = 0; // this.selectedSheetColor;
    order.Adress = this.orderForm.get('address').value;
    order.City = this.orderForm.get('city').value;
    order.Location = this.orderForm.get('location').value;

    this.ordersService.CreateOrder(order)
      .subscribe(res => alert(res));
  }


}
