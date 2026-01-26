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

            if (applicationManager.Contacts.VerifyingContactExistence() == false)
            {
                applicationManager.Contacts.CreateDefaultContact();
            }

            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData toBeRemoved = oldContacts[index];

            applicationManager.Contacts.Remove(toBeRemoved);
            List<ContactData> newContacts = ContactData.GetAll();
            oldContacts.RemoveAt(index);
            Assert.AreEqual(oldContacts, newContacts);
        }

    }
}
