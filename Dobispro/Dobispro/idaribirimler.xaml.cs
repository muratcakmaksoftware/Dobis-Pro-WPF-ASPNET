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
    /// Interaction logic for dersprogramres.xaml
    /// </summary>
    public partial class idaribirimler : UserControl
    {
        SqlConnection bag;
        SqlCommand cmd;
       
        public idaribirimler()
        {
            InitializeComponent();
            bag = App.fnk.bag();
            sinifBilgileriniGetir();
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

        private void cmbSinif_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            App.fnk.zamanSifirla();
            if (cmbIdari.Items.Count > 0)
            {
                dersProgramResim.Source = App.fnk.base64ResimeCevirme(idariBirimler[cmbIdari.SelectedIndex]);
            }
        }

        List<string> idariBirimler = new List<string>();

        void sinifBilgileriniGetir()
        {
            cmd = new SqlCommand();
            cmd.Connection = bag;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ibgetir";            
            bag.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cmbIdari.Items.Add(dr["resimAdi"].ToString());
                idariBirimler.Add(dr["resim"].ToString());
            }
            dr.Close();
            bag.Close();

            if(cmbIdari.Items.Count > 0)
            {
                cmbIdari.SelectedIndex = 0;
            }
        }
    }
}
