using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Net.FtpClient;



namespace mantis_tests
{
    public class FtpHelper : HelperBase
    {
        public FtpClient client;

        public FtpHelper(ApplicationManager manager) : base(manager)
        {
            client = new FtpClient();
            client.Credentials = new System.Net.NetworkCredential("mantis", "mantis");
            client.Connect();
        }

        public void BackUpFile(String path)
        {

        }

        public void RestoreBackUpFile(String path)
        {

        }

        public void Upload(String path, Stream localFile)
        {

        }
    }
}
