$(document).ready(function () {
    ObtieneDestinos();
    ObtieneSalidas();
    ObtieneHabitaciones();
});


    

//Destinos
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
            $('#selDestinosCost')
                .append($("<option></option>")
                    .attr("value", data.LsDestinos[i].Viaje)
                    .text(data.LsDestinos[i].Destino));

        });
    } else {
        MensajeError('Ha ocurrido un error inesperado');
    }
}

//salidas

function ObtieneSalidas() {
    var url = $('#urlSalidaInicial').val();
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
            $('#selSalidaCost')
                .append($("<option></option>")
                    .attr("value", data.LsSalidas[i].Salida)
                    .text(data.LsSalidas[i].Ciudad));

        });
    } else {
        MensajeError('Ha ocurrido un error inesperado');
    }
}

//Habitaciones

function ObtieneHabitaciones() {
    var url = $('#urlObtHabitaciones').val();
    $.ajax({
        url: url,
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        success: successObtieneHabitaciones,
        error: function (xmlHttpRequest, textStatus, errorThrown) {
            MensajeError(data.Mensaje);
        }
    });
}
function successObtieneHabitaciones(data) {
    if (data.Exito) {
        var valact = 0;
        $.each(data.LsHabitaciones, function (i) {
            $('#selHabitaciones')
                .append($("<option></option>")
                    .attr("value", data.LsHabitaciones[i].tipoHab)
                    .text(data.LsHabitaciones[i].Descripcion));

        });
    } else {
        MensajeError('Ha ocurrido un error inesperado');
    }
}


//inserta costo

$(document).on('click', '#btnInsertaCosto', function (e) {


    if ($('#inCosto').val() != '') {
        var CCosto = {
            dCostoLugar: $('#inCosto').val(),
            IdDestino: $('#selDestinosCost').val(),
            IdSalida: $('#selSalidaCost').val(),
            IdHabitación: $('#selHabitaciones').val(),
            sTipoPersona: $('#selPersona').val(),
            
        };
        LLamaInsertaCosto(CCosto);
    } else {
        MensajeAdvertencia('No ha llenado los campos requeridos');
    }
});

function LLamaInsertaCosto(CCosto) {
    var url = $('#urlInsertaCostos').val();
    $.ajax({
        url: url,
        data: JSON.stringify({ CCosto }),
        type: "POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        success: SuccessLlamadaInsertaCosto,
        Advertencia: function (xmlHttpRequest, textStatus, errorThrown) {
            alert("error ", data.Mensaje, "verificar info");
        }
    });
}

function SuccessLlamadaInsertaCosto(data) {
    if (data.Exito) {
        MensajeExito('Se ha agregado el costo correctamente');
        $('#inCosto').val('');
        $('#selDestinosCost').val(0);
        $('#selSalidaCost').val(0);
        $('#selHabitaciones').val(0);
        $('#selPersona').val(0);

    } else {
        MensajeError('Algo ha salido mal, intentelo mas tarde.');
    }
}