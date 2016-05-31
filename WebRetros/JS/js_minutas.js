﻿function pageLoad()
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

    

}

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