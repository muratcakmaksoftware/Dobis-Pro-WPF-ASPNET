using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Dobispro
{
    /// <summary>
    /// Interaction logic for anagorunum.xaml
    /// </summary>
    public partial class anagorunum : UserControl
    {
        public anagorunum()
        {
            InitializeComponent();
        }

        List<string> resimData = new List<string>();
        DispatcherTimer slaytTimer = new DispatcherTimer();
        SqlConnection bag;
        SqlCommand cmd;
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            bag = App.fnk.bag();
            App.fnk.zamanDurdur();
            okulbg.Width = SystemParameters.PrimaryScreenWidth * 0.70; // okul arkaplanı ekranın genişik olarak %70 lik bölmünü kaplasın
            saatbg.Width = SystemParameters.PrimaryScreenWidth * 0.30; // saat arkaplanı ekranın genişik olarak %30 luk bölmünü kaplasın            
            new Thread(zamaniGoster).Start();
            //new Thread(resimleriGoster).Start();
            genelBilgileriGetir();
            resimleriYukle();
            Bildirim.Show(bildirim1, "Başlayalım", "Başlamak için ekrana dokunun.", "Bilgi");
        }


        void zamaniGoster()
        {
            while(true)
            {
                lblSaat.Dispatcher.BeginInvoke((ThreadStart)delegate ()
                {
                    lblSaat.Content =  DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString();
                    lblSaat.Margin = new Thickness { Left = 0, Top = 22, Bottom = 0, Right = (SystemParameters.PrimaryScreenWidth * 0.30) - lblSaat.ActualWidth }; //yazıyı başa hizalamak için.
                });
                Thread.Sleep(100); // 100 milisaniyede 1 kere Zamanı güncelleyecek.
            }
        }

        int resimindex = -1;
        void resimleriGoster(object sender, EventArgs args)
        {            
            if (resimData.Count > 0)
            {
                resimindex++;
                gorunenResim.Source = App.fnk.base64ResimeCevirme(resimData[resimindex].ToString());

                if (resimindex >= resimData.Count - 1)
                    resimindex = -1;
            }            
        }
        
        void resimleriYukle()
        {
            cmd = new SqlCommand();
            cmd.Connection = bag;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "slaytlariGetir";
            bag.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                resimData.Add(dr["resim"].ToString());
            }
            dr.Close();
            bag.Close();
        }
        
        void genelBilgileriGetir()
        {
            App.yaziciSayfaBasiFiyat = 2;
            int slaytSuresi = 1, zamanAsimiSuresi = 3;
            cmd = new SqlCommand();
            cmd.Connection = bag;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "genelgetir";
            bag.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lblOkulAdi.Content = dr["okulAdi"].ToString();
                slaytSuresi = Convert.ToInt32(dr["slaytSuresi"]);
                zamanAsimiSuresi = Convert.ToInt32(dr["beklemeSuresi"]);
                App.yaziciSayfaBasiFiyat = Convert.ToDecimal(dr["sayfaBasiFiyat"]);
            }
            dr.Close();
            bag.Close();
            App.tmrBeklemeSuresi.Interval = new TimeSpan(0,zamanAsimiSuresi,0);
            slaytTimer.Interval = new TimeSpan(0, 0, 0);// başlangıç için 100 milisaniyede girişini sağlayıp
            slaytTimer.Tick += resimleriGoster;
            slaytTimer.Start();
            slaytTimer.Interval = new TimeSpan(0, 0, slaytSuresi); // daha sonra slayt bekleme süresine ayarlıyoruz.
        }
        
        

        private void gorunenResim_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            App.mw.Content = new arayuz();
            App.fnk.zamanBaslat();
        }

        private void gorunenResim_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            App.mw.Content = new arayuz();
            App.fnk.zamanBaslat();
        }
    }
}
