<%@ WebHandler Language="C#" Class="ManejadorSesion" %>

using System;
using System.Web;

public class ManejadorSesion : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.Cache.SetNoStore();
        context.Response.ContentType = "application/x-javascript";
        context.Response.Write("Su sesion esta a punto de Expirar. Click para continuar conectado");
        context.Response.End();
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}