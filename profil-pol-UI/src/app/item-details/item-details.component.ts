import { Router } from '@angular/router';
import { CommonPageService } from './../shared/services/common-page.service';
import { SheetColor } from './../shared/dictionaries/sheet-color.enum';
import { Order } from './../shared/models/order';
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

  public order: Order;
  public itemDetails: ItemDetails;
  public showForm: boolean;
  orderForm: FormGroup;

  constructor(
    private itemDetailsService: ItemDetailsService,
    private formBuilder: FormBuilder,
    private commonPageService: CommonPageService,
    private router: Router
  ) { }

  ngOnInit() {
    this.order = {} as Order;
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
    this.setValueOfOrderProperty('SheetColor', sheetColor);
  }

  private setValueOfOrderProperty(propertyName: string, propertyValue: any) {
    this.order[propertyName] = propertyValue;
  }

  buildOrderForm() {
    return this.formBuilder.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required]],
      address: ['', Validators.required],
      city: ['', Validators.required],
      location: ['', Validators.required],
      postCode: ['', Validators.required],
    });
  }


}
