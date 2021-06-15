using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularCrud.BDO
{
    public class DataContext:DbContext
    {
        public DbSet<Registration> Registration { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Roles>().ToTable("Role");
            modelBuilder.Entity<UserRoles>().ToTable("UserRole");
            modelBuilder.Entity<Country>().ToTable("Country");
            modelBuilder.Entity<State>().ToTable("State");
            modelBuilder.Entity<City>().ToTable("City");
        }
    }
}
