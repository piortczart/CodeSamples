using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using SomeSamples.Chapter2;

namespace SomeSamples.Chapter3
{
    public class Sample_3_23
    {
        public static void Do()
        {
            UnicodeEncoding byteConverter = new UnicodeEncoding();
            SHA256 sha256 = SHA256.Create();

            string data = "A paragraph of text!";
            byte[] hashA = sha256.ComputeHash(byteConverter.GetBytes(data));
            Console.WriteLine(Convert.ToBase64String(hashA));
            data = "A paragraph of text?";
            byte[] hashB = sha256.ComputeHash(byteConverter.GetBytes(data));
            data = "A paragraph of text!";
            Console.WriteLine(Convert.ToBase64String(hashB));
            Console.ReadLine();
            byte[] hashC = sha256.ComputeHash(byteConverter.GetBytes(data));
            Console.WriteLine(Convert.ToBase64String(hashC));

            Console.WriteLine(hashA.SequenceEqual(hashB)); // First not euqal to second.
            Console.WriteLine(hashA.SequenceEqual(hashC)); // First equal to last.
        }
    }
}