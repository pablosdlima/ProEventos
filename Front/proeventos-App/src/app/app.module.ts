import { NgModule } from '@angular/core';
import { BrowserModule} from '@angular/platform-browser';
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component'; //importou a classe exportada no arquivo component.ts
import { EventosComponent } from './eventos/eventos.component';
import { PalestrantesComponent } from './palestrantes/palestrantes.component';
import { NavComponent } from './nav/nav.component';

import { CollapseModule } from 'ngx-bootstrap/collapse';

@NgModule({
  declarations: [	
    AppComponent, //modulos declarados. // modulo principal
    EventosComponent, //modulos declarados.
    PalestrantesComponent, //modulos declarados.
    NavComponent
   ],
  imports: [ //importações
    BrowserModule,
    AppRoutingModule,
    HttpClientModule, //importação para comunicação de APIS
    BrowserAnimationsModule,
    CollapseModule.forRoot(),
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
