import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UploadService {

  constructor(private http: HttpClient, @Inject('API_URL') private apiBaseUrl: string) {
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
