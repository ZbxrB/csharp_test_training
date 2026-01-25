using NUnit.Framework;
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Excel = Microsoft.Office.Interop.Excel;
using LinqToDB;
using System.Linq;



namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {


        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();

            for (int i = 0; i < 5; i++)
            {
                groups.Add(new GroupData(GenerateRandomString(30))
                {
                    GroupHeader = GenerateRandomString(100),
                    GroupFooter = GenerateRandomString(100),
                });
            }
            return groups;
        }

        public static IEnumerable<GroupData> GroupDataFromCsvFile()
        {
            List<GroupData> groups = new List<GroupData>();
            string[] lines = File.ReadAllLines(@"groups.csv");
            foreach (string line in lines)
            {
                string [] parts =  line.Split(',');
                groups.Add(
                    new GroupData(parts[0])
                    {
                        GroupHeader = parts[1],
                        GroupFooter = parts[2]
                    });
            }

            return groups;
        }

        public static IEnumerable<GroupData> GroupDataFromXmlFile()
        {
            return (List<GroupData>)
                new XmlSerializer(typeof(List<GroupData>))
                    .Deserialize(new StreamReader(@"groups.xml"));
        }

        public static IEnumerable<GroupData> GroupDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<GroupData>>(
                File.ReadAllText(@"groups.json"));
        }

        public static IEnumerable<GroupData> GroupDataFromExcelFile()
        {
            List<GroupData> groups = new List<GroupData>();
            Excel.Application app = new Excel.Application();
            app.Visible = true;

            Excel.Workbook wb = app.Workbooks.Open(Path.Combine(Directory.GetCurrentDirectory(), @"groups.xlsx"));
            Excel.Worksheet sheet = wb.ActiveSheet;
            Excel.Range range = sheet.UsedRange;

            for (int i = 1; i <= range.Rows.Count; i++)
            {
                groups.Add(
                    new GroupData(range.Cells[i, 1].Value)
                    {
                        GroupHeader = range.Cells[i, 2].Value,
                        GroupFooter = range.Cells[i, 3].Value
                    });
            }

            wb.Close();
            app.Visible = false;
            // скрывая окно, мы не закрываем процесс. соответственно его нужно закрыть командой ниже
            app.Quit();

            return groups;
        }


        [Test, TestCaseSource("GroupDataFromJsonFile")]
        public void GroupCreationTest(GroupData group)
        {
            applicationManager.Navigator.GoToGroupsPage();
            List<GroupData> oldGroups = applicationManager.Groups.GetGroupList();
            applicationManager.Groups.Create(group);

            Assert.AreEqual(oldGroups.Count + 1,
                            applicationManager.Groups.GetGroupCount());

            List<GroupData> newGroups =  applicationManager.Groups.GetGroupList();
            oldGroups.Add(group);

            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }

        [Test]
        public void BadNameGroupCreationTest()
        {
            GroupData group = new GroupData("a'a")
            {
                GroupHeader = "",
                GroupFooter = ""
            };
            applicationManager.Navigator.GoToGroupsPage();
            List<GroupData> oldGroups = applicationManager.Groups.GetGroupList();
            applicationManager.Groups.Create(group);

            Assert.AreEqual(oldGroups.Count + 1,
                applicationManager.Groups.GetGroupCount());

            List<GroupData> newGroups = applicationManager.Groups.GetGroupList();
            oldGroups.Add(group);

            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }

        [Test]
        public void TestDBConnectivity()
        {
            DateTime start = DateTime.Now;

            List<GroupData> fromUI = applicationManager.Groups.GetGroupList();

            DateTime end = DateTime.Now;
            System.Console.Out.WriteLine($"From UI: {end.Subtract(start)}");

            start = DateTime.Now;

            List<GroupData> fromDB = GroupData.GetAll();

            end = DateTime.Now;
            System.Console.Out.WriteLine($"From DB: {end.Subtract(start)}");
        }
    }
}

