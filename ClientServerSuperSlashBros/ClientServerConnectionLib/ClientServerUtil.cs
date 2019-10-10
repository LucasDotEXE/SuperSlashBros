#define l

using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ClientServer
{
    public class ClientServerUtil  {
        public static Encoding encoding = Encoding.UTF8;

        public async static Task<string> ReadTextMessage(NetworkStream networkStream)
        {
            StreamReader stream = new StreamReader(networkStream, encoding);
            return  stream.ReadLine();
        }

        public async static void WriteTextMessage(NetworkStream networkStream, string message)
        {
            StreamWriter stream = new StreamWriter(networkStream, encoding);
            stream.WriteLine(message);
            stream.Flush();
        }
    }
}
