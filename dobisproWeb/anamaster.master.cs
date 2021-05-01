using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class anamaster : System.Web.UI.MasterPage
{

    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["kadidobis"] == null || Session["sifredobis"] == null)
            Response.Redirect("login.aspx");
        
    }
}
