using System.Security.Cryptography;
using System.Text;
using GenericTools.Security.Core;

namespace GenericTools.Security.Persistance;

public class SimpleEncryptionServiceMd5 : ISimpleEncryptionService
{
    public string EncryptValue(string value)
    {
        //Encrypt String using MD5
        MD5 md5 = new MD5CryptoServiceProvider();
        var result = md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(value));
        return Convert.ToBase64String(result);
    }
}