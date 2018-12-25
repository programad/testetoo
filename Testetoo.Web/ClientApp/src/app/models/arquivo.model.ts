
export interface ArquivoListItemViewModel {
  id: string;
  nome: string;
}

export interface ArquivoViewModel {
  id: string;
  nome: string;
  idUsuario: string;
  bytes: Blob;
}
