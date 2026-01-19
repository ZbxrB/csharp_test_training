using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class TestBase
    {
        protected ApplicationManager applicationManager;
        public static Random rnd = new Random();

        [SetUp]
        public void SetupApplicationManager()
        {
            applicationManager = ApplicationManager.GetInstance();
        }

        public static string GenerateRandomString(int maxLengh)
        {
            int l = Convert.ToInt32(rnd.NextDouble() * maxLengh);
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < l; i++)
            {
                builder.Append(Convert.ToChar(Convert.ToInt32(rnd.NextDouble() * 223 + 32)));
            }
            return builder.ToString();
        }

    }
}
