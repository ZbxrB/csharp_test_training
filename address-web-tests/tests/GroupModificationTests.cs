using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : TestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("task5 modified")
            {
               GroupHeader = "task5 modified",
               GroupFooter = "task5 modified"
            };
            applicationManager.Groups.Modify(1, newData);

        }
    }
}
