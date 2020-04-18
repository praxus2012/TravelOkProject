var preguntas = "";
var respuestas = "";

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
        console.log(preguntas);
        console.log(respuestas);
        
    });
    
}


$(btnSend).click(function (e) {
    e.preventDefault();
    EnviarEncuesta();
});

function SeleccionarDestino() {
    $(document).on('change', '#selDestinos', function (event) {
        if ($("#selDestinos option:selected").val() != 0) {
            console.log($("#selDestinos option:selected").val());
        }
    });
}



$(document).ready(function () {
    Inicial();
    ObtenerFecha();
    SeleccionarDestino();
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
            var html = '<div class="col-12"><div class="Text">' + data.LsEncuesta[i].nvPregunta;
            html += '</div><div class="row col-12 rate-layer d-flex justify-content-between pregunta" id="p' + data.LsEncuesta[i].IdPregunta + '">';
            if (data.LsEncuesta[i].iTipoPreg == 1) {
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


function ObtenerFecha() {
    let today = new Date().toLocaleDateString()
    var lbFecha = document.getElementById('lbFecha');
    lbFecha.innerHTML = today;
}

function EnviarEncuesta() {
    console.log($('#urlEnviarEncuesta').val());
}