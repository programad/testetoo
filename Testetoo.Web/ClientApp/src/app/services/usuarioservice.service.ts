import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { UsuarioViewModel, OperationResultVo } from '../models/usuario.model';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';


@Injectable()
export class UsuarioService {
  public usuarios: UsuarioViewModel[];

  constructor(private http: HttpClient, @Inject('API_URL') private apiBaseUrl: string) {
  }

  public getAll() {
    return this.http.get<UsuarioViewModel[]>(this.apiBaseUrl + 'api/usuario')
      .catch(this.errorHandler);
  }

  public get(id) {
    return this.http.get<OperationResultVo>(this.apiBaseUrl + 'api/usuario/' + id)
      .catch(this.errorHandler);
  }

  public add(payload) {
    return this.http.post(this.apiBaseUrl + 'api/usuario/', payload)
      .catch(this.errorHandler);
  }

  public remove(id) {
    return this.http.delete(this.apiBaseUrl + 'api/usuario/' + id)
      .catch(this.errorHandler);
  }

  public update(payload) {
    return this.http.put(this.apiBaseUrl + 'api/usuario/' + payload.id, payload)
      .catch(this.errorHandler);
  }

  errorHandler(response: HttpErrorResponse) {
    var erros = "";

    for (var property in response.error) {
      var msgs = (response.error[property])
      for (var i = 0; i < msgs.length; i++) {
        var msg = msgs[i];
        erros += msg + '\n';
      }
    }

    alert(erros); // TODO trocar pelo SweetAlert2

    return Observable.throw(response);
  }
}
