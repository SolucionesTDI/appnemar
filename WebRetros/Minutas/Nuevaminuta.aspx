<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Nuevaminuta.aspx.cs" Inherits="Minutas_Nuevaminuta" MasterPageFile="~/Site.master" %>

<asp:Content ContentPlaceHolderID="contentBody" runat="server" ID="contNuevaminuta">
    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
        <ProgressTemplate>
            <div class="col-md-12">
              <div class="box box-info box-solid">
                <div class="box-header">
                  <h3 class="box-title">Procesando información. </h3>
                </div>
                <div class="box-body">
                  Espere un momento porfavor...
                </div>
                <div class="overlay">
                  <i class="fa fa-refresh fa-spin"></i>
                </div>
              </div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
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
                  <h3 class="box-title">Registro de Minuta</h3>

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
                                      <asp:DropDownList CssClass="form-control select2" ID="ddltema" runat="server"></asp:DropDownList>
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
                                    <small>anotaciones de los puntos de la minuta</small>
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
                            <div class="col-sm-2">
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
                                    <asp:DropDownList ID="ddltiposesion" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnGuardarSesion" EventName="click" />
                </Triggers>
                </asp:UpdatePanel>
                <div class="box-footer">
                    <asp:Button ID="btnGuardarSesion" CssClass="btn btn-success" OnClientClick="return validaMinuta()" OnClick="btnGuardarSesion_Click" runat="server" Text="Crear Sesión" />
                </div> 
            </div>
        </section>
    </div>
    <script src="<%=ResolveClientUrl("~/JS/js_minutas.js") %>" type="text/javascript"></script>
 
</asp:Content>