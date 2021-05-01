using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace Dobispro
{
    /// <summary>
    /// Interaction logic for Bildirim.xaml
    /// </summary>
    public partial class Bildirim : UserControl
    {
        DispatcherTimer timer = new DispatcherTimer();

        public Bildirim()
        {
            InitializeComponent();

            timer.Interval = new TimeSpan(0, 0, 5);
            timer.Tick += (sender, e) =>
            {
                timer.Stop();
                DoubleAnimation animKapa = new DoubleAnimation(1, 0, new Duration(new TimeSpan(0, 0, 2)));
                BeginAnimation(OpacityProperty, animKapa);
            };
        }

        public Bildirim(string baslik, string icerik, string resim)
        {
            InitializeComponent();

            timer.Interval = new TimeSpan(0, 0, 5);
            timer.Tick += (sender, e) =>
            {
                timer.Stop();
                DoubleAnimation animKapa = new DoubleAnimation(1, 0, new Duration(new TimeSpan(0, 0, 2)));
                BeginAnimation(OpacityProperty, animKapa);
            };
        }

        public static void Show(Bildirim bld, string baslik, string icerik, string resim)
        {            
            bld.Baslik.Content = baslik;
            bld.Icerik.Text = icerik;
            switch (resim)
            {
                case "Hata":
                    bld.Resim.Source = new BitmapImage(new Uri("images/Error.png", UriKind.Relative));
                    break;
                case "Uyarı":
                    bld.Resim.Source = new BitmapImage(new Uri("images/Warning.png", UriKind.Relative));
                    break;
                case "Bilgi":
                    bld.Resim.Source = new BitmapImage(new Uri("images/info.png", UriKind.Relative));
                    break;
            }            

            DoubleAnimation animAc = new DoubleAnimation(0, 1, new Duration(new TimeSpan(0, 0, 1)));
            bld.BeginAnimation(OpacityProperty, animAc);
            bld.timer.Start();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (timer.IsEnabled)
                timer.Stop();
            DoubleAnimation animKapa = new DoubleAnimation(Opacity, 0, new Duration(new TimeSpan(0, 0, 2)));
            BeginAnimation(OpacityProperty, animKapa);
        }
    }
}
