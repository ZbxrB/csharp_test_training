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
            GroupData group = new GroupData("group name 112")
            {
                GroupHeader = "group header 132",
                GroupFooter = "group footer 1567"
            };

            applicationManager.Groups.Create(group);
            applicationManager.Auth.Logout();
        }

        [Test]
        public void EmptyGroupCreationTest()
        {
            GroupData group = new GroupData("")
            {
                GroupHeader = "",
                GroupFooter = ""
            };

            applicationManager.Groups.Create(group);
            applicationManager.Auth.Logout();
        }
    }
}

