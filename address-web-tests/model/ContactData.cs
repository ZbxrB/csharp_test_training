using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string firstname;
        private string lastname;
        private string middlename = "";
        private string homePhoneNumber = "";

        public ContactData(string firstname, string lastname)
        {
            this.firstname = firstname;
            this.lastname = lastname;
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

            return firstname == other.Firstname
                                    && lastname == other.Lastname; 
        }

        public override int GetHashCode()
        {
            return (firstname+lastname).GetHashCode();
        }

        public override string ToString()
        {
            return "firstname = " + firstname + "; lastname = " + lastname;
        }

        public int CompareTo(ContactData other)
        {
            if (other is null)
            {
                return 1;
            }
            return 
        }


        public string Firstname
        {
            get
            {
                return this.firstname;
            }
            set
            {
                this.firstname = value;
            }
        }

        public string Lastname
        {
            get
            {
                return this.lastname;
            }
            set
            {
                this.lastname = value;
            }
        }

        public string Middlename
        {
            get
            {
                return this.middlename;
            }
            set
            {
                this.middlename = value;
            }
        }

        public string HomePhoneNumber
        {
            get
            {
                return this.homePhoneNumber;
            }
            set
            {
                this.homePhoneNumber = value;
            }
        }
    }
}
