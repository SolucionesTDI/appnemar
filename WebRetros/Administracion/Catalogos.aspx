<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Catalogos.aspx.cs" Inherits="Administracion_Catalogos" MasterPageFile="~/Site.master" %>
<asp:Content ContentPlaceHolderID="contentBody" runat="server" ID="contInicio">
    <!-- Content Wrapper. Contains page content -->
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <h1>Catálogos               
                <asp:UpdatePanel ID="ValoresPanel" runat="server">
                    <ContentTemplate>
                        <asp:HiddenField ID="ID" runat="server" />
                        <asp:HiddenField ID="Catalogo" runat="server" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </h1>
            <ol class="breadcrumb">
                <li><a href="../Inicio.aspx"><i class="fa fa-home"></i>Inicio</a></li>
            </ol>
        </section>
        <section class="content">
            <div class="row">
                <div class="col-md-6">
                    <div class="box">
                        <div class="box-header with-border">
                            <h3 class="box-title">Departamentos </h3>
                            <div class="box-tools">
                                <div class="input-group input-group-sm" style="width: 300px;">
                                    <asp:TextBox runat="server" ID="txtBuscarDepartamento" CssClass="form-control pull-right" placeholder="Buscar" />
                                    <div class="input-group-btn">
                                        <asp:LinkButton ID="BuscarDepartamento"
                                            runat="server"
                                            CssClass="btn btn-default"
                                            OnClick="BuscarDepartamento_Click">
    <span aria-hidden="true" class="fa fa-search"></span> Buscar
                                        </asp:LinkButton>
                                        <asp:LinkButton ID="btnNuevoDepartamento"
                                            runat="server"
                                            CssClass="btn btn-success btn-sm"
                                            OnClick="NuevoDepartamento_Click">
    <span aria-hidden="true" class="fa fa-plus"></span> Nuevo
                                        </asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="box-body">
                            <asp:UpdatePanel ID="UpdatePanelGridDepartamentos" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:GridView ID="GridViewDepartamentos" CssClass="table table-bordered" runat="server" AutoGenerateColumns="false" DataKeyNames="iddepto" OnRowCommand="GridView_RowCommand">
                                        <Columns>
                                            <asp:BoundField DataField="descripcion" HeaderText="Nombre" Visible="true" />
                                            <asp:BoundField DataField="fecharegistro" HeaderText="Fecha Alta" Visible="true" />
                                            <asp:TemplateField HeaderText="Opciones" ItemStyle-Width="161px">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnEditarDepartamento"
                                                        runat="server"
                                                        CssClass="btn btn-primary btn-sm"
                                                        CommandName="EditarDepartamento"
                                                        CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">
    <span aria-hidden="true" class="fa fa-pencil"></span> Editar
                                                    </asp:LinkButton>
                                                    <asp:LinkButton ID="btnEliminarDepartamento"
                                                        runat="server"
                                                        CssClass="btn btn-danger btn-sm"
                                                        CommandName="EliminarDepartamento"
                                                        CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">
    <span aria-hidden="true" class="fa fa-trash"></span> Eliminar
                                                    </asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="GuardarNuevo" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="GuardarEdicion" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="GuardarEliminacion" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="btnNuevoDepartamento" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="BuscarDepartamento" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="box">
                        <div class="box-header with-border">
                            <h3 class="box-title">Puestos </h3>
                            <div class="box-tools">
                                <div class="input-group input-group-sm" style="width: 300px;">
                                    <asp:TextBox runat="server" ID="txtBuscarPuesto" CssClass="form-control pull-right" placeholder="Buscar" />
                                    <div class="input-group-btn">
                                        <asp:LinkButton ID="BuscarPuesto"
                                            runat="server"
                                            CssClass="btn btn-default"
                                            OnClick="BuscarPuesto_Click">
    <span aria-hidden="true" class="fa fa-search"></span> Buscar
                                        </asp:LinkButton>
                                        <asp:LinkButton ID="btnNuevoPuesto"
                                            runat="server"
                                            CssClass="btn btn-success btn-sm"
                                            OnClick="NuevoPuesto_Click">
    <span aria-hidden="true" class="fa fa-plus"></span> Nuevo
                                        </asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="box-body">
                            <asp:UpdatePanel ID="UpdatePanelGridPuestos" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:GridView ID="GridViewPuestos" CssClass="table table-bordered" runat="server" AutoGenerateColumns="false" DataKeyNames="idpuesto" OnRowCommand="GridView_RowCommand">
                                        <Columns>
                                            <asp:BoundField DataField="descripcion" HeaderText="Nombre" Visible="true" />
                                            <asp:BoundField DataField="fecharegistro" HeaderText="Fecha Alta" Visible="true" />
                                            <asp:TemplateField HeaderText="Opciones" ItemStyle-Width="161px">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnEditarPuesto"
                                                        runat="server"
                                                        CssClass="btn btn-primary btn-sm"
                                                        CommandName="EditarPuesto"
                                                        CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">
    <span aria-hidden="true" class="fa fa-pencil"></span> Editar
                                                    </asp:LinkButton>
                                                    <asp:LinkButton ID="btnEliminarPuesto"
                                                        runat="server"
                                                        CssClass="btn btn-danger btn-sm"
                                                        CommandName="EliminarPuesto"
                                                        CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">
    <span aria-hidden="true" class="fa fa-trash"></span> Eliminar
                                                    </asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="GuardarNuevo" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="GuardarEdicion" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="GuardarEliminacion" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="btnNuevoPuesto" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="BuscarPuesto" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="box">
                        <div class="box-header with-border">
                            <h3 class="box-title">Sedes </h3>
                            <div class="box-tools">
                                <div class="input-group input-group-sm" style="width: 300px;">
                                    <asp:TextBox runat="server" ID="txtBuscarSede" CssClass="form-control pull-right" placeholder="Buscar" />
                                    <div class="input-group-btn">
                                        <asp:LinkButton ID="BuscarSede"
                                            runat="server"
                                            CssClass="btn btn-default"
                                            OnClick="BuscarSede_Click">
    <span aria-hidden="true" class="fa fa-search"></span> Buscar
                                        </asp:LinkButton>
                                        <asp:LinkButton ID="btnNuevaSede"
                                            runat="server"
                                            CssClass="btn btn-success btn-sm"
                                            OnClick="NuevaSede_Click">
    <span aria-hidden="true" class="fa fa-plus"></span> Nuevo
                                        </asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="box-body">
                            <asp:UpdatePanel ID="UpdatePanelGridSedes" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:GridView ID="GridViewSedes" CssClass="table table-bordered" runat="server" AutoGenerateColumns="false" DataKeyNames="idsede" OnRowCommand="GridView_RowCommand">
                                        <Columns>
                                            <asp:BoundField DataField="descripcion" HeaderText="Nombre" Visible="true" />
                                            <asp:BoundField DataField="fecharegistro" HeaderText="Fecha Alta" Visible="true" />
                                            <asp:TemplateField HeaderText="Opciones" ItemStyle-Width="161px">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnEditarSede"
                                                        runat="server"
                                                        CssClass="btn btn-primary btn-sm"
                                                        CommandName="EditarSede"
                                                        CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">
    <span aria-hidden="true" class="fa fa-pencil"></span> Editar
                                                    </asp:LinkButton>
                                                    <asp:LinkButton ID="btnEliminarSede"
                                                        runat="server"
                                                        CssClass="btn btn-danger btn-sm"
                                                        CommandName="EliminarSede"
                                                        CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">
    <span aria-hidden="true" class="fa fa-trash"></span> Eliminar
                                                    </asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="GuardarNuevo" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="GuardarEdicion" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="GuardarEliminacion" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="btnNuevaSede" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="BuscarSede" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="box">
                        <div class="box-header with-border">
                            <h3 class="box-title">Temas </h3>
                            <div class="box-tools">
                                <div class="input-group input-group-sm" style="width: 300px;">
                                    <asp:TextBox runat="server" ID="txtBuscarTema" CssClass="form-control pull-right" placeholder="Buscar" />
                                    <div class="input-group-btn">
                                        <asp:LinkButton ID="BuscarTema"
                                            runat="server"
                                            CssClass="btn btn-default"
                                            OnClick="BuscarTema_Click">
    <span aria-hidden="true" class="fa fa-search"></span> Buscar
                                        </asp:LinkButton>
                                        <asp:LinkButton ID="btnNuevoTema"
                                            runat="server"
                                            CssClass="btn btn-success btn-sm"
                                            OnClick="NuevoTema_Click">
    <span aria-hidden="true" class="fa fa-plus"></span> Nuevo
                                        </asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="box-body">
                            <asp:UpdatePanel ID="UpdatePanelGridViewTemas" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:GridView ID="GridViewTemas" CssClass="table table-bordered" runat="server" AutoGenerateColumns="false" DataKeyNames="idtema" OnRowCommand="GridView_RowCommand">
                                        <Columns>
                                            <asp:BoundField DataField="descripcion" HeaderText="Nombre" Visible="true" />
                                            <asp:BoundField DataField="fecharegistro" HeaderText="Fecha Alta" Visible="true" />
                                            <asp:TemplateField HeaderText="Opciones" ItemStyle-Width="161px">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnEditarTema"
                                                        runat="server"
                                                        CssClass="btn btn-primary btn-sm"
                                                        CommandName="EditarTema"
                                                        CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">
    <span aria-hidden="true" class="fa fa-pencil"></span> Editar
                                                    </asp:LinkButton>
                                                    <asp:LinkButton ID="btnEliminarTema"
                                                        runat="server"
                                                        CssClass="btn btn-danger btn-sm"
                                                        CommandName="EliminarTema"
                                                        CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">
    <span aria-hidden="true" class="fa fa-trash"></span> Eliminar
                                                    </asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="GuardarNuevo" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="GuardarEdicion" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="GuardarEliminacion" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="btnNuevoTema" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="BuscarTema" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>
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
                <!-- Bootstrap Modal Dialog Edit -->
                <div class="modal fade" id="ModalEditar" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                    <div class="modal-dialog">
                        <asp:UpdatePanel ID="upModalEditar" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                            <ContentTemplate>

                                <div class="modal-content">
                                    <div class="modal-header">
                                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                        <h4 class="modal-title">
                                            <asp:Label ID="lblModalTitleEditar" runat="server" Text=""></asp:Label></h4>
                                    </div>
                                    <div class="modal-body">
                                        <asp:TextBox ID="txtDescripcionEditar" CssClass="form-control" runat="server"></asp:TextBox>
                                        <div class="has-error">
                                            <asp:Label CssClass="control-label" ID="lblMensajeEditar" runat="server" Visible="false" Text="">
                    <i class="fa fa-times-circle-o"></i> El Campo no puede estar vacio
                                            </asp:Label>
                                        </div>
                                    </div>
                                    <div class="modal-footer">
                                        <asp:Button CssClass="btn btn-primary" ID="GuardarEdicion" runat="server" Text="Guardar" OnClick="Editar_Click" />
                                        <button class="btn btn-danger" data-dismiss="modal" aria-hidden="true">Cancelar</button>
                                    </div>
                                </div>
                            </ContentTemplate>

                        </asp:UpdatePanel>
                    </div>
                </div>
                <!-- Bootstrap Modal Dialog New -->
                <div class="modal fade" id="ModalNuevo" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                    <div class="modal-dialog">
                        <asp:UpdatePanel ID="upModalNuevo" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                            <ContentTemplate>
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                        <h4 class="modal-title">
                                            <asp:Label ID="lblModalTitleNuevo" runat="server" Text=""></asp:Label></h4>
                                    </div>
                                    <div class="modal-body">
                                        <asp:TextBox ID="txtDescripcionNuevo" CssClass="form-control" runat="server"></asp:TextBox>
                                        <div class="has-error">
                                            <asp:Label CssClass="control-label" ID="lblMensajeNuevo" runat="server" Visible="false" Text="">
                    <i class="fa fa-times-circle-o"></i> El Campo no puede estar vacio
                                            </asp:Label>
                                        </div>
                                    </div>
                                    <div class="modal-footer">
                                        <asp:Button CssClass="btn btn-primary" ID="GuardarNuevo" runat="server" Text="Guardar" OnClick="Nuevo_Click" />
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




