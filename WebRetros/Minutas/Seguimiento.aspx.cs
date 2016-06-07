using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidades;

public partial class Minutas_Seguimiento : System.Web.UI.Page
{
    private int idsesion = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!ValidarSesion.sesionactiva())
            Response.Redirect("~/Default.aspx");

        if (RouteData.Values["idsesion"] != null)
            idsesion = Convert.ToInt32(RouteData.Values["idsesion"]);
        if(!IsPostBack)
        {
            if (idsesion > 0)
            {
                CargarDatos(idsesion);
            }
        }
    }
    protected void btnCargarDatos_Click(object sender, EventArgs e)
    {
        try
        {
            string folio = txtfoliominuta.Text;
            int valor = 0;
            bool canConvert = int.TryParse(folio, out valor);
            if (canConvert == true)
                CargarDatos(Convert.ToInt32(folio));
            else
                Console.WriteLine("numString is not a valid long");
            
        }
        catch(Exception ex)
        {

        }
    }
    protected void CargarDatos(int foliominuta)
    {
        MinutasBL bl = new MinutasBL();
        Minutas min = new Minutas();
        min.IdSesion = foliominuta;
        min = bl.GetMinutasbyFolio(min);
        lblobjetivos.Text = HttpUtility.HtmlDecode(min.Objetivo);
        lbldescripcion.Text = HttpUtility.HtmlDecode(min.Descripcion);
        txtfoliominuta.Text = string.Format("{0,22:D8}", foliominuta);
        txtfechacierre.Text = min.Fechafin.ToString();
        txttiposesion.Text = min.ObjTipoSesion.TipoSesion;
        LoadUsuariosSesion(foliominuta);
    }
    protected void LoadUsuariosSesion(int idminuta=0)
    {
        MinutasUsuarios mu = new MinutasUsuarios() { ObjMinutas = new Minutas(), ObjUsuarios = new UsuariosDatos() { User = new Usuarios() } };
        mu.ObjMinutas.IdSesion = idminuta;
        mu.ObjUsuarios.User.IdUser = Convert.ToInt32(Session["IdUser"]);
        MinutasBL blmu = new MinutasBL();
        ltvUsuariosSesion.DataSource = blmu.GetUsuariosSesion(mu);
        ltvUsuariosSesion.DataBind();
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
            ,
            ObjMinutaAcuerdo = new MinutasAcuerdos(),
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