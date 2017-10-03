using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace _03.Simple_Web_Server
{
    class Program
    {
        static void Main()
        {
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            int port = 1300;
            TcpListener listener = new TcpListener(ip,port);
            listener.Start();

            Console.WriteLine("Server started.");
            Console.WriteLine($"Listening to TCP clients at 127.0.0.1:{port}");

            var task = Task.Run(() => ConnectWithTcpClient(listener));
            task.Wait();
        }

        public static async Task ConnectWithTcpClient(TcpListener listener)
        {
            while (true)
            {
                Console.WriteLine("Waiting for client...");

                using (var client = await listener.AcceptTcpClientAsync())
                {
                    Console.WriteLine("Client connected.");

                    //read the request and print it on the console
                    byte[] buffer = new byte[1024];
                    await client.GetStream().ReadAsync(buffer, 0, buffer.Length);

                    var message = Encoding.UTF8.GetString(buffer).Trim('\0');
                    Console.WriteLine(message);

                    byte[] data = Encoding.UTF8.GetBytes("HTTP/1.1 200 OK\nContent-Type: text/plain\n\nHello from server!");
                    await client.GetStream().WriteAsync(data, 0, data.Length);

                    //close connection
                    Console.WriteLine("Closing connection");
                }
            }
        }
    }
}