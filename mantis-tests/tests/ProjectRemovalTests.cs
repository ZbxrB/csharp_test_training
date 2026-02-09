using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectRemovalTests : TestBase
    {
        [Test]
        public void ProjectRemovalTest()
        {
            AccountData admin = new AccountData()
            {
                Name = "administrator",
                Password = "root"
            };

            ProjectData project = new ProjectData()
            {
                Name = $"test project {GetRandomNumber()}"
            };

            applicationManager.Login.LoginUser(admin);
            applicationManager.Navigator.GoToManagementPage();
            applicationManager.Navigator.GoToProjectManagementPage();

            List<ProjectData> before = applicationManager.ProjectManager.GetProjectList();

            if (before.Count == 0)
            {
                applicationManager.ProjectManager.CreateNewProject(project);
                before = applicationManager.ProjectManager.GetProjectList();
            }

            applicationManager.ProjectManager.RemoveProject(before[0]);
             
            List<ProjectData> after = applicationManager.ProjectManager.GetProjectList();

            Assert.AreEqual(before.Count - 1, after.Count);
        }
    }
}
