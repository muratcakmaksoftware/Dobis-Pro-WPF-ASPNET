using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Runtime.InteropServices;

namespace Dobispro
{
    /// <summary>
    /// Interaction logic for EkranKlavyesi.xaml
    /// </summary>
    public partial class EkranKlavyesi : Window
    {
        
        public TextBox textBox { get; set; }
        public DevExpress.Xpf.Editors.TextEdit editText { get; set; }
        public bool klavyeEnterEngel = false;
        public EkranKlavyesi()
        {
            InitializeComponent();

            foreach (Button b in Grid.Children)
            {
                b.Click += Tus_Click;
            }           
        }

        public void klavyeSecimKaldir()
        {
            textBox = null;
            editText = null;
            klavyeEnterEngel = false;
        }

        public void klavyeEkranKonumla(Point textpoint)
        {
            this.Top = textpoint.Y + 50;
        }

        public void klavyeEkranKonumla(TouchPoint touchpoint)
        {
            this.Top = touchpoint.Position.Y + 50;
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);

            e.Cancel = true;
            Hide();
        }
        
        private void Tus_Click(object sender, RoutedEventArgs e)
        {
            App.fnk.zamanSifirla();
            if (textBox == null && editText == null)
                return;
            
            if(textBox != null)
                textBox.Focus();
            if (editText != null)
                editText.Focus();

            Button btn = (Button)sender;
            if (btn.Name == "o16")
            {
                if(textBox!= null)
                    textBox.Text += " ";

                if (editText != null)
                    editText.Text += " ";

                
            }
            else if (btn.Name == "o17")
            {
                if(textBox != null)
                    textBox.Text = "";

                if (editText != null)
                    editText.Text = "";
            }
            else if (btn.Name == "o15")
            {
                bool kontrol = (string)btn.Content == "Büyük Harf";
                btn.Content = kontrol ? "Küçük Harf" : "Büyük Harf";
                o1.Content = kontrol ? "€" : "!";
                o2.Content = kontrol ? "£" : "'";
                o3.Content = kontrol ? "#" : "^";
                o4.Content = kontrol ? "$" : "+";
                o5.Content = kontrol ? "½" : "%";
                o6.Content = kontrol ? "~" : "&";
                o7.Content = kontrol ? "{" : "/";
                o8.Content = kontrol ? "[" : "(";
                o9.Content = kontrol ? "]" : ")";
                o10.Content = kontrol ? "}" : "=";
                o11.Content = kontrol ? "\\" : "?";
                o12.Content = kontrol ? "_" : "-";
                b36.Content = kontrol ? ";" : ",";
                b24.Content = kontrol ? ":" : ".";
                b35.Content = kontrol ? ">" : "<";

                foreach (Button buton in Grid.Children.Cast<Button>().Where(x => x.Name.StartsWith("b")))
                {                    
                    buton.Content = kontrol ? ((string)buton.Content).ToUpper() : ((string)buton.Content).ToLower();
                }
            }
            else if (btn.Name == "o14")
            {
                if (!klavyeEnterEngel)
                {

                    if (textBox != null)
                        textBox.Text += Environment.NewLine;

                    if(editText != null)
                        editText.Text += Environment.NewLine;
                    textBox.CaretIndex = textBox.Text.Length;
                }
                else
                {
                    if (textBox != null)
                        textBox.Text += "[ENTER]";

                    if (editText != null)
                        editText.Text += "[ENTER]";
                }
                
            }
            else if (btn.Name == "o13")
            {
                if (textBox != null)
                    if (textBox.Text.Length > 0)
                        textBox.Text = textBox.Text.Substring(0, textBox.Text.Length - 1);

                if (editText != null)
                    if (editText.Text.Length > 0)
                        editText.Text = editText.Text.Substring(0, editText.Text.Length - 1);

                
            }
            else
            {

                if (textBox != null)
                {
                    textBox.Text += btn.Content;
                    textBox.CaretIndex = textBox.Text.Length;
                }
                if (editText != null)
                {
                    editText.Text += btn.Content;
                    editText.CaretIndex = editText.Text.Length;
                }
            }
            
        }
        

        
    }
    
}
