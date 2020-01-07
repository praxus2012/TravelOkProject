$(document).ready(function () {
    $('#hDest').text($('#hDest').text() + sessionStorage.getItem('DestinoDes'));
    FuncionesIniciales();
    ActivaCombo();
});

function FuncionesIniciales() {
    if (sessionStorage.getItem("Destino") != null) {
        var oDest = {
            idDestino: sessionStorage.getItem("Destino")
        };
        ObtieneSalidaDet(oDest);
        
        //window.location.href = '/Venta/DetalleVenta';
    } 
}

/*
 sessionStorage.setItem("Salida", $('#selSalida').val());
        sessionStorage.setItem("Destino", $('#selDestinos').val());
        sessionStorage.setItem("DestinoDes", $('#selDestinos option:selected').text());
        sessionStorage.setItem("Fecha", $('#selFechas').val());
 */

function ObtieneSalidaDet(oDest) {
    var url = $('#urlinicialDetVent').val();
    $.ajax({
        url: url,
        type: "POST",
        data: JSON.stringify({ oDest }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        success: successObtieneSalidaDet,
        error: function (xmlHttpRequest, textStatus, errorThrown) {
            alert('test');
        }
    });
}

function successObtieneSalidaDet(data) {
    if (data.Exito) {
        $('#selSalida').empty();
        $('#selSalida')
            .append($("<option></option>")
                .attr("value", "0")
                .text("¿De dónde salimos?"));
        $.each(data.LsSalidas, function (i) {
            $('#selSalida')
                .append($("<option></option>")
                    .attr("value", data.LsSalidas[i].idSalida)
                    .text(data.LsSalidas[i].sSalida));
        });
        if (sessionStorage.getItem("Salida") != null) {
            $('#selSalida').val(sessionStorage.getItem("Salida"));
            var detVenta = {
                idDestino: sessionStorage.getItem("Destino"),
                idSalida: $('#selSalida').val()
            };
            LlamaRecupFechVta(detVenta);
        }
    }
}

function ActivaCombo() {
    /*$('#selDestinos').change(function () {
        var detVenta = {
            idDestino: $('#selDestinos').val(),
            idSalida: $('#selSalida').val()
        };
        LlamaRecupFechVta(detVenta);
    });*/

    $('#selSalida').change(function () {
        var detVenta = {
            idDestino: sessionStorage.getItem("Destino"),
            idSalida: $('#selSalida').val()
        };
        LlamaRecupFechVta(detVenta);
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

        if (sessionStorage.getItem("Fecha") != null) {
            $('#selFechas').val(sessionStorage.getItem("Fecha"));
        }
    }
}

$(document).on('click', '.btnAsiento', function () {
    sessionStorage.setItem("Fecha", $('#selFechas').val());
    sessionStorage.setItem("Salida", $('#selSalida').val());
    sessionStorage.setItem("Adulto", $('#inAdultos').val() == '' ? 0 : $('#inAdultos').val());
    sessionStorage.setItem("Nino", $('#inNinos').val() == '' ? 0 : $('#inNinos').val());
    window.location.href = '/Venta/Index';
});