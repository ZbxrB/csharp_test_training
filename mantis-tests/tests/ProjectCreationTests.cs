using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectCreationTests : TestBase
    {
        [Test]
        public void ProjectCreationTest()
        {
            AccountData admin = new AccountData()
            {
                Name = "administrator",
                Password = "root"
            };

            ProjectData project = new ProjectData()
            {
                Name = "test_project1112711579771",
            };

            applicationManager.Login.LoginUser(admin);

            applicationManager.Navigator.GoToManagementPage();
            applicationManager.Navigator.GoToProjectManagementPage();
            List<ProjectData> before = applicationManager.ProjectManager.GetProjectList();
            applicationManager.ProjectManager.CreateNewProject(project);
            
            List<ProjectData> after = applicationManager.ProjectManager.GetProjectList();

            Assert.AreEqual(before.Count + 1, after.Count);
        }
    }
}
