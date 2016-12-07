using System;
using System.Security.Cryptography;

namespace SomeSamples.Chapter3
{
    public class Sample_3_20
    {
        public static void Do()
        {
            string containerName = "SecretContainer";
            CspParameters csp = new CspParameters {KeyContainerName = containerName};
            byte[] encryptedData;
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(csp))
            {
                byte[] dataToEncrypt = {1, 5, 8};
                encryptedData = rsa.Encrypt(dataToEncrypt, false);
            }
            Console.WriteLine("Encrypted.");
        }
    }
}