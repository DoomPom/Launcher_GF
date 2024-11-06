using KartLauncher.Data.Set_Data;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace KartLauncher.Data.Forms
{
    public partial class Launcher : Form
    {


        public Launcher()
        {
            InitializeComponent();
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
            MinorVersion.Text = SetGameOption.Version.ToString();
        }

        private void Start_Button_Click(object sender, EventArgs e)
        {
            Program.Start();
        }

        private void GetKart_Button_Click(object sender, EventArgs e)
        {
            GetKart dlg = new GetKart();
            dlg.ShowDialog();
        }

    }
}
