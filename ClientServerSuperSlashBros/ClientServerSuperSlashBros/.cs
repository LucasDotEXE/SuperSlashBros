using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ClientServerSuperSlashBros
{
    class ServerClientUtil
    {

        public static void SendMessage(String message, NetworkStream stream)
        {
            byte[] data = Encoding.ASCII.GetBytes(message);
            stream.Write(data, 0, data.Length);
        }

        public async static Task<String> ReadMessage(TcpClient client)
        {
            //get the incoming data through a network stream
            NetworkStream nwStream = client.GetStream();

            int recieveBuffersize = client.ReceiveBufferSize;

            byte[] buffer = new byte[recieveBuffersize];

            //read incoming stream
            int bytesRead = nwStream.Read(buffer, 0, recieveBuffersize);

            return Encoding.ASCII.GetString(buffer, 0, recieveBuffersize);
        }
    }
}
