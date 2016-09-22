using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SomeSamples
{
    public static class Sample_1_18
    {
        public static void Do()
        {
            string result = DownloadContent().Result;

            Console.WriteLine(result);

            Console.ReadKey();
        }

        private static async Task<string> DownloadContent()
        {
            using (HttpClient client = new HttpClient())
            {
                string result = await client.GetStringAsync("http://icanhazip.com");
                return result;
            }
        }
    }
}
