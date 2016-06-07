using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidades;
using System.Text;
using System.Data;

public partial class Site : System.Web.UI.MasterPage
{
    public Usuarios UserMaster;
   
    List<Entidades.Menu> listMenu;
    string path;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!ValidarSesion.sesionactiva())
            Response.Redirect("~/Default.aspx");
        
        UserMaster = new Usuarios() { Perfil = new Perfiles() };
        UserMaster = Session["Usuario"] as Usuarios;
        
        MenusBL bl = new MenusBL();
        UsuariosBL userbl = new UsuariosBL();
              if (!IsPostBack)
        {
           
            path = HttpContext.Current.Request.Url.AbsolutePath;
            path = path.Replace("/retros/", "");
            listMenu = bl.GetMenus(UserMaster.Perfil.IdPerfil);
            LoadMenu();
          
            List<UsuariosDatos> _lstusuariodatos = new List<UsuariosDatos>();
            _lstusuariodatos = userbl.list(0, 0, 0, 0,(int) Session["IdUser"]);
            if (_lstusuariodatos.Count == 0)
            {
                nombreusuariousermenu.Text = "Soporte";
                nombredeusuariodropmenu.Text = "Soporte";
                perfilusuariodropmenu.Text = ((Usuarios)Session["Usuario"]).Perfil.NomPerfil;
                nombreusuarioleftmenu.Text = "Soporte";
            }
            else
            {
                nombreusuariousermenu.Text = _lstusuariodatos[0].NombreUser;
                nombredeusuariodropmenu.Text = _lstusuariodatos[0].NombreUser;
                perfilusuariodropmenu.Text = _lstusuariodatos[0].User.Perfil.NomPerfil;
                nombreusuarioleftmenu.Text = _lstusuariodatos[0].NombreUser;
            }
           
            lblModalTitlePassword.Text = "Cambio de Contraseña";
            txtUserPasswordCambio.Attributes.Add("placeholder", "Contraseña Nueva");
            txtUserPasswordCambioConfirma.Attributes.Add("placeholder", "Confirmar Contraseña");
        }
    }

    public void ValidarSession()
    {
        UserMaster = new Usuarios() { Perfil=new Perfiles()};
        UserMaster = Session["Usuario"] as Usuarios;
        if (UserMaster == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        
    }

    protected void LoadMenu(int idpadre=0)
    {
        rptMenus.DataSource = listMenu.Where(x => x.idpadre == idpadre);
        rptMenus.DataBind();
    }
    protected void rptMenus_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            if (listMenu.Count>0)
            {
                Entidades.Menu men = new Entidades.Menu();
                men = e.Item.DataItem as Entidades.Menu;
                int newpadre = men.Idmenu;
                string Title = men.nommenu;

                List<Entidades.Menu> menu = listMenu.Where(x => x.idpadre == newpadre).ToList();
                StringBuilder lip = new StringBuilder();
                string classli = "";
                string active = "";
                if (men.urlmenu == path)
                    active = "active";

                if (menu.Count > 0)
                {
                    classli = "treeview "+active;
                    //<li class="treeview" data-idmenu='<%# DataBinder.Eval(Container.DataItem, "Idmenu")%>' data-idpadre='<%# DataBinder.Eval(Container.DataItem, "idpadre")%>'>
                    StringBuilder sb = new StringBuilder();
                    StringBuilder sbcollapse = new StringBuilder();
                    lip.Append("<li class='" + classli + "'>");
                    sbcollapse.Append("<i class='fa fa-angle-left pull-right'></i>");
                    (e.Item.FindControl("ltrcollapse") as Literal).Text = sbcollapse.ToString();
                    sb.Append("<ul id='" + Title + "' class='treeview-menu'>");
                    foreach (Entidades.Menu item in menu)
                    {
                        int parentId = item.Idmenu;
                        string parentTitle = item.nommenu;
                        List<Entidades.Menu> menuhijo = listMenu.Where(x => x.idpadre == parentId).ToList();
                        if (menuhijo.Count > 0)
                        {
                            sb.Append("<li><a href='" + ResolveUrl("~/" + item.urlmenu) + "'><i class='" + item.icono + "'></i>" + item.nommenu + "<i class='fa fa-angle-left pull-right'></i></a>");
                          
                        }
                        else
                        {
                            if (item.urlmenu == path)
                            {
                                active = "active";
                                lip.Clear();
                                lip.Append("<li class='treeview active'>");
                            }
                            else
                            {
                                active = "";
                            }
                            sb.Append("<li class=" + active + "><a href='" + ResolveUrl("~/" + item.urlmenu) + "'><i class='" + item.icono + "'></i>" + item.nommenu + " </a>");

                        }
                            
                            sb = CreateChild(sb, parentId, parentTitle, menuhijo);
                            sb.Append("</li>");
                    }
                    sb.Append("</ul>");
                    (e.Item.FindControl("ltrlSubMenu") as Literal).Text = sb.ToString();
                }
                else
                {
                    lip.Append("<li class='" + active + "'>");
                }
                (e.Item.FindControl("ltrliprincipal") as Literal).Text = lip.ToString();
            }
        }
    }

    private StringBuilder CreateChild(StringBuilder sb, int parentId, string parentTitle, List<Entidades.Menu> parentRows)
    {
        if (parentRows.Count > 0)
        {
            sb.Append("<ul id='" + parentTitle + "' class='treeview-menu'>");
            foreach (var item in parentRows)
            {
                int childId = item.Idmenu;
                string childTitle = item.nommenu;
                List<Entidades.Menu> childRow = listMenu.Where(x => x.idpadre == childId).ToList();
                string active = "";
                if (item.urlmenu == path)
                    active = "active";
                else
                    active = "";
                if (childRow.Count > 0)
                {
                    sb.Append("<li><a  href='" + ResolveUrl("~/" + item.urlmenu) + "'><i class='" + item.icono + "'></i>" + item.nommenu + "<i class='fa fa-angle-left pull-right'></i></a>");
                          
                }
                else
                {
                    sb.Append("<li class=" + active + "><a href='" + ResolveUrl("~/" + item.urlmenu) + "'><i class='" + item.icono + "'></i>" + item.nommenu + " </a>");
                }
                CreateChild(sb, childId, childTitle, childRow);
                sb.Append("</li>");
            }
            sb.Append("</ul>");

        }
        return sb;
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
                UsuariosBL _catusuariosneg = new UsuariosBL();
                UsuariosDatos _catusuario = new UsuariosDatos();
                _catusuario.User = new Usuarios();
                _catusuario.User.IdUser = Convert.ToInt32(Session["IdUser"]);
                _catusuario.User.Password = txtUserPasswordCambio.Text;
                _catusuariosneg.cambiarPassword(_catusuario);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalPassword", "$('#ModalPassword').modal('hide');", true);
                upModalPassword.Update();
            }
            else
            {
                lblUserPasswordCambioConfirma.Visible = true;
            }
        }
        else
        {
            lblUserPasswordCambio.Visible = true;
        }

    }
}
