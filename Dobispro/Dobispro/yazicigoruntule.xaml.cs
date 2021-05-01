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
using System.Windows.Xps.Packaging;
using Microsoft.Office.Interop.Word;
using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.IO.Packaging;
using System.Diagnostics;
using Word = Microsoft.Office.Interop.Word;
using System.Windows.Xps;
using System.Printing;
using System.Drawing.Printing;
using System.IO;
using System.Data;
using System.Data.SqlClient;

namespace Dobispro
{
    /// <summary>
    /// Interaction logic for yazicigoruntule.xaml
    /// </summary>
    public partial class yazicigoruntule : UserControl
    {
        SqlConnection bag;
        SqlCommand cmd;
        public yazicigoruntule()
        {
            InitializeComponent();
            bag = App.fnk.bag();
        }
        XpsDocument xpsDocument;

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            lbladi.Content = "Dosya Adı: " + App.ogrencibilgileri.yaziciSecilenAd;
            lbltip.Content = "Dosya Türü: " + App.ogrencibilgileri.yaziciSecilenTip;
            
            string xpKayitYolu;
            XpsDocument cevirmisXps;            
            string anaYol = System.Environment.CurrentDirectory;
            string dosyayoluTam = App.ogrencibilgileri.yaziciSecilenTamAd;
            string dosyaYoluAdi = App.ogrencibilgileri.yaziciSecilenAd;
            string uzanti = App.ogrencibilgileri.yaziciSecilenTip;

            try
            {
                if (File.Exists(App.ogrencibilgileri.yaziciSecilenTamAd))
                {
                    switch (uzanti)
                    {
                        case "XLS":

                            xpKayitYolu = anaYol + "\\cop\\" + dosyaYoluAdi + "Converted.xps";
                            cevirmisXps = ConvertAllToXps(dosyayoluTam, xpKayitYolu, "excel");
                            docViewer.Document = cevirmisXps.GetFixedDocumentSequence();
                            docViewer.Visibility = Visibility.Visible;
                            pdfGoruntule.Visibility = Visibility.Hidden;
                            tilex.Visibility = Visibility.Visible;
                            xpsDocument.Close();
                            lblSayfaSayi.Content = "Sayfa Sayısı : " + docViewer.PageCount.ToString();
                            break;
                        case "XLSX":
                            xpKayitYolu = anaYol + "\\cop\\" + dosyaYoluAdi + "Converted.xps";
                            cevirmisXps = ConvertAllToXps(dosyayoluTam, xpKayitYolu, "excel");
                            docViewer.Document = cevirmisXps.GetFixedDocumentSequence();
                            docViewer.Visibility = Visibility.Visible;
                            pdfGoruntule.Visibility = Visibility.Hidden;
                            tilex.Visibility = Visibility.Visible;
                            xpsDocument.Close();
                            lblSayfaSayi.Content = "Sayfa Sayısı : " + docViewer.PageCount.ToString();
                            break;
                        case "DOC":
                            xpKayitYolu = anaYol + "\\cop\\" + dosyaYoluAdi + "Converted.xps";
                            xpsDocument = ConvertAllToXps(dosyayoluTam, xpKayitYolu, "word");
                            if (xpsDocument == null)
                            {
                                return;
                            }
                            docViewer.Document = xpsDocument.GetFixedDocumentSequence();
                            docViewer.Visibility = Visibility.Visible;
                            pdfGoruntule.Visibility = Visibility.Hidden;
                            tilex.Visibility = Visibility.Visible;
                            xpsDocument.Close();
                            lblSayfaSayi.Content = "Sayfa Sayısı : " + docViewer.PageCount.ToString();
                            break;
                        case "DOCX":
                            xpKayitYolu = anaYol + "\\cop\\" + dosyaYoluAdi + "Converted.xps";
                            xpsDocument = ConvertAllToXps(dosyayoluTam, xpKayitYolu, "word");
                            if (xpsDocument == null)
                            {
                                return;
                            }
                            docViewer.Document = xpsDocument.GetFixedDocumentSequence();
                            docViewer.Visibility = Visibility.Visible;
                            pdfGoruntule.Visibility = Visibility.Hidden;
                            tilex.Visibility = Visibility.Visible;
                            xpsDocument.Close();
                            lblSayfaSayi.Content = "Sayfa Sayısı : " + docViewer.PageCount.ToString();
                            break;
                        case "PDF":

                            docViewer.Visibility = Visibility.Hidden;
                            pdfGoruntule.Visibility = Visibility.Visible;

                            pdfGoruntule.DocumentSource = dosyayoluTam;
                            tilex.Visibility = Visibility.Visible;
                            /*
                            xpKayitYolu = anaYol + "\\cop\\" + dosyaYoluAdi + "Converted.xps";
                            xpsDocument = ConvertAllToXps(global.yaziciSecilenTamAd, xpKayitYolu, "pdf");                            
                            docViewer.Document = xpsDocument.GetFixedDocumentSequence();*/

                            break;
                        default:
                            Bildirim.Show(bildirim1, "Hatalı Giriş", "Belirtilen Uzantıların Dışında.", "Uyari");
                            tilex.Visibility = Visibility.Hidden;
                            break;

                    }
                }
                else
                {
                    Bildirim.Show(bildirim1, "Dizin Hatası", "Belirtilen Yol Bulunamadı.", "Uyari");
                    tilex.Visibility = Visibility.Hidden;
                }
            }
            catch
            {
                Bildirim.Show(bildirim1, "Çevirme Hatası", "Çevirme Hatası Lütfen\nFarklı Dosya Deneyiniz.", "Uyari");
                tilex.Visibility = Visibility.Hidden;
            }
        }

