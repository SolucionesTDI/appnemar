<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Nuevaminuta.aspx.cs" Inherits="Minutas_Nuevaminuta" MasterPageFile="~/Site.master" %>

<asp:Content ContentPlaceHolderID="contentBody" runat="server" ID="contNuevaminuta">
   
    <div class="content-wrapper">
        <section class="content-header">
          <h1>
            Nueva Minuta
          </h1>
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-home"></i> Inicio</a></li>
            <li><a href="#">Minutas</a></li>
            <li class="active">nueva minuta</li>
          </ol>
        </section>
        <section class="content">
            <div class="box box-default">
                <div class="box-header with-border">
                  <h3 class="box-title">Paso 1. Registrar datos generales de la Sesión</h3>

                  <div class="box-tools pull-right">
                    <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                  </div>
                </div>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                <div class="box-body">
                    <asp:HiddenField ID="hd_idsesion" runat="server" />
                    <div class="row">
                        <div class="col-sm-12">
                            <div class="col-sm-8">
                                <div class="form-group">
                                    <label>Seleccionar Temática  </label>
                                    <div class="input-group">
                                      <asp:DropDownList CssClass="form-control select2" AutoPostBack="false" ID="ddltema" runat="server"></asp:DropDownList>
                                      <div class="input-group-addon">
                                        <span id="stema" class="fa fa-plus-circle addcat" data-titulo="Agregar Tema" data-tabla="temas"></span>
                                      </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-12">
                            <div class="box">
                                <div class="box-header">
                                  <h3 class="box-title">Objetivo
                                    <small>describa el objetivo de la sesión</small>
                                  </h3>
                                  <!-- tools box -->
                                  <div class="pull-right box-tools">
                                    <button type="button" class="btn btn-default btn-sm" data-widget="collapse" data-toggle="tooltip" title="minimizar">
                                      <i class="fa fa-minus"></i></button>
                                  </div>
                                  <!-- /. tools -->
                                </div>
                                <!-- /.box-header -->
                                <div class="box-body pad">
                                    <textarea id="txtobservaciones" runat="server" class="textarea" placeholder="Dato obligatorio" style="width: 100%; height: 200px; font-size: 14px; line-height: 18px; border: 1px solid #dddddd; padding: 10px;"></textarea>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-12">
                            <div class="box">
                                <div class="box-header">
                                  <h3 class="box-title">Descripción
                                    <small>anotaciones de los puntos de la sesión</small>
                                  </h3>
                                  <!-- tools box -->
                                  <div class="pull-right box-tools">
                                    <button type="button" class="btn btn-default btn-sm" data-widget="collapse" data-toggle="tooltip" title="minimizar">
                                      <i class="fa fa-minus"></i></button>
                                  </div>
                                  <!-- /. tools -->
                                </div>
                                <!-- /.box-header -->
                                <div class="box-body pad">
                                    <textarea id="txtdescripcion" runat="server" class="textarea" placeholder="Dato obligatorio" style="width: 100%; height: 200px; font-size: 14px; line-height: 18px; border: 1px solid #dddddd; padding: 10px;"></textarea>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-12">
                            <div class="col-sm-3">
                                <div class="form-group">
                                    <label>Fecha cierre planeada</label>
                                    <div class="input-group">
                                      <div class="input-group-addon">
                                        <i class="fa fa-calendar"></i>
                                      </div>
                                        <asp:TextBox ID="txtfechacierre" CssClass="form-control formatofecha" data-inputmask="'alias': 'dd/mm/yyyy'" data-mask runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-4">
                                <div class="form-group">
                                    <label>Tipo de Sesión</label>
                                    <asp:DropDownList ID="ddltiposesion" AutoPostBack="false" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnGuardarSesion" EventName="click" />
                    <asp:AsyncPostBackTrigger ControlID="btnaddParticipante" EventName="click" />
                    <asp:AsyncPostBackTrigger ControlID="btnfinalizar" EventName="click" />
                </Triggers>
                </asp:UpdatePanel>
                <div class="box-footer">
                    <asp:Button ID="btnGuardarSesion" CssClass="btn btn-success" OnClientClick="return validaMinuta()" OnClick="btnGuardarSesion_Click" runat="server" Text="Guardar Sesión" />
                </div> 
            </div>
            <div class="row">     
                <div class="col-sm-7">
                    <div class="box box-default">
                        <div class="box-header with-border">
                          <h3 class="box-title">Paso 2. Agregar Participante(s)</h3>
                          <div class="box-tools pull-right">
                            <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                          </div>
                        </div>
                        <div class="box-body">
                            <div class="row">
                                <div class="col-sm-12">
                                    <div class="col-sm-12">
                                        <div class="form-group">
                                            <label>Seleccionar Participante </label>
                                            <div class="input-group">
                                              <asp:UpdatePanel ID="UpdatePanel5" style="display:inline" runat="server">
                                                  <ContentTemplate>
                                              <asp:DropDownList CssClass="form-control select2" ID="ddlparticipantes" AutoPostBack="false" runat="server"></asp:DropDownList>
                                              </ContentTemplate>
                                              <Triggers>
                                                  <asp:AsyncPostBackTrigger ControlID="btnaddParticipante" EventName="click" />
                                                  <asp:AsyncPostBackTrigger ControlID="btnGuardarSesion" EventName="click" />
                                                  <asp:AsyncPostBackTrigger ControlID="btnfinalizar" EventName="click" />
                                              </Triggers>
                                              </asp:UpdatePanel>
                                                    <div class="input-group-btn">
                                                  <asp:Button ID="btnaddParticipante" CssClass="btn btn-info" OnClick="btnaddParticipante_Click" OnClientClick="return validarparticipante()" runat="server" Text="Agregar" />
                                              </div>
                                            </div>
                                        </div>
                                    </div>
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                    <div class="col-sm-12 clearfix">
                                        <div class="table-responsive">
                                        <asp:GridView CssClass="table table-striped datagrid" ID="gdvParticipantes" runat="server"
                                             AutoGenerateColumns="false" AllowPaging="false" DataKeyNames="IdSesionUser,IdUserMinuta" 
                                             OnRowDeleting="gdvParticipantes_RowDeleting"
                                             OnRowDataBound="gdvParticipantes_RowDataBound">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Marcar">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chksel" CssClass="flat-red seluser" AutoPostBack="false" runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Participante">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="lblusuario"><%# DataBinder.Eval(Container.DataItem, "ObjUsuarios.NombreCompleto")%></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Acciones" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="40">
                                                    <ItemTemplate>
                                                        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                            <ContentTemplate>
                                                                <asp:LinkButton CommandName="Delete" OnClientClick="if(confirm('Está seguro de eliminar al participante ?')){return true}else{return false}" CssClass="col-sm-1" ToolTip="Eliminar" data-toogle="tooltip"
                                                                    ID="btndelcancel" runat="server">
                                                                                <span class="glyphicon glyphicon-trash" aria-hidden="true"></span> 
                                                                </asp:LinkButton>
                                                            </ContentTemplate>
                                                            <Triggers>
                                                                <asp:AsyncPostBackTrigger ControlID="btndelcancel" EventName="click" />
                                                            </Triggers>
                                                        </asp:UpdatePanel>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td colspan="100%">
                                                                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                                    <ContentTemplate>
                                                                <div class="table-responsive">
                                                                    <asp:GridView BorderWidth="0" CssClass="datagrid table table-striped" ID="gdvAcuerdo" runat="server"
                                                                             AutoGenerateColumns="false" AllowPaging="false" DataKeyNames="IdAcuerdo,IdUserMinuta" 
                                                                             OnRowDeleting="gdvAcuerdo_RowDeleting" >
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="Fecha Inicial">
                                                                                <ItemTemplate>
                                                                                    <asp:Label runat="server" ID="lblini"><%# DataBinder.Eval(Container.DataItem, "FechaIni","{0:d}")%></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Fecha Final">
                                                                                <ItemTemplate>
                                                                                    <asp:Label runat="server" ID="lblfin"><%# DataBinder.Eval(Container.DataItem, "FechaFin","{0:d}")%></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Descripcion">
                                                                                <ItemTemplate>
                                                                                    <asp:Label runat="server" ID="lbldescrip"><%# DataBinder.Eval(Container.DataItem, "Descripcion")%></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Acciones" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="40">
                                                                                <ItemTemplate>
                                                                                    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                                                <ContentTemplate>
                                                                                    <asp:LinkButton CommandName="Delete" OnClientClick="if(confirm('Está seguro de eliminar el acuerdo ?')){return true}else{return false}" CssClass="col-sm-1" ToolTip="Eliminar" data-toogle="tooltip"
                                                                                        ID="btndelacuerdo" runat="server">
                                                                                                    <span class="glyphicon glyphicon-trash" aria-hidden="true"></span> 
                                                                                    </asp:LinkButton>
                                                                                  <%--  <asp:LinkButton CommandName="Edit"
                                                                                        CssClass="col-sm-1" ToolTip="Editar Acuerdo" data-toogle="tooltip"
                                                                                        ID="linkeditar" runat="server">
                                                                                                    <span class="fa fa-pencil" aria-hidden="true"></span> 
                                                                                    </asp:LinkButton>--%>
                                                                                </ContentTemplate>
                                                                                    <Triggers>
                                                                                        <asp:AsyncPostBackTrigger ControlID="btndelacuerdo" EventName="click" />
                                                                                         <%-- <asp:AsyncPostBackTrigger ControlID="linkeditar" EventName="click" />--%>
                                                                                    </Triggers>
                                                                                </asp:UpdatePanel>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                    </asp:GridView>
                                                                </div>
                                                                </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                        </div>
                                    </div>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="btnGuardarSesion" EventName="click" />
                                        <asp:AsyncPostBackTrigger ControlID="btnaddParticipante" EventName="click" />
                                        <asp:AsyncPostBackTrigger ControlID="btnGuardarAcuerdo" EventName="click" />
                                        <asp:AsyncPostBackTrigger ControlID="btnfinalizar" EventName="click" />
                                    </Triggers>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </div>
                        
                        <div class="box-footer">
                            <p class="text-yellow">Seleccione al menos un participante para poder agregar los acuerdos</p>
                        </div> 
                    </div>
                </div>
                <div class="col-sm-5">
                     <div class="box box-default">
                        <div class="box-header with-border">
                          <h3 class="box-title">Paso 3. Acuerdos de Mejora Continua</h3> 
                            <span class="fa fa-question-circle ayudamodal" data-msj="Puede agregar un mismo acuerdo para mas de un participante.<br> Para ésto marque en la lista a los participantes previamente agregados y luego registre el acuerdo." ></span>
                          <div class="box-tools pull-right">
                            <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                          </div>
                        </div>
                         <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                             <ContentTemplate>
                                 <div class="box-body">
                                    <div class="row">
                                        <div class="col-sm-12">
                                            <div class="col-sm-12">
                                                <div class="form-group">
                                                    <label>Fecha inicial y final</label>
                                                    <div class="input-group">
                                                        <asp:TextBox ID="txtfechai_b" MaxLength="10" data-inputmask="'alias': 'dd/mm/yyyy'" data-mask CssClass="form-control formatofecha" runat="server"></asp:TextBox>
                                                        <span class="input-group-addon"><i class="glyphicon glyphicon-calendar"></i></span>
                                                        <asp:TextBox ID="txtfechaf_b" MaxLength="10" data-inputmask="'alias': 'dd/mm/yyyy'" data-mask CssClass="form-control formatofecha" runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-sm-12 clearfix">
                                                <div class="form-group">
                                                    <label>Descripción del acuerdo</label>
                                                    <asp:TextBox ID="txtdescripcionacuerdo" CssClass="form-control" Rows="3" TextMode="MultiLine" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                             </ContentTemplate>
                             <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="btnGuardarSesion" EventName="click" />
                                <asp:AsyncPostBackTrigger ControlID="btnaddParticipante" EventName="click" />
                                <asp:AsyncPostBackTrigger ControlID="btnGuardarAcuerdo" EventName="click" />
                                 <asp:AsyncPostBackTrigger ControlID="btnfinalizar" EventName="click" />
                            </Triggers>
                         </asp:UpdatePanel>
                        
                        <div class="box-footer">
                            <asp:Button ID="btnGuardarAcuerdo" CssClass="btn btn-success" OnClientClick="return validaAcuerdo()" OnClick="btnGuardarAcuerdo_Click" runat="server" Text="Guardar Acuerdo" />
                        </div> 
                    </div>
                </div>
            </div> 

           <div class="row">
                <div class="col-sm-12">
                    <div class="alert alert-info">
                        <asp:Button ID="btnfinalizar" CssClass="btn btn-warning"  OnClick="btnfinalizar_Click" runat="server" Text="Finalizar y Enviar Notificación" />
                    </div>
                </div>
            </div>
        </section>
    </div>

        <div class="modal modal-success modalfinsesion">
          <div class="modal-dialog">
            <div class="modal-content">
              <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                  <span aria-hidden="true">&times;</span></button>
                <h4 class="modal-title">Acción Finalizada</h4>
              </div>
              <div class="modal-body">
                <p>Se ha notifacado de la nueva minuta a los participantes!</p>
              </div>
              <div class="modal-footer">
                  <asp:Button ID="btnreload" CssClass="btn btn-outline pull-left"  OnClick="btnreload_Click" runat="server" Text="Iniciar nueva minuta" />
                  <asp:Button ID="btnirahistorial" CssClass="btn btn-outline"  OnClick="btnirahistorial_Click" runat="server" Text="Ir al Historial" />
              </div>
            </div>
            <!-- /.modal-content -->
          </div>
          <!-- /.modal-dialog -->
        </div>
        <!-- /.modal -->


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
                                     <table class="table table-bordered table-hover" border='1' style='border-collapse:collapse;border:1px solid #99CCCC;color:#000000;width:100%' cellpadding='5' cellspacing='1'>
                                        <thead>
                                            <tr style='background-color:#EAEAEA;'>
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

    <script src="<%=ResolveClientUrl("~/JS/js_minutas.js") %>" type="text/javascript"></script>
    
</asp:Content>