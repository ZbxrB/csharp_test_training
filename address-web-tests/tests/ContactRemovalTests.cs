using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]

        public void ContactRemovalTest()
        {
            applicationManager.Navigator.GoToHomePage();

            if (applicationManager.Contacts.VerifyingContactExistence() == false)
            {
                applicationManager.Contacts.CreateDefaultContact();
            }

            applicationManager.Contacts.Remove(2);
            applicationManager.Navigator.GoToHomePage();
        }

    }
}
