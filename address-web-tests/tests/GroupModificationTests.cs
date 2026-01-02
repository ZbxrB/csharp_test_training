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
            GroupData newData = new GroupData("task7 modified")
            {
               GroupHeader = "task7 modified",
               GroupFooter = "task7 modified"
            };
            applicationManager.Groups.Modify(1, newData);

        }
    }
}
