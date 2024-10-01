using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
//using static System.Net.WebRequestMethods;
using OfficeOpenXml;

namespace Proba10
{
    internal class Program
    {
                
                static void Main(string[] args)
        {
            Console.WriteLine("выбирите файл для чтения:\n 1 json 2 excel.");
            string number = Console.ReadLine(); 

            switch (number) {
                case "1":
                    string jsonFilePath = @"D:\izdeliya\json\изделия.json";
                    string jsonData = File.ReadAllText(jsonFilePath);

                    List<Product> products = JsonConvert.DeserializeObject<List<Product>>(jsonData);

                    foreach (Product product in products)
                    {
                        Console.WriteLine(
                            $"Изделие: {product.ProductName} \n переменный расход: {product.GetPrice()}");
                        foreach (var component in product.components)
                        {
                            Console.WriteLine($"комплектующие: {component.ComponentName}");
                        }
                    }
                    break;
                    case "2":

                    using (var fileExcel = new ExcelPackage(new FileInfo(@"D:\izdeliya\excel\Книга1.xlsx")))
                    {
                        
                        foreach (var sheet in fileExcel.Workbook.Worksheets)
                        {
                            Product product = new Product();
                            product.ProductName = sheet.ToString();
                            
                            int start = 2;
                            while (sheet.Cells[start, 1].Value != null)
                            {
                                Component component = new Component();

                                component.ComponentName = sheet.Cells[start, 1].Text;
                                component.ComponentCount = decimal.Parse(sheet.Cells[start, 2].Text);
                                component.ComponentPrice = decimal.Parse(sheet.Cells[start, 3].Text);
                                product.components.Add(component);

                                start++;
                            }
                            Console.WriteLine(
                            $"Изделие: {product.ProductName} \n переменный расход: {product.GetPrice()}");

                        }

                    }
                        break;
            }
            Console.ReadLine();
        }
    }
}
