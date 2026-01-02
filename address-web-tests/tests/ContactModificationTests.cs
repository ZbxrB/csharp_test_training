using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class ContactModificationTests : TestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData newData = new ContactData("modified firstname", "modified lastname")
            {
                HomePhoneNumber = "modified number",
                Middlename = "modified middlename"
            };

            int index = 2;

            applicationManager.Contacts.Modify(index, newData);
        }
    }
}
