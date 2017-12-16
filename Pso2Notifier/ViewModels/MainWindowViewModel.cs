using System;
using System.ComponentModel;
using Pso2Notifier.Models;
using Prism.Mvvm;
using System.Collections.Generic;
using Prism.Events;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using Pso2Notifier;
using System.Diagnostics;

namespace Pso2Notifier.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private Pso2AlertApi Api;
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

        public MainWindowViewModel()
        {
            Api = new Pso2AlertApi();
            Api.fetch();
        }
    }
}
