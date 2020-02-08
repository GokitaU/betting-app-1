using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BettingApp
{
    public class Team
    {
        public int ID { get; set; }
        public int LegaueID { get; set; }
        public int Name { get; set; }
        public decimal InitialSummerBudjet { get; set; }
        public decimal AveContractPerPLayer { get; set; }
        public virtual League League { get; set;}
        public virtual ICollection<Match> HomeMatches { get; set; }
        public virtual ICollection<Match> AwayMatches { get; set; }

    }
}
