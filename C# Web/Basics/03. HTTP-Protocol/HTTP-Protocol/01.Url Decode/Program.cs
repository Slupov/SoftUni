using System;
using System.Net;

namespace _01.Url_Decode
{
    class Program
    {
        static void Main()
        {
            string url = Console.ReadLine();
            Console.WriteLine(WebUtility.UrlDecode(url));
        }
    }
}