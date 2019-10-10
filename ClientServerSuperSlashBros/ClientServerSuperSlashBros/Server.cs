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
using Newtonsoft.Json;

namespace ClientServerSuperSlashBros
{
    class Server
    {
        IPAddress localhost;
        private int port;
        TcpListener listener;
        private String serverName;

        private List<TcpClient> clients;


        private readonly double VERSION_NR = 1.1;

        private bool listening;

        public Server(int port, String servername)
        {
            this.port = port;
            serverName = servername;
            this.clients = new List<TcpClient>();
           
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

            String[] clientInfo = await getClientInfo(networkStream, client);

            if (!isCorrectClient(clientInfo))
            {
                Console.WriteLine($"Fuck Client has wrong version NR, will comence Yeeting of client");
            } else
            {
                Console.WriteLine($"Client {clientInfo[0]} connected succesfully with Version {clientInfo[1]}");
                this.clients.Add(client);
                DataPacketHandler packetHandler = new ServerPacketHandler(this, client, clientInfo);
                bool keepReading = true;
                while (keepReading)
                {
                    String message = await ClientServerUtil.ReadTextMessage(networkStream);
                    keepReading = packetHandler.handlePacket(message);
                }
                this.clients.Remove(client);
                //return a message to say stop has been succesfully accepted;
            }
        }

        private async Task<String[]> getClientInfo(NetworkStream networkStream, TcpClient client)
        {
            ClientServerUtil.WriteTextMessage(networkStream, $@"{this.serverName} {this.VERSION_NR}");
            String clientInfoResponce = await ClientServerUtil.ReadTextMessage(client.GetStream());
            return clientInfoResponce.Split();
        }

        private bool isCorrectClient(String[] clientInfo)
        {   
            return double.Parse(clientInfo[1]) == this.VERSION_NR;
        }

    }

    class ServerPacketHandler : DataPacketHandler
    {
        private Server server;
        private TcpClient client;
        private String[] info;

        public ServerPacketHandler(Server server, TcpClient client, String[] info)
        {
            this.server = server;
            this.client = client;
            this.info = info;
        }

        public override void HandleHit(dynamic parameters)
        {
            throw new NotImplementedException();
        }

        public override void HandleMessage(dynamic parameters)
        {
            String message = parameters.message;
            Console.WriteLine($"Message Recieved from {info[0]}: {message}");
        }

        public override void HandlePlayerPos(dynamic parameters)
        {
            throw new NotImplementedException();
        }

        public override bool HandleStop(dynamic parameters)
        {

            Console.WriteLine($"{info[0]} has disconnected");
            return false;
        }
    }
}

