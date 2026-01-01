using NUnit.Framework;
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            applicationManager.Navigator.GoToHomePage();
            applicationManager.Auth.Login(new AccountData("admin", "secret"));
            applicationManager.Navigator.GoToGroupsPage();
            applicationManager.Groups.InitGroupCreation();

            GroupData group = new GroupData("group name 112")
            {
                GroupHeader = "group header 132",
                GroupFooter = "group footer 1567"
            };
            applicationManager.Groups.FillGroupForm(group);

            applicationManager.Groups.SubmitGroupCreation();
            applicationManager.Navigator.GoToGroupsPage();
            applicationManager.Auth.Logout();
        }
    }
}
