$(document).ready(
    function () {
        CargaInicial();
    }
);

function CargaInicial() {
    ObtieneDestinos();
    $(".rate").rate();
}

function ObtieneDestinos() {
    var url = $('#urlInicioComunidad').val();
    $.ajax({
        url: url,
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        success: successObtieneDestinos,
        error: function (xmlHttpRequest, textStatus, errorThrown) {
            MensajeError(data.Mensaje);
            //alert('error');
            OcultaCarga();
        }
    });
}

function successObtieneDestinos(data) {
    if (data.Exito) {
        var valact = 0;
        $.each(data.LsDestinos, function (i) {
            $.each(data.LsDestinos[i], function (key, val) {
                if ($.isNumeric(val))
                    valact = val;
                else {
                    $('#selDestinos')
                        .append($("<option></option>")
                            .attr("value", valact)
                            .text(val));
                }
            });            
        });
        GeneraComentarios(data.LsComunidad);
        OcultaCarga();
    } else {
        MensajeError('Ha ocurrido un error inesperado');
        OcultaCarga();
    }
}

function GeneraComentarios(Comunidad) {
    //function CreaComentario(Nombre, Destino, Testimonio, Calificacion, Fecha) {
    $('#dvTestimonios').empty();
    $.each(Comunidad, function (i) {
        $('#dvTestimonios').append(
            CreaComentario(Comunidad[i]["Nom"], Comunidad[i]["Des"], Comunidad[i]["Tes"], Comunidad[i]["Cal"], Comunidad[i]["FR"], Comunidad[i]["Img"])
        );
        $(".rate").rate();
    });
}

$(document).on("click", "#btnComparte", function (e) {
    if ($('#selDestinos').val() != 0 && $('.txExp').val() != "") {

        let datosComunidad = new FormData();
        //DatosFirma.append("DescripcionUno", $('.filedata1').val());
        datosComunidad.append("ImgDestino", $('#inArchivo').prop("files")[0]);
        datosComunidad.append("IdViaje", $('#selDestinos').val());
        datosComunidad.append("sNombre", $('.inNombre').val());
        datosComunidad.append("sTestimonio", $('.txExp').val());
        datosComunidad.append("iCalificacion", $(".rate").rate("getValue"));

        /*
        var datosComunidad = {
            IdViaje: $('#selDestinos').val(),
            sNombre: $('.inNombre').val(),
            sTestimonio: $('.txExp').val(),
            iCalificacion: $(".rate").rate("getValue")
        };*/
        InsertaComunidad(datosComunidad);
        OcultaCarga();
    } else {
        MensajeAdvertencia("No ha llenado algunos de los cámpos.");
        OcultaCarga();
    }
});

function InsertaComunidad(datosComunidad) {
    var url = $('#urlInsertaComunidad').val();
    /*$.ajax({
        url: url,
        type: "POST",
        data: JSON.stringify({ Comunidad }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        success: successInsertaComunidad,
        error: function (xmlHttpRequest, textStatus, errorThrown) {
            //MensajeError(data.Mensaje);
            MensajeError('Ha ocurrido un error inesperado');
        }
    });*/
    $.ajax({
        url: url,
        data: datosComunidad,
        type: "POST",
        contentType: false,
        processData: false,
        // dataType: "json",
        async: true,
        success: successInsertaComunidad,
        error: function (xmlHttpRequest, textStatus, errorThrown) {
            MensajeError(errorThrown);
            OcultaCarga();
        }
    });
}

function successInsertaComunidad(data) {
    if (data.Exito) {
        $('#selDestinos').val('0');
        $('.inNombre').val('');
        $('.txExp').val('');
        $(".rate").rate("setValue");
        MensajeExito("Gracias por sus comentarios.");
        CargaInicial();
        OcultaCarga();
    } else {
        MensajeError('Ha ocurrido un error inesperado');
        OcultaCarga();
    }
}

function CreaComentario(Nombre, Destino, Testimonio,Calificacion,Fecha,Img) {
    if (Nombre != "")
        Nombre = Nombre + " - ";
    var dvComentario = "<div class='jumbotron jumbotron-fluid'>" +
        "<div class='container col-12'>" +
        "<div class='row col-8 text'><ul><li><h3 class='display-5 hName'>" + Nombre + Destino + "</h3></li>" +
        "<li><p class='lead dvText'>" + Testimonio + "<br/><div>" + Fecha + "</div></p></li></ul></div>" +
        "<div class='row col-3'><img class='imgVis' src='" + Img + "'></div></div><div class='rate' id='Trate' data-rate-value=" + Calificacion + "></div></div > ";
    return dvComentario;
}