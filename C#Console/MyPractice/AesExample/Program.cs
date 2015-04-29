using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string exitChar = string.Empty;
            Console.WriteLine("Press x to exit");
            do
            {
                Console.WriteLine("Enter phrase to encrypt");
                string plainText = Console.ReadLine(); ;
                byte[] key = Convert.FromBase64String(ConfigurationManager.AppSettings["aesKey"]);
                byte[] byteValue = Convert.FromBase64String(ConfigurationManager.AppSettings["aesValue"]);
                //Console.WriteLine(Convert.FromBase64String(key));
                //Console.WriteLine(Convert.FromBase64String(byteValue));

                Task<String> mainTask = Task.Run<string>(() =>
                {
                    return Encrypt(plainText, key, byteValue).Result;
                });
                string cipherText = mainTask.Result;
                Console.WriteLine(cipherText);
                exitChar = Console.ReadLine();
            } while (exitChar != "x");

            //Task<string> decTask = Task.Run<string>(() => Decrypt(cipherText, key, byteValue).Result);
            //string diCipherText = decTask.Result;
            //Console.WriteLine(diCipherText);
        }

        public static async Task<string> Encrypt(string plainText, byte[] key, byte[] value)
        {
            string hexResult = string.Empty;
            var aesManaged = AesManaged.Create();
            using (aesManaged)
            {
                ICryptoTransform transform = aesManaged.CreateEncryptor(key, value);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, transform, CryptoStreamMode.Write))
                    {
                        byte[] plainByte = Encoding.Default.GetBytes(plainText);
                        await cs.WriteAsync(plainByte, 0, plainByte.Length);
                    }
                    byte[] result = ms.ToArray();
                    hexResult = Convert.ToBase64String(result);
                }
            }
            return hexResult;
        }

        public static async Task<string> Decrypt(string cipherText, byte[] key, byte[] value)
        {
            string plainText = string.Empty;
            using (var aesManaged = AesManaged.Create())
            {
                ICryptoTransform transform = aesManaged.CreateDecryptor(key, value);
                using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(cipherText)))
                {
                    using (var cryptoStream = new CryptoStream(ms, transform, CryptoStreamMode.Read))
                    {
                        using (var srReader = new StreamReader(cryptoStream))
                        {
                            plainText = srReader.ReadToEnd();
                        }
                    }
                }
            }
            return plainText;
        }
    }
}
