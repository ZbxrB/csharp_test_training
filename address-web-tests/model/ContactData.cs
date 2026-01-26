using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Reflection;
using LinqToDB.Mapping;

namespace WebAddressbookTests
{
    [Table(Name = "addressbook")]
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;

        public ContactData()
        {
        }

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

        [Column(Name = "id"), PrimaryKey]
        public string Id { get; set; }

        [Column(Name = "firstname")]
        public string Firstname { get; set; }
        public string Middlename { get; set; } = "";

        [Column(Name = "lastname")]
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

        public string PrepareContactInformationString(string infoString, string starting = "",  string ending = "")
        {
            if (infoString == null || infoString == "")
            {
                return "";
            }

            return string.Concat(starting, infoString, ending);
        }

        public string GetContactInformationAsDetails()
        {
            string ending = "\r\n";
            StringBuilder builder = new StringBuilder("");

            // name section
            builder.Append(PrepareContactInformationString(infoString: Firstname, ending: " "));
            builder.Append(PrepareContactInformationString(infoString: Middlename, ending: " "));
            builder.Append(PrepareContactInformationString(infoString: Lastname, ending: ending));
            builder.Append(PrepareContactInformationString(infoString: Nickname, ending: ending));
            builder.Append(PrepareContactInformationString(infoString: Title, ending: ending));
            builder.Append(PrepareContactInformationString(infoString: Company, ending: ending));
            builder.Append(PrepareContactInformationString(infoString: Address));
            builder = new StringBuilder(builder.ToString().Trim());
            builder.Append(ending + ending);

            //phone section
            builder.Append(PrepareContactInformationString(infoString: HomePhone, starting: "H: ",  ending: ending));
            builder.Append(PrepareContactInformationString(infoString: MobilePhone, starting: "M: ", ending: ending));
            builder.Append(PrepareContactInformationString(infoString: WorkPhone, starting: "W: ", ending: ending));
            builder.Append(PrepareContactInformationString(infoString: FaxPhone, starting: "F: "));
            builder = new StringBuilder(builder.ToString().Trim());
            builder.Append(ending + ending);

            //email section
            builder.Append(PrepareContactInformationString(infoString: Email, ending: ending));
            builder.Append(PrepareContactInformationString(infoString: Email2, ending: ending));
            builder.Append(PrepareContactInformationString(infoString: Email3, ending: ending));
            builder.Append(PrepareContactInformationString(infoString: Homepage.Replace("http://", ""), starting: "Homepage:", ending: ending));

            return builder.ToString().Trim();
        }
    }
}
