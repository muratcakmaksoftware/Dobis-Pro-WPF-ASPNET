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
using System.Globalization;

namespace Dobispro
{
    /// <summary>
    /// Interaction logic for ogrenciNerede.xaml
    /// </summary>
    public partial class ogrenciNerede : UserControl
    {
        SqlConnection bag;
        SqlCommand cmd;

        public ogrenciNerede()
        {
            InitializeComponent();

            bag = App.fnk.bag();
            double w = SystemParameters.PrimaryScreenWidth; // ekran genişliği
            double y = SystemParameters.PrimaryScreenHeight; // ekran yüksekliği
            w -= dataGridView1.Margin.Left; // datagridview sol konumundan itibaren genişlikten sil çünkü en sol kısım öğrenci bilgilerinin gösterildiği kısım
            w /= 2; // geri kalan kısmı 2 ye bölüp 2 nesne yerleştirmiş olucağız
            w -= 10; // nesnelerin aralarında 10 piksel boşluk olucağından siliyoruz.
            dataGridView1.Width = w; // yerleştireceğimiz nesneleri aynı genişliği veriyoruz.
            bolgeResim.Width = w; 
            bolgeResim.Margin = new Thickness(dataGridView1.Margin.Left + dataGridView1.Width + 10, bolgeResim.Margin.Top, bolgeResim.Margin.Right, bolgeResim.Margin.Bottom); //ilk nesnemizin yanında olacak left bilgisini verip daha sonra genişliği ile toplayıp 10 piksel boşluğunuda verip yerini konumlamış ve ekrana genişliğine sığdırmış oluyoruz.
            // arama textbox ve butonu ayarlama
            
            w = SystemParameters.PrimaryScreenWidth;
            w -= txtarama.Margin.Left;
            w -= bildirim1.Width + bildirim1.Margin.Right;
            w -= arama.Width;
            w -= 20;
            txtarama.Width = w;
            arama.Margin = new Thickness(txtarama.Margin.Left + txtarama.Width + 10, arama.Margin.Top, arama.Margin.Right, arama.Margin.Bottom);
            gizle();
            App.klavye.editText = txtarama;
            App.klavye.klavyeEnterEngel = true;
        }        

        private void geri_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (App.klavyeSayi.IsVisible)
            {
                App.klavyeSayi.Hide();
            }
            App.fnk.zamanSifirla();
            App.klavye.klavyeSecimKaldir();
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

