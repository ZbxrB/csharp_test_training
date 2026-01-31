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
            List<ContactData> contacts = ContactData.GetAll();

            if (groups.Count == 0)
            {
                applicationManager.Groups.CreateDefaultGroup();
                groups = GroupData.GetAll();
            }

            if (contacts.Count == 0)
            {
                applicationManager.Contacts.CreateDefaultContact();
                contacts = ContactData.GetAll();
            }

            ContactData contactForAdding;
            GroupData groupForAdding = groups[0];
            List<ContactData> oldList = groupForAdding.GetContacts();
            

            if (oldList.Count == contacts.Count)
            {
                contactForAdding = contacts[0];
                applicationManager.Contacts.RemoveContactFromGroup(contactForAdding, groupForAdding);
                oldList = groupForAdding.GetContacts();
            }
            else
            {
                contactForAdding = oldList[0];
            }
                       
            applicationManager.Contacts.AddContactToGroup(contactForAdding, groupForAdding);

            List<ContactData> newList = groupForAdding.GetContacts();
            oldList.Add(contactForAdding);

            newList.Sort();
            oldList.Sort();
            Assert.AreEqual(oldList, newList);
        }

    }
}
