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

import { AgmCoreModule } from '@agm/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { GarageCustomComponent } from './shared/garage-custom/garage-custom.component';
import { LoginComponent } from './forms/login/login.component';
import { ProductionStatusComponent } from './production-status/production-status.component';
import { CommonPageService } from './shared/services/common-page.service';

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
    ProductionStatusComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    CommonModule,
    FormsModule,
    // BsDropdownModule.forRoot(),
    CarouselModule,
    AgmCoreModule.forRoot({
      apiKey: 'AIzaSyBKG9Bm93qO_Pb6B1qjSz2MhbdTX1EN3j8'
    }),
    AngularFontAwesomeModule
  ],
  providers: [
    CommonPageService,
    OrdersService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
