using System.Net;
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
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
                return response.StatusCode.ToString();
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}