        private void CommandBinding_CanExecutePrint(object sender, CanExecuteRoutedEventArgs e)
        {
            e.Handled = true;
        }

        
        public XpsDocument ConvertAllToXps(string cevrilCekDosya, string xpsKayitYolu, string ConvertTip)
        {
            switch (ConvertTip)
            {
                case "pdf":

                    /*
                    PdfDocument docx = new PdfDocument();
                    docx.LoadFromFile(cevrilCekDosya, FileFormat.PDF);
                    docx.SaveToFile(xpsKayitYolu, FileFormat.XPS);
                    docx.Close();
                    XpsDocument converToXps = new XpsDocument(xpsKayitYolu, FileAccess.Read);    */
                    return null;
                case "word":
                    // Create a WordApplication and host word document
                    Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
                    try
                    {
                        wordApp.Documents.Open(cevrilCekDosya);

                        // To Invisible the word document
                        wordApp.Application.Visible = false;

                        // Minimize the opened word document
                        wordApp.WindowState = WdWindowState.wdWindowStateMinimize;

                        Document doc = wordApp.ActiveDocument;

                        doc.SaveAs(xpsKayitYolu, WdSaveFormat.wdFormatXPS);

                        xpsDocument = new XpsDocument(xpsKayitYolu, FileAccess.Read);
                        return xpsDocument;
                    }
                    catch //(Exception ex)
                    {
                        ///MessageBox.Show("Error occurs, The error message is  " + ex.ToString());
                        return null;
                    }
                    finally
                    {
                        wordApp.Documents.Close();
                        ((Microsoft.Office.Interop.Word._Application)wordApp).Quit(WdSaveOptions.wdDoNotSaveChanges);
                    }
                case "excel":

                    var excelApp = new Microsoft.Office.Interop.Excel.Application();
                    excelApp.DisplayAlerts = false;
                    excelApp.Visible = false;
                    Microsoft.Office.Interop.Excel.Workbook excelWorkbook = excelApp.Workbooks.Open(cevrilCekDosya);
                    // add below
                    //ExportXPS(excelWorkbook, xpsKayitYolu); // XPS Exporter is explained at next description
                    excelWorkbook.ExportAsFixedFormat(XlFixedFormatType.xlTypeXPS, Filename: xpsKayitYolu, OpenAfterPublish: false);
                    excelWorkbook.Close(false, null, null);
                    excelApp.Quit();
                    // release com object
                    Marshal.ReleaseComObject(excelApp);
                    excelApp = null;

                    xpsDocument = new XpsDocument(xpsKayitYolu, FileAccess.Read, CompressionOption.NotCompressed);
                    return xpsDocument;
                default:
                    Bildirim.Show(bildirim1, "Çevrilme Uzantı", "Uzantı Bulunamadı", "Uyari");
                    break;
            }

            return null;
        }

