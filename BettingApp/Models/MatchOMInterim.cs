using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BettingApp.Models
{
    public class MatchOMInterim
    {
        public int ID { get; set; }
        public int OtherMultiplierID { get; set; }
        public int AvailableBetID { get; set; }

        public virtual OtherMultiplier OtherMultiplier { get; set; }
        public virtual AvailableBet AvailableBet { get; set; }
    }
}