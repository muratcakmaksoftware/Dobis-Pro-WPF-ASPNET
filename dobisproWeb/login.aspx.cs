using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class login : System.Web.UI.Page
{
    SqlConnection bag;
    SqlCommand cmd;
    fonk fnk = new fonk();
    protected void Page_Load(object sender, EventArgs e)
    {
        bag = fnk.bag();
    }

    protected void btngirisyap_Click(object sender, EventArgs e)
    {
        bool dogrulama = false;
        cmd = new SqlCommand();
        cmd.Connection = bag;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "kullaniciKontrol";
        cmd.Parameters.Add("@kadi", SqlDbType.VarChar).Value = txtKullaniciAdi.Text;
        cmd.Parameters.Add("@sifre", SqlDbType.VarChar).Value = txtsifre.Text;
        bag.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                Session["isimdobis"] = dr["isim"].ToString();
                Session["kadidobis"] = dr["kadi"].ToString();
                Session["sifredobis"] = dr["sifre"].ToString();
                dogrulama = true;
                break;
            }
        }
        else
            fnk.alert("Kullanıcı Adı Veya Şifre Yanlış", this.Page);
        bag.Close();

        if(dogrulama)
            Response.Redirect("Default.aspx");


    }
}