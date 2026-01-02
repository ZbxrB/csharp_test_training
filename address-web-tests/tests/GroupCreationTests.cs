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
            GroupData group = new GroupData("task5")
            {
                GroupHeader = "task5",
                GroupFooter = "task5"
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

