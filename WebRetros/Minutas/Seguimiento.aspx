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
        <div class="modal fade" id="modalComentarios" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
          <div class="modal-dialog">
            <div class="modal-content">
              <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                  <span aria-hidden="true">&times;</span></button>
                <h4 class="modal-title">Comentarios</h4>
              </div>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                      <div class="modal-body">
                            <div class="row">
                                <div class="col-sm-12">
                                    <asp:HiddenField runat="server" ID="hd_idacuerdo" />
                                        <div class="col-sm-12">
                                            <div class="form-group">
                                                <label>Añadir comentario</label>
                                                <asp:TextBox ID="txtcomentario_acuerdo" TextMode="MultiLine" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                </div>
                            </div>
                      </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnguardarcomentario" EventName="click" />
                    </Triggers>
                </asp:UpdatePanel>
              <div class="modal-footer">
                <asp:Button ID="btnguardarcomentario" OnClientClick="return validarcomentarioacuerdo()" OnClick="btnguardarcomentario_Click" CssClass="btn btn-success" runat="server" Text="Guardar comentario" />
              </div>
            </div>
            <!-- /.modal-content -->
          </div>
          <!-- /.modal-dialog -->
        </div>

        <div class="modal fade" id="modalstatus" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
          <div class="modal-dialog">
            <div class="modal-content">
              <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                  <span aria-hidden="true">&times;</span></button>
                <h4 class="modal-title">Actualizar Estatus</h4>
              </div>
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                      <div class="modal-body">
                            <div class="row">
                                <div class="col-sm-12">
                                    <asp:HiddenField runat="server" ID="hdacuerdo_status" />
                                    <div class="col-sm-12">
                                        <div class="form-group">
                                            <label>Asignar Estatus</label>
                                            <asp:DropDownList ID="ddlstatuscambia" CssClass="form-control" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                            </div>
                      </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnActualizarStatus" EventName="click" />
                    </Triggers>
                </asp:UpdatePanel>
              <div class="modal-footer">
                <asp:Button ID="btnActualizarStatus"  OnClick="btnActualizarStatus_Click" CssClass="btn btn-success" runat="server" Text="Actualizar Estatus" />
              </div>
            </div>
            <!-- /.modal-content -->
          </div>
          <!-- /.modal-dialog -->
        </div>
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
                            <asp:AsyncPostBackTrigger ControlID="btnguardarcomentario" EventName="click" />
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
                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                        <ContentTemplate>
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
                                                           <asp:ListView runat="server" ID="ltvAcuerdos" DataKeyNames="IdAcuerdo,IdUserMinuta "
                                                              OnItemDataBound="ltvAcuerdos_ItemDataBound" OnItemCommand="ltvAcuerdos_ItemCommand"  >
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
                                                                            <asp:UpdatePanel ID="UpdatePanel5" style="display:inline" runat="server">
                                                                                <ContentTemplate>
                                                                            <asp:LinkButton CssClass="btn btn-warning btn-sm" runat="server" ID="linkiniciar" ToolTip="Iniciar Acuerdo" data-toggle="tooltip" 
                                                                               CommandName="IniciarAcuerdo" CommandArgument="<%# ((ListViewDataItem) Container).DataItemIndex %>"
                                                                                OnClientClick="if(confirm('Ésta acción ingresará la fecha inicial real\nEstá seguro?')){return true}else{return false}" >
                                                                                <span class="fa fa-check-square-o" aria-hidden="true"></span> 
                                                                            </asp:LinkButton>
                                                                            <asp:LinkButton CssClass="btn btn-info btn-sm" runat="server" ID="linkupdestatus" ToolTip="Actualizar Estatus" data-toggle="tooltip" 
                                                                               CommandName="ActualizarStatus" CommandArgument="<%# ((ListViewDataItem) Container).DataItemIndex %>" >
                                                                                <span class="fa fa-refresh" aria-hidden="true"></span> 
                                                                            </asp:LinkButton>
                                                                                    </ContentTemplate>
                                                                                    <Triggers>
                                                                                        <asp:AsyncPostBackTrigger ControlID="linkiniciar" EventName="click" />
                                                                                        <asp:AsyncPostBackTrigger ControlID="linkupdestatus" EventName="click" />
                                                                                    </Triggers>
                                                                                </asp:UpdatePanel>
                                                                            <button data-idacuerdo='<%#DataBinder.Eval(Container.DataItem, "IdAcuerdo")%>' type="button" class="btn btn-info btn-sm addcomentario">
                                                                                <span class="fa fa-commenting" aria-hidden="true"></span> 
                                                                            </button>
                                                                                    
                                                                            </div>
                                                                       </td>
                                                                   </tr>
                                                                   <tr>
                                                                       <td colspan="8">
                                                                           <asp:ListView runat="server" ID="ltvComentariosAcuerdos" DataKeyNames="Idcomentario" >
                                                                               <LayoutTemplate > 
                                                                               <div class="row">
                                                                                    <div class="col-sm-12">
                                                                                        <div class="table-responsive">
                                                                                             <table class=" table table-striped">
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
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="btnCargarDatos" EventName="click" />
                                            <asp:AsyncPostBackTrigger ControlID="btnguardarcomentario" EventName="click" />
                                        </Triggers>
                                    </asp:UpdatePanel>

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