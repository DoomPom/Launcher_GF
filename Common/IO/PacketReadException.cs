using System;

namespace KartLauncher.Common.IO
{
    public sealed class PacketReadException : Exception
    {
        public PacketReadException(string message) : base(message)
        {
        }
    }
}