        public int Print()
        {
            App.fnk.zamanSifirla();
            try
            {
                PrintDialog dialog = new PrintDialog();

                dialog.PrintQueue = LocalPrintServer.GetDefaultPrintQueue();
                dialog.PrintTicket = dialog.PrintQueue.DefaultPrintTicket;
                dialog.SelectedPagesEnabled = false;
                dialog.UserPageRangeEnabled = true;
                dialog.MaxPage = Convert.ToUInt32(docViewer.PageCount.ToString());
                dialog.PrintTicket.PageOrientation = PageOrientation.Landscape; // dikey ayarlama varsayılan

                dialog.PrintTicket.PageOrientation = System.Printing.PageOrientation.Landscape;
                if (dialog.ShowDialog() == true)
                {
                    //lbladi.Content = dialog.PrintTicket.CopyCount.ToString(); // kopyalama sayısı
                    //lbladi.Content = dialog.PageRange.ToString(); // Sayfa Sayısı
                    /*XpsDocumentWriter writer = PrintQueue.CreateXpsDocumentWriter(dialog.PrintQueue);
                    writer.Write(doc as FixedDocument, dialog.PrintTicket);*/

                    if (dialog.PageRangeSelection.ToString() == "AllPages") // Tüm sayfalar seçildiği için max page sayısıdır.
                    {
                        //lbladi.Content = "Çıkacak Sayfa Sayısı : " + dialog.MaxPage.ToString();
                        decimal fiyat = (dialog.MaxPage * App.yaziciSayfaBasiFiyat) * Convert.ToInt32(dialog.PrintTicket.CopyCount);
                        if (fiyat > App.ogrencibilgileri.ogrenciPara)
                        {
                            Bildirim.Show(bildirim1, "Yazıcı", "Bakiye Yetersiz.\n" + fiyat.ToString() + " Miktar Olmalı.", "Uyari");
                            return -1;
                        }
                        else
                        {
                            try
                            {
                                var doc = ((IDocumentPaginatorSource)docViewer.Document).DocumentPaginator;
                                dialog.PrintDocument(doc, "Yazdır");
                                ogrenciOdemeAlinmasi(fiyat);
                                return 1;
                            }
                            catch
                            {
                                Bildirim.Show(bildirim1, "Yazıcı", "Yazıcı Bağlı Değil.", "Uyari");
                                return -1;
                            }
                        }
                    }
                    else if (dialog.PageRangeSelection.ToString() == "UserPages")
                    {
                        //lbladi.Content = "Çıkacak Sayfa Sayısı : " + dialog.PageRange.ToString();
                        //double fiyat = (Convert.ToInt32(dialog.PageRange.ToString()) * global.yaziciMiktar) * Convert.ToInt32(dialog.PrintTicket.CopyCount);
                        decimal fiyat = 0;
                        int bas = 1;
                        int bit = 1;
                        if (App.fnk.IsNumeric(dialog.PageRange.ToString()))
                        {
                            fiyat = (Convert.ToInt32(dialog.PageRange.ToString()) * App.yaziciSayfaBasiFiyat) * Convert.ToInt32(dialog.PrintTicket.CopyCount);
                            bas = Convert.ToInt32(dialog.PageRange.ToString());
                            bit = Convert.ToInt32(dialog.PageRange.ToString());
                        }
                        else
                        {
                            string digPageRange = dialog.PageRange.ToString();
                            bas = Convert.ToInt32(digPageRange.Substring(0, Convert.ToInt32(digPageRange.IndexOf("-"))));
                            bit = Convert.ToInt32(digPageRange.Substring(Convert.ToInt32(digPageRange.ToString().IndexOf("-") + 1), digPageRange.Length - Convert.ToInt32(digPageRange.ToString().IndexOf("-") + 1)));
                            fiyat = ((bit - bas) * App.yaziciSayfaBasiFiyat) * Convert.ToInt32(dialog.PrintTicket.CopyCount);
                        }

                        if (fiyat > App.ogrencibilgileri.ogrenciPara)
                        {
                            Bildirim.Show(bildirim1, "Yazıcı", "Bakiye Yetersiz.\n" + fiyat.ToString() + " Miktar Olmalı.", "Uyari");
                            return -1;
                        }
                        else
                        {
                            try
                            {
                                var doc = ((IDocumentPaginatorSource)docViewer.Document).DocumentPaginator;
                                dialog.PrintDocument(doc, "Yazdır");
                                ogrenciOdemeAlinmasi(fiyat);
                                return 1;
                            }
                            catch
                            {
                                Bildirim.Show(bildirim1, "Yazıcı", "Yazıcı Bağlı Değil.", "Uyari");
                                return -1;
                            }

                        }
                    }
                    else
                        return 4;

                }
                else
                {
                    return 0;
                }
            }
            catch
            {
                return 3;
            }
        }


