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

    }
}
