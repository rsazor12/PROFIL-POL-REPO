import { CommonPageService } from './../services/common-page.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

declare var $: any;
@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {


  constructor(
    private router: Router,
    private commonPageService: CommonPageService
  ) { }

  ngOnInit() {
    $(window).on('scroll', function() {
      if ($(window).scrollTop()) {
        $('nav').addClass('black');
      } else {
        $('nav').removeClass('black');
      }
    });

    $(document).ready(function() {
      $('.menu h4').click(function() {
        alert('click');
        $('nav ul').toggleClass('active');
      });
    });
  }

  getCommonPageService(): CommonPageService {
    return this.commonPageService;
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

  gotoLoginPage() {
    this.router.navigate(['login']);
  }

  gotoProductionStatusPage() {
    this.router.navigate(['production-status']);
  }

}
