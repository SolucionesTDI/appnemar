<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TemplateMailMinuta.ascx.cs" Inherits="Minutas_TemplateMailMinuta" %>

<div style="margin:5px auto;width:680px;">
    <p>
        Hola #Usuario#, ha sido creada una nueva minuta con el Folio <b>#Foliominuta#</b>, 
        <br />
        Te presentamos los detalles a continuación:<br />
    </p>
    <hr />
    <p>
        <b>Fecha de Creación: </b>#Fechacreacion#<br />
        <b>Responsable: </b>#Usuariocreador#<br />
        <b>Tema asignado: </b>#Tematica#<br />
        <b>Fecha de Entrega: </b> #Fechaentrega#<br />
        <b>Tipo Sesión: </b>#Tiposesion#<br />
    </p>
    <hr />
    <h4><b>Objetivo</b></h4>
    <p>
        #Objetivo#
    </p>
    <h4><b>Descripción</b></h4>
    <p>
        #Descripcion#
    </p>
    <hr />
    <p>
        #Acuerdos#
    </p>
    <hr />
    <p>
        Es importante mantener todas sus actividades asignadas, dando seguimiento a las minutas en tiempo y forma.<br />
        Por favor, ingrese al <a href="http://201.157.52.148/retros/Login">sistema de minutas </a>para poder dar seguimiento a sus asignaciones.
    </p>
</div>