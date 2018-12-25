import { Component, OnInit } from '@angular/core';
import { UploadService } from '../services/upload.service';
import { HttpEventType } from '@angular/common/http';

@Component({
  selector: 'app-upload',
  templateUrl: './upload.component.html',
  styleUrls: ['./upload.component.css']
})
export class UploadComponent implements OnInit {
  arquivoSelecionado: File;

  public progress: number;
  public message: string;


  constructor(private _uploadService: UploadService) {
  }

  ngOnInit() {
  }

  onFileChanged(event) {
    this.arquivoSelecionado = event.target.files[0]
  }

  onUpload() {
    const uploadData = new FormData();
    uploadData.append('arquivo', this.arquivoSelecionado, this.arquivoSelecionado.name);

    this._uploadService.upload(uploadData).subscribe(
      event => {
        if (event.type === HttpEventType.UploadProgress) {
          this.progress = Math.round(100 * event.loaded / event.total);
        }
        else if (event.type === HttpEventType.Response) {
          if (event.success === false) {
            this.message = event.message;
          }
          else {
            this.message = "Arquivo enviado com sucesso!";
          }
        }
      }
    );
  }
}
