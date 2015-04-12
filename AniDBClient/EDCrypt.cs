using System;
using System.IO;
using System.Security.Cryptography;

class EncDec
{
    //Encrypt file + create key
    public static void Encrypt(string fileIn, string fileOut, string Password)
    {
        FileStream fsIn = new FileStream(fileIn, FileMode.Open, FileAccess.Read);
        FileStream fsOut = new FileStream(fileOut, FileMode.OpenOrCreate, FileAccess.Write);

        PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });

        Rijndael alg = Rijndael.Create();
        alg.Key = pdb.GetBytes(32);
        alg.IV = pdb.GetBytes(16);

        CryptoStream cs = new CryptoStream(fsOut, alg.CreateEncryptor(), CryptoStreamMode.Write);

        int bufferLen = 4096;
        byte[] buffer = new byte[bufferLen];
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
    public static void Decrypt(string fileIn, string fileOut, string Password)
    {
        FileStream fsIn = new FileStream(fileIn, FileMode.Open, FileAccess.Read);
        FileStream fsOut = new FileStream(fileOut, FileMode.OpenOrCreate, FileAccess.Write);

        PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
        Rijndael alg = Rijndael.Create();

        alg.Key = pdb.GetBytes(32);
        alg.IV = pdb.GetBytes(16);

        CryptoStream cs = new CryptoStream(fsOut, alg.CreateDecryptor(), CryptoStreamMode.Write);

        int bufferLen = 4096;
        byte[] buffer = new byte[bufferLen];
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
