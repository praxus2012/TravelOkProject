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
/*
$(document).on('click', '.btnAsiento', function () {
    
});*/


$(document).on('click', '.btnBuscar', function () {
    var oHabitacion = {
        idViaje: $("#selFechas").val(),
        iPasajeros : parseInt($('#inNinos').val() == '' ? '0' : $('#inNinos').val()) + parseInt($('#inAdultos').val() == '' ? '0' : $('#inAdultos').val())
    };
    ObtienePropuestas(oHabitacion);
});

function ObtienePropuestas(oHabitacion) {
    var url = $('#urlObtieneProp').val();
    $.ajax({
        url: url,
        type: "POST",
        data: JSON.stringify({ oHabitacion }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        success: successObtienePropuestas,
        error: function (xmlHttpRequest, textStatus, errorThrown) {
            alert('test');
        }
    });
}

function successObtienePropuestas(data) {
    if (data.Exito) {
        var html = '';
        $('.dvOp').empty();
        var pasajeros = parseInt($('#inNinos').val() == '' ? '0' : $('#inNinos').val()) + parseInt($('#inAdultos').val() == '' ? '0' : $('#inAdultos').val());
        if (pasajeros > 2) {
            html = '<div class="col-4">' +
                '<div class="card mb-3" style="max-width: 540px;">' +
                '<div class="row no-gutters">' +
                '<div class="col-md-4 imgH">' +
                '<img src="http://www.hotelelparque.com/wp-content/uploads/2017/11/habitacion-sencilla-fomeque.jpg" class="card-img" alt="...">' +
                '</div>' +
                '<div class="col-md-8">' +
                '<div class="card-body cb-1">';
            $.each(data.Opcion0, function (i) {
                html = html + '<h4 class="card-title">Habitacion ' + data.Opcion0[i]['nvDescripcion'] + ': ' + data.Opcion0[i]['inumHab'] + '</h4>';
            });
            html = html + '<h3>Total: <label id="p-1">' + formatCurrency(data.Total0) + '</label></h3>' +
                //'<h2 class="c-1">$' + data.Total0 + '</h2>' +
                '<div class="btn btn-primary btnAsiento btnV" id="btnOp-0">ELIJE ESTE VIAJE</div>' +
                '</div>' +
                '</div>' +
                '</div>' +
                '</div>' +
                '</div>';

            html = html +'<div class="col-4">' +
                '<div class="card mb-3" style="max-width: 540px;">' +
                '<div class="row no-gutters">' +
                '<div class="col-md-4 imgH">' +
                '<img src="https://cdn.easy-rez.com/production/hotels/a5ef0afdd823b3a0448bc3198a285aee/uploads/.rooms/th_0752692001531761234.jpg" class="card-img" alt="...">' +
                '</div>' +
                '<div class="col-md-8">' +
                '<div class="card-body cb-2">';
            $.each(data.Opcion1, function (i) {
                html = html + '<h4 class="card-title">Habitacion ' + data.Opcion1[i]['nvDescripcion'] + ': ' + data.Opcion1[i]['inumHab'] + '</h4>';
            });
            html = html + '<h3>Total: <label id="p-1">' + formatCurrency(data.Total1) + '</label></h3>' +
                //'<h2 class="c-1">$' + data.Total1 + '</h2>' +
                '<div class="btn btn-primary btnAsiento btnV" id="btnOp-1">ELIJE ESTE VIAJE</div>' +
                '</div>' +
                '</div>' +
                '</div>' +
                '</div>' +
                '</div>';

            html = html +'<div class="col-4">' +
                '<div class="card mb-3" style="max-width: 540px;">' +
                '<div class="row no-gutters">' +
                '<div class="col-md-4 imgH">' +
                '<img src="https://www.hotelveracruz.com.mx/uploads/galeriahabitaciones/estandar-sencilla-hotel-veracruz-centro-b_UQkqZsm.jpg" class="card-img" alt="...">' +
                '</div>' +
                '<div class="col-md-8">' +
                '<div class="card-body cb-3">';
            $.each(data.Opcion2, function (i) {
                html = html + '<h4 class="card-title">Habitacion ' + data.Opcion2[i]['nvDescripcion'] + ': ' + data.Opcion2[i]['inumHab'] + '</h4>';
            });
            html = html + '<h3>Total: <label id="p-2">' + formatCurrency(data.Total2) + '</label></h3>' +
                //'<h2 class="c-1">$</h2>' +
                '<div class="btn btn-primary btnAsiento btnV" id="btnOp-2">ELIJE ESTE VIAJE</div>' +
                '</div>' +
                '</div>' +
                '</div>' +
                '</div>' +
                '</div>';
            $('.dvOp').append(html);
        } else {
            html = '<div class="col-4">' +
                '<div class="card mb-3" style="max-width: 540px;">' +
                '<div class="row no-gutters">' +
                '<div class="col-md-4 imgH">' +
                '<img src="http://www.hotelelparque.com/wp-content/uploads/2017/11/habitacion-sencilla-fomeque.jpg" class="card-img" alt="...">' +
                '</div>' +
                '<div class="col-md-8">' +
                '<div class="card-body cb-1">';
            $.each(data.Opcion, function (i) {
                html = html + '<h4 class="card-title">Habitacion ' + data.Opcion[i]['nvDescripcion'] + ': ' + data.Opcion[i]['inumHab'] + '</h4>';
            });
            html = html + '<h3>Total: <label id="p-3">' + formatCurrency(data.Total)+'</label></h3>' +
                '<div class="btn btn-primary btnAsiento btnV" id="btnOp-3">ELIJE ESTE VIAJE</div>' +
                '</div>' +
                '</div>' +
                '</div>' +
                '</div>' +
                '</div>';
            $('.dvOp').append(html);
        }
        GeneraClick();
    } else {
        alert('error');
    }
}

function formatCurrency(number) {
    if (number == "") return;
    number = parseFloat(number).toFixed(0);
    var n = number.split('').reverse().join("");
    console.log(n);
    var n2 = n.replace(/\d\d\d(?!$)/g, "$&,");
    return '$' + n2.split('').reverse().join('');
}

//Generar click de bton
function GeneraClick() {
    $('.btnV').click(function () {
        sessionStorage.setItem("Fecha", $('#selFechas').val());
        sessionStorage.setItem("Salida", $('#selSalida').val());
        sessionStorage.setItem("Adulto", $('#inAdultos').val() == '' ? 0 : $('#inAdultos').val());
        sessionStorage.setItem("Nino", $('#inNinos').val() == '' ? 0 : $('#inNinos').val());
        sessionStorage.setItem("OpHab", $(this).attr('id'));
        window.location.href = '/Venta/Index';
    });
}