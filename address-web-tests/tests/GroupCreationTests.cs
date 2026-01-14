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
        [Test]
        public void GroupCreationTest()
        {
            GroupData group = new GroupData("name created " + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"))
            {
                GroupHeader = "header",
                GroupFooter = "footer"
            };
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
        public void EmptyGroupCreationTest()
        {
            GroupData group = new GroupData("")
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

