using System;
using System.Text;


    internal class Hash
    {
        public static uint GetHash(string str)
        {
           return Adler32.ToAsciiHash(str);
        }
    }
    public class Adler32
    {

        public static uint ToAsciiHash(string str)
        {
            return ComputeHash(Encoding.ASCII.GetBytes(str));
        }
        /// <summary>Performs the hash algorithm on given data array.</summary>
        /// <param name="bytes">Input data.</param>
        /// <param name="checksum">Init checksum</param>
        public static uint ComputeHash(byte[] bytes, uint checksum = 0)
        {
            return ComputeHash(bytes, 0, bytes.Length, checksum);
        }
        /// <summary>ADLEPerforms the hash algorithm on given data array.</summary>
        /// <param name="bytes">Input data.</param>
        /// <param name="start">The position to begin reading from.</param>
        /// <param name="length">How many bytes in the bytes to read.</param>
        /// <param name="checksum">Init checksum</param>
        public static uint ComputeHash(byte[] bytes, int start, int length, uint checksum = 0)
        {
            int n;
            uint s1 = checksum & 0xFFFF;
            uint s2 = checksum >> 16;

            while (length > 0)
            {
                n = (3800 > length) ? length : 3800;
                length -= n;
                while (--n >= 0)
                {
                    s1 += (uint)(bytes[start++] & 0xFF);
                    s2 += s1;
                }
                s1 %= 65521;
                s2 %= 65521;
            }
            checksum = (s2 << 16) | s1;
            return checksum;
        }
        public static uint GenerateSimple(byte[] bytes)
        {
            uint num = 1;
            uint num1 = 0;
            byte[] numArray = bytes;
            for (int i = 0; i < (int)numArray.Length; i++)
            {
                num = (num + numArray[i]) % 65521;
                num1 = (num1 + num) % 65521;
            }
            return ((num1 << 16) + num);
        }
    }

