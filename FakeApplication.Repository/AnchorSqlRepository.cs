using System.Collections.Generic;
using FakeApplication.Repository.Entities;
using FakeApplication.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FakeApplication.Repository
{
    public class AnchorSqlRepository : IAnchorRepository
    {
        private readonly DbContext _context;
        private DbSet<AnchorRE> Set => _context.Set<AnchorRE>();

        public AnchorSqlRepository(DbContext context)
        {
            _context = context;
        }

        public AnchorRE Get(int id)
        {
            return Set.Find(id);
        }

        public IEnumerable<AnchorRE> GetAll()
        {
            return Set;
        }

        public AnchorRE Update(AnchorRE entity)
        {
            DbSet<AnchorRE> set = Set;
            AnchorRE found = set.Find(entity.Id);
            if (found == null)
            {
                return null;
            }

            found = entity;
            _context.SaveChanges();
            return found;

        }

        public AnchorRE Insert(AnchorRE entity)
        {
            var tracker = Set.Add(entity);
            _context.SaveChanges();
            return tracker.Entity;
        }

        public AnchorRE Upsert(AnchorRE entity)
        {
            DbSet<AnchorRE> set = Set;
            AnchorRE found = set.Find(entity.Id);
            if (found == null)
            {
                var tracker = set.Add(entity);
                return tracker.Entity;
            }

            found = entity;
            _context.SaveChanges();
            return found;
        }

        public bool Delete(int id)
        {
            var set = Set;
            set.Remove(set.Find(id));
            return _context.SaveChanges() > 0;
        }
    }
}