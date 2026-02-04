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
        [OneTimeSetUp] // уточнить
        public void SetUpConfig()
        {
            applicationManager.Ftp.BackUpFile("");
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
                Name = "testuser",
                Password = "password",
                Email = "testuser@localhost.localdomain"
            };

            applicationManager.Registration.Register(account);

        }

        [OneTimeTearDown] // уточнить
        public void RestoreConfig()
        {
            applicationManager.Ftp.RestoreBackUpFile("");
        }


    }
}
