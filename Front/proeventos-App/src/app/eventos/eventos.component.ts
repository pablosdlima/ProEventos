import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos', //declaração de seletor para chamar no modulo principal.
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {
  public eventos: any; // art declarado.

  constructor(private http: HttpClient) { } //construtor recebe como parametro uma var chamada http que recebe Httpclient

  ngOnInit(): void {
    this.getEventos();
  }

  public getEventos(): void { //metodo em angular.
    this.http.get('https://localhost:5001/api/eventos').subscribe(
      response => this.eventos = response,
      error => console.log(error)
    );
  }
}
