using BettingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BettingApp
{
    public class AvailableBet
    {
        public int ID { get; set; }
        public int MatchId { get; set; }
        public int AdministratorID { get; set; }
        public double TeamHWinMultiplier { get; set; }
        public double TeamAWinMultiplier { get; set; }
        public double DrawMultiplier { get; set; }
        
        public virtual Match Match { get; set; }
        public virtual Administrator Administrator { get; set; }

   
        public virtual ICollection<MatchOMInterim> MatchOtherMultiplierInterims { get; set; }
        public virtual IEnumerable<UserPlacedBet> UserPlacedBets { get; set; }
    }
}
