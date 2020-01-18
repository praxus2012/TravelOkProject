$(document).ready(function () {
    ObtieneSalidasI();
    ObtieneDestinosI();
    ObtieneHabitaciones();
   
    ObtieneSalidasE();  

    ActivaComboDestE();
    ObtHabitacionSalidaDestino();
});

// Destinos (para el insert)
function ObtieneDestinosI() {
    var url = $('#urlObtDestinoI').val();
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
            $('#selIDestinosCost')
                .append($("<option></option>")
                    .attr("value", data.LsDestinos[i].Viaje)
                    .text(data.LsDestinos[i].Destino));

        });
    } else {
        MensajeError('Ha ocurrido un error inesperado');
    }
}


//Destinos
/*function ObtieneDestinos() {
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
                    .attr("value", data.LsDestinos[i].IdDest)
                    .text(data.LsDestinos[i].Destino));

        });
    } else {
        MensajeError('Ha ocurrido un error inesperado');
    }
}*/

//salidas (para el insert)
function ObtieneSalidasI() {
    var url = $('#urlObtSalidaI').val();
    $.ajax({
        url: url,
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        success: successObtieneSaalidasI,
        error: function (xmlHttpRequest, textStatus, errorThrown) {
            MensajeError(data.Mensaje);
        }
    });
}

function successObtieneSaalidasI(data) {
    if (data.Exito) {
        var valact = 0;
        $.each(data.LsSalidas, function (i) {
            $('#selISalidaCost')
                .append($("<option></option>")
                    .attr("value", data.LsSalidas[i].Salida)
                    .text(data.LsSalidas[i].Ciudad));

        });
    } else {
        MensajeError('Ha ocurrido un error inesperado');
    }
}

//Habitaciones (para insertar)

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

//      Modificar

//obtiene destinos(Modificar)

function LlamaRecupDestVtaM(detVenta) {
    var url = $('#urlDestinoInicial').val();
    $.ajax({
        url: url,
        type: "POST",
        data: JSON.stringify({ detVenta }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        success: successRecupDestVtaM,
        error: function (xmlHttpRequest, textStatus, errorThrown) {
            alert('test');
        }
    });
}
function successRecupDestVtaM(data) {
    if (data.Exito) {
        $.each(data.LsDestinos, function (i) {

            if (i == 0) {
                $('#selMDestinosCost').empty();
                $('#selMDestinosCost')
                    .append($("<option></option>")
                        .attr("value", "0")
                        .text("¿De dónde salimos?"));
            }

            $('#selMDestinosCost')
                .append($("<option></option>")
                    .attr("value", data.LsDestinos[i].IdDest)
                    .text(data.LsDestinos[i].Destino));
        });
    }
}
//obtiene habitaciones(Modificar)

function LlamaRecupHabCostoM(idSalida, idDestino) {
    var url = $('#urlObtHabitacionesCost').val();
    $.ajax({
        url: url,
        type: "POST",
        data: JSON.stringify({ idSalida, idDestino }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        success: successRecupHabCostM,
        error: function (xmlHttpRequest, textStatus, errorThrown) {
            alert('test');
        }
    });
}
function successRecupHabCostM(data) {
    if (data.Exito) {
        $.each(data.LsHabitaciones, function (i) {

            if (i == 0) {
                $('#selMHabitacionCost').empty();
                $('#selMHabitacionCost')
                    .append($("<option></option>")
                        .attr("value", "0")
                        .text("¿Cual es la Habitación?"));
            }
            $('#selMHabitacionCost')
                .append($("<option></option>")
                    .attr("value", data.LsHabitaciones[i].tipoHab)
                    .text(data.LsHabitaciones[i].Descripcion));
        });
    }
}


//     eliminar--------------------------------------------

//obtiene salidas (para eliminar)

function ObtieneSalidasE() {
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
            $('#selSalidaCost, #selMSalidaCost')
                .append($("<option></option>")
                    .attr("value", data.LsSalidas[i].Salida)
                    .text(data.LsSalidas[i].Ciudad));

        });
    } else {
        MensajeError('Ha ocurrido un error inesperado');
    }
}

//obtiene destinos a partir de una salida (para eliminar)

function ActivaComboDestE() {
    $('#selSalidaCost').change(function () {
        var detVenta = {
            idSalida: $('#selSalidaCost').val()
        };
        LlamaRecupDestVta(detVenta);
    });

    $('#selMSalidaCost').change(function () {
        var detVenta = {
            idSalida: $('#selMSalidaCost').val()
        };
        LlamaRecupDestVtaM(detVenta);
    });
}

