using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        public ContactData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }
        
        public bool Equals(ContactData other)
        {
            if (other is null)
            {
                return false;
            }
            if(Object.ReferenceEquals(this, other))
            {
                return true;
            }

            return Firstname == other.Firstname
                                    && Lastname == other.Lastname; 
        }

        public override int GetHashCode()
        {
            return (Firstname+Lastname).GetHashCode();
        }

        public override string ToString()
        {
            return "firstname = " + Firstname + "; lastname = " + Lastname;
        }

        public int CompareTo(ContactData other)
        {
            if (other is null)
            {
                return 1;
            }
            return (Firstname + Lastname).CompareTo(other.Firstname + other.Lastname);
        }


        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Middlename { get; set; } = "";

        public string Address { get; set; } = "";

        public string HomePhone { get; set; } = "";

        public string HomePhoneNumber { get; set; } = "";

        public string MobilePhone { get; set; } = "";

        public string WorkPhone { get; set; } = "";

        public string AllPhones
        {
            get
            {
                if (AllPhones != null)
                {
                    return AllPhones;
                }

                else
                {
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone)).Trim();
                }
            }
            
            set
            {
                AllPhones = value;
            }
        }

        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return phone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "") + "\r\n";
        }
    }
}
