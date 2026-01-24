using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System.IO;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        public static IEnumerable<ContactData>ContactDataFromXmlFile()
        {
            return (List<ContactData>)
                new XmlSerializer(typeof(List<ContactData>))
                    .Deserialize(new StreamReader(@"contacts.xml"));
        }

        public static IEnumerable<ContactData> ContactDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<ContactData>>(
                File.ReadAllText(@"contacts.json"));
        }

        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();

            for (int i = 0; i < 5; i++)
            {
                contacts.Add(
                    new ContactData(GenerateRandomString(20), GenerateRandomString(20))
                    {
                        Middlename = GenerateRandomString(20),
                        Address = GenerateRandomString(40),
                        HomePhone = GenerateRandomString(12)
                    });
            }

            return contacts;
        }

        [Test, TestCaseSource("ContactDataFromJsonFile")]
        public void ContactCreationTest(ContactData contact)
        {
            applicationManager.Navigator.GoToHomePage();
            List<ContactData> oldContacts = applicationManager.Contacts.GetContactList();

            applicationManager.Contacts.Create(contact);

            List<ContactData> newContacts = applicationManager.Contacts.GetContactList();

            oldContacts.Add(contact);

            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

        }
    }
}
