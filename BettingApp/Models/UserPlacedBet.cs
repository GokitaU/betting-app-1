using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BettingApp.Models
{
    public class UserPlacedBet
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int AvailableBetID { get; set; }
        public decimal Amount { get; set; }
        public FinalResult ResultBetByUser { get; set; }
        public virtual User User { get; set; }
        public virtual AvailableBet AvailableBet { get; set; }
        public virtual ICollection<OtherMultiplier> OtherMultipliers { get; set; }
        
    }
}