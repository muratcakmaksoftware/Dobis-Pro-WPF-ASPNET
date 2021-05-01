using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Globalization;

public partial class dersprogram : System.Web.UI.Page
{
    SqlConnection bag;
    SqlCommand cmd;
    fonk fnk = new fonk();
    protected void Page_Load(object sender, EventArgs e)
    {
        bag = fnk.bag();

        if (!IsPostBack)
        {   
            siniflarigetir();
            dersPrograminiGoster();
        }
        
    }

    void siniflarigetir()
    {
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
                drpSinifFiltrele.Items.Add(dr["ogSinif"].ToString());
            }
        }
        dr.Close();
        bag.Close();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (fileExcel.HasFile)
        {
            fileExcel.SaveAs(MapPath("excel/" + fileExcel.FileName));
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            OleDbDataAdapter adp;
            try
            {
                adp = new OleDbDataAdapter("SELECT * FROM [dersProgram$]", "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + MapPath("excel/" + fileExcel.FileName) + "; Extended Properties=Excel 8.0");
                adp.Fill(ds, "dersProgram");
                adp.Fill(dt);
            }
            catch
            {
                fnk.alert("Doğru Ders Programını Seçtiğinizden Emin Olun.", this.Page);
            }
           
            if (dt != null) // eğer bilgiler varsa excel boş değildir.
            {              
               
                //Önce eklenen aynı sınıfın ders programı varsa siliniyor ve yenisi eklenecek.
                cmd = new SqlCommand();
                cmd.Connection = bag;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "dpsil";
                cmd.Parameters.Add("@sinif", SqlDbType.VarChar).Value = drpSinif.Text;
                bag.Open();
                cmd.ExecuteNonQuery();
                bag.Close();

                foreach (DataRow item in dt.Rows)
                {
                    if (item[0].ToString() != "") // fazladan boş satırları eklediğinden boş geçilmesini sağlayıp hata sağlanmamasını sağlıyoruz.
                    {
                        cmd = new SqlCommand();
                        cmd.Connection = bag;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "dpekle";
                        cmd.Parameters.Add("@sinif", SqlDbType.VarChar).Value = drpSinif.Text;

                        cmd.Parameters.Add("@ders", SqlDbType.VarChar).Value = item[0].ToString();
                        int[] cvzmn = Array.ConvertAll(item[1].ToString().Split(':'), int.Parse);
                        cmd.Parameters.Add("@giris", SqlDbType.Time).Value = new TimeSpan(cvzmn[0], cvzmn[1], 0);
                        cvzmn = Array.ConvertAll(item[2].ToString().Split(':'), int.Parse);
                        cmd.Parameters.Add("@cikis", SqlDbType.Time).Value = new TimeSpan(cvzmn[0], cvzmn[1], 0);

                        cmd.Parameters.Add("@pztDersAdi", SqlDbType.VarChar).Value = item[3].ToString();
                        cmd.Parameters.Add("@pztDersOgretmen", SqlDbType.VarChar).Value = item[4].ToString();
                        cmd.Parameters.Add("@pztDersSinif", SqlDbType.VarChar).Value = item[5].ToString();

                        cmd.Parameters.Add("@saliDersAdi", SqlDbType.VarChar).Value = item[6].ToString();
                        cmd.Parameters.Add("@saliDersOgretmen", SqlDbType.VarChar).Value = item[7].ToString();
                        cmd.Parameters.Add("@saliDersSinif", SqlDbType.VarChar).Value = item[8].ToString();

                        cmd.Parameters.Add("@carDersAdi", SqlDbType.VarChar).Value = item[9].ToString();
                        cmd.Parameters.Add("@carDersOgretmen", SqlDbType.VarChar).Value = item[10].ToString();
                        cmd.Parameters.Add("@carDersSinif", SqlDbType.VarChar).Value = item[11].ToString();

                        cmd.Parameters.Add("@perDersAdi", SqlDbType.VarChar).Value = item[12].ToString();
                        cmd.Parameters.Add("@perDersOgretmen", SqlDbType.VarChar).Value = item[13].ToString();
                        cmd.Parameters.Add("@perDersSinif", SqlDbType.VarChar).Value = item[14].ToString();

                        cmd.Parameters.Add("@cumaDersAdi", SqlDbType.VarChar).Value = item[15].ToString();
                        cmd.Parameters.Add("@cumaDersOgretmen", SqlDbType.VarChar).Value = item[16].ToString();
                        cmd.Parameters.Add("@cumaDersSinif", SqlDbType.VarChar).Value = item[17].ToString();
                        bag.Open();
                        cmd.ExecuteNonQuery();
                        bag.Close();
                    }                       
                }

                fnk.alert("Ders Programı Başarıyla Veritabanına Aktarıldı.", this.Page);
            }
            else
                fnk.alert("Excel Boş.", this.Page);

        }
    }


    protected void drpSinifFiltrele_SelectedIndexChanged(object sender, EventArgs e)
    {
        dersPrograminiGoster();
    }

    void dersPrograminiGoster()
    {
        if (drpSinifFiltrele.Items.Count > 0)
        {
            bag.Open();
            cmd = new SqlCommand();
            cmd.Connection = bag;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "dpgetirsinif";
            cmd.Parameters.Add("@sinif", SqlDbType.VarChar).Value = drpSinifFiltrele.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                ltdersprogram.Text = "";
                while (dr.Read())
                {

                    ltdersprogram.Text += "<tr>" +
                        "<td>" + dr["ders"] + "</td>" +
                        "<td>" + dr["giris"] + "</td>" +
                        "<td>" + dr["cikis"] + "</td>" +
                        "<td>" + dr["pztDersAdi"] + "<br/>" + dr["pztDersOgretmen"] + "<br/>" + dr["pztDersSinif"] + "</td>" +

                        "<td>" + dr["saliDersAdi"] + "<br/>" + dr["saliDersOgretmen"] + "<br/>" + dr["saliDersSinif"] + "</td>" +

                        "<td>" + dr["carDersAdi"] + "<br/>" + dr["carDersOgretmen"] + "<br/>" + dr["carDersSinif"] + "</td>" +

                        "<td>" + dr["perDersAdi"] + "<br/>" + dr["perDersOgretmen"] + "<br/>" + dr["perDersSinif"] + "</td>" +

                        "<td>" + dr["cumaDersAdi"] + "<br/>" + dr["cumaDersOgretmen"] + "<br/>" + dr["cumaDersSinif"] + "</td>" +
                        "";
                }
                dr.Close();
                bag.Close();
            }
            else
                ltdersprogram.Text = "";
        }
    }


}