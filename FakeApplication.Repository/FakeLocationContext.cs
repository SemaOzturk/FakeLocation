using FakeApplication.Repository.Entities;
using Microsoft.EntityFrameworkCore;

namespace FakeApplication.Repository
{
    public class FakeLocationContext : DbContext
    {
        public FakeLocationContext():base()
        {
            
        }
        public FakeLocationContext(DbContextOptions<FakeLocationContext> options):base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=FakeLocation;Integrated Security=true");
        }
        // x	y	z
        // 53	199	82
        // 143	199	37
        // 94	199	19
        // 53	199	82
        // 143	199	37
        // 94	199	19
        // 53	199	82
        // 143	199	37
        // 94	199	19
        // 73	199	43
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Anchors

            modelBuilder.Entity<AnchorRE>().HasData(
                new AnchorRE()
                {
                    Id = 512,
                    X = 8.535628,
                    Y = 27,
                    Z = 60.12051
                },
                new AnchorRE()
                {
                    Id = 513,
                    X = 8.535628,
                    Y = 27,
                    Z = 7.236729
                },
                new AnchorRE()
                {
                    Id = 514,
                    X = 34.88474,
                    Y = 27,
                    Z = 95.93304
                },
                new AnchorRE()
                {
                    Id = 515,
                    X = 99.45863,
                    Y = 27,
                    Z = 89.25299
                },
                new AnchorRE()
                {
                    Id = 516,
                    X = 144.9201,
                    Y = 27,
                    Z = 66.05834
                },
                new AnchorRE()
                {
                    Id = 517,
                    X = 160.3214,
                    Y = 27,
                    Z = 8.906743
                },
                new AnchorRE()
                {
                    Id = 518,
                    X = 96.86083,
                    Y = 27,
                    Z = 7.7934
                },
                new AnchorRE()
                {
                    Id = 519,
                    X = 55.8527,
                    Y = 27,
                    Z = 8.906743
                });

            #endregion

            #region Tag

            modelBuilder.Entity<TagRE>().HasData(
            
                new TagRE()
                {
                    Id = 42,
                    X = 53,
                    Y = 199,
                    Z = 82
                }
            );

        #endregion

        base.OnModelCreating(modelBuilder);
        }


        public DbSet<AnchorRE> Anchors { get; set; }
        public DbSet<TagRE> Tags { get; set; }
    }
}