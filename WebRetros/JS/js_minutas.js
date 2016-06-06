function pageLoad()
{
        
    $(".textarea").wysihtml5({
        toolbar: {
            "font-styles": true, //Font styling, e.g. h1, h2, etc. Default true
            "emphasis": true, //Italics, bold, etc. Default true
            "lists": true, //(Un)ordered lists, e.g. Bullets, Numbers. Default true
            "html": false, //Button which allows you to edit the generated HTML. Default false
            "link": true, //Button to insert a link. Default true
            "image": false, //Button to insert an image. Default true,
            "color": false, //Button to change color of font  
            "blockquote": true, //Blockquote  
        }
    });

    $(".select2").select2();

    $(".formatofecha").inputmask("dd/mm/yyyy", { "placeholder": "dd/mm/yyyy" });
    
    $("[data-mask]").inputmask();

    $('input[type="checkbox"].flat-red, input[type="radio"].flat-red').iCheck({
      checkboxClass: 'icheckbox_flat-green',
      radioClass: 'iradio_flat-green'
    });

    

}

$(document).ready(function () {
    $(".ddlmulti").multiselect();
})

function validaMinuta()
{
    var msj = "";

    if($("#ddltema").val()=="0")
    {
        msj += "<div class='alert alert-warning'>Seleccione un tema de la minuta</div>";
    }

    if ($.trim($("#txtobservaciones").val()) == "")
    {
        msj += "<div class='alert alert-warning'>Describa los objetivos de la minuta</div>";
    }

    if ($.trim($("#txtdescripcion").val()) == "") {
        msj += "<div class='alert alert-warning'>Agregue una descripción breve</div>";
    }

    if ($("#txtfechacierre").val() == "") {
        msj += "<div class='alert alert-warning'>Indique la fecha de cierre planeada</div>";
    }

    if ($("#ddltiposesion").val() == "0") {
        msj += "<div class='alert alert-warning'>Seleccione el tipo de sesion a crear</div>";
    }

    if(msj!="")
    {
        bootbox.alert(msj);
        return false;
    }
    else
    {
        return true;
    }
}

function validarparticipante()
{
    var msj = "";
    if ($("#hd_idsesion").val() == "") {
        msj += "<div class='alert alert-warning'>Antes de ingresar a los participantes es necesario crear la sesión</div>";
    }
    
    if ($("#ddlparticipantes").val() == "0" || $("#ddlparticipantes").val() == "") {
        msj += "<div class='alert alert-warning'>Seleccione un participante válido</div>";
    }

    if (msj != "") {
        bootbox.alert(msj);
        return false;
    }
    else {
        return true;
    }
}

function validaAcuerdo()
{
    var msj = "";
    if ($("#txtfechai_b").val() == "" || $("#txtfechaf_b").val() == "") {
        msj += "<div class='alert alert-warning'>Ingrese un rango de fecha válido</div>";
    }

    if ($("#txtdescripcionacuerdo").val() == "" ) {
        msj += "<div class='alert alert-warning'>Agregue la descripción del acuerdo</div>";
    }

    if (msj != "") {
        bootbox.alert(msj);
        return false;
    }
    else {
        return true;
    }
}
