using ClientServerConnectionLib;
using ShareClientServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientServerSuperSlashBros
{
    class Program
    {
        static void Main(string[] args)
        {
            Server server = new Server(1234, "GameServer");
            server.startListen();

            //DataPacketHandler handler = new ServerPacketHandler();
            //DataPacket packet = new DataPacket(DataPacketType.MESSAGE);
            //handler.handlePacket(packet.getProtocolJson());
            //Console.ReadLine();

            Console.ReadLine();
        }
    }
}
