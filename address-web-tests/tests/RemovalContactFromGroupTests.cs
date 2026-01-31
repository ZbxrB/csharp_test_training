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
            List<ContactData> contacts = ContactData.GetAll();
            /*
            проверяем, что существует хотя бы одна группа,
            если не существует, то создаем группу по-умолчанию
            */
            if (groups.Count == 0)
            {
                applicationManager.Groups.CreateDefaultGroup();
                groups = GroupData.GetAll();
            }

            /*
            проверяем, что существует хотя бы один контакт,
            если не существует, то создаем контакт по-умолчанию
            */
            if (contacts.Count == 0)
            {
                applicationManager.Contacts.CreateDefaultContact();
                contacts = ContactData.GetAll();
            }

            /*
            проверяем, содержит ли первая в списке группа хоть один контакт,
            если не содержит, то добавляем в эту групп первый в списке контакт из обещго списка контактов,
            если содержит, то сохраняем его в переменную для последующего удаления
            */

            ContactData contactForRemoval;
            GroupData groupForRemoval = groups.First();
            List<ContactData> oldList = groups.First().GetContacts();
            
            if (oldList.Count == 0)
            {
                contactForRemoval = contacts.First();
                applicationManager.Contacts.AddContactToGroup(contactForRemoval, groupForRemoval);
                oldList = GroupData.GetAll().First().GetContacts();
            }
            else
            {
                contactForRemoval = oldList.First();
            }
            
            // удаляем контакт из группы для удаления
            applicationManager.Contacts.RemoveContactFromGroup(contactForRemoval, groupForRemoval);

            // получаем список контактов из группы для удаления
            List<ContactData> newList = groupForRemoval.GetContacts();

            // удаляем контакт для удаления из списка контактов до момента удаления
            oldList.Remove(contactForRemoval);

            // сортируем и сравниваем списки
            newList.Sort();
            oldList.Sort();
            Assert.AreEqual(oldList, newList);
        }
    }
}
