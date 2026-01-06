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
            GroupData newData = new GroupData("task7 modified")
            {
               GroupHeader = null,
               GroupFooter = null
            };
            applicationManager.Groups.Modify(1, newData);

        }
    }
}
