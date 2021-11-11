using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace PRS_Server.Models
{
    public class PRSDatabaseContext : DbContext
    {

        public PRSDatabaseContext(DbContextOptions<PRSDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Request> Requests { get; set; }
        public virtual DbSet<Requestline> Requestlines { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Vendor> Vendors { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(e =>
            {
                e.HasIndex(p => p.Username).IsUnique(true);
            });
            modelBuilder.Entity<Vendor>(e =>
            {
                e.HasIndex(p => p.Code).IsUnique(true);
            });
            modelBuilder.Entity<Product>(e =>
            {
                e.HasIndex(p => p.PartNbr).IsUnique(true);
            });
        }   
    }
}
