using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    internal class ContactData
    {
        private string firstname;
        private string middlename = "";
        private string homePhoneNumber = "";

        public ContactData(string firstname)
        {
            this.firstname = firstname;
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
