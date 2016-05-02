using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Relationer.Models
{
    public class RelationContext : DbContext
    {
        public RelationContext() : base("EfRelationsDemo")
        {

        }

        public DbSet<MedlemModel> Medlemmar { get; set; }
        public DbSet<LagModel> Lag { get; set; }
        public DbSet<MatchModel> Matcher { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MedlemModel>()
                .HasOptional(m => m.Lag)
                .WithMany(l => l.Medlemmar)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MatchModel>()
                .HasRequired(m => m.Lag1)
                .WithMany().WillCascadeOnDelete(false);
            modelBuilder.Entity<MatchModel>()
                .HasRequired(m => m.Lag2)
                .WithMany().WillCascadeOnDelete(false);

            modelBuilder.Entity<MatchModel>()
                .HasMany(m => m.Spelare)
                .WithMany(m => m.SpeladeMatcher);

            base.OnModelCreating(modelBuilder);
        }
    }
}
