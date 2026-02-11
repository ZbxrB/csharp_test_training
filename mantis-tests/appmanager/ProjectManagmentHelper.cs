using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class ProjectManagmentHelper : HelperBase
    {
        private string baseUrl;

        public ProjectManagmentHelper(ApplicationManager manager, string baseUrl) : base(manager)
        {
            this.baseUrl = baseUrl;
        }

        public List<ProjectData> GetProjectListFromPage()
        {
            List<ProjectData> projects = new List<ProjectData>();
            IWebDriver driver = manager.Admin.OpenAppAndLogin();
            driver.Url = baseUrl + "/manage_proj_page.php";
            ICollection<IWebElement> elements = driver.FindElements(By.XPath("//a[starts-with(@href, 'manage_proj_edit_page.php?project_id=')]"));

            Regex regex = new Regex(@"project_id=(\d+)", RegexOptions.Compiled);

            foreach (IWebElement element in elements)
            {
                string link = element.GetAttribute("href");
                Match match = regex.Match(link);
                projects.Add(
                    new ProjectData()
                    {
                        Id = match.Groups[1].Value,
                        Name = element.Text,
                        Link = link,
                    });
            }

            return projects;
        }

        public void CreateNewProject(ProjectData project)
        {
            IWebDriver driver = manager.Admin.OpenAppAndLogin();
            driver.Url = baseUrl + "/manage_proj_page.php";
            driver.FindElement(By.CssSelector("input[type='submit'][value='создать новый проект']")).Click();
            driver.FindElement(By.CssSelector("input[id='project-name'][name='name']")).SendKeys(project.Name);
            driver.FindElement(By.CssSelector("input[type='submit'][value='Добавить проект']")).Click();

            //Wait(10, By.CssSelector("input[type='submit'][value='создать новый проект']"));
        }

        public void RemoveProject(ProjectData projectData)
        {
            IWebDriver driver = manager.Admin.OpenAppAndLogin();
            driver.Url = projectData.Link;
            driver.FindElement(By.CssSelector("input[type='submit'][value='Удалить проект']")).Click();
            driver.FindElement(By.CssSelector("input[type='submit'][value='Удалить проект']")).Click();
            //Wait(10, By.CssSelector("input[type='submit'][value='создать новый проект']"));
        }

        private void SubmitProjectRemoval()
        {
            driver.FindElement(By.CssSelector("input[type='submit'][value='Удалить проект']")).Click();
        }

        public void SubmitProjectCreation()
        {
            driver.FindElement(By.CssSelector("input[type='submit'][value='Добавить проект']")).Click();
        }

        public void FillProjectForm(ProjectData project)
        {
            driver.FindElement(By.CssSelector("input[id='project-name'][name='name']")).SendKeys(project.Name);
        }


    }
}
