$(document).ready(function () {
    var options = {
        valueNames: ['dropdown-item-name']
    };
    ObtieneDestinos();
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
        $.each(data.LsDestinos, function (i) {
            $.each(data.LsDestinos[i], function (key, val) {
                if ($.isNumeric(val))
                    valact = val;
                else {
                    $('#selDestinos')
                        .append($("<option></option>")
                            .attr("value", valact)
                            .text(val));
                }
            });
        });
        valact = 0;
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
    var detVenta = {
        idSalida : $('#selSalida').val(),
        idDestino : $('#selDestinos').val(),
        sFecha : $('#selFechas').val()
    };
    LlamaIniciarVenta(detVenta);
});

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
        window.location.href = '/Venta/SeleccionVenta';
    }
}