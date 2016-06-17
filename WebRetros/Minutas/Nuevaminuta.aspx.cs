using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidades;
using System.Data;
using System.Text;
using System.IO;



public partial class Minutas_Nuevaminuta : System.Web.UI.Page
{
    private int idsesion = 0;
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
            idsesion = bl.InsMinuta(ent);
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
        ddlparticipantes.ClearSelection();
        ddlparticipantes.SelectedIndex = 0;
        LoadGridParticipantes();
    }

    protected void LoadGridParticipantes()
    {
        try
        {
            MinutasBL bl = new MinutasBL();
            
            MinutasUsuarios usm = new MinutasUsuarios() { ObjMinutas = new Minutas(), ObjUsuarios = new UsuariosDatos() { User = new Usuarios() } };
            usm.ObjMinutas.IdSesion = Convert.ToInt32(hd_idsesion.Value);
            usm.ObjUsuarios.User.IdUser = Convert.ToInt32(Session["IdUser"]);
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

    protected void limpiarFormAcuerdos()
    {
        txtdescripcionacuerdo.Text = "";
        txtfechai_b.Text = "";
        txtfechaf_b.Text = "";
    }

    protected void LoadAcuerdos(GridView gdv, int iduser = 0)
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
   
    protected void gdvAcuerdo_RowEditing(object sender, GridViewEditEventArgs e)
    {
        /*
         int id = Convert.ToInt32(gdvAcuerdo.DataKeys[e.NewEditIndex].Values[1]);
        MinutasBL bl = new MinutasBL();
        MinutasAcuerdos min = new MinutasAcuerdos() { ObjMinutas = new Minutas(), ObjTipoacuerdo = new CatTipoAcuerdo(), ObjUserSesion = new UsuariosDatos() };
        min.ObjMinutas.IdSesion = Convert.ToInt32(hd_idsesion.Value);
        min.ObjUserSesion.IdUserSesion = Convert.ToInt32(Session["IdUser"]);
        min.IdAcuerdo = id;
        min.ObjUserSesion.IdUserMostrar = 0;

        min = bl.GetAcuerdosByFolio(min);

        txtfechai_b.Text = min.FechaIni.ToString();
        */
    }

    protected void MailTemplate()
    {
        try
        {
            if(gdvParticipantes.Rows.Count>0)
            { 
                StringBuilder sb = new StringBuilder();
                UserControl ctr = (UserControl)LoadControl("~/Minutas/TemplateMailMinuta.ascx");
                StringWriter sw = new StringWriter(sb);
                Html32TextWriter htw = new Html32TextWriter(sw);
                ctr.RenderControl(htw);
                string templete = sb.ToString();
                idsesion = Convert.ToInt32(hd_idsesion.Value);
                MinutasUsuarios mu = new MinutasUsuarios() { ObjMinutas = new Minutas(), ObjUsuarios = new UsuariosDatos() { User = new Usuarios() } };
                mu.ObjMinutas.IdSesion = idsesion;
                mu.ObjUsuarios.User.IdUser = Convert.ToInt32(Session["IdUser"]);
                MinutasBL blmu = new MinutasBL();


                MinutasBL bl = new MinutasBL();
                Minutas min = new Minutas() { ObjUsuarios = new UsuariosDatos() { User = new Usuarios() } };
                min.IdSesion = idsesion;
                min.ObjUsuarios.User.IdUser = Convert.ToInt32(Session["IdUser"]);
                min = bl.GetMinutasbyFolio(min);

                templete = templete.Replace("#Foliominuta#", string.Format("{0:D8}", idsesion));
                templete = templete.Replace("#Fechacreacion#", min.Fecharegistro.ToShortDateString());
                templete = templete.Replace("#Usuariocreador#", min.ObjUsuarios.NombreUser);
                templete = templete.Replace("#Tematica#", min.ObjTemas.descripcion);
                templete = templete.Replace("#Fechaentrega#", min.Fechafin.HasValue ? min.Fechafin.Value.ToShortDateString() : "");
                templete = templete.Replace("#Tiposesion#", min.ObjTipoSesion.TipoSesion);
            
                templete = templete.Replace("#Objetivo#", HttpUtility.HtmlDecode(min.Objetivo));
                templete = templete.Replace("#Descripcion#", HttpUtility.HtmlDecode(min.Descripcion));

                string minutacompleta = "";

                Email objemail = new Email();
                EmailBL blmail = new EmailBL();
                objemail.Principal = true;
                objemail.IdMail = 0;
                objemail.Usermail = string.Empty;

                objemail = blmail.GetEmail(objemail);
                objemail.Asunto = "Notificación de nueva Sesión de minuta. Folio " + string.Format("{0:D8}", idsesion);


                foreach (MinutasUsuarios item in blmu.GetUsuariosSesion(mu))
                {
                    MinutasUsuarios obj = new MinutasUsuarios() { ObjMinutas = new Minutas(), ObjUsuarios = new UsuariosDatos() { User = new Usuarios() } };
                    obj.ObjMinutas.IdSesion = idsesion;
                    obj.ObjUsuarios.User.IdUser = item.IdUserMinuta;
                    MinutasBL mbl = new MinutasBL();

                    StringBuilder sb1 = new StringBuilder();
                    UserControl ctr1 = (UserControl)LoadControl("~/Minutas/TemplateMailMinuta.ascx");
                    StringWriter sw1 = new StringWriter(sb1);
                    Html32TextWriter htw1 = new Html32TextWriter(sw1);
                    ctr1.RenderControl(htw1);
                    string templeteaux = sb1.ToString();

                    templeteaux = templeteaux.Replace("#Usuario#", item.ObjUsuarios.NombreCompleto);
                    templeteaux = templeteaux.Replace("#Foliominuta#", string.Format("{0:D8}", idsesion));
                    templeteaux = templeteaux.Replace("#Fechacreacion#", min.Fecharegistro.ToShortDateString());
                    templeteaux = templeteaux.Replace("#Usuariocreador#", min.ObjUsuarios.NombreUser);
                    templeteaux = templeteaux.Replace("#Tematica#", min.ObjTemas.descripcion);
                    templeteaux = templeteaux.Replace("#Fechaentrega#", min.Fechafin.HasValue ? min.Fechafin.Value.ToShortDateString() : "");
                    templeteaux = templeteaux.Replace("#Tiposesion#", min.ObjTipoSesion.TipoSesion);

                    templeteaux = templeteaux.Replace("#Objetivo#", HttpUtility.HtmlDecode(min.Objetivo));
                    templeteaux = templeteaux.Replace("#Descripcion#", HttpUtility.HtmlDecode(min.Descripcion));

                    StringBuilder sbltvUsuariosMinuta = new StringBuilder();
                    System.IO.StringWriter stringWrite = new System.IO.StringWriter(sbltvUsuariosMinuta);
                    System.Web.UI.Html32TextWriter htmlWrite = new Html32TextWriter(stringWrite);

                    ltvUsuariosSesion.DataSource = mbl.GetUsuariosSesion(obj);
                    ltvUsuariosSesion.DataBind();
                    ltvUsuariosSesion.RenderControl(htmlWrite);

                    minutacompleta += sbltvUsuariosMinuta.ToString();
                    templeteaux = templeteaux.Replace("#Acuerdos#", sbltvUsuariosMinuta.ToString());

                    generales gral = new generales();
                    if (gral.IsValidEmail(item.ObjUsuarios.User.Username))
                    {
                        objemail.Body = templeteaux;
                        objemail.MailTo = item.ObjUsuarios.User.Username;
                        objemail.MailCC = string.Empty;
                        objemail.MailBcc = string.Empty;
                        generales.enviarMail(objemail);
                    }
                    stringWrite.Dispose();
                    htmlWrite.Dispose();

                    sw1.Dispose();
                    htw1.Dispose();

                }

                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "$('.modalfinsesion').modal('show')", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "bootbox.alert('<div class=\" alert alert-warning\">No existe participantes para ésta sesión. Para enviar la notificación es necesario incluir a los participantes.</div>')", true);
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "bootbox.alert('<div class=\"alert alert-danger\">Se produjo un error al enviar el mail! " + ex.Message.Replace("'", "") + "</div>');", true);
        }

    }

    #region render para mail

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
        ListView ltvAcuerdos = (ListView)sender;
        if (e.Item.ItemType == ListViewItemType.DataItem && (ltvAcuerdos.DataSource != null))
        {
            int id = Convert.ToInt32(ltvAcuerdos.DataKeys[e.Item.DataItemIndex].Values[0]);

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
    #endregion 
    protected void btnfinalizar_Click(object sender, EventArgs e)
    {
        MailTemplate();
    }
    protected void btnreload_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/minutas/nuevo");
    }
    protected void btnirahistorial_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/minutas/list");
    }
}