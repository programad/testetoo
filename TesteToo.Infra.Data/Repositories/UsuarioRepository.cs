using System;
using System.Collections.Generic;
using System.Text;
using Testetoo.Domain.Interfaces;
using Testetoo.Domain.Models;
using TesteToo.Infra.Data.Context;

namespace TesteToo.Infra.Data.Repositories
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(TestetooContext context) : base(context)
        {

        }
    }
}
