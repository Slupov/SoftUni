using System;
using System.Net;

namespace _02.Validate_URL
{
    class Program
    {
        static void Main()
        {
            var url = WebUtility.UrlDecode(Console.ReadLine());
            var uri = new Uri(url);

            try
            {
                var scheme = uri.Scheme;
                var host = uri.Host;
                var port = uri.Port;
                var path = uri.AbsolutePath;
                var query = uri.Query;
                var fragment = uri.Fragment;

                if (scheme == "https")
                {
                    if (port == 80)
                    {
                        throw new ArgumentException("Port doesn't match the protocol");
                    }
                }
                else if (scheme == "http")
                {
                    if (port == 443)
                    {
                        throw new ArgumentException("Port doesn't match the protocol");
                    }
                }

                Console.WriteLine("Protocol: " + scheme);
                Console.WriteLine("Host: " + host);
                Console.WriteLine("Port: " + port);
                Console.WriteLine("Path: " + path);

                if (!string.IsNullOrEmpty(query))
                {
                    Console.WriteLine("Query: " + query.Substring(1));
                }
                if (!string.IsNullOrEmpty(fragment))
                {
                    Console.WriteLine("Fragment: " + fragment.Substring(1));
                }
            }
            catch (Exception ex)
            {
                if (ex is UriFormatException || ex is ArgumentException)
                {
                    Console.WriteLine("Invalid URL");
                    return;
                }

                throw;
            }
        }
    }
}