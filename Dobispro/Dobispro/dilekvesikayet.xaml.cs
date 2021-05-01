using System;
using System.Collections.Generic;
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
using System.Data;
using System.Data.SqlClient;

namespace Dobispro
{
    /// <summary>
    /// Interaction logic for dilekvesikayet.xaml
    /// </summary>
    public partial class dilekvesikayet : UserControl
    {
        public dilekvesikayet()
        {
            InitializeComponent();
            bag = App.fnk.bag();
        }

        SqlConnection bag;
        SqlCommand cmd;

        private void geri_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            App.fnk.zamanSifirla();
            App.klavye.klavyeSecimKaldir();
            if (App.klavye.IsVisible)
            {
                App.klavye.Hide();
            }

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

        private void txtkonu_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            App.fnk.zamanSifirla();
            App.klavye.textBox = null;
            App.klavye.klavyeEnterEngel = true;
            App.klavye.editText = txtkonu;
            App.klavye.klavyeEkranKonumla(e.GetPosition(this));
            if (!App.klavye.IsVisible)
                App.klavye.Show();

        }

        private void txtmesaj_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            App.fnk.zamanSifirla();
            App.klavye.editText = null;
            App.klavye.klavyeEnterEngel = false;
            App.klavye.textBox = txtmesaj;
            App.klavye.klavyeEkranKonumla(e.GetPosition(this));
            if (!App.klavye.IsVisible)
                App.klavye.Show();
        }

        private void txtkonu_EditValueChanged(object sender, DevExpress.Xpf.Editors.EditValueChangedEventArgs e)
        {
            try
            {
                if (txtkonu.Text.LastIndexOf("[ENTER]") != -1)
                {
                    txtkonu.Text = txtkonu.Text.Substring(0, txtkonu.Text.LastIndexOf("[ENTER]"));
                    App.klavye.editText = null;
                    App.klavye.klavyeEnterEngel = false;
                    App.klavye.textBox = txtmesaj;                    
                    txtmesaj.Focus();                    

                }
            }
            catch
            {               
            }
        }

        private void gonder_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            App.fnk.zamanSifirla();
            
            if (txtkonu.Text != "" && txtmesaj.Text != "")
            {
                App.klavye.Hide();
                if (MessageBox.Show("Göndermek İstediğinize Emin Misiniz ?", "Dilek Ve Şikayet", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.Yes)
                {                    
                    if(App.ogrencibilgileri.ogrenciAdi != "")
                        txtmesaj.Text += "\n\nGönderen Bilgileri:\n" +
                            "Öğrencinin Adı: "+App.ogrencibilgileri.ogrenciAdi+"\n"+
                            "Öğrencinin Numarası: " + App.ogrencibilgileri.ogrenciOkulno + "\n" +
                            "Öğrencinin Sınıfı: " + App.ogrencibilgileri.ogrenciSinifi+ "" +
                            "";

                    cmd = new SqlCommand();
                    cmd.Connection = bag;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "dvsekle";
                    cmd.Parameters.Add("@konu", SqlDbType.VarChar).Value = txtkonu.Text;
                    cmd.Parameters.Add("@mesaj", SqlDbType.VarChar).Value = txtmesaj.Text;
                    bag.Open();
                    cmd.ExecuteNonQuery();
                    bag.Close();
                    txtkonu.Text = "";
                    txtmesaj.Text = "";
                    Bildirim.Show(bildirim1, "Teşekkürler", "Bildirin Bize Ulaşmıştır.", "Bilgi");
                }
            }
            else
                Bildirim.Show(bildirim1, "Uyarı", "Lütfen Gerekli Yerleri Doldurun.", "Uyarı");
        }
    }
}
