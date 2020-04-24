var preguntas = "";
var respuestas = "";
var totPreg = 0;
var pregMult = 0;
//variables: 1 - 15
//evaluar si son iguales
//Reasignar Valor de cada pregunta
function GeneraClick() {
    $('.pregunta').children().children().click(function () {
        $(this).parent().parent().children().children().css('background-color', '#ffffff');
        $(this).css('background-color', 'cornflowerblue');
        var pregunta = "" + $(this).parent().parent().attr('id').substr(1, 2).trim();
        var respuesta = "" + $(this).attr('class').split(' ')[0].split('-')[1];
        if (preguntas == "") {
            preguntas = pregunta;
            respuestas = respuesta;
            totPreg--;
            pregMult--;
        } else {
            var lsPreguntas = preguntas.split('|');
            var lsRespuestas = respuestas.split('|');
            var cambiado = false;
            $.each(lsPreguntas, function (i) {
                if (lsPreguntas[i] == pregunta) {
                    lsRespuestas[i] = respuesta;
                    cambiado = true;
                }
            });
            if (!cambiado) {
                preguntas = preguntas + '|' + pregunta;
                respuestas = respuestas + '|' + respuesta;
                totPreg--;
                pregMult--;
            } else {
                preguntas = "";
                respuestas = "";
                $.each(lsPreguntas, function (i) {
                    if (i == 0) {
                        preguntas += lsPreguntas[i];
                        respuestas += lsRespuestas[i];
                    } else {
                        preguntas += '|' + lsPreguntas[i];
                        respuestas += '|' + lsRespuestas[i];
                    }
                });
            }
        }
    });
    
}

$('#btnSend').click(function (e) {
    var cont = 1;
    if (pregMult == 0) {
        while (totPreg > 0) {
            if ($('#txRes' + cont).val() != null) {
                preguntas = preguntas + '|' + cont;
                respuestas = respuestas + '|' + $('#txRes' + cont).val();
                totPreg--;
            } 
            cont++;
        }
        var lsPreguntas = preguntas.split('|');
        var lsRespuestas = respuestas.split('|');
        var SalidaRes = [];
        $.each(lsPreguntas, function (i) {
            var Respuesta = {
                NombrePersona: $('#inNom').val(),
                IdPregunta: lsPreguntas[i],
                IdDestino: $("#selDestinos option:selected").val(),
                nvRespuesta: lsRespuestas[i],
                dtFechaEncuesta: $('#lbFecha').text(),
                dtFechaViaje: $('#inFechaViaje').val()
            };
            SalidaRes.push(Respuesta);
        });
        EnviaRespuesta(SalidaRes);

    } else {
        MensajeAdvertencia("Debe contestar las preguntas de opción múltiple");
        
    }
});



function ObtenerFecha() {
    let today = new Date().toLocaleDateString();
    var lbFecha = document.getElementById('lbFecha');
    lbFecha.innerHTML = today;
}

function EnviaRespuesta(SalidaRes) {
    var url = $('#urlEnviarEncuesta').val();
    $.ajax({
        url: url,
        type: "POST",
        data: JSON.stringify({ SalidaRes }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        success: sucessEnviaRespuesta,
        error: function (xmlHttpRequest, textStatus, errorThrown) {
            MensajeError('Error al enviar la encuesta, inténtelo más tarde');
            OcultaCarga();
        }
    });
}
function sucessEnviaRespuesta(data) {
    if (data.Exito) {
        MensajeExitoPago("Se ha enviado con éxito");
    } else {
        MensajeError('Ha ocurrido un error inesperado');
        OcultaCarga();
    }
}




$(document).ready(function () {
    Inicial();
    ObtenerFecha();
});

function Inicial() {
    CargaInicial();
}

function CargaInicial() {
    var url = $('#urlDestinoInicial').val();
    $.ajax({
        url: url,
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        success: successCargaInicial,
        error: function(xmlHttpRequest, textStatus, errorThrown) {
            MensajeError(data.Mensaje);
        }
    });
}
function successCargaInicial(data) {
    if (data.Exito) {
        $.each(data.LsDestinos, function(i) {
            $('#selDestinos')
                .append($("<option></option>")
                    .attr("value", data.LsDestinos[i].Viaje)
                    .text(data.LsDestinos[i].Destino));
        });
        $.each(data.LsEncuesta, function (i) {
            totPreg++;
            var html = '<div class="col-12"><div class="Text">' + data.LsEncuesta[i].nvPregunta;
            html += '</div><div class="row col-12 rate-layer d-flex justify-content-between pregunta" id="p' + data.LsEncuesta[i].IdPregunta + '">';
            if (data.LsEncuesta[i].iTipoPreg == 1) {
                pregMult++;
                html += '<div class="col-2 d-flex justify-content-between"><div class="c-5 c"></div></div>';
                html += '<div class="col-2 d-flex justify-content-between"><div class="c-4 c"></div></div>';
                html += '<div class="col-2 d-flex justify-content-between"><div class="c-3 c"></div></div>';
                html += '<div class="col-2 d-flex justify-content-between"><div class="c-2 c"></div></div>';
                html += '<div class="col-2 d-flex justify-content-between"><div class="c-1 c"></div></div>';
            } else {
                html += '<textarea id="txRes' + data.LsEncuesta[i].IdPregunta + '"></textarea>';
            }

            html += '</div></div>';
            $('#dvPreguntas').append(html);
        });
        GeneraClick();
        OcultaCarga();
    } else {
        MensajeError('Ha ocurrido un error inesperado');
    }
}