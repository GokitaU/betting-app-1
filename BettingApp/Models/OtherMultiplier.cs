using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BettingApp.Models
{
    public class OtherMultiplier
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public double Multiplier { get; set; }
        public virtual ICollection<MatchOMInterim> MatchOtherMultiplierInterims { get; set; }
        public virtual ICollection<UserPlacedBet> UserPlacedBets { get; set; }
    }
}