import { Component, OnInit } from '@angular/core';
import { ArquivoService } from '../services/arquivo.service';
import { ArquivoListItemViewModel } from '../models/arquivo.model';
import { saveAs } from 'file-saver';

@Component({
  selector: 'app-arquivo',
  templateUrl: './arquivo.component.html',
  styleUrls: ['./arquivo.component.css']
})
export class ArquivoComponent implements OnInit {
  public arquivos: ArquivoListItemViewModel[];

  constructor(private _arquivoService: ArquivoService) {
    this.getArquivos();
  }

  ngOnInit() {
  }


  getArquivos() {
    this._arquivoService.getAll().subscribe(
      data => this.arquivos = data
    );
  }

  downloaFile(id, filename) {
    this._arquivoService.download(id, filename).subscribe(
      bytes => {
        saveAs(bytes, filename);
      }
    );
  }
}
