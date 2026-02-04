using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class TestBase
    {
        public static bool PERFORM_LONG_UI_CHECKS = true;

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
                builder.Append(Convert.ToChar(32 + Convert.ToInt32(rnd.NextDouble() * 65)));
            }
            return builder.ToString();
        }

    }
}
