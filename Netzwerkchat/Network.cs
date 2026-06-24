using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Net;
using System.Diagnostics;

namespace Netzwerkchat
{
    internal class Network
    {
        public Thread bcReceiver;

        public  Network()
        {
            bcReceiver = new Thread(new ThreadStart(receiveBroadcast));
            bcReceiver.IsBackground = true;
            bcReceiver.Start();
        }
        public void sendBroadcast(string message)
        {
            UdpClient udp = new UdpClient();
            udp.Connect(IPAddress.Parse("192.168.2.255"), 1234);
            byte[] data = Encoding.UTF8.GetBytes(message);
            udp.Send(data, data.Length);
        }

        public void receiveBroadcast()
        {
            UdpClient udp = new UdpClient(1234);
            IPEndPoint ipendpoint = new IPEndPoint(IPAddress.Any, 1234);
            byte[] b = udp.Receive(ref ipendpoint);
            Trace.WriteLine(Encoding.UTF8.GetString(b));
            string zeichen = Encoding.UTF8.GetString(b);
            Trace.WriteLine(zeichen);
            udp.Close();
        }

    }
}





