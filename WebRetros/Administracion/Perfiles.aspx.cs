using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidades;

public partial class Administracion_Perfiles : System.Web.UI.Page
{
    PerfilesNegocio _catperfilneg = new PerfilesNegocio();
    MenuPerfilNegocio _catmenuperfilneg = new MenuPerfilNegocio();
    Entidades.Perfiles _objperfil;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!ValidarSesion.sesionactiva())
            Response.Redirect("~/Default.aspx");

        if (!Page.IsPostBack)
        {
            GridViewPerfiles.DataSource = _catperfilneg.list();
            GridViewPerfiles.DataBind();
            txtCambiarNombrePerfil.Attributes.Add("placeholder", "Nombre");
            txtBusquedaNombrePerfil.Attributes.Add("placeholder", "Perfil");
            txtNombrePerfil.Attributes.Add("placeholder", "Nombre");
        }
    }
  
  
    protected void GridView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EliminarPerfil")
        {
            int fila = Convert.ToInt32(e.CommandArgument);
            ID.Value = this.GridViewPerfiles.DataKeys[fila].Value.ToString();
            lblModalTitleEliminar.Text = "Eliminar";
            Label labeltemp = GridViewPerfiles.Rows[fila].FindControl("NomPerfil") as Label;
            string valor = labeltemp.Text;
            lblModalBodyEliminar.Text = "¿ Esta seguro que desea eliminar el Perfil : " + valor + " ?";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalEliminar", "$('#ModalEliminar').modal();", true);
            upModalEliminar.Update();
        }

        if (e.CommandName == "CambiarNombrePerfil")
        {
            lblMensajeEditar.Visible = false;
            int fila = Convert.ToInt32(e.CommandArgument);
            lblModalTitleEditar.Text = "Editar Nombre del Perfil";
            txtCambiarNombrePerfil.Text =((Label)this.GridViewPerfiles.Rows[fila].FindControl("NomPerfil")).Text;
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalCambiarNombrePerfil", "$('#ModalCambiarNombrePerfil').modal();", true);
            upModalCambiarNombrePerfil.Update();
            ID.Value = this.GridViewPerfiles.DataKeys[fila].Value.ToString();
        }

        if (e.CommandName == "EditarPermisos")
        {

            
            int fila = Convert.ToInt32(e.CommandArgument);
            ID.Value = this.GridViewPerfiles.DataKeys[fila].Value.ToString();
            Label labeltemp = GridViewPerfiles.Rows[fila].FindControl("NomPerfil") as Label;
            string valor = labeltemp.Text;
            txtNombrePerfil.Visible = false;
            EtiquetaNombrePerfil.Visible = false;
            lblNombrePerfil.Visible = false;  
            lblModalTitleNuevo.Text = "Editar Permisos de " + valor ;
            Operacion.Value = "Editar";
            chckboxlist.DataSource = _catperfilneg.listmenus();
            chckboxlist.DataValueField = "idmenu";
            chckboxlist.DataTextField = "nommenu";
            chckboxlist.DataBind();
            MenusBL _menuneg = new MenusBL();
           
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalOperPerfil", "$('#ModalOperPerfil').modal();", true);
            
            upModalOperPerfil.Update();
            foreach (Entidades.Menu obj in _menuneg.GetMenus(Convert.ToInt32(ID.Value)))
            {
                foreach (ListItem itemActual in chckboxlist.Items)
                {
                    if (itemActual.Value == obj.Idmenu.ToString())
                    {
                        itemActual.Selected = true;

                    }
                }
             
            }
        }



    }
    protected void BuscarPefil_Click(object sender, EventArgs e)
    {
        GridViewPerfiles.DataSource = _catperfilneg.list(0,txtBusquedaNombrePerfil.Text);
        GridViewPerfiles.DataBind();
    }
    protected void Guardar_Click(object sender, EventArgs e)
    {
        if (Operacion.Value == "Nuevo")
        {
            if(txtNombrePerfil.Text == string.Empty)
            {
                lblNombrePerfil.Visible = true;
                upModalOperPerfil.Update();
              
            }
            else
            {
                _objperfil = new Entidades.Perfiles();
                _objperfil.NomPerfil = txtNombrePerfil.Text;
                _objperfil.IdUsuario = Convert.ToInt32(Session["IdUser"]);
                List<Entidades.Menu> lstmenus = new List<Entidades.Menu>();
                Entidades.Menu _objmenu;
                foreach (ListItem itemActual in chckboxlist.Items)
                {
                    if (itemActual.Selected == true)
                    {
                        _objmenu = new Entidades.Menu();
                        _objmenu.Idmenu = Convert.ToInt32(itemActual.Value);
                        lstmenus.Add(_objmenu);
                        _objmenu = new Entidades.Menu();
                        _objmenu.Idmenu = _catperfilneg.listmenus(Convert.ToInt32(itemActual.Value))[0].idpadre;
                        lstmenus.Add(_objmenu);
                    }

                }
                _catperfilneg.insertarPerfil(_objperfil, lstmenus);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalOperPerfil", "$('#ModalOperPerfil').modal('hide');", true);
                upModalOperPerfil.Update();
                GridViewPerfiles.DataSource = _catperfilneg.list();
                GridViewPerfiles.DataBind();

            }
           
        }
        if (Operacion.Value == "Editar")
        {
           
                _objperfil = new Entidades.Perfiles();
                _objperfil.IdPerfil = Convert.ToInt32(ID.Value);
                _objperfil.IdUsuario = Convert.ToInt32(Session["IdUser"]);
                List<Entidades.Menu> lstmenus = new List<Entidades.Menu>();
                Entidades.Menu _objmenu;
                foreach (ListItem itemActual in chckboxlist.Items)
                {
                    if (itemActual.Selected == true)
                    {
                        _objmenu = new Entidades.Menu();
                        _objmenu.Idmenu = Convert.ToInt32(itemActual.Value);
                        lstmenus.Add(_objmenu);
                        _objmenu = new Entidades.Menu();
                        _objmenu.Idmenu = _catperfilneg.listmenus(Convert.ToInt32(itemActual.Value))[0].idpadre;
                        lstmenus.Add(_objmenu);
                    }

                }
                _catmenuperfilneg.actualizarMenuPerfiles(_objperfil, lstmenus);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalOperPerfil", "$('#ModalOperPerfil').modal('hide');", true);
                upModalOperPerfil.Update();
                GridViewPerfiles.DataSource = _catperfilneg.list();
                GridViewPerfiles.DataBind();
            
        }
           


    }
    protected void NuevoPerfil_Click(object sender, EventArgs e)
    {
        txtNombrePerfil.Text = string.Empty;
        txtNombrePerfil.Visible = true;
        EtiquetaNombrePerfil.Visible = true;
        lblNombrePerfil.Visible = false;
        lblModalTitleNuevo.Text = "Nuevo Perfil";
        Operacion.Value = "Nuevo";
        chckboxlist.DataSource = _catperfilneg.listmenus();
        chckboxlist.DataValueField = "idmenu";
        chckboxlist.DataTextField = "nommenu";
        chckboxlist.DataBind();
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalOperPerfil", "$('#ModalOperPerfil').modal();", true);
        upModalOperPerfil.Update();
    }



    protected void Eliminar_Click(object sender, EventArgs e)
    {

        _objperfil = new Perfiles();
        _objperfil.IdPerfil = Convert.ToInt32(ID.Value.ToString());
        _objperfil.NomPerfil = txtCambiarNombrePerfil.Text;
        _catperfilneg.eliminarPerfil(_objperfil);
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalEliminar", "$('#ModalEliminar').modal('hide');", true);
        upModalEliminar.Update();
        GridViewPerfiles.DataSource = _catperfilneg.list();
        GridViewPerfiles.DataBind();

    }
    protected void NombrePerfil_Click(object sender,EventArgs e)
    {
        if (txtCambiarNombrePerfil.Text == string.Empty)
        {
            lblMensajeEditar.Visible = true;
            upModalCambiarNombrePerfil.Update();

        }else
        {
            _objperfil = new Perfiles();
            _objperfil.IdPerfil = Convert.ToInt32(ID.Value.ToString());
            _objperfil.NomPerfil = txtCambiarNombrePerfil.Text;
            _catperfilneg.modificarPerfil(_objperfil);
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalCambiarNombrePerfil", "$('#ModalCambiarNombrePerfil').modal('hide');", true);
            upModalCambiarNombrePerfil.Update();
            GridViewPerfiles.DataSource = _catperfilneg.list();
            GridViewPerfiles.DataBind();
        }
       
    }
    protected void Edicion_Click(object sender, EventArgs e)
    {

    }

  
}