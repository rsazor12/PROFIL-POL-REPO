import { Email } from './../shared/models/contact/email';
import { ContactService } from './../shared/services/contact.service';
import { Component, OnInit, ViewContainerRef } from '@angular/core';
import { ToastsManager } from 'ng2-toastr';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-kontakt',
  templateUrl: './kontakt.component.html',
  styleUrls: ['./kontakt.component.scss']
})
export class KontaktComponent implements OnInit {

  public contactForm: FormGroup;

  // public title = 'My first AGM project';
  public lat = 49.786218;
  public lng = 20.255336;

  constructor(
    private contactService: ContactService,
    private formBuilder: FormBuilder,
    public toastr: ToastsManager, vcr: ViewContainerRef,
  ) {
    this.toastr.setRootViewContainerRef(vcr);
  }

  ngOnInit() {
    this.contactForm = this.buildContactForm();
  }

  showSuccess() {
    this.toastr.success('Email wyslany pomyslnie', 'Sukces!');
  }

  showError() {
    this.toastr.error('Niestety nie udalo sie wyslac emaila, wybierz inny rodzaj kontaktu!', 'Bledne dane!');
  }

  buildContactForm(): any {
    return this.formBuilder.group({
      name: ['', [Validators.required]],
      email: ['', [Validators.required, Validators.email]],
      message: ['', [Validators.required]]
    });
  }

  public sendEmail() {
    const email: Email = {
      UserAddress: this.contactForm.get('email').value,
      UserName: this.contactForm.get('name').value,
      MessageContent: this.contactForm.get('message').value
    };

    this.contactService.sendEmail(email)
    .subscribe(
      resp => this.showSuccess(),
      error => this.showError()
    );
  }

}
