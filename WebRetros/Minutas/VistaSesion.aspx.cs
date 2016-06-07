using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.IO;
using Entidades;
using Negocio;

public partial class Minutas_VistaSesion : System.Web.UI.Page
{
    private int idsesion = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (RouteData.Values["idsesion"] != null)
            idsesion = Convert.ToInt32(RouteData.Values["idsesion"]);
        if (!ValidarSesion.sesionactiva())
            Response.Redirect("~/Default.aspx");

        StringBuilder sb = new StringBuilder();
        UserControl ctr = (UserControl)LoadControl("~/Minutas/TemplateDetalleSesion.ascx");
        StringWriter sw = new StringWriter(sb);
        Html32TextWriter htw = new Html32TextWriter(sw);
        ctr.RenderControl(htw);         
        string templete = sb.ToString();
        templete = templete.Replace("#FOLIOSESION#", string.Format("{0,22:D8}",idsesion));

        MinutasBL bl = new MinutasBL();
        Minutas min = new Minutas();
        min.IdSesion = idsesion;
        min=bl.GetMinutasbyFolio(min);

        templete = templete.Replace("#STATUSMINUTA#", min.ObjStatus.nomstatus);
        templete = templete.Replace("#FECHAREGISTRO#", min.Fecharegistro.ToShortDateString());
        templete = templete.Replace("#FECHAPROGRAMADA#", min.Fechafin.Value.ToShortDateString());
        templete = templete.Replace("#FECHACONC#", min.FechaConclusion.ToString());
        templete = templete.Replace("#TIPOSESION#", min.ObjTipoSesion.TipoSesion);
        templete = templete.Replace("#COACHING#", min.ObjUsuarios.NombreCompleto);
        templete = templete.Replace("#DETALLEENTREGA#", min.LabelDias);

        templete = templete.Replace("#OBJETIVO#", HttpUtility.HtmlDecode(min.Objetivo));
        templete = templete.Replace("#DESCRIPCION#",HttpUtility.HtmlDecode( min.Descripcion));


        //usuarios sesion
        /*AGREGAMOS EL DETALLE DE PAGO A PROVEEDORES*/
        StringBuilder sbltvUsuariosMinuta = new StringBuilder();
        System.IO.StringWriter stringWrite = new System.IO.StringWriter(sbltvUsuariosMinuta);
        System.Web.UI.Html32TextWriter htmlWrite = new Html32TextWriter(stringWrite);

        MinutasUsuarios mu = new MinutasUsuarios() { ObjMinutas = new Minutas(), ObjUsuarios = new UsuariosDatos() { User=new Usuarios()} };
        mu.ObjMinutas.IdSesion = idsesion;
        mu.ObjUsuarios.User.IdUser = 0;
        MinutasBL blmu= new MinutasBL();
        ltvUsuariosSesion.DataSource = blmu.GetUsuariosSesion(mu);
        ltvUsuariosSesion.DataBind();
        ltvUsuariosSesion.RenderControl(htmlWrite);
        templete = templete.Replace("#LISTAUSUARIOS#", sbltvUsuariosMinuta.ToString());

        stringWrite.Dispose();
        htmlWrite.Dispose();
        
        ltvUsuariosSesion.Visible = false;
        htmlMinutas.InnerHtml = templete;
    }

    protected void ltvUsuariosSesion_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        if (e.Item.ItemType == ListViewItemType.DataItem && (ltvUsuariosSesion.DataSource != null))
        {
            int id = Convert.ToInt32(ltvUsuariosSesion.DataKeys[e.Item.DataItemIndex].Values[1]);

            ListView ltvAcuerdos = e.Item.FindControl("ltvAcuerdos") as ListView;
            LoadAcuerdos(ltvAcuerdos, id);
            
        }
    }

    protected void LoadAcuerdos(ListView gdv, int iduser = 0)
    {

        MinutasBL bl = new MinutasBL();
        MinutasAcuerdos min = new MinutasAcuerdos() { ObjMinutas = new Minutas(), ObjTipoacuerdo = new CatTipoAcuerdo(), ObjUserSesion = new UsuariosDatos() };
        min.ObjMinutas.IdSesion = idsesion;
        min.ObjUserSesion.IdUserSesion = Convert.ToInt32(Session["IdUser"]);
        min.IdAcuerdo = 0;
        min.ObjUserSesion.IdUserMostrar = iduser;
        gdv.DataSource = bl.GetAcuerdos(min);
        gdv.DataBind();

    }
    protected void ltvAcuerdos_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        if (e.Item.ItemType == ListViewItemType.DataItem && (ltvUsuariosSesion.DataSource != null))
        {
            int id = Convert.ToInt32(ltvUsuariosSesion.DataKeys[e.Item.DataItemIndex].Values[1]);

            /* StringBuilder sbltvUsuariosMinuta = new StringBuilder();
             System.IO.StringWriter stringWrite = new System.IO.StringWriter(sbltvUsuariosMinuta);
             System.Web.UI.Html32TextWriter htmlWrite = new Html32TextWriter(stringWrite);
             */
            ListView ltvComentariosAcuerdos = e.Item.FindControl("ltvComentariosAcuerdos") as ListView;
            LoadComentarios(ltvComentariosAcuerdos, id);
           
        }
    }

    protected void LoadComentarios(ListView gdv, int idacuerdo = 0)
    {

        MinutasBL bl = new MinutasBL();
        MinutasComentarios mc = new MinutasComentarios()
        {
            ObjMinutas = new Minutas() { ObjStatus = new CatStatus() }
            , ObjMinutaAcuerdo=new MinutasAcuerdos(),
            ObjUsercoment = new Usuarios(),
            ObjUserDatos = new UsuariosDatos(),
            ObjStatuscoment = new CatStatus()
        };
        mc.ObjMinutaAcuerdo.IdAcuerdo = idacuerdo;
        mc.ObjUsercoment.IdUser = 0;
        mc.Idcomentario = 0;
        gdv.DataSource = bl.GetComentariosAcuerdos(mc);
        gdv.DataBind();

    }
}