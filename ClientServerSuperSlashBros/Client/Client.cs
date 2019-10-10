using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using ClientServer;
using ClientServerConnectionLib;
using ShareClientServer;

namespace Client
{
    
    class Client
    {
        private String clientName;
        IPAddress localhost;
        private int port;
        private static readonly double VERSION_NR = 1.1;

        TcpClient client;
        private bool connected {
            get { return connected; }
            set { this.connected = value; }
        }

        public Client(int port, string name)
        {
            this.port = port;
            this.clientName = name;
            connected = false;

            
        }

        public async Task<bool> connect()
        {
            if (connected)
            {
                Console.WriteLine($"Client {clientName} is already connected to a server");
            } else
            {
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
                    this.client = client;
                    this.connected = true;
                }
                else
                {

                    Console.Write("ERROR: Incompatible VersionNR's" +
                        "\r\nDisconneced ");
                    Console.WriteLine(disconnect() ? "Succesfully" : "Unsuccesfully");
                    this.connected = false;
                }
            }
            return connected;
        }

        public void SendPacket(DataPacket dataPacket)
        {
            ClientServerUtil.WriteTextMessage(client.GetStream(), dataPacket.getProtocolJson());
        }

        public bool disconnect()
        {
            return true;
        }
    }

    class ClientPacketHandler : DataPacketHandler
    {
        public override void HandleHit(dynamic parameters)
        {
            throw new NotImplementedException();
        }

        public override void HandleMessage(dynamic parameters)
        {
            throw new NotImplementedException();
        }

        public override void HandlePlayerPos(dynamic parameters)
        {
            throw new NotImplementedException();
        }
    }
}
