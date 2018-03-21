import { Router } from '@angular/router';
import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-garage-card',
  templateUrl: './garage-card.component.html',
  styleUrls: ['./garage-card.component.scss']
})
export class GarageCardComponent implements OnInit {

  @Input() garageId: string;
  @Input() imagePath: string;
  @Input() name: string;
  @Input() price: number;
  @Input() available: string;
  @Input() deliveryTime: string;
  @Input() description: string;
  @Input() badgeContent: string;

  constructor(
    private router: Router
  ) { }

  ngOnInit() {
  }

  gotoItemDetailsPage() {
    this.router.navigate(['item-details/' + this.garageId]);
  }

}
