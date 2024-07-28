using System.Net;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread thread = new Thread(DownloadFileUrl);
            Console.Write("Enter link of file you want to download: ");
            string url = Console.ReadLine();

            thread.Start(url);

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"From Main " + i);
                Thread.Sleep(100);
            }
        }
        public static void DownloadFileUrl(object obj)
        {
            string url = obj.ToString();
            string file = Path.GetFileName(url);
            using (var client = new WebClient())
            {
                client.DownloadFile(url, file);
            }
            Console.WriteLine("File is downloaded");
        }
    }
}
