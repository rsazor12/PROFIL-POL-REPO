import { Order } from './../shared/models/order';
import { OrdersService } from './../shared/services/orders.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-production-status',
  templateUrl: './production-status.component.html',
  styleUrls: ['./production-status.component.scss']
})
export class ProductionStatusComponent implements OnInit {

  public orders: Order[] = [];
  constructor(
    private ordersService: OrdersService
    ) {}

  ngOnInit() {
    this.orders = this.ordersService.getFakeOrders();
  }

}
