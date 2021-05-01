using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.UI;
using System.IO;
using System.Web.UI.WebControls;

public class fonk
{
    public fonk()
    {
       
    }
    public SqlConnection bag()
    {
        return new SqlConnection("Server=localhost;Database=dobispro;Trusted_Connection=True;");
    }

    public void alert(string msj, Page pg)
    {
        pg.RegisterStartupScript("PopupScript", 
            "<script>" +
                "alert('" + msj + "')" +
            "</script>"    
        );
    }

    public byte[] getImageByteStream(Stream input)
    {
        byte[] buffer = new byte[input.Length];
        using (MemoryStream ms = new MemoryStream())
        {
            int read;
            while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                ms.Write(buffer, 0, read);
            }
            return ms.ToArray();
        }
    }


    public bool IsNumeric(string text)
    {
        foreach (char chr in text)
        {
            if (!Char.IsNumber(chr)) return false;
        }
        return true;
    }

    public bool drpAra(DropDownList drp, string aranan)
    {
        bool drm = true;
        for (int i = 0; i < drp.Items.Count; i++)
        {
            if (aranan == drp.Items[i].ToString())
            {
                drm = false; // bulunduğu için aynı items var demektir.
                break;
            }
            else
            {
                drm = true; // yeni bir değer eklenecek.
            }
        }
        return drm;
    }
}