using System;
using System.Data.Entity;
using Common.Data.Interfaces;
using PropznetCommon.Features.CRM.Interfaces.Data;
using CRMLite.Core.Interfaces.Data;

namespace CRMLite.UI
{
    public class UnitOfWork : IUnitOfWork
    {
        DbContext _context;
        public UnitOfWork(IDataContext context)
        {
            _context = (DbContext)context;
        }
        public int Commit()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }
    }
}