using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            applicationManager.Navigator.GoToHomePage();
            applicationManager.Auth.Login(new AccountData("admin", "secret"));
            applicationManager.Navigator.GoToGroupsPage();

            int index = 1;
            applicationManager.Groups.SelectGroup(index);
            applicationManager.Groups.RemoveGroup();
            applicationManager.Navigator.GoToGroupsPage();
        }
    }
}
