using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using ClientServer;

namespace Client
{
    
    class Client
    {
        private String clientName;
        IPAddress localhost;
        private int port;
        private static readonly double VERSION_NR = 1.1;

        TcpClient client;
        private bool connected;

        public Client(int port, string name)
        {
            this.port = port;
            this.clientName = name;
            connected = false;

            
        }

        public async void connect()
        {
            if (connected)
            {
                Console.WriteLine($"Client {clientName} is already connected to a server");
                return;
            } else
            {

            }

            if (!IPAddress.TryParse("127.0.0.1", out localhost))
            {
                Console.WriteLine("ip adres kan niet geparsed worden.");
                Environment.Exit(1);
            }
            TcpClient client = new TcpClient(localhost.ToString(), port);

            String serverInfoResponce = await ClientServerUtil.ReadTextMessage(client.GetStream());
            ClientServerUtil.WriteTextMessage(client.GetStream(), $"{this.clientName} {VERSION_NR}");
            String[] serverInfo = serverInfoResponce.Split();
            if (double.Parse(serverInfo[1]) == VERSION_NR)
            {
                Console.WriteLine($"You succesfully connected to {serverInfo[0]} with Version {serverInfo[1]}");
            } else
            {

                Console.Write("ERROR: Incompatible VersionNR's" +
                    "\r\nDisconneced ");
                Console.WriteLine(disconnect() ? "Succesfully" : "Unsuccesfully") ;
            }




        }

        public bool disconnect()
        {
            return true;
        }
    }
}
