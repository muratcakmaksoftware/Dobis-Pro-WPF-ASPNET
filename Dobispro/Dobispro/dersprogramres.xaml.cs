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
    public partial class dersprogramres : UserControl
    {
        SqlConnection bag;
        SqlCommand cmd;
       
        public dersprogramres()
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
            if (cmbSinif.Items.Count > 0)
            {
                dersProgramResim.Source = App.fnk.base64ResimeCevirme(sinifDersProgram[cmbSinif.SelectedIndex]);
            }
        }

        List<string> sinifDersProgram = new List<string>();

        void sinifBilgileriniGetir()
        {
            cmd = new SqlCommand();
            cmd.Connection = bag;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "dprSadeceSinifResmi";            
            bag.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cmbSinif.Items.Add(dr["sinif"].ToString());
                sinifDersProgram.Add(dr["resim"].ToString());
            }
            dr.Close();
            bag.Close();
            for (int i = 0; i < cmbSinif.Items.Count; i++)
            {
                if (App.arayuz == "veli")
                {
                    cmbSinif.SelectedIndex = i;
                    break;
                }

                if (cmbSinif.Items[i].ToString() == App.ogrencibilgileri.ogrenciSinifi)
                {
                    cmbSinif.SelectedIndex = i;
                    break;
                }
            }
            
        }
    }
}
