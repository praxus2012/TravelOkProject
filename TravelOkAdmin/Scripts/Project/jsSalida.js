$(document).ready(function () {
    Inicial();
});


function Inicial() {
    ObtieneSalidas();
    ObtieneSalidasModif();
}

const ObtieneSalidas = async () => {
    const url = $('#urlDestinoInicial').val();
    const data = await fetch(url).then(res => res.json()).catch(err => MensajeError(err.Message));
    successObtieneSaalidas(data);
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

//-- Agregar



$(document).on('click', '#btnAgregarSal', function (e) {
    if ($('#inSalida').val() === "") {
        MensajeAdvertencia("No has ingresado una salida");
    } else {
        var Ciudad = $('#inSalida').val();
        LlamaInsertaSalida(Ciudad);
    }
});


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


//-- Modificar

function ObtieneSalidasModif() {
    var url = $('#urlDestinoInicial').val();
    $.ajax({
        url: url,
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        success: successObtieneSaalidasModif,
        error: function (xmlHttpRequest, textStatus, errorThrown) {
            MensajeError(data.Mensaje);
        }
    });
}
function successObtieneSaalidasModif(data) {
    if (data.Exito) {
        var valact = 0;
        $.each(data.LsSalidas, function (i) {
            $('#selSalidaM')
                .append($("<option></option>")
                    .attr("value", data.LsSalidas[i].Salida)
                    .text(data.LsSalidas[i].Ciudad));

        });
    } else {
        MensajeError('Ha ocurrido un error inesperado');
    }
}

$('#selSalidaM').on('change', function (e) {

    $('#inMSalida').val($("#selSalidaM option:selected").text());

    $('#dvMSalida').removeClass("d-none");

   

});

$(document).on('click', '#btnMdifCiudad', function (e) {
    if ($('#inMSalida').val() === "") {
        MensajeAdvertencia("No has ingresado el nombre de salida");
    } else {
        //var CDsalida = {
        IdSalida = $('#selSalidaM').val();
        Ciudad = $('#inMSalida').val();
        //}
        LlamaModificaSalida(IdSalida, Ciudad);
    }
});

function LlamaModificaSalida(IdSalida, Ciudad) {
    var url = $('#urlSalidaModif').val();
    $.ajax({
        url: url,
        data: JSON.stringify({ IdSalida, Ciudad }),
        type: "POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        success: SuccessLlamadaModificaSalida,
        Advertencia: function (xmlHttpRequest, textStatus, errorThrown) {
            alert("error ", data.Mensaje, "verificar info");
        }
    });
}

function SuccessLlamadaModificaSalida(data) {
    if (data.Exito) {
        MensajeExito("Se ha modificado la salida correctamente");
       // $('#inMSalida').val('');

        $('#selSalidaM').empty();
        ObtieneSalidasModif();

    } else {
        MensajeAdvertencia("Ha ocurrido un error inesperado, intentelo mas tarde.");
    }
}

//--Eliminar

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

