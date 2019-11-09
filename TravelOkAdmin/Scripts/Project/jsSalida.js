$(document).on('click', '#btnAgregarSal', function (e) {
    if ($('#inSalida').val() === "") {
        MensajeAdvertencia("No has ingresado una salida");
    } else {
        var Ciudad = $('#inSalida').val();
        LlamaInsertaSalida(Ciudad);
    }
});

$(document).on('click', '#btnEliminaCiudad', function (e) {
    if ($('#inEliminaCiudad').val() === "") {
        MensajeAdvertencia("No has ingresado una salida");
    } else {
        var idCiudad = $('#inEliminaCiudad').val();
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
        $('#inEliminaCiudad').val('');
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
    } else {
        MensajeAdvertencia("Ha ocurrido un error inesperado, intentelo mas tarde.");
    }
}