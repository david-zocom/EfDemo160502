using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relationer.Models
{
    [Table("Matcher")]
    public class MatchModel
    {
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }

        //[Required]
        public virtual LagModel Lag1 { get; set; }
        //[Required]
        public virtual LagModel Lag2 { get; set; }
        [Required]
        public virtual IList<MedlemModel> Spelare { get; set; }

        [Required]
        public int AntalMålLag1 { get; set; }
        [Required]
        public int AntalMålLag2 { get; set; }

    }
}
