using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidades;

public partial class Minutas_Nuevaminuta : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            LoadTemas();
            LoadTipoSesion();
        }
    }

    protected void LoadTemas()
    {
        CatTemasNegocio bl = new CatTemasNegocio();
        ddltema.DataSource = bl.list();
        ddltema.DataValueField = "idtema";
        ddltema.DataTextField = "descripcion";
        ddltema.DataBind();
        ddltema.Items.Insert(0, new ListItem("Seleccionar", "0"));
        ddltema.Items.FindByValue("0").Selected = true;
    }
    protected void LoadTipoSesion()
    {
        Catalogos obj = new Catalogos();
        obj.Tipo = "tiposesion";
        CatalogosBL bl = new CatalogosBL();

        ddltiposesion.DataSource = bl.GetCatalogos(obj);
        ddltiposesion.DataValueField = "IdCat";
        ddltiposesion.DataTextField = "NomCat";
        ddltiposesion.DataBind();
        ddltiposesion.Items.Insert(0, new ListItem("Seleccionar", "0"));
        ddltiposesion.Items.FindByValue("0").Selected = true;
    }
    protected void btnGuardarSesion_Click(object sender, EventArgs e)
    {
        try
        {
            Minutas ent = new Minutas() { ObjTemas = new CatTemas(), ObjUsuarios = new UsuariosDatos(){ User=new Usuarios()}, ObjTipoSesion = new CatTipoSesion() };
            MinutasBL bl = new MinutasBL();
            ent.ObjTemas.idtema = Convert.ToInt32(ddltema.SelectedValue);
            ent.Objetivo = txtobservaciones.InnerHtml;
            ent.Descripcion = txtdescripcion.InnerHtml;
            ent.Fechafin = Convert.ToDateTime(txtfechacierre.Text);
            ent.ObjUsuarios.User.IdUser = Convert.ToInt32(Session["IdUser"].ToString());
            ent.ObjTipoSesion.IdTipo = Convert.ToInt32(ddltiposesion.SelectedValue);

            int idsesion = bl.InsMinuta(ent);
            hd_idsesion.Value = idsesion.ToString();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "bootbox.alert('<div class=\" alert alert-success\">Sesión Creada. Agregue a los participantes de la sesión</div>')", true);
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "bootbox.alert('<div class=\"alert alert-danger\">Proceso interrumpido! " + ex.Message.Replace("'", "") + "</div>');", true);
        }
    }
}