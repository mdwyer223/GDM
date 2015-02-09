using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using System.Web.Script.Serialization;

namespace Solo
{
    public class Server
    {
        public static TcpClient ClientSocket
        {
            get { return ClientSocket; }
        }
        static TcpClient clientSocket;
        public Server()
            : base()
        {
            //create connection
            try
            {
                clientSocket = new TcpClient(ServerConstants.IP, ServerConstants.PORT);
            }
            catch (Exception e)
            {
                Game1.passMessage(e.Message);
            }
        }

        public static string read()
        {
            return "";
        }

        public static void write(string operation)
        {

        }

        public static void write(object operation)
        {
            string json = new JavaScriptSerializer().Serialize(operation);
            Server.write(json);
        }
    }
}
