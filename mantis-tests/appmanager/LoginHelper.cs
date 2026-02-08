using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager) : base(manager) { }

        internal void LoginUser(AccountData account)
        {
            if (IsLoggedIn())
            {
                if (IsLoggedIn(account))
                {
                    return;
                }

                Logout();
            }

            Type(By.Name("username"), account.Name);
            Type(By.Name("password"), account.Password);
            driver.FindElement(By.CssSelector("input[type='submit']")).Click();

            Wait(10, By.CssSelector("input[type='submit'][value='Изменить учетную запись']"));
        }

        private void Logout()
        {
            if (IsLoggedIn())
            {
                driver.FindElement(By.CssSelector("a[href='/mantisbt/logout_page.php']")).Click();
            }
        }

        private bool IsLoggedIn(AccountData account)
        {
            return IsLoggedIn() &&
                (driver.FindElement(By.ClassName("user-info")).Text == account.Name);
        }

        private bool IsLoggedIn()
        {
            return IsElementPresent(By.ClassName("user-info"));
        }
    }
}
