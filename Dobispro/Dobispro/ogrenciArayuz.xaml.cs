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

namespace Dobispro
{
    /// <summary>
    /// Interaction logic for ogrenciArayuz.xaml
    /// </summary>
    public partial class ogrenciArayuz : UserControl
    {
        public ogrenciArayuz()
        {
            InitializeComponent();
        }

        private void dilekvesikayet_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            App.fnk.zamanSifirla();
            App.mw.Content = new dilekvesikayet();
        }

        private void geri_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            App.fnk.zamanSifirla();
            App.ogrencibilgileri.ogrenciBilgileriniTemizle();
            App.mw.Content = new ogrenciLogin();
        }

        private void dersprogram_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            App.fnk.zamanSifirla();
            App.mw.Content = new dersprogramres();
        }

        private void idaribirimler_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            App.fnk.zamanSifirla();
            App.mw.Content = new idaribirimler();
        }

        /*private void maltepeuniwebsite_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            App.fnk.zamanSifirla();
            App.mw.Content = new webtarayici();
        }*/

        private void yazici_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            App.fnk.zamanSifirla();
            App.mw.Content = new yazici();
        }
    }
}
