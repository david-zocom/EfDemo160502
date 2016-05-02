using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace RelationerDemo2.Models
{
    class SchoolContext:DbContext
    {
        public SchoolContext() : base() { }

        public DbSet<StudentModel> Students { get; set; }
        public DbSet<CourseModel> Courses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentModel>()
                .HasOptional(s => s.Course)
                .WithMany(c => c.Students);

            //base.OnModelCreating(modelBuilder);
        }
    }
}
