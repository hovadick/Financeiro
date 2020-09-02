import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { analyzeAndValidateNgModules } from '@angular/compiler';

@Component({
  selector: 'app-movimentacao',
  templateUrl: './movimentacao.component.html',
  styleUrls: ['./movimentacao.component.scss']
})
export class MovimentacaoComponent implements OnInit {

  movimentacao: any;
  endereco: any;

  constructor(private http: HttpClient) { }

  // tslint:disable-next-line: typedef
  ngOnInit() {
    this.getCategoria();
  }

  // tslint:disable-next-line: typedef
  getCategoria() {
    this.endereco = 'http://localhost:5000/api/Movimentacao/PorPessoaPorMes?dateIni=2020-08-01&dateFim=2020-08-01&idPessoa=1';

    this.http.get(this.endereco).subscribe( response =>
      {
        this.movimentacao = response;
      }
      , error => {
        console.log(error);
      });

  }

}
