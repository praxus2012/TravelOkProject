$(document).ready(function () {
    GeneraClicks();
    localStorage.clear();
    ObtieneSalidasI();
    ObtieneDestinosI();
    ObtieneTransportesI();
    ObtieneViajesElim();
});

// Viajes a eliminar
function ObtieneViajesElim() {
    var url = $('#urlObtieneViajElimina').val();
    $.ajax({
        url: url,
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        success: successObtieneViajesElim,
        error: function (xmlHttpRequest, textStatus, errorThrown) {
            MensajeError(data.Mensaje);
        }
    });
}
function successObtieneViajesElim(data) {
    if (data.Exito) {
        $('#selEViaje').empty();
        $('#selEViaje')
            .append($("<option></option>")
                .attr("value", 0)
                .text("Seleccione el viaje a eliminar"));
        $.each(data.LsViajeElim, function (i) {
            $('#selEViaje')
                .append($("<option></option>")
                    .attr("value", data.LsViajeElim[i].idViaje)
                    .text(data.LsViajeElim[i].desViaje));
        });
    } else {
        MensajeError('Ha ocurrido un error inesperado');
    }
}
// Viajes a eliminar Activos
function ObtieneViajesElimA() {
    var url = $('#urlObtieneViajEliminaA').val();
    $.ajax({
        url: url,
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        success: successObtieneViajesElimA,
        error: function (xmlHttpRequest, textStatus, errorThrown) {
            MensajeError(data.Mensaje);
        }
    });
}
function successObtieneViajesElimA(data) {
    if (data.Exito) {
        $('#selEViaje').empty();
        $('#selEViaje')
            .append($("<option></option>")
                .attr("value", 0)
                .text("Seleccione el viaje a eliminar"));
        $.each(data.LsViajeElim, function (i) {
            $('#selEViaje')
                .append($("<option></option>")
                    .attr("value", data.LsViajeElim[i].idViaje)
                    .text(data.LsViajeElim[i].desViaje));
        });
    } else {
        MensajeError('Ha ocurrido un error inesperado');
    }
}
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
            $('#selIDestinosVia')
                .append($("<option></option>")
                    .attr("value", data.LsDestinos[i].Viaje)
                    .text(data.LsDestinos[i].Destino));

        });
    } else {
        MensajeError('Ha ocurrido un error inesperado');
    }
}

// Transportes para insertar
function ObtieneTransportesI() {
    var url = $('#urlObtieneTransportesI').val();
    $.ajax({
        url: url,
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        success: successObtieneTransportesI,
        error: function (xmlHttpRequest, textStatus, errorThrown) {
            MensajeError(data.Mensaje);
        }
    });
}

function successObtieneTransportesI(data) {
    if (data.Exito) {
        var valact = 0;
        $.each(data.LsTransportes, function (i) {
            $('#selTransporteI')
                .append($("<option></option>")
                    .attr("value", data.LsTransportes[i].idTrans)
                    .text(data.LsTransportes[i].NombreT + ' - Asientos: ' + data.LsTransportes[i].NumAsi));

        });
    } else {
        MensajeError('Ha ocurrido un error inesperado');
    }
}

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
        if (localStorage.getItem("counter") == null)
            valact = 1;
        else
            valact = localStorage.getItem("counter");
        $.each(data.LsSalidas, function (i) {
            $('#selISalidaVia' + valact)
                .append($("<option></option>")
                    .attr("value", data.LsSalidas[i].Salida)
                    .text(data.LsSalidas[i].Ciudad));

        });
    } else {
        MensajeError('Ha ocurrido un error inesperado');
    }
}

function GeneraClicks() {
    $(".btnCan").click(function () {
        var counter = localStorage.getItem("counter");
        var id = this.id.split('-')[1];
        $('#dv' + id).remove();
        $('#s' + id).remove();
        if (counter == id) {
            while ($('#dv' + counter).length == 0 && counter>2) {
                counter--;
            }
            localStorage.setItem("counter", counter);
        }        
        if (counter == 2) {
            localStorage.clear();
        }
    });

    $("#inActivos").change(function () {
        if (this.checked) {
            ObtieneViajesElimA();
        } else {
            ObtieneViajesElim();
        }
    });
}

$(document).on("click", "#btnAgregarSalida", function (e) {
    AgregarSalida();
});

