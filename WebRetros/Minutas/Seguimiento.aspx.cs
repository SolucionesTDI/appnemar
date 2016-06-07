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
    private int idusuariosesion = 0;
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
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "bootbox.alert('<div class=\" alert alert-warning\">El folio ingresado no es válido</div>')", true);
            
        }
        catch(Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "bootbox.alert('<div class=\"alert alert-danger\">Proceso interrumpido! " + ex.Message.Replace("'", "") + "</div>');", true);

        }
    }
    protected void CargarDatos(int foliominuta)
    {
        MinutasBL bl = new MinutasBL();
        Minutas min = new Minutas() { ObjUsuarios = new UsuariosDatos() { User = new Usuarios() } };
        min.IdSesion = foliominuta;
        min.ObjUsuarios.User.IdUser = Convert.ToInt32(Session["IdUser"]);
        min = bl.GetMinutasbyFolio(min);
        if (min.IdSesion > 0)
        {
            idusuariosesion = min.ObjUsuarios.User.IdUser;
            lblobjetivos.Text = HttpUtility.HtmlDecode(min.Objetivo);
            lbldescripcion.Text = HttpUtility.HtmlDecode(min.Descripcion);
            txtfoliominuta.Text = string.Format("{0:D8}", foliominuta);
            txtfoliominuta.Text.Trim();
            txtfechacierre.Text = min.Fechafin.ToString();
            txttiposesion.Text = min.ObjTipoSesion.TipoSesion;
            LoadUsuariosSesion(foliominuta);
            LoadStatus();
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "bootbox.alert('<div class=\" alert alert-warning\">El folio ingresado no es válido</div>')", true);
        }
    }

    protected void LoadStatus()
    {
        string tipo = "tipostatus";
        if (idusuariosesion != Convert.ToInt32(Session["IdUser"]))
        {
            tipo = "statususer";
        }
        CatalogosBL cbl = new CatalogosBL();
        Catalogos cat = new Catalogos();
        cat.Tipo = tipo;
        ddlstatuscambia.DataSource = cbl.GetCatalogos(cat);
        ddlstatuscambia.DataValueField = "IdCat";
        ddlstatuscambia.DataTextField = "NomCat";
        ddlstatuscambia.DataBind();
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
        min.ObjMinutas.IdSesion = Convert.ToInt32(txtfoliominuta.Text.Trim());
        min.ObjUserSesion.IdUserSesion = Convert.ToInt32(Session["IdUser"]);
        min.IdAcuerdo = 0;
        min.ObjUserSesion.IdUserMostrar = iduser;
        gdv.DataSource = bl.GetAcuerdos(min);
        gdv.DataBind();

    }
    protected void ltvAcuerdos_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        ListView ltvAcuerdos = (ListView)sender;
        if (e.Item.ItemType == ListViewItemType.DataItem && (ltvAcuerdos.DataSource != null))
        {

            int id = Convert.ToInt32(ltvAcuerdos.DataKeys[e.Item.DataItemIndex].Values[0]);

            /* StringBuilder sbltvUsuariosMinuta = new StringBuilder();
             System.IO.StringWriter stringWrite = new System.IO.StringWriter(sbltvUsuariosMinuta);
             System.Web.UI.Html32TextWriter htmlWrite = new Html32TextWriter(stringWrite);
             */

            MinutasAcuerdos ent = new MinutasAcuerdos();
            
            ent = (e.Item.DataItem as MinutasAcuerdos);
            LinkButton linkiniciar = (e.Item.FindControl("linkiniciar") as LinkButton);
            
            if(ent.FechaIniReal.HasValue)
            {
                linkiniciar.Visible = false;
            }

           
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
    protected void ltvAcuerdos_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        try
        {
            ListView ltvAcuerdos = (ListView)sender;
            int rowindex = Convert.ToInt32(e.CommandArgument);
            int idacuerdo = Convert.ToInt32(ltvAcuerdos.DataKeys[rowindex].Values[0]);
            int idusuario = Convert.ToInt32(ltvAcuerdos.DataKeys[rowindex].Values[1]);
            if (e.CommandName == "IniciarAcuerdo")
            {
            
                    MinutasAcuerdos mina = new MinutasAcuerdos() { ObjUserSesion = new UsuariosDatos() { User = new Usuarios() } };
                    mina.IdAcuerdo = idacuerdo;
                    mina.IdUserMinuta = idusuario;
                    MinutasBL mbl = new MinutasBL();
                    mbl.IniciarAcuerdo(mina);
                    LoadAcuerdos(ltvAcuerdos, idusuario);
            
            }
            if (e.CommandName == "ActualizarStatus")
            {

                hdacuerdo_status.Value = idacuerdo.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "$('#modalstatus').modal('show')", true);

            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "bootbox.alert('<div class=\"alert alert-danger\">Proceso interrumpido! " + ex.Message.Replace("'", "") + "</div>');", true);

        }

    }
    protected void btnguardarcomentario_Click(object sender, EventArgs e)
    {
        MinutasComentarios mc = new MinutasComentarios() { ObjUsercoment=new Usuarios(),ObjMinutaAcuerdo=new MinutasAcuerdos() };
        MinutasBL bl = new MinutasBL();
        try
        {
            mc.ObjMinutaAcuerdo.IdAcuerdo = Convert.ToInt32(hd_idacuerdo.Value);
            mc.ObjUsercoment.IdUser = Convert.ToInt32(Session["IdUser"]);
            mc.Comentarios = txtcomentario_acuerdo.Text.Trim();
            bl.InsComentarios(mc);
            LoadUsuariosSesion(Convert.ToInt32(txtfoliominuta.Text));
            txtcomentario_acuerdo.Text = "";
            hd_idacuerdo.Value = "";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "$('#modalComentarios').modal('hide')", true);
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "bootbox.alert('<div class=\"alert alert-danger\">Proceso interrumpido! " + ex.Message.Replace("'", "") + "</div>');", true);

        }

    }
    protected void btnActualizarStatus_Click(object sender, EventArgs e)
    {
        try
        {
            MinutasAcuerdos min = new MinutasAcuerdos() { ObjStatus = new CatStatus(), ObjUserSesion = new UsuariosDatos() { User=new Usuarios() } };
            min.IdAcuerdo = Convert.ToInt32(hdacuerdo_status.Value);
            min.ObjStatus.idstatus = Convert.ToInt32(ddlstatuscambia.SelectedValue);
            min.ObjUserSesion.User.IdUser = Convert.ToInt32(Session["IdUser"]);
            MinutasBL bl = new MinutasBL();
            bl.UpdEstatusAcuerdo(min);
            LoadUsuariosSesion(Convert.ToInt32(txtfoliominuta.Text));
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "$('#modalstatus').modal('hide')", true);
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "bootbox.alert('<div class=\"alert alert-danger\">Proceso interrumpido! " + ex.Message.Replace("'", "") + "</div>');", true);

        }
    }
}