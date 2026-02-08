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
                Name = "test_project",
            };

            List<ProjectData> before = applicationManager.ProjectManagment.GetProjectList(); // ProjectManagmentHelper

            applicationManager.Login.LoginUser(admin); // LoginHelper
            applicationManager.Navigator.GoToManagementPage(); // NavigationHelper
            applicationManager.Navigator.GoToProjectManagementPage(); // NavigationHelper
            applicationManager.ProjectManagment.CreateNewProject(project); // ProjectManagmentHelper

            List<ProjectData> after = applicationManager.ProjectManagment.GetProjectList(); // ProjectManagmentHelper

            Assert.AreEqual(before.Count + 1, after.Count);

        }

    }
}
