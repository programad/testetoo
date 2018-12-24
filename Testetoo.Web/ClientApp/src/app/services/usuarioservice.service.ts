import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UsuarioViewModel, OperationResultVo } from '../models/usuario.model';


@Injectable()
export class UsuarioService {
  public usuarios: UsuarioViewModel[];

  constructor(private http: HttpClient, @Inject('API_URL') private apiBaseUrl: string) {
  }

  public getAll() {
    return this.http.get<UsuarioViewModel[]>(this.apiBaseUrl + 'api/usuario');
  }

  public get(id) {
    var operationResponse = this.http.get<OperationResultVo>(this.apiBaseUrl + 'api/usuario/' + id);

    return operationResponse;
  }

  public add(payload) {
    return this.http.post(this.apiBaseUrl + 'api/usuario/', payload);
  }

  public remove(id) {
    return this.http.delete(this.apiBaseUrl + 'api/usuario/' + id);
  }

  public update(payload) {
    return this.http.put(this.apiBaseUrl + 'api/usuario/' + payload.id, payload);
  }
}
