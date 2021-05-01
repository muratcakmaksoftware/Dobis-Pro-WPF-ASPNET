using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page
{
    fonk fnk = new fonk();        
    SqlConnection bag;
    SqlCommand cmd;
    protected void Page_Load(object sender, EventArgs e)
    {
        bag = fnk.bag();
        if (!IsPostBack)
        {            
            cmd = new SqlCommand();
            cmd.Connection = bag;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "genelgetir";
            bag.Open();
            SqlDataReader dr = cmd.ExecuteReader();            
            while (dr.Read())
            {
                txtOkulAdi.Text = dr["okulAdi"].ToString();
                txtSlaytBekleme.Text = dr["slaytSuresi"].ToString();
                txtzamanAsimi.Text = dr["beklemeSuresi"].ToString();
                txtSayfaBasiYaziciMiktar.Text = dr["sayfaBasiFiyat"].ToString();
            }
            dr.Close();
            bag.Close();
        }
    }

    protected void btnguncelle_Click(object sender, EventArgs e)
    {
        cmd = new SqlCommand();
        cmd.Connection = bag;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "genelguncelle";
        cmd.Parameters.Add("@okulAdi", SqlDbType.VarChar).Value = txtOkulAdi.Text;
        cmd.Parameters.Add("@slaytSuresi", SqlDbType.Int).Value = Convert.ToInt32(txtSlaytBekleme.Text);
        cmd.Parameters.Add("@beklemeSuresi", SqlDbType.Int).Value = Convert.ToInt32(txtzamanAsimi.Text);
        cmd.Parameters.Add("@sayfaBasiFiyat", SqlDbType.Decimal).Value = Convert.ToDecimal(txtSayfaBasiYaziciMiktar.Text);
        bag.Open();
        cmd.ExecuteNonQuery();
        bag.Close();
    }
}