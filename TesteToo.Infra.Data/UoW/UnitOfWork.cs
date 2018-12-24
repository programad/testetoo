using System;
using System.Collections.Generic;
using System.Text;
using Testetoo.Domain.Interfaces;
using TesteToo.Infra.Data.Context;

namespace TesteToo.Infra.Data.UoW
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
