$(document).ready(function () {
    var options = {
        valueNames: ['dropdown-item-name']
    };
    ObtieneDestinos();
    ActivaCombo();
    var hackerList = new List('dropdown-sorted-list', options);
});


function ObtieneDestinos() {
    var url = $('#urlInicialHome').val();
    $.ajax({
        url: url,
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        success: successObtieneDestinos,
        error: function (xmlHttpRequest, textStatus, errorThrown) {
            MensajeError(data.Mensaje);
            //alert('error');
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

$(document).on('click', '.btselec', function (e) {
    /*var detVenta = {
        idSalida : $('#selSalida').val(),
        idDestino : $('#selDestinos').val(),
        sFecha : $('#selFechas').val()
    };
    LlamaIniciarVenta(detVenta);*/
    if ($('#selSalida').val() != 0
        && $('#selDestinos').val() != 0
        && $('#selFechas').val() != 0) {
        sessionStorage.setItem("Salida", $('#selSalida').val());
        sessionStorage.setItem("Destino", $('#selDestinos').val());
        sessionStorage.setItem("DestinoDes", $('#selDestinos option:selected').text());
        sessionStorage.setItem("Fecha", $('#selFechas').val());
        window.location.href = '/Venta/DetalleVenta';
    } else {
        window.location.href = '/Venta/SeleccionVenta';
    }

});
/*
function LlamaIniciarVenta(detVenta) {
    var url = $('#urlInicialVenta').val();
    $.ajax({
        url: url,
        type: "POST",
        data: JSON.stringify({ detVenta }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        success: successIniciaVenta,
        error: function (xmlHttpRequest, textStatus, errorThrown) {
            alert('test');
        }
    });
}
function successIniciaVenta(data) {
    if (data.Exito) {
        
        
    }
}*/



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
function successRecupDestVta(data) {
    if (data.Exito) {
        $('#selDestinos').empty();
        $('#selDestinos')
            .append($("<option></option>")
                .attr("value", "0")
                .text("¿Ha donde vamos?"));
        $.each(data.LsDestinos, function (i) {
            $('#selDestinos')
                .append($("<option></option>")
                    .attr("value", data.LsDestinos[i].IdDest)
                    .text(data.LsDestinos[i].Destino));
        });
    }
}

function ActivaCombo() {
    $('#selDestinos').change(function () {
        var detVenta = {
            idDestino: $('#selDestinos').val(),
            idSalida: $('#selSalida').val()
        };
        LlamaRecupFechVta(detVenta);
    });

    $('#selSalida').change(function () {
        var detVenta = {
            idSalida: $('#selSalida').val()
        };
        LlamaRecupDestVta(detVenta);
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
function successRecupFechVta(data) {
    if (data.Exito) {
        $('#selFechas').empty();
        $('#selFechas')
            .append($("<option></option>")
                .attr("value", "0")
                .text("Fechas"));
        $.each(data.LsFechaVta, function (i) {
            $('#selFechas')
                .append($("<option></option>")
                    .attr("value", data.LsFechaVta[i].IdVenta)
                    .text(data.LsFechaVta[i].dtFecha));
        });
    }
}