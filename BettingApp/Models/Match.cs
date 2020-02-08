using BettingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BettingApp
{
    public class Match
    {
        public int ID { get; set; }
        public int TeamHId { get; set; }
        public int TeamAId { get; set; }
        public FinalResult FinalResult { get; set; }
        public string OtherResult { get; set; }
        public DateTime MatchStartDateTime { get; set; }
        public bool MatchIsOver { get; set; }
        public virtual Team TeamH { get; set; }
        public virtual Team TeamA { get; set; }

        
  
    }
}
