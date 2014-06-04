using System;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using DonkeyWPF.Filter;
using Framework;
using Infrastructure;
using Model;
using Protocol;

namespace DonkeyWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly DonkeyViewModel viewModel = new DonkeyViewModel();
        public Context Context = new Context();

        private const string DISCONNECTED = "disconnected";
        private const string CONNECTED = "connected";

        private const string CONNECT = "Connect";
        private const string DISCONNECT = "Disconnect";

        public MainWindow()
        {
            InitializeComponent();

            this.Loaded += MainWindow_Loaded;

            this.DataContext = viewModel;

            if (!Context.IsConnected())
            {
                viewModel.IsDisconnected = !Context.IsConnected();
                viewModel.StatusText = DISCONNECTED;
                viewModel.BtnCaption = CONNECT;
            }
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            LoadServerList();

            ICollectionView view =
              CollectionViewSource.GetDefaultView(viewModel.Servers);

            new TextSearchFilter(view, this.SearchBox);

            LoadProtocolList();
        }

        private void LoadProtocolList()
        {
            var names = Enum.GetNames(typeof(VPNProtocols));

            foreach (var name in names)
            {
                viewModel.ProtocolNames.Add(name);
            }
        }

        private void LoadServerList()
        {
            var path = ConfigurationManager.AppSettings["serverlist"];

            var items = File.ReadAllLines(path);

            var serverList =
                items.Select(item => item.Split('|'))
                    .Select(splitString => new Server(splitString[0], splitString[1], int.Parse(splitString[2])))
                    .ToList();

            foreach (var server in serverList.OrderBy(p => p.Name).ToList())
            {
                viewModel.Servers.Add(server);
            }
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            if (Context.IsConnected())
            {
                Context.Disconnect();

                viewModel.IsDisconnected = true;
                viewModel.StatusText = DISCONNECTED;
                viewModel.BtnCaption = CONNECT;
            }
            else
            {
                Context.Connect();

                viewModel.IsDisconnected = false;
                viewModel.StatusText =  CONNECTED;
                viewModel.BtnCaption = DISCONNECT;
            }
        }

        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //note: need to implement DI to load class through service locator
            if (viewModel.SelectedProtocol == typeof(PPTP).Name)
            {
                Context.Protocol = new PPTP(viewModel.SelectedServer.IpAddress, viewModel.SelectedServer.Port);
            }
            else
            {
                Context.Protocol = new OpenVPN(viewModel.SelectedServer.IpAddress, viewModel.SelectedServer.Port);
            }
        }
    }
}
