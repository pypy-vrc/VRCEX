using System;
using System.Windows.Forms;

namespace VRCEX
{
    public static class VRCEX
    {
        public static readonly string APP = "VRCEX v0.08c";

        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            LocalConfig.LoadConfig();
            VRCApi.LoadCookie();
            Application.Run(new MainForm());
            VRCApi.SaveCookie();
            LocalConfig.SaveConfig();
        }
    }
}