import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-garage-card',
  templateUrl: './garage-card.component.html',
  styleUrls: ['./garage-card.component.scss']
})
export class GarageCardComponent implements OnInit {

  @Input() imagePath: string;
  @Input() name: string;
  @Input() price: number;
  @Input() available: string;
  @Input() deliveryTime: string;
  @Input() description: string;
  @Input() badgeContent: string;

  constructor() { }

  ngOnInit() {
  }

}
