using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class GroupData : IEquatable<GroupData>
    {
        private string groupName;
        private string groupHeader = "";
        private string groupFooter = "";


        public GroupData(string groupName)
        {
            this.groupName = groupName;
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

            return groupName == other.groupName;
        }

        public int GetHashCode()
        {
            return groupName.GetHashCode();
        }

        public string GroupName
        {
            get
            {
                return this.groupName;
            }
            set
            {
                this.groupName = value;
            }
        }

        public string GroupHeader
        {
            get
            {
                return this.groupHeader;
            }
            set
            {
                this.groupHeader = value;
            }
        }

        public string GroupFooter
        {
            get
            {
                return this.groupFooter;
            }
            set
            {
                this.groupFooter = value;
            }
        }
    }
}
