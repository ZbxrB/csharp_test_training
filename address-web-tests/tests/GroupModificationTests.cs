using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : GroupTestBase
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


            if (applicationManager.Groups.VerifyingGroupExistence() == false)
            {
                applicationManager.Groups.CreateDefaultGroup();
            }

            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData toBeModified = oldGroups[index];

            applicationManager.Groups.Modify(toBeModified, newData);

            Assert.AreEqual(oldGroups.Count,
                applicationManager.Groups.GetGroupCount());

            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups[index].GroupName = newData.GroupName;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                if (group.Id == toBeModified.Id)
                {
                    Assert.AreEqual(newData.GroupName, group.GroupName);
                }
            }

            applicationManager.Navigator.GoToGroupsPage();
        }
    }
}
