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
                HomePhone = "modified number",
                Middlename = "modified middlename"
            };

            int index = 0;

            applicationManager.Navigator.GoToHomePage();

            if (applicationManager.Contacts.VerifyingContactExistence() == false)
            {
                applicationManager.Contacts.CreateDefaultContact();
            }

            List<ContactData> oldContacts = applicationManager.Contacts.GetContactList();
            applicationManager.Contacts.Modify(index, newData);
            List<ContactData> newContacts = applicationManager.Contacts.GetContactList();
            oldContacts[index].Firstname = newData.Firstname;
            oldContacts[index].Lastname = newData.Lastname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
            applicationManager.Navigator.GoToHomePage();
        }
    }
}
