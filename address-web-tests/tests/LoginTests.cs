using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class LoginTests : TestBase
    {
        [Test]
        public void LoginWithValidCredentials()
        {
            // prepare
            applicationManager.Auth.Logout();

            // action
            AccountData account = new AccountData("admin", "secret");
            applicationManager.Auth.Login(account);

            // verification
            Assert.IsTrue(applicationManager.Auth.IsLoggedIn(account));
        }

        [Test]
        public void LoginWithInValidCredentials()
        {
            // prepare
            applicationManager.Auth.Logout();

            // action
            AccountData account = new AccountData("admin", "wrong password");
            applicationManager.Auth.Login(account);

            // verification
            Assert.IsFalse(applicationManager.Auth.IsLoggedIn(account));
        }
    }
}
