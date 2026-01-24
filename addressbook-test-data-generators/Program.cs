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
            string dataType = args[0];
            int count = Convert.ToInt32(args[1]);
            string filename = args[2];
            string format = args[3];

            
            if (dataType == "group")
            {
                List<GroupData> groups = new List<GroupData>();

                for (int i = 0; i < count; i++)
                {
                    groups.Add(new GroupData(TestBase.GenerateRandomString(10))
                    {
                        GroupHeader = TestBase.GenerateRandomString(10),
                        GroupFooter = TestBase.GenerateRandomString(10)
                    });
                }

                WriteGroupsDataToFile(groups, filename, format);  
            }
            else if (dataType == "contact")
            {
                List<ContactData> contacts = new List<ContactData>();

                for (int i = 0; i < count; i++)
                {
                    contacts.Add(
                        new ContactData()
                        {
                            Firstname = TestBase.GenerateRandomString(10),
                            Lastname = TestBase.GenerateRandomString(10),
                            HomePhone = TestBase.GenerateRandomString(10)
                        });
                }

                WriteContactsDataToFile(contacts, filename, format);
            }
            else
            {
                System.Console.Out.Write($"Unsupported data type: {dataType}");
            }   
        }

        private static void WriteContactsDataToFile(List<ContactData> contacts, string filename, string format)
        {
            StreamWriter writer = new StreamWriter(filename);

            if (format == "json")
            {
                WriteContactsDataToJsonFile(contacts, writer);
            }
            else if (format == "xml")
            {
                WriteContactsDataToXmlFile(contacts, writer);
            }
            else
            {
                System.Console.Out.Write($"Format \"{format}\" is unsupported for \"contact\" data type.");
            }
            writer.Close();
        }

        private static void WriteContactsDataToXmlFile(List<ContactData> contacts, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<ContactData>)).Serialize(writer, contacts);
        }

        private static void WriteContactsDataToJsonFile(List<ContactData> contacts, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(contacts, Newtonsoft.Json.Formatting.Indented));
        }

        public static void WriteGroupsDataToFile(List<GroupData> groups, string filename, string format)
        {
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
                    System.Console.Out.Write($"Format \"{format}\" is unsupported for \"group\" data type.");
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
