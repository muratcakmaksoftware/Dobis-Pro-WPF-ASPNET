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
using System.Windows.Shapes;



namespace Dobispro
{   
    /// <summary>
    /// Interaction logic for SayisalEkran.xaml
    /// </summary>
    public partial class SayisalEkran : Window
    {
        public TextBox textBox { get; set; }
        public DevExpress.Xpf.Editors.TextEdit editText { get; set; }
        public DevExpress.Xpf.Editors.PasswordBoxEdit passText { get; set; }
        public SayisalEkran()
        {
            InitializeComponent();
            
            foreach (Button b in Grid.Children)
            {
                b.Click += Tus_Click;
            }
            
        }
        

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);

            e.Cancel = true;
            Hide();
        }

        public void klavyeSecimKaldir()
        {
            textBox = null;
            editText = null;
            passText = null;
        }
        
        public void sayisalEkranKonumla(Point textpoint)
        {
            this.Top = textpoint.Y + 50;
        }

        public void sayisalTouchEkranKonumla(TouchPoint touchpoint)
        {
            this.Top = touchpoint.Position.Y + 50;
        }

        private void Tus_Click(object sender, RoutedEventArgs e)
        {
            App.fnk.zamanSifirla();
            if (textBox != null)
            {
                textBox.Focus();

                Button btn = (Button)sender;
                if (btn.Name == "o1")
                {
                    if (textBox.Text.Length > 0)
                    {
                        textBox.Text = textBox.Text.Substring(0, textBox.Text.Length - 1);
                    }
                    else { }
                }
                else if (btn.Name == "ok")
                {
                    textBox.Text += "[OK]";
                }
                else
                {
                    textBox.Text += btn.Content;
                    textBox.CaretIndex = textBox.Text.Length;
                }
                
            }

            if(editText != null)
            {
                editText.Focus();

                Button btn = (Button)sender;
                if (btn.Name == "o1")
                {
                    if (editText.Text.Length > 0)
                    {
                        editText.Text = editText.Text.Substring(0, editText.Text.Length - 1);
                    }
                    else { }
                }
                else if (btn.Name == "ok")
                {
                    editText.Text += "[OK]";
                }
                else {
                    editText.Text += btn.Content;
                    editText.CaretIndex = editText.Text.Length;
                }
                
            }

            if(passText != null)
            {
                passText.Focus();

                Button btn = (Button)sender;
                if (btn.Name == "o1")
                {
                    if (passText.Text.Length > 0)
                    {
                        passText.Text = passText.Text.Substring(0, passText.Text.Length - 1);
                    }
                    else { }
                }
                else if (btn.Name == "ok")
                {
                    passText.Text += "[OK]";
                }
                else { passText.Text += btn.Content; }
                //passText. = editText.Text.Length;
                
            }
        }
    }
}
