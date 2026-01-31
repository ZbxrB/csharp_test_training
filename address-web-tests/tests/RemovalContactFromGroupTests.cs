using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class RemovalContactFromGroupTests : AuthTestBase
    {
        [Test]
        public void TestRemovalContactFromGroup()
        {
            List<GroupData> groups = GroupData.GetAll();
            applicationManager.Groups.CreateDefaultGroup();
            GroupData groupForRemoval = GroupData.GetAll().Except(groups).ToList()[0];

            List<ContactData> contacts = ContactData.GetAll();
            applicationManager.Contacts.CreateDefaultContact();
            ContactData contactForRemoval = ContactData.GetAll().Except(contacts).ToList()[0];

            applicationManager.Contacts.AddContactToGroup(contactForRemoval, groupForRemoval);
            List<ContactData> oldList = groupForRemoval.GetContacts();

            applicationManager.Contacts.RemoveContactFromGroup(contactForRemoval, groupForRemoval);

            List<ContactData> newList = groupForRemoval.GetContacts();
            oldList.Remove(contactForRemoval);
            newList.Sort();
            oldList.Sort();
            Assert.AreEqual(oldList, newList);
        }
    }
}