        int pdfPrint()
        {
            App.fnk.zamanSifirla();
            try
            {
                PrintDialog dialog = new PrintDialog();

                dialog.PrintQueue = LocalPrintServer.GetDefaultPrintQueue();
                dialog.PrintTicket = dialog.PrintQueue.DefaultPrintTicket;
                dialog.SelectedPagesEnabled = false;
                dialog.UserPageRangeEnabled = true;
                dialog.MaxPage = Convert.ToUInt32(pdfGoruntule.PageCount.ToString());
                dialog.PrintTicket.PageOrientation = PageOrientation.Landscape; // dikey ayarlama

                dialog.PrintTicket.PageOrientation = System.Printing.PageOrientation.Landscape;
                if (dialog.ShowDialog() == true)
                {

                    if (dialog.PageRangeSelection.ToString() == "AllPages") // Tüm sayfalar seçildiği için max page sayısıdır.
                    {
                        decimal fiyat = (dialog.MaxPage * App.yaziciSayfaBasiFiyat) * Convert.ToInt32(dialog.PrintTicket.CopyCount);
                        if (fiyat > App.ogrencibilgileri.ogrenciPara)
                        {
                            Bildirim.Show(bildirim1, "Yazıcı", "Bakiye Yetersiz.\n" + fiyat.ToString() + " Miktar Olmalı.", "Uyari");
                            return -1;
                        }
                        else
                        {

                            try
                            {

                                PrinterSettings prnSettings = new PrinterSettings();
                                prnSettings.PrintRange = PrintRange.AllPages;
                                prnSettings.FromPage = 1;
                                prnSettings.ToPage = Convert.ToInt32(dialog.MaxPage);
                                prnSettings.PrinterName = dialog.PrintQueue.Name;
                                prnSettings.Copies = (short)dialog.PrintTicket.CopyCount;
                                if (dialog.PrintTicket.PageOrientation.Value.ToString() != "Landscape")
                                    prnSettings.DefaultPageSettings.Landscape = false;
                                else
                                    prnSettings.DefaultPageSettings.Landscape = true;

                                pdfGoruntule.Print(prnSettings);
                                ogrenciOdemeAlinmasi(fiyat);
                                return 1;
                            }
                            catch
                            {
                                Bildirim.Show(bildirim1, "Yazıcı", "Yazıcı Bağlı Değil.", "Uyari");                            
                                return -1;
                            }
                        }
                    }
                    else if (dialog.PageRangeSelection.ToString() == "UserPages")
                    {
                        decimal fiyat = 0;
                        int bas = 1;
                        int bit = 1;
                        if (App.fnk.IsNumeric(dialog.PageRange.ToString()))
                        {
                            fiyat = (Convert.ToInt32(dialog.PageRange.ToString()) * App.yaziciSayfaBasiFiyat) * Convert.ToInt32(dialog.PrintTicket.CopyCount);
                            bas = Convert.ToInt32(dialog.PageRange.ToString());
                            bit = Convert.ToInt32(dialog.PageRange.ToString());
                        }
                        else
                        {
                            string digPageRange = dialog.PageRange.ToString();
                            bas = Convert.ToInt32(digPageRange.Substring(0, Convert.ToInt32(digPageRange.IndexOf("-"))));
                            bit = Convert.ToInt32(digPageRange.Substring(Convert.ToInt32(digPageRange.ToString().IndexOf("-") + 1), digPageRange.Length - Convert.ToInt32(digPageRange.ToString().IndexOf("-") + 1)));
                            fiyat = ((bit - bas) * App.yaziciSayfaBasiFiyat) * Convert.ToInt32(dialog.PrintTicket.CopyCount);
                        }


                        if (fiyat > App.ogrencibilgileri.ogrenciPara)
                        {
                            Bildirim.Show(bildirim1, "Yazıcı", "Bakiye Yetersiz.\n" + fiyat.ToString() + " Miktar Olmalı.", "Uyari");
                            return -1;
                        }
                        else
                        {
                            
                            try
                            {
                                PrinterSettings prnSettings = new PrinterSettings();
                                prnSettings.PrintRange = PrintRange.SomePages;
                                prnSettings.FromPage = bas;
                                prnSettings.ToPage = bit;
                                prnSettings.PrinterName = dialog.PrintQueue.Name;
                                prnSettings.Copies = (short)dialog.PrintTicket.CopyCount;
                                if (dialog.PrintTicket.PageOrientation.Value.ToString() != "Landscape")
                                    prnSettings.DefaultPageSettings.Landscape = false;
                                else
                                    prnSettings.DefaultPageSettings.Landscape = true;

                                pdfGoruntule.Print(prnSettings, true);
                                ogrenciOdemeAlinmasi(fiyat);
                                return 1;
                            }
                            catch
                            {
                                Bildirim.Show(bildirim1, "Yazıcı", "Yazıcı Bağlı Değil.", "Uyari");
                                return -1;
                            }
                           
                        }
                    }
                    else
                        return 4;

                }
                else
                {
                    return 0;
                }
            }
            catch
            {
                return 3;
            }
        }

