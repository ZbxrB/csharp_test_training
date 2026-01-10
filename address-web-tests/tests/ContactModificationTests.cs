using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData newData = new ContactData("modified " + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"), "modified lastname")
            {
                HomePhoneNumber = "modified number",
                Middlename = "modified middlename"
            };

            int index = 2;

            applicationManager.Navigator.GoToHomePage();

            if (applicationManager.Contacts.VerifyingContactExistence() == false)
            {
                applicationManager.Contacts.CreateDefaultContact();
            }

            applicationManager.Contacts.Modify(index, newData);
            applicationManager.Navigator.GoToHomePage();
        }
    }
}
