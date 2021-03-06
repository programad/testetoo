﻿using System;
using System.ComponentModel.DataAnnotations;
using Testetoo.Application.Attributes;

namespace Testetoo.Application.ViewModels.Usuario
{
    //Deverão ser exibidos os campos abaixo:
    //    - Nome
    //    - Data de nascimento
    //    - Usuário
    //    - Senha

    //    * Todos os campos são obrigatórios
    //    * A data de nascimento não pode ser uma data futura
    //    * A senha deverá conter ao menos 5 dígitos e ao menos um número e uma letra
    public class UsuarioViewModel : BaseViewModel
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{5,}$", ErrorMessage = "A senha deve conter ao menos 5 dígitos e ao menos um número e uma letra")]
        public string Senha { get; set; }

        [Required] // TODO validar data não pode ser futuro
        [FutureDate(ErrorMessage = "A data não pode ser uma data futura")]
        public DateTime DataNascimento { get; set; }
    }
}
