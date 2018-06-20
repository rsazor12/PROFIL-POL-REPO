import { Email } from './../../shared/models/contact/email';
import { LoginService } from './../../shared/services/login.service';
import { Credentials } from './../../shared/models/login/credentials';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { Input, Output, EventEmitter } from '@angular/core';


@Component({
  selector: 'app-credentials-form',
  templateUrl: './credentials-form.component.html',
  styleUrls: ['./credentials-form.component.scss']
})
export class CredentialsFormComponent implements OnInit {

  public credentialsForm: FormGroup;
  public credentialFormStatus: boolean;

  @Output() credentialsOK = new EventEmitter<boolean>();
  @Output() credentials = new EventEmitter<Credentials>();


  constructor(
    private formBuilder: FormBuilder,
    private loginService: LoginService
  ) { }

  ngOnInit() {
    this.credentialsForm = this.buildCredentialsForm();
    this.credentialsOK.emit(false);
    this.credentialFormStatus = true;
  }

  checkEmailAndPassword() {

    // only if two inputs are dirty do user check
      if (this.credentialsForm.get('email').dirty && this.credentialsForm.get('password').dirty)  {

        const credentials: Credentials = {
          Email: this.credentialsForm.get('email').value,
          Password: this.credentialsForm.get('password').value };

    this.loginService.checkUserCredentialsForOrderForm(credentials)
        .subscribe(
          res => {
            this.credentialsOK.emit(true);

            this.credentials.emit({
              Email: this.credentialsForm.get('email').value,
              Password: this.credentialsForm.get('password').value
            });

            this.credentialFormStatus = true;
          },
          error => {
            this.credentialsOK.emit(false);
            this.credentialFormStatus = false;
          });
      }
  }

  getCredentialFormStatusByResponseAndValidation(response: boolean) {
    return response && this.credentialsForm.valid;
  }

  buildCredentialsForm() {
    return this.formBuilder.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required]]
    });
}

}
