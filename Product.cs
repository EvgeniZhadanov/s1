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
            StringBuilder sb = new StringBuilder();
            
            foreach (var list in components)
            {
                sb.AppendLine( list.ComponentName);
            }
            return sb.ToString();   
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
