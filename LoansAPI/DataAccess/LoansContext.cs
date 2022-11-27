using Microsoft.EntityFrameworkCore;
using LoansAPI.Entities;

namespace LoansAPI.DataAccess
{
    public class LoansContext : DbContext
    {
        public LoansContext(DbContextOptions options) : base(options)
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
                .HasAnnotation("EmailAddress", true)
                .IsRequired();


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


            modelBuilder.Entity<Loan>()
                .Property(l => l.CreateDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
           

            modelBuilder.Entity<User>()
                .Property(u => u.Username)
                .HasAnnotation("MinLength", 4);

            modelBuilder.Entity<User>()
                .Property(u => u.Username)
                .HasMaxLength(32)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(u => u.Password)
                .HasAnnotation("MinLength", 4);

            modelBuilder.Entity<User>()
                .Property(u => u.Password)
                .HasMaxLength(128)
                .IsRequired();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();

            //TODO: Delete if implement azure sql
            modelBuilder.Entity<User>()
                .HasData(new User
                {
                    Id = 1,
                    Username = "admin",
                    Password = "admin",
                    Role = Role.Admin
                });

            modelBuilder.Entity<User>()
                .HasData(new User
                {
                    Id = 2,
                    Username = "francofonzo",
                    Password = "123456",
                    Role = Role.User
                });
        }

        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Loan> Loans { get; set; } = null!;
        public DbSet<Thing> Things { get; set; } = null!;
        public DbSet<Person> People { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
    }
}
