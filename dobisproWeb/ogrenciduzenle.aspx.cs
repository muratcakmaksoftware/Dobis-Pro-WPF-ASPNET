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
    string ogsinif = "";
    string rsmBase64 = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        bag = fnk.bag();
        if (Request.QueryString["id"] != null)
        {
            id = Request.QueryString["id"];            
        }
        else
            Response.Redirect("ogrenciler.aspx");


        if (fnk.IsNumeric(id))
        {

            bag.Open();
            cmd = new SqlCommand();
            cmd.Connection = bag;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ogrenciyigetir";
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = Convert.ToInt32(id);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (!IsPostBack)
                {
                    txtOgrenciAdi.Text = dr["isim"].ToString();
                    txtTcNo.Text = dr["tcno"].ToString();
                    txtSifre.Text = dr["sifre"].ToString();
                    txtOkulNo.Text = dr["okulNo"].ToString();
                    txtBakiye.Text = dr["miktar"].ToString();
                    ogsinif = dr["ogSinif"].ToString();
                    

                }
                rsmBase64 = dr["ogResim"].ToString();
                ltresim.Text = "<img src='data:image/png;base64," + dr["ogResim"] + "' width='150' height='150'/>";
            }
            dr.Close();
            bag.Close();

            

        }
        else
            Response.Redirect("ogrenciler.aspx");

        if(!IsPostBack)
        {
            siniflariGetir();
        }
        
    }
    string secilenSinif = "";
    protected void btnguncelle_Click(object sender, EventArgs e)
    {
        if (txtOgrenciAdi.Text != "" && txtOkulNo.Text != "" && txtTcNo.Text != "" && txtSifre.Text != "")
        {
            if (drpSinif.Text == "" && txtSinif.Text == "")
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

            if(fileResim.FileName != "")
                rsmBase64 = Convert.ToBase64String(fnk.getImageByteStream(fileResim.PostedFile.InputStream));

            if (txtBakiye.Text == "")
                txtBakiye.Text = "0";

            cmd = new SqlCommand();
            cmd.Connection = bag;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ogrenciguncelle";
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = Convert.ToInt32(id);
            cmd.Parameters.Add("@ogrenciAdi", SqlDbType.VarChar).Value = txtOgrenciAdi.Text;
            cmd.Parameters.Add("@tcno", SqlDbType.VarChar).Value = txtTcNo.Text;
            cmd.Parameters.Add("@sifre", SqlDbType.VarChar).Value = txtSifre.Text;            
            cmd.Parameters.Add("@okulNo", SqlDbType.VarChar).Value = txtOkulNo.Text;
            cmd.Parameters.Add("@sinif", SqlDbType.VarChar).Value = secilenSinif;
            cmd.Parameters.Add("@miktar", SqlDbType.Decimal).Value = Convert.ToDecimal(txtBakiye.Text);
            cmd.Parameters.Add("@resimData", SqlDbType.VarChar).Value = rsmBase64;
            bag.Open();
            cmd.ExecuteNonQuery();
            bag.Close();
            Response.Redirect(Page.Request.Url.ToString(), true);
            

        }
        else
            fnk.alert("Gerekli Yerleri Doldurun.", this.Page);
    }


    void siniflariGetir()
    {
        drpSinif.Items.Clear();
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

        for (int i = 0; i < drpSinif.Items.Count; i++)
        {
            if (drpSinif.Items[i].Text.ToString() == ogsinif)
            {
                drpSinif.SelectedIndex = i;
                break;
            }
        }
    }

    protected void btnsil_Click(object sender, EventArgs e)
    {
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
}