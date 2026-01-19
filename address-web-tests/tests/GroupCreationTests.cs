using NUnit.Framework;
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;

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


        [Test, TestCaseSource("RandomGroupDataProvider")]
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

