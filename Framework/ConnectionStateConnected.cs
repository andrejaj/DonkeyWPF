using System;
using Infrastructure;

namespace Framework
{
    public class ConnectionStateConnected : ConnectionState
    {
        public ConnectionStateConnected(IVpnProtocol protocol)
        {
            try
            {
                protocol.Connect();
                System.Diagnostics.Debug.WriteLine("Connected");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        public override void Connect(Context context)
        {
            System.Diagnostics.Debug.WriteLine("Already connected");
        }

        public override void Disconnect(Context context)
        {
            context.State = new ConnectionStateDisconnected(context.Protocol);
        }

        public override bool IsConnected(Context context)
        {
            return true;
        }
    }
}
