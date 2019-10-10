using System;
using System.Threading;
using System.Threading.Tasks;
using ShareClientServer;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client(1234, "Test");

            connectClient(client).Wait();
            client.StartListening();
            
            DataPacket message = new DataPacket(DataPacketType.MESSAGE);
            message.addParam("message", "Hello Server How Do you do");
            client.SendPacket(message);


            client.SendPacket(new DataPacket(DataPacketType.STOP_CONNECTION));
            Thread.Sleep(100);
        }

        private async static Task connectClient(Client client)
        {
            while (await isntConnected(client))
            {
                Thread.Sleep(10);
            }
        }

        static async Task<bool> isntConnected(Client client)
        {
            return !await client.connect();
        }
    }
}
