using System;
using Infrastructure;

namespace Framework
{
    public class ConnectionStateDisconnected : ConnectionState
    {
        public ConnectionStateDisconnected(IVpnProtocol protocol) 
        {
            try
            {
                protocol.Disconnect();
                System.Diagnostics.Debug.WriteLine("Disconnected");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        public ConnectionStateDisconnected()
        { }

        public override bool IsConnected(Context context)
        {
            return false;
        }

        public override void Connect(Context context)
        {
            context.State = new ConnectionStateConnected(context.Protocol);
        }

        public override void Disconnect(Context context)
        {
            System.Diagnostics.Debug.WriteLine("Already disconnected");
        }
    }
}
