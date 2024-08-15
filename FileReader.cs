using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Proba10
{
    static List<Completings> WayExcel()            {
        //метод чтения txt файла
        


        //чтение из excel файла
        
            List<List<string>> stringXl = new List<List<string>>();
            using (var xlFile = new ExcelPackage(new FileInfo(@"D:\izdeliya\Книга1.xlsx")))
            {
                var cheetCount = xlFile.Workbook.Worksheets; // путь к листам книге
                foreach (var cheet in cheetCount)
                {
                    //Console.WriteLine($"изделие: {cheet.Name}");
                }

                ExcelWorksheet worksheet = xlFile.Workbook.Worksheets[1]; // путь к конкретному листу

                int rowCount = worksheet.Dimension.Rows; //количество строк
                int columnCount = worksheet.Dimension.End.Column; // количество столбцов 

                for (int i = 2; i <= rowCount; i++)
                {
                    Completingscomp = new Completings(worksheet.Cells[i, 1].Value.ToString(), Convert.ToDecimal(worksheet.Cells[i, 2].Value.ToString(), Convert.ToDecimal(worksheet.Cells[i, 3].Value.ToString());
                    List<Completings> list = new List<Completings>();
                    
                    
                        
                //for (int j = 1; j <= columnCount; j++)
                    //{
                        //list.Add(worksheet.Cells[i, j].Value.ToString());
                                            //}
                    //Completings comp = new Completings(list[0], Convert.ToDecimal(list[1]), Convert.ToDecimal(list[2]));
                    stringXl.Add(list);
                }
            
                return stringXl;
            }



            }
         }
