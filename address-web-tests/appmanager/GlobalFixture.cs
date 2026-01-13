using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    [SetUpFixture]
    internal class GlobalFixture
    {
        [OneTimeTearDown]
        public void TearDownApplicationManager()
        {
            ApplicationManager.GetInstance().Driver.Quit();
        }
    }
}
