using Microsoft.EntityFrameworkCore;
using Natro_Backend.Core.Abstract;
using Natro_Backend.Entity.Context;
using Natro_Backend.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Natro_Backend.Core.Concrate
{
    public class Repository<T> : IRepository<T> where T : BaseEntity, new()
    {
        private readonly MssqlContext _context;
        public Repository(MssqlContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            T existing = _context.Set<T>().FirstOrDefault(x => x.ID == entity.ID);
            if (existing != null)
            {
                _context.Set<T>().Remove(existing);
                _context.SaveChanges();
            }
        }

        public IEnumerable<T> Get() => _context.Set<T>();

        public IEnumerable<T> Get(System.Linq.Expressions.Expression<Func<T, bool>> predicate) => _context.Set<T>().Where(predicate);

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.Set<T>().Attach(entity);
            _context.SaveChanges();
        }
    }
}
