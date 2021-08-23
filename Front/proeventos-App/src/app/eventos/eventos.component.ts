import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos', //declaração de seletor para chamar no modulo principal.
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {
  public eventos: any = []; // art declarado. Que quando chamado ao component, será pelo nome
            //any possui elementos = any é um array
            // isso permite que eventos possa vir vazio
  public eventosFiltrados: any = [];

  widthImg: number = 150;    // larguraImagem
  marginImg: number = 2;     // margemImagem
  mostrarImagem: boolean = true;
  private _filtroLista: string = '';   

  public get filtroLista() : string{ //retorno da prop privada
      return this._filtroLista;
  }

  public set filtroLista(value: string){ //retorno da prop privada
      this._filtroLista = value;
      this.eventosFiltrados = this.filtroLista ? this.filtrarEventos(this.filtroLista) : this.eventos;
  }

  filtrarEventos(filtrarPor: string) : any {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.eventos.filter(
        (evento: { tema: string; local: string }) => evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
       evento.local.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    );
  }

  constructor(private http: HttpClient) { } //construtor recebe como parametro uma var chamada http que recebe Httpclient

  ngOnInit(): void {
    this.getEventos();
  }

  alterarImagem(){
    this.mostrarImagem = !this.mostrarImagem;
  }

  public getEventos(): void { //metodo em angular.
    this.http.get('https://localhost:5001/api/eventos').subscribe( //pega dados da API controller / sql
      response => this.eventos = response, // atr eventos recebe resposta da API acima.
      error => console.log(error) //em caso de erro.
    );
  }
}
