using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relationer.Models
{
    [Table("Medlemmar")]
    public class MedlemModel
    {
        public int Id { get; set; }
        public string Namn { get; set; }

        // En medlem kan vara med i 0-1 lag
        public virtual LagModel Lag { get; set; }
        public virtual IList<MatchModel> SpeladeMatcher { get; set; }
    }
}
