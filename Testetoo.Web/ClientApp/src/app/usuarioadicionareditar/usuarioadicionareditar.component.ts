import { Component, OnInit } from '@angular/core';
import { NgForm, FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';  
import { UsuarioService } from '../services/usuario.service';

@Component({
  selector: 'app-usuarioadicionareditar',
  templateUrl: './usuarioadicionareditar.component.html'
})
export class UsuarioAdicionarEditarComponent implements OnInit {
  usuarioForm: FormGroup;
  titulo: string = "Criar";
  usuarioId: string;
  errorMessage: any;

  constructor(private _fb: FormBuilder, private _router: Router, private _avRoute: ActivatedRoute, private _usuarioService: UsuarioService) {
    if (this._avRoute.snapshot.params["id"]) {
      this.usuarioId = this._avRoute.snapshot.params["id"];
    }
    this.usuarioForm = this._fb.group({
      id: '00000000-0000-0000-0000-000000000000',
      nome: ['', [Validators.required]],
      userName: ['', [Validators.required]],
      senha: ['', [Validators.required, Validators.pattern('([a-z|0-9]){5,}')]],
      dataNascimento: ['', [Validators.required]]
    })  
  }

  ngOnInit(): void {
    if (this.usuarioId !== undefined && this.usuarioId !== '00000000-0000-0000-0000-000000000000') {
      this.titulo = "Editar";
      this._usuarioService.get(this.usuarioId)
        .subscribe(resp => this.usuarioForm.setValue(resp.value)
          , error => this.errorMessage = error);
    }  
  }

  salvarUsuario() {
    if (!this.usuarioForm.valid) {
      return;
    }

    if (this.titulo == "Criar") {
      this._usuarioService.add(this.usuarioForm.value)
        .subscribe((data) => {
          this._router.navigate(['/usuario']);
        }, error => this.errorMessage = error)
    }
    else if (this.titulo == "Editar") {
      this._usuarioService.update(this.usuarioForm.value)
        .subscribe((data) => {
          this._router.navigate(['/usuario']);
        }, error => this.errorMessage = error)
    }
  }

  cancel() {
    this._router.navigate(['/usuario']);
  }

}
