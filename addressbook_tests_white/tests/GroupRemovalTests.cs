using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace addressbook_tests_white
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {
        [Test]
        public void TestGroupRemoval()
        {
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            int index = 0;

            if (oldGroups.Count == 1)
            {
                app.Groups.CreateDefaultGroup();
                oldGroups = app.Groups.GetGroupList();
            }

            app.Groups.Remove(index);
            List<GroupData> newGroups = app.Groups.GetGroupList();
            Assert.AreEqual(oldGroups.Count - 1, newGroups.Count);
        }
    }
}
