using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Routing;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        VirtualPathData vpd =
        RouteTable.Routes.GetVirtualPath(null, "LoginApp", null);
        Response.Redirect(vpd.VirtualPath);
    }
}