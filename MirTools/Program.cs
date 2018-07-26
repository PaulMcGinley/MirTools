using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.UserSkins;
using System;
using System.IO;
using System.Windows.Forms;

namespace MirTools
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            // Create %LocalAppData% directories
            if (!Directory.Exists(Common.LocalAppDataPath))
                Directory.CreateDirectory(Common.LocalAppDataPath);
            if (!Directory.Exists(Common.SavedFramesPath))
                Directory.CreateDirectory(Common.SavedFramesPath);
            if (!Directory.Exists(Common.LibraryCachePath))
                Directory.CreateDirectory(Common.LibraryCachePath);

            // Create configuration file
            if (!File.Exists(Common.MirToolsConfigurationFilePath))
                Configuration.SaveConfiguration();
            else
                Configuration.LoadConfiguration();

            // Create start page files
            if (!File.Exists(Common.BookmarkFilePath))
                StartPage.Bookmarks.Save();
            else
                StartPage.Bookmarks.Load();

            if (!File.Exists(Common.HistoryFilePath))
                StartPage.History.Save();
            else
                StartPage.History.Load();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            BonusSkins.Register();
            SkinManager.EnableFormSkins();
            SkinManager.EnableMdiFormSkins();
            UserLookAndFeel.Default.SetSkinStyle("Office 2013 Dark Gray");

            Application.Run(new TfmMain());
            //Application.Run(new FirstRunWizard());
        }
    }
}