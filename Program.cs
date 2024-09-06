using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
//using static System.Net.WebRequestMethods;
//using OfficeOpenXml;

namespace Proba10
{
    internal class Program
    {
                
                static void Main(string[] args)
        {
            string jsonFilePath = @"D:\izdeliya\json\изделия.json";
            string jsonData = File.ReadAllText(jsonFilePath);

            List<Product> products = JsonConvert.DeserializeObject<List<Product>>(jsonData);

            foreach (Product product in products)
            {
                Console.WriteLine($"Изделие: {product.ProductName} \n переменный расход: {product.GetPrice()}");
                foreach (var component in product.components)
                {
                    Console.WriteLine($"комплектующие: {component.ComponentName}");
                }
            }


            Console.ReadLine();
        }
    }
}
