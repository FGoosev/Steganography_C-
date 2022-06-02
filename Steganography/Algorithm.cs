using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EncryptionCompare
{
    public class Algorithm
    {
        protected SymmetricAlgorithm sa;
        
        public string Name { get; private set; }

        protected byte[] Cipherbytes { get; set; }

        public Algorithm(SymmetricAlgorithm sa, string name)
        {
            this.sa = sa;
            this.Name = name;
        }

        public void InitKey(byte[] key)
        {
            //sa.Key = key;
            sa.Padding = PaddingMode.Zeros;
            sa.GenerateKey();
        }

        public void SetCipherMode(CipherMode cm)
        {
            sa.Mode = cm;
        }

        public string Encryption(string content)
        {              
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, sa.CreateEncryptor(), CryptoStreamMode.Write);

            byte[] plainbytes = Encoding.UTF8.GetBytes(content);

            cs.Write(plainbytes, 0, plainbytes.Length);
            cs.Close();

            Cipherbytes = ms.ToArray();
            ms.Close();

            return Encoding.UTF8.GetString(Cipherbytes);
        }
        public byte[] Encryption(byte[] plainbytes)
        {
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, sa.CreateEncryptor(), CryptoStreamMode.Write);

            cs.Write(plainbytes, 0, plainbytes.Length);
            cs.Close();

            Cipherbytes = ms.ToArray();
            ms.Close();

            return Cipherbytes;
        }
        public string Decryption()
        {    
            MemoryStream ms = new MemoryStream(Cipherbytes);
            CryptoStream cs = new CryptoStream(ms, sa.CreateDecryptor(), CryptoStreamMode.Read);

            byte[] plainbytes = new byte[Cipherbytes.Length];

            cs.Read(plainbytes, 0, Cipherbytes.Length);
            cs.Close();

            cs.Close();
            ms.Close();
            
            return Encoding.UTF8.GetString(plainbytes);
        }
        public string Decryption(string cyphermessage)
        {
            byte[] data_to_decrypt = Encoding.UTF8.GetBytes(cyphermessage);
            MemoryStream ms = new MemoryStream(data_to_decrypt);
            CryptoStream cs = new CryptoStream(ms, sa.CreateDecryptor(), CryptoStreamMode.Read);

            byte[] plainbytes = new byte[data_to_decrypt.Length];

            cs.Read(plainbytes, 0, data_to_decrypt.Length);
            cs.Close();

            cs.Close();
            ms.Close();

            return Encoding.UTF8.GetString(plainbytes);
        }
        public byte[] Decryption(byte[] cypherbytes)
        {
            MemoryStream ms = new MemoryStream(Cipherbytes);
            CryptoStream cs = new CryptoStream(ms, sa.CreateDecryptor(), CryptoStreamMode.Read);

            byte[] plainbytes = new byte[cypherbytes.Length];

            cs.Read(plainbytes, 0, cypherbytes.Length);
            cs.Close();

            cs.Close();
            ms.Close();

            return plainbytes;
        }

        public static CipherMode GetCipherMode(int val)
        {
            switch (val)
            {
                case 0: return CipherMode.ECB;
                case 1: return CipherMode.CBC;
                case 2: return CipherMode.CFB;
                case 3: return CipherMode.OFB;
                default: return CipherMode.CTS;
            }
            
        }

        public void Encryption_Decryption(string content)
        {
            Encryption(content);
            Decryption();
        }
    }
}
