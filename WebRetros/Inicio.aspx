<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Inicio.aspx.cs" Inherits="Inicio" MasterPageFile="~/Site.master" %>


<asp:Content ContentPlaceHolderID="contentBody" runat="server" ID="contInicio">
 <!-- Content Wrapper. Contains page content -->
<div class="content-wrapper">
    <!-- Content Header (Page header) -->
    <section class="content-header">
        <h1>
        Inicio
        </h1>
        <ol class="breadcrumb">
        <li><a href="#"><i class="fa fa-home"></i> Inicio</a></li>
        </ol>
    </section>
    <section class="content">

        <div class="col-md-12">
          <div class="box box-solid">
            <div class="box-header with-border">
              <i class="fa fa-home"></i>

              <h3 class="box-title">Introducción</h3>
            </div>
            <!-- /.box-header -->
            <div class="box-body">
              <dl>
              
             <dd>Bienvenido <strong><asp:Label runat="server" ID="nombrecompleto"> </asp:Label> </strong>  al Sistema de Gestión de Minutas, aquí podrá encontrar una variedad de herramientas que le ayudaran a realizar este proceso.</dd>
              
          
              </dl>
            </div>
              </div>
            </div>
         <div class="col-md-12">
          <div class="box box-solid">
            <div class="box-header with-border">
              <i class="fa fa-flag"></i>

              <h3 class="box-title">Indicadores por Sesiones Creadas</h3>
            </div>
            <!-- /.box-header -->
            <div class="box-body">
              <dl>
                  <asp:repeater ID="RepeaterSesionesCreadas" runat="server" 
    >
  <HeaderTemplate>
    
  </HeaderTemplate>

  <ItemTemplate>
   
      <div class="col-lg-3 col-xs-6">
          <!-- small box -->
          <div class="small-box <%# DataBinder.Eval(Container.DataItem, "color") %>">
            <div class="inner">
              <h3><%# DataBinder.Eval(Container.DataItem, "Indicador") %></h3>

              <p><%# DataBinder.Eval(Container.DataItem, "nombrestatus") %></p>
            </div>
            <div class="icon">
              <i class="<%# DataBinder.Eval(Container.DataItem, "icono") %>"></i>
            </div>
          <!--  <a class="small-box-footer" href="#"><i class="fa fa-arrow-circle-right"></i></a>-->
          </div>
        </div>

     
   
  </ItemTemplate>

  <FooterTemplate>
  
  </FooterTemplate>
</asp:repeater>
              </dl>
          </div>
              </div>
            </div>
        <div class="col-md-12">
          <div class="box box-solid">
            <div class="box-header with-border">
              <i class="fa fa-flag"></i>

              <h3 class="box-title">Indicadores por Sesiones Asignadas</h3>
            </div>
            <!-- /.box-header -->
            <div class="box-body">
              <dl>
                  <asp:repeater ID="RepeaterSesionesAsignadas" runat="server" 
    >
  <HeaderTemplate>
    
  </HeaderTemplate>

  <ItemTemplate>
   
      <div class="col-lg-3 col-xs-6">
          <!-- small box -->
          <div class="small-box <%# DataBinder.Eval(Container.DataItem, "color") %>">
            <div class="inner">
              <h3><%# DataBinder.Eval(Container.DataItem, "Indicador") %></h3>

              <p><%# DataBinder.Eval(Container.DataItem, "nombrestatus") %></p>
            </div>
            <div class="icon">
              <i class="<%# DataBinder.Eval(Container.DataItem, "icono") %>"></i>
            </div>
             <!--  <a class="small-box-footer" href="#"><i class="fa fa-arrow-circle-right"></i></a>-->
          </div>
        </div>

     
   
  </ItemTemplate>

  <FooterTemplate>
  
  </FooterTemplate>
</asp:repeater>
              </dl>
          </div>
              </div>
            </div>
       

        <div class="col-md-12">
          <div class="box box-solid">
            <div class="box-header with-border">
              <i class="fa fa-flag"></i>

              <h3 class="box-title">Indicadores por Acuerdos</h3>
            </div>
            <!-- /.box-header -->
            <div class="box-body">
              <dl>
                  <asp:repeater ID="RepeaterIndicadores" runat="server" 
    >
  <HeaderTemplate>
    
  </HeaderTemplate>

  <ItemTemplate>
   
      <div class="col-lg-3 col-xs-6">
          <!-- small box -->
          <div class="small-box <%# DataBinder.Eval(Container.DataItem, "color") %>">
            <div class="inner">
              <h3><%# DataBinder.Eval(Container.DataItem, "Indicador") %></h3>

              <p><%# DataBinder.Eval(Container.DataItem, "nombrestatus") %></p>
            </div>
            <div class="icon">
              <i class="<%# DataBinder.Eval(Container.DataItem, "icono") %>"></i>
            </div>
            <!--  <a class="small-box-footer" href="#"><i class="fa fa-arrow-circle-right"></i></a>-->
          </div>
        </div>

     
   
  </ItemTemplate>

  <FooterTemplate>
  
  </FooterTemplate>
</asp:repeater>
              </dl>
          </div>
              </div>
            </div>
           
            
            <!-- /.box-body -->
            <div class="col-md-4">
<div class="box box-solid">
                  <div class="box-header with-border">
              <i class="fa fa-university"></i>

              <h3 class="box-title">Sede</h3>
            </div>
            <!-- /.box-header -->
            <div class="box-body" style="text-align:center">
              <dl>
              
             <dd><h4><asp:Label runat="server" ID="lblSede"> </asp:Label></h4></dd>
              
          
              </dl>
            </div>
            <!-- /.box-body -->


          </div>
         
                </div>
        <div class="col-md-4">
<div class="box box-solid">
                  <div class="box-header with-border">
              <i class="fa fa-building"></i>

              <h3 class="box-title">Departamento</h3>
            </div>
            <!-- /.box-header -->
            <div class="box-body" style="text-align:center">
              <dl>
              
             <dd><h4><asp:Label runat="server" ID="lblDepartamento"> </asp:Label></h4></dd>
              
          
              </dl>
            </div>
            <!-- /.box-body -->


          </div>
         
                </div>
        <div class="col-md-4">
<div class="box box-solid">
                  <div class="box-header with-border">
              <i class="fa fa-briefcase"></i>

              <h3 class="box-title">Puesto</h3>
            </div>
            <!-- /.box-header -->
            <div class="box-body" style="text-align:center">
              <dl>
              
             <dd><h4><asp:Label runat="server" ID="lblPuesto"> </asp:Label></h4></dd>
              
          
              </dl>
            </div>
            <!-- /.box-body -->


          </div>
         
                </div>
          
        
         
            <div class="col-md-12">
        <div class="callout callout-info">
                <h4>Nota</h4>

               <p>Es importante que mantenga al día sus acuerdos, para que sean cumplidos en tiempo y forma.</p>
              </div>
          <!-- /.box -->
        
      </div>
           <div class="col-md-12">
        <div class="callout callout-danger">
                <h4>Aviso</h4>

               <p>Usted es responsable de su usuario y contraseña, porfavor no comparta sus datos de acceso con otros usuarios.</p>
              </div>
          <!-- /.box -->
        
      </div>
        
     &nbsp;
 &nbsp;

       
    </section>
</div>
</asp:Content>