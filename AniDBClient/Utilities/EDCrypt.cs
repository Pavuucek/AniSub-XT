using System.IO;
using System.Security.Cryptography;

namespace AniDBClient
{
    internal class EncDec
    {
        //Encrypt file + create key
        public static void Encrypt(string fileIn, string fileOut, string password)
        {
            var fsIn = new FileStream(fileIn, FileMode.Open, FileAccess.Read);
            var fsOut = new FileStream(fileOut, FileMode.OpenOrCreate, FileAccess.Write);

            var pdb = new PasswordDeriveBytes(password,
                new byte[] {0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76});

            var alg = Rijndael.Create();
            alg.Key = pdb.GetBytes(32);
            alg.IV = pdb.GetBytes(16);

            var cs = new CryptoStream(fsOut, alg.CreateEncryptor(), CryptoStreamMode.Write);

            const int bufferLen = 4096;
            var buffer = new byte[bufferLen];
            int bytesRead;

            do
            {
                bytesRead = fsIn.Read(buffer, 0, bufferLen);
                cs.Write(buffer, 0, bytesRead);
            } while (bytesRead != 0);


            cs.FlushFinalBlock();
            cs.Close();

            fsIn.Close();
        }

        //Decrypt file with key
        public static void Decrypt(string fileIn, string fileOut, string password)
        {
            var fsIn = new FileStream(fileIn, FileMode.Open, FileAccess.Read);
            var fsOut = new FileStream(fileOut, FileMode.OpenOrCreate, FileAccess.Write);

            var pdb = new PasswordDeriveBytes(password,
                new byte[] {0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76});
            var alg = Rijndael.Create();

            alg.Key = pdb.GetBytes(32);
            alg.IV = pdb.GetBytes(16);

            var cs = new CryptoStream(fsOut, alg.CreateDecryptor(), CryptoStreamMode.Write);

            const int bufferLen = 4096;
            var buffer = new byte[bufferLen];
            int bytesRead;

            do
            {
                bytesRead = fsIn.Read(buffer, 0, bufferLen);
                cs.Write(buffer, 0, bytesRead);
            } while (bytesRead != 0);

            cs.FlushFinalBlock();
            cs.Close();

            fsIn.Close();
        }
    }
}