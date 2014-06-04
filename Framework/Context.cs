using System;
using Infrastructure;

namespace Framework
{
    public class Context
    {
        private ConnectionState _state;

        public Context(ConnectionState state, IVpnProtocol protocol)
        {
            State = state;
            Protocol = protocol;
        }

        public Context()
        {
            State = new ConnectionStateDisconnected();
        }

        public ConnectionState State
        {
            get { return _state; }
            set
            {
                _state = value;
                Console.WriteLine("State: " + _state.GetType().Name);
            }
        }

        public IVpnProtocol Protocol { get; set; }

        public void Connect()
        {
            _state.Connect(this);
        }

        public void Disconnect()
        {
            _state.Disconnect(this);
        }

        public bool IsConnected()
        {
            return _state.IsConnected(this);
        }
    }
}
