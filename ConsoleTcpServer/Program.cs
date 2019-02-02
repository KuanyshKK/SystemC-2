using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTcpServer
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                TcpListener tcpListener =
             new TcpListener(IPAddress.Parse("127.0.0.1"), 34561);
                tcpListener.Start();
                Console.WriteLine("Listening ...");

                TcpClient client = tcpListener.AcceptTcpClient();

                Console.WriteLine("IPAdress: {0}, Port: {1}",
                    ((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString(),
                    ((IPEndPoint)client.Client.RemoteEndPoint).Port.ToString());

                using (NetworkStream stream = client.GetStream())
                {
                    byte[] data = new byte[1024];
                    stream.Read(data, 0, data.Length);

                    Console.WriteLine("Data: {0}",
                        Encoding.UTF8.GetString(data));
                }

                tcpListener.Stop();

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
         
        }
    }
}
