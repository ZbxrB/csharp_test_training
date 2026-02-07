using System;
using System.IO;
using System.Net.FtpClient;
using System.Collections.Generic;
using NUnit.Framework;


namespace mantis_tests
{
    [TestFixture]
    internal class AccountCreationTests : TestBase
    {
        [OneTimeSetUp]
        public void SetUpConfig()
        {
            applicationManager.Ftp.BackUpFile("/config_inc.php");

            using (Stream localFile = File.Open("config_inc.php", FileMode.Open))
            {
                applicationManager.Ftp.Upload("/config_inc.php", localFile);
            }

        }

        [Test]
        public void TestAccountRegistration()
        {
            AccountData account = new AccountData()
            {
                Name = "user3",
                Password = "password",
                Email = "user3@localhost.localdomain"
            };

            applicationManager.James.Delete(account);
            applicationManager.James.Add(account);

            applicationManager.Registration.Register(account);
        }

        [OneTimeTearDown]
        public void RestoreConfig()
        {
            applicationManager.Ftp.RestoreBackUpFile("/config_inc.php");
        }


    }
}
