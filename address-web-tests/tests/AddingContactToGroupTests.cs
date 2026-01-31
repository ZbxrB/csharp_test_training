using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public  class AddingContactToGroupTests : AuthTestBase
    {
        [Test]
        public void TestAddingContactToGroup()
        {
            List<GroupData> groups = GroupData.GetAll();
            applicationManager.Groups.CreateDefaultGroup();
            GroupData groupForAdding = GroupData.GetAll().Except(groups).ToList()[0];
            List<ContactData> oldList = groupForAdding.GetContacts();

            List<ContactData> contacts = ContactData.GetAll();
            applicationManager.Contacts.CreateDefaultContact();
            ContactData contactForAdding = ContactData.GetAll().Except(contacts).ToList()[0];

            applicationManager.Contacts.AddContactToGroup(contactForAdding, groupForAdding);

            List<ContactData> newList = groupForAdding.GetContacts();
            oldList.Add(contactForAdding);

            newList.Sort();
            oldList.Sort();
            Assert.AreEqual(oldList, newList);
        }

    }
}
