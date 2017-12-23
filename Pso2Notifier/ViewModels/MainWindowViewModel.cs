using System;
using System.ComponentModel;
using Pso2Notifier.Models;
using Prism.Commands;
using Prism.Mvvm;
using System.Collections.Generic;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System.Threading.Tasks;
using System.Globalization;
using Prism.Events;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using Pso2Notifier;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Media.Imaging;

namespace Pso2Notifier.ViewModels
{
    public class MainWindowViewModel : BindableBase, INotifyPropertyChanged, IDataErrorInfo, IDisposable
    {
        string IDataErrorInfo.Error => throw new NotImplementedException();
        string IDataErrorInfo.this[string columnName] => throw new NotImplementedException();
        public IDialogCoordinator MahAppsDialogCoordinator { get; set; }

        public Pso2AlertApi Api;


        private string _title = "Pso2Nortfier";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public List<String> IncomingEmergencyQuests
        {
            get
            {
                // TODO: Ship Key Name as Model Parameter
                string ItemName = "Ship" + Ship.ToString();
                // Reload eq.json
                List<string> Incomming = new List<string>();
                Incomming.Add(Api.Now);
                Incomming.Add(Api.HalfHour);
                Incomming.Add(Api.OneLater);
                Incomming.Add(Api.OneHalfLater);
                Incomming.Add(Api.TwoLater);
                Incomming.Add(Api.TwoHalfLater);
                Incomming.Add(Api.ThreeLater);
                Incomming.Add(Api.ThreeHalfLater);
                return Incomming;
            }
        }

        private int _current_ship = 2;
        public int Ship
        {
            get { return _current_ship; }
            set { SetProperty(ref _current_ship, value); }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public MainWindowViewModel()
        {
            Api = new Pso2AlertApi();
            Api.reload();

            // Reflesh Incoming Emergency Quests
            

            //CultureInfos = CultureInfo.GetCultures(CultureTypes.InstalledWin32Cultures).OrderBy(c => c.DisplayName).ToList();           
        }
        /// <summary>
        /// Destructor
        /// </summary>
        public void Dispose()
        {
            
        }
        /// <summary>
        /// Reload eq.json
        /// </summary>
        private async Task Reload()
        {
            await MahAppsDialogCoordinator.ShowMessageAsync(
                    this, "Dialog from ViewModel", $"Now = {DateTime.Now}");
            Api.reload();

            // Reflesh Incoming Emergency Quests
            IncomingEmergencyQuests.Clear();
            IncomingEmergencyQuests.Add(Api.Now);
            IncomingEmergencyQuests.Add(Api.HalfHour);
            IncomingEmergencyQuests.Add(Api.OneLater);
            IncomingEmergencyQuests.Add(Api.OneHalfLater);
            IncomingEmergencyQuests.Add(Api.TwoLater);
            IncomingEmergencyQuests.Add(Api.TwoHalfLater);
            IncomingEmergencyQuests.Add(Api.ThreeLater);
            IncomingEmergencyQuests.Add(Api.ThreeHalfLater);
        }

    }
}
