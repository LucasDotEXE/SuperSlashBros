using System;
using System.Threading;

using ShareClientServer;

namespace Client
{
    class Program
    {
        static async void Main(string[] args)
        {
            Client client = new Client(1234, "Test");
            while (! await client.connect())
            {
                Thread.Sleep(10);
            }
            DataPacket message = new DataPacket(ShareClientServer.DataPacketType.MESSAGE);
            message.addParam(new Tuple<string, dynamic>("mes", "Hello Server How Do you do"));
            client.SendPacket(message);
            Console.ReadLine();
        }
    }
}
