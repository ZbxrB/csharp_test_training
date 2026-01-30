using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace addressbook_tests_autoit
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
        [Test]
        public void TestGoupCreation()
        {
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            GroupData newGroup = new GroupData()
            {
                Name = "test"
            };

            app.Groups.Add(newGroup);
            List<GroupData> newGroups = app.Groups.GetGroupList();

            Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);
        }
    }
}
