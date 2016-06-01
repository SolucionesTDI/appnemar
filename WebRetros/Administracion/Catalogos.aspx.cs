using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidades;

public partial class Administracion_Catalogos : System.Web.UI.Page
{
    CatDepartamentosNegocio _catdepneg = new CatDepartamentosNegocio();
    CatPuestosNegocio _catpuesneg = new CatPuestosNegocio();
    CatSatusNegocio _catstatneg = new CatSatusNegocio();
    CatSedesNegocio _catsedneg = new CatSedesNegocio();
    CatTemasNegocio _cattemneg = new CatTemasNegocio();

    CatDepartamentos _catdepartamento;
    CatPuestos _catpuesto;
    CatSedes _catsede;
    CatStatus _catstatus;
    CatTemas _cattema;
    protected void Page_Load(object sender, EventArgs e)
    {
        //Departamentos
        if(!Page.IsPostBack)
        {
            GridViewDepartamentos.DataSource = _catdepneg.list();
            GridViewDepartamentos.DataBind();

            GridViewPuestos.DataSource = _catpuesneg.list();
            GridViewPuestos.DataBind();


            GridViewSedes.DataSource = _catsedneg.list();
            GridViewSedes.DataBind();

            GridViewTemas.DataSource = _cattemneg.list();
            GridViewTemas.DataBind();

            txtDescripcionNuevo.Attributes.Add("placeholder", "Nombre");
            txtDescripcionEditar.Attributes.Add("placeholder", "Nombre");

        }
     }
    protected void GridView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if(e.CommandName == "EditarDepartamento")
        {
            lblMensajeEditar.Visible = false;
            int fila = Convert.ToInt32(e.CommandArgument);
            lblModalTitleEditar.Text = "Editar Departamento";
            txtDescripcionEditar.Text = this.GridViewDepartamentos.Rows[fila].Cells[0].Text;
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalEditar", "$('#ModalEditar').modal();", true);
            upModalEditar.Update();
            ID.Value = this.GridViewDepartamentos.DataKeys[fila].Value.ToString();
            Catalogo.Value = "Departamentos";
        }
        if (e.CommandName == "EliminarDepartamento")
        {
            int fila = Convert.ToInt32(e.CommandArgument);
            ID.Value = this.GridViewDepartamentos.DataKeys[fila].Value.ToString();
            Catalogo.Value = "Departamentos";
            lblModalTitleEliminar.Text = "Eliminar";
            lblModalBodyEliminar.Text = "¿ Esta seguro que desea eliminar el Registro : " + this.GridViewDepartamentos.Rows[fila].Cells[0].Text + " ?";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalEliminar", "$('#ModalEliminar').modal();", true);
            upModalEliminar.Update();
        }
        if (e.CommandName == "EditarPuesto")
        {
            lblMensajeEditar.Visible = false;
            int fila = Convert.ToInt32(e.CommandArgument);
            lblModalTitleEditar.Text = "Editar Puesto";
            txtDescripcionEditar.Text = this.GridViewPuestos.Rows[fila].Cells[0].Text;
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalEditar", "$('#ModalEditar').modal();", true);
            upModalEditar.Update();
            ID.Value = this.GridViewPuestos.DataKeys[fila].Value.ToString();
            Catalogo.Value = "Puestos";
        }
        if (e.CommandName == "EliminarPuesto")
        {
            int fila = Convert.ToInt32(e.CommandArgument);
            ID.Value = this.GridViewPuestos.DataKeys[fila].Value.ToString();
            Catalogo.Value = "Puestos";
            lblModalTitleEliminar.Text = "Eliminar";
            lblModalBodyEliminar.Text = "¿ Esta seguro que desea eliminar el Registro : " + this.GridViewPuestos.Rows[fila].Cells[0].Text + " ?";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalEliminar", "$('#ModalEliminar').modal();", true);
            upModalEliminar.Update();
        }
        if (e.CommandName == "EditarSede")
        {
            lblMensajeEditar.Visible = false;
            int fila = Convert.ToInt32(e.CommandArgument);     
            lblModalTitleEditar.Text = "Editar Sede";
            txtDescripcionEditar.Text = this.GridViewSedes.Rows[fila].Cells[0].Text;
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalEditar", "$('#ModalEditar').modal();", true);
            upModalEditar.Update();
            ID.Value = this.GridViewSedes.DataKeys[fila].Value.ToString();
            Catalogo.Value = "Sedes";
        }
        if (e.CommandName == "EliminarSede")
        {
            int fila = Convert.ToInt32(e.CommandArgument);
            ID.Value = this.GridViewSedes.DataKeys[fila].Value.ToString();
            Catalogo.Value = "Sedes";
            lblModalTitleEliminar.Text = "Eliminar Sede";
            lblModalBodyEliminar.Text = "¿ Esta seguro que desea eliminar el Registro : " + this.GridViewSedes.Rows[fila].Cells[0].Text + " ?";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalEliminar", "$('#ModalEliminar').modal();", true);
            upModalEliminar.Update();
        }
     
