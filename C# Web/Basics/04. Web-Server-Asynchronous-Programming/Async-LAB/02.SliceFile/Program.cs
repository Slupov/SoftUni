using System;
using System.IO;
using System.Threading.Tasks;

namespace _02.SliceFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string videoPath = Console.ReadLine();
            string destination = Console.ReadLine();
            int pieces = int.Parse(Console.ReadLine());

            Slice(videoPath, destination, pieces);

            Console.WriteLine("Anything else?");

            while (true)
            {
                Console.ReadLine();
            }
        }

        private static void SliceAsync(string sourceFile, string destinationPath, int parts)
        {
            Task.Run(() => { Slice(sourceFile, destinationPath, parts); });
        }

        private static void Slice(string sourceFile, string destinationPath, int parts)
        {
            //check if folder exists
            if (!Directory.Exists(destinationPath))
            {
                Directory.CreateDirectory(destinationPath);
            }

            using (var source = new FileStream(sourceFile, FileMode.Open))
            {
                FileInfo fileInfo = new FileInfo(sourceFile);

                long partLength = (source.Length / parts) + 1;
                long currentByte = 0;

                for (int currentPart = 0; currentPart < parts; currentPart++)
                {
                    string filePath = string.Format("{0}/Part-{1}{2}",
                        destinationPath, currentPart + 1, fileInfo.Extension);

                    using (var destination = new FileStream(filePath, FileMode.Create))
                    {
                        byte[] buffer = new byte[partLength];

                        while (currentByte <= partLength * currentPart)
                        {
                            int readBytesCount = source.Read(buffer, 0, buffer.Length);

                            if (readBytesCount == 0)
                            {
                                break;
                            }

                            destination.Write(buffer, 0, readBytesCount);
                            currentByte += readBytesCount;
                        }
                    }
                }
            }

            Console.WriteLine("Slice complete.");
        }
    }
}