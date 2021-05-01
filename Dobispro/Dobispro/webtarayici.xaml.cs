using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
    /// Interaction logic for webtarayici.xaml
    /// </summary>
    public partial class webtarayici : UserControl
    {
        public webtarayici()
        {
            InitializeComponent();
            HideScriptErrors(webBrowser, true);
            webBrowser.Navigate("http://mubis.maltepe.edu.tr/");
            if (!App.klavye.IsVisible)
                App.klavye.Show();
        }
        public void HideScriptErrors(WebBrowser wb, bool hide)
        {
            var fiComWebBrowser = typeof(WebBrowser).GetField("_axIWebBrowser2", BindingFlags.Instance | BindingFlags.NonPublic);
            if (fiComWebBrowser == null) return;
            var objComWebBrowser = fiComWebBrowser.GetValue(wb);
            if (objComWebBrowser == null)
            {
                wb.Loaded += (o, s) => HideScriptErrors(wb, hide); //In case we are to early
                return;
            }
            objComWebBrowser.GetType().InvokeMember("Silent", BindingFlags.SetProperty, null, objComWebBrowser, new object[] { hide });
        }

        private void geri_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            App.klavye.klavyeSecimKaldir();
            if (App.klavye.IsVisible)
                App.klavye.Hide();
            App.fnk.zamanSifirla();
            App.mw.Content = new ogrenciArayuz();
        }

        private void webBrowser_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            App.fnk.zamanSifirla();
        }
    }
}
