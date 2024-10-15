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
using System.ComponentModel;

namespace Proba10
{
    internal class Program
    {
                
                static void Main(string[] args)
        {
            //создание папки для файлов, для считывания данных
            string path = @"C:\Users\Евгений\с1\папка считывания данных для подсчёта";

            DirectoryInfo dirInfo = new DirectoryInfo(path);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }

            //поиск в папке файла
                FileInfo[] files = dirInfo.GetFiles();

                foreach (FileInfo file in files)
                {
                    string extension = String.Empty;

                    extension = file.Extension; //присваивание строке расширения файла

                    switch (extension)
                    {
                        case ".json":

                            string jsonData = File.ReadAllText(file.FullName);

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
                        case ".xlsx":

                            using (var fileExcel = new ExcelPackage(new FileInfo(file.FullName)))
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
                                    Console.WriteLine(
                                        $"деталь- {product.GetComponentName()}");
                                }

                            }
                            break;
                    }
                }
            Console.ReadLine();
        }
    }
}
