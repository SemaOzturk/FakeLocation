using System.Collections.Generic;
using System.Linq;
using FakeApplication.Repository.Entities;
using Microsoft.EntityFrameworkCore;

namespace FakeApplication.Repository
{
    public abstract class BaseSqlRepository<T> : IRepository<T> where T: class, IRepositoryEntity
    {
        private readonly DbContext _context;
        private DbSet<T> Set => _context.Set<T>();

        protected BaseSqlRepository(DbContext context)
        {
            _context = context;
        }

        public virtual T Get(int id)
        {
            return Set.Find(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return Set;
        }
        public virtual IQueryable<T> GetAllQueryable()
        {
            return Set;
        }

        public virtual T Update(T entity)
        {
            DbSet<T> set = Set;
            T found = set.Find(entity.Id);
            if (found == null)
            {
                return null;
            }

            found = entity;
            _context.SaveChanges();
            return found;

        }

        public virtual T Insert(T entity)
        {
            var tracker = Set.Add(entity);
            _context.SaveChanges();
            return tracker.Entity;
        }

        public virtual T Upsert(T entity)
        {
            DbSet<T> set = Set;
            T found = set.Find(entity.Id);
            if (found == null)
            {
                var tracker = set.Add(entity);
                _context.SaveChanges();
                return tracker.Entity;
            }

            found = entity;
            _context.SaveChanges();
            return found;
        }

        public virtual bool Delete(int id)
        {
            var set = Set;
            set.Remove(set.Find(id));
            return _context.SaveChanges() > 0;
        }
    }
}