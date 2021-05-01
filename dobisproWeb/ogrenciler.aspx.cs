using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class ogrenciler : System.Web.UI.Page
{
    SqlConnection bag;
    SqlCommand cmd;
    fonk fnk = new fonk();
    string id = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        bag = fnk.bag();
        if (Request.QueryString["id"] != null)
        {
            id = Request.QueryString["id"];            
            cmd = new SqlCommand();
            cmd.Connection = bag;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ogrencisil";
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = Convert.ToInt32(id);
            bag.Open();
            cmd.ExecuteNonQuery();
            bag.Close();
            Response.Redirect("ogrenciler.aspx");
        }
       
        if(!IsPostBack)
        {
            ogrencilerigetir();
        }

        

    }
    string secilenSinif = "";
    protected void btnogrenciekle_Click(object sender, EventArgs e)
    {
        if (txtOgrenciAdi.Text != "" && txtOkulNo.Text != "" && txtTcNo.Text != "" && fileResim.FileName != "")
        {
            if(drpSinif.Text == "" && txtSinif.Text == "")
            {
                fnk.alert("Sınıfı Boş Geçemezsiniz.", this.Page);
                return;
            }

            if (drpSinif.Text != "" && txtSinif.Text != "")
            {
                fnk.alert("Lütfen bir tane sınıf seçin.", this.Page);
                return;
            }

            if (drpSinif.Text != "")
                secilenSinif = drpSinif.Text;
            if (txtSinif.Text != "")
                secilenSinif = txtSinif.Text;

            if (txtBakiye.Text == "")
                txtBakiye.Text = "0";

            string rsmBase64 = Convert.ToBase64String(fnk.getImageByteStream(fileResim.PostedFile.InputStream));
            cmd = new SqlCommand();
            cmd.Connection = bag;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ogrenciekle";
            cmd.Parameters.Add("@ogrenciAdi", SqlDbType.VarChar).Value = txtOgrenciAdi.Text;
            cmd.Parameters.Add("@tcno", SqlDbType.VarChar).Value = txtTcNo.Text;
            cmd.Parameters.Add("@sifre", SqlDbType.VarChar).Value = txtTcNo.Text.Substring(txtTcNo.Text.Length - 4, 4);            
            cmd.Parameters.Add("@okulNo", SqlDbType.VarChar).Value = txtOkulNo.Text;
            cmd.Parameters.Add("@sinif", SqlDbType.VarChar).Value = secilenSinif;
            cmd.Parameters.Add("@miktar", SqlDbType.Decimal).Value = Convert.ToDecimal(txtBakiye.Text);
            cmd.Parameters.Add("@resimData", SqlDbType.VarChar).Value = rsmBase64;
            bag.Open();
            cmd.ExecuteNonQuery();
            bag.Close();
            //fnk.alert("Başarıyla Öğrenci Eklendi.", this.Page);
            Response.Redirect("ogrenciler.aspx");

        }
        else
            fnk.alert("Gerekli Yerleri Doldurun.", this.Page);
    }


    void ogrencilerigetir()
    {
        drpSinif.Items.Add("");
        bag.Open();
        cmd = new SqlCommand();
        cmd.Connection = bag;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "ogrencilerigetir";
        SqlDataReader dr = cmd.ExecuteReader();
        int sira = 1;
        while (dr.Read())
        {
            if (fnk.drpAra(drpSinif, dr["ogSinif"].ToString()))
            {
                drpSinif.Items.Add(dr["ogSinif"].ToString());
            }

            lticerik.Text += "<tr>" +
                "<td>" + sira + "</td>" +
                "<td>" + dr["isim"] + "</td>" +
                "<td>" + dr["tcno"] + "</td>" +
                "<td>" + dr["okulno"] + "</td>" +
                "<td>" + dr["ogSinif"] + "</td>" +
                "<td>" + dr["miktar"] + "</td>" +
                "<td><a href='ogrenciduzenle.aspx?id=" + dr["id"] + "'><img src='images/duzenle.png' width='30' height='30' /></a> '</td>" +
                "<td><a href='ogrenciler.aspx?id=" + dr["id"] + "' class='confirmation' ><img src='images/sil.png' width='35' height='35' /></a> '</td>" +
                "";
            sira++;
        }
        dr.Close();
        bag.Close();
    }



}