        if (e.CommandName == "EditarTema")
        {
            lblMensajeEditar.Visible = false;
            int fila = Convert.ToInt32(e.CommandArgument);
            lblModalTitleEditar.Text = "Editar Tema";
            txtDescripcionEditar.Text = this.GridViewTemas.Rows[fila].Cells[0].Text;
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalEditar", "$('#ModalEditar').modal();", true);
            upModalEditar.Update();
            ID.Value = this.GridViewTemas.DataKeys[fila].Value.ToString();
            Catalogo.Value = "Sedes";
        }
        if (e.CommandName == "EliminarTema")
        {
            int fila = Convert.ToInt32(e.CommandArgument);
            ID.Value = this.GridViewTemas.DataKeys[fila].Value.ToString();
            Catalogo.Value = "Temas";
            lblModalTitleEliminar.Text = "Eliminar";
            lblModalBodyEliminar.Text = "¿ Esta seguro que desea eliminar el Registro : " + this.GridViewTemas.Rows[fila].Cells[0].Text + " ?";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalEliminar", "$('#ModalEliminar').modal();", true);
            upModalEliminar.Update();
        }
    }

    protected void Nuevo_Click(object sender, EventArgs e)
    {
        if (txtDescripcionNuevo.Text == String.Empty)
        {
            lblMensajeNuevo.Visible = true;
            upModalNuevo.Update();
        }
        else
        {
            if (Catalogo.Value == "Departamentos")
            {
                _catdepartamento = new CatDepartamentos();
                _catdepartamento.descripcion = txtDescripcionNuevo.Text;
                _catdepneg.insertarDepartamento(_catdepartamento);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalNuevo", "$('#ModalNuevo').modal('hide');", true);
                upModalNuevo.Update();
                GridViewDepartamentos.DataSource = _catdepneg.list();
                GridViewDepartamentos.DataBind();

            }
            if (Catalogo.Value == "Sedes")
            {
                _catsede = new CatSedes();
                _catsede.descripcion = txtDescripcionNuevo.Text;
                _catsedneg.insertarSede(_catsede);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalNuevo", "$('#ModalNuevo').modal('hide');", true);
                upModalNuevo.Update();
                GridViewSedes.DataSource = _catsedneg.list();
                GridViewSedes.DataBind();
            }
            if (Catalogo.Value == "Puestos")
            {
                _catpuesto = new CatPuestos();
                _catpuesto.descripcion = txtDescripcionNuevo.Text;
                _catpuesneg.insertarPuesto(_catpuesto);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalNuevo", "$('#ModalNuevo').modal('hide');", true);
                upModalNuevo.Update();
                GridViewPuestos.DataSource = _catpuesneg.list();
                GridViewPuestos.DataBind();
            }
            if (Catalogo.Value == "Temas")
            {
                _cattema = new CatTemas();
                _cattema.descripcion = txtDescripcionNuevo.Text;
                _cattemneg.insertarTema(_cattema);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalNuevo", "$('#ModalNuevo').modal('hide');", true);
                upModalNuevo.Update();
                GridViewTemas.DataSource = _cattemneg.list();
                GridViewTemas.DataBind();
            }
        }
    }
    protected void BuscarSede_Click(object sender, EventArgs e)
    {
            GridViewSedes.DataSource = _catsedneg.list(txtBuscarSede.Text);
            GridViewSedes.DataBind();
    }
    protected void BuscarDepartamento_Click(object sender, EventArgs e)
    {
        GridViewDepartamentos.DataSource = _catdepneg.list(txtBuscarDepartamento.Text);
        GridViewDepartamentos.DataBind();
    }
    protected void BuscarTema_Click(object sender, EventArgs e)
    {
        GridViewTemas.DataSource = _cattemneg.list(txtBuscarTema.Text);
        GridViewTemas.DataBind();
    }
    protected void BuscarPuesto_Click(object sender, EventArgs e)
    {
        GridViewPuestos.DataSource = _catpuesneg.list(txtBuscarPuesto.Text);
        GridViewPuestos.DataBind();
    }
    protected void NuevaSede_Click(object sender, EventArgs e)
    {
        lblMensajeNuevo.Visible = false;
        lblModalTitleNuevo.Text = "Nueva Sede";
        txtDescripcionNuevo.Text = string.Empty;
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalNuevo", "$('#ModalNuevo').modal();", true);
        upModalNuevo.Update();
        Catalogo.Value = "Sedes";
    }
    protected void NuevoDepartamento_Click(object sender, EventArgs e)
    {
        lblMensajeNuevo.Visible = false;
        lblModalTitleNuevo.Text = "Nuevo Departamento";
        txtDescripcionNuevo.Text = string.Empty;
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalNuevo", "$('#ModalNuevo').modal();", true);
        upModalNuevo.Update();
        Catalogo.Value = "Departamentos";
    }
    protected void NuevoPuesto_Click(object sender, EventArgs e)
    {
        lblMensajeNuevo.Visible = false;
        lblModalTitleNuevo.Text = "Nuevo Puesto";
        txtDescripcionNuevo.Text = string.Empty;
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalNuevo", "$('#ModalNuevo').modal();", true);
        upModalNuevo.Update();
        Catalogo.Value = "Puestos";
    }
    protected void NuevoTema_Click(object sender, EventArgs e)
    {
        lblMensajeNuevo.Visible = false;
        lblModalTitleNuevo.Text = "Nuevo Tema";
        txtDescripcionNuevo.Text = string.Empty;
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalNuevo", "$('#ModalNuevo').modal();", true);
        upModalNuevo.Update();
        Catalogo.Value = "Temas";
    }
    protected void Eliminar_Click(object sender,EventArgs e)
    {
        if(Catalogo.Value == "Departamentos")
        {
               _catdepartamento = new CatDepartamentos();
               _catdepartamento.iddepto = Convert.ToInt32(ID.Value.ToString());
               _catdepneg.eliminarDepartamento(_catdepartamento);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalEliminar", "$('#ModalEliminar').modal('hide');", true);
                upModalEliminar.Update();
                GridViewDepartamentos.DataSource = _catdepneg.list();
                GridViewDepartamentos.DataBind();
        }
        if (Catalogo.Value == "Sedes")
        {
            _catsede = new CatSedes();
            _catsede.idsede = Convert.ToInt32(ID.Value.ToString());
            _catsedneg.eliminarSede(_catsede);
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalEliminar", "$('#ModalEliminar').modal('hide');", true);
            upModalEliminar.Update();
            GridViewSedes.DataSource = _catsedneg.list();
            GridViewSedes.DataBind();
        }
        if (Catalogo.Value == "Puestos")
        {
            _catpuesto = new CatPuestos();
            _catpuesto.idpuesto = Convert.ToInt32(ID.Value.ToString());
            _catpuesneg.eliminarPuesto(_catpuesto);
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalEliminar", "$('#ModalEliminar').modal('hide');", true);
            upModalEliminar.Update();
            GridViewPuestos.DataSource = _catpuesneg.list();
            GridViewPuestos.DataBind();
        }
        if (Catalogo.Value == "Temas")
        {
            _cattema = new CatTemas();
            _cattema.idtema = Convert.ToInt32(ID.Value.ToString());
            _cattemneg.eliminarTema(_cattema);
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalEliminar", "$('#ModalEliminar').modal('hide');", true);
            upModalEliminar.Update();
            GridViewTemas.DataSource = _cattemneg.list();
            GridViewTemas.DataBind();
        }
    }
    protected void Editar_Click(object sender, EventArgs e)
    {
        if (txtDescripcionEditar.Text == String.Empty)
        {
            lblMensajeEditar.Visible = true;
            upModalEditar.Update();
        }
        else
        {
            if (Catalogo.Value == "Departamentos")
            {
                _catdepartamento = new CatDepartamentos();
                _catdepartamento.iddepto = Convert.ToInt32(ID.Value.ToString());
                _catdepartamento.descripcion = txtDescripcionEditar.Text;
                _catdepneg.modificarDepartamento(_catdepartamento);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalEditar", "$('#ModalEditar').modal('hide');", true);
                upModalEditar.Update();
                GridViewDepartamentos.DataSource = _catdepneg.list();
                GridViewDepartamentos.DataBind();
            }
            if (Catalogo.Value == "Sedes")
            {
                _catsede = new CatSedes();
                _catsede.idsede = Convert.ToInt32(ID.Value.ToString());
                _catsede.descripcion = txtDescripcionEditar.Text;
                _catsedneg.modificarSede(_catsede);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalEditar", "$('#ModalEditar').modal('hide');", true);
                upModalEditar.Update();
                GridViewSedes.DataSource = _catsedneg.list();
                GridViewSedes.DataBind();
            }
            if (Catalogo.Value == "Puestos")
            {
                _catpuesto = new CatPuestos();
                _catpuesto.idpuesto = Convert.ToInt32(ID.Value.ToString());
                _catpuesto.descripcion = txtDescripcionEditar.Text;
                _catpuesneg.modificarPuesto(_catpuesto);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalEditar", "$('#ModalEditar').modal('hide');", true);
                upModalEditar.Update();
                GridViewPuestos.DataSource = _catpuesneg.list();
                GridViewPuestos.DataBind();
            }
            if (Catalogo.Value == "Temas")
            {
                _cattema = new CatTemas();
                _cattema.idtema = Convert.ToInt32(ID.Value.ToString());
                _cattema.descripcion = txtDescripcionEditar.Text;
                _cattemneg.modificarTema(_cattema);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalEditar", "$('#ModalEditar').modal('hide');", true);
                upModalEditar.Update();
                GridViewTemas.DataSource = _cattemneg.list();
                GridViewTemas.DataBind();
            }
        }
    }
}