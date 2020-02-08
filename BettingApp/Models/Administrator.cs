using BettingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BettingApp
{
    public  class Administrator
    {
        public int ID { get; set; }
        public string AdminName { get; set; }

        public string AdminPassword { get; set; }
        
        public virtual ICollection<AdminCashDesk> AdminCashDesks { get; set; }

        public virtual ICollection<AvailableBet> AvailableBet { get; set; }
    }

}