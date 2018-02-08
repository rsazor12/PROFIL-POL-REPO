import { KontaktComponent } from './kontakt/kontakt.component';
import { StartComponent } from './start/start.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { OfertaComponent } from './oferta/oferta.component';
import { GaleriaComponent } from './galeria/galeria.component';
import { PoradnikComponent } from './poradnik/poradnik.component';

const routes: Routes = [
  { path: '', pathMatch: 'full', redirectTo: 'start' },
  { path: 'start', component: StartComponent },
  { path: 'oferta', component: OfertaComponent },
  { path: 'kontakt', component: KontaktComponent },
  { path: 'poradnik', component: PoradnikComponent },
  { path: 'galeria', component: GaleriaComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
