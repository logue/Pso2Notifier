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

        private Dictionary<string, EmergencyQuestStructure>EmergencyQuests;

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

        /// <summary>
        /// Emergency Quest Structure
        /// </summary>
        public struct EmergencyQuestStructure
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public string Image { get; set; }
        }
        private void createEmergencyQuestList()
        {
            //EmergencyQuests.Clear();
            // Key is Match Pattern.
            // Value is display Infomation

            // マザーシップ
            EmergencyQuests.Add("Facility", new EmergencyQuestStructure()
            {
                Name = "Facility",
                Description = "Facility",
                Image = "MotherShip_Facility.png"
            });
            // ウォパル海底
            EmergencyQuests.Add("Seabed", new EmergencyQuestStructure()
            {
                Name = "Seabed",
                Description = "Seabed",
                Image = "Wopal_Seabed.png"
            });
            // ビーチウォーズ
            EmergencyQuests.Add("Beach Wars", new EmergencyQuestStructure()
            {
                Name = "Beach Wars",
                Description = "Beach Wars",
                Image = "Wopal_Beach_Wars.png"
            });
            // ウォパル（汎用）
            EmergencyQuests.Add("Vopar", new EmergencyQuestStructure()  // Maybe ArksLayer's miss spell :p
            {
                Name = "Wopal Beach",
                Description = "Beach ",
                Image = "Wopal_Beach.png"
            });
            // 平穏を引き裂く混沌
            EmergencyQuests.Add("Chaotic Tranquility", new EmergencyQuestStructure()
            {
                Name = "ArksShip",
                Description = "Beach ",
                Image = "ArksShip_Chaotic_Tranquility.png"
            });
            // 消火活動（バーニングレンジャータイアップなのでもうないとおもう）
            EmergencyQuests.Add("Fire Swirl", new EmergencyQuestStructure()
            {
                Name = "",
                Description = "",
                Image = "ArksShip_Fire_Swirl.png"
            });
            EmergencyQuests.Add("Burning Rangers", new EmergencyQuestStructure()
            {
                Name = "",
                Description = "",
                Image = "ArksShip_Fire_Swirl.png"
            });
            // アークスシップ市街地
            EmergencyQuests.Add("Uraban", new EmergencyQuestStructure()
            {
                Name = "ArksShip　Urban",
                Description = "",
                Image = "ArksShip_Urban.png"
            });
            // マザーシップ汎用
            EmergencyQuests.Add("Mothership", new EmergencyQuestStructure()
            {
                Name = "Mothership",
                Description = "",
                Image = "Mothership.png"
            });
            // 採掘基地防衛戦：襲来
            EmergencyQuests.Add("(I)", new EmergencyQuestStructure()
            {
                Name = "Defense MiningBase Attack",
                Description = "",
                Image = "Defense_MiningBase1_Attack.png"
            });
            // 採掘基地防衛戦：侵入	
            EmergencyQuests.Add("(II)", new EmergencyQuestStructure()
            {
                Name = "Defense MiningBase Invation",
                Description = "",
                Image = "Defense_MiningBase2_Invasion.png"
            });
            // 採掘基地防衛戦：絶望
            EmergencyQuests.Add("(III)", new EmergencyQuestStructure()
            {
                Name = "Defense MiningBase Despair",
                Description = "",
                Image = "Defense_MiningBase3_Despair.png"
            });
            // 採掘基地防衛戦：終焉
            EmergencyQuests.Add("(IV)", new EmergencyQuestStructure()
            {
                Name = "Defense MiningBase Demise",
                Description = "",
                Image = "Defense_MiningBase4_Demise.png"
            });
            // 採掘基地防衛戦：VR
            EmergencyQuests.Add("Mining Base VR", new EmergencyQuestStructure()
            {
                Name = "Defense MiningBase VR",
                Description = "",
                Image = "Defense_MiningBase5_VR.png"
            });
            // 採掘基地防衛戦（汎用）
            EmergencyQuests.Add("Mining Base", new EmergencyQuestStructure()
            {
                Name = "Defense MiningBase",
                Description = "",
                Image = "Defense_MiningBase1_Attack.png"
            });
            // 猛る黒曜の暴腕／深遠に至りし巨なる躯【巨躯】
            EmergencyQuests.Add("Elder", new EmergencyQuestStructure()
            {
                Name = "Dark Falz [Elder]",
                Description = "",
                Image = "Raid_Elder.png"
            });
            // 狡猾なる黒翼の尖兵／現れる偽りの覇者【敗者】
            EmergencyQuests.Add("Loser", new EmergencyQuestStructure()
            {
                Name = "Dark Falz [Loser]",
                Description = "",
                Image = "Raid_Loser1.png"
            });
            // クーナのライブ
            EmergencyQuests.Add("Concert", new EmergencyQuestStructure()
            {
                Name = "Concert",
                Description = "",
                Image = "Concert.png"
            });
            // ナベリウス凍土
            EmergencyQuests.Add("Tundra", new EmergencyQuestStructure()
            {
                Name = "Naberius Tundra",
                Description = "",
                Image = "Naberius_Tundra.png"
            });
            // 	氷上のメリークリスマス
            EmergencyQuests.Add("Christmas", new EmergencyQuestStructure()
            {
                Name = "Merry Christmas on Ice",
                Description = "",
                Image = "Naberius_Christmas.png"
            });
            // ナベリウス遺跡
            EmergencyQuests.Add("Ruins", new EmergencyQuestStructure()
            {
                Name = "Naberius Ruins",
                Description = "",
                Image = "Naberius_Ruins.png"
            });
            // 雨風とともに
            EmergencyQuests.Add("Driving Rain", new EmergencyQuestStructure()
            {
                Name = "Driving Rain",
                Description = "",
                Image = "Naberius_Rain.png"
            });
            // ナベリウス森林
            EmergencyQuests.Add("Forest", new EmergencyQuestStructure()
            {
                Name = "Naberius Forest",
                Description = "",
                Image = "Naberius_Forest.png"
            });
            // ナベリウス汎用
            EmergencyQuests.Add("Naberius", new EmergencyQuestStructure()
            {
                Name = "Naberius",
                Description = "",
                Image = "Naberius_Forest.png"
            });
            // アムドゥスキア浮遊大陸
            EmergencyQuests.Add("Skyscape", new EmergencyQuestStructure()
            {
                Name = "Amduskia Skyscape",
                Description = "",
                Image = "Amduskia_Skyscape.png"
            });
            // アムドゥスキア龍祭壇
            EmergencyQuests.Add("Sanctum", new EmergencyQuestStructure()
            {
                Name = "Amduskia Sanctum",
                Description = "",
                Image = "Amduskia_Sanctum.png"
            });
            // ホワイトデーは大わらわ
            EmergencyQuests.Add("White Day", new EmergencyQuestStructure()
            {
                Name = "White Day",
                Description = "",
                Image = "Amduskia_White_Day.png"
            });
            // チョコレートの行方
            EmergencyQuests.Add("Chocolate", new EmergencyQuestStructure()
            {
                Name = "Valentine's Day",
                Description = "",
                Image = "Amduskia_Chocolate.png"
            });
            // リリーパ砂漠
            EmergencyQuests.Add("Desert", new EmergencyQuestStructure()
            {
                Name = "Lilipur Desert",
                Description = "",
                Image = "Lilipur_Desert.png"
            });
            // トリックオアトリート
            EmergencyQuests.Add("Trick or Treat", new EmergencyQuestStructure()
            {
                Name = "Lilipur Desert",
                Description = "",
                Image = "Lilipur_ToT.png"
            });
            // リリーパ採掘基地
            EmergencyQuests.Add("Quarry", new EmergencyQuestStructure()
            {
                Name = "Lilipur Quarry",
                Description = "",
                Image = "Lilipur_Quarry.png"
            });
            // ワイルドイースター
            EmergencyQuests.Add("Easter", new EmergencyQuestStructure()
            {
                Name = "Lilipur Easter",
                Description = "",
                Image = "Lilipur_Easter.png"
            });
            // リリーパ（汎用）
            EmergencyQuests.Add("Lillipa", new EmergencyQuestStructure()         // Maybe ArksLayer's miss spell :p
            {
                Name = "Lilipur Desert",
                Description = "",
                Image = "Lilipur_Desert.png"
            });
            // 顕現せし星滅の災厄／星滅の災厄禊ぐ灰の唱
            EmergencyQuests.Add("Magatsu", new EmergencyQuestStructure()
            {
                Name = "Harukotan Magatsu",
                Description = "",
                Image = "Raid_Magatsu.png"
            });
            // 闇のゆりかご
            EmergencyQuests.Add("Cradle", new EmergencyQuestStructure()
            {
                Name = "Darker's Crèche",
                Description = "",
                Image = "DarkerDen.png"
            });
            // ハルコタン白の領域
            EmergencyQuests.Add("Shironia", new EmergencyQuestStructure()
            {
                Name = "Harukotan Shironia",
                Description = "",
                Image = "Harukotan_Shironia.png"
            });
            // ハルコタン黒の領域
            EmergencyQuests.Add("Kuron", new EmergencyQuestStructure()
            {
                Name = "Harukotan Kuronia",
                Description = "",
                Image = "Harukotan_Kuronia.png"
            });
            // ハルコタン（汎用）
            EmergencyQuests.Add("Shironia", new EmergencyQuestStructure()
            {
                Name = "Harukotan",
                Description = "",
                Image = "Harukotan_Shironia.png"
            });
            // 禍魂集いし戦道
            EmergencyQuests.Add("Regiment of the Wicked", new EmergencyQuestStructure()
            {
                Name = "Harukotan",
                Description = "",
                Image = "Harukotan_Kuronia.png"
            });
            // 来襲せし虚なる深遠の躯
            EmergencyQuests.Add("Profound Invasion", new EmergencyQuestStructure()
            {
                Name = "Profound Invasion",
                Description = "",
                Image = "Raid_Elder&Loser.png"
            });
            // 世界を堕とす輪廻の徒花
            EmergencyQuests.Add("Profound Darkness", new EmergencyQuestStructure()
            {
                Name = "Profound Darkness",
                Description = "",
                Image = "Raid_Double.png"
            });
            // 地球東京
            EmergencyQuests.Add("Tokyo", new EmergencyQuestStructure()
            {
                Name = "Tokyo",
                Description = "",
                Image = "Earth_Tokyo.png"
            });
            // 地球（汎用）
            EmergencyQuests.Add("Tokyo", new EmergencyQuestStructure()
            {
                Name = "Earth",
                Description = "",
                Image = "Earth_Tokyo.png"
            });
            // 地球ラスベガス
            EmergencyQuests.Add("Vegas", new EmergencyQuestStructure()
            {
                Name = "Vegas",
                Description = "",
                Image = "Earth_Vegas.png"
            });
            // 威風堂々たる鋼鉄の進撃／大海に顕れし鋼鉄の巨艦
            EmergencyQuests.Add("Yamato", new EmergencyQuestStructure()
            {
                Name = "Yamato",
                Description = "",
                Image = "Raid_Yamato.png"
            });
            // ネッキーからの挑戦状！
            EmergencyQuests.Add("Necky", new EmergencyQuestStructure()
            {
                Name = "Necky",
                Description = "",
                Image = "VR_Famitsu.png"
            });
            // 月駆ける幻創の母
            EmergencyQuests.Add("Phantom Mother", new EmergencyQuestStructure()
            {
                Name = "Phantom Mother",
                Description = "",
                Image = "Raid_Mother.png"
            });
            // 新世を成す幻創の造神／創世を謳う幻創の造神
            EmergencyQuests.Add("Phantom God", new EmergencyQuestStructure()
            {
                Name = "Phantom God",
                Description = "",
                Image = "Raid_Deus_Esca.png"
            });
            // 魔神城戦：不断の闘志
            EmergencyQuests.Add("Endless Belligerence", new EmergencyQuestStructure()
            {
                Name = "Endless Belligerence",
                Description = "",
                Image = "Omega_Endless_Belligerence.png"
            });
            // 電撃！ポリタンランド！
            EmergencyQuests.Add("Polytanland", new EmergencyQuestStructure()
            {
                Name = "Dengeki Polytanland",
                Description = "",
                Image = "VR_Dengeki_Polytanland.png"
            });
        }
        /// <summary>
        /// Resource image to ImageSource
        /// </summary>
        /// <param name="respurcePath"></param>
        /// <returns></returns>
        private static BitmapImage Resource2Bitmap(string respurcePath)
        {
            var uri = string.Format(
                "pack://application:,,,/{0};component/{1}"
                , Assembly.GetExecutingAssembly().GetName().Name
                , respurcePath
            );
            return new BitmapImage(new Uri(uri));
        }
    }
}
