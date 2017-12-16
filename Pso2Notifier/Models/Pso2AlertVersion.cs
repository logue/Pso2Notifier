using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using System.Runtime.Serialization;

namespace Pso2Notifier.Models
{
    class Pso2AlertVersion : BindableBase
    {
        private string _DownloadLink;
        private string _ChangeLog;
        private string _ChangeLog2;
        private string _ChangeLog3;
        private string _ChangeLog4;
        private string _ChangeLog5;
        private string _ChangeLog6;
        private string _ChangeLog7;
        private string _ChangeLog8;
        private string _ChangeLog9;
        private string _ChangeLog10;

        [DataMember]
        public string DownloadLink
        {
            get { return _DownloadLink; }
            set { SetProperty<string>(ref _DownloadLink, value); }
        }

        [DataMember]
        public string ChangeLog
        {
            get { return _ChangeLog; }
            set { SetProperty<string>(ref _ChangeLog, value); }
        }
        [DataMember]
        public string ChangeLog2
        {
            get { return _ChangeLog2; }
            set { SetProperty<string>(ref _ChangeLog2, value); }
        }
        [DataMember]
        public string ChangeLog3
        {
            get { return _ChangeLog3; }
            set { SetProperty<string>(ref _ChangeLog3, value); }
        }
        [DataMember]
        public string ChangeLog4
        {
            get { return _ChangeLog4; }
            set { SetProperty<string>(ref _ChangeLog4, value); }
        }
        [DataMember]
        public string ChangeLog5
        {
            get { return _ChangeLog5; }
            set { SetProperty<string>(ref _ChangeLog5, value); }
        }
        [DataMember]
        public string ChangeLog6
        {
            get { return _ChangeLog6; }
            set { SetProperty<string>(ref _ChangeLog6, value); }
        }
        [DataMember]
        public string ChangeLog7
        {
            get { return _ChangeLog7; }
            set { SetProperty<string>(ref _ChangeLog7, value); }
        }
        [DataMember]
        public string ChangeLog8
        {
            get { return _ChangeLog8; }
            set { SetProperty<string>(ref _ChangeLog8, value); }
        }
        [DataMember]
        public string ChangeLog9
        {
            get { return _ChangeLog9; }
            set { SetProperty<string>(ref _ChangeLog9, value); }
        }
        [DataMember]
        public string ChangeLog10
        {
            get { return _ChangeLog; }
            set { SetProperty<string>(ref _ChangeLog10, value); }
        }
    }
}
