using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relationer.Models
{
    [Table("Lag")]
    public class LagModel
    {
        //public enum SportTyp { Fotboll, Biljard, CounterStrike }

        public int Id { get; set; }
        public string Namn { get; set; }
        //public SportTyp Sport { get; set; }

        // Ett lag kan ha flera medlemmar
        public virtual IList<MedlemModel> Medlemmar { get; set; }
    }
}
