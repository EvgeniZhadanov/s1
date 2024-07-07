using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proba10
{
    internal class Completings
    {
        public Completings(string _name, decimal _amount, decimal _cost)
        {
        name = _name;   
            amount = _amount;
            cost = _cost;   
        }
        
        public string name { get; set; }
        public decimal amount {get; set;}
        public decimal cost {get; set;}

        string Name;
        decimal Amount;
        decimal Cost;
    }
}
