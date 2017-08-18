using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace Metin_Belgesi_Şifreleme
{
    class password
    {
        public string anahtar = @"!&+qwsdf!123126+";
        public string kelime = @"/&+/57YjzW?{zjMr";
        AesCryptoServiceProvider sif = new AesCryptoServiceProvider();
        public string sifrele(string metin)
        {

            sif.BlockSize = 128;//256 bit
            sif.KeySize = 128; //256 bit

            sif.IV = Encoding.UTF8.GetBytes(anahtar); //şifrelemek istedigimiz metnin hangi karakterlerde olması.
            sif.Key = Encoding.UTF8.GetBytes(kelime); //şifredeki karakterler
            sif.Mode = CipherMode.CBC;
            sif.Padding = PaddingMode.ANSIX923;
            byte[] dizi = Encoding.Unicode.GetBytes(metin);

            using (ICryptoTransform sifrelemek = sif.CreateEncryptor())
            {
                byte[] dizi2 = sifrelemek.TransformFinalBlock(dizi, 0, dizi.Length);
                return Convert.ToBase64String(dizi2);
            }


        }
        public string cozumle(string metin2)
        {
            sif.BlockSize = 128;//256 bit
            sif.KeySize = 128; //256 bit
            sif.IV = Encoding.UTF8.GetBytes(anahtar);
            sif.Key = Encoding.UTF8.GetBytes(kelime);
            sif.Mode = CipherMode.CBC;
            sif.Padding = PaddingMode.ANSIX923;
            byte[] hedef = System.Convert.FromBase64String(metin2);
            using (ICryptoTransform cozmek = sif.CreateDecryptor())
            {
                byte[] hedef2 = cozmek.TransformFinalBlock(hedef, 0, hedef.Length);
                return Encoding.Unicode.GetString(hedef2);
            }


        }
    }
}
