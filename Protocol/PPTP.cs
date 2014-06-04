using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Infrastructure;

namespace Protocol
{
    public class PPTP : IVpnProtocol
    {
        public string IpAddress { get; set; }
        public int Port { get; set; }
        public PPTP(string ipAddress, int port) 
        {
            IpAddress = ipAddress;
            Port = port;
        }
        public PPTP() { }
        public void Connect() 
        {
            Thread.Sleep(900);
        }

        public void Disconnect()
        {
            Thread.Sleep(500);
        }
    }
}
