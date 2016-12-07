using System;
using System.Security.Cryptography;

namespace SomeSamples.Chapter3
{
    public class Sample_3_18
    {
        public static void Do()
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            string publicKeyXml = rsa.ToXmlString(false);
            string privateKeyXml = rsa.ToXmlString(true);
            Console.WriteLine(publicKeyXml);
            Console.ReadKey();
            Console.WriteLine(privateKeyXml);
        }
    }
}