import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component'; //importou a classe exportada no arquivo component.ts
import { EventosComponent } from './eventos/eventos.component';
import { PalestrantesComponent } from './palestrantes/palestrantes.component';

@NgModule({
  declarations: [
    AppComponent, //modulos declarados. // modulo principal
    EventosComponent, //modulos declarados.
    PalestrantesComponent //modulos declarados.
  ],
  imports: [ //importações
    BrowserModule,
    AppRoutingModule,
    HttpClientModule, //importação para comunicação de APIS
    //BrowserAnimationsModule vai precisar
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
