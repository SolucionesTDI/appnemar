﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Catalogos.aspx.cs" Inherits="Administracion_Catalogos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

       
        <asp:Label ID="lblGridViewDepartamentos" runat="server" Text="Departamentos" ></asp:Label> <asp:HiddenField ID="IdDepartamentos" runat="server" />
        <asp:GridView ID="GridViewDepartamentos" runat="server" AutoGenerateColumns="false" DataKeyNames="iddepto" OnRowCommand="GridView_RowCommand">
            <Columns>

                <asp:BoundField DataField="descripcion" HeaderText="Departamento" Visible="true" />
             
                <asp:BoundField DataField="fecharegistro" HeaderText="Fecha Alta" Visible="true" />
                <asp:TemplateField HeaderText="Opciones">
                    <ItemTemplate>
                        <asp:Button ID="btnEditarDepartamento" runat="server"  
                            CommandName="EditarDepartamento"
                            CommandArgument= "<%# ((GridViewRow) Container).RowIndex %>"                      
                            Text="Editar" />
                        <asp:Button ID="btnEliminarDepartamento" runat="server"  
                            CommandName="EliminarDepartamento"
                            CommandArgument= "<%# ((GridViewRow) Container).RowIndex %>"                                  
                            Text="Eliminar" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
          <asp:Label ID="lblGridViewPuestos" runat="server" Text="Puestos"></asp:Label> <asp:HiddenField ID="IdPuestos" runat="server" />
          <asp:GridView ID="GridViewPuestos" runat="server" AutoGenerateColumns="false" DataKeyNames="idpuesto" OnRowCommand="GridView_RowCommand">
                 <Columns>

                <asp:BoundField DataField="descripcion" HeaderText="Puesto" Visible="true" />
             
                <asp:BoundField DataField="fecharegistro" HeaderText="Fecha Alta" Visible="true" />
                <asp:TemplateField HeaderText="Opciones">
                    <ItemTemplate>
                        <asp:Button ID="btnEditarPuesto" runat="server"  
                            CommandName="EditarPuesto"
                            CommandArgument= "<%# ((GridViewRow) Container).RowIndex %>"                      
                            Text="Editar" />
                        <asp:Button ID="btnEliminarPuesto" runat="server"  
                            CommandName="EliminarPuesto"
                            CommandArgument= "<%# ((GridViewRow) Container).RowIndex %>"                                  
                            Text="Eliminar" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
          <asp:Label ID="lblGridViewStatus" runat="server" Text="Status"></asp:Label> <asp:HiddenField ID="IdStatus" runat="server" />
          <asp:GridView ID="GridViewStatus" runat="server" AutoGenerateColumns="false" DataKeyNames="idstatus" OnRowCommand="GridView_RowCommand">
               <Columns>

                <asp:BoundField DataField="nomstatus" HeaderText="Status" Visible="true" />
                
                    <asp:BoundField DataField="orden" HeaderText="Orden" Visible="true" />
               
                <asp:BoundField DataField="fecharegistro" HeaderText="Fecha Alta" Visible="true" />
                <asp:TemplateField HeaderText="Opciones">
                    <ItemTemplate>
                        <asp:Button ID="btnEditarStatus" runat="server"  
                            CommandName="EditarStatus"
                            CommandArgument= "<%# ((GridViewRow) Container).RowIndex %>"                      
                            Text="Editar" />
                        <asp:Button ID="btnEliminarStatus" runat="server"  
                            CommandName="EliminarStatus"
                            CommandArgument= "<%# ((GridViewRow) Container).RowIndex %>"                                  
                            Text="Eliminar" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
          <asp:Label ID="lblGridViewSedes" runat="server" Text="Sedes"></asp:Label> <asp:HiddenField ID="IdSede" runat="server" />
        <asp:GridView ID="GridViewSedes" runat="server" AutoGenerateColumns="false" DataKeyNames="idsede" OnRowCommand="GridView_RowCommand">
             <Columns>

                <asp:BoundField DataField="descripcion" HeaderText="Sede" Visible="true" />
              
                <asp:BoundField DataField="fecharegistro" HeaderText="Fecha Alta" Visible="true" />
                <asp:TemplateField HeaderText="Opciones">
                    <ItemTemplate>
                        <asp:Button ID="btnEditarSede" runat="server"  
                            CommandName="EditarSede"
                            CommandArgument= "<%# ((GridViewRow) Container).RowIndex %>"                      
                            Text="Editar" />
                        <asp:Button ID="btnEliminarSede" runat="server"  
                            CommandName="EliminarSede"
                            CommandArgument= "<%# ((GridViewRow) Container).RowIndex %>"                                  
                            Text="Eliminar" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
          <asp:Label ID="lblGridViewTemas" runat="server" Text="Temas"></asp:Label> <asp:HiddenField ID="IdTemas" runat="server" />
        <asp:GridView ID="GridViewTemas" runat="server" AutoGenerateColumns="false" DataKeyNames="idtema" OnRowCommand="GridView_RowCommand">
              <Columns>

                <asp:BoundField DataField="descripcion" HeaderText="Sede" Visible="true" />
              
                <asp:BoundField DataField="fecharegistro" HeaderText="Fecha Alta" Visible="true" />
                <asp:TemplateField HeaderText="Opciones">
                    <ItemTemplate>
                        <asp:Button ID="btnEditarTema" runat="server"  
                            CommandName="EditarTema"
                            CommandArgument= "<%# ((GridViewRow) Container).RowIndex %>"                      
                            Text="Editar" />
                        <asp:Button ID="btnEliminarTema" runat="server"  
                            CommandName="EliminarTema"
                            CommandArgument= "<%# ((GridViewRow) Container).RowIndex %>"                                  
                            Text="Eliminar" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

        <div>
         <asp:Label ID="lblAgregarDepartamento" runat="server" Text="Agregar Departamento"></asp:Label>
        <asp:Label ID="lblDepartamento" runat="server" Text="Departamento: "></asp:Label>
        <asp:TextBox ID="txtDepartamento" runat="server"></asp:TextBox>
        <asp:Button ID="btnGuardarDepartamento" runat="server" Text="Guardar" OnClick="btnGuardarDepartamento_Click" />
        <asp:Button ID="btnCancelarDepartamento" runat="server" Text="Cancelar" />
            </div>
 
       <div>
        <asp:Label ID="lblAgregarPuesto" runat="server" Text="Agregar Puesto"></asp:Label>
        <asp:Label ID="lblPuesto" runat="server" Text="Puesto: "></asp:Label>
        <asp:TextBox ID="txtPuesto" runat="server"></asp:TextBox>
        <asp:Button ID="btnGuardarPuesto" runat="server" Text="Guardar" OnClick="btnGuardarPuesto_Click" />
        <asp:Button ID="btnCancelarPuesto" runat="server" Text="Cancelar" />
        </div>
        <div>
        <asp:Label ID="lblAgregarSede" runat="server" Text="Agregar Sede"></asp:Label>
        <asp:Label ID="lblSede" runat="server" Text="Sede: "></asp:Label>
        <asp:TextBox ID="txtSede" runat="server"></asp:TextBox>
        <asp:Button ID="btnGuardarSede" runat="server" Text="Guardar" OnClick="btnGuardarSede_Click" />
        <asp:Button ID="btnCancelarSede" runat="server" Text="Cancelar" />
        </div>
        <div>
         <asp:Label ID="lblAgregarStatus" runat="server" Text="Agregar Status"></asp:Label>
        <asp:Label ID="lblStatus" runat="server" Text="Status: "></asp:Label>
        <asp:TextBox ID="txtNomStatus" runat="server"></asp:TextBox>
         <asp:Label ID="lblOrden" runat="server" Text="Orden"></asp:Label>
        <asp:TextBox ID="txtOrden" runat="server"></asp:TextBox>
        <asp:Button ID="btnGuardarStatus" runat="server" Text="Guardar" OnClick="btnGuardarStatus_Click" />
        <asp:Button ID="btnCancelarStatus" runat="server" Text="Cancelar" />
         </div>
         <div>
        <asp:Label ID="lblAgregarTema" runat="server" Text="Agregar Tema"></asp:Label>
        <asp:Label ID="lblTema" runat="server" Text="Tema: "></asp:Label>
        <asp:TextBox ID="txtTema" runat="server"></asp:TextBox>
        <asp:Button ID="btnGuardarTema" runat="server" Text="Guardar" OnClick="btnGuardarTema_Click" />
        <asp:Button ID="btnCancelarTema" runat="server" Text="Cancelar" />
        </div>

    </div>
    </form>
</body>
</html>
