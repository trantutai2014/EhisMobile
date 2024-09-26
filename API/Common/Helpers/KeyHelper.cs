using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MDP.Common.Helpers
{
  public class KeyHelper
  {

    private static readonly byte[] Key = new byte[16];
    // RandomNumberGenerator.GetBytes(Key);

    private static readonly byte[] IV = Convert.FromBase64String("X8T5NlRxAi9e7M+Jjf3eZw==");

    public static string Encrypt(string plainText)
    {
      using (Aes aes = Aes.Create())
      {
        aes.Key = Key;
        aes.IV = IV;

        ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

        using (MemoryStream ms = new MemoryStream())
        {
          using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
          {
            using (StreamWriter sw = new StreamWriter(cs))
            {
              sw.Write(plainText);
            }
          }
          return Convert.ToBase64String(ms.ToArray());
        }
      }
    }

    public static string Decrypt(string cipherText)
    {
      using (Aes aes = Aes.Create())
      {
        aes.Key = Key;
        aes.IV = IV;

        ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
        using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(cipherText)))
        {
          using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
          {
            using (StreamReader sr = new StreamReader(cs))
            {
              return sr.ReadToEnd();
            }
          }
        }
      }
    }
  }
}
