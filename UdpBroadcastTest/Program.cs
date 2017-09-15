using System;
using System.Net.Sockets;
using System.Text;

namespace UdpBroadcastTest
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Sender");
// This constructor arbitrarily assigns the local port number.

            UdpClient udpClient = new UdpClient();
            udpClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            udpClient.Connect("192.168.1.126", 11000);
            try
            {
                string message = String.Empty;
                do
                {
                    message = Console.ReadLine();
// Sends a message to the host to which you have connected.
                    Byte[] sendBytes = Encoding.ASCII.GetBytes(message);

                    udpClient.Send(sendBytes, sendBytes.Length);
                } while (message != String.Empty);

                udpClient.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine("Press Any Key to Continue");
            Console.ReadKey();
        }
    }
}