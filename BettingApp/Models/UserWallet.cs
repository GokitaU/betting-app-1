﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BettingApp
{
    public class UserWallet
    {
        public int ID { get; set; }
        public decimal Amount { get; set; }
        public int UserID { get; set; }

        public virtual User User { get; set; }

  
    }
}
