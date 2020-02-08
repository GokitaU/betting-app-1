using BettingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BettingApp
{
    public class User
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime DateBirth { get; set; }

        public virtual IEnumerable<UserPlacedBet> UserPlacedBets { get; set; }

    }


}
