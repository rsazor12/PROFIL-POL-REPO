import { AdminPanelComponent } from './admin-panel/admin-panel.component';
import { ProductionStatusComponent } from './production-status/production-status.component';
import { LoginComponent } from './forms/login/login.component';
import { KontaktComponent } from './kontakt/kontakt.component';
import { StartComponent } from './start/start.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { OfertaComponent } from './oferta/oferta.component';
import { GaleriaComponent } from './galeria/galeria.component';
import { PoradnikComponent } from './poradnik/poradnik.component';
import { ItemDetailsComponent } from './item-details/item-details.component';

const routes: Routes = [
  { path: '', pathMatch: 'full', redirectTo: 'start' },
  { path: 'start', component:  StartComponent}, // StartComponent
  { path: 'oferta', component: OfertaComponent },
  { path: 'kontakt', component: KontaktComponent },
  { path: 'poradnik', component: PoradnikComponent },
  { path: 'galeria', component: GaleriaComponent },
  // tslint:disable-next-line:max-line-length
  // { path: 'item-details/:idOffer/:imagePath/:name/:available/:longDescription/:price/:availableSizes/:availableDoors/:availableSheets', component: ItemDetailsComponent},
  { path: 'item-details/:idOffer', component: ItemDetailsComponent},
  { path: 'login', component: LoginComponent },
  { path: 'production-status', component: ProductionStatusComponent },
  { path: 'admin-panel', component: AdminPanelComponent }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
