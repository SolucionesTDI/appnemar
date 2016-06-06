using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocio;
public partial class Minutas_Historial : System.Web.UI.Page
{
    Catalogos cat;
    CatalogosBL cbl;
    Minutas min;
    MinutasBL mbl;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            LoadTemas();
        }
    }

    private string CadenaOptions(ListBox ltb )
    {
        string cadenaserv = string.Empty;
        foreach (ListItem item in ltb.Items)
        {
            if (item.Selected)
            {
                if (string.IsNullOrEmpty(cadenaserv))
                {
                    cadenaserv += "'"+ item.Value +"'";
                }
                else
                {
                    cadenaserv += "," + "'" + item.Value + "'";
                }
            }
        }

        return cadenaserv;
    }

    public void LoadTemas()
    {
        cbl = new CatalogosBL();
        cat = new Catalogos();
        cat.Tipo = "temaslist";
        ddltemas_b.DataSource = cbl.GetCatalogos(cat);
        ddltemas_b.DataValueField = "IdCat";
        ddltemas_b.DataTextField = "NomCat";
        ddltemas_b.DataBind();
        //ddltemas_b.Items.Insert(0,new ListItem("Todos los temas","0"));

    }

    protected void btnbuscarfiltros_Click(object sender, EventArgs e)
    {
        LoadGridMinutas();
    }

    private MinutasFiltros FiltroMinutas()
    {
        MinutasFiltros fil = new MinutasFiltros();
        fil.TemasCadena = CadenaOptions(ddltemas_b);
        return fil;
    }

    protected void LoadGridMinutas()
    {
        mbl = new MinutasBL();
        gdvMinutas.DataSource = mbl.GetMinutas(FiltroMinutas());
        gdvMinutas.DataBind();
    }

    protected void gdvMinutas_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void gdvMinutas_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void gdvMinutas_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    protected void pageMinutasDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}