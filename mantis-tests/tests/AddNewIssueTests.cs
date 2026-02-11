using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class AddNewIssueTests : TestBase
    {
        [Test]
        public void AddNewIssueTest()
        {
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "root"
            };
            ProjectData project = new ProjectData()
            {
                Id = "21",
            };

            IssueData issue = new IssueData()
            {
                Summary = "some summary",
                Description = "some description",
                Category = "General",
            };

            applicationManager.API.CreateNewIssue(account, issue, project);
        }
    }
}
