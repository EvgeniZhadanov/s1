using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Proba10
{
    internal class Product
    {

        public string ProductName { set; get; }
        public List<Component> components = new List<Component>();

        public string GetComponentName()
        {
            List<string> strings = new List<string>();
            foreach (var list in components)
            {
                strings.Add(list.ComponentName);
            }
            return string.Join("\n", strings);

        }
        
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
