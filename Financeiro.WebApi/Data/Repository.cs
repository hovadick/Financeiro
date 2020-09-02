using EFCore.Financeiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Financeiro.WebApi.Data
{
    public class Repository : IRepository
    {

        private readonly FinanceiroContext _context;

        public Repository(FinanceiroContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

  

        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);
        }
    }
}
