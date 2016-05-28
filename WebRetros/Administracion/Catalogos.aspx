<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Catalogos.aspx.cs" Inherits="Administracion_Catalogos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:GridView ID="GridViewDepartamentos" runat="server">
        </asp:GridView>

          <asp:GridView ID="GridViewPuestos" runat="server">
        </asp:GridView>

          <asp:GridView ID="GridViewStatus" runat="server">
        </asp:GridView>

        <asp:GridView ID="GridViewSedes" runat="server">
        </asp:GridView>

        <asp:GridView ID="GridViewTemas" runat="server">
        </asp:GridView>


    
    </div>
    </form>
</body>
</html>
