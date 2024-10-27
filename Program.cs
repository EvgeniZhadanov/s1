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
             //копирование пути к системной папки
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                        //создание папки для файлов с данными для расчёта
            string path = Path.Combine(documentsPath, "С1\\отправка данных");


            DirectoryInfo dirInfo = new DirectoryInfo(path);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }

            //поиск в папке файла
                FileInfo[] files = dirInfo.GetFiles();

            
            foreach (FileInfo file in files)
                {
                List<string> result = new List<string>();
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
$"Изделие: {product.ProductName}\nпеременный расход: {product.GetPrice()}\nкомпоненты:\n{product.GetComponentName()}\n");

result.Add($"Изделие: {product.ProductName}\nпеременный расход: {product.GetPrice()}\nкомпоненты:\n{product.GetComponentName()}\n");
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
                                $"Изделие: {product.ProductName}\nпеременный расход: {product.GetPrice()}\nкомпоненты:\n{product.GetComponentName()}\n");

                                result.Add($"Изделие: {product.ProductName}\nпеременный расход: {product.GetPrice()}\nкомпоненты:\n{product.GetComponentName()}\n");
                            }
                                                                                        }
                            break;
                    }

                path = Path.Combine(documentsPath, "С1\\получение данных");
                DirectoryInfo d = new DirectoryInfo(path);
                if (!d.Exists)
                {
                    d.Create();
                }
                string dispatchFile = Path.Combine(path, "переменный расход.txt");

                using (StreamWriter writer = new StreamWriter(dispatchFile, false))
                {

                    foreach (var list in result)
                    {
                        writer.WriteLine(list);
                    }
                }
            }

                Console.ReadLine();
        }
    }
}
