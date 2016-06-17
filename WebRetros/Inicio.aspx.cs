using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocio;

public partial class Inicio : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        MenusBL bl = new MenusBL();
        UsuariosBL userbl = new UsuariosBL();
        IndicadoresNegocio _indicadoresneg = new IndicadoresNegocio();
        if (!IsPostBack)
        {

            List<UsuariosDatos> _lstusuariodatos = new List<UsuariosDatos>();
            _lstusuariodatos = userbl.list(0, 0, 0, 0, (int)Session["IdUser"]);
            if (_lstusuariodatos.Count == 0)
            {
                nombrecompleto.Text = "Soporte";
                lblSede.Text = "No Aplica";
                lblDepartamento.Text = "No Aplica";
                lblPuesto.Text = "No Aplica";
            }
            else
            {
                nombrecompleto.Text = _lstusuariodatos[0].NombreCompleto;
                lblSede.Text = _lstusuariodatos[0].ObjSedes.descripcion;
                lblDepartamento.Text = _lstusuariodatos[0].ObjDepto.descripcion;
                lblPuesto.Text = _lstusuariodatos[0].ObjPuestos.descripcion;

            }

            RepeaterIndicadores.DataSource = _indicadoresneg.obtenerIndicadorAcuerdosStatusUsuario((int)Session["IdUser"]);
            RepeaterIndicadores.DataBind();
            RepeaterSesionesCreadas.DataSource = _indicadoresneg.obtenerIndicadorSesionesStatusUsuario((int)Session["IdUser"],"Creada");
            RepeaterSesionesCreadas.DataBind();
            RepeaterSesionesAsignadas.DataSource = _indicadoresneg.obtenerIndicadorSesionesStatusUsuario((int)Session["IdUser"], "Asignada");
            RepeaterSesionesAsignadas.DataBind();

        }


    }
}