import { LoginService } from './login.service';
import { Injectable, OnInit } from '@angular/core';

@Injectable()
export class CommonPageService implements OnInit {

  ngOnInit(): void {
  }

  constructor(
    private loginService: LoginService
  ) { }

  getLoginService(): LoginService {
    return this.loginService;
  }

}
