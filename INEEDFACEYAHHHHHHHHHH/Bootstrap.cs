using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OMGIMHORNY_Chat_Server.Server;
using WebSocketSharp;
using WebSocketSharp.Server;


namespace OMGIMHORNY_Chat_Server.Server
{
    public class Bootstrap
    {
        public static void Main(string[] args)
        {
            Console.Title = "Chat Server";
            Console.WriteLine("Starting");
            
            Database.LoadDb();
            
            
            var WS = new WebSocketServer(13422, true);
            var Store = new X509Store("WebHosting", StoreLocation.LocalMachine);
            Store.Open(OpenFlags.ReadOnly);
            WS.SslConfiguration.ServerCertificate = Store.Certificates[0];
            WS.Log.Level = LogLevel.Info;
            WS.AddWebSocketService<Chat>("/chat");
            WS.Start();

            Console.WriteLine("ready");

            while (true) { Thread.Sleep(int.MaxValue);}
        }
    }
}
            
