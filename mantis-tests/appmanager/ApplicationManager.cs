using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        public string baseUrl;

        private static ThreadLocal<ApplicationManager> applicationManager = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            FirefoxOptions options = new FirefoxOptions();
            options.BrowserExecutableLocation = @"C:\Program Files\Mozilla Firefox\firefox.exe";

            driver = new FirefoxDriver(options);
            baseUrl = "http://localhost:8443/mantisbt";
            Registration = new RegistrationHelper(this);
            Ftp = new FtpHelper(this);
            James = new JamesHelper(this);
            Mail = new MailHelper(this);
            Login = new LoginHelper(this);
            Navigator = new NavigationHelper(this);
            ProjectManager = new ProjectManagmentHelper(this, baseUrl);
            Admin = new AdminHelper(this, baseUrl);
            API = new APIHelper(this);

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
                newInstance.driver.Url = newInstance.baseUrl + "/login_page.php";
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
        public JamesHelper James { get; set; }
        public MailHelper Mail { get; set; }
        public LoginHelper Login { get; set; }
        public NavigationHelper Navigator { get; set; }
        public ProjectManagmentHelper ProjectManager { get; set; }
        public AdminHelper Admin { get; set; }
        public APIHelper API { get; set; }
    }
}
