using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace mantis_tests
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected string baseURL;

        private static ThreadLocal<ApplicationManager> applicationManager = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost:8080/addressbook";
            Registration = new RegistrationHelper(this);
            Ftp = new FtpHelper(this);
        }

        ~ApplicationManager()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        public static ApplicationManager GetInstance()
        {   
            if (! applicationManager.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.driver.Url = "http;//localhost/mantisbt-1.2.17/login_page.php";
                applicationManager.Value = newInstance;
            }
            return applicationManager.Value;
        }

        public IWebDriver Driver
        { 
            get
            {
                return driver;
            }
        }

        public RegistrationHelper Registration { get; set; }
        public FtpHelper Ftp { get; set; }
    }
}
