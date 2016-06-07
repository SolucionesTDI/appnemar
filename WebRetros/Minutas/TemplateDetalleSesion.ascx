<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TemplateDetalleSesion.ascx.cs" Inherits="Minutas_DetalleSesion" %>
<div class="wrapper">


    <!-- Content Header (Page header) -->
    
    <!-- Main content -->
    <section class="content">
      <div class="row">
        <div class="col-md-3">
          <!-- About Me Box -->
          <div class="box box-primary">
            <div class="box-header with-border">
              <h3 class="box-title">Resumen de Minuta</h3>
            </div>
            <!-- /.box-header -->
            <div class="box-body">
              <strong>Folio #FOLIOSESION#</strong>

              <hr>

              <strong>Estatus Gral</strong>
              <p class="text-muted">#STATUSMINUTA#</p>

              <hr>

              <strong> Fecha Registro</strong>
              <p class="text-muted">#FECHAREGISTRO#</p>
              
              <hr>

              <strong> Fecha Final Programada</strong>
              <p class="text-muted">#FECHAPROGRAMADA#</p>
              
              <hr>
              <strong> Fecha Conclusión</strong>
              <p class="text-muted">#FECHACONC#</p>
              
              <hr>
                <strong> Tipo Sesión</strong>
              <p class="text-muted">#TIPOSESION#</p>
              
              <hr>
                <strong> Registrador</strong>
              <p class="text-muted">#COACHING#</p>
              
              <hr>
                <strong> Detalle Entrega</strong>
              <p class="text-muted">#DETALLEENTREGA#</p>
              
              <hr>
            </div>
            <!-- /.box-body -->
          </div>
          <!-- /.box -->
        </div>
        <!-- /.col -->
        <div class="col-md-9">
          <div class="nav-tabs-custom">
            <ul class="nav nav-tabs">
              <li class="active"><a href="#detalles" data-toggle="tab">Detalles</a></li>
            </ul>
            <div class="tab-content">
              
              <!-- /.tab-pane -->
              <div class="active tab-pane" id="detalles">
                <ul class="timeline timeline-inverse">
                 
                  <li>
                    <i class="fa fa-envelope bg-blue"></i>

                    <div class="timeline-item">
                      <h3 class="timeline-header"><a href="#">Objetivo</a></h3>
                      <div class="timeline-body">
                       #OBJETIVO#
                      </div>
                    </div>
                  </li>
                  <!-- END timeline item -->
                  <!-- timeline item -->
                  <li>
                    <i class="fa fa-user bg-aqua"></i>

                    <div class="timeline-item">
                      <h3 class="timeline-header no-border"><a href="#">Descripción</a></h3>
                      <div class="timeline-body">
                       #DESCRIPCION#
                      </div>
                    </div>
                  </li>
               
                  <!-- END timeline item -->
                  <li>
                    <i class="fa fa-clock-o bg-gray"></i>
                  </li>
                </ul>
                
                #LISTAUSUARIOS#
              </div>
              <!-- /.tab-pane -->
            </div>
            <!-- /.tab-content -->
          </div>
          <!-- /.nav-tabs-custom -->
        </div>
        <!-- /.col -->
      </div>
      <!-- /.row -->

    </section>
    <!-- /.content -->

</div>