using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Reflection;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;

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
            return $"firstname = {Firstname}\nlastname = {Lastname}\nmiddlename = {Middlename}\naddress = {Address}\nhome phone = {HomePhone}";
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
        public string Middlename { get; set; } = "";
        public string Lastname { get; set; }
        public string Nickname { get; set; } = "";
        public string Title { get; set; } = "";
        public string Company { get; set; } = "";
        public string Address { get; set; } = "";
        public string HomePhone { get; set; } = "";
        public string MobilePhone { get; set; } = "";
        public string WorkPhone { get; set; } = "";
        public string FaxPhone { get; set; } = "";
        public string Email { get; set; } = "";
        public string Email2 { get; set; } = "";
        public string Email3 { get; set; } = "";
        public string Homepage { get; set; } = "";

        public string AllPhones
        {
            get
            {
                if (this.allPhones != null)
                {
                    return this.allPhones;
                }

                else
                {
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone)).Trim();
                }
            }
            
            set
            {
                this.allPhones = value;
            }
        }

        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return Regex.Replace(phone, "[ ()-]", "") + "\r\n";
        }

        internal string GetContactInformationAsDetails()
        {
            StringBuilder builder = new StringBuilder();

            builder.Append($"{Firstname} {Middlename} {Lastname}\n");
            builder.Append($"{Nickname}\n");
            builder.Append($"{Title}\n");
            builder.Append($"{Company}\n");
            builder.Append($"{Address}\n\n");
            builder.Append($"H: {HomePhone}\n");
            builder.Append($"M: {MobilePhone}\n");
            builder.Append($"W: {WorkPhone}\n");
            builder.Append($"F: {FaxPhone}\n\n");
            builder.Append($"{Email}\n");
            builder.Append($"{Email2}\n");
            builder.Append($"{Email3}\n");
            builder.Append($"Homeoage:{Homepage.Replace("http://", "")}\n");

            return builder.ToString();
        }
    }
}
