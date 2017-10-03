using System;
using System.Collections.Generic;

namespace _03.Request_Parser
{
    class Program
    {
        static void Main()
        {
            Dictionary<string, HashSet<string>> pathsMethods = new Dictionary<string, HashSet<string>>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                var tokens = input.Split(new char[] {'/'}, StringSplitOptions.RemoveEmptyEntries);
                var path = tokens[0];
                var method = tokens[1];

                if (!pathsMethods.ContainsKey(path))
                {
                    pathsMethods.Add(path, new HashSet<string>());
                }

                pathsMethods[path].Add(method.ToLower());
            }

            var requestTokens = Console.ReadLine().Split(new char[] {' ', '/'}, StringSplitOptions.RemoveEmptyEntries);
            var requestMethod = requestTokens[0].ToLower();
            var requestPath = requestTokens[1];
            var requestProtocol = requestTokens[2] + "/" + requestTokens[3];

            string responseCode = "404 Not Found";

            if (pathsMethods.ContainsKey(requestPath))
            {
                if (pathsMethods[requestPath].Contains(requestMethod))
                {
                    responseCode = "200 OK";
                }
            }

            //print response
            Console.WriteLine(requestProtocol + " " + responseCode);
            Console.WriteLine("Content-Length: " + (responseCode.Length - 4));
            Console.WriteLine("Content-Type: text/plain");
            Console.WriteLine();
            Console.WriteLine(responseCode.Substring(4));
        }
    }
}