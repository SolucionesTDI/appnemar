<%@ Page Language="C#" AutoEventWireup="true" CodeFile="VistaSesion.aspx.cs" Inherits="Minutas_VistaSesion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Detalles de la minuta</title>
     <link rel="stylesheet" href="~/assets/bootstrap/css/bootstrap.min.css" runat="server" />


  <link rel="stylesheet" href="~/assets/dist/css/AdminLTE.min.css" runat="server"/>
  <!-- AdminLTE Skins. Choose a skin from the css/skins
       folder instead of downloading all of them to reduce the load. -->
  <link rel="stylesheet" href='<%#ResolveUrl("~/assets/dist/css/skins/_all-skins.min.css") %>'/>

  <link rel="stylesheet" href="<%#ResolveUrl("~/assets/dist/css/GridView.css") %>"/>
  <link rel="stylesheet" href="<%#ResolveUrl("~/assets/dist/css/csstables.css") %>"/>
    <style type="text/css">
		    #htmlMinutas{ width:1200px; margin:20px auto;}
		</style>
</head>
<body class="">

<asp:ListView runat="server" ID="ltvUsuariosSesion" EnableModelValidation="True" DataKeyNames="IdSesionUser,IdUserMinuta"
  OnItemDataBound="ltvUsuariosSesion_ItemDataBound" >
    <LayoutTemplate >
        <div class="row">
            <div class="col-sm-12">
                <div class="box box-solid">
                    <div class="box-header with-border">
                      <h3 class="box-title">Usuarios Participantes</h3>
                    </div>
                    <div class="box-body">
                        <div class="box-group">
                            <div runat="server" id="itemPlaceholder"></div>
                        </div>
                    </div>
                </div>
            </div>
        </div> 
    </LayoutTemplate>
    <ItemTemplate>
        <div class="box box-primary">
            <div class="box-header">
                <h4 class="box-title text-light-blue">
                    <%#DataBinder.Eval(Container.DataItem, "ObjUsuarios.NombreCompleto")%>
                </h4>
            </div>
            <div class="box-body">
               <asp:ListView runat="server" ID="ltvAcuerdos" EnableModelValidation="True" DataKeyNames="IdAcuerdo,IdUserMinuta"
                  OnItemDataBound="ltvAcuerdos_ItemDataBound"   >
                   <LayoutTemplate >
                        <div class="row">
                            <div class="col-sm-12">
                                <div class="table-responsive">
                                     <table class="table table-bordered table-hover">
                                        <thead>
                                            <tr>
                                              <th>Fecha inicial</th>
                                              <th>Fecha final</th>
                                              <th>Descripción</th>
                                              <th>Estatus</th>
                                              <th>Tiempo entrega</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr runat="server" id="itemPlaceholder" ></tr>
                                        </tbody>
                                     </table>
                                </div>
                            </div>
                        </div> 
                    </LayoutTemplate>
                   <ItemTemplate>
                       <tr>
                           <td><%#DataBinder.Eval(Container.DataItem, "FechaIni","{0:d}")%></td>
                           <td><%#DataBinder.Eval(Container.DataItem, "FechaFin","{0:d}")%></td>
                           <td><%#DataBinder.Eval(Container.DataItem, "Descripcion")%></td>
                           <td><%#DataBinder.Eval(Container.DataItem, "ObjMinutas.ObjStatus.nomstatus")%></td>
                           <td><%#DataBinder.Eval(Container.DataItem, "LabelDias")%></td>
                       </tr>
                       <tr>
                           <td colspan="5">
                               <asp:ListView runat="server" ID="ltvComentariosAcuerdos" EnableModelValidation="True" DataKeyNames="Idcomentario" >
                                   <LayoutTemplate >
                                   <div class="row">
                                        <div class="col-sm-12">
                                            <div class="table-responsive">
                                                 <table class="datagrid table table-striped">
                                                    <thead>
                                                        <tr>
                                                          <th>Comentarios</th>
                                                          <th>Usuario</th>
                                                          <th>Fecha Registro</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <tr runat="server" id="itemPlaceholder" ></tr>
                                                    </tbody>
                                                 </table>
                                            </div>
                                        </div>
                                    </div> 
                                    </LayoutTemplate>
                                    <ItemTemplate>
                                        <tr>
                                           <td><%#DataBinder.Eval(Container.DataItem, "Comentarios")%></td>
                                           <td><%#DataBinder.Eval(Container.DataItem, "ObjUserDatos.NombreCompleto")%></td>
                                           <td><%#DataBinder.Eval(Container.DataItem, "FechaRegistro","{0:d}")%></td>
                                       </tr>
                                    </ItemTemplate>
                                </asp:ListView>
                           </td>
                       </tr>
                   </ItemTemplate>
                </asp:ListView>
            </div>
        </div>
    </ItemTemplate>
</asp:ListView>

<div id="htmlMinutas" runat="server">
       
</div>
    <form id="form1" runat="server">
    
        
        <asp:ScriptManager ID="ScriptManager1" runat="server">
            <Scripts>
                <asp:ScriptReference Path="~/assets/plugins/jQuery/jQuery-2.2.0.min.js" />
                <asp:ScriptReference Path="~/assets/bootstrap/js/bootstrap.min.js" />
                
            </Scripts>
           
        </asp:ScriptManager>
      
    </form>
</body>
</html>
