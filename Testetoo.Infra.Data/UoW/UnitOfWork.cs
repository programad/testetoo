using System;
using System.Collections.Generic;
using System.Text;
using Testetoo.Domain.Interfaces;
using Testetoo.Infra.Data.Context;

namespace Testetoo.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TestetooContext _context;

        public UnitOfWork(TestetooContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
