using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Media.Imaging;
using System.IO;

namespace Dobispro
{
    public class fonk
    {
        public fonk()
        {

        }

        public SqlConnection bag()
        {
            return new SqlConnection("Server=localhost;Database=dobispro;Trusted_Connection=True;");
        }

        public void zamanAsimi()
        {
            App.klavye.klavyeSecimKaldir();
            App.klavye.Hide();

            App.klavyeSayi.klavyeSecimKaldir();
            App.klavyeSayi.Hide();

            App.mw.Content = new anagorunum();
        }
        public void zamanSifirla()
        {
            App.tmrBeklemeSuresi.Stop();
            App.tmrBeklemeSuresi.Start();
        }

        public void zamanBaslat()
        {
            App.tmrBeklemeSuresi.Start();
        }

        public void zamanDurdur()
        {
            App.tmrBeklemeSuresi.Stop();
        }


        public bool tckontrol(ref string baslik, ref string hatamesaji, string tcNo)
        {
            int toplam = 0, toplam2 = 0, toplam3 = 0;
            try
            {
                if (tcNo.Length == 11)
                {
                    if (Convert.ToInt32(tcNo[0].ToString()) != 0) //tc kimlik numaranın ilk hanesi 0 değilse
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            toplam = toplam + Convert.ToInt32(tcNo[i].ToString());
                            if (i % 2 == 0)
                            {
                                if (i != 10)
                                {
                                    toplam2 = toplam2 + Convert.ToInt32(tcNo[i].ToString()); // 7 ile çarpılacak sayıları topluyoruz
                                }

                            }
                            else
                            {
                                if (i != 9)
                                {
                                    toplam3 = toplam3 + Convert.ToInt32(tcNo[i].ToString());
                                }
                            }
                        }
                    }
                    else
                    {
                        baslik = "Uyarı";
                        hatamesaji = "T.C Kimlik Doğrulaması\nYanlış Lütfen Doğru Giriniz.";
                        //Bildirim.Show(bildirim1, "Uyarı", "T.C Kimlik Doğrulaması\nYanlış Lütfen Doğru Giriniz.", "Uyari");
                        return false;
                    }
                }
                else
                {
                    //Bildirim.Show(bildirim1, "Uyarı", "T.C Kimlik 11 Haneli\nOlmalı", "Uyari");
                    baslik = "Uyarı";
                    hatamesaji = "T.C Kimlik 11 Haneli\nOlmalı";
                    return false;
                }
            }
            catch
            {
                //Bildirim.Show(bildirim1, "Uyarı", "T.C Kimlik Doğrulaması\nYanlış Lütfen Doğru Giriniz.", "Uyari");
                baslik = "Uyarı";
                hatamesaji = "T.C Kimlik Doğrulaması\nYanlış Lütfen Doğru Giriniz.";
                return false;
            }
            try
            {
                if (((toplam2 * 7) - toplam3) % 10 == Convert.ToInt32(tcNo[9].ToString()) && toplam % 10 == Convert.ToInt32(tcNo[10].ToString()))
                {
                    return true;
                }
                else
                {
                    //Bildirim.Show(bildirim1, "Uyarı", "T.C Kimlik Doğrulaması\nYanlış Lütfen Doğru Giriniz.", "Uyari");
                    baslik = "Uyarı";
                    hatamesaji = "T.C Kimlik Doğrulaması\nYanlış Lütfen Doğru Giriniz.";
                    return false;
                }
            }
            catch
            {
                //Bildirim.Show(bildirim1, "Uyarı", "T.C Kimlik Doğrulaması\nYanlış Lütfen Doğru Giriniz.", "Uyari");
                baslik = "Uyarı";
                hatamesaji = "T.C Kimlik Doğrulaması\nYanlış Lütfen Doğru Giriniz.";
                return false;
            }

            
        }


        public BitmapImage base64ResimeCevirme(string resimBase64)
        {
            byte[] binaryData = Convert.FromBase64String(resimBase64);
            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            bi.StreamSource = new MemoryStream(binaryData);
            bi.EndInit();

            return bi;
        }

        public bool IsNumeric(string text)
        {
            foreach (char chr in text)
            {
                if (!Char.IsNumber(chr)) return false;
            }
            return true;
        }

    }
}
