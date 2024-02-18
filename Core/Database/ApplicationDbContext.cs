using Microsoft.EntityFrameworkCore;
using piqe.Models;

namespace piqe.Core
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "server=localhost;database=piqe;user=root;password=Piqe2024!@#;";
            optionsBuilder.UseMySQL(connectionString);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Attendence> Attendences { get; set; }

        // protected override void OnModelCreating(ModelBuilder builder)
        // {
        //     base.OnModelCreating(builder);

        //     builder.Entity<User>(entity =>
        //     {
        //         entity.HasKey(e => e.Key);
        //     });

        //     builder.Entity<Student>(entity =>
        //     {
        //         entity.HasKey(e => e.Key);
        //     });

        //     builder.Entity<Teacher>(entity =>
        //     {
        //         entity.HasKey(e => e.Key);
        //     });

        //     builder.Entity<Grade>(entity =>
        //     {
        //         entity.HasKey(e => e.Key);
        //     });

        //     builder.Entity<Attendence>(entity =>
        //     {
        //         entity.HasKey(e => e.Key);
        //     });
        // }
    }
}