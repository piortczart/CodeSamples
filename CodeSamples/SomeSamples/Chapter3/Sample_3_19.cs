using System;
using System.Security.Cryptography;
using System.Text;

namespace SomeSamples.Chapter3
{
    public class Sample_3_19
    {
        public static void Do()
        {
            string publicKeyXml;
            string privateKeyXml;
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                publicKeyXml = rsa.ToXmlString(false);
                privateKeyXml = rsa.ToXmlString(true);
            }

            UnicodeEncoding byteConverter = new UnicodeEncoding();
            byte[] dataToEncrypt = byteConverter.GetBytes("My Secret Data!");
            byte[] encryptedData;
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(publicKeyXml);
                encryptedData = rsa.Encrypt(dataToEncrypt, false);
            }
            byte[] decryptedData;
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(privateKeyXml);
                decryptedData = rsa.Decrypt(encryptedData, false);
            }
            string decryptedString = byteConverter.GetString(decryptedData);
            Console.WriteLine(decryptedString); // Displays: My Secret Data!
        }
    }
}