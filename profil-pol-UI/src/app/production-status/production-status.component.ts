import { SheetColor } from './../shared/dictionaries/sheet-color.enum';
import { UserService } from './../shared/services/user.service';
import { ProductionStatus } from './../shared/dictionaries/production-status';
import { RoutingHistoryService } from './../shared/services/routing-history.service';
import { GetOrderInfo } from './../shared/models/get-order-info';
// import { Order } from './../shared/models/order';
import { OrdersService } from './../shared/services/orders.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { error } from 'selenium-webdriver';

@Component({
  selector: 'app-production-status',
  templateUrl: './production-status.component.html',
  styleUrls: ['./production-status.component.scss']
})
export class ProductionStatusComponent implements OnInit {
  public orders: GetOrderInfo[];
  constructor(
    private ordersService: OrdersService,
    private router: Router,
    private routingHistoryService: RoutingHistoryService,
    private userService: UserService
    ) {}

  ngOnInit() {
    // this.orders = this.ordersService.getFakeOrders();
    this.ordersService
    .getOrdersInfo(this.userService.userDetails.email)
    .subscribe(
      res => this.orders = res
    );
  }

  gotoPreviousPage() {
    this.router.navigate([this.routingHistoryService.getPreviousUrl()]);
  }

  mapIndexToEnumValue(index: number): string {
    return Object.values(SheetColor)[index];
  }

}
