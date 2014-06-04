using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Infrastructure;

namespace Protocol
{
    public class OpenVPN : IVpnProtocol
    {
        public string IpAddress { get; set; }
        public int Port { get; set; }

        public OpenVPN(string ipAddress, int port) 
        {
            IpAddress = ipAddress;
            Port = port;
        }

        public OpenVPN() { }
        public void Connect() 
        {
            Thread.Sleep(500);
        }

        public void Disconnect()
        {
            Thread.Sleep(700);
        }
    }
}
