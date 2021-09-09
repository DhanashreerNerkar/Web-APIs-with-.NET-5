using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using ASP.NET_Core_Application_1.Models;

namespace ASP.NET_Core_Application_1.DataAccess
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }

        public DbSet<PersonModel> person { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { base.OnModelCreating(modelBuilder); }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            return base.SaveChanges();
        }      
    }
}
