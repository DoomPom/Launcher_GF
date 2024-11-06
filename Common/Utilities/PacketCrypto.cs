using System;

public static class PacketCrypto
{
    public const int KEYLEN = 4;
    public static uint[] KEY = new uint[KEYLEN] { 347277256, 2361332396, 604215233, 4089260480 };

    public static uint Checksum(byte[] bytes)
    {
        return Checksum(bytes, 0, bytes.Length);
    }
    public static uint Checksum(byte[] bytes, int offsize,int length)
    {
        uint sum = 0;
        // 使用非安全代码来固定字节数组并获取其指针  
        unsafe
        {
            fixed (byte* bytePtr = bytes)
            {
                // 将指针转换为int*类型，以便我们可以将其视为int数组  
                uint* ptr = (uint*)(bytePtr + offsize);
                int len = (int)(length >> 4);
                len <<= 2;
                for (int i = 0;i < len; i++, ptr++)
                {
                    sum ^= *ptr;
                }
                // 处理最后16字节
                len = length % 16;
                byte* bptr = (byte*)ptr;
                for (int i = 0; i < len; i++, bptr++)
                {
                    sum = (uint)(sum ^ (*bptr) << i);
                }
            }
        }
        return sum;
     }
    public static void HashEncrypt(byte[] bytes, uint nKey)
    {
        HashEncrypt(bytes, 0, bytes.Length,nKey);
    }
    public static void HashEncrypt(byte[] bytes, int offsize, int length, uint nKey)
    {
        uint[] Key = new uint[KEYLEN];
        for (uint i = 0;i < KEYLEN;i++)
        {
            Key[i] = nKey ^ KEY[i];
        }
       // 使用非安全代码来固定字节数组并获取其指针  
        unsafe
        {
            fixed (byte* bytePtr = bytes)
            {
                // 将指针转换为int*类型，以便我们可以将其视为int数组  
                uint* ptr = (uint*)(bytePtr+ offsize);
                int len = (int)(length >> 2);
                for (int i = 0; i < len; i++, ptr++)
                {
                    *ptr ^= Key[i % 4];
                }
                byte[] En = BitConverter.GetBytes(Key[len % 4]);

                // 处理最后4字节
                len <<= 2;
                byte* p = (byte*)ptr;
                len = (int)(length - len);
                for (int i=0; i < len;i++,p++)
                {
                    *p ^= En[i];
                }
            }
        }
    }
}