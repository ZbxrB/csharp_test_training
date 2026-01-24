using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAddressbookTests;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Excel = Microsoft.Office.Interop.Excel; // библиотека для работы с Excel

namespace addressbook_test_data_generators
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = Convert.ToInt32(args[0]);
            string filename = args[1];
            string format = args[2];

            List<GroupData> groups = new List<GroupData>();

            for (int i = 0; i < count; i++)
            {
                groups.Add(new GroupData(TestBase.GenerateRandomString(10))
                {
                    GroupHeader = TestBase.GenerateRandomString(10),
                    GroupFooter = TestBase.GenerateRandomString(10)
                });
            }

            if (format == "excel")
            {
                WriteGroupsDataToExcelFile(groups, filename);
            }
            else
            {
                StreamWriter writer = new StreamWriter(filename);

                if (format == "csv")
                {
                    WriteGroupsDataToCsvFile(groups, writer);
                }
                else if (format == "xml")
                {
                    WriteGroupsDataToXmlFile(groups, writer);
                }
                else if (format == "json")
                {
                    WriteGroupsDataToJsonFile(groups, writer);
                }
                else
                {
                    System.Console.Out.Write($"Unrecognized format: {format}");
                }
                writer.Close();
            }
        }

        public static void WriteGroupsDataToExcelFile(List<GroupData> groups, string filename)
        {
            // запускаем окно приложения excel 
            Excel.Application app = new Excel.Application();
            // делаем видимым то, что происходит в этом окне. Нужно для отладки
            // если не включить, код будет отрабатывать, файл будет создаваться, просто вс будет происходить в невидимом режиме
            app.Visible = true;
            Excel.Workbook wb = app.Workbooks.Add();
            Excel.Worksheet sheet = wb.ActiveSheet;

            int row = 1;
            foreach (GroupData group in groups)
            {
                sheet.Cells[row, 1] = group.GroupName;
                sheet.Cells[row, 2] = group.GroupHeader;
                sheet.Cells[row, 3] = group.GroupFooter;
                row++;
            }

            string fullPath = Path.Combine(Directory.GetCurrentDirectory(), filename);
            File.Delete(fullPath);
            wb.SaveAs(fullPath);
            // закрываем файл
            wb.Close();
            // закрываем окно программы excel
            app.Visible = false;
            // скрывая окно, мы не закрываем процесс. соответственно его нужно закрыть командой ниже
            app.Quit();
        }

        static void WriteGroupsDataToCsvFile(List<GroupData> groups, StreamWriter writer)
        {
            foreach (GroupData group in groups)
            {
                writer.WriteLine(
                    $"{group.GroupName}," +
                    $"{group.GroupHeader}," +
                    $"{group.GroupFooter}");
            }
        }

        static void WriteGroupsDataToXmlFile(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
        }

        static void WriteGroupsDataToJsonFile(List<GroupData> groups, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(groups, Newtonsoft.Json.Formatting.Indented));
        }

    }
}
