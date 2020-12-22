$(document).ready(function () {
    ObtieneDestinos();
    ActivaCombo();
});

//#region ObtieneDestinos
function ObtieneDestinos() {
    var url = $('#urlRecuperaSalida').val();
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
        $.each(data.LsSalidas, function (i) {
            $.each(data.LsSalidas[i], function (key, val) {
                if ($.isNumeric(val))
                    valact = val;
                else {
                    $('#selSalida')
                        .append($("<option></option>")
                            .attr("value", valact)
                            .text(val));
                }
            });
        });
    } else {
        MensajeError('Ha ocurrido un error inesperado');
    }
}
//#endregion

//#region ActivaCombo
function ActivaCombo() {
    $('#selSalida').change(function () {
        var detVenta = {
            idSalida: $('#selSalida').val()
        };
        LlamaRecupDestVta(detVenta);
    });

    $('#selDestinos').change(function () {
        var detVenta = {
            idDestino: $('#selDestinos').val(),
            idSalida: $('#selSalida').val()
        };
        LlamaRecupFechVta(detVenta);
    });  
}

function LlamaRecupDestVta(detVenta) {
    var url = $('#urlRecuperaDestinos').val();
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

function LlamaRecupFechVta(detVenta) {
    var url = $('#urlRecuperaFechas').val();
    $.ajax({
        url: url,
        type: "POST",
        data: JSON.stringify({ detVenta }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        success: successRecupFechVta,
        error: function (xmlHttpRequest, textStatus, errorThrown) {
            alert('Error de datos');
        }
    });
}

function successRecupDestVta(data) {
    if (data.Exito) {
        $('#selDestinos').empty();
        $('#selDestinos')
            .append($("<option></option>")
                .attr("value", "0")
                .text("Destino"));
        $.each(data.LsDestinos, function (i) {
            $('#selDestinos')
                .append($("<option></option>")
                    .attr("value", data.LsDestinos[i].IdDest)
                    .text(data.LsDestinos[i].Destino));
        });
    }
}

function successRecupFechVta(data) {
    if (data.Exito) {
        $('#selFechas').empty();
        $('#selFechas')
            .append($("<option></option>")
                .attr("value", "0")
                .text("Fechas"));
        $.each(data.LsFechaVta, function (i) {
            var fecha = data.LsFechaVta[i].dtFecha;

            var $nuevaFecha = fecha.toString().slice(0,10);

            $('#selFechas')
                .append($("<option></option>")
                    .attr("value", data.LsFechaVta[i].IdVenta)
                    .text(convertirFecha($nuevaFecha)));

        });
    }
}

function convertirFecha(fechaSinFormato) {

    let fechaNueva = "";
    let fechaDividida = fechaSinFormato.split("-");
    fechaNueva = fechaDividida[2] + "-" + fechaDividida[1] + "-" + fechaDividida[0];
    return fechaNueva;
}
//#endregion

//#region botonMostrarViajeros
function botonMostrarViajeros() {
    if ($('#selSalida').val() != 0 && $('#selDestinos').val() != 0 && $('#selFechas').val() != 0) {
        var idViaj = $('#selFechas').val();
        ObtieneTablaViajeros(idViaj);
        $('#listaViajeros').css('display', 'block');
    } else {
        MensajeAdvertencia("Debe Seleccionar Todos Los Campos");
    }
}

function ObtieneTablaViajeros(idViaj) {
    var url = $('#urlObtieneTablaViajeros').val();
    $.ajax({
        url: url,
        type: "POST",
        data: JSON.stringify({ idViaj }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        success: muestraTablaViajeros,
        error: function (xmlHttpRequest, textStatus, errorThrown) {
            alert('Error de datos');
        }
    });
}

function muestraTablaViajeros(data) {
    $('#contenidoTablaViajeros').empty();
    $.each(data.lsTablaViajeros, function (i) {
        var tr = 
       `<tr>' +
          '<td>`+ data.lsTablaViajeros[i].sNombre + ' ' + data.lsTablaViajeros[i].sApellido + `</td>' +
          '<td>`+ data.lsTablaViajeros[i].idUsuario + `</td>' +
          '<td>`+ data.lsTablaViajeros[i].iAsiento + `</td>' +
          '<td>`+ data.lsTablaViajeros[i].sTelefono + `</td>' +
          '<td>`+ data.lsTablaViajeros[i].dtFechaRegistro + `</td>' +
          '<td>`+ data.lsTablaViajeros[i].sDestino + `</td>' +
          '<td>`+ data.lsTablaViajeros[i].sSalida + `</td>' +
          '<td>`+ data.lsTablaViajeros[i].dtFechaSalida + `</td>' +
        '</tr>`;
        $("#contenidoTablaViajeros").append(tr)
    });
    
}



//#endregion

