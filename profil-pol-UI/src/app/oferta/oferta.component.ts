import { GarageCardContent } from './../shared/models/garage-card-content';
import { Component, OnInit } from '@angular/core';
import { garages } from './garages-to-cards';
@Component({
  selector: 'app-oferta',
  templateUrl: './oferta.component.html',
  styleUrls: ['./oferta.component.scss']
})
export class OfertaComponent implements OnInit {

  public garages: GarageCardContent[] = garages;
  constructor() { }

  ngOnInit() {
  }

}
