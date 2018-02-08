import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {

  constructor(private router: Router) { }

  ngOnInit() {
  }

  gotoStartPage() {
    this.router.navigate(['start']);
  }

  gotoOfertaPage() {
    this.router.navigate(['oferta']);
  }

  gotoKontaktPage() {
    this.router.navigate(['kontakt']);
  }

  gotoPoradnikPage() {
    this.router.navigate(['poradnik']);
  }

  gotoGaleriaPage() {
    this.router.navigate(['galeria']);
  }

}
