import { OfferService } from './../shared/services/offer.service';
import { OfferDetails } from './../shared/models/garage-card-content';
import { Component, OnInit } from '@angular/core';
@Component({
  selector: 'app-oferta',
  templateUrl: './oferta.component.html',
  styleUrls: ['./oferta.component.scss']
})
export class OfertaComponent implements OnInit {

  public garagesOfferDetails: OfferDetails[];
  constructor(
    private offerService: OfferService
  ) { }

  public getOfferService(): OfferService {
    return this.offerService;
  }

  // TODO error handling
  ngOnInit() {
    this.offerService.getGarageOfferDetails();
    // .subscribe(
    //   res => {
    //     this.garagesOfferDetails = res;
    //     this.offerService.garageCardContentArray = res;
    //   }
    // );
  }

}
