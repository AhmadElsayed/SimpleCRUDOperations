using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TaskResolution.Models
{
    public class Context : DbContext
    {
        public Context() : base()
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                        .HasMany(r => r.Subjects)
                        .WithMany()
                        .Map(m =>
                        {
                            m.MapLeftKey("StudentID");
                            m.MapRightKey("SubjectID");
                            m.ToTable("StudentSubjects");
                        });
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
    }
}