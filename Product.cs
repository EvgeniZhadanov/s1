using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proba10
{
    internal class Product
    {

        public string ProductName { set; get; }
                public List<Component> components{ set; get; }


                public decimal GetPrice()
        {
            decimal result = 0;

            foreach (var component in components)
            {
                result += component.ComponentCount * component.ComponentPrice;

            }
            return result;
        }
    }
}
