using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using ClientServer;

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
            
            Console.ReadLine();
        }
    }
}