        private void Tile_Click(object sender, EventArgs e)
        {
            App.fnk.zamanSifirla();
            try
            {
                if (App.ogrencibilgileri.yaziciSecilenTip != "")
                {
                    if (File.Exists(App.ogrencibilgileri.yaziciSecilenTamAd))
                    {
                        string uzanti = App.ogrencibilgileri.yaziciSecilenTip;
                        if (uzanti == "XLS" || uzanti == "XLSX" || uzanti == "DOC" || uzanti == "DOCX")
                        {
                            int durum = Print();
                            if (durum == 1)
                            {

                                Bildirim.Show(bildirim1, "Yazıcı", "Başarıyla Yazdırılıyor...", "Bilgi");
                            }
                            else if (durum == 0)
                                Bildirim.Show(bildirim1, "Yazıcı", "Yazdırılma İşlemi İptal Edildi.", "Bilgi");
                            else if (durum == 3)
                                Bildirim.Show(bildirim1, "Yazıcı", "Yazdırılırken Bir Hata Oluştu", "Hata");
                            else if (durum == 4)
                                Bildirim.Show(bildirim1, "Yazıcı", "Seçim Hatası.\nİşlem İptal", "Hata");
                            else if (durum == 5)
                                Bildirim.Show(bildirim1, "Yazıcı", "Miktar Güncelleştirme\nHatası", "Hata");

                        }
                        else if (uzanti == "PDF")
                        {
                            int durum = pdfPrint();
                            if (durum == 1)
                            {
                                Bildirim.Show(bildirim1, "Yazıcı", "Başarıyla Yazdırılıyor...", "Bilgi");
                            }
                            else if (durum == 0)
                                Bildirim.Show(bildirim1, "Yazıcı", "Yazdırılma İşlemi İptal Edildi.", "Bilgi");
                            else if (durum == 3)
                                Bildirim.Show(bildirim1, "Yazıcı", "Yazdırılırken Bir Hata Oluştu", "Hata");
                            else if (durum == 4)
                                Bildirim.Show(bildirim1, "Yazıcı", "Seçim Hatası.\nİşlem İptal", "Hata");
                            else if (durum == 5)
                                Bildirim.Show(bildirim1, "Yazıcı", "Miktar Güncelleştirme\nHatası", "Hata");
                        }
                        else
                            Bildirim.Show(bildirim1, "Hatalı Giriş", "Belirtilen Uzantıların Dışında.", "Uyari");
                    }
                    else
                        Bildirim.Show(bildirim1, "Dizin Hatası", "Belirtilen Yol Bulunamadı.", "Uyari");
                }
                else
                    Bildirim.Show(bildirim1, "Hatalı Giriş", "Belirtilen Hiç Uzantı\nYok.", "Uyari");
            }
            catch
            {
                Bildirim.Show(bildirim1, "Yazdırma Hatası", "Yazdırılırken Bir Sorun\nOluştu", "Uyari");
            }
        }

        private void docViewer_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            App.fnk.zamanSifirla();
        }

        private void docViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            App.fnk.zamanSifirla();
        }

        private void pdfGoruntule_DocumentLoaded(object sender, RoutedEventArgs e)
        {
            lblSayfaSayi.Content = "Sayfa Sayısı : " + pdfGoruntule.PageCount.ToString();
        }

        private void geri_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            App.fnk.zamanSifirla();
            App.mw.Content = new yazici();
        }


        void ogrenciOdemeAlinmasi(decimal fiyat)
        {

            try
            {
                decimal yeniBakiye = App.ogrencibilgileri.ogrenciPara - fiyat;
                App.ogrencibilgileri.ogrenciPara = yeniBakiye;
                cmd = new SqlCommand();
                cmd.Connection = bag;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ogrenciYazici";
                cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = App.ogrencibilgileri.ogrenciId;
                cmd.Parameters.Add("@yeniBakiye", SqlDbType.Decimal).Value = yeniBakiye;
                bag.Open();
                cmd.ExecuteNonQuery();
                bag.Close();                
            }
            catch
            {
                Bildirim.Show(bildirim1, "Güncelleme Hata", "Öğrenci Güncelleme\nHatası", "Uyari");
            }


        }
    }
}