function LlamaRecupDestVta(detVenta) {
    var url = $('#urlDestinoInicial').val();
    $.ajax({
        url: url,
        type: "POST",
        data: JSON.stringify({ detVenta }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        success: successRecupDestVta,
        error: function (xmlHttpRequest, textStatus, errorThrown) {
            alert('test');
        }
    });
}
function successRecupDestVta(data) {
    if (data.Exito) {
        $.each(data.LsDestinos, function (i) {

            if (i==0) {
                $('#selDestinosCost').empty();
                $('#selDestinosCost')
                    .append($("<option></option>")
                        .attr("value", "0")
                        .text("¿De dónde salimos?"));
            }

            $('#selDestinosCost')
                .append($("<option></option>")
                    .attr("value", data.LsDestinos[i].IdDest)
                    .text(data.LsDestinos[i].Destino));
        });
    }
}

//Habitaciones (para Eliminar)


function ObtHabitacionSalidaDestino() {
    $('#selDestinosCost').change(function () {        
       /* var detCosto = {
            idSalida: $('#selSalidaCost').val(),
            idDestino: $('#selDestinosCost').val()           
        };*/

        var idSalida = $('#selSalidaCost').val();
        var idDestino = $('#selDestinosCost').val();    

        LlamaRecupHabCosto(idSalida, idDestino);
    });

    $('#selMDestinosCost').change(function () {
        
        var idSalida = $('#selMSalidaCost').val();
        var idDestino = $('#selMDestinosCost').val();

        LlamaRecupHabCostoM(idSalida, idDestino);
    });
}

function LlamaRecupHabCosto(idSalida, idDestino) {
    var url = $('#urlObtHabitacionesCost').val();
    $.ajax({
        url: url,
        type: "POST",
        data: JSON.stringify({ idSalida, idDestino }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        success: successRecupHabCost,
        error: function (xmlHttpRequest, textStatus, errorThrown) {
            alert('test');
        }
    });
}
function successRecupHabCost(data) {
    if (data.Exito) {
        $.each(data.LsHabitaciones, function (i) {

            if (i == 0) {
                $('#selHabitacionCost').empty();
                $('#selHabitacionCost')
                    .append($("<option></option>")
                        .attr("value", "0")
                        .text("¿Cual es la Habitación?"));
            }
            $('#selHabitacionCost')
                .append($("<option></option>")
                    .attr("value", data.LsHabitaciones[i].tipoHab)
                    .text(data.LsHabitaciones[i].Descripcion));
        });
    }
}



//------------------------------------------------------



//inserta costo

$(document).on('click', '#btnInsertaCosto', function (e) {


    if ($('#inCosto').val() != '') {
        var CCosto = {
            dCostoLugar: $('#inCosto').val(),
            IdDestino: $('#selIDestinosCost').val(),
            IdSalida: $('#selISalidaCost').val(),
            IdHabitacion: $('#selHabitaciones').val(),
            sTipoPersona: $('#selPersona option:selected').text(),
            
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
        $('#selIDestinosCost').val(0);
        $('#selISalidaCost').val(0);
        $('#selHabitaciones').val(0);
        $('#selPersona').val(0);

    } else {
        MensajeError('Algo ha salido mal, intentelo mas tarde.');
    }
}

//Elimina costos

$(document).on('click', '#btnEliminaCosto', function (e) {
    if ($('#selSalidaCost').val() === "") {
        MensajeAdvertencia("No has ingresado una salida");
    } else {
        
        var CCosto = {
             idSalida:  $('#selSalidaCost').val(),
             idDestino: $('#selDestinosCost').val(),
            IdHabitacion: $('#selHabitacionCost').val()
        }

        LLamaEliminaCosto(CCosto);
    }
});

function LLamaEliminaCosto(CCosto) {
    var url = $('#urlEliminaCostos').val();
    $.ajax({
        url: url,
        data: JSON.stringify({ CCosto}),
        type: "POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        success: SuccessLlamadaEliminaCosto,
        Advertencia: function (xmlHttpRequest, textStatus, errorThrown) {
            alert("error ", data.Mensaje, "verificar info");
        }
    });
}

function SuccessLlamadaEliminaCosto(data) {
    if (data.Exito) {
        MensajeExito('Se ha eliminado correctamente');
        $('#selSalidaCost').empty();
        $('#selDestinosCost').empty();
        $('#selHabitacionCost').empty();

        ObtieneSalidasE();
        ActivaComboDestE();
        ObtHabitacionSalidaDestino();
        
    } else {
        MensajeAdvertencia('Ha ocurrido un error');
    }

}


//-----------------------------
