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
    /// Interaction logic for arayuz.xaml
    /// </summary>
    public partial class arayuz : UserControl
    {
        public arayuz()
        {
            InitializeComponent();
        }

        private void ogrenci_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            App.fnk.zamanSifirla();
            App.arayuz = "ogrenci";
            App.mw.Content = new ogrenciLogin();
        }

        private void ogrenci_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            App.fnk.zamanSifirla();
            App.arayuz = "ogrenci";
            App.mw.Content = new ogrenciLogin();
        }

        private void veli_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            App.fnk.zamanSifirla();
            App.arayuz = "veli";
            App.mw.Content = new veliArayuz();
        }
    }
}
