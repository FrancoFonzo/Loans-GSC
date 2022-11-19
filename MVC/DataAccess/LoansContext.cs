using Microsoft.EntityFrameworkCore;
using System.Net;
using System;
using MVC.Entities;
using MVC.Dto;

namespace MVC.DataAccess
{
    public class LoansContext : DbContext
    {
        public LoansContext(DbContextOptions options): base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .Property(p => p.Name)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Person>()
                .Property(p => p.PhoneNumber)
                .HasMaxLength(20)
                .HasAnnotation("Phone", true)
                .IsRequired();

            modelBuilder.Entity<Person>()
                .Property(p => p.Email)
                .HasMaxLength(120)
                .HasAnnotation("EmailAddress", true);

            
            modelBuilder.Entity<Thing>()
                .Property(t => t.Description)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Thing>()
              .Property(t => t.CreationDate)
              .HasDefaultValueSql("CURRENT_TIMESTAMP");


            modelBuilder.Entity<Category>()
                .Property(c => c.Description)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Category>()
                .Property(c => c.CreationDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder.Entity<Category>()
                .HasIndex(c => c.Description)
                .IsUnique();

            //TODO: Unique constraint for thing description and person email/phone?

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Thing> Things { get; set; }
        public DbSet<Person> People { get; set; }
    }
}
