import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-kontakt',
  templateUrl: './kontakt.component.html',
  styleUrls: ['./kontakt.component.scss']
})
export class KontaktComponent implements OnInit {

  public title = 'My first AGM project';
  public lat = 51.678418;
  public lng = 7.809007;

  constructor() { }

  ngOnInit() {
  }

}
