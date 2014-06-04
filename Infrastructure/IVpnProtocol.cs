using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    /*public enum Status
    {
        Connecting,
        Connected,
        Disconnecting,
        Disconnected
    }*/

    public enum VPNProtocols
    {
        OpenVPN,
        PPTP
    }

    public interface IVpnProtocol
    {
        void Connect();
        void Disconnect();
    }
}
