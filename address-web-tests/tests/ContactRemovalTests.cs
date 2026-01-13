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
            int index = 0;
            applicationManager.Navigator.GoToHomePage();

            if (applicationManager.Contacts.VerifyingContactExistence() == false)
            {
                applicationManager.Contacts.CreateDefaultContact();
            }

            List<ContactData> oldContacts = applicationManager.Contacts.GetContactList();
            applicationManager.Contacts.Remove(index);
            List<ContactData> newContacts = applicationManager.Contacts.GetContactList();
            oldContacts.RemoveAt(index);
            //oldContacts.Sort();
            //newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
            applicationManager.Navigator.GoToHomePage();
        }

    }
}
