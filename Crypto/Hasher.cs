using System;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using HashAlgorithmExample.Crypto;

namespace HashAlgorithmExample.Util {

	public static class Hasher {

        #region Base64
        public static string GetBase64(string input) {

			var plainTextBytes = Encoding.UTF8.GetBytes(input);
			return Convert.ToBase64String(plainTextBytes);
		}
		#endregion

		#region MD5
		public static string GetMD5(string input) {

            MD5 md5 = MD5.Create();
            byte[] data = md5.ComputeHash(Encoding.UTF8.GetBytes(input));

            md5.Dispose();

            return BytesToHash(data);
        }
		#endregion

		#region SHA1
		public static string GetSHA1(string input) {

            SHA1 sha1 = SHA1.Create();
            byte[] data = sha1.ComputeHash(Encoding.UTF8.GetBytes(input));

            sha1.Dispose();

            return BytesToHash(data);
        }
        #endregion

        #region SHA384
        public static string GetSHA384(string input) {

            SHA384 sha384 = SHA384.Create();
            byte[] data = sha384.ComputeHash(Encoding.UTF8.GetBytes(input));

            sha384.Dispose();

            return BytesToHash(data);
        }
        #endregion

        #region SHA256
        public static string GetSHA256(string input) {

            SHA256 sha256 = SHA256.Create();
            byte[] data = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));

            sha256.Dispose();

            return BytesToHash(data);
        }
		#endregion

		#region SHA512
		public static string GetSHA512(string input) {

            SHA512 sha512 = SHA512.Create();
            byte[] data = sha512.ComputeHash(Encoding.UTF8.GetBytes(input));

            sha512.Dispose();

            return BytesToHash(data);
        }
		#endregion

		#region Whirlpool
		public static string GetWhirlpool(string input) {

            Whirlpool whirlpool = new Whirlpool();
            byte[] data = whirlpool.ComputeHash(Encoding.UTF8.GetBytes(input));

            whirlpool.Dispose();

            return BytesToHash(data);
        }
        #endregion

        #region Streebog
        public static string GetStreebog(string input) {

            return Streebog.GetHashCode(input, 512);
        }
        #endregion

        private static string BytesToHash(byte[] data) {

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++) {

                sBuilder.Append(data[i].ToString("x2", CultureInfo.CurrentCulture));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();

        }
    }
}
