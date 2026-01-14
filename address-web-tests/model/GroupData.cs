using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class GroupData : IEquatable<GroupData>, IComparable<GroupData>
    {

        public GroupData(string groupName)
        {
            GroupName = groupName;
        }

        public bool Equals(GroupData other)
        {
            if (other is null)
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }

            return GroupName == other.GroupName;
        }

        public override int GetHashCode()
        {
            return GroupName.GetHashCode();
        }

        // возвращает строковое представление экземпляра класса GroupData
        public override string ToString()
        {
            return "name = " + GroupName;
        }

        public int CompareTo(GroupData other)
        {
            if (other is null)
            {
                return 1;
            }
            return GroupName.CompareTo(other.GroupName);
        }


        public string GroupName { get; set; }

        public string GroupHeader { get; set; }

        public string GroupFooter { get; set; }

        public string Id { get; set; }

    }
}
