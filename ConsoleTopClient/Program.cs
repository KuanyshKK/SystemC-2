using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTopClient
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                IPEndPoint endPoint =
             new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1115);

                TcpClient tcpClient = new TcpClient(endPoint);

                tcpClient.Connect(IPAddress.Parse("127.0.0.1"), 34561);

                Console.WriteLine("Write message: ");
                byte[] data = Encoding.UTF8.GetBytes(Console.ReadLine());

                NetworkStream networkStream = tcpClient.GetStream();
                networkStream.Write(data, 0, data.Length);

                tcpClient.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
         
        }
    }
}
