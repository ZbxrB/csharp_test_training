using NUnit.Framework;
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            GroupData group = new GroupData("task7")
            {
                GroupHeader = "task7",
                GroupFooter = "task7"
            };

            applicationManager.Groups.Create(group);
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
        }
    }
}

