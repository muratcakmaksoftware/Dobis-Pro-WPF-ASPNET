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
    /// Interaction logic for ogrenciLogin.xaml
    /// </summary>
    public partial class ogrenciLogin : UserControl
    {
        SqlConnection bag;
        SqlCommand cmd;

        public ogrenciLogin()
        {
            bag = App.fnk.bag();
            InitializeComponent();
        }

        private void geri_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            if (App.klavyeSayi.IsVisible)
            {
                App.klavyeSayi.Hide();
            }
            App.fnk.zamanSifirla();
            App.klavyeSayi.klavyeSecimKaldir();
            App.mw.Content = new arayuz();
            
        }

        private void geri_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (App.klavyeSayi.IsVisible)
            {
                App.klavyeSayi.Hide();
            }
            App.fnk.zamanSifirla();
            App.klavyeSayi.klavyeSecimKaldir();
            App.mw.Content = new arayuz();
        }
            
        

        private void txtTcNo_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            App.fnk.zamanSifirla();
            App.klavyeSayi.editText = txtTcNo;
            App.klavyeSayi.passText = null;

            if (!App.klavyeSayi.IsVisible)
            {
                App.klavyeSayi.Show();
                App.klavyeSayi.sayisalTouchEkranKonumla(e.GetTouchPoint(this));
            }
            else
            {
                App.klavyeSayi.sayisalTouchEkranKonumla(e.GetTouchPoint(this));
            }
        }

        private void txtTcNo_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            App.fnk.zamanSifirla();
            App.klavyeSayi.editText = txtTcNo;
            App.klavyeSayi.passText = null;
            
            if (!App.klavyeSayi.IsVisible)
            {
                App.klavyeSayi.Show();
                App.klavyeSayi.sayisalEkranKonumla(e.GetPosition(this));
            }
            else
            {
                App.klavyeSayi.sayisalEkranKonumla(e.GetPosition(this));
            }
            
        }

        

        private void txtTcNo_EditValueChanged(object sender, DevExpress.Xpf.Editors.EditValueChangedEventArgs e)
        {
            try
            {
                if (txtTcNo.Text.LastIndexOf("[OK]") != -1)
                {
                    txtTcNo.Text = txtTcNo.Text.Substring(0, txtTcNo.Text.LastIndexOf("[OK]"));
                    if (txtTcNo.Text.Length == 11)
                    {
                        App.klavyeSayi.editText = null;
                        App.klavyeSayi.passText = txtSifre;
                        txtSifre.Focus();
                        
                    }

                }
                if (txtTcNo.Text.Length > 11)
                {
                    txtTcNo.Text = txtTcNo.Text.Substring(0, 11);
                }
            }
            catch
            {
                Bildirim.Show(bildirim1, "Uyarı", "Kısayol Hatası", "Hata");
            }
        }

        private void txtSifre_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            App.fnk.zamanSifirla();
            App.klavyeSayi.editText = null;
            App.klavyeSayi.passText = txtSifre;

            if (!App.klavyeSayi.IsVisible)
            {
                App.klavyeSayi.Show();
                App.klavyeSayi.sayisalTouchEkranKonumla(e.GetTouchPoint(this));
            }
            else
            {
                App.klavyeSayi.sayisalTouchEkranKonumla(e.GetTouchPoint(this));
            }
        }

        private void txtSifre_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            App.fnk.zamanSifirla();
            App.klavyeSayi.editText = null;
            App.klavyeSayi.passText = txtSifre;

            if (!App.klavyeSayi.IsVisible)
            {
                App.klavyeSayi.Show();
                App.klavyeSayi.sayisalEkranKonumla(e.GetPosition(this));
            }
            else
            {
                App.klavyeSayi.sayisalEkranKonumla(e.GetPosition(this));
            }
        }

        private void txtSifre_EditValueChanged(object sender, DevExpress.Xpf.Editors.EditValueChangedEventArgs e)
        {
            try
            {
                if (txtSifre.Text.IndexOf("[OK]") != -1)
                {
                    txtSifre.Text = txtSifre.Text.Substring(0, txtSifre.Text.IndexOf("[OK]"));
                    login(txtTcNo.Text, txtSifre.Text);
                }
            }
            catch
            {
                Bildirim.Show(bildirim1, "Uyarı", "Kısayol Hatası", "Hata");
            }
        }

        private void girisYap_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            login(txtTcNo.Text, txtSifre.Text);
        }

        private void girisYap_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            login(txtTcNo.Text, txtSifre.Text);
        }


        void login(string tcno, string sifre)
        {
            string baslik = "", hatamesaji = "";
            if (tcno != "" && sifre != "" && tcno.Length == 11)
            {
                if (App.fnk.tckontrol(ref baslik, ref hatamesaji, tcno))
                {
                    bool ogrenciBulunduMu = false;
                    cmd = new SqlCommand();
                    cmd.Connection = bag;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "ogrencilogin";
                    cmd.Parameters.Add("@ogtc", SqlDbType.VarChar).Value = tcno;
                    cmd.Parameters.Add("@ogsifre", SqlDbType.VarChar).Value = sifre;
                    bag.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        ogrenciBulunduMu = true;
                        App.ogrencibilgileri.ogrenciId = Convert.ToInt32(dr["id"]);
                        App.ogrencibilgileri.ogrenciAdi = dr["isim"].ToString();
                        App.ogrencibilgileri.ogrenciTc = dr["tcno"].ToString();
                        App.ogrencibilgileri.ogrenciSifre = dr["sifre"].ToString();
                        App.ogrencibilgileri.ogrenciOkulno = dr["okulno"].ToString();
                        App.ogrencibilgileri.ogrenciSinifi = dr["ogSinif"].ToString();
                        App.ogrencibilgileri.ogrenciResmi = dr["ogResim"].ToString();
                        App.ogrencibilgileri.ogrenciPara = Convert.ToDecimal(dr["miktar"]);
                    }
                    dr.Close();
                    bag.Close();
                    if (ogrenciBulunduMu)
                    {
                        if (App.klavyeSayi.IsVisible)
                            App.klavyeSayi.Hide();

                        Bildirim.Show(bildirim1, "Hoşgeldin,", App.ogrencibilgileri.ogrenciAdi, "Bilgi");
                        App.mw.Content = new ogrenciArayuz();
                    }
                    else
                        Bildirim.Show(bildirim1, "Doğrulama", "Kullanıcı Adı Veya Şifre Yanlış", "Uyarı");


                }
                else
                {
                    Bildirim.Show(bildirim1, baslik, hatamesaji, baslik);
                }
            }
            else
            {
                Bildirim.Show(bildirim1, "Doğrulama", "Gerekli Yerleri Doldurun", "Uyarı");
            }
        }
       
    }
}
