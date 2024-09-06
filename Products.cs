using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proba10
{
    internal class Products
    {
        public string productName { set; get; }
        public List<Completings> completing { set; get; }


        public decimal GetPrice()
        {
            decimal result = 0;

            for (int i = 0; i < completing.Count; i++)
            {
                decimal res = completing[i].cost * completing[i].amount;
                result += res;
            }
            return result;
        }

        public string GetString()
        {
            List<string> strings = new List<string>();
            foreach (var list in completing)
            {
                strings.Add(list.name);
            }
            string String = string.Join("\n", strings);
            return String;
        }

    }
}
