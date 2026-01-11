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
            GroupData newData = new GroupData("modified " + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"))
            {
               GroupHeader = null,
               GroupFooter = null
            };

            applicationManager.Navigator.GoToGroupsPage();

            if (applicationManager.Groups.VerifyingGroupExistence() == false)
            {
                applicationManager.Groups.CreateDefaultGroup();
            }

            applicationManager.Groups.Modify(0, newData);
            applicationManager.Navigator.GoToGroupsPage();
        }
    }
}
