using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;

public partial class dersprogramres : System.Web.UI.Page
{
    fonk fnk = new fonk();
    SqlConnection bag;
    SqlCommand cmd;

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
            cmd.CommandText = "dprsil";
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = Convert.ToInt32(id);
            bag.Open();
            cmd.ExecuteNonQuery();
            bag.Close();
            Response.Redirect("dersprogramres.aspx");
        }       
        

        if (!IsPostBack)
        {
            bag.Open();
            cmd = new SqlCommand();
            cmd.Connection = bag;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "dprgetir";
            SqlDataReader dr = cmd.ExecuteReader();
            int sira = 1;
            while (dr.Read())
            {
                lticerik.Text += "<tr>" +
                    "<td>" + sira + "</td>" +
                    "<td>" + dr["sinif"] + "</td>" +
                    "<td>" + dr["resimAdi"] + "</td>" +
                    "<td><img src='data:image/png;base64," + dr["resim"] + "' width='30' height='30' /></td>" +
                    "<td><a href='dersprogramresDuzenle.aspx?id=" + dr["id"] + "'><img src='images/duzenle.png' width='30' height='30' /></a> '</td>" +
                    "<td><a href='dersprogramres.aspx?id=" + dr["id"] + "' class='confirmation' ><img src='images/sil.png' width='35' height='35' /></a> '</td>" +
                    "";
                sira++;
            }
            dr.Close();
            bag.Close();

            siniflarigetir();
        }
    }
    
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (txtResimAdi.Text != "" && fileResim.FileName != "")
        {            
            string rsmBase64 = Convert.ToBase64String(fnk.getImageByteStream(fileResim.PostedFile.InputStream));
            cmd = new SqlCommand();
            cmd.Connection = bag;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "dprekle";
            cmd.Parameters.Add("@sinif", SqlDbType.VarChar).Value = drpSinif.Text;
            cmd.Parameters.Add("@resimAdi", SqlDbType.VarChar).Value = txtResimAdi.Text;
            cmd.Parameters.Add("@resim", SqlDbType.VarChar).Value = rsmBase64;
            bag.Open();
            cmd.ExecuteNonQuery();
            bag.Close();
            //fnk.alert("Başarıyla Eklendi.", this.Page);
            Response.Redirect("dersprogramres.aspx");

        }
        else
            fnk.alert("Bilgileri Boş Geçemezsiniz.", this.Page);
         


    }

    void siniflarigetir()
    {
        drpSinif.Items.Add("");
        bag.Open();
        cmd = new SqlCommand();
        cmd.Connection = bag;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "ogrencilerigetir";
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            if (fnk.drpAra(drpSinif, dr["ogSinif"].ToString()))
            {
                drpSinif.Items.Add(dr["ogSinif"].ToString());
            }
        }
        dr.Close();
        bag.Close();
    }


}