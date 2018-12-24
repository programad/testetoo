import { Component } from '@angular/core';
import { UsuarioService } from '../services/usuarioservice.service';
import { UsuarioViewModel } from '../models/usuario.model';

@Component({
  selector: 'app-usuario',
  templateUrl: './usuario.component.html'
})
export class UsuarioComponent {
  public usuarios: UsuarioViewModel[];

  constructor(private _usuarioService: UsuarioService) {
    this.getUsuarios();
  }

  getUsuarios() {
    this._usuarioService.getAll().subscribe(
      data => this.usuarios = data
    )
  }

  excluir(id) {
    var ans = confirm("Você quer mesmo excluir esse usuário?");
    if (ans) {
      this._usuarioService.remove(id).subscribe((data) => {
        this.getUsuarios();
      }, error => console.error(error))
    }
  }  
}
