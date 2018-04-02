import { ErrorObservable } from 'rxjs/observable/ErrorObservable';
import { catchError } from 'rxjs/operators';
import { HttpErrorResponse } from '@angular/common/http';
import { ToastsManager } from 'ng2-toastr';
import { OrdersService } from './../shared/services/orders.service';
import { LoginService } from './../shared/services/login.service';
import { UserService } from './../shared/services/user.service';
import { Router } from '@angular/router';
import { CommonPageService } from './../shared/services/common-page.service';
import { SheetColor } from './../shared/dictionaries/sheet-color.enum';
import { MakeOrder } from './../shared/models/make-order';
import { ItemDetailsService } from './../shared/services/item-details.service';
import { ItemDetails } from './../shared/models/item-detail';
import { Component, OnInit, ViewContainerRef } from '@angular/core';
import { NgIf } from '@angular/common';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { OnDestroy } from '@angular/core/src/metadata/lifecycle_hooks';

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
  public selectedGarageSize: string = null;

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
    private routeLink: ActivatedRoute,
    public toastr: ToastsManager, vcr: ViewContainerRef,
  ) {
    this.toastr.setRootViewContainerRef(vcr);
   }

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

  // TODO - polskie litery
  showSuccess() {
    this.toastr.success('Zamowienie zostalo zlozone, zaloguj sie i zajrzyj do sekcji "Moje Zamowienia"', 'Udalo sie!');
  }

  showError() {
    this.toastr.error('Niestety formularz zamowienia ulegl awarii, prosimy o kontakt telefoniczny!', 'Blad strony!');
  }

  getCommonService(): CommonPageService {
    return this.commonPageService;
  }

  gotoKontaktPage() {
    this.router.navigate(['kontakt']);
  }

  public showOrderForm() {
    this.showForm = !this.showForm;
  }

  public onSelectSheetColor(sheetColor: SheetColor) {
    this.selectedSheetColor = sheetColor;
  }

  public onSelectGarageSize(size: string) {
    this.selectedGarageSize = size;
    console.log(size);
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
    order.UserName = '',
    order.UserSurname = '',
    order.Password = this.orderForm.get('password').value;
    order.GarageId = this.itemDetails.garageId;
    order.Price = this.itemDetails.price;
    order.SheetColor = this.mapSheetColor(this.selectedSheetColor);
    order.XLength = +this.selectedGarageSize.split('x')[0];
    order.YLength = +this.selectedGarageSize.split('x')[1];
    order.ZLength = +this.selectedGarageSize.split('x')[2];
    order.Adress = this.orderForm.get('address').value;
    order.City = this.orderForm.get('city').value;
    order.Location = this.orderForm.get('location').value;

    this.ordersService.CreateOrder(order)
      .pipe(catchError(this.handleError))
      .subscribe(
       res => {
         this.showSuccess();
         this.orderForm.reset();
         this.showOrderForm();
       },
       error => this.showError());
  }

  // TODO Obszywka
  private mapSheetColor(sheetColor: string): number {
    let indexOfColor: number;

    Object.values(SheetColor).forEach( (color, index) => {
      if (color === sheetColor) {
        indexOfColor = index;
      }
    });

    return indexOfColor;
  }

  private handleError(error: HttpErrorResponse) {

    if (error.error instanceof ErrorEvent) {
      // A client-side or network error occurred. Handle it accordingly.
      console.error('An error occurred:', error.error.message);
    } else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong,
      console.error(
        `Backend returned code ${error.status}, ` +
        `body was: ${error.error}`);
    }
    // return an ErrorObservable with a user-facing error message
    return new ErrorObservable(
      'Something bad happened; please try again later.');
  }


}
