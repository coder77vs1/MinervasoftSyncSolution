using System;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace ScanLauncher.Core
{
    public class CryptographyHelper
    {
        public class AES
        {
            public static void InitLastRequestIndex(int index = -1)
            {
                LastRequestIndex = index;
            }

            #region Encrypt

            public static string Encrypt(string context, int keyindex, bool isUrlEncode = true)
            {
                var publickey = GetPublickey(keyindex);
                var vectorkey = MakeVectorKey();
                return Encrypt(context, publickey, vectorkey, isUrlEncode);
            }

            public static string Encrypt(string context, int keyindex, string vectorkey, bool isUrlEncode = true)
            {
                var publickey = GetPublickey(keyindex);
                return Encrypt(context, publickey, vectorkey, isUrlEncode);
            }

            public static string Encrypt(string context, string publickey, bool isUrlEncode = true)
            {
                var vectorkey = MakeVectorKey();
                return Encrypt(context, publickey, vectorkey, isUrlEncode);
            }

            public static string Encrypt(string context, string publickey, string vectorkey, bool isUrlEncode = true)
            {
                using (var csp = new AesCryptoServiceProvider())
                {
                    ICryptoTransform e = GetCryptoTransform(csp, publickey, vectorkey, true);
                    byte[] inputBuffer = Encoding.UTF8.GetBytes(context);
                    byte[] outputBuffer = e.TransformFinalBlock(inputBuffer, 0, inputBuffer.Length);
                    string encrypted = Convert.ToBase64String(outputBuffer);

                    if (isUrlEncode)
                        encrypted = HttpUtility.UrlEncode(encrypted, Encoding.UTF8);

                    return encrypted;
                }
            }
            #endregion

            #region Decrypt

            public static string Decrypt(string context, int keyindex, bool isUrlEncode = true)
            {
                var publickey = GetPublickey(keyindex);
                var vectorkey = MakeVectorKey();
                return Decrypt(context, publickey, vectorkey, isUrlEncode);
            }

            public static string Decrypt(string context, int keyindex, string vectorkey, bool isUrlEncode = true)
            {
                var publickey = GetPublickey(keyindex);
                return Decrypt(context, publickey, vectorkey, isUrlEncode);
            }

            public static string Decrypt(string context, string publickey, bool isUrlEncode = true)
            {
                var vectorkey = MakeVectorKey();
                return Decrypt(context, publickey, vectorkey, isUrlEncode);
            }

            public static string Decrypt(string context, string publickey, string vectorkey, bool isUrlEncode = true)
            {
                if (isUrlEncode)
                    context = HttpUtility.UrlDecode(context, Encoding.UTF8);

                using (var csp = new AesCryptoServiceProvider())
                {
                    ICryptoTransform d = GetCryptoTransform(csp, publickey, vectorkey, false);
                    byte[] outputBuffer = Convert.FromBase64String(context);
                    byte[] decryptBuffer = d.TransformFinalBlock(outputBuffer, 0, outputBuffer.Length);
                    string decrypted = Encoding.UTF8.GetString(decryptBuffer);

                    return decrypted;
                }
            }

            #endregion

            #region Process

            public static int CreateKeyIndex()
            {
                Random r = new Random();
                int newKey = r.Next(0, 99);

                if (LastRequestIndex.Equals(newKey))
                    newKey = CreateKeyIndex();

                return newKey;
            }

            private static string MakeVectorKey()
            {
                return string.Format("sc{0}", DateTime.Now.ToString("yyyyMMdd"));
            }

            private static Rfc2898DeriveBytes MakeKey(string password)
            {
                byte[] keyBytes = System.Text.Encoding.UTF8.GetBytes(password);
                byte[] saltBytes = SHA512.Create().ComputeHash(keyBytes);

                return new Rfc2898DeriveBytes(keyBytes, saltBytes, 65536);
            }

            private static Rfc2898DeriveBytes MakeVector(string vector)
            {
                byte[] vectorBytes = System.Text.Encoding.UTF8.GetBytes(vector);
                byte[] saltBytes = SHA512.Create().ComputeHash(vectorBytes);

                return new Rfc2898DeriveBytes(vectorBytes, saltBytes, 65536);
            }

            private static ICryptoTransform GetCryptoTransform(AesCryptoServiceProvider aes, string publickey, string vectorkey, bool encryption)
            {
                Rfc2898DeriveBytes key = MakeKey(publickey);
                Rfc2898DeriveBytes vector = MakeVector(vectorkey);

                aes.BlockSize = 128;
                aes.KeySize = 256;

                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;
                aes.Key = key.GetBytes(32);
                aes.IV = vector.GetBytes(16);

                if (encryption)
                    return aes.CreateEncryptor();
                else
                    return aes.CreateDecryptor();
            }

            private static int LastRequestIndex = -1;
            public static string GetPublickey(int index)
            {
                if (LastRequestIndex.Equals(index))
                {
                    return string.Empty;
                }
                else
                {
                    LastRequestIndex = index;
                }

                string[] keys = {
                    "a7060358ae03408cbcdf5e710a0b77eb",
                    "6f17850570814e54baf3bd34d5d8cfc9",
                    "237b049f251348fdb280419006d7b347",
                    "b10319b4b0504a118a3b7783ba3cf263",
                    "860211f619274eaeae0041134a549062",
                    "b4be1497a9584c0ba671394b2987151c",
                    "7a00eb8651dc452495df13f6d559f48e",
                    "26e1c98fdaeb426d9ef75f6e29833525",
                    "1171e087293a4d1282cc139df7e7e092",
                    "78d9e7fd2a9d41809eb9b0f46d58224f",
                    "64ea109276224ac18d8c94432d2ecb3b",
                    "9a711ff0741245598fbed7754d0f02e1",
                    "42a46caa7dc24fe09657485e0855346e",
                    "034d1053a14540f39eca2bf1edb4d37c",
                    "1f12bc68bf1b49799b49b6ac256a4d3a",
                    "3dfd63ae51bc451191fb98078b31f4ba",
                    "01682848f748458e9ce10be543e2be71",
                    "a5b0c48052a04738ada3aef669b6e0b1",
                    "fc29034af70d456db09ab24fa51fda6a",
                    "9a5466f5e4c14cc3bdf8e95c92c3ad58",
                    "a080f795be7d44d8ba0c4738020fa409",
                    "321a2f724ee04e16a607dbd708b5576a",
                    "d8d21fd8f9654eb695e2fe11f81a9218",
                    "b6413fdbc54c4f44b92931071658247e",
                    "578861d43ae141679823c5c43ed84389",
                    "fe1a956801c341329375f3cbd534ecba",
                    "f2ee520c8f70443087fe6f62a937940d",
                    "1753e70c37b54e33af25f9c4dee8d9c0",
                    "845270b70fec4fbcbe6c6dcf8cb34bab",
                    "d71d034ec6654e37be6ebfeb8ad7efd8",
                    "761d717e1b3240bca15c26b710b0028d",
                    "2df82e2fca124453ae9a470bef6cfddc",
                    "4ee400fbb54b41bf95029b35e0f764c1",
                    "aa349f8d55f44a1a917da12a52cc3b22",
                    "9243ee1c7b27424392c8ca58fe340583",
                    "3ed6f28cc677480e8cd773666e1af6fa",
                    "9fcb3ac4062c4ad6aec6f87fef47d824",
                    "a661644db71e4401bc888cd32fe3cf73",
                    "ecfcc9b857854d8992195d7a94b94b6c",
                    "076515d0753a43b6a82240132f85351b",
                    "9da818fa534843bd8529ff5b366e7817",
                    "e026bf7e62a44543a845ab23324e0af9",
                    "76a8df8f671e49a3a3ba9ea5e13fd6a0",
                    "393cab9230c549e38c211fca40f5dd67",
                    "8998aac1595b414ca1cea8a4945ae0d2",
                    "4fd8994519c8455688213cdbb780eb46",
                    "2e7e67826cce4ac9ba2353862189d101",
                    "328de170b33f4dfb90135daea5d764c2",
                    "6081df65b7d043879db8f1fd77ec516c",
                    "86bec68fbc3949af97024ca951909d30",
                    "a5e124cce6134c64addc5c6ff570c47d",
                    "30b388625d174a478a98b48945e6778c",
                    "5942a69a3e9841cf869b7a0f19fcd6cc",
                    "a9624002d1944595a1987ea442afcffc",
                    "890e66930088452bae415dba25a7dacc",
                    "f973f15b3d1d423da6518e0def06bcdf",
                    "579dfea7c9e649949f2f0804ebbeff7a",
                    "4936adc0b9024e2fac0f4ea3949919fd",
                    "c0cb2c0f458a4ac4a1dd70cea02daae2",
                    "f77904e927004654af228e95f02816dc",
                    "31d4a0b4749e4ea7a2ff211c7f8b2493",
                    "2f893c6308134073873028cce0ca3b0c",
                    "13480baf4c414b809891d89d88909987",
                    "8dec1ee2132346c5b1a295ea48825723",
                    "2a4c3c15b902479caa97d7e8aba1e384",
                    "e57e2f1b5af842f0841977151d822dee",
                    "fd2835cd61664750aab29ebc0079a022",
                    "eb18350355e841c5be17291bb74c74f0",
                    "5545f5c85fa44635a5fd30e02b1e77e0",
                    "dad29c90aadd4976977ebb3579ea1f88",
                    "02a92f031a06435fa6884c3a66eca626",
                    "5a139ff9a7644b62b56eb89b4e4be5db",
                    "435504d76f004329af92c5a446731e9a",
                    "73b8c41072e14a87b93373287ac6eb2b",
                    "1edbb8cde183416f8d86c6da05846cab",
                    "2155640de2b34c42824313bccc183183",
                    "24886ecec7b7426eb26a275fc85826d3",
                    "75fc47d60f1541a0857f04fdae746d3c",
                    "d119e9611bf0408ba967e9d6adb65aad",
                    "7431585d0c09452cb0c2562ff6018a37",
                    "02229de7b4d14e46b80c411ca563a421",
                    "a1aa490f69b44a1aa2e60164ccbde3a3",
                    "d92328129790486f82d31c29e5f502f9",
                    "22d15ecf4e0f4139a1a60d7a0f22a194",
                    "ed63678009c1405bb52ce9ac4650ec40",
                    "f303b29a1a2042ef816714a99e6126d2",
                    "501e0f11250c492ea6cc656af74cdb3a",
                    "fb4d946f0aed41139367da93f9f4d720",
                    "e729efc6c8354c57a792776c213f8615",
                    "20df58693be04c2bafc5147797c1c54b",
                    "c55de505bb29486980cda74d9bd99aec",
                    "eccac011a5f348dbbc4a702dfc2ba652",
                    "067fc7fb736d4729a64be79b2582e0a6",
                    "30b2e4eab1a7464f8839fd5fa10d7a7a",
                    "ed93d0ee77964047bec42f783bfc5844",
                    "a2c6f053680943d49ce47941d8f7d578",
                    "66554096f7704541a6e850f880422582",
                    "cfc5f550b23145b9ba825352b55abed6",
                    "32e26619a7224ec292180bcccf643408",
                    "04e9270df11a7467fc7f54e37be6ebfe",
                };

                return string.Format(keys[LastRequestIndex]);
            }

            #endregion
        }
    }
}

