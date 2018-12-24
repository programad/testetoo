import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { UsuarioComponent } from './usuario/usuario.component';
import { UsuarioService } from './services/usuarioservice.service';
import { UsuarioAdicionarEditarComponent } from './usuarioadicionareditar/usuarioadicionareditar.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    UsuarioComponent,
    UsuarioAdicionarEditarComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,  
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'usuario', component: UsuarioComponent },
      { path: 'usuario/adicionar', component: UsuarioAdicionarEditarComponent },
      { path: 'usuario/editar/:id', component: UsuarioAdicionarEditarComponent },
      { path: 'usuario/excluir/:id', component: UsuarioComponent },  
    ])
  ],
  providers: [UsuarioService],
  bootstrap: [AppComponent]
})
export class AppModule { }
