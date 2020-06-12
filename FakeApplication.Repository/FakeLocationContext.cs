using FakeApplication.Repository.Entities;
using Microsoft.EntityFrameworkCore;

namespace FakeApplication.Repository
{
    public class FakeLocationContext : DbContext
    {
        public FakeLocationContext(DbContextOptions<FakeLocationContext> options):base(options)
        {
            
        }

        public DbSet<AnchorRE> Anchors { get; set; }
        
    }
}