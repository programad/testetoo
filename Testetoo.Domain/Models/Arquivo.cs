using System;
using System.Collections.Generic;
using System.Text;
using Testetoo.Domain.Core.Models;

namespace Testetoo.Domain.Models
{
    public class Arquivo : Entity
    {
        public Guid? IdUsuario { get; set; }

        public string Nome { get; set; }

        public byte[] Bytes { get; set; }

        public Usuario Usuario { get; set; }
    }
}
