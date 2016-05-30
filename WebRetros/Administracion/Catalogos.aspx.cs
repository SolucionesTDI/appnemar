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

            GridViewStatus.DataSource = _catstatneg.list();
            GridViewStatus.DataBind();

            GridViewSedes.DataSource = _catsedneg.list();
            GridViewSedes.DataBind();

            GridViewTemas.DataSource = _cattemneg.list();
            GridViewTemas.DataBind();
        }
     }
    protected void GridView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if(e.CommandName == "EditarDepartamento")
        {
            int fila = Convert.ToInt32(e.CommandArgument);
            IdDepartamentos.Value = this.GridViewDepartamentos.DataKeys[fila].Value.ToString();
        }
        if (e.CommandName == "EliminarDepartamento")
        {
            int fila = Convert.ToInt32(e.CommandArgument);
            IdDepartamentos.Value = this.GridViewDepartamentos.DataKeys[fila].Value.ToString();
        }
        if (e.CommandName == "EditarPuesto")
        {
            int fila = Convert.ToInt32(e.CommandArgument);
            IdPuestos.Value = this.GridViewPuestos.DataKeys[fila].Value.ToString();
        }
        if (e.CommandName == "EliminarPuesto")
        {
            int fila = Convert.ToInt32(e.CommandArgument);
            IdPuestos.Value = this.GridViewPuestos.DataKeys[fila].Value.ToString();
        }
        if (e.CommandName == "EditarSede")
        {
            int fila = Convert.ToInt32(e.CommandArgument);
            IdSede.Value = this.GridViewSedes.DataKeys[fila].Value.ToString();
        }
        if (e.CommandName == "EliminarSede")
        {
            int fila = Convert.ToInt32(e.CommandArgument);
            IdSede.Value = this.GridViewSedes.DataKeys[fila].Value.ToString();
        }
        if (e.CommandName == "EditarStatus")
        {
            int fila = Convert.ToInt32(e.CommandArgument);
            IdStatus.Value= this.GridViewStatus.DataKeys[fila].Value.ToString();
        }
        if (e.CommandName == "EliminarStatus")
        {
            int fila = Convert.ToInt32(e.CommandArgument);
            IdStatus.Value = this.GridViewStatus.DataKeys[fila].Value.ToString();
        }
        if (e.CommandName == "EditarTema")
        {
            int fila = Convert.ToInt32(e.CommandArgument);
            IdTemas.Value = this.GridViewTemas.DataKeys[fila].Value.ToString();
        }
        if (e.CommandName == "EliminarTema")
        {
            int fila = Convert.ToInt32(e.CommandArgument);
            IdTemas.Value = this.GridViewTemas.DataKeys[fila].Value.ToString();
        }
    }
    protected void btnGuardarDepartamento_Click(object sender, EventArgs e)
    {
        if(IdDepartamentos.Value!= null)
        {
            _catdepartamento = new CatDepartamentos();
            _catdepartamento.iddepto = Convert.ToInt32(IdDepartamentos.Value.ToString());
            _catdepartamento.descripcion = txtDepartamento.Text;
            _catdepneg.eliminarDepartamento(_catdepartamento);
        }
        else
        {
            _catdepartamento = new CatDepartamentos();
            _catdepartamento.descripcion = txtDepartamento.Text;
            _catdepneg.insertarDepartamento(_catdepartamento);
        }
    }
    protected void btnGuardarPuesto_Click(object sender, EventArgs e)
    {
        if (IdPuestos.Value != null)
        {
            _catpuesto = new CatPuestos();
            _catpuesto.idpuesto = Convert.ToInt32(IdPuestos.Value.ToString());
            _catpuesto.descripcion = txtPuesto.Text;
            _catpuesneg.modificarPuesto(_catpuesto);
        }
        else
        {
            _catpuesto = new CatPuestos();
            _catpuesto.descripcion = txtPuesto.Text;
            _catpuesneg.insertarPuesto(_catpuesto);
        }
    }
    protected void btnGuardarSede_Click(object sender, EventArgs e)
    {
        if (IdSede.Value != null)
        {
            _catsede = new CatSedes();
            _catsede.idsede = Convert.ToInt32(IdSede.Value.ToString());
            _catsede.descripcion = txtSede.Text;
            _catsedneg.eliminarSede(_catsede);
        }
        else
        {
            _catsede = new CatSedes();
            _catsede.descripcion = txtSede.Text;
            _catsedneg.insertarSede(_catsede);
        }
    }
    protected void btnGuardarStatus_Click(object sender, EventArgs e)
    {
        if (IdStatus.Value != null)
        {
            _catstatus = new CatStatus();
            _catstatus.idstatus = Convert.ToInt32(IdStatus.Value.ToString());
            _catstatus.nomstatus = txtNomStatus.Text;
            _catstatneg.eliminarStatu(_catstatus);
        }
        else
        {
            _catstatus = new CatStatus();
            _catstatus.nomstatus = txtNomStatus.Text;
            _catstatus.orden = Convert.ToInt32(txtOrden.Text);
            _catstatneg.insertarStatu(_catstatus);

        }

    }
    protected void btnGuardarTema_Click(object sender, EventArgs e)
    {
        if (IdTemas.Value != null)
        {
            _cattema = new CatTemas();
            _cattema.idtema = Convert.ToInt32(IdTemas.Value.ToString());
            _cattema.descripcion = txtTema.Text;
            _cattemneg.eliminarTema(_cattema);
        }
        else
        {
            _cattema = new CatTemas();
            _cattema.descripcion = txtTema.Text;
            _cattemneg.insertarTema(_cattema);
        }
    }
}