$(document).ready(function () {
    Inicial();
});

var CHECADO = 0;
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
        error: function (xmlHttpRequest, textStatus, errorThrown) {
            MensajeError(data.Mensaje);
        }
    });
}
function successObtieneDestinos(data) {
    if (data.Exito) {
        var valact = 0;
        $.each(data.LsDestinos, function (i) {
            $('#selDestinos')
                .append($("<option></option>")
                    .attr("value", data.LsDestinos[i].Viaje)
                    .text(data.LsDestinos[i].Destino));

            $('#selDestinos2')
                .append($("<option></option>")
                    .attr("value", data.LsDestinos[i].Viaje)
                    .text(data.LsDestinos[i].Destino));
        });
    } else {
        MensajeError('Ha ocurrido un error inesperado');
    }
}

$(document).on('click', '#btnInsertaDestino', function (e) {

    if ($('#chActivo').is(':checked')) {
        CHECADO = 1;
    }
    else {
        CHECADO = 0;
    }


    if ($('#inDestino').val() != '') {
        var CDestino = {
            sDestino: $('#inDestino').val(),
            sTitulo: $('#inTitulo').val(),
            sSubTit: $('#inSubtitulo').val(),
            sDescrip: $('#inDescripcion').val(),
            bPrincipal: CHECADO


        };
        LLamaInsertaDestino(CDestino);
    } else {
        MensajeAdvertencia('No ha llenado los campos requeridos');
    }
});

function LLamaInsertaDestino(CDestino) {
    var url = $('#urlDestinoInserta').val();
    $.ajax({
        url: url,
        data: JSON.stringify({ CDestino }),
        type: "POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        success: SuccessLlamadaInsertaDestino,
        Advertencia: function (xmlHttpRequest, textStatus, errorThrown) {
            alert("error ", data.Mensaje, "verificar info");
        }
    });
}

function SuccessLlamadaInsertaDestino(data) {
    if (data.Exito) {
        MensajeExito('Se ha agregado el destino correctamente');
        $('#inDestino').val('');
        $('#inTitulo').val('');
        $('#inSubtitulo').val('');
        $('#inDescripcion').val('');
        $("#chActivo").prop("checked", false);
        CHECADO = 0;
    } else {
        MensajeError('Algo ha salido mal, intentelo mas tarde.');
    }
}


$(document).on('click', '#btnEliminaDestino', function (e) {
    if ($('#selDestinos').val() === "") {
        MensajeAdvertencia("No has ingresado un Destino");
    } else {
        var idDest = $('#selDestinos').val();
        LLamaEliminaDestinoId(idDest);
    }
});

function LLamaEliminaDestinoId(idDestino) {
    var url = $('#urlDestinoElimina').val();
    $.ajax({
        url: url,
        data: JSON.stringify({ idDestino }),
        type: "POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        success: SuccessLlamadaEliminaDestinoId,
        Advertencia: function (xmlHttpRequest, textStatus, errorThrown) {
            alert("error ", data.Mensaje, "verificar info");
        }
    });
}

function SuccessLlamadaEliminaDestinoId(data) {
    if (data.Exito) {
        MensajeExito('Se ha eliminado correctamente');
        $('#selDestinos').empty();
        ObtieneDestinos();
        // $('#selSalida').val(0);
    } else {
        MensajeAdvertencia('Ha ocurrido un error');
    }

}




$(document).on('click', '#btnInsertaDetDestino', function (e) {

    if ($('#chActivoDetDest').is(':checked')) {
        CHECADO_det = 1;
    }
    else {
        CHECADO_det = 0;
    }


    if ($('#selDestinos2').val() != '') {
        var CDetDestino = {
            iDestino: $('#selDestinos2').val(),
            sRutaImg: $('#inFotoDetDestino').val(),
            sDescripcion: $('#inDescDetDestino').val(),
            bActivo: CHECADO_det


        };
        LLamaInsertaDetDestino(CDetDestino);
    } else {
        MensajeAdvertencia('No ha llenado los campos requeridos');
    }
});


function LLamaInsertaDetDestino(CDetDestino) {
    var url = $('#urlDetalleDestinoInserta').val();
    $.ajax({
        url: url,
        data: JSON.stringify({ CDetDestino }),
        type: "POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        success: SuccessLlamadaInsertaDetDestino,
        Advertencia: function (xmlHttpRequest, textStatus, errorThrown) {
            alert("error ", data.Mensaje, "verificar info");
        }
    });
}

function SuccessLlamadaInsertaDetDestino(data) {
    if (data.Exito) {
        MensajeExito('Se ha agregado el detalle destino correctamente');

        $('#selDestinos2').val('');
        $('#inFotoDetDestino').val('');
        $('#inDescDetDestino').val('');
        $("#chActivoDetDest").prop("checked", false);
        CHECADO = 0;
    } else {
        MensajeError('Algo ha salido mal, intentelo mas tarde.');
    }
}