using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Site : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void rptMenus_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            if (Menus != null)
            {
                DataRowView drv = e.Item.DataItem as DataRowView;
                string ID = drv["MenuId"].ToString();
                string Title = drv["Title"].ToString();
                DataRow[] rows = Menus.Select("ParentMenuId=" + ID);
                if (rows.Length > 0)
                {

                    StringBuilder sb = new StringBuilder();
                    sb.Append("<ul id='" + Title + "' class='sub-menu collapse'>");
                    foreach (var item in rows)
                    {
                        string parentId = item["MenuId"].ToString();
                        string parentTitle = item["Title"].ToString();

                        DataRow[] parentRow = Menus.Select("ParentMenuId=" + parentId);

                        if (parentRow.Count() > 0)
                        {
                            sb.Append("<li data-toggle='collapse' data-target='#" + parentTitle + "' class='collapsed'><a href='" + item["Url"] + "'>" + item["Title"] + "<span class='arrow'></span></a>");
                            sb.Append("</li>");
                        }
                        else
                        {
                            sb.Append("<li><a href='" + item["Url"] + "'>" + item["Title"] + "</a>");
                            sb.Append("</li>");
                        }
                        sb = CreateChild(sb, parentId, parentTitle, parentRow);
                    }
                    sb.Append("</ul>");
                    (e.Item.FindControl("ltrlSubMenu") as Literal).Text = sb.ToString();
                }
            }
        }
    }
}