        private void dataGridView1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int secilenindex = dataGridView1.SelectedIndex;
            if (secilenindex != -1)
            {
                try
                {
                    DataRowView drv = (DataRowView)dataGridView1.SelectedValue;
                    string rResim = drv.Row.ItemArray[5].ToString();
                    if (rResim != "")
                    {
                        cmd = new SqlCommand();
                        cmd.Connection = bag;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "dprbolgegetir";
                        cmd.Parameters.Add("@resimAdi", SqlDbType.VarChar).Value = rResim;
                        bag.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                if (dr["resim"].ToString() != "")
                                    bolgeResim.Source = App.fnk.base64ResimeCevirme(dr["resim"].ToString());
                                else
                                {
                                    Uri yol = new Uri("pack://application:,,,/images/bos.jpg", UriKind.RelativeOrAbsolute);
                                    bolgeResim.Source = new BitmapImage(yol);
                                }
                                break;
                            }
                            
                        }
                        else
                        {
                            Uri yol = new Uri("pack://application:,,,/images/bos.jpg", UriKind.RelativeOrAbsolute);
                            bolgeResim.Source = new BitmapImage(yol);
                        }
                        dr.Close();
                        bag.Close();
                    }
                    else
                    {
                        Uri yol = new Uri("pack://application:,,,/images/bos.jpg", UriKind.RelativeOrAbsolute);
                        bolgeResim.Source = new BitmapImage(yol);
                    }

                }
                catch
                {
                    Bildirim.Show(bildirim1, "Uyarı", "Seçim Sırasında Hata Oluştu.\nLütfen Tekrar Dokunun.", "Uyari");
                }
            }
        }

        void gizle()
        {
            lblAdi.Visibility = Visibility.Hidden;
            lblokulNo.Visibility = Visibility.Hidden;
            lblsinif.Visibility = Visibility.Hidden;
            lblbilgi.Visibility = Visibility.Hidden;
            dataGridView1.Visibility = Visibility.Hidden;
            bolgeResim.Visibility = Visibility.Hidden;
            imgKimlik.Visibility = Visibility.Hidden;
        }

        void goster()
        {
            lblAdi.Visibility = Visibility.Visible;
            lblokulNo.Visibility = Visibility.Visible;
            lblsinif.Visibility = Visibility.Visible;
            lblbilgi.Visibility = Visibility.Visible;
            dataGridView1.Visibility = Visibility.Visible;
            bolgeResim.Visibility = Visibility.Visible;
            imgKimlik.Visibility = Visibility.Visible;
        }

        private void txtarama_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (!App.klavye.IsVisible)
            {              
                App.klavye.editText = txtarama;
                App.klavye.Show();
                App.klavye.klavyeEkranKonumla(e.GetPosition(this));
            }

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void arama_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ara();
        }

        void ara()
        {
            if (txtarama.Text != "")
            {
                bool ogrenciBulunduMu = false;
                cmd = new SqlCommand();
                cmd.Connection = bag;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ogrenciara";
                cmd.Parameters.Add("@tcno", SqlDbType.VarChar).Value = txtarama.Text;
                cmd.Parameters.Add("@ogrenciAdi", SqlDbType.VarChar).Value = txtarama.Text;
                cmd.Parameters.Add("@okulno", SqlDbType.VarChar).Value = txtarama.Text;
                bag.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ogrenciBulunduMu = true;
                    App.ogrencibilgileri.ogrenciAdi = dr["isim"].ToString();
                    App.ogrencibilgileri.ogrenciOkulno = dr["okulno"].ToString();
                    App.ogrencibilgileri.ogrenciSinifi = dr["ogSinif"].ToString();
                    App.ogrencibilgileri.ogrenciResmi = dr["ogResim"].ToString();
                    break;
                }
                dr.Close();
                bag.Close();

                if (ogrenciBulunduMu)
                {
                    lblAdi.Content= "Adı:"+App.ogrencibilgileri.ogrenciAdi;
                    lblsinif.Content = "Sınıf:"+App.ogrencibilgileri.ogrenciSinifi;
                    lblokulNo.Content = "No:"+App.ogrencibilgileri.ogrenciOkulno;
                    try
                    {
                        imgKimlik.Source = App.fnk.base64ResimeCevirme(App.ogrencibilgileri.ogrenciResmi);
                    }
                    catch
                    {
                        Uri yol = new Uri("pack://application:,,,/images/kim.png", UriKind.RelativeOrAbsolute);
                        imgKimlik.Source = new BitmapImage(yol);
                    }
                    goster();
                    dersPrograminiGetir(App.ogrencibilgileri.ogrenciSinifi);
                }
                else
                {
                    Bildirim.Show(bildirim1, "Öğrenci Ara", "Öğrenciyi Bulamadık\nDiğer Alternatifleri\nDeneyin.", "Uyarı");
                    gizle();
                }
            }
            else
            {
                Bildirim.Show(bildirim1, "Öğrenci Ara", "Öğrenci Adı,\nÖğrenci Numarası\nveyaÖğrencinin T.C No Giriniz.", "Uyarı");
                gizle();
            }
        }

        void dersPrograminiGetir(string sinif)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ders");
            dt.Columns.Add("giris");
            dt.Columns.Add("cikis");
            dt.Columns.Add("dersOgretmen");
            dt.Columns.Add("dersAdi");
            dt.Columns.Add("dersSinif");
            int suankiDers = -1;
            int sira = -1;
            cmd = new SqlCommand();
            cmd.Connection = bag;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "dpgetirsinif";
            cmd.Parameters.Add("@sinif", SqlDbType.VarChar).Value = sinif;
            bag.Open();
            SqlDataReader dr = cmd.ExecuteReader();            
            DataRow row;
            while (dr.Read())
            {
                sira++;
                switch (CultureInfo.GetCultureInfo("tr-TR").DateTimeFormat.DayNames[(int)DateTime.Now.DayOfWeek].ToString().ToLower())
                {
                    case "pazartesi":                        
                        row = dt.NewRow();
                        if (Convert.ToDateTime(DateTime.Now.ToShortTimeString()) >= Convert.ToDateTime(dr["giris"].ToString()) && Convert.ToDateTime(DateTime.Now.ToShortTimeString()) < Convert.ToDateTime(dr["cikis"].ToString()))
                        {
                            suankiDers = sira;
                            lblbilgi.Content = "Durum: " + dr["ders"].ToString() + " Giriş: " + dr["giris"].ToString() + " Çıkış: " + dr["cikis"].ToString() + "";
                        }
                        row["ders"] = dr["ders"].ToString();
                        row["giris"] = dr["giris"].ToString();
                        row["cikis"] = dr["cikis"].ToString();
                        row["dersOgretmen"] = dr["pztDersOgretmen"].ToString();
                        row["dersAdi"] = dr["pztDersAdi"].ToString();
                        row["dersSinif"] = dr["pztDersSinif"].ToString();
                        dt.Rows.Add(row);

                        break;
                    case "salı":
                        row = dt.NewRow();
                        if (Convert.ToDateTime(DateTime.Now.ToShortTimeString()) >= Convert.ToDateTime(dr["giris"].ToString()) && Convert.ToDateTime(DateTime.Now.ToShortTimeString()) < Convert.ToDateTime(dr["cikis"].ToString()))
                        {
                            suankiDers = sira;
                            lblbilgi.Content = "Durum: " + dr["ders"].ToString() + " Giriş: " + dr["giris"].ToString() + " Çıkış: " + dr["cikis"].ToString() + "";
                        }
                        row["ders"] = dr["ders"].ToString();
                        row["giris"] = dr["giris"].ToString();
                        row["cikis"] = dr["cikis"].ToString();
                        row["dersOgretmen"] = dr["saliDersAdi"].ToString();
                        row["dersAdi"] = dr["saliDersOgretmen"].ToString();
                        row["dersSinif"] = dr["saliDersSinif"].ToString();
                        dt.Rows.Add(row);
                        break;
                    case "çarşamba":
                        row = dt.NewRow();
                        if (Convert.ToDateTime(DateTime.Now.ToShortTimeString()) >= Convert.ToDateTime(dr["giris"].ToString()) && Convert.ToDateTime(DateTime.Now.ToShortTimeString()) < Convert.ToDateTime(dr["cikis"].ToString()))
                        {
                            suankiDers = sira;
                            lblbilgi.Content = "Durum: " + dr["ders"].ToString() + " Giriş: " + dr["giris"].ToString() + " Çıkış: " + dr["cikis"].ToString() + "";
                        }
                        row["ders"] = dr["ders"].ToString();
                        row["giris"] = dr["giris"].ToString();
                        row["cikis"] = dr["cikis"].ToString();
                        row["dersOgretmen"] = dr["carDersAdi"].ToString();
                        row["dersAdi"] = dr["carDersOgretmen"].ToString();
                        row["dersSinif"] = dr["carDersSinif"].ToString();
                        dt.Rows.Add(row);
                        break;
                    case "perşembe":
                        row = dt.NewRow();
                        if (Convert.ToDateTime(DateTime.Now.ToShortTimeString()) >= Convert.ToDateTime(dr["giris"].ToString()) && Convert.ToDateTime(DateTime.Now.ToShortTimeString()) < Convert.ToDateTime(dr["cikis"].ToString()))
                        {
                            suankiDers = sira;
                            lblbilgi.Content = "Durum: " + dr["ders"].ToString() + " Giriş: " + dr["giris"].ToString() + " Çıkış: " + dr["cikis"].ToString() + "";
                        }

                        row["ders"] = dr["ders"].ToString();
                        row["giris"] = dr["giris"].ToString();
                        row["cikis"] = dr["cikis"].ToString();
                        row["dersOgretmen"] = dr["perDersAdi"].ToString();
                        row["dersAdi"] = dr["perDersOgretmen"].ToString();
                        row["dersSinif"] = dr["perDersSinif"].ToString();
                        dt.Rows.Add(row);
                        break;
                    case "cuma":
                        row = dt.NewRow();
                        if (Convert.ToDateTime(DateTime.Now.ToShortTimeString()) >= Convert.ToDateTime(dr["giris"].ToString()) && Convert.ToDateTime(DateTime.Now.ToShortTimeString()) < Convert.ToDateTime(dr["cikis"].ToString()))
                        {
                            suankiDers = sira;
                            lblbilgi.Content = "Durum: " + dr["ders"].ToString() + " Giriş: " + dr["giris"].ToString() + " Çıkış: " + dr["cikis"].ToString() + "";
                        }

                        row["ders"] = dr["ders"].ToString();
                        row["giris"] = dr["giris"].ToString();
                        row["cikis"] = dr["cikis"].ToString();
                        row["dersOgretmen"] = dr["cumaDersAdi"].ToString();
                        row["dersAdi"] = dr["cumaDersOgretmen"].ToString();
                        row["dersSinif"] = dr["cumaDersSinif"].ToString();
                        dt.Rows.Add(row);
                        break;
                } 
                
            }
            dr.Close();
            bag.Close();          
            dataGridView1.ItemsSource = dt.DefaultView;
            gridTasarim();

            if(suankiDers != -1)
            {
                Dispatcher.Invoke(new Action(delegate ()
                {
                    dataGridView1.SelectedIndex = suankiDers;
                    dataGridView1.Focus();
                }), System.Windows.Threading.DispatcherPriority.Background);

            }
            if(App.klavye.IsVisible)
                App.klavye.Hide();
            Bildirim.Show(bildirim1, "Bulduk", "Öğrencinizi Bulduk!", "Bilgi");
        }

        void gridTasarim()
        {            
            dataGridView1.Columns[0].Header = "Ders";
            dataGridView1.Columns[1].Header = "Giriş";
            dataGridView1.Columns[2].Header = "Çıkış";
            dataGridView1.Columns[3].Header = "Dersin Öğretmen";
            dataGridView1.Columns[4].Header = "Ders Adı";
            dataGridView1.Columns[5].Header = "Ders Sınıf";

            dataGridView1.ColumnWidth = dataGridView1.Width / (dataGridView1.Columns.Count - 1);
            //dataGridView1.ColumnHeaderHeight = 25;                        
            //dataGridView1.RowHeight = dataGridView1.Height / dataGridView1.Items.Count;
            dataGridView1.RowHeight = 35;
            dataGridView1.HorizontalContentAlignment = HorizontalAlignment.Center;
        }

        private void txtarama_EditValueChanged(object sender, DevExpress.Xpf.Editors.EditValueChangedEventArgs e)
        {
            try
            {
                if (txtarama.Text.LastIndexOf("[ENTER]") != -1)
                {
                    txtarama.Text = txtarama.Text.Substring(0, txtarama.Text.LastIndexOf("[ENTER]"));                    
                    ara();                    
                }
            }
            catch
            {
                Bildirim.Show(bildirim1, "Uyarı", "Kısayol Hatası", "Hata");
            }
        }
    }   
        

}

