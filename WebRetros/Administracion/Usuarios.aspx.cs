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
        if (!Page.IsPostBack)
        {
            txtUserName.Attributes.Add("placeholder", "Correo Electronico");
            txtUserPassword.Attributes.Add("placeholder", "Contraseña");
            txtUserPasswordConfirma.Attributes.Add("placeholder", "Confirmar Contraseña");
            txtUserName.Attributes.Add("placeholder", "Nombre");
            txtUserApellidoPaterno.Attributes.Add("placeholder", "Apellido Paterno");
            txtUserApellidoMaterno.Attributes.Add("placeholder", "Apellido Materno");
            LoadComboSede("filtro");
            LoadComboDepartamento("filtro");
            LoadComboPuesto("filtro");
            txtNombreCompletoEmail.Attributes.Add("placeholder", "Nombre o Correo Electronico");
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
        }    
        else
        {
            dropUserSede.DataSource = _catsedesneg.list();
            dropUserSede.DataValueField = "idsede";
            dropUserSede.DataTextField = "descripcion";
            dropUserSede.DataBind();
        }   
        dropFiltroSedes.Items.FindByValue(ID.ToString()).Selected = true;
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
        }
        else
        {
            dropUserDepartamento.DataSource = _catdeptoneg.list();
            dropUserDepartamento.DataValueField = "iddepto";
            dropUserDepartamento.DataTextField = "descripcion";
            dropUserDepartamento.DataBind();
        }
        dropFiltroDepartamento.Items.FindByValue(ID.ToString()).Selected = true;
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
        }
        else
        {
            dropUserPuesto.DataSource = _catpuestosneg.list();
            dropUserPuesto.DataValueField = "idpuesto";
            dropUserPuesto.DataTextField = "descripcion";
            dropUserPuesto.DataBind();
        }
        dropFiltroPuesto.Items.FindByValue(ID.ToString()).Selected = true;
    }
    public void LoadComboPerfil(string oper = null, int ID = 0)
    {

        if (oper == "filtro")
        {
            dropFiltroPuesto.DataSource = _catpuestosneg.list();
            dropFiltroPuesto.DataValueField = "idpuesto";
            dropFiltroPuesto.DataTextField = "descripcion";
            dropFiltroPuesto.DataBind();
            dropFiltroPuesto.Items.Insert(0, new ListItem("Todos los Puestos", "0"));
        }
        else
        {
            dropUserPerfil.DataSource = _catperfilneg.list();
            dropUserPerfil.DataValueField = "idperfil";
            dropUserPerfil.DataTextField = "nomperfil";
            dropUserPerfil.DataBind();
        }
      //  dropUserPerfil.Items.FindByValue(ID.ToString()).Selected = true;
    }
    protected void GridView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EliminarUsuario")
        {
            int fila = Convert.ToInt32(e.CommandArgument);
            ID.Value = this.GridViewUsuarios.DataKeys[fila].Value.ToString();
            lblModalTitleEliminar.Text = "Eliminar";
            lblModalBodyEliminar.Text = "¿ Esta seguro que desea eliminar el Usuario : " + this.GridViewUsuarios.Rows[fila].Cells[0].Text + " ?";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalEliminar", "$('#ModalEliminar').modal();", true);
            upModalEliminar.Update();
        }
    }
    protected void BuscarUsuario_Click(object sender, EventArgs e)
    {
    }
    protected void Nuevo_Click(object sender, EventArgs e)
    {
        UsuariosDatos catusuario = new UsuariosDatos();
        catusuario.User = new Usuarios();
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
        _catusuariosneg.insertUsuario(catusuario);
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalOperUsuario", "$('#ModalOperUsuario').modal('hide');", true);
        upModalOperUsuario.Update();
    }
    protected void NuevoUsuario_Click(object sender, EventArgs e)
    {
        lblMensajeUserName.Visible = false;
        lblMensajeUserNameCorreo.Visible = false;
        lblMensajeUserPass.Visible = false;
        lblMensajeUserPassConfirma.Visible = false;
        lblModalTitleNuevo.Text = "Nuevo Usuario";
        Operacion.Value = "Nuevo";
        txtUserName.Text = string.Empty;
        txtUserPassword.Text = string.Empty;
        txtUserPasswordConfirma.Text = string.Empty;
        LoadComboPerfil();
        LoadComboSede();
        LoadComboDepartamento();
        LoadComboPuesto();
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalOperUsuario", "$('#ModalOperUsuario').modal();", true);
        upModalOperUsuario.Update();
    }

    protected void Editar_Click(object sender, EventArgs e)
    {
        lblMensajeUserName.Visible = false;
        lblMensajeUserNameCorreo.Visible = false;
        lblModalTitleNuevo.Text = "Editar Usuario";
        txtUserName.Text = string.Empty;
        txtUserPassword.Text = string.Empty;
        txtUserPasswordConfirma.Text = string.Empty;
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalEditar", "$('#ModalEditar').modal();", true);
        //upModalEditar.Update();
    }

    protected void Eliminar_Click(object sender, EventArgs e)
    {
        
    }

    protected void CambiarPassword_Click(object sender, EventArgs e)
    {
    }

}