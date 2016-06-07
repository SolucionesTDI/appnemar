using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidades;

public partial class Administracion_Usuarios : System.Web.UI.Page
{
    CatSedesNegocio _catsedesneg = new CatSedesNegocio();
    CatDepartamentosNegocio _catdeptoneg = new CatDepartamentosNegocio();
    CatPuestosNegocio _catpuestosneg = new CatPuestosNegocio();
    UsuariosBL _catusuariosneg = new UsuariosBL();
    PerfilesNegocio _catperfilneg = new PerfilesNegocio();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!ValidarSesion.sesionactiva())
            Response.Redirect("~/Default.aspx");

        if (!Page.IsPostBack)
        {
            txtUserName.Attributes.Add("placeholder", "Correo Electronico");
            txtUserPassword.Attributes.Add("placeholder", "Contraseña");
            txtUserPasswordConfirma.Attributes.Add("placeholder", "Confirmar Contraseña");
            txtUserName.Attributes.Add("placeholder", "Nombre");
            txtUserApellidoPaterno.Attributes.Add("placeholder", "Apellido Paterno");
            txtUserApellidoMaterno.Attributes.Add("placeholder", "Apellido Materno");
            txtUserPasswordCambio.Attributes.Add("placeholder", "Contraseña Nueva");
            txtUserPasswordCambioConfirma.Attributes.Add("placeholder", "Confirmar Contraseña");
            LoadComboSede("filtro");
            LoadComboDepartamento("filtro");
            LoadComboPuesto("filtro");
            LoadComboPerfil("filtro");
            txtNombreCompletoEmail.Attributes.Add("placeholder", "Nombre o Correo Electronico");
            GridViewUsuarios.DataSource = _catusuariosneg.list();
            GridViewUsuarios.DataBind();
        }
    }
    public void LoadComboSede(string oper=null,int ID=0)
    {
      
        if(oper == "filtro")
        {
            dropFiltroSedes.DataSource = _catsedesneg.list();
            dropFiltroSedes.DataValueField = "idsede";
            dropFiltroSedes.DataTextField = "descripcion";
            dropFiltroSedes.DataBind();
            dropFiltroSedes.Items.Insert(0, new ListItem("Todas Las Sedes", "0"));
            dropFiltroSedes.Items.FindByValue(ID.ToString()).Selected = true;
        }    
        else
        {
            dropUserSede.DataSource = _catsedesneg.list();
            dropUserSede.DataValueField = "idsede";
            dropUserSede.DataTextField = "descripcion";
            dropUserSede.DataBind();
        }   
    
    }
    public void LoadComboDepartamento(string oper = null, int ID = 0)
    {

        if (oper == "filtro")
        {
            dropFiltroDepartamento.DataSource = _catdeptoneg.list();
            dropFiltroDepartamento.DataValueField = "iddepto";
            dropFiltroDepartamento.DataTextField = "descripcion";
            dropFiltroDepartamento.DataBind();
            dropFiltroDepartamento.Items.Insert(0, new ListItem("Todos los Departamentos", "0"));
            dropFiltroDepartamento.Items.FindByValue(ID.ToString()).Selected = true;
        }
        else
        {
            dropUserDepartamento.DataSource = _catdeptoneg.list();
            dropUserDepartamento.DataValueField = "iddepto";
            dropUserDepartamento.DataTextField = "descripcion";
            dropUserDepartamento.DataBind();
        }
     
    }
    public void LoadComboPuesto(string oper = null, int ID = 0)
    {
       
        if (oper == "filtro")
        {
            dropFiltroPuesto.DataSource = _catpuestosneg.list();
            dropFiltroPuesto.DataValueField = "idpuesto";
            dropFiltroPuesto.DataTextField = "descripcion";
            dropFiltroPuesto.DataBind();
            dropFiltroPuesto.Items.Insert(0, new ListItem("Todos los Puestos", "0"));
            dropFiltroPuesto.Items.FindByValue(ID.ToString()).Selected = true;
        }
        else
        {
            dropUserPuesto.DataSource = _catpuestosneg.list();
            dropUserPuesto.DataValueField = "idpuesto";
            dropUserPuesto.DataTextField = "descripcion";
            dropUserPuesto.DataBind();
        }
     
    }
    public void LoadComboPerfil(string oper = null, int ID = 0)
    {

        if (oper == "filtro")
        {
            dropFiltroPerfil.DataSource = _catperfilneg.list();
            dropFiltroPerfil.DataValueField = "idperfil";
            dropFiltroPerfil.DataTextField = "nomperfil";
            dropFiltroPerfil.DataBind();
            dropFiltroPerfil.Items.Insert(0, new ListItem("Todos los Perfiles", "0"));
            dropFiltroPerfil.Items.FindByValue(ID.ToString()).Selected = true;
        }
        else
        {
            dropUserPerfil.DataSource = _catperfilneg.list();
            dropUserPerfil.DataValueField = "idperfil";
            dropUserPerfil.DataTextField = "nomperfil";    
            dropUserPerfil.DataBind();
        }
       
    }
    public void LoadComboJefe(string oper = null, int ID = 0)
    {

        if (oper == "filtro")
        {
           
        }
        else
        {
            dropUserJefe.DataSource = _catusuariosneg.list();
            dropUserJefe.DataValueField = "idUser";
            dropUserJefe.DataTextField = "NombreCompleto";
            dropUserJefe.DataBind();
            dropUserJefe.Items.Insert(0, new ListItem("No Aplica", "0"));
        }

    }

    protected void GridView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EliminarUsuario")
        {
            int fila = Convert.ToInt32(e.CommandArgument);
            ID.Value = this.GridViewUsuarios.DataKeys[fila].Value.ToString();
            lblModalTitleEliminar.Text = "Eliminar";
            Label labeltemp = GridViewUsuarios.Rows[fila].FindControl("username") as Label;
            string valor = labeltemp.Text;
            lblModalBodyEliminar.Text = "¿ Esta seguro que desea eliminar el Usuario : " + valor + " ?";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalEliminar", "$('#ModalEliminar').modal();", true);
            upModalEliminar.Update();
        }
        if (e.CommandName == "CambiarPassword")
        {
            int fila = Convert.ToInt32(e.CommandArgument);
            ID.Value = this.GridViewUsuarios.DataKeys[fila].Value.ToString();
            lblModalTitlePassword.Text = "Cambio de Contraseña";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalPassword", "$('#ModalPassword').modal();", true);
            upModalPassword.Update();
        }
        if (e.CommandName == "EditarUsuario")
        {

            LoadComboPerfil();
            LoadComboSede();
            LoadComboDepartamento();
            LoadComboPuesto();
            LoadComboJefe();
            int fila = Convert.ToInt32(e.CommandArgument);
            ID.Value = this.GridViewUsuarios.DataKeys[fila].Value.ToString();
            txtUserPassword.Visible = false;
            txtUserPasswordConfirma.Visible = false;
            lblpasswordtitle.Visible = false;
            lblMensajeUserPass.Visible = false;
            lblMensajeUserPassConfirma.Visible = false;
            HiddenField tempperfil = GridViewUsuarios.Rows[fila].FindControl("idperfil") as HiddenField;
            string valorperfil = tempperfil.Value;
            dropUserPerfil.Items.FindByValue(valorperfil.ToString()).Selected = true;
            HiddenField tempsede = GridViewUsuarios.Rows[fila].FindControl("idsede") as HiddenField;
            string valorsede = tempsede.Value;
            dropUserSede.Items.FindByValue(valorsede.ToString()).Selected = true;
            HiddenField tempdepto = GridViewUsuarios.Rows[fila].FindControl("iddepto") as HiddenField;
            string valordepto = tempdepto.Value;
            dropUserDepartamento.Items.FindByValue(valordepto.ToString()).Selected = true;
            HiddenField temppuesto = GridViewUsuarios.Rows[fila].FindControl("idpuesto") as HiddenField;
            string valorpuesto = temppuesto.Value;
            dropUserPuesto.Items.FindByValue(valorpuesto.ToString()).Selected = true;
            HiddenField tempjefe = GridViewUsuarios.Rows[fila].FindControl("idjefe") as HiddenField;
            string valorjefe = tempjefe.Value;
            HiddenField versesiones = GridViewUsuarios.Rows[fila].FindControl("hdversesiones") as HiddenField;
            dropUserJefe.Items.FindByValue(valorjefe.ToString()).Selected = true;

            //lblMensajeUserName.Visible = false;
            //lblMensajeUserNameCorreo.Visible = false;
            //lblMensajeUserPass.Visible = false;
            //lblMensajeUserPassConfirma.Visible = false;
            lblModalTitleNuevo.Text = "Editar Usuario";
            Operacion.Value = "Editar";
            txtUserName.Text = (GridViewUsuarios.Rows[fila].FindControl("username") as Label).Text;
            txtUserNombre.Text = (GridViewUsuarios.Rows[fila].FindControl("nombre") as HiddenField).Value.ToString();
            txtUserApellidoPaterno.Text = (GridViewUsuarios.Rows[fila].FindControl("ApellidoPat") as HiddenField).Value.ToString();
            txtUserApellidoMaterno.Text = (GridViewUsuarios.Rows[fila].FindControl("ApellidoMat") as HiddenField).Value.ToString();
            if (versesiones.Value=="1")
                chkversesiones.Checked = true;
            else
                chkversesiones.Checked = false;
            //LoadComboPerfil();
            //LoadComboSede();
            //LoadComboDepartamento();
            //LoadComboPuesto();
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalOperUsuario", "$('#ModalOperUsuario').modal();", true);
            upModalOperUsuario.Update();

        }



    }
    protected void BuscarUsuario_Click(object sender, EventArgs e)
    {
        GridViewUsuarios.DataSource = _catusuariosneg.list(Convert.ToInt32(dropFiltroSedes.SelectedValue.ToString()),Convert.ToInt32(dropFiltroDepartamento.SelectedValue.ToString()), Convert.ToInt32(dropFiltroPuesto.SelectedValue.ToString()), Convert.ToInt32(dropFiltroPerfil.SelectedValue.ToString()),0, txtNombreCompletoEmail.Text.ToString());
        GridViewUsuarios.DataBind();
    }
    protected void Nuevo_Click(object sender, EventArgs e)
    {
        
        lblMensajeUserName.Visible = false;
        lblMensajeUserNameCorreo.Visible = false;
        lblMensajeUserNombre.Visible = false;
        lblMensajeUserApellidoPaterno.Visible = false;
        lblMensajeUserApellidoMaterno.Visible = false;
        lblMensajeUserPass.Visible = false;
        lblMensajeUserPassConfirma.Visible = false;
        upModalOperUsuario.Update();
        if (txtUserName.Text != string.Empty)
        {
            if (txtUserNombre.Text != string.Empty)
            {
                if (txtUserApellidoPaterno.Text != string.Empty)
                {
                    //if(txtUserApellidoMaterno.Text != string.Empty)
                    //{
                        if ((txtUserPassword.Text != string.Empty & txtUserPasswordConfirma.Text != string.Empty) || Operacion.Value == "Editar")
                        {
                            if (txtUserPassword.Text == txtUserPasswordConfirma.Text || Operacion.Value == "Editar")
                            {
                                if(Operacion.Value == "Nuevo")
                                {
                                    UsuariosDatos catusuario = new UsuariosDatos();
                                    catusuario.User = new Usuarios();
                                    catusuario.User.IdUserGestion = Convert.ToInt32(Session["IdUser"]);
                                    catusuario.User.Username = txtUserName.Text;
                                    catusuario.User.Password = txtUserPassword.Text;
                                    catusuario.User.Perfil = new Perfiles();
                                    catusuario.User.Perfil.IdPerfil = Convert.ToInt32(dropUserPerfil.SelectedValue.ToString());
                                    catusuario.NombreUser = txtUserNombre.Text;
                                    catusuario.ApellidoPat = txtUserApellidoPaterno.Text;
                                    catusuario.ApellidoMat = txtUserApellidoMaterno.Text;
                                    catusuario.ObjSedes = new CatSedes();
                                    catusuario.ObjSedes.idsede = Convert.ToInt32(dropUserSede.SelectedValue.ToString());
                                    catusuario.ObjDepto = new CatDepartamentos();
                                    catusuario.ObjDepto.iddepto = Convert.ToInt32(dropUserDepartamento.SelectedValue.ToString());
                                    catusuario.ObjPuestos = new CatPuestos();
                                    catusuario.ObjPuestos.idpuesto = Convert.ToInt32(dropUserPuesto.SelectedValue.ToString());
                                    catusuario.IdJefe = Convert.ToInt32(dropUserJefe.SelectedValue.ToString());
                                    catusuario.User.Versesiones = (chkversesiones.Checked == true) ? true : false;
                                    _catusuariosneg.insertUsuario(catusuario);
                                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalOperUsuario", "$('#ModalOperUsuario').modal('hide');", true);
                                    upModalOperUsuario.Update();
                                    GridViewUsuarios.DataSource = _catusuariosneg.list();
                                    GridViewUsuarios.DataBind();
                                }
                                if(Operacion.Value == "Editar")
                                {
                                    UsuariosDatos catusuario = new UsuariosDatos();
                                    catusuario.User = new Usuarios();
                                    catusuario.User.IdUser = Convert.ToInt32(ID.Value);
                                    catusuario.User.Username = txtUserName.Text;
                                    catusuario.User.Perfil = new Perfiles();
                                    catusuario.User.Perfil.IdPerfil = Convert.ToInt32(dropUserPerfil.SelectedValue.ToString());
                                    catusuario.NombreUser = txtUserNombre.Text;
                                    catusuario.ApellidoPat = txtUserApellidoPaterno.Text;
                                    catusuario.ApellidoMat = txtUserApellidoMaterno.Text;
                                    catusuario.ObjSedes = new CatSedes();
                                    catusuario.ObjSedes.idsede = Convert.ToInt32(dropUserSede.SelectedValue.ToString());
                                    catusuario.ObjDepto = new CatDepartamentos();
                                    catusuario.ObjDepto.iddepto = Convert.ToInt32(dropUserDepartamento.SelectedValue.ToString());
                                    catusuario.ObjPuestos = new CatPuestos();
                                    catusuario.ObjPuestos.idpuesto = Convert.ToInt32(dropUserPuesto.SelectedValue.ToString());
                                    catusuario.IdJefe = Convert.ToInt32(dropUserJefe.SelectedValue.ToString());
                                    catusuario.User.Versesiones = (chkversesiones.Checked == true) ? true : false;
                                    _catusuariosneg.modificarUsuario(catusuario);
                                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalOperUsuario", "$('#ModalOperUsuario').modal('hide');", true);
                                    upModalOperUsuario.Update();
                                    GridViewUsuarios.DataSource = _catusuariosneg.list();
                                    GridViewUsuarios.DataBind();
                                }
                               
                            }
                            else
                            {
                                lblMensajeUserPassConfirma.Visible = true;
                            }

                        }
                        else
                        {
                            lblMensajeUserPass.Visible = true;
                        }

                    //}
                   //else
                   // {
                   //     lblMensajeUserApellidoMaterno.Visible = true;
                   // }
                
                }
                else
                {
                    lblMensajeUserApellidoPaterno.Visible = true;
                }
            }
            else
            {
                lblMensajeUserNombre.Visible = true;
            }

        }
        else
        {
            lblMensajeUserName.Visible = true;
        }
   }
    protected void NuevoUsuario_Click(object sender, EventArgs e)
    {
        txtUserPassword.Visible = true;
        txtUserPasswordConfirma.Visible = true;
        lblpasswordtitle.Visible = true;
        lblMensajeUserName.Visible = false;
        lblMensajeUserNameCorreo.Visible = false;
        lblMensajeUserPass.Visible = false;
        lblMensajeUserPassConfirma.Visible = false;
        lblModalTitleNuevo.Text = "Nuevo Usuario";
        Operacion.Value = "Nuevo";
        txtUserName.Text = string.Empty;
        txtUserNombre.Text = string.Empty;
        txtUserPassword.Text = string.Empty;
        txtUserPasswordConfirma.Text = string.Empty;
        txtUserNombre.Text = string.Empty;
        txtUserApellidoPaterno.Text = string.Empty;
        txtUserApellidoMaterno.Text = string.Empty;
        LoadComboPerfil();
        LoadComboSede();
        LoadComboDepartamento();
        LoadComboPuesto();
        LoadComboJefe();
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalOperUsuario", "$('#ModalOperUsuario').modal();", true);
        upModalOperUsuario.Update();
    }



    protected void Eliminar_Click(object sender, EventArgs e)
    {
        UsuariosDatos _catusuario = new UsuariosDatos();
        _catusuario.User = new Usuarios();
        _catusuario.User.IdUser = Convert.ToInt32(ID.Value.ToString());
        _catusuariosneg.eliminarUsuario(_catusuario);
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalEliminar", "$('#ModalEliminar').modal('hide');", true);
        upModalEliminar.Update();
        GridViewUsuarios.DataSource = _catusuariosneg.list();
        GridViewUsuarios.DataBind();

    }
    protected void Edicion_Click(object sender, EventArgs e)
    {

    }

    protected void Password_Click(object sender, EventArgs e)
    {
        if (txtUserPasswordCambio.Text != string.Empty & txtUserPasswordCambioConfirma.Text != string.Empty)
        {
            lblUserPasswordCambio.Visible = false;
            lblUserPasswordCambioConfirma.Visible = false;
            upModalPassword.Update();
            if (txtUserPasswordCambio.Text == txtUserPasswordCambioConfirma.Text)
            {
                UsuariosDatos _catusuario = new UsuariosDatos();
                _catusuario.User = new Usuarios();
                _catusuario.User.IdUser = Convert.ToInt32(ID.Value.ToString());
                _catusuario.User.Password = txtUserPasswordCambio.Text;
                _catusuariosneg.cambiarPassword(_catusuario);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalPassword", "$('#ModalPassword').modal('hide');", true);
                upModalPassword.Update();
            }
            else
            {
                lblUserPasswordCambioConfirma.Visible = true;
            }
        }else
        {
            lblUserPasswordCambio.Visible = true;
        }

    }

    

}