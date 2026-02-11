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
            List<ProjectData> before = applicationManager.API.GetProjectListByAPI();

            if (before.Count == 0)
            {
                applicationManager.API.CreateProjectByAPI(new ProjectData()
                {
                    Name = $"test_project_{GetRandomNumber()}"
                });

                before = applicationManager.API.GetProjectListByAPI();
            }

            applicationManager.ProjectManager.RemoveProject(before[0]);
             
            List<ProjectData> after = applicationManager.API.GetProjectListByAPI();

            Assert.AreEqual(before.Count - 1, after.Count);
        }
    }
}
