using System;
using System.Text;
using System.IO;
using System.Diagnostics;
using Microsoft.Win32;
using System.Security.Cryptography;
namespace Utility
{
    // the best palce to put this calss in business layer
    public static class clsUtil
    {
        const string KeyPath = @"HKEY_CURRENT_USER\SOFTWARE\LocalDrivingLicenseManger";

        public static string GenerateGuid()
        {
            return Guid.NewGuid().ToString();
        }

        public static bool CreateFolderIfDoesNotExist(string FolderPath)
        {
            // FolderPath is with name of new directory
            if (!Directory.Exists(FolderPath))
            {
                try
                {
                    Directory.CreateDirectory(FolderPath);
                    return true;

                }
                catch (Exception)
                {
                    //MessageBox.Show("Error creating folder: " + ex.Message);
                   

                    return false;
                }
            }
            return true;
        }

        public static string ReplaceFileNameWithGUID(string FileName)
        {
            FileInfo info = new FileInfo(FileName);
            return GenerateGuid() + info.Extension;
        }

        public static bool CopyImageToFileAndNameWithGuid(ref string sourceFile)
        {
            string destFile = @"C:\DVLDImagePath\";
            if (!CreateFolderIfDoesNotExist(destFile))
            {
                return false;
            }
            string copyTo = destFile + ReplaceFileNameWithGUID(sourceFile);
            bool Result = false;
            try
            {
                File.Copy(sourceFile, copyTo);
                Result = true;
                sourceFile = copyTo;
            }
            catch (Exception)
            {

                throw;
            }
            return Result;


        }

        public static bool WriteOnRegistryCurrentMachine(string ValueName, string ValueData)
        {
            try
            {
                Registry.SetValue(KeyPath, ValueName, ValueData);
                return true;
            }
            catch (Exception)
            {

                return false;

            }

        }

        public static object ReadFromRegistryCurrentMachine(string ValueName)
        {
            try
            {
                return Registry.GetValue(KeyPath, ValueName, null) ;
            }
            catch (Exception)
            {

                return null;
            }


        }
        /// <summary>
        ///  Function that is Responsible to log all error happened during run time 
        /// </summary>
        /// <param name="e">is exception happened</param>
        public static void LogErrors(Exception e)
        {
            string Sourc = "DVLD";
            if(!EventLog.Exists(Sourc))
            { 
                    EventLog.CreateEventSource(Sourc, "Application");
            }

            string EventContent=e.Message+'\n'+e.StackTrace;

            try
            {
                EventLog.WriteEntry(Sourc, EventContent, EventLogEntryType.Error,e.HResult);

            }
            catch (Exception)
            {

                
            }

        }


        public static string ComuteHash(string Input)
            {
            using(SHA256 SHA= SHA256.Create())
            {
                // calculate hash as bytes
                byte[] HashedByte = SHA.ComputeHash(Encoding.UTF8.GetBytes(Input));
                // convert from bytes to Hexadecimal 
                return BitConverter.ToString(HashedByte).Replace("-", "").ToLower();

            }
        }
        // using Advanced Encryption Stander 
        // Symmetric Encryption
        public static string Encrypt(string plainText, string key)
        {
            using (Aes aesAlg = Aes.Create())
            {
                // Set the key and IV for AES encryption
                aesAlg.Key = Encoding.UTF8.GetBytes(key);
                //IV number of bits
                aesAlg.IV = new byte[aesAlg.BlockSize / 8];


                // Create an encryptor
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);


                // Encrypt the data
                using (var msEncrypt = new System.IO.MemoryStream())
                {
                    using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    using (var swEncrypt = new System.IO.StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(plainText);
                    }


                    // Return the encrypted data as a Base64-encoded string
                    return Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
        }
        public static int name;
        public static string Decrypt(string cipherText, string key)
        {
            using (Aes aesAlg = Aes.Create())
            {
                // Set the key and IV for AES decryption
                aesAlg.Key = Encoding.UTF8.GetBytes(key);
                aesAlg.IV = new byte[aesAlg.BlockSize / 8];


                // Create a decryptor
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);


                // Decrypt the data
                using (var msDecrypt = new System.IO.MemoryStream(Convert.FromBase64String(cipherText)))
                using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                using (var srDecrypt = new System.IO.StreamReader(csDecrypt))
                {
                    // Read the decrypted data from the StreamReader
                    return srDecrypt.ReadToEnd();
                }
            }
        }
    }

}

