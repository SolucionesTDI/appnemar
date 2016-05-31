using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

public partial class Administracion_Usuarios : System.Web.UI.Page
{
    CatSedesNegocio _catsedesneg = new CatSedesNegocio();
    CatDepartamentosNegocio _catdeptoneg = new CatDepartamentosNegocio();
    CatPuestosNegocio _catpuestosneg = new CatPuestosNegocio();
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
            LoadComboSede();
            LoadComboDepartamento();
            LoadComboPuesto();
            txtNombreCompletoEmail.Attributes.Add("placeholder", "Nombre o Correo Electronico");
        }
    }
    public void LoadComboSede(int ID=0)
    {
        dropFiltroSedes.DataSource = _catsedesneg.list();
        dropFiltroSedes.DataValueField = "idsede";
        dropFiltroSedes.DataTextField = "descripcion";
        dropFiltroSedes.DataBind();
        dropFiltroSedes.Items.Insert(0, new ListItem("Todas Las Sedes", "0"));
        dropFiltroSedes.Items.FindByValue(ID.ToString()).Selected = true;
    }
    public void LoadComboDepartamento(int ID = 0)
    {
        dropFiltroDepartamento.DataSource = _catdeptoneg.list();
        dropFiltroDepartamento.DataValueField = "iddepto";
        dropFiltroDepartamento.DataTextField = "descripcion";
        dropFiltroDepartamento.DataBind();
        dropFiltroDepartamento.Items.Insert(0, new ListItem("Todos los Departamentos", "0"));
        dropFiltroDepartamento.Items.FindByValue(ID.ToString()).Selected = true;
    }
    public void LoadComboPuesto(int ID = 0)
    {
        dropFiltroPuesto.DataSource = _catpuestosneg.list();
        dropFiltroPuesto.DataValueField = "idpuesto";
        dropFiltroPuesto.DataTextField = "descripcion";
        dropFiltroPuesto.DataBind();
        dropFiltroPuesto.Items.Insert(0, new ListItem("Todos los Puestos", "0"));
        dropFiltroPuesto.Items.FindByValue(ID.ToString()).Selected = true;
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