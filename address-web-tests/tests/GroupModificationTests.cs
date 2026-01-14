using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("name modified " + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"))
            {
               GroupHeader = "header modified",
               GroupFooter = "footer modified"
            };
            int index = 0;

            applicationManager.Navigator.GoToGroupsPage();

            if (applicationManager.Groups.VerifyingGroupExistence() == false)
            {
                applicationManager.Groups.CreateDefaultGroup();
            }

            List<GroupData> oldGroups = applicationManager.Groups.GetGroupList();
            applicationManager.Groups.Modify(index, newData);
            Assert.AreEqual(oldGroups.Count,
                applicationManager.Groups.GetGroupCount());

            List<GroupData> newGroups = applicationManager.Groups.GetGroupList();
            oldGroups[index].GroupName = newData.GroupName;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
            applicationManager.Navigator.GoToGroupsPage();
        }
    }
}
