using System;
using System.Collections.Generic;
using System.Text;
using Testetoo.Domain.Interfaces;
using Testetoo.Domain.Models;
using Testetoo.Infra.Data.Context;

namespace Testetoo.Infra.Data.Repositories
{
    public class ArquivoRepository : Repository<Arquivo>, IArquivoRepository
    {
        public ArquivoRepository(TestetooContext context) : base(context)
        {

        }
    }
}
