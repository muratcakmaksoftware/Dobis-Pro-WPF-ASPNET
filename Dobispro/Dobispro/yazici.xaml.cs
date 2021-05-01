using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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

namespace Dobispro
{
    /// <summary>
    /// Interaction logic for yazici.xaml
    /// </summary>
    public partial class yazici : UserControl
    {
        public yazici()
        {
            InitializeComponent();

            
        }

        void usbSearch()
        {
            bool usbBulundumu = false;
            try
            {
                cmbUsb.Items.Clear();
                foreach (DriveInfo drive in DriveInfo.GetDrives())
                {
                    if (drive.DriveType == DriveType.Removable)
                    {
                        cmbUsb.Items.Add(drive.RootDirectory.FullName);
                        usbBulundumu = true;
                    }
                }
            }
            catch
            {
                Bildirim.Show(bildirim1, "USB Kontrol", "USB Arama Hatası", "Hata");
                return;
            }
            try
            {
                if (usbBulundumu)
                {
                    cmbUsb.SelectedIndex = 0;                    
                    Bildirim.Show(bildirim1, "USB Kontrol", "USB Bulundu.", "Bilgi");
                    
                }
                else
                    Bildirim.Show(bildirim1, "USB Kontrol", "Takılı USB Bulunamadı.", "Bilgi");
            }
            catch
            {
                Bildirim.Show(bildirim1, "USB Kontrol", "USB Seçim Hatası.", "Hata");
            }
        }


        void gereksizDosyalariSil()
        {
            foreach (string file in Directory.GetFiles(System.Environment.CurrentDirectory + "\\cop\\"))
            {
                try
                {
                    File.Delete(file);
                }
                catch
                { }
            }

        }

        public class MyItem
        {
            public string tamAdi { get; set; }
            public string adi { get; set; }
            public string tur { get; set; }
            public long boyut { get; set; }
            public string tarih { get; set; }
        }

        void listViewTasarim()
        {
            // xaml Ekleme
            /*
                <GridViewColumn Header="Tam Adı" Width="200" DisplayMemberBinding="{Binding tamAdi}"/>
                <GridViewColumn Header="Adı" Width="250" DisplayMemberBinding="{Binding adi}"/>
                <GridViewColumn Header="Boyut" Width="200" DisplayMemberBinding="{Binding boyut}"/>
                <GridViewColumn Header="Oluşturma Tarihi" Width="200" DisplayMemberBinding="{Binding tarih}"/> 
             */

            GridView gridView = new GridView();
            listView1.View = gridView;
            string[] idler = new string[] { "tamAdi", "adi", "tur", "boyut", "tarih" };
            string[] isimler = new string[] { "Tam Adı", "Adı", "Tür", "Boyut", "Oluşturma Tarihi" };
            double gnslk = listView1.ActualWidth / idler.Length;
            GridViewColumn clm;
            for (int i = 0; i < idler.Length; i++)
            {
                clm = new GridViewColumn();
                clm.Header = isimler[i].ToString();
                clm.DisplayMemberBinding = new Binding(idler[i]);
                clm.Width = gnslk;
                gridView.Columns.Add(clm);

                /*
                gridView.Columns.Add(new GridViewColumn{
                    Header = isimler[i].ToString(),
                    DisplayMemberBinding = new Binding(idler[i]),
                    Width = gnslk
                });*/

            }
            listView1.View = gridView;

        }

        void klasorListele(string dizin)
        {
            foreach (string klasor in Directory.GetDirectories(dizin))
            {
                //listBox1.Items.Add(klasor); // klasörüde ekle
                dosyaListele(klasor);
            }

        }
        FileInfo inf;
        void dosyaListele(string dizin)
        {
            foreach (string file in Directory.GetFiles(dizin))
            {
                inf = new FileInfo(file);
                string uzanti = inf.Extension.ToLower();
                if (uzanti == ".xls" || uzanti == ".xlsx" || uzanti == ".doc" || uzanti == ".docx" || uzanti == ".pdf")
                {
                    listView1.Items.Add(new MyItem { tamAdi = inf.FullName, adi = inf.Name, tur = inf.Extension.ToUpper().Replace(".", ""), boyut = inf.Length, tarih = inf.CreationTime.ToString() });
                }
            }
            klasorListele(dizin);
        }

        private void cmbUsb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            App.fnk.zamanSifirla();
            try
            {
                dosyaListele(cmbUsb.Items[cmbUsb.SelectedIndex].ToString());
            }
            catch
            {
                Bildirim.Show(bildirim1, "USB Kontrol", "USB Dosya Listeleme Hatası.", "Hata");
            }
        }

        private void secileniGoster_Click(object sender, RoutedEventArgs e)
        {
            App.fnk.zamanSifirla();
            if (listView1.SelectedIndex == -1)
                Bildirim.Show(bildirim1, "USB Kontrol", "Listeden Seçim Yapınız.", "Uyari");
            else
            {
                MyItem s = (MyItem)listView1.SelectedItems[0];
                App.ogrencibilgileri.yaziciSecilenTamAd = s.tamAdi.ToString();
                App.ogrencibilgileri.yaziciSecilenAd = s.adi.ToString();
                App.ogrencibilgileri.yaziciSecilenTip = s.tur.ToString();
                App.mw.Content = new yazicigoruntule();
            }
        }

        private void geri_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {            
            App.fnk.zamanSifirla();
            switch (App.arayuz)
            {
                case "ogrenci":
                    App.mw.Content = new ogrenciArayuz();
                    break;
                case "veli":
                    App.mw.Content = new veliArayuz();
                    break;
            }
        }

        private void usbAra_Click(object sender, RoutedEventArgs e)
        {
            App.fnk.zamanSifirla();
            usbSearch();
        }
        
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            lblAd.Content = "İsim :" + App.ogrencibilgileri.ogrenciAdi;
            lblMiktar.Content = "Bakiye :" + App.ogrencibilgileri.ogrenciPara;

            listViewTasarim();
            usbSearch();
            gereksizDosyalariSil();
        }
    }
}
