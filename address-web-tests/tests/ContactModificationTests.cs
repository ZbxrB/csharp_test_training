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
            ContactData newData = new ContactData("Y5ESTRUTRI", "ZRZUTUTU6I")
            {
                HomePhone = "46S7RDUTUT",
                Middlename = "XYSUX6DIYI"
            };

            int index = 0;

            if (applicationManager.Contacts.VerifyingContactExistence() == false)
            {
                applicationManager.Contacts.CreateDefaultContact();
            }

            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData toBeModified = oldContacts[index];

            applicationManager.Contacts.Modify(toBeModified, newData);
            List<ContactData> newContacts = ContactData.GetAll();
            toBeModified.Firstname = newData.Firstname;
            toBeModified.Lastname = newData.Lastname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
            applicationManager.Navigator.GoToHomePage();
        }
    }
}
