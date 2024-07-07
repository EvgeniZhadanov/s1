using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Net.WebRequestMethods;

namespace Proba10
{
    internal class Program
    {

        static List<string> Way()
        {
            var list = new List<string>();  
            using (StreamReader path = new StreamReader("settings.txt"))
            {
                using (StreamReader pathDirectory = new StreamReader(path.ReadLine()))
                {
                    //var files = Directory.GetFiles(pathDirectory.ReadLine());

                    foreach (var file in Directory.GetFiles(pathDirectory.ReadLine()))
                    {
                        list.Add(file);
                    }
                }
            }
            return list;    
        }

        static List<Completings> Products(string stringPath)
        {
            List<Completings> list = new List<Completings>();
            using (StreamReader File = new StreamReader(stringPath))
            {
                string file;
                while ((file = File.ReadLine()) != null)
                {
                    foreach (var line in file.Split('\n'))
                    {
                        var values = line.Split('\t');


                        Completings com = new Completings(values[0], Convert.ToDecimal(values[1]), Convert.ToDecimal(values[2]));

                        list.Add(com);

                    }
                }
            }
            return list;
        }

        static void Main(string[] args)
        {
            
            
            WayProduct stringWay = new WayProduct(Way());   

Console.WriteLine("выберите изделие. 0 для выхода из программы.");
                    foreach (var file in stringWay.wayproducts)
                    {
                        Console.WriteLine($"Изделие: {Path.GetFileName(file)}\t");
                    }

                    var _number = Console.ReadLine();
                    
                    try
                    {
                    
                    int number = int.Parse(_number);
                while (number != 0)
                {
                    Products product = new Products(Products(stringWay.wayproducts[number - 1]));
                    Console.WriteLine(
                format: "{0,-8} \n {1,6:C}", arg0: product.GetString(), arg1: product.GetPrice());
                }
                    }
            
                    catch
                    {
                        Console.WriteLine("вы ввели не верное значение");
                    }
            Console.Write("досвидание");
            Console.Read();
        }
    }
}
