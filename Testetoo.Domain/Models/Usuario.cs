using System;
using Testetoo.Domain.Core;
using Testetoo.Domain.Core.Models;

namespace Testetoo.Domain.Models
{
    public class Usuario : Entity
    {
        public string Nome { get; set; }

        public string UserName { get; set; }

        public string Senha { get; set; }

        public DateTime DataNascimento { get; set; }
    }
}
