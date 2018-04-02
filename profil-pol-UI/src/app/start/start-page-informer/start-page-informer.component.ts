import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-start-page-informer',
  templateUrl: './start-page-informer.component.html',
  styleUrls: ['./start-page-informer.component.scss']
})
export class StartPageInformerComponent implements OnInit {

  constructor(
    private router: Router
  ) { }

  ngOnInit() {
  }

  gotoOfertaPage() {
    this.router.navigate(['oferta']);
  }

}
