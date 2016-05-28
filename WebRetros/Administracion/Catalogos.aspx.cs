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
    protected void Page_Load(object sender, EventArgs e)
    {
        //Departamentos
        if(!Page.IsPostBack)
        {
            GridViewDepartamentos.DataSource = _catdepneg.list();
            GridViewDepartamentos.DataBind();
        }
      

    }
}