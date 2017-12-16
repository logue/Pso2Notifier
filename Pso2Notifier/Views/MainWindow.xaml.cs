using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;
using Windows.Foundation;
using Windows.Graphics.Display;
using Windows.System;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Documents;
using System.IO;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using Pso2Notifier.Models;
using Pso2Notifier.ViewModels;

namespace Pso2Notifier.Views
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            
            InitializeComponent();
        }

        private void ReloadButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }
    }
}