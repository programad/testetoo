import { Component, OnInit } from '@angular/core';
import { ArquivoService } from '../services/arquivo.service';
import { HttpEventType, HttpResponse } from '@angular/common/http';
import { OperationResultVo } from '../models/base';
import { Router } from '@angular/router';
import swal from 'sweetalert2';

@Component({
  selector: 'app-upload',
  templateUrl: './upload.component.html',
  styleUrls: ['./upload.component.css']
})
export class UploadComponent implements OnInit {
  arquivoSelecionado: File;

  public progress: number;
  public message: string;


  constructor(private _arquivoService: ArquivoService, private _router: Router) {
  }

  ngOnInit() {
  }

  onFileChanged(event) {
    var type = event.target.files[0].type;

    if (type === 'image/jpeg' || type === 'image/png') {
      this.arquivoSelecionado = event.target.files[0];
    }
    else {
      swal("Arquivo inválido!", "Selecione apenas imagens JPEG ou PNG", 'error');
    }
  }

  onUpload() {
    const uploadData = new FormData();
    uploadData.append('arquivo', this.arquivoSelecionado, this.arquivoSelecionado.name);

    this._arquivoService.upload(uploadData).subscribe(
      event => {
        if (event.type === HttpEventType.UploadProgress) {
          this.progress = Math.round(100 * event.loaded / event.total);
        }
        else if (event.type === HttpEventType.Response) {
          var result = event as HttpResponse<OperationResultVo<string>>;
          if (result.body.success === false) {
            this.message = result.body.message;
          }
          else {
            this.message = "Arquivo enviado com sucesso!";
            swal("Sucesso!", this.message, 'success');
            this._router.navigate(['/arquivo']);
          }
        }
      }
    );
  }
}
