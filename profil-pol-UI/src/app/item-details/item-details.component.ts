import { OfferDetails } from './../shared/models/garage-card-content';
import { OfferService} from './../shared/services/offer.service';
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
import { SheetType } from '../shared/dictionaries/sheet-type.enum';

@Component({
  selector: 'app-item-details',
  templateUrl: './item-details.component.html',
  styleUrls: ['./item-details.component.scss']
})
export class ItemDetailsComponent implements OnInit, OnDestroy {

  // public garageId: number;

  // public itemDetails: ItemDetails;

  public idOffer: string;
  public offerDetails: OfferDetails;
  // public imagePath: string;
  // public name: string;
  // public available: boolean;
  // public longDescription: string;
  // public price: string;
  // public availableSizes: any[];
  // public availableDoors: any[];
  // public availableSheets: any[];


  public showForm: boolean;
  public orderForm: FormGroup;

  public selectedSheetColor: SheetColor = SheetColor.zlotyDab;
  public selectedSheetType: SheetType = SheetType.Polysk;

  public selectedGarageSize = null;

  private sub: any;
  private subItemDetails: any;

  constructor(
    private itemDetailsService: ItemDetailsService,
    private offerService: OfferService,
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


    // get item details

    this.sub = this.routeLink.params.subscribe(params => {
      this.idOffer = params['idOffer'];

      this.initOfferDetails();
      // this.imagePath = params['imagePath'];
      // this.name = params['name'];
      // this.available = params['available'];
      // this.longDescription = params['longDescription'];
      // this.price = params['price'];
      // this.availableSizes = params['availableSizes'];
      // this.availableDoors = params['availableDoors'];
      // this.availableSheets = params['availableSheets'];
    });

    // this.sub = this.routeLink.params.subscribe(params => {
    //       this.subItemDetails = this.itemDetailsService.getItemDetails(params['id'])
    //         .subscribe(res =>
    //           this.itemDetails = res
    //           );
    // });
  }

  ngOnDestroy() {
   // this.sub.unsubscribe();
   // this.subItemDetails.unsubscribe();
  }

  public initOfferDetails() {
    this.offerDetails = this.offerService.garageCardContentArray.find(offer => offer.idOffer === this.idOffer);
  }

  public getOfferService(): OfferService {
    return this.offerService;
  }

  // TODO - polskie litery
  showSuccess() {
    this.toastr.success('Zamówienie zostało złożone, zaloguj się i zajrzyj do sekcji "Moje Zamówienia"', 'Udało się!');
  }

  showError() {
    this.toastr.error('Niestety formularz zamówienia uległ awarii, prosimy o kontakt telefoniczny!', 'Bład strony!');
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

  public onSelectSheetType(sheetType: SheetType) {
    this.selectedSheetType = sheetType;
  }

  public onSelectGarageSize(size: string) {
    this.selectedGarageSize = size;
    console.log(size);
  }

  buildOrderForm() {
      return this.formBuilder.group({
        email: ['', [Validators.required, Validators.email]],
        password: ['', [Validators.required]],
        name: ['', [Validators.required]],
        surname: ['', [Validators.required]],
        city: ['', Validators.required],
        houseNumber: ['', [Validators.required]],
        location: ['', Validators.required],
        zipCode: ['', Validators.required],
        postCity: ['', [Validators.required]],
      });
  }

  public makeOrder() {
    // TODO change this values
    // User details
    const order: MakeOrder = {} as MakeOrder;
    order.UserName = this.orderForm.get('name').value;
    order.UserSurname = this.orderForm.get('surname').value;
    order.UserEmail = this.orderForm.get('email').value;
    order.Password = this.orderForm.get('password').value;
    order.City = this.orderForm.get('city').value;
    order.PostCity = this.orderForm.get('postCity').value;
    order.Location = this.orderForm.get('location').value;
    order.ZipCode = this.orderForm.get('zipCode').value;
    order.HouseNumber = this.orderForm.get('houseNumber').value;
    // item details
    // order.GarageId = this.itemDetails.garageId;
    // order.Price = this.itemDetails.price;
    order.OfferId = this.offerDetails.idOffer;
    order.Price = this.offerDetails.price;
    order.XLength = +this.selectedGarageSize.xLength;
    order.YLength = +this.selectedGarageSize.yLength;
    order.ZLength = +this.selectedGarageSize.zLength;
    order.SheetColor = this.mapSheetColor(this.selectedSheetColor);
    order.SheetType = this.mapSheetType(this.selectedSheetType);
    order.DoorType = 'niezdefiniowane';
    order.DoorXLength = 0;
    order.DoorYLength = 0;


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

  private mapSheetType(sheetType: string): number {
    let indexOfColor: number;

    Object.values(SheetType).forEach( (type, index) => {
      if (type === sheetType) {
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
