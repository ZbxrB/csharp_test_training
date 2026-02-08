using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{
    public class NavigationHelper : HelperBase
    {
        public NavigationHelper(ApplicationManager manager) : base(manager) { }

        internal void GoToManagementPage()
        {
            try
            {
                driver.FindElement(By.CssSelector("a[href='/mantisbt/manage_overview_page.php']")).Click();
            }
            catch (Exception)
            {
                Console.Out.WriteLine("The current user does not have administrator rights");
            }
        }

        internal void GoToProjectManagementPage()
        {
            driver.FindElement(By.CssSelector("a[href='/mantisbt/manage_proj_page.php']")).Click();
        }
    }
}
