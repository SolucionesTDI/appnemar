<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Historial.aspx.cs" Inherits="Minutas_Historial" MasterPageFile="~/Site.master" %>

<asp:Content ContentPlaceHolderID="contentBody" runat="server" ID="contNuevaminuta">
    <div class="content-wrapper">
        <section class="content-header">
          <h1>
            Historial de Minutas
          </h1>
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-home"></i> Inicio</a></li>
            <li><a href="#">Minutas</a></li>
            <li class="active">Historial</li>
          </ol>
        </section>
        <section class="content">
            <div class="box box-default">
                <div class="box-header with-border">
                  <h3 class="box-title">Filtros Personalizados</h3>
                  <div class="box-tools pull-right">
                    <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                  </div>
                </div>
                <div class="box-body">
                    <div class="col-sm-12">
                        <div class="col-sm-3">
                            <asp:ListBox CssClass="form-control input-sm ddlmulti" ID="ddltemas_b" SelectionMode="Multiple" runat="server"></asp:ListBox>
                        </div>
                        <div class="col-sm-3">
                            <asp:ListBox CssClass="form-control input-sm ddlmulti" ID="ListBox1" SelectionMode="Multiple" runat="server"></asp:ListBox>
                        </div>
                        <div class="col-sm-3">
                            <asp:ListBox CssClass="form-control input-sm ddlmulti" ID="ListBox2" SelectionMode="Multiple" runat="server"></asp:ListBox>
                        </div>
                    </div>
                    
                </div>
                <div class="box-footer">
                    <asp:Button ID="btnbuscarfiltros" OnClick="btnbuscarfiltros_Click" CssClass="btn btn-success" runat="server" Text="Filtrar" />
                </div>
            </div>
            <div class="box box-info">
                <div class="box-header with-border">
                  <h3 class="box-title">Minutas Registradas</h3>
                  <div class="box-tools pull-right">
                    <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                  </div>
                </div>
                <div class="box-body">
                    <div class="col-sm-12">
                        <asp:UpdatePanel ID="updMinutasGrid" runat="server">
                            <ContentTemplate>
                            <div class="table-responsive">
                                <asp:GridView ID="gdvMinutas" runat="server" CssClass="table table-striped " AllowPaging="True" PageSize="20"
                                        AutoGenerateColumns="False" EmptyDataText="No se encontraron minutas registradas"
                                    onpageindexchanging="gdvMinutas_PageIndexChanging" OnRowDataBound="gdvMinutas_RowDataBound" 
                                    OnRowCommand="gdvMinutas_RowCommand"
                                    DataKeyNames="IdSesion"  >
                                    <Columns>
                                        <asp:TemplateField HeaderText="Opciones" HeaderStyle-Width="80" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" Visible="true">
                                            <ItemTemplate>
                                                <asp:HyperLink runat="server" ID="linkseguimiento" ToolTip="Seguimiento"  data-toggle="tooltip" Target="_blank" >
                                                    <span class="fa fa-share-square-o" aria-hidden="true"></span> 
                                                </asp:HyperLink>
                                                <asp:HyperLink runat="server" ID="linkresumen" ToolTip="Ver Resumen"  data-toggle="tooltip" Target="_blank" >
                                                    <span class="fa fa-sticky-note" aria-hidden="true"></span> 
                                                </asp:HyperLink>
                                                <asp:HyperLink runat="server" ID="linkeliminar" ToolTip="Eliminar Minuta" data-toggle="tooltip" Target="_blank" >
                                                    <span class="fa fa-trash" aria-hidden="true"></span> 
                                                </asp:HyperLink>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Folio" Visible="true">
                                            <ItemTemplate>
                                                <asp:Label ID="lblfolio" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "IdSesion","{0,22:D8}") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Fecha Registro" Visible="true">
                                            <ItemTemplate>
                                                <asp:Label ID="lblfecharegistro" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Fecharegistro","{0:d}") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Fecha Final Programada" Visible="true">
                                            <ItemTemplate>
                                                <asp:Label ID="lblfechaconclusiion" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Fechafin","{0:d}")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Tema Minuta" Visible="true">
                                            <ItemTemplate>
                                                <asp:Label ID="lbltemaminuta" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ObjTemas.descripcion")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Tipo Sesión" Visible="true">
                                            <ItemTemplate>
                                                <asp:Label ID="lbltiposesion" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ObjTipoSesion.TipoSesion")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Coaching" Visible="true">
                                            <ItemTemplate>
                                                <asp:Label ID="lblusuario" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ObjUsuarios.NombreUser")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Status General" Visible="true">
                                            <ItemTemplate>
                                                <asp:Label ID="lblstatusgral" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ObjStatus.nomstatus")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Detalle de entrega " Visible="true">
                                            <ItemTemplate>
                                                <asp:Label ID="lbldetalleentrega" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "LabelDias")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Cumplimiento" Visible="true">
                                            <ItemTemplate>
                                                <asp:Label ID="lblcumplimiento" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TiempoEntrega")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <PagerTemplate>
                                        <asp:UpdatePanel ID="updgriddoc" runat="server" style="display:inline">
                                            <ContentTemplate>
                                                Página 
                                                <asp:DropDownList ID="pageMinutasDropDownList" OnSelectedIndexChanged="pageMinutasDropDownList_SelectedIndexChanged" AutoPostBack="true" runat="server"></asp:DropDownList>
                                                de
                                                <asp:Label ID="lblTotalNumberOfPagesMinutas" runat="server" />
                                                &nbsp;&nbsp;
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="pageMinutasDropDownList" EventName="SelectedIndexChanged" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                        <asp:Button ID="Button4" runat="server" CommandName="Page" ToolTip="Prim. Pag"  CommandArgument="First" CssClass="pagfirst" />                    
                                        <asp:Button ID="Button1" runat="server" CommandName="Page" ToolTip="Pág. anterior"  CommandArgument="Prev" CssClass="pagprev" />
                                        <asp:Button ID="Button2" runat="server" CommandName="Page" ToolTip="Sig. página" CommandArgument="Next" CssClass="pagnext" />                    
                                        <asp:Button ID="Button3" runat="server" CommandName="Page" ToolTip="Últ. Pag"  CommandArgument="Last" CssClass="paglast" />
                                    </PagerTemplate>
                                    <SelectedRowStyle CssClass="selectedrow" />
                                    <PagerStyle CssClass="pagerstyle" />
                                    <AlternatingRowStyle CssClass="altrow" />
                                </asp:GridView>
                            </div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="btnbuscarfiltros" EventName="click" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                    
                </div>
                <div class="box-footer">
                </div>
            </div>
        </section>
    </div>
    <script src="<%=ResolveClientUrl("~/JS/js_minutas.js") %>" type="text/javascript"></script>
</asp:Content>