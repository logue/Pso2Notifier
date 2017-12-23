using Prism.Mvvm;
using System;
using System.Runtime.Serialization;

/// <summary>
/// eq.json Model
/// </summary>

/*
[
    {
        "HalfHour": "",
        "JST": "21",
        "Maintenance": false,
        "Now": "",
        "OneHalfLater": "",
        "OneLater": "Phantom God",
        "Ship1": "",
        "Ship10": "",
        "Ship2": "",
        "Ship3": "",
        "Ship4": "",
        "Ship5": "",
        "Ship6": "",
        "Ship7": "",
        "Ship8": "",
        "Ship9": "",
        "ThreeHalfLater": "",
        "ThreeLater": "Live Concert",
        "TwoHalfLater": "",
        "TwoLater": ""
    }
]
*/
namespace Pso2Notifier.Models
{
    [DataContract]
    public class Pso2AlertApi : BindableBase
    {
        private string uri;
        private string ua;
        private DateTime lastLoaded;

        /// <summary>
        /// Constructor
        /// </summary>
        public Pso2AlertApi()
        {
            var pso2a = new Pso2Alert();
            // Pso2Alert eq.json ignoles when not Pso2Alert user agent.
            // Then, set user agent string from pso2alert.json Version value.
            ua = pso2a.Version;
            // uri of eq.json
            uri = pso2a.API;
            lastLoaded = DateTime.MinValue;
        }
        /// <summary>
        /// Fetch eq.json
        /// </summary>
        public void reload()
        {            
            // Change UA.
            Client.setUa("Pso2Alert" + "_" + ua);
            // Fetch eq.json
            var json = Client.getJson(uri)[0].GetObject();

            _Maintenance = json["Maintenance"].GetBoolean();
            _Now = json["Now"].GetString();
            _HalfHour = json["HalfHour"].GetString();
            _OneLater = json["OneLater"].GetString();
            _OneHalfLater = json["OneHalfLater"].GetString();
            _TwoLater = json["TwoLater"].GetString();
            _TwoHalfLater = json["TwoHalfLater"].GetString();
            _ThreeLater = json["ThreeLater"].GetString();
            _ThreeHalfLater = json["ThreeHalfLater"].GetString();

            _JST = Convert.ToDouble(json["JST"].GetString());

            _Ship1 = json["Ship1"].GetString();
            _Ship2 = json["Ship2"].GetString();
            _Ship3 = json["Ship3"].GetString();
            _Ship4 = json["Ship4"].GetString();
            _Ship5 = json["Ship5"].GetString();
            _Ship6 = json["Ship6"].GetString();
            _Ship7 = json["Ship7"].GetString();
            _Ship8 = json["Ship8"].GetString();
            _Ship9 = json["Ship9"].GetString();
            _Ship10 = json["Ship10"].GetString();

            lastLoaded = DateTime.Now;
        }

        private bool _Maintenance;

        private string _Now;
        private string _HalfHour;
        private string _OneLater;
        private string _OneHalfLater;
        private string _TwoLater;
        private string _TwoHalfLater;
        private string _ThreeLater;
        private string _ThreeHalfLater;

        private double _JST;

        private string _Ship1;
        private string _Ship2;
        private string _Ship3;
        private string _Ship4;
        private string _Ship5;
        private string _Ship6;
        private string _Ship7;
        private string _Ship8;
        private string _Ship9;
        private string _Ship10;

        [DataMember]
        public bool Maintenance
        {
            get { return _Maintenance; }
        }

        [DataMember]
        public string Now
        {
            get { return _Now; }
        }
        [DataMember]
        public string HalfHour
        {
            get { return _HalfHour; }
        }
        [DataMember]
        public string OneLater
        {
            get { return _OneLater; }
        }
        [DataMember]
        public string OneHalfLater
        {
            get { return _OneHalfLater; }
        }
        [DataMember]
        public string TwoLater
        {
            get { return _TwoLater; }
        }
        [DataMember]
        public string TwoHalfLater
        {
            get { return _TwoHalfLater; }
        }
        [DataMember]
        public string ThreeLater
        {
            get { return _ThreeLater; }
        }
        [DataMember]
        public string ThreeHalfLater
        {
            get { return _ThreeHalfLater; }
        }

        [DataMember]
        public double JST
        {
            get { return _JST; }
        }

        [DataMember]
        public string Ship1
        {
            get { return _Ship1; }
        }
        [DataMember]
        public string Ship2
        {
            get { return _Ship2; }
        }
        [DataMember]
        public string Ship3
        {
            get { return _Ship3; }
        }
        [DataMember]
        public string Ship4
        {
            get { return _Ship4; }
        }
        [DataMember]
        public string Ship5
        {
            get { return _Ship5; }
        }
        [DataMember]
        public string Ship6
        {
            get { return _Ship6; }
        }
        [DataMember]
        public string Ship7
        {
            get { return _Ship7; }
        }
        [DataMember]
        public string Ship8
        {
            get { return _Ship8; }
        }
        [DataMember]
        public string Ship9
        {
            get { return _Ship9; }
        }
        [DataMember]
        public string Ship10
        {
            get { return _Ship10; }
        }
    }
}
