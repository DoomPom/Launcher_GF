using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    internal struct KartDateTime
    {
        public ushort Days;    // 自 1900 年1月1日到现在的天数。
        public ushort Seconds; // 当天从0点开始 的秒数 / 4。 [0 , 86400/4);
        

        /// <summary>
        /// DateTime转换的时间基点。
        /// </summary>
        public static readonly long UEpochTicks = new DateTime(1900, 1, 1).Ticks;
        public KartDateTime(long ticks)
        {
            long t = (ticks - UEpochTicks) / TimeSpan.TicksPerSecond;
            Days = (ushort)(t / 86400);
            Seconds = (ushort)((t % 86400 / 4) & 0xFFFF);
        }
        /// <summary>
        /// 转换为 DateTime
        /// </summary>
        /// <returns></returns>
        public DateTime ToDateTime()
        {
            long ticks = (Days * 86400L + (Seconds << 2)) * TimeSpan.TicksPerSecond + UEpochTicks;
            return new DateTime(ticks);
        }

        public static KartDateTime Now { get => new KartDateTime(DateTime.Now.Ticks); }
    }
