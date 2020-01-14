﻿var preguntas;
var respuestas;

$('.pregunta').children().children().click(function (evt) {
    var numPregunta = parseInt($(this).parent().parent().attr('id').substr(1, 2).trim());
    var respuesta = parseInt($(this).attr("class").substr(1, 1).trim());
    console.warn("Pregunta numero: " + numPregunta + " Respuesta a la pregunta: " + respuesta);

    var preguntas;
    //console.log(respuesta);
    //allElements = $(numPregunta).add(respuesta);
    preguntas = $(preguntas).add(numPregunta);
    respuestas = $(preguntas.respuestas).add(respuesta);

    console.log(preguntas);
    console.log(respuestas);
});

$(btnSend).click(function (e) {
    e.preventDefault();
    console.log('Enviado');
    EnviarEncuesta();
    console.log(allElements);
});

function SeleccionarDestino() {
    $(document).on('change', '#selDestinos', function (event) {
        if ($("#selDestinos option:selected").val() != 0) {
            console.log($("#selDestinos option:selected").val());
        }
    });
}



$(document).ready(function() {
    Inicial();
    ObtenerFecha();
    SeleccionarDestino();
});

function Inicial() {
    ObtieneDestinos();
}

function ObtieneDestinos() {
    var url = $('#urlDestinoInicial').val();
    $.ajax({
        url: url,
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        success: successObtieneDestinos,
        error: function(xmlHttpRequest, textStatus, errorThrown) {
            MensajeError(data.Mensaje);
        }
    });
}
function successObtieneDestinos(data) {
    if (data.Exito) {
        $.each(data.LsDestinos, function(i) {
            $('#selDestinos')
                .append($("<option></option>")
                    .attr("value", data.LsDestinos[i].Viaje)
                    .text(data.LsDestinos[i].Destino));
        });
    } else {
        MensajeError('Ha ocurrido un error inesperado');
    }
}


function ObtenerFecha() {
    let today = new Date().toLocaleDateString()
    var lbFecha = document.getElementById('lbFecha');
    lbFecha.innerHTML = today;
}

function EnviarEncuesta() {
    console.log($('#urlEnviarEncuesta').val());
}