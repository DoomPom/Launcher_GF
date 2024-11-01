using KartLauncher.Data;
using System;
using System.Net;
using System.Net.Sockets;

namespace KartLauncher.Data.Server
{
    public class RouterListener
    {
        public static string sIP;

        public static int port;

        public static string forceConnect;

        public static IPEndPoint client;

        public static IPEndPoint CurrentUDPServer { get; set; }

        public static string ForceConnect { get; set; }

        public static TcpListener Listener { get; private set; }

        public static SessionGroup MySession { get; set; }

        static RouterListener()
        {
            string str = "127.0.0.1";
            sIP = str;
            int str1 = 39312;
            port = str1;
        }

        public static int[] DataTime()
        {
            DateTime dt = DateTime.Now;
            DateTime time = new DateTime(1900, 1, 1, 0, 0, 0);
            TimeSpan t = dt.Subtract(time);
            double totalSeconds = dt.TimeOfDay.TotalSeconds / 4;
            int Month = (dt.Year - 1900) * 12;
            int MonthCount = Month + dt.Month;
            double tempResult = (double)MonthCount / 2;
            int oddMonthCount;
            if (tempResult % 1 != 0)
            {
                oddMonthCount = (int)tempResult + 1;
            }
            else
            {
                oddMonthCount = (int)tempResult;
            }
            return new int[] { t.Days, (int)totalSeconds, oddMonthCount };
        }

        public static void OnAcceptSocket(IAsyncResult ar)
        {
            try
            {
                Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                Socket clientSocket = Listener.EndAcceptSocket(ar);
                forceConnect = sIP;
                if (ForceConnect == "" ? false : ForceConnect != "0.0.0.0")
                {
                    forceConnect = ForceConnect;
                }
                MySession = new SessionGroup(clientSocket, null);
                client = clientSocket.RemoteEndPoint as IPEndPoint;
                Console.WriteLine("Client: " + client.Address.ToString() + ":" + client.Port.ToString());
                GameSupport.PcFirstMessage();
            }
            catch
            {
            }
            Listener.BeginAcceptSocket(new AsyncCallback(OnAcceptSocket), null);
        }

        public static void Start()
        {
            Console.WriteLine("Load server IP : {0}:{1}", sIP, port);
            ForceConnect = "";
            Listener = new TcpListener(IPAddress.Parse(sIP), port);
            Listener.Start();
            Listener.BeginAcceptSocket(new AsyncCallback(OnAcceptSocket), null);
            CurrentUDPServer = new IPEndPoint(IPAddress.Parse(sIP), 39311);
        }
    }
}