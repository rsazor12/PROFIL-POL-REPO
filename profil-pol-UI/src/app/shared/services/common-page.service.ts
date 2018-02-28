import { Injectable, OnInit } from '@angular/core';

@Injectable()
export class CommonPageService implements OnInit {
  loginStatus: boolean;

  ngOnInit(): void {
    this.loginStatus = false;
  }

  constructor() { }

}
