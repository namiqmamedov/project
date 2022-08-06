using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Core.Helpers
{

    public static class PasswordHasher
    {
        public static string Encrypt(string password)
        {
            var publicKey = "<RSAKeyValue><Modulus>21wEnTU+mcD2w0Lfo1Gv4rtcSWsQJQTNa6gio05AOkV/Er9w3Y13Ddo5wGtjJ19402S71HUeN0vbKILLJdRSES5MHSdJPSVrOqdrll/vLXxDxWs/U0UT1c8u6k/Ogx9hTtZxYwoeYqdhDblof3E75d9n2F0Zvf6iTb4cI7j6fMs=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";

            var testData = Encoding.UTF8.GetBytes(password);

            using (var rsa = new RSACryptoServiceProvider(1024))

            {

                rsa.FromXmlString(publicKey.ToString());

                var encryptedData = rsa.Encrypt(testData, true);

                var base64Encrypted = Convert.ToBase64String(encryptedData);

                return base64Encrypted;

                rsa.PersistKeyInCsp = false;

            }
        }

        public static string Decrypt(string hashedPassword)
        {
            var privateKey = "<RSAKeyValue><Modulus>21wEnTU+mcD2w0Lfo1Gv4rtcSWsQJQTNa6gio05AOkV/Er9w3Y13Ddo5wGtjJ19402S71HUeN0vbKILLJdRSES5MHSdJPSVrOqdrll/vLXxDxWs/U0UT1c8u6k/Ogx9hTtZxYwoeYqdhDblof3E75d9n2F0Zvf6iTb4cI7j6fMs=</Modulus><Exponent>AQAB</Exponent><P>/aULPE6jd5IkwtWXmReyMUhmI/nfwfkQSyl7tsg2PKdpcxk4mpPZUdEQhHQLvE84w2DhTyYkPHCtq/mMKE3MHw==</P><Q>3WV46X9Arg2l9cxb67KVlNVXyCqc/w+LWt/tbhLJvV2xCF/0rWKPsBJ9MC6cquaqNPxWWEav8RAVbmmGrJt51Q==</Q><DP>8TuZFgBMpBoQcGUoS2goB4st6aVq1FcG0hVgHhUI0GMAfYFNPmbDV3cY2IBt8Oj/uYJYhyhlaj5YTqmGTYbATQ==</DP><DQ>FIoVbZQgrAUYIHWVEYi/187zFd7eMct/Yi7kGBImJStMATrluDAspGkStCWe4zwDDmdam1XzfKnBUzz3AYxrAQ==</DQ><InverseQ>QPU3Tmt8nznSgYZ+5jUo9E0SfjiTu435ihANiHqqjasaUNvOHKumqzuBZ8NRtkUhS6dsOEb8A2ODvy7KswUxyA==</InverseQ><D>cgoRoAUpSVfHMdYXW9nA3dfX75dIamZnwPtFHq80ttagbIe4ToYYCcyUz5NElhiNQSESgS5uCgNWqWXt5PnPu4XmCXx6utco1UVH8HGLahzbAnSy6Cj3iUIQ7Gj+9gQ7PkC434HTtHazmxVgIR5l56ZjoQ8yGNCPZnsdYEmhJWk=</D></RSAKeyValue>";

            var testData = Encoding.UTF8.GetBytes(hashedPassword);

            using (var rsa = new RSACryptoServiceProvider(1024))
            {

                var base64Encrypted = hashedPassword;

                rsa.FromXmlString(privateKey);

                var resultBytes = Convert.FromBase64String(base64Encrypted);
                var decryptedBytes = rsa.Decrypt(resultBytes, true);
                var decryptedData = Encoding.UTF8.GetString(decryptedBytes);
                return decryptedData.ToString();


                rsa.PersistKeyInCsp = false;

            }

        }
        //    static void Main(string[] args)
        //    {
        //        var text = "This is my password to protect";

        //        //var encryptedText = EncryptPlainTextToCipherText(text);
        //        //var decryptedText = DecryptCipherTextToPlainText(text);


        //        //Console.WriteLine("Passed Text = " + text);
        //        //Console.WriteLine("EncryptedText = " + encryptedText);
        //        //Console.WriteLine("DecryptedText = " + decryptedText);
        //        //Console.ReadLine();
        //    }

        //    private const string SecurityKey = "toor";
        //    public static string EncryptPlainTextToCipherText(string password)
        //    {
        //        // Getting the bytes of Input String.
        //        byte[] toEncryptedArray = UTF8Encoding.UTF8.GetBytes(password);

        //        MD5CryptoServiceProvider objMD5CryptoService = new MD5CryptoServiceProvider();
        //        //Gettting the bytes from the Security Key and Passing it to compute the Corresponding Hash Value.
        //        byte[] securityKeyArray = objMD5CryptoService.ComputeHash(UTF8Encoding.UTF8.GetBytes(SecurityKey));
        //        //De-allocatinng the memory after doing the Job.
        //        objMD5CryptoService.Clear();

        //        var objTripleDESCryptoService = new TripleDESCryptoServiceProvider();
        //        //Assigning the Security key to the TripleDES Service Provider.
        //        objTripleDESCryptoService.Key = securityKeyArray;
        //        //Mode of the Crypto service is Electronic Code Book.
        //        objTripleDESCryptoService.Mode = CipherMode.ECB;
        //        //Padding Mode is PKCS7 if there is any extra byte is added.
        //        objTripleDESCryptoService.Padding = PaddingMode.PKCS7;


        //        var objCrytpoTransform = objTripleDESCryptoService.CreateEncryptor();
        //        //Transform the bytes array to resultArray
        //        byte[] resultArray = objCrytpoTransform.TransformFinalBlock(toEncryptedArray, 0, toEncryptedArray.Length);
        //        objTripleDESCryptoService.Clear();
        //        return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        //    }

        //    public static string Encrypt(string PlainText)
        //    {
        //        // Getting the bytes of Input String.
        //        byte[] toEncryptedArray = UTF8Encoding.UTF8.GetBytes(PlainText);

        //        MD5CryptoServiceProvider objMD5CryptoService = new MD5CryptoServiceProvider();
        //        //Gettting the bytes from the Security Key and Passing it to compute the Corresponding Hash Value.
        //        byte[] securityKeyArray = objMD5CryptoService.ComputeHash(UTF8Encoding.UTF8.GetBytes(SecurityKey));
        //        //De-allocatinng the memory after doing the Job.
        //        objMD5CryptoService.Clear();

        //        var objTripleDESCryptoService = new TripleDESCryptoServiceProvider();
        //        //Assigning the Security key to the TripleDES Service Provider.
        //        objTripleDESCryptoService.Key = securityKeyArray;
        //        //Mode of the Crypto service is Electronic Code Book.
        //        objTripleDESCryptoService.Mode = CipherMode.ECB;
        //        //Padding Mode is PKCS7 if there is any extra byte is added.
        //        objTripleDESCryptoService.Padding = PaddingMode.PKCS7;


        //        var objCrytpoTransform = objTripleDESCryptoService.CreateEncryptor();
        //        //Transform the bytes array to resultArray
        //        byte[] resultArray = objCrytpoTransform.TransformFinalBlock(toEncryptedArray, 0, toEncryptedArray.Length);
        //        objTripleDESCryptoService.Clear();
        //        return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        //    }

        //    //This method is used to convert the Encrypted/Un-Readable Text back to readable  format.
        //    public static string Decrypt(string hashedPassword)
        //    {
        //        byte[] toEncryptArray = Convert.FromBase64String(hashedPassword);
        //        MD5CryptoServiceProvider objMD5CryptoService = new MD5CryptoServiceProvider();

        //        //Gettting the bytes from the Security Key and Passing it to compute the Corresponding Hash Value.
        //        byte[] securityKeyArray = objMD5CryptoService.ComputeHash(UTF8Encoding.UTF8.GetBytes(SecurityKey));
        //        objMD5CryptoService.Clear();

        //        var objTripleDESCryptoService = new TripleDESCryptoServiceProvider();
        //        //Assigning the Security key to the TripleDES Service Provider.
        //        objTripleDESCryptoService.Key = securityKeyArray;
        //        //Mode of the Crypto service is Electronic Code Book.
        //        objTripleDESCryptoService.Mode = CipherMode.ECB;
        //        //Padding Mode is PKCS7 if there is any extra byte is added.
        //        objTripleDESCryptoService.Padding = PaddingMode.PKCS7;

        //        var objCrytpoTransform = objTripleDESCryptoService.CreateDecryptor();
        //        //Transform the bytes array to resultArray
        //        byte[] resultArray = objCrytpoTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
        //        objTripleDESCryptoService.Clear();

        //        //Convert and return the decrypted data/byte into string format.
        //        return UTF8Encoding.UTF8.GetString(resultArray);
        //    }
        //}

    }
}

