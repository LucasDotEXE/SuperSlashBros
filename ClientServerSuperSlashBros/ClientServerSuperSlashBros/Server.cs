using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ClientServer;
using ClientServerConnectionLib;

namespace ClientServerSuperSlashBros
{
    class Server
    {
        IPAddress localhost;
        private int port;
        TcpListener listener;
        private String serverName;
        private readonly double VERSION_NR = 1.1;

        private bool listening;

        public Server(int port, String servername)
        {
            this.port = port;
            serverName = servername;
        }

        public async void startListen()
        {
            if (listening)
            {
                Console.WriteLine("Server was already listening");
                return;
            }

            bool ipIsOk = IPAddress.TryParse("127.0.0.1", out localhost);
            if (!ipIsOk)
            {
                Console.WriteLine("ip adres kan niet geparsed worden.");
                Environment.Exit(1);
            }

            this.listener = new TcpListener(localhost, port);

            listener.Start();
            Console.WriteLine($@"
                ========================================
                  Server started listening at {DateTime.Now}
                ========================================");

            this.listening = true;
            while (this.listening)
            {
                TcpClient client = await listener.AcceptTcpClientAsync();
                Console.WriteLine($"Accepted client at {DateTime.Now}");

                if (client != null)
                {
                    Thread thread = new Thread(HandleClientThread);
                    thread.Start(client);
                }
                    
            }
            Console.WriteLine($"{serverName} stopped listening");
        }

        public void stopListening()
        {
            this.listening = false;
        }


        public async void HandleClientThread(Object obj)
        {
            TcpClient client = obj as TcpClient;


            NetworkStream networkStream = client.GetStream();

            ClientServerUtil.WriteTextMessage(networkStream, $@"{this.serverName} {this.VERSION_NR}");
            String clientInfoResponce = await ClientServerUtil.ReadTextMessage(client.GetStream());
            String[] clientInfo = clientInfoResponce.Split();
            if (double.Parse(clientInfo[1]) == this.VERSION_NR)
            {
                Console.WriteLine($"Client {clientInfo[0]} connected succesfully with Version {clientInfo[1]}");
            } else
            {
                Console.WriteLine($"Fuck Client has wrong version NR, will comence Yeeting of client");
            }

        }

    }

    class ServerPacketHandler : DataPacketHandler
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

