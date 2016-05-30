using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidades;
using System.Web.Routing;

public partial class Acceso_Login : System.Web.UI.Page
{
    private VirtualPathData vpd;
    protected void Page_Load(object sender, EventArgs e)
    {
       vpd =
       RouteTable.Routes.GetVirtualPath(null, "IndexApp", null);
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        Usuarios usuario = new Usuarios();
        UsuariosBL bl = new UsuariosBL();
        Session["Usuario"] = "";
        try
        {
            usuario = bl.Sigin(txtmail.Text,txtpass.Text);
            if (usuario.IdUser>0)
            {
                
                Session["Usuario"] = usuario;
                Session["IdUser"] = usuario.IdUser;
                Session["IdRol"] = usuario.Perfil.IdPerfil;
                Response.Redirect(vpd.VirtualPath);
               
            }
            else
            {
                lblMensaje.Visible = true;
                //lblMensaje.Text = "Credenciales Incorrectas";
            }
        }
        catch (Exception ex)
        {
            lblMensaje.Visible = true;
            //lblMensaje.Text = "Ocurrio un error al intentar Autenticar el Usuario:" + ex;
        }
    }
}