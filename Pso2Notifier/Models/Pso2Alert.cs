using Prism.Mvvm;
using System.Diagnostics;
using System.Runtime.Serialization;
using Windows.Data.Json;
/*
[
	{
		"Version": "3.0.5.2",
		"Application": "https://pso2.acf.me.uk/PSO2Alert/PSO2Alert.exe",
		"Updater": "https://pso2.acf.me.uk/PSO2Alert/PSO2AlertUpdater.exe",
		"XML": "https://pso2.acf.me.uk/PSO2Alert/PSO2Aversion.xml",
		"API": "https://pso2.acf.me.uk/api/eq.json"
	}
]
*/

/// <summary>
/// Pso2Alert.json Model
/// </summary>
namespace Pso2Notifier.Models
{
    [DataContract]
    class Pso2Alert : BindableBase
    {
        public static readonly string DefaultUri = "https://pso2.acf.me.uk/PSO2Alert.json";

        private static Pso2Alert _instance = new Pso2Alert();

        private string _Version;
        private string _Application;
        private string _Updater;
        private string _XML;
        private string _API;
        private bool initialized = false;
   
        public Pso2Alert(string uri = "")
        {
            if (initialized)
            {
                return;
            }
            if (uri == "")
            {
                uri = DefaultUri;
            }
            var json = Client.getJson(uri)[0].GetObject();
            _Version = json["Version"].GetString();
            _Application = json["Application"].GetString();
            _Updater = json["Updater"].GetString();
            _XML = json["XML"].GetString();
            _API = json["API"].GetString();
            initialized = true;
        }

        public Pso2Alert instance()
        {
            return _instance;
        }
  
        [DataMember]
        public string Version {
            get { return _Version; }
        }
        [DataMember]
        public string Application {
            get { return _Application; }
        }
        [DataMember]
        public string Updater {
            get { return _Updater; }
        }
        [DataMember]
        public string XML {
            get { return _XML; }
        }
        [DataMember]
        public string API
        {
            get { return _API; }
        }
    }
}
