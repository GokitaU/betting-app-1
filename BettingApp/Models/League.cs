using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BettingApp
{
    public class League
    {
        public int ID { get; set; }
        public string Country { get; set; }
        public string LeagueName { get; set; }

        public virtual ICollection<Team> Teams { get; set; }

    }
}
