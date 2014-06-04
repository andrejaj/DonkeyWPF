using System.Collections.ObjectModel;
using System.ComponentModel;
using Model;

namespace DonkeyWPF
{
    public class DonkeyViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Server> _server;

        public ObservableCollection<Server> Servers
        {
            get { return _server ?? (_server = new ObservableCollection<Server>()); }
            set
            {
                _server = value;
                InvokePropertyChanged("Servers");
            }
        }

        private bool _isDisconnected;
        public bool IsDisconnected {
            get { return _isDisconnected; }
            set
            {
                _isDisconnected = value;
                InvokePropertyChanged("IsDisconnected");
            } 
        }

        private string _statusText;
        public string StatusText { get { return _statusText; }
            set
            {
                _statusText = value;
                InvokePropertyChanged("StatusText");
            }
        }

        private string _btnCaption;
        public string BtnCaption {
            get { return _btnCaption; }
            set
            {
                _btnCaption = value;
                InvokePropertyChanged("BtnCaption");
            }
        }

        public Server SelectedServer { get; set; }

        private ObservableCollection<string> _protocolNames = new ObservableCollection<string>();
        public ObservableCollection<string> ProtocolNames
        {
            get { return _protocolNames ?? (_protocolNames = new ObservableCollection<string>()); }
            set
            {
                _protocolNames = value;
                InvokePropertyChanged("ProtocolNames");
            }
        }

        public string SelectedProtocol { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void InvokePropertyChanged(string propertyName)
        {

            var e = new PropertyChangedEventArgs(propertyName);

            PropertyChangedEventHandler changed = PropertyChanged;

            if (changed != null) changed(this, e);

        }
    }
}
