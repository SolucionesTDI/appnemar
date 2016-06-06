<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Perfiles.aspx.cs" Inherits="Administracion_Perfiles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

    <asp:Content ContentPlaceHolderID="contentBody" runat="server" ID="contInicio">
    <!-- Content Wrapper. Contains page content -->
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <h1>Perfiles               
                <asp:UpdatePanel ID="ValoresPanel" runat="server">
                    <ContentTemplate>
                        <asp:HiddenField ID="ID" runat="server" />
                        <asp:HiddenField ID="Operacion" runat="server" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </h1>
            <ol class="breadcrumb">
                <li><a href="../Inicio.aspx"><i class="fa fa-home"></i>Inicio</a></li>
            </ol>
        </section>
        <section class="content">
            <div class="row">
                <div class="col-xs-12">
                    <div class="box">
                        <div class="box-header with-border">
                            <h3 class="box-title">&nbsp;</h3>
                            <div class="box-tools">
                                <div class="input-group input-group-sm" style="width: 200px;">
                                    <asp:TextBox runat="server" ID="txtBusquedaNombrePerfil" CssClass="form-control pull-right" Width="200px" />
                                    <div class="input-group-btn">
                                        <asp:LinkButton ID="BuscarPerfil"
                                            runat="server"
                                            CssClass="btn btn-default"
                                            OnClick="BuscarPefil_Click">
    <span aria-hidden="true" class="fa fa-search"></span> Buscar
                                        </asp:LinkButton>
                                        <asp:LinkButton ID="btnNuevoPerfil"
                                            runat="server"
                                            CssClass="btn btn-success btn-sm"
                                            OnClick="NuevoPerfil_Click">
    <span aria-hidden="true" class="fa fa-plus"></span> Nuevo
                                        </asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="box-body">
                            <asp:UpdatePanel ID="UpdatePanelGridViewPerfiles" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:GridView ID="GridViewPerfiles" CssClass="table table-bordered" runat="server" DataKeyNames="IdPerfil" AutoGenerateColumns="false" OnRowCommand="GridView_RowCommand">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Nombre del Perfil">
                                                <ItemTemplate>
                                                       <asp:Label ID="NomPerfil" runat="server" Text='<%# Bind("NomPerfil") %>'><%# Eval("NomPerfil") %> </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                          
                                            <asp:TemplateField HeaderText="Alta">
                                                <ItemTemplate>
                                                    <asp:Label runat="server"><%# Eval("FechaRegistro") %> </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Opciones" ItemStyle-Width="344px">
                                                <ItemTemplate>

                                                    <asp:LinkButton ID="btnCambiarNombrePerfil"
                                                        runat="server"
                                                        CssClass="btn btn-primary btn-sm"
                                                        CommandName="CambiarNombrePerfil"
                                                        CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">
  &nbsp; <span aria-hidden="true" class="fa fa-pencil"></span>&nbsp;&nbsp;Editar Nombre  
                                                    </asp:LinkButton>
                                                    <asp:LinkButton ID="btnEditarPermisos"
                                                        runat="server"
                                                        CssClass="btn btn-warning btn-sm"
                                                        CommandName="EditarPermisos"
                                                        CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">
  &nbsp;  <span aria-hidden="true" class="fa fa-list"></span>&nbsp;&nbsp;Editar Permisos
                                                    </asp:LinkButton>
                                                    <asp:LinkButton ID="btnEliminarPerfil"
                                                        runat="server"
                                                        CssClass="btn btn-danger btn-sm"
                                                        CommandName="EliminarPerfil"
                                                        CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">
  &nbsp;  <span aria-hidden="true" class="fa fa-trash"></span>&nbsp;&nbsp;Eliminar
                                                    </asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="GuardarPerfil" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="GuardarNombrePerfil" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="GuardarEliminacion" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="btnNuevoPerfil" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="BuscarPerfil" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
                 <!-- Bootstrap Modal Dialog Edit -->
                <div class="modal fade" id="ModalCambiarNombrePerfil" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                    <div class="modal-dialog">
                        <asp:UpdatePanel ID="upModalCambiarNombrePerfil" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                            <ContentTemplate>

                                <div class="modal-content">
                                    <div class="modal-header">
                                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                        <h4 class="modal-title">
                                            <asp:Label ID="lblModalTitleEditar" runat="server" Text=""></asp:Label></h4>
                                    </div>
                                    <div class="modal-body">
                                        <asp:TextBox ID="txtCambiarNombrePerfil" CssClass="form-control" runat="server"></asp:TextBox>
                                        <div class="has-error">
                                            <asp:Label CssClass="control-label" ID="lblMensajeEditar" runat="server" Visible="false" Text="">
                    <i class="fa fa-times-circle-o"></i> El Campo no puede estar vacio
                                            </asp:Label>
                                        </div>
                                    </div>
                                    <div class="modal-footer">
                                        <asp:Button CssClass="btn btn-primary" ID="GuardarNombrePerfil" runat="server" Text="Guardar" OnClick="NombrePerfil_Click" />
                                        <button class="btn btn-danger" data-dismiss="modal" aria-hidden="true">Cancelar</button>
                                    </div>
                                </div>
                            </ContentTemplate>

                        </asp:UpdatePanel>
                    </div>
                </div>
                <!-- Bootstrap Modal Dialog Delete -->
                <div class="modal fade" id="ModalEliminar" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                    <div class="modal-dialog">
                        <asp:UpdatePanel ID="upModalEliminar" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                            <ContentTemplate>
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                        <h4 class="modal-title">
                                            <asp:Label ID="lblModalTitleEliminar" runat="server" Text=""></asp:Label></h4>
                                    </div>
                                    <div class="modal-body">
                                        <asp:Label ID="lblModalBodyEliminar" runat="server" Text=""></asp:Label>
                                    </div>
                                    <div class="modal-footer">
                                        <asp:Button CssClass="btn btn-primary" ID="GuardarEliminacion" runat="server" Text="Aceptar" OnClick="Eliminar_Click" />
                                        <button class="btn btn-danger" data-dismiss="modal" aria-hidden="true">Cancelar</button>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <!-- Bootstrap Modal Dialog OperPerfil -->
                <div class="modal fade" id="ModalOperPerfil" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                    <div class="modal-dialog">
                        <asp:UpdatePanel ID="upModalOperPerfil" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                            <ContentTemplate>
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                        <h4 class="modal-title">
                                            <asp:Label ID="lblModalTitleNuevo" runat="server" Text=""></asp:Label></h4>
                                    </div>
                                    <div class="modal-body">
                                        <div class="form-horizontal">
                                            <div class="form-group">
                                                <asp:label class="col-sm-2 control-label" runat="server" ID="EtiquetaNombrePerfil">Nombre: </asp:label>
                                                <div class="col-sm-10">
                                                    <asp:TextBox ID="txtNombrePerfil" CssClass="form-control" runat="server"></asp:TextBox>
                                                    <div class="has-error">
                                                        <asp:Label CssClass="control-label" ID="lblNombrePerfil" runat="server" Visible="false" Text="">
                    <i class="fa fa-times-circle-o"></i> Campo Obligatorio
                                                        </asp:Label>
                                                      </div>
                                                </div>
                                            </div>
                                           
                                            <div class="form-group">
                                                
                                                   <label class="col-sm-2 control-label">Permisos: </label>
                                                 <div class="col-sm-5">
                                                   <asp:CheckBoxList ID="chckboxlist" runat="server"></asp:CheckBoxList>
                                                     </div>
                                              </div>
                                         </div>
                                            <div class="modal-footer">
                                                <asp:Button CssClass="btn btn-primary" ID="GuardarPerfil" runat="server" Text="Guardar" OnClick="Guardar_Click" />
                                                <button class="btn btn-danger" data-dismiss="modal" aria-hidden="true">Cancelar</button>
                                            </div>
                                        </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </section>
    </div>
</asp:Content>


