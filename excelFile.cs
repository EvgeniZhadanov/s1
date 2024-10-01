using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Proba10
{
    internal class excelFile
    {

        static public List<List<Component>> WayExcel()
        {
                        List<List<Component>> components1 = new List<List<Component>>();
            using (var fileExcel = new ExcelPackage(new FileInfo(@"D:\izdeliya\excel\Книга1.xlsx")))
            {
                foreach (var sheet in fileExcel.Workbook.Worksheets)
                {
                    //var sheet = fileExcel.Workbook.Worksheets;
                    int rowcount = sheet.Dimension.Rows;

                    for (int i = 2; i <= rowcount; i++)
                    {
                        List<Component> components = new List<Component>();
                        Component component = new Component();
                        {
                            component.ComponentName = sheet.Cells[i, 1].Value.ToString();
                            component.ComponentCount = Convert.ToDecimal(sheet.Cells[i, 2].Value.ToString());
                            component.ComponentPrice = Convert.ToDecimal(sheet.Cells[i, 3].Value.ToString());

                            components.Add(component);
                        }
                                                components1.Add(components);
                    }

                }
            }
            return components1;
        }

    }
}
