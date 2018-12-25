import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { ResponseContentType, ResponseType } from '@angular/http';
import { Observable } from 'rxjs';
import { ArquivoListItemViewModel, ArquivoViewModel } from '../models/arquivo.model';
import { OperationResultVo } from '../models/base';

@Injectable({
  providedIn: 'root'
})
export class ArquivoService {

  constructor(private http: HttpClient, @Inject('API_URL') private apiBaseUrl: string) {
  }


  public getAll() {
    return this.http.get<ArquivoListItemViewModel[]>(this.apiBaseUrl + 'api/arquivo')
      .catch(this.errorHandler);
  }

  public download(id, filename) {
    return this.http.get(this.apiBaseUrl + 'api/arquivo/' + id, {
      responseType: 'blob'
    })
      .map(res => {
        return new Blob([res])
      })
      .catch(this.errorHandler);
  }

  public upload(payload) {
    return this.http.post(this.apiBaseUrl + 'api/arquivo/', payload, {
      reportProgress: true,
      observe: 'events'
    })
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
