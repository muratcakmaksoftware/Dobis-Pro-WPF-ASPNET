using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dobispro
{
    public class ogrencibilgileri
    {
        public int ogrenciId { get; set; }
        public string ogrenciAdi { get; set; }
        public string ogrenciTc { get; set; }
        public string ogrenciSifre { get; set; }
        public string ogrenciOkulno { get; set; }
        public string ogrenciSinifi { get; set; }
        public string ogrenciResmi { get; set; }
        public decimal ogrenciPara { get; set; }

        public string yaziciSecilenTamAd { get; set; }
        public string yaziciSecilenAd { get; set; }
        public string yaziciSecilenTip { get; set; }


        public ogrencibilgileri()
        {

        }

        public void ogrenciBilgileriniTemizle()
        {
            ogrenciId = -1;
            ogrenciAdi = "";
            ogrenciTc = "";
            ogrenciSifre = "";
            ogrenciOkulno = "";
            ogrenciSinifi = "";
            ogrenciResmi = "";
            ogrenciPara = 0;
        }

    }
}
