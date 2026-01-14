using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            int index = 0;

            applicationManager.Navigator.GoToGroupsPage();

            if (applicationManager.Groups.VerifyingGroupExistence() == false)
            {
                applicationManager.Groups.CreateDefaultGroup();
            }

            List<GroupData> oldGroups = applicationManager.Groups.GetGroupList();
            applicationManager.Groups.Remove(index);
            Assert.AreEqual(oldGroups.Count - 1,
                            applicationManager.Groups.GetGroupCount());
            List<GroupData> newGroups = applicationManager.Groups.GetGroupList();

            // сохраняем данные удаленной группы
            GroupData toBeRemoved = oldGroups[index];

            oldGroups.RemoveAt(index);
            Assert.AreEqual(oldGroups, newGroups);

            // проверяем по уникальному Id, что группа отсутствует в новом списке, а значит действительно удалена
            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }
        }
    }
}
