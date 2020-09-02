import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule  } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { from } from 'rxjs';
import { CategoriaComponent } from './Categoria/Categoria.component';
import { ContaComponent } from './Conta/Conta.component';
import { NavComponent } from './nav/nav.component';
import { MovimentacaoComponent } from './movimentacao/movimentacao.component';

@NgModule({
  declarations: [		
    AppComponent,
      CategoriaComponent,
      ContaComponent,
      NavComponent,
      MovimentacaoComponent
   ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
