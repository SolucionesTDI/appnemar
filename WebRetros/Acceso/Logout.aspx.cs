using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Acceso_Logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Usuario"] != null)
        {
            Session.Remove("Usuario");
        }
        if (Session["IdUser"] != null)
        {
            Session.Remove("IdUser");
        }

        if (Session["IdRol"] != null)
        {
            Session.Remove("IdRol");
        }


        Response.Redirect("~/Default.aspx");
    }
}