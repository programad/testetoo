export interface UsuarioViewModel {
  nome: string;
  userName: number;
  dataNascimento: Date;
  senha: string
}


export class OperationResultVo {
  success: boolean;
  message: string;
  value: object;
}
