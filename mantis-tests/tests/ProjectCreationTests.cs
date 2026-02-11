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
            ProjectData project = new ProjectData()
            {
                Name = $"test_project_{GetRandomNumber()}",
            };

            List<ProjectData> before = applicationManager.API.GetProjectListByAPI();

            applicationManager.ProjectManager.CreateNewProject(project);
            
            List<ProjectData> after = applicationManager.API.GetProjectListByAPI();

            Assert.AreEqual(before.Count + 1, after.Count);
        }
    }
}
