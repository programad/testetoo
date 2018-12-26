import { Component } from '@angular/core';
import { UsuarioService } from '../services/usuario.service';
import { UsuarioViewModel } from '../models/usuario.model';
import swal from 'sweetalert2';

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
    swal("Tem certeza?", "Você quer mesmo excluir esse usuário?", 'question')
      .then((resposta) => {
        if (resposta.value) {
          this._usuarioService.remove(id).subscribe((data) => {
            swal("Sucesso!", "Usuário excluído com sucesso!", 'success');
            this.getUsuarios();
          }, error => console.error(error))
        }
      })
  }
}
