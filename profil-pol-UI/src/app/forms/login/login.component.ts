import { UserService } from './../../shared/services/user.service';
import { RoutingHistoryService } from './../../shared/services/routing-history.service';
import { ErrorObservable } from 'rxjs/observable/ErrorObservable';
import { LoginService } from './../../shared/services/login.service';
import { Router } from '@angular/router';
import { Component, OnInit, ViewContainerRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HttpErrorResponse } from '@angular/common/http';
import { catchError, retry } from 'rxjs/operators';
import { ToastsManager } from 'ng2-toastr/src/toast-manager';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  public loginForm: FormGroup;


  constructor(
    private router: Router,
    private formBuilder: FormBuilder,
    private loginService: LoginService,
    public toastr: ToastsManager, vcr: ViewContainerRef,
    private routingHistoryService: RoutingHistoryService,
    private userService: UserService) {
      this.toastr.setRootViewContainerRef(vcr);
     }

  ngOnInit() {
    this.loginForm = this.buildLoginForm();
  }

  // showSuccess() {
  //   this.toastr.success('You are awesome!', 'Success!');
  // }

  showError() {
    this.toastr.error('Uzytkownik o pdanych danych nie istnieje, sprobuj ponownie!', 'Bledne dane!');
  }

  // showWarning() {
  //   this.toastr.warning('You are being warned.', 'Alert!');
  // }

  // showInfo() {
  //   this.toastr.info('Just some information for you.');
  // }

  // showCustom() {
  //   this.toastr.custom('<span style="color: red">Message in red.</span>', null, {enableHTML: true});
  // }

  getLoginService(): LoginService {
    return this.loginService;
  }

  gotoProductionStatusPage() {
    this.router.navigate(['production-status']);
  }

  gotoFrogetPasswordPage() {
    this.router.navigate(['forget-password']);
  }

  gotoStartPage() {
    this.router.navigate(['start']);
  }

  buildLoginForm() {
    return this.formBuilder.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required]]
    });
  }


  public login() {
    // IF admin
    if (this.loginForm.get('email').value === 'admin@mail' && this.loginForm.get('password').value === 'superhaslo123') {
      this.router.navigate(['admin-panel']);
    } else {
      // IF normal user
      this.loginService.login(this.loginForm.get('email').value, this.loginForm.get('password').value)
      .pipe(catchError(this.handleError))
      .subscribe(
        token => {
          localStorage.setItem('auth_token', token);
          this.loginService.isLogedIn = true;
          this.userService.getUserDetailsByEmail(this.loginForm.get('email').value);
          // TODO obszywka
          if (this.routingHistoryService.getPreviousUrl() === 'admin-panel') {
            this.router.navigate(['production-status']);
          } else {
            this.router.navigate([this.routingHistoryService.getPreviousUrl()]);
          }

      },
      error => {
        this.showError();
      }
    );
    }
}

logout() {
  this.toastr.info('Poprawnie wylogowano z platformy!');
}

  private handleError(error: HttpErrorResponse) {

    if (error.error instanceof ErrorEvent) {
      // A client-side or network error occurred. Handle it accordingly.
      console.error('An error occurred:', error.error.message);
    } else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong,
      console.error(
        `Backend returned code ${error.status}, ` +
        `body was: ${error.error}`);
    }
    // return an ErrorObservable with a user-facing error message
    return new ErrorObservable(
      'Something bad happened; please try again later.');
  }

}
