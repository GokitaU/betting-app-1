using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BettingApp.Models
{
    public class AdminCashDesk
    {

        public int ID { get; set; }
        public decimal Amount { get; set; }
        public int AdminID { get; set; }
        
        public virtual Administrator Administrator { get; set; }
 
    }
}