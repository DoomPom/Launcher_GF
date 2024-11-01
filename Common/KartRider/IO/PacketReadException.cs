using System;

namespace KartLauncher.Common.KartRider.IO
{
    public sealed class PacketReadException : Exception
    {
        public PacketReadException(string message) : base(message)
        {
        }
    }
}