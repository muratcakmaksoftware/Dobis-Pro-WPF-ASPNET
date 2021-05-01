using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace Dobispro
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        public static MainWindow mw = new MainWindow();
        public static fonk fnk = new fonk();
        public static EkranKlavyesi klavye = new EkranKlavyesi();
        public static SayisalEkran klavyeSayi = new SayisalEkran();
        public static ogrencibilgileri ogrencibilgileri = new ogrencibilgileri();
        public static string arayuz { get; set; }
        public static decimal yaziciSayfaBasiFiyat { get; set; }

        public static DispatcherTimer tmrBeklemeSuresi = new DispatcherTimer();
        DispatcherTimer tmrprogramOneGetirme = new DispatcherTimer();
        public App()
        {
            // Programı hep üstte tutmak için öne getir yapıyoruz bir timer ile.            
            tmrprogramOneGetirme.Interval = new TimeSpan(0, 0, 0, 0, 300);
            tmrprogramOneGetirme.Tick += onegetir;
            //tmrprogramOneGetirme.Start();                        
            tmrBeklemeSuresi.Tick += zamankontrol;
            

            mw.WindowStyle = WindowStyle.None;
            mw.Content = new anagorunum();
            mw.Show();
            
        }

        void onegetir(object sender, EventArgs args)
        {
            mw.Topmost = true;
        }

        void zamankontrol(object sender, EventArgs args)
        {
            fnk.zamanAsimi();
        }

        private void OnAppStartup_UpdateThemeName(object sender, StartupEventArgs e)
        {

            DevExpress.Xpf.Core.ApplicationThemeHelper.UpdateApplicationThemeName();
        }
    }
}
