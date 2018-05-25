import { Router } from '@angular/router';
import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-garage-card',
  templateUrl: './garage-card.component.html',
  styleUrls: ['./garage-card.component.scss']
})
export class GarageCardComponent implements OnInit {

  @Input() idOffer: string;
  @Input() imagePath: string;
  @Input() name: string;
  @Input() available: boolean;
  @Input() shortDescription: string;
  @Input() longDescription: string;
  @Input() badgeColour: string;
  @Input() badgeContent: string;
  @Input() price: number;
  @Input() discount: number;
  @Input() availableSizes: any[];
  @Input() availableDoors: any[];
  @Input() availableSheets: any[];


  constructor(
    private router: Router
  ) { }

  ngOnInit() {
  }

  gotoItemDetailsPage() {
    this.router.navigate(['item-details/' + this.idOffer]);
    // this.router.navigate(['item-details'], { queryParams: { idOffer: idOffer, imagePath: imagePath, name: name } });
    // tslint:disable-next-line:max-line-length
    // this.router.navigate(['/item-details', this.idOffer, this.imagePath, this.name, this.available, this.longDescription, this.price, this.availableSizes, this.availableDoors, this.availableSheets]);
  }

}
