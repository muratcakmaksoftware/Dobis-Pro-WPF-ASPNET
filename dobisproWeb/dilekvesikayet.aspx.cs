using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class dilekvesikayet : System.Web.UI.Page
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

            if (fnk.IsNumeric(id))
            {
                bag.Open();
                cmd = new SqlCommand();
                cmd.Connection = bag;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "dvssil";
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = Convert.ToInt32(id);
                cmd.ExecuteNonQuery();
                bag.Close();
            }
        }

        if (!IsPostBack)
        {
            dilekcileriGetir();
        }

    }

    void dilekcileriGetir()
    {        
        bag.Open();
        cmd = new SqlCommand();
        cmd.Connection = bag;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "dvsgetir";
        SqlDataReader dr = cmd.ExecuteReader();
        int sira = 1;
        while (dr.Read())
        {

            lticerik.Text += "<tr>" +
                "<td>" + sira + "</td>" +
                "<td>" + dr["konu"] + "</td>" +
                "<td>" + dr["mesaj"] + "</td>" +
                "<td>" + ((bool)dr["okunma"] == true ? "<span style='color:green'>Okundu</span>" : "<span style='color:red'>Okunmadı</span>") + "</td>" +
                "<td><a href='dilekvesikayetoku.aspx?id=" + dr["id"] + "'><img src='images/oku.png' width='30' height='30' /></a> '</td>" +
                "<td><a href='dilekvesikayet.aspx?id=" + dr["id"] + "' class='confirmation' ><img src='images/sil.png' width='35' height='35' /></a> '</td>" +
                "";
            sira++;
        }
        dr.Close();
        bag.Close();
    }
}