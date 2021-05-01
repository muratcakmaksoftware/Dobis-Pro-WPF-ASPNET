using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class dilekvesikayetoku : System.Web.UI.Page
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
        }
        else
            Response.Redirect("dilekvesikayet.aspx");

        if (fnk.IsNumeric(id))
        {

            bag.Open();
            cmd = new SqlCommand();
            cmd.Connection = bag;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "dvsokunduisaretle";
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = Convert.ToInt32(id);
            cmd.ExecuteNonQuery();            
            bag.Close();

            cmd.CommandText = "dvsokunanmesaj";
            bag.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                txtkonu.Text = dr["konu"].ToString();
                txtmesaj.Text = dr["mesaj"].ToString();
            }
            dr.Close();
            bag.Close();
        }
        else
            Response.Redirect("dilekvesikayet.aspx");
    }

    protected void btnsil_Click(object sender, EventArgs e)
    {
        bag.Open();
        cmd = new SqlCommand();
        cmd.Connection = bag;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "dvssil";
        cmd.Parameters.Add("@id", SqlDbType.Int).Value = Convert.ToInt32(id);
        cmd.ExecuteNonQuery();
        bag.Close();
        Response.Redirect("dilekvesikayet.aspx");

    }
}