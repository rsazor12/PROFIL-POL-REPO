import { ContactService } from './shared/services/contact.service';
import { OfferService } from './shared/services/offer.service';
import { UserService } from './shared/services/user.service';
import { LoginService } from './shared/services/login.service';
import { ItemDetailsService } from './shared/services/item-details.service';
import { OrdersService } from './shared/services/orders.service';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule, ApplicationRef } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { CarouselModule } from 'ngx-bootstrap';
import { SliderComponent } from './start/slider/slider.component';
import { JumbotronComponent } from './start/jumbotron/jumbotron.component';
import { NavbarComponent } from './shared/navbar/navbar.component';
import { StartPageInformerComponent } from './start/start-page-informer/start-page-informer.component';
import { AngularFontAwesomeModule } from 'angular-font-awesome';
import { OfertaComponent } from './oferta/oferta.component';
import { KontaktComponent } from './kontakt/kontakt.component';
import { GaleriaComponent } from './galeria/galeria.component';
import { StartComponent } from './start/start.component';
import { PoradnikComponent } from './poradnik/poradnik.component';
import { GarageCardComponent } from './oferta/garage-card/garage-card.component';
import { FooterComponent } from './shared/footer/footer.component';

import { ScrollToModule } from 'ng2-scroll-to-el';
import { AgmCoreModule } from '@agm/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { GarageCustomComponent } from './shared/garage-custom/garage-custom.component';
import { LoginComponent } from './forms/login/login.component';
import { ProductionStatusComponent } from './production-status/production-status.component';
import { CommonPageService } from './shared/services/common-page.service';
import { ItemDetailsComponent } from './item-details/item-details.component';
import { SheetColorComponent } from './shared/sheet-color/sheet-color.component';
import { HttpClientModule } from '@angular/common/http';
import {ToastModule} from 'ng2-toastr/ng2-toastr';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import { RoutingHistoryService } from './shared/services/routing-history.service';

// TO GALERY
import 'hammerjs';
import 'mousetrap';
import { ModalGalleryModule } from 'angular-modal-gallery';
import { GarageSizeComponent } from './shared/garage-size/garage-size.component';
import { AdminPanelComponent } from './admin-panel/admin-panel.component';

@NgModule({
  declarations: [
    AppComponent,
    SliderComponent,
    JumbotronComponent,
    NavbarComponent,
    StartPageInformerComponent,
    OfertaComponent,
    KontaktComponent,
    GaleriaComponent,
    StartComponent,
    PoradnikComponent,
    GarageCardComponent,
    FooterComponent,
    GarageCustomComponent,
    LoginComponent,
    ProductionStatusComponent,
    ItemDetailsComponent,
    SheetColorComponent,
    GarageSizeComponent,
    AdminPanelComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    CommonModule,
    FormsModule,
    // BsDropdownModule.forRoot(),
    CarouselModule,
    AgmCoreModule.forRoot({
      apiKey: 'AIzaSyBKG9Bm93qO_Pb6B1qjSz2MhbdTX1EN3j8'
    }),
    ScrollToModule.forRoot(),
    AngularFontAwesomeModule,
    ReactiveFormsModule,
    HttpClientModule,
    ToastModule.forRoot(),
    ModalGalleryModule.forRoot()
  ],
  providers: [
    CommonPageService,
    OrdersService,
    ItemDetailsService,
    LoginService,
    RoutingHistoryService,
    UserService,
    OfferService,
    ContactService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
