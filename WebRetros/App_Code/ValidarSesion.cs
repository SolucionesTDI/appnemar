using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entidades;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
/// <summary>
/// Descripción breve de ValidarSesion
/// </summary>
public class ValidarSesion
{
	public ValidarSesion()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}
    public static bool sesionactiva()
    {
        Usuarios UserMaster = new Usuarios() { Perfil = new Perfiles() };
        UserMaster = HttpContext.Current.Session["Usuario"] as Usuarios;
        if (UserMaster == null)
        {
            return false;
           // HttpContext.Current.Response.Redirect("~/Default.aspx");
        }
        return true;

    }

    public static bool IsSessionTimedOut()
    {
        HttpContext ctx = HttpContext.Current;
        if (ctx == null)
            throw new Exception("Este método sólo se puede usar en una aplicación Web");

        //Comprobamos que haya sesión en primer lugar 
        //(por ejemplo si por ejemplo EnableSessionState=false)
        if (ctx.Session == null)
            return false;   //Si no hay sesión, no puede caducar
        //Se comprueba si se ha generado una nueva sesión en esta petición
        if (!ctx.Session.IsNewSession)
            return false;   //Si no es una nueva sesión es que no ha caducado

        HttpCookie objCookie = ctx.Request.Cookies["ASP.NET_SessionId"];
        //Esto en teoría es imposible que pase porque si hay una 
        //nueva sesión debería existir la cookie, pero lo compruebo porque
        //IsNewSession puede dar True sin ser cierto (más en el post)
        if (objCookie == null)
            return false;

        //Si hay un valor en la cookie es que hay un valor de sesión previo, pero como la sesión 
        //es nueva no debería estar, por lo que deducimos que la sesión anterior ha caducado
        if (!string.IsNullOrEmpty(objCookie.Value))
            return true;
        else
            return false;
    }
}