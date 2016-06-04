using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidades;
using System.Data;

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
            ent.IdSesion = (string.IsNullOrEmpty(hd_idsesion.Value) ? 0 : Convert.ToInt32(hd_idsesion.Value));
            int idsesion = bl.InsMinuta(ent);
            hd_idsesion.Value = idsesion.ToString();
            if (ent.IdSesion > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "bootbox.alert('<div class=\" alert alert-success\">Datos Actualizados con éxito</div>')", true);
            }
            else
            {
                LoadParticipantes();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "bootbox.alert('<div class=\" alert alert-success\">Sesión Guardada. Agregue a los participantes de la sesión</div>')", true);
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "bootbox.alert('<div class=\"alert alert-danger\">Proceso interrumpido! " + ex.Message.Replace("'", "") + "</div>');", true);
        }
    }

    public void LoadParticipantes()
    {
        try
        {
            Catalogos obj = new Catalogos();
            obj.Tipo = "usuarios";
            CatalogosBL bl = new CatalogosBL();

            ddlparticipantes.DataSource = bl.GetCatalogos(obj);
            ddlparticipantes.DataValueField = "IdCat";
            ddlparticipantes.DataTextField = "NomCat";
            ddlparticipantes.DataBind();
            ddlparticipantes.Items.Insert(0, new ListItem("Seleccionar Participante", "0"));
            ddlparticipantes.Items.FindByValue("0").Selected = true;
        }
        catch(Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "bootbox.alert('<div class=\"alert alert-danger\">Proceso interrumpido! " + ex.Message.Replace("'", "") + "</div>');", true);
        }
    }
    protected void btnaddParticipante_Click(object sender, EventArgs e)
    {
        MinutasBL bl = new MinutasBL();
        MinutasUsuarios usm = new MinutasUsuarios() { ObjMinutas = new Minutas(), ObjUsuarios = new UsuariosDatos() { User=new Usuarios() } };
        usm.ObjMinutas.IdSesion = Convert.ToInt32(hd_idsesion.Value);
        usm.ObjUsuarios.User.IdUser = Convert.ToInt32(ddlparticipantes.SelectedValue);

        bl.InsUsuariosbyMinuta(usm);
        LoadGridParticipantes();
    }

    protected void LoadGridParticipantes()
    {
        try
        {
            MinutasBL bl = new MinutasBL();
            MinutasUsuarios usm = new MinutasUsuarios() { ObjMinutas = new Minutas() };
            usm.ObjMinutas.IdSesion = Convert.ToInt32(hd_idsesion.Value);
            gdvParticipantes.DataSource = bl.GetUsuariosSesion(usm);
            gdvParticipantes.DataBind();
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "bootbox.alert('<div class=\"alert alert-danger\">Proceso interrumpido! " + ex.Message.Replace("'", "") + "</div>');", true);
        }
    }
    protected void gdvParticipantes_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            int id = Convert.ToInt32(gdvParticipantes.DataKeys[e.RowIndex]["IdSesionUser"]);
            MinutasBL bl = new MinutasBL();
            MinutasUsuarios usm = new MinutasUsuarios() { ObjUsuarios = new UsuariosDatos() { User = new Usuarios() } };
            usm.ObjUsuarios.User.IdUser = Convert.ToInt32(Session["IdUser"]);
            usm.IdSesionUser = id;
            bl.DelUsuarioMinuta(usm);
            LoadGridParticipantes();
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "bootbox.alert('Proceso Interrumpido ! " + ex.Message.Replace("'", "") + "');", true);
        }
    }
    protected void gdvParticipantes_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        
       // int key = Convert.ToInt32(gdvParticipantes.DataKeys[e.NewSelectedIndex].Value);
        foreach (GridViewRow row in gdvParticipantes.Rows)
        {
            CheckBox check = row.FindControl("chksel") as CheckBox;
            if (check.Checked)
            {
                row.BackColor = System.Drawing.Color.LightCyan;
            }
            else
            {
                row.BackColor = System.Drawing.Color.White;
            }
        }
    }
    protected void btnGuardarAcuerdo_Click(object sender, EventArgs e)
    {
        var arrayServicios = new DataTable();
        arrayServicios.Columns.Add("idsesion", typeof(int));
        arrayServicios.Columns.Add("fechaini", typeof(DateTime));
        arrayServicios.Columns.Add("fechafin", typeof(DateTime));
        arrayServicios.Columns.Add("idstatus", typeof(int));
        arrayServicios.Columns.Add("descripcion", typeof(string));
        arrayServicios.Columns.Add("idusuario", typeof(int));
        arrayServicios.Columns.Add("idtipoacuerdo", typeof(int));

        int idsesion = Convert.ToInt32(hd_idsesion.Value);
        DateTime fechaini = Convert.ToDateTime(txtfechai_b.Text);
        DateTime fechafin = Convert.ToDateTime(txtfechaf_b.Text);
        string descripcion = txtdescripcionacuerdo.Text;
        int idstatus = 3; // status en seguimiento
        int idtipoacuerdo = 1; //acuerdo tipo individual

        int cont = 0;
        foreach (GridViewRow row in gdvParticipantes.Rows)
        {
            CheckBox check = row.FindControl("chksel") as CheckBox;
            if (check.Checked)
            {
                cont++;
                int idusuarioacuerdo = Convert.ToInt32(gdvParticipantes.DataKeys[row.RowIndex].Values[1]);
                arrayServicios.Rows.Add(idsesion, fechaini, fechafin, idstatus, descripcion, idusuarioacuerdo,idtipoacuerdo);
            }
        }

        if(cont>0)
        {
            MinutasBL bl = new MinutasBL();
            MinutasAcuerdos ent = new MinutasAcuerdos();
            ent.ArrayAcuerdos = arrayServicios;
            bl.InsAcuerdos(ent);
            LoadGridParticipantes();
            limpiarFormAcuerdos();
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "bootbox.alert('<div class=\" alert alert-warning\">Para agregar el Acuerdo tiene que seleccionar al menos un participante de la lista</div>')", true);
        }


    }

    public void limpiarFormAcuerdos()
    {
        txtdescripcionacuerdo.Text = "";
        txtfechai_b.Text = "";
        txtfechaf_b.Text = "";
    }

    public void LoadAcuerdos(GridView gdv, int iduser = 0)
    {
        
        MinutasBL bl = new MinutasBL();
        MinutasAcuerdos min = new MinutasAcuerdos() { ObjMinutas=new Minutas(), ObjTipoacuerdo=new CatTipoAcuerdo(), ObjUserSesion=new UsuariosDatos() };
        min.ObjMinutas.IdSesion = Convert.ToInt32(hd_idsesion.Value);
        min.ObjUserSesion.IdUserSesion = Convert.ToInt32(Session["IdUser"]);
        min.IdAcuerdo = 0;
        min.ObjUserSesion.IdUserMostrar = iduser;
        gdv.DataSource = bl.GetAcuerdos(min);
        gdv.DataBind();

    }
    protected void gdvAcuerdo_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            GridView gdvAcuerdo = (GridView)sender;
            int id = Convert.ToInt32(gdvAcuerdo.DataKeys[e.RowIndex]["IdAcuerdo"]);
            int iduser = Convert.ToInt32(gdvAcuerdo.DataKeys[e.RowIndex]["IdUserMinuta"]);
            MinutasBL bl = new MinutasBL();
            MinutasAcuerdos usm = new MinutasAcuerdos() { ObjUserSesion = new UsuariosDatos() { User = new Usuarios() } };
            usm.ObjUserSesion.User.IdUser = Convert.ToInt32(Session["IdUser"]);
            usm.IdAcuerdo = id;
            bl.DelAcuerdo(usm);
            LoadAcuerdos(gdvAcuerdo, iduser);
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "bootbox.alert('Proceso Interrumpido ! " + ex.Message.Replace("'", "") + "');", true);
        }
    }
    protected void gdvParticipantes_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow && (gdvParticipantes.DataSource != null))
        {
            int id = Convert.ToInt32(gdvParticipantes.DataKeys[e.Row.RowIndex].Values[1]);

            GridView gdvAcuerdos = e.Row.FindControl("gdvAcuerdo") as GridView;
            LoadAcuerdos(gdvAcuerdos, id);
        }
    }
}