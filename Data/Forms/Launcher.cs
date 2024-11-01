using KartLauncher.Common.KartRider.Common.Data;
using KartLauncher.Data.ExcData;
using KartLauncher.Data.Server;
using KartLauncher.Data.Set_Data;
using KartLauncher.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

namespace KartLauncher.Data.Forms
{
    public class Launcher : Form
    {
        public static bool GetKart = true;
        public static bool OpenGetItem = false;
        public string kartRiderDirectory = null;
        public string profilePath = null;
        public static string KartRider = "KartRider.exe";
        public static string pinFile = "KartRider.pin";
        private Button Start_Button;
        private Button GetKart_Button;
        private Label label_DeveloperName;
        private Label MinorVersion;

        public Launcher()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Launcher));
            Start_Button = new Button();
            GetKart_Button = new Button();
            label_DeveloperName = new Label();
            MinorVersion = new Label();
            SuspendLayout();
            // 
            // Start_Button
            // 
            Start_Button.Location = new System.Drawing.Point(19, 20);
            Start_Button.Name = "Start_Button";
            Start_Button.Size = new System.Drawing.Size(114, 23);
            Start_Button.TabIndex = 364;
            Start_Button.Text = "启动游戏";
            Start_Button.UseVisualStyleBackColor = true;
            Start_Button.Click += new EventHandler(Start_Button_Click);
            // 
            // GetKart_Button
            // 
            GetKart_Button.Location = new System.Drawing.Point(19, 49);
            GetKart_Button.Name = "GetKart_Button";
            GetKart_Button.Size = new System.Drawing.Size(114, 23);
            GetKart_Button.TabIndex = 365;
            GetKart_Button.Text = "添加道具";
            GetKart_Button.UseVisualStyleBackColor = true;
            GetKart_Button.Click += new EventHandler(GetKart_Button_Click);
            // 
            // label_DeveloperName
            // 
            label_DeveloperName.AutoSize = true;
            label_DeveloperName.BackColor = System.Drawing.SystemColors.Control;
            label_DeveloperName.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label_DeveloperName.ForeColor = System.Drawing.Color.Blue;
            label_DeveloperName.Location = new System.Drawing.Point(2, 160);
            label_DeveloperName.Name = "label_DeveloperName";
            label_DeveloperName.Size = new System.Drawing.Size(53, 12);
            label_DeveloperName.TabIndex = 367;
            label_DeveloperName.Text = "Version:";
            // 
            // MinorVersion
            // 
            MinorVersion.AutoSize = true;
            MinorVersion.BackColor = System.Drawing.SystemColors.Control;
            MinorVersion.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            MinorVersion.ForeColor = System.Drawing.Color.Red;
            MinorVersion.Location = new System.Drawing.Point(55, 160);
            MinorVersion.Name = "MinorVersion";
            MinorVersion.Size = new System.Drawing.Size(10, 12);
            MinorVersion.TabIndex = 367;
            // 
            // Launcher
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.Control;
            ClientSize = new System.Drawing.Size(257, 180);
            Controls.Add(MinorVersion);
            Controls.Add(label_DeveloperName);
            Controls.Add(GetKart_Button);
            Controls.Add(Start_Button);
            Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = Resources.icon;
            MaximizeBox = false;
            Name = "Launcher";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Launcher";
            FormClosing += new FormClosingEventHandler(OnFormClosing);
            Load += new EventHandler(OnLoad);
            ResumeLayout(false);
            PerformLayout();

        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            File.Delete(@"KartRider.xml");
            if (Process.GetProcessesByName("KartRider").Length != 0)
            {
                LauncherSystem.MessageBoxType1();
                e.Cancel = true;
            }
        }

        private void OnLoad(object sender, EventArgs e)
        {
            kartRiderDirectory = Environment.CurrentDirectory;
            if (File.Exists(KartRider) && File.Exists(@"KartRider.pin"))
            {
                string str = Path.Combine(kartRiderDirectory, "Profile", SessionGroup.Service);
                if (!Directory.Exists(str))
                {
                    Directory.CreateDirectory(str);
                }
                Load_KartData();
                StartingLoad_ALL.StartingLoad();
                PINFile PINFile = new PINFile(pinFile);
                SetGameOption.Version = PINFile.Header.MinorVersion;
                SetGameOption.Save_SetGameOption();
                MinorVersion.Text = SetGameOption.Version.ToString();
                profilePath = Path.Combine(str, "launcher.xml");
                Console.WriteLine("Process: {0}", kartRiderDirectory + "\\" + KartRider);
                Console.WriteLine("Profile: {0}", profilePath);
                RouterListener.Start();
            }
            else
            {
                LauncherSystem.MessageBoxType3();
            }
        }

        private void Start_Button_Click(object sender, EventArgs e)
        {
            if (Process.GetProcessesByName("KartRider").Length != 0)
            {
                LauncherSystem.MessageBoxType2();
            }
            else
            {
                new Thread(() =>
                {
                    Start_Button.Enabled = true;
                    GetKart = false;
                    File.Delete("KartRider.xml");
                    string[] text1 = new string[] { "<?xml version='1.0' encoding='UTF-16'?>\r\n<config>\r\n\t<server addr='", RouterListener.sIP, ":", RouterListener.port.ToString(), "'/>\r\n</config>" };
                    File.WriteAllText(@"KartRider.xml", string.Concat(text1));
                    string str = profilePath;
                    string[] text2 = new string[] { "<?xml version='1.0' encoding='UTF-16'?>\r\n<profile>\r\n<username>", SetRider.UserID, "</username>\r\n</profile>" };
                    File.WriteAllText(str, string.Concat(text2));
                    ProcessStartInfo startInfo = new ProcessStartInfo(KartRider, "TGC -region:3 -passport:556O5Yeg5oqK55yL5ZWl")
                    {
                        WorkingDirectory = kartRiderDirectory,
                        UseShellExecute = true,
                        Verb = "runas"
                    };
                    try
                    {
                        Process.Start(startInfo);
                        Thread.Sleep(1000);
                        Start_Button.Enabled = true;
                        GetKart = true;
                    }
                    catch (System.ComponentModel.Win32Exception ex)
                    {
                        // 用户取消了UAC提示或没有权限
                        Console.WriteLine(ex.Message);
                    }
                }).Start();
            }
        }

        private void GetKart_Button_Click(object sender, EventArgs e)
        {
            if (GetKart)
            {
                //GetKart_Button.Enabled = false;
                Program.GetKartDlg = new GetKart();
                Program.GetKartDlg.ShowDialog();
                //GetKart_Button.Enabled = true;
            }
        }

        public static void Load_KartData()
        {
            if (!File.Exists(@"Profile\KartSpec.xml"))
            {
                string KartSpec = Resources.KartSpec;
                using (StreamWriter streamWriter = new StreamWriter(@"Profile\KartSpec.xml", false))
                {
                    streamWriter.Write(KartSpec);
                }
            }
            if (!File.Exists(@"Profile\FlyingPetSpec.xml"))
            {
                string FlyingPetSpec = Resources.FlyingPetSpec;
                using (StreamWriter streamWriter = new StreamWriter(@"Profile\FlyingPetSpec.xml", false))
                {
                    streamWriter.Write(FlyingPetSpec);
                }
            }
            if (!File.Exists(@"Profile\Item.xml"))
            {
                string Item = Resources.Item;
                using (StreamWriter streamWriter = new StreamWriter(@"Profile\Item.xml", false))
                {
                    streamWriter.Write(Item);
                }
            }
            if (!File.Exists(@"Profile\RandomTrack.xml"))
            {
                string RandomTrack = Resources.RandomTrack;
                using (StreamWriter streamWriter = new StreamWriter(@"Profile\RandomTrack.xml", false))
                {
                    streamWriter.Write(RandomTrack);
                }
            }
            if (!File.Exists(@"Profile\NewKart.xml"))
            {
                string NewKart = Resources.NewKart;
                using (StreamWriter streamWriter = new StreamWriter(@"Profile\NewKart.xml", false))
                {
                    streamWriter.Write(NewKart);
                }
            }
            if (!File.Exists(@"Profile\PartsData.xml"))
            {
                string PartsData = Resources.PartsData;
                using (StreamWriter streamWriter = new StreamWriter(@"Profile\PartsData.xml", false))
                {
                    streamWriter.Write(PartsData);
                }
            }
            if (File.Exists(@"Profile\TuneData.xml"))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(@"Profile\TuneData.xml");
                if (!(doc.GetElementsByTagName("Kart") == null))
                {
                    XmlNodeList lis = doc.GetElementsByTagName("Kart");
                    KartExcData.TuneList = new List<List<short>>();
                    foreach (XmlNode xn in lis)
                    {
                        XmlElement xe = (XmlElement)xn;
                        short i = short.Parse(xe.GetAttribute("id"));
                        short sn = short.Parse(xe.GetAttribute("sn"));
                        short tune1 = short.Parse(xe.GetAttribute("tune1"));
                        short tune2 = short.Parse(xe.GetAttribute("tune2"));
                        short tune3 = short.Parse(xe.GetAttribute("tune3"));
                        List<short> AddList = new List<short> { i, sn, tune1, tune2, tune3 };
                        KartExcData.TuneList.Add(AddList);
                    }
                }
            }
            if (File.Exists(@"Profile\PlantData.xml"))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(@"Profile\PlantData.xml");
                if (!(doc.GetElementsByTagName("Kart") == null))
                {
                    XmlNodeList lis = doc.GetElementsByTagName("Kart");
                    KartExcData.PlantList = new List<List<short>>();
                    foreach (XmlNode xn in lis)
                    {
                        XmlElement xe = (XmlElement)xn;
                        short i = short.Parse(xe.GetAttribute("id"));
                        short sn = short.Parse(xe.GetAttribute("sn"));
                        short item1 = short.Parse(xe.GetAttribute("item1"));
                        short item_id1 = short.Parse(xe.GetAttribute("item_id1"));
                        short item2 = short.Parse(xe.GetAttribute("item2"));
                        short item_id2 = short.Parse(xe.GetAttribute("item_id2"));
                        short item3 = short.Parse(xe.GetAttribute("item3"));
                        short item_id3 = short.Parse(xe.GetAttribute("item_id3"));
                        short item4 = short.Parse(xe.GetAttribute("item4"));
                        short item_id4 = short.Parse(xe.GetAttribute("item_id4"));
                        List<short> AddList = new List<short> { i, sn, item1, item_id1, item2, item_id2, item3, item_id3, item4, item_id4 };
                        KartExcData.PlantList.Add(AddList);
                    }
                }
            }
            if (File.Exists(@"Profile\LevelData.xml"))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(@"Profile\LevelData.xml");
                if (!(doc.GetElementsByTagName("Kart") == null))
                {
                    XmlNodeList lis = doc.GetElementsByTagName("Kart");
                    KartExcData.LevelList = new List<List<short>>();
                    foreach (XmlNode xn in lis)
                    {
                        XmlElement xe = (XmlElement)xn;
                        short i = short.Parse(xe.GetAttribute("id"));
                        short sn = short.Parse(xe.GetAttribute("sn"));
                        short level = short.Parse(xe.GetAttribute("level"));
                        short pointleft = short.Parse(xe.GetAttribute("pointleft"));
                        short v1 = short.Parse(xe.GetAttribute("v1"));
                        short v2 = short.Parse(xe.GetAttribute("v2"));
                        short v3 = short.Parse(xe.GetAttribute("v3"));
                        short v4 = short.Parse(xe.GetAttribute("v4"));
                        short Effect = short.Parse(xe.GetAttribute("Effect"));
                        List<short> AddList = new List<short> { i, sn, level, pointleft, v1, v2, v3, v4, Effect };
                        KartExcData.LevelList.Add(AddList);
                    }
                }
            }
            if (File.Exists(@"Profile\PartsData.xml"))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(@"Profile\PartsData.xml");
                if (!(doc.GetElementsByTagName("Parts") == null))
                {
                    XmlNodeList lis = doc.GetElementsByTagName("Kart");
                    KartExcData.PartsList = new List<List<short>>();
                    foreach (XmlNode xn in lis)
                    {
                        XmlElement xe = (XmlElement)xn;
                        short i = short.Parse(xe.GetAttribute("id"));
                        short sn = short.Parse(xe.GetAttribute("sn"));
                        short Item_Id1 = short.Parse(xe.GetAttribute("Item_Id1"));
                        byte Grade1 = byte.Parse(xe.GetAttribute("Grade1"));
                        short PartsValue1 = short.Parse(xe.GetAttribute("PartsValue1"));
                        short Item_Id2 = short.Parse(xe.GetAttribute("Item_Id2"));
                        byte Grade2 = byte.Parse(xe.GetAttribute("Grade2"));
                        short PartsValue2 = short.Parse(xe.GetAttribute("PartsValue2"));
                        short Item_Id3 = short.Parse(xe.GetAttribute("Item_Id3"));
                        byte Grade3 = byte.Parse(xe.GetAttribute("Grade3"));
                        short PartsValue3 = short.Parse(xe.GetAttribute("PartsValue3"));
                        short Item_Id4 = short.Parse(xe.GetAttribute("Item_Id4"));
                        byte Grade4 = byte.Parse(xe.GetAttribute("Grade4"));
                        short PartsValue4 = short.Parse(xe.GetAttribute("PartsValue4"));
                        short partsCoating = byte.Parse(xe.GetAttribute("partsCoating"));
                        short partsTailLamp = short.Parse(xe.GetAttribute("partsTailLamp"));
                        List<short> AddList = new List<short> { i, sn, Item_Id1, Grade1, PartsValue1, Item_Id2, Grade2, PartsValue2, Item_Id3, Grade3, PartsValue3, Item_Id4, Grade4, PartsValue4, partsCoating, partsTailLamp };
                        KartExcData.PartsList.Add(AddList);
                    }
                }
            }
        }
    }
}
