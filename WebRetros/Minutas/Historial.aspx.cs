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
    int npageMinuta = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!ValidarSesion.sesionactiva())
            Response.Redirect("~/Default.aspx");

        if(!IsPostBack)
        {
            txtfechai_b.Text = DateTime.Now.AddDays(-7).ToShortDateString();
            txtfechaf_b.Text = DateTime.Now.ToShortDateString();
            LoadTemas();
            LoadCoaching();
            LoadStatus();
            LoadTipoSesion();

            LoadGridMinutas();
        }
    }

    private void LimpiarFiltros()
    {
        ddlcoaching_b.ClearSelection();
        ddlstatus_b.ClearSelection();
        ddltemas_b.ClearSelection();
        ddltipoentrega_b.ClearSelection();
        ddltiposesion_b.ClearSelection();
        
        txtfechai_b.Text = DateTime.Now.AddDays(-7).ToShortDateString();
        txtfechaf_b.Text = DateTime.Now.ToShortDateString();
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
    public void LoadTipoSesion()
    {
        cbl = new CatalogosBL();
        cat = new Catalogos();
        cat.Tipo = "tiposesion";
        ddltiposesion_b.DataSource = cbl.GetCatalogos(cat);
        ddltiposesion_b.DataValueField = "IdCat";
        ddltiposesion_b.DataTextField = "NomCat";
        ddltiposesion_b.DataBind();
        //ddltemas_b.Items.Insert(0,new ListItem("Todos los temas","0"));

    }

    public void LoadStatus()
    {
        cbl = new CatalogosBL();
        cat = new Catalogos();
        cat.Tipo = "tipostatus";
        ddlstatus_b.DataSource = cbl.GetCatalogos(cat);
        ddlstatus_b.DataValueField = "IdCat";
        ddlstatus_b.DataTextField = "NomCat";
        ddlstatus_b.DataBind();
        //ddltemas_b.Items.Insert(0,new ListItem("Todos los temas","0"));

    }
    public void LoadCoaching()
    {
        cbl = new CatalogosBL();
        cat = new Catalogos();
        cat.Tipo = "coaching";
        ddlcoaching_b.DataSource = cbl.GetCatalogos(cat);
        ddlcoaching_b.DataValueField = "IdCat";
        ddlcoaching_b.DataTextField = "NomCat";
        ddlcoaching_b.DataBind();
        if(Convert.ToInt32(Session["IdUser"].ToString())==1)
        {
            ddlcoaching_b.Items.Insert(0, new ListItem("Usuario no visible", Session["IdUser"].ToString()));
        }
        //ddltemas_b.Items.Insert(0,new ListItem("Todos los temas","0"));

    }

    protected void btnbuscarfiltros_Click(object sender, EventArgs e)
    {
        LoadGridMinutas();
        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "$('#modalfiltros').modal('hide')", true);
    }

    private MinutasFiltros FiltroMinutas()
    {
        MinutasFiltros fil = new MinutasFiltros();
        fil.TemasCadena = CadenaOptions(ddltemas_b);
        if (string.IsNullOrEmpty(txtfechai_b.Text) || string.IsNullOrEmpty(txtfechaf_b.Text))
        {
            fil.FechaIni = null;
            fil.FechaFin = null;
        }
        else
        {
            fil.FechaIni = Convert.ToDateTime(txtfechai_b.Text);
            fil.FechaFin = Convert.ToDateTime(txtfechaf_b.Text);
        }
        fil.UsuariosCadena = CadenaOptions(ddlcoaching_b);
        fil.TipoSesionCadena = CadenaOptions(ddltiposesion_b);
        fil.StatusCadena = CadenaOptions(ddlstatus_b);
        fil.TiempoEntregaCadena = CadenaOptions(ddltipoentrega_b);
        fil.IdUser = Convert.ToInt32(Session["IdUser"]);
        fil.Origen = CadenaOptions(ddlorigen);
        return fil;
    }

    protected void LoadGridMinutas()
    {
        mbl = new MinutasBL();
        gdvMinutas.DataSource = mbl.GetMinutas(FiltroMinutas());
        gdvMinutas.PageIndex = npageMinuta;
        gdvMinutas.DataBind();
    }

    protected void gdvMinutas_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        if (e.NewPageIndex >= 0)
        {
            gdvMinutas.PageIndex = e.NewPageIndex;
            gdvMinutas.EditIndex = -1;
            npageMinuta = gdvMinutas.PageIndex;
            LoadGridMinutas();
        }
    }
    protected void gdvMinutas_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Pager && (gdvMinutas.DataSource != null))
        {
            //TRAE EL TOTAL DE PAGINAS

            Label _TotalPags = (e.Row.FindControl("lblTotalNumberOfPagesMinutas") as Label);
            _TotalPags.Text = gdvMinutas.PageCount.ToString();

            //LLENA LA LISTA CON EL NUMERO DE PAGINAS
            DropDownList list = (e.Row.FindControl("pageMinutasDropDownList") as DropDownList);
            for (int i = 1; i <= Convert.ToInt32(gdvMinutas.PageCount); i++)
            {
                list.Items.Add(i.ToString());
            }
            list.SelectedValue = Convert.ToString(gdvMinutas.PageIndex + 1);
        }
        else if (e.Row.RowType == DataControlRowType.DataRow && (gdvMinutas.DataSource != null))
        {
            string id = gdvMinutas.DataKeys[e.Row.RowIndex].Value.ToString();
            min = new Minutas() { ObjUsuarios=new UsuariosDatos()};
            min = (e.Row.DataItem as Minutas);
            HyperLink link = (e.Row.FindControl("linkresumen") as HyperLink);
            link.NavigateUrl = GetRouteUrl("VistaSesionApp", new { idsesion = min.IdSesion });

            HyperLink linkseg = (e.Row.FindControl("linkseguimiento") as HyperLink);
            linkseg.NavigateUrl = GetRouteUrl("MinutasSeguimientoApp", new { idsesion = min.IdSesion });

            LinkButton linkdel = (e.Row.FindControl("linkeliminar") as LinkButton);
            if(Convert.ToInt32(Session["IdUser"])!=min.ObjUsuarios.IdUser)
            {
                linkdel.Visible = false;
            }

        }
    }
    protected void gdvMinutas_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("CancelarMinuta"))
        {
            
            try
            {
                int rowindex = Convert.ToInt32(e.CommandArgument);
                int idsesion = Convert.ToInt32(gdvMinutas.DataKeys[rowindex].Value);

                min = new Minutas() { ObjUsuarios = new UsuariosDatos() { User=new Usuarios()} };
                min.IdSesion = idsesion;
                min.ObjUsuarios.User.IdUser = Convert.ToInt32(Session["IdUser"]);
                mbl = new MinutasBL();
                mbl.CancelarSesion(min);
                LoadGridMinutas();
            }
            catch(Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "bootbox.alert('<div class=\"alert alert-danger\">Proceso interrumpido! " + ex.Message.Replace("'", "") + "</div>');", true);

            }
            
        }
    }
    protected void pageMinutasDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList _IraPag = ((DropDownList)sender);

        int _NumPag;
        if (int.TryParse(_IraPag.Text.Trim(), out _NumPag) && _NumPag > 0 && _NumPag <= gdvMinutas.PageCount)
        {
            gdvMinutas.PageIndex = _NumPag - 1;
            npageMinuta = _NumPag - 1;
            LoadGridMinutas();
        }
        else
        {
            LoadGridMinutas();
        }
    }
    protected void btnLimpiarFiltros_Click(object sender, EventArgs e)
    {
        LimpiarFiltros();
        LoadGridMinutas();
    }

    public override void VerifyRenderingInServerForm(Control control)
    {

    }

    protected void btnExportar_Click(object sender, EventArgs e)
    {
        DateTime Hoy = DateTime.Today;
        string fecha_actual = Hoy.ToString("ddMMyyyy");
        mbl = new MinutasBL();
        gdvExportarHistorial.DataSource = mbl.GetMinutas(FiltroMinutas());
        gdvExportarHistorial.DataBind();
        Exportar(gdvExportarHistorial, "Historialminutas_" + fecha_actual);
    }

    protected void Exportar(GridView gv, string nombreArchivo)
    {
        this.EnableViewState = false;
        Response.ClearContent();
        Response.ContentType = "application/vnd.ms-excel";
        Response.Charset = "Windows-1252";
        Response.AddHeader("content-disposition", "filename=" + nombreArchivo + ".xls");

        Response.Cache.SetCacheability(HttpCacheability.NoCache);


        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);

        gv.RenderControl(htmlWrite);
        Response.Write(stringWrite.ToString());
        Response.End();
    }
   
}