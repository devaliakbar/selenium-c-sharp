using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace SeleniumCSharp.Utilities
{
    public static class TestUtilities
    {
        private static readonly Random _random = new();

        public static string GenerateRandomString(int size = 6)
        {
            var builder = new StringBuilder(size);

            char offset = 'a';
            const int lettersOffset = 26;

            for (var i = 0; i < size; i++)
            {
                var character = (char)_random.Next(offset, offset + lettersOffset);
                builder.Append(character);
            }

            return builder.ToString().ToLower();
        }

        public static string GenerateRandomEmail()
        {
            int randomInt = _random.Next(1000);
            return "username" + randomInt + "@gmail.com";
        }



        public static string GetHttpStatus(string url)
        {
            try
            {
                initiateSSLTrust();

                HttpWebRequest webReq;
                webReq = (HttpWebRequest)WebRequest.Create(url);
                webReq.UseDefaultCredentials = true;
                webReq.UserAgent = "Link Checker";
                webReq.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
                HttpWebResponse response = (HttpWebResponse)webReq.GetResponse();

                return response.StatusCode.ToString();

            }

            catch (Exception e)
            {
                return e.Message;
            }

        }


        private static void initiateSSLTrust()
        {
            try
            {
                ServicePointManager.ServerCertificateValidationCallback =
                    new RemoteCertificateValidationCallback(
                        delegate (object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
                        {
                            return true;
                        });
            }
            catch (Exception)
            {
                // ActivityLog.InsertSyncActivity(ex);
            }
        }
    }
}