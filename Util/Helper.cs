using System;
using System.Linq;
using System.Text;

namespace HashAlgorithmExample.Util {

    public static class Helper {

        /// <summary>
        /// Converts a string to its hexadecimal form
        /// </summary>
        /// <param name="input">Input string</param>
        public static string ToHexString(this string str) {

            byte[] ba = Encoding.Default.GetBytes(str);
            var hexString = BitConverter.ToString(ba);
            hexString = hexString.Replace("-", "");
            return hexString;
        }

        /// <summary>
        /// Converting a byte array to a hex string
        /// </summary>
        /// <param name="input">Input string</param>
        public static string ToHexString(this byte[] input) {

            return BitConverter.ToString(input.Reverse().ToArray()).Replace("-", "").ToLower();
        }

        /// <summary>
        /// Converts a hex string to a byte array
        /// </summary>
        /// <param name="input">Input string</param>
        public static byte[] ToByteArray(this string input) {

            byte[] bytes = new byte[input.Length / 2];

            for (int i = 0; i < bytes.Length; i++) {

                bytes[i] = Convert.ToByte(input.Substring((bytes.Length - i - 1) * 2, 2), 16);
            }
            return bytes;
        }
    }
}