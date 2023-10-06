using System.Reflection;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

    namespace Persistence.Seed
    {
        public class EnrollAppContext : DbContext
        {
            public EnrollAppContext(DbContextOptions<EnrollAppContext> options) : base(options) { }
            public DbSet<Student>? Students { get; set; }
            public DbSet<Subject>? Subjects { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
                {
                    SubjectDbInitializer.Seed(modelBuilder);
                }
        }
    }
