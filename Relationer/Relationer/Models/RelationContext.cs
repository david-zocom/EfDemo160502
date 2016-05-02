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
        public DbSet<KontaktinfoModell> Kontaktinfo { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MedlemModel>()  //Medlem->Kontaktinfo
                .HasOptional(m => m.Kontaktinfo)
                .WithRequired(k => k.Medlem);

            /*modelBuilder.Entity<MedlemModel>()
                .HasOptional(m => m.Lag)
                .WithMany(l => l.Medlemmar);*/
            modelBuilder.Entity<LagModel>()  //Lag->Medlemmar
                .HasMany(l => l.Medlemmar)
                .WithOptional(m => m.Lag)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MatchModel>()  //Match->Lag1
                .HasRequired(m => m.Lag1)
                .WithMany()
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<MatchModel>()  //Match->Lag2
                .HasRequired(m => m.Lag2)
                .WithMany()
                .WillCascadeOnDelete(false);

            /*modelBuilder.Entity<MatchModel>()  //Match->Spelare, Medlem->SpeladeMatcher
                .HasMany(m => m.Spelare)
                .WithMany(mm=>mm.SpeladeMatcher);*/
            /*modelBuilder.Entity<MedlemModel>()  //Medlem->SpeladeMatcher
                .HasMany(m => m.SpeladeMatcher)
                .WithMany(mm => mm.Spelare);*/

            base.OnModelCreating(modelBuilder);
        }
    }
}
