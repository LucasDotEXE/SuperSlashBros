using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClientServer;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client(1234, "Test");
            client.connect();
            Console.ReadLine();
        }
    }
}
