using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Server
    {
        public string Name { get; set; }
        public string IpAddress { get; set; }
        public int Port { get; set; }

        public Server(string name, string ipAddress, int port)
        {
            Name = name;
            IpAddress = ipAddress;
            Port = port;
        }
    }
}
