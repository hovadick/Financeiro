import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  // tslint:disable-next-line: component-selector
  selector: 'app-Categoria',
  templateUrl: './Categoria.component.html',
  styleUrls: ['./Categoria.component.css']
})
export class CategoriaComponent implements OnInit {

  categoria: any;

  constructor(private http: HttpClient) { }

  // tslint:disable-next-line: typedef
  ngOnInit() {
    this.getCategoria();
  }

  // tslint:disable-next-line: typedef
  getCategoria() {
    this.http.get('http://localhost:5000/api/Categoria/PorPessoa/?Pessoaid=1').subscribe( response =>
      {
        this.categoria = response;
      }
      , error => {
        console.log(error);
      });

  }

}
