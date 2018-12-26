import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { UsuarioComponent } from './usuario/usuario.component';
import { UsuarioService } from './services/usuario.service';
import { UsuarioAdicionarEditarComponent } from './usuarioadicionareditar/usuarioadicionareditar.component';
import { UploadComponent } from './upload/upload.component';
import { ArquivoService } from './services/arquivo.service';
import { ArquivoComponent } from './arquivo/arquivo.component';

import { SweetAlert2Module } from '@toverux/ngx-sweetalert2';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    UsuarioComponent,
    UsuarioAdicionarEditarComponent,
    UploadComponent,
    ArquivoComponent
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
      { path: 'arquivo/upload', component: UploadComponent },
      { path: 'arquivo', component: ArquivoComponent },
      { path: 'arquivo/:id', component: ArquivoComponent },
    ]),
    SweetAlert2Module.forRoot({
      buttonsStyling: false,
      customClass: 'modal-content',
      confirmButtonClass: 'btn btn-primary',
      cancelButtonClass: 'btn'
    })
  ],
  providers: [UsuarioService, ArquivoService],
  bootstrap: [AppComponent]
})
export class AppModule { }