function AgregarSalida() {
    if (localStorage.getItem("counter") == null) {
        var counter = 2;
        $("#dvIotras").append('<div class="row" id="dv' + counter + '"><div id="diISalida"' + counter + '>Salida</div>' +
            '<select class="form-control" id="selISalidaVia' + counter + '">' +
            '<option value="0">Selecciona de donde salimos</option></select><div class="container">' +
            '<div class="row"><div class="col-5">' +
            '<div id="diIFechas' + counter + '">Fecha de Salida</div>' +
            '<input type="date" id="fISalida' + counter + '" />' +
            '<div id="diIhoras' + counter + '">Hora de Salida</div>' +
            '<input type="time" id="hISalida' + counter + '" />' +
            '</div><div class="col-5">' +
            '<div id="diIFechar' + counter + '">Fecha de Regreso</div>' +
            '<input type="date" id="fIRegreso' + counter + '" />' +
            '<div id="diIhorar' + counter + '">Hora de Regreso</div>' +
            '<input type="time" id="hIRegreso' + counter + '" />' +
            '</div></div></div>' +
            '<div id="btnCancViaje-' + counter + '" class="btn btn-primary btnCan mt-3">Cancelar</div></div><hr id="s' + counter + '" />'
        );
        localStorage.setItem("counter", counter);
    } else {
        var counter = localStorage.getItem("counter");
        counter++;
        $("#s" + (counter - 1)).after('<div class="row" id="dv' + counter + '"><div id="diISalida"' + counter + '>Salida</div>' +
            '<select class="form-control" id="selISalidaVia' + counter + '">' +
            '<option value="0">Selecciona de donde salimos</option></select><div class="container">' +
            '<div class="row"><div class="col-5">' +
            '<div id="diIFechas' + counter + '">Fecha de Salida</div>' +
            '<input type="date" id="fISalida' + counter + '" />' +
            '<div id="diIhoras' + counter + '">Hora de Salida</div>' +
            '<input type="time" id="hISalida' + counter + '" />' +
            '</div><div class="col-5">' +
            '<div id="diIFechar' + counter + '">Fecha de Regreso</div>' +
            '<input type="date" id="fIRegreso' + counter + '" />' +
            '<div id="diIhorar' + counter + '">Hora de Regreso</div>' +
            '<input type="time" id="hIRegreso' + counter + '" />' +
            '</div></div></div>' +
            '<div id="btnCancViaje-' + counter + '" class="btn btn-primary btnCan mt-3">Cancelar</div></div><hr id="s' + counter + '" />'
        );
        localStorage.setItem("counter",counter);
    }
    GeneraClicks();
    ObtieneSalidasI();
}

$(document).on("click", "#btnInsertaViaje", function (e) {
    var lsViajes = [];
    if (localStorage.getItem("counter") == null) {
        var Viaje = {
            Id_Destino: $('#selIDestinosVia').val(),
            Id_Salida: $('#selISalidaVia1').val(),
            dtFechaSalida: getAsDate($('#fISalida1').val(), $('#hISalida1').val()),
            IdTransporte: $('#selTransporteI').val(),
            dtFechaLleg: getAsDate($('#fIRegreso1').val(), $('#hIRegreso1').val())
        };
        lsViajes.push(Viaje);
    } else {
        var counter = localStorage.getItem("counter");
        var count = 1;
        while (count <= counter) {
            if ($('#dv' + count).length > 0 || count==1) {
                var Viaje = {
                    Id_Destino: $('#selIDestinosVia').val(),
                    Id_Salida: $('#selISalidaVia' + count).val(),
                    dtFechaSalida: getAsDate($('#fISalida' + count).val(), $('#hISalida' + count).val()),
                    IdTransporte: $('#selTransporteI').val(),
                    dtFechaLleg: getAsDate($('#fIRegreso' + count).val(), $('#hIRegreso' + count).val())
                };
                lsViajes.push(Viaje);
            }
            count++;
        }
    }
    LLamaInsertaViaje(lsViajes);

});

function LLamaInsertaViaje(lsViajes) {
    var url = $('#urlInsertarViaje').val();
    $.ajax({
        url: url,
        type: "POST",
        data: JSON.stringify({ lsViajes }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        success: SuccessLLamaInsertaViaje,
        error: function (xmlHttpRequest, textStatus, errorThrown) {
            MensajeError('Problema al crear el registro, favor de acudir con un asistente');
        }
    });
}


function SuccessLLamaInsertaViaje(data) {
    if (data.Exito) {
        MensajeExito('Se ha agregado el viaje correctamente');
        if ($('#inActivos:checked').length > 0) {
            ObtieneViajesElimA();
        } else {
            ObtieneViajesElim();
        }
    } else {
        MensajeError('Algo ha salido mal, intentelo mas tarde.');
    }
}

$(document).on('click', '#btnEliminaViaje', function (e) {
    LLamaEliminaViaje($('#selEViaje').val());
});


function LLamaEliminaViaje(idViaje) {
    var url = $('#urlBorrarViaje').val();
    $.ajax({
        url: url,
        type: "POST",
        data: JSON.stringify({ idViaje }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        success: SuccessLLamaEliminaViaje,
        error: function (xmlHttpRequest, textStatus, errorThrown) {
            MensajeError('Problema al eliminar el registro, favor de acudir con un asistente');
        }
    });
}


function SuccessLLamaEliminaViaje(data) {
    if (data.Exito) {
        MensajeExito('Se ha eliminado el viaje correctamente');
        
        if ($('#inActivos:checked').length>0) {
            ObtieneViajesElimA();
        } else {
            ObtieneViajesElim();
        }
        
    } else {
        MensajeError('Algo ha salido mal, intentelo mas tarde.');
    }
}

function limpiaInserta() {
    $('#dvIotras').empty();
    localStorage.clear();
    $('#selISalidaVia1').val(0);
    $('#selIDestinosVia').val(0);
    $('#selTransporteI').val(0);
}