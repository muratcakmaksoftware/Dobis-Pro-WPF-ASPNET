using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class dersprogramresDuzenle : System.Web.UI.Page
{
    string id = "";
    fonk fnk = new fonk();
    SqlConnection bag;
    SqlCommand cmd;
    string resimData = "";
    string ogsinif = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        bag = fnk.bag();

        if (Request.QueryString["id"] != null)
        {
            id = Request.QueryString["id"];

        }
        else
            Response.Redirect("dersprogramres.aspx");

        
        if (fnk.IsNumeric(id))
        {
            bag.Open();
            cmd = new SqlCommand();
            cmd.Connection = bag;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "dprgetirid";
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = Convert.ToInt32(id);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (!IsPostBack)
                {
                    ogsinif = dr["sinif"].ToString();
                    txtResimAdi.Text = dr["resimAdi"].ToString();                    
                }
                resimData = dr["resim"].ToString();
                ltresim.Text = "<br/><label>Şuanki Resim</label><br/><img src='data:image/png;base64," + dr["resim"] + "' width='200' height='200'/>";
            }
            dr.Close();
            bag.Close();
        }
        else
            Response.Redirect("dersprogramres.aspx");

        if (!IsPostBack)
        {
            siniflariGetir();
        }
    }

    protected void btnguncelle_Click(object sender, EventArgs e)
    {
        if (txtResimAdi.Text != "")
        {
            if (fileResim.FileName != "")
            {
                resimData = Convert.ToBase64String(fnk.getImageByteStream(fileResim.PostedFile.InputStream));
            }
            
            cmd = new SqlCommand();
            cmd.Connection = bag;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "dprguncelle";
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = Convert.ToInt32(id);
            cmd.Parameters.Add("@sinif", SqlDbType.VarChar).Value = drpSinif.Text;
            cmd.Parameters.Add("@resimAdi", SqlDbType.VarChar).Value = txtResimAdi.Text;
            cmd.Parameters.Add("@resim", SqlDbType.VarChar).Value = resimData;
            bag.Open();
            cmd.ExecuteNonQuery();
            bag.Close();
            fnk.alert("Başarıyla Güncellendi.", this.Page);

            ltresim.Text = "<br/><label>Şuanki Resim</label><br/><img src='data:image/png;base64," + resimData + "' width='200' height='200'/>";
        }
        else
            fnk.alert("Bilgileri Boş Geçemezsiniz.", this.Page);
    }

    protected void btn_Click(object sender, EventArgs e)
    {
        try
        {
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
        catch { }
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
}