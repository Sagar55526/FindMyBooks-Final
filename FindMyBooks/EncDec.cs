using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for EncDec
/// </summary>
public static class EncDec
{
    public static string GetEncryptPassword(string Password)
    {
        try
        {
            Password = Password.Replace(" ", "+");
            byte[] key = ASCIIEncoding.ASCII.GetBytes("!)@(#*$&"); //Encrypt Key
            byte[] IV = ASCIIEncoding.ASCII.GetBytes("qwertyui"); //Initial Value
            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream,
            cryptoProvider.CreateEncryptor(key, IV), CryptoStreamMode.Write);
            StreamWriter writer = new StreamWriter(cryptoStream);
            writer.Write(Password);
            writer.Flush();
            cryptoStream.FlushFinalBlock();
            writer.Flush();
            return Convert.ToBase64String(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    public static string GetDecryptPassword(string Password)
    {
        try
        {
            Password = Password.Replace(" ", "+");
            byte[] key = ASCIIEncoding.ASCII.GetBytes("!)@(#*$&"); //Encrypt Key
            byte[] IV = ASCIIEncoding.ASCII.GetBytes("qwertyui"); //Initial Value
            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream memoryStream = new MemoryStream(Convert.FromBase64String(Password));
            CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoProvider.CreateDecryptor(key, IV), CryptoStreamMode.Read);
            StreamReader reader = new StreamReader(cryptoStream);
            return reader.ReadToEnd();
        }
        catch (Exception ex)
        {
            return Password;
        }
    }


    public static string GetEncrypt(string Password)
    {
        try
        {
            Password = Password.Replace(" ", "+");
            byte[] key = ASCIIEncoding.ASCII.GetBytes("!)@(#*$!"); //Encrypt Key
            byte[] IV = ASCIIEncoding.ASCII.GetBytes("qwertyui"); //Initial Value
            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream,
            cryptoProvider.CreateEncryptor(key, IV), CryptoStreamMode.Write);
            StreamWriter writer = new StreamWriter(cryptoStream);
            writer.Write(Password);
            writer.Flush();
            cryptoStream.FlushFinalBlock();
            writer.Flush();
            return Convert.ToBase64String(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    public static string GetDecrypt(string Password)
    {
        try
        {
            Password = Password.Replace(" ", "+");
            byte[] key = ASCIIEncoding.ASCII.GetBytes("!)@(#*$!"); //Encrypt Key
            byte[] IV = ASCIIEncoding.ASCII.GetBytes("qwertyui"); //Initial Value
            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream memoryStream = new MemoryStream(Convert.FromBase64String(Password));
            CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoProvider.CreateDecryptor(key, IV), CryptoStreamMode.Read);
            StreamReader reader = new StreamReader(cryptoStream);
            return reader.ReadToEnd();
        }
        catch (Exception ex)
        {
            return Password;
        }
    }
}