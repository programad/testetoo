using System;

namespace Testetoo.Application.ViewModels.Arquivo
{
    public class ArquivoViewModel : BaseViewModel
    {
        public Guid? IdUsuario { get; set; }

        public string Nome { get; set; }

        public byte[] Bytes { get; set; }
    }
}
