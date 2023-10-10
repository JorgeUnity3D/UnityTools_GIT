using System;
using System.Security.Cryptography;
using System.Text;

public class Encrypter
{

    string encryptKey;

    public Encrypter()
    {
        encryptKey = Md5Sum("~Q!w2e3r4M=n9b8v7···@KyEcCpGmn");
    }

    public string Encrypt(string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            return "";
        }
        //For KeyStorage
        byte[] keyArray;
        //For TextStorage
        byte[] textArray = Encoding.UTF8.GetBytes(text);

        //Generate Key for Hash with MD5
        MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
        keyArray= md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(encryptKey));
        md5.Clear();

        //3DAS
        TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
        tdes.Key = keyArray;
        tdes.Mode = CipherMode.ECB;
        tdes.Padding= PaddingMode.PKCS7;
        
        //Convert string
        ICryptoTransform cryptoTransform = tdes.CreateEncryptor();

        //Result
        byte[] resultArray = cryptoTransform.TransformFinalBlock(textArray, 0, textArray.Length);
        tdes.Clear();

        //Return as string

        return Convert.ToBase64String(resultArray, 0 , resultArray.Length);
    }

    public string Decrypt(string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            return "";
        }
        //For KeyStorage
        byte[] keyArray;
        //For TextStorage
        byte[] textArray = Convert.FromBase64String(text);

        //Generate Key for Hash with MD5
        MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
        keyArray = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(encryptKey));
        md5.Clear();

        //3DAS
        TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
        tdes.Key = keyArray;
        tdes.Mode = CipherMode.ECB;
        tdes.Padding = PaddingMode.PKCS7;

        //Convert string
        ICryptoTransform cryptoTransform = tdes.CreateDecryptor();

        //Result
        byte[] resultArray = cryptoTransform.TransformFinalBlock(textArray, 0, textArray.Length);
        tdes.Clear();

        //Return as string

        return UTF8Encoding.UTF8.GetString(resultArray);
    }

    private string Md5Sum(string toEncrypt)
    {
        UTF8Encoding utf8 = new UTF8Encoding();
        byte[] bytes = utf8.GetBytes(toEncrypt);
        MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
        byte[] hashBytes = md5.ComputeHash(bytes);
        string hasString = "";
        for (int i = 0; i < hashBytes.Length; i++)
        {
            hasString += Convert.ToString(hashBytes[i], 16).PadLeft(2, '0');
        }
        return hasString.PadLeft(32, '0'); ;
    }
}

