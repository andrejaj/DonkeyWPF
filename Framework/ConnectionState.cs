
namespace Framework
{
    public abstract class ConnectionState
    { 
        public abstract void Connect(Context context);

        public abstract void Disconnect(Context context);

        public abstract bool IsConnected(Context context);
    }
}
