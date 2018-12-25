import { Component, OnInit } from '@angular/core';
import { ArquivoService } from '../services/arquivo.service';
import { HttpEventType, HttpResponse } from '@angular/common/http';
import { OperationResultVo } from '../models/base';

@Component({
  selector: 'app-upload',
  templateUrl: './upload.component.html',
  styleUrls: ['./upload.component.css']
})
export class UploadComponent implements OnInit {
  arquivoSelecionado: File;

  public progress: number;
  public message: string;


  constructor(private _arquivoService: ArquivoService) {
  }

  ngOnInit() {
  }

  onFileChanged(event) {
    this.arquivoSelecionado = event.target.files[0]
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
          }
        }
      }
    );
  }
}
