<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Seguimiento.aspx.cs" Inherits="Minutas_Seguimiento" MasterPageFile="~/Site.master" %>

<asp:Content ContentPlaceHolderID="contentBody" runat="server" ID="contSeguimientos">
    <div class="content-wrapper">
        <section class="content-header">
          <h1>
            Seguimiento de Minuta
          </h1>
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-home"></i> Inicio</a></li>
            <li><a href="#">Minutas</a></li>
            <li class="active">Seguimiento de minuta</li>
          </ol>
        </section>
        <section class="content">
            <div class="box box-default">
                <div class="box-header with-border">
                  <h3 class="box-title">Datos Generales de la Minuta</h3>
                  <div class="box-tools pull-right">
                    <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                  </div>
                </div>
                
                <div class="box-body">
                    <div class="row">
                        <div class="col-sm-12">
                            <div class="col-sm-3">
                                <div class="form-group">
                                    <label>Folio Minuta  </label>
                                    <div class="input-group">
                                      <asp:TextBox runat="server" ID="txtfoliominuta" CssClass="form-control"></asp:TextBox>
                                      <div class="input-group-btn">
                                          <asp:Button ID="btnCargarDatos" OnClick="btnCargarDatos_Click" CssClass="btn btn-info" Text="Buscar" ToolTip="Buscar Folio" runat="server"  />
                                      </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div class="col-sm-12">
                                <div class="box">
                                    <div class="box-header">
                                      <h3 class="box-title">Objetivo </h3>
                                      <!-- tools box -->
                                      <div class="pull-right box-tools">
                                        <button type="button" class="btn btn-default btn-sm" data-widget="collapse" data-toggle="tooltip" title="minimizar">
                                          <i class="fa fa-minus"></i></button>
                                      </div>
                                      <!-- /. tools -->
                                    </div>
                                    <!-- /.box-header -->
                                    <div class="box-body pad">
                                        <asp:Label runat="server" ID="lblobjetivos"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-12">
                                <div class="box">
                                    <div class="box-header">
                                      <h3 class="box-title">Descripción </h3>
                                      <!-- tools box -->
                                      <div class="pull-right box-tools">
                                        <button type="button" class="btn btn-default btn-sm" data-widget="collapse" data-toggle="tooltip" title="minimizar">
                                          <i class="fa fa-minus"></i></button>
                                      </div>
                                      <!-- /. tools -->
                                    </div>
                                    <!-- /.box-header -->
                                    <div class="box-body pad">
                                        <asp:Label runat="server" ID="lbldescripcion"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-12">
                                <div class="col-sm-4">
                                    <div class="form-group">
                                        <label>Fecha cierre planeada</label>
                                        <div class="input-group">
                                          <div class="input-group-addon">
                                            <i class="fa fa-calendar"></i>
                                          </div>
                                            <asp:TextBox ID="txtfechacierre" CssClass="form-control" Enabled="false" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <div class="form-group">
                                        <label>Tipo de Sesión</label>
                                        <asp:TextBox ID="txttiposesion" CssClass="form-control" Enabled="false" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnCargarDatos" EventName="click" />
                        </Triggers>
                        </asp:UpdatePanel>
                        </div>
                </div>
            </div>
            <div class="row">     
                <div class="col-sm-12">
                    <div class="box box-default">
                        <div class="box-header with-border">
                          <h3 class="box-title">Acuerdos establecidos</h3>
                          <div class="box-tools pull-right">
                            <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                          </div>
                        </div>
                        
                        <div class="box-body">
                            <div class="row">
                                <div class="col-sm-12">
                                    <asp:ListView runat="server" ID="ltvUsuariosSesion" DataKeyNames="IdSesionUser,IdUserMinuta"
                                      OnItemDataBound="ltvUsuariosSesion_ItemDataBound" >
                                        <LayoutTemplate >
                                            <div class="row">
                                                <div class="col-sm-12">
                                                    <div class="box box-solid">
                                                        <div class="box-header with-border">
                                                          <h3 class="box-title">Participantes</h3>
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
                                                   <asp:ListView runat="server" ID="ltvAcuerdos" DataKeyNames="IdAcuerdo,IdUserMinuta"
                                                      OnItemDataBound="ltvAcuerdos_ItemDataBound"   >
                                                       <LayoutTemplate >
                                                            <div class="row">
                                                                <div class="col-sm-12">
                                                                    <div class="table-responsive">
                                                                         <table class="table table-bordered table-striped">
                                                                            <thead>
                                                                                <tr>
                                                                                    <th>Fecha inicial planeada</th>
                                                                                    <th>Fecha final planeada</th>
                                                                                    <th>Descripción</th>
                                                                                    <th>Estatus Actual</th>
                                                                                    <th>Tiempo entrega</th>
                                                                                    <th>Fecha inicial real</th>
                                                                                    <th>Fecha final real</th>
                                                                                    <th width="120">Opciones</th>
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
                                                               <td><%#DataBinder.Eval(Container.DataItem, "FechaIniReal","{0:d}")%></td>
                                                               <td><%#DataBinder.Eval(Container.DataItem, "FechaFinReal","{0:d}")%></td>
                                                               <td>
                                                                   <div class="btn-group">
                                                                    
                                                                    <asp:LinkButton CssClass="btn btn-warning btn-sm" runat="server" ID="linkiniciar" ToolTip="Iniciar Acuerdo" data-toggle="tooltip" 
                                                                       CommandName="IniciarAcuerdo" CommandArgument="<%# ((ListViewDataItem) Container).DataItemIndex %>"
                                                                        OnClientClick="if(confirm('Ésta acción ingresará la fecha inicial real\nEstá seguro?')){return true}else{return false}" >
                                                                        <span class="fa fa-check-square-o" aria-hidden="true"></span> 
                                                                    </asp:LinkButton>
                                                  
                                                                    </div>
                                                               </td>
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
                                </div>
                            </div>
                        </div>
                        
                        <div class="box-footer">
                        </div> 
                    </div>
                </div>
                
            </div> 

           
        </section>
    </div>
    <script src="<%=ResolveClientUrl("~/JS/js_minutas.js") %>" type="text/javascript"></script>
 </asp:Content>