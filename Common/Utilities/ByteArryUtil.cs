using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


internal class ByteArryUtil
{
    public static byte[] HexStringToByteArray(string value)
    {
        if (value == null)
        {
            throw new ArgumentNullException("value");
        }
        String[] aa = value.Split(' ');
        byte[] arr = new byte[aa.Length];
        for (int i = 0; i < aa.Length; i++)
        {
            arr[i] = byte.Parse(aa[i], NumberStyles.HexNumber);
        }
        return arr;
    }
    public static string ToHexString(byte[] value)
    {
        return ToHexString(value, 0, value.Length);
    }
    public static string ToHexString(byte[] value, int offset, int length)
    {
        if (value == null)
        {
            throw new ArgumentNullException("value");
        }
        StringBuilder sb = new StringBuilder();
        if (length - offset > 0)
        {
            sb.Append(String.Format("{0:X2}", value[offset]));
        }
        for (int i = offset + 1; i < length; i++)
        {
            sb.Append(String.Format(" {0:X2}", value[i]));
        }
        return sb.ToString();
    }
}
