using NUnit.Framework;
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using System.IO;

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

        public static IEnumerable<GroupData> GroupDataFromFile()
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

        [Test, TestCaseSource("GroupDataFromFile")]
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
    }
}

