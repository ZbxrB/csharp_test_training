using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_tests_autoit
{
    public class ApplicationManager
    {

        private GroupHelper groupHelper;

        public ApplicationManager()
        {
            groupHelper = new GroupHelper(this);
        }

        public void Stop()
        {

        }

        public GroupHelper Groups
        {
            get
            {
                return groupHelper;
            }
        }
    }
}
