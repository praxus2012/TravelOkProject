$(document).ready(function () {
    Inicial();
});


function Inicial() {
    ObtieneSalidas();
}

function ObtieneSalidas() {
    var url = $('#urlDestinoInicial').val();
    $.ajax({
        url: url,
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        success: successObtieneSaalidas,
        error: function (xmlHttpRequest, textStatus, errorThrown) {
            MensajeError(data.Mensaje);
        }
    });
}
function successObtieneSaalidas(data) {
    if (data.Exito) {
        var valact = 0;
        $.each(data.LsSalidas, function (i) {
            $('#selSalida')
                .append($("<option></option>")
                    .attr("value", data.LsSalidas[i].Salida)
                    .text(data.LsSalidas[i].Ciudad));

        });
    } else {
        MensajeError('Ha ocurrido un error inesperado');
    }
}

$(document).on('click', '#btnAgregarSal', function (e) {
    if ($('#inSalida').val() === "") {
        MensajeAdvertencia("No has ingresado una salida");
    } else {
        var Ciudad = $('#inSalida').val();
        LlamaInsertaSalida(Ciudad);
    }
});

$(document).on('click', '#btnEliminaCiudad', function (e) {
    if ($('#selSalida').val() === "") {
        MensajeAdvertencia("No has ingresado una salida");
    } else {
        var idCiudad = $('#selSalida').val();
        LLamaEliminaSalidaId(idCiudad);
    }
});

function LLamaEliminaSalidaId(idSalida) {
    var url = $('#urlSalidaEliminaId').val();
    $.ajax({
        url: url,
        data: JSON.stringify({ idSalida }),
        type: "POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        success: SuccessLlamadaEliminaSalidaId,
        Advertencia: function (xmlHttpRequest, textStatus, errorThrown) {
            alert("error ", data.Mensaje, "verificar info");
        }
    });
}

function SuccessLlamadaEliminaSalidaId(data) {
    if (data.Exito) {
        MensajeExito('Se ha eliminado correctamente');
        $('#selSalida').empty();
        ObtieneSalidas();
        // $('#selSalida').val(0);
    } else {
        MensajeAdvertencia('Ha ocurrido un error');
    }

}
function LlamaInsertaSalida(sSalida) {
    var url = $('#urlSalidaInserta').val();
    $.ajax({
        url: url,
        data: JSON.stringify({ sSalida }),
        type: "POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        success: SuccessLlamadaInsertaSalida,
        Advertencia: function (xmlHttpRequest, textStatus, errorThrown) {
            alert("error ", data.Mensaje, "verificar info");
        }
    });
}

function SuccessLlamadaInsertaSalida(data) {
    if (data.Exito) {
        MensajeExito("Se ha agregado la salida correctamente");
        $('#inSalida').val('');

        $('#selSalida').empty();
        ObtieneSalidas();

    } else {
        MensajeAdvertencia("Ha ocurrido un error inesperado, intentelo mas tarde.");
    }
}