import { OfferService } from './../shared/services/offer.service';
import { GarageCardContent } from './../shared/models/garage-card-content';
import { Component, OnInit } from '@angular/core';
@Component({
  selector: 'app-oferta',
  templateUrl: './oferta.component.html',
  styleUrls: ['./oferta.component.scss']
})
export class OfertaComponent implements OnInit {

  public garages: GarageCardContent[]; // = garages;
  constructor(
    private offerService: OfferService
  ) { }

  // TODO error handling
  ngOnInit() {
    this.offerService.getGarageOfferDetails()
    .subscribe(
      res => {
        this.garages = res;
      }
    );
  }

}
