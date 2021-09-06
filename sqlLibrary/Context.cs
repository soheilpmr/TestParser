using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sqlLibrary
{
    public class Context : DbContext
    {
        //private static string Connectionstring = "Server=.;Database=TestResult;User ID=sa;Password=123456";
            public Context() : base("name=TestResultContext")
            {
                
            }
       
            public DbSet<TestTime> TestTimes { get; set; }
            public DbSet<TestKind> TestKinds { get; set; }
            public DbSet<TestDetail> TestDetails { get; set; }
            public DbSet<TestDetailOfEveryTest> TestDetailOfEveryTests { get; set; }
            public DbSet<FiveShowestTest> FiveShowestTests { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder
        //            .UseSqlServer(_configuration.GetConnectionString("Server =.; Database = TestResult; User ID = sa; Password = 123456"));
        //            //.UseLazyLoadingProxies();
        //    }
        //}

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    //modelBuilder.HasAnnotation("ProductVersion", "2.2.1-servicing-10028");

        //    modelBuilder.Entity<TestTime>(entity =>
        //    {
        //        entity.Property(e => e.Date).HasDefaultValue(DateTime.Now);
        //    });

        //    modelBuilder.Entity<TestKind>(entity =>
        //    {
        //        entity.HasOne(d => d.TestTime)
        //            .WithMany(p => p.TestKind)
        //            .HasForeignKey(d => d.IdTime)
        //            .HasConstraintName("FK__TestTime__Id__");
        //    });
        //}
    }
}
