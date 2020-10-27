$(document).ready(function () {
    $('#hDest').text($('#hDest').text() + sessionStorage.getItem('DestinoDes'));
    FuncionesIniciales();
    ActivaCombo();
    OcultaCarga();
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
            MensajeError('Ocurrió un error inesperado');
            OcultaCarga();
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
        OcultaCarga();
    } else {
        MensajeError("Existe un problema");
        OcultaCarga();
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
            MensajeError('Error de datos');
            OcultaCarga();
        }
    });
}
function successRecupFechVta(data) {
    console.log(data.LsFechaVta);
    if (data.Exito) {
        $('#selFechas').empty();
        $('#selFechas')
            .append($("<option></option>")
                .attr("value", "0")
                .text("Fechas"));
        $.each(data.LsFechaVta, function (i) {

            var fecha = data.LsFechaVta[i].dtFecha;

            var $nuevaFecha = fecha.toString().slice(0, 10);

            $('#selFechas')
                .append($("<option></option>")
                    .attr("value", data.LsFechaVta[i].IdVenta)
                    .text(convertirFecha($nuevaFecha)));
        });

        if (sessionStorage.getItem("Fecha") != null) {
            $('#selFechas').val(sessionStorage.getItem("Fecha"));
        }
        OcultaCarga();
    } else {
        MensajeError("Ha ocurrido un error inesperado");
        OcultaCarga();
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
            MensajeError('Problema al cargar');
            OcultaCarga();
        }
    });
}

function successObtienePropuestas(data) {
    if (data.Exito) {
        var html = '';
        $('.dvOp').empty();
        var pasajeros = parseInt($('#inNinos').val() == '' ? '0' : $('#inNinos').val()) + parseInt($('#inAdultos').val() == '' ? '0' : $('#inAdultos').val());
        if (pasajeros > 2) {
            html = '<div class="col-sm">' +
                '<div class="card mb-3" style="max-width: 540px;">' +
                '<div class="row no-gutters">' +
                '<div class="col-md-4 imgH">' +
                '<img src="/Img/imagenHotel.jpg" class="card-img col-12" alt="...">' +
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

            html = html +'<div class="col-sm">' +
                '<div class="card mb-3" style="max-width: 540px;">' +
                '<div class="row no-gutters">' +
                '<div class="col-md-4 imgH">' +
                '<img src="/Img/imagenHotel.jpg" class="card-img col-12" alt="...">' +
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

            html = html +'<div class="col-sm">' +
                '<div class="card mb-3" style="max-width: 540px;">' +
                '<div class="row no-gutters">' +
                '<div class="col-md-4 imgH">' +
                '<img src="/Img/imagenHotel.jpg" class="card-img col-12" alt="...">' +
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
            html = '<div class="col-sm">' +
                '<div class="card mb-3" style="max-width: 540px;">' +
                '<div class="row no-gutters">' +
                '<div class="col-md-4 imgH">' +
                '<img src="/Img/imagenHotel.jpg" class="card-img col-12" alt="...">' +
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
        OcultaCarga();
    } else {
        MensajeAdvertencia('Ocurrió un problema al cargar la información');
        OcultaCarga();
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
        console.log($('#p-' + $(this).attr('id').split('-')[1]).text());
        sessionStorage.setItem("Tot", $('#p-' + $(this).attr('id').split('-')[1]).text().replace('$', '').replace(',', ''));
        window.location.href = '/Venta/Index';
    });
}


function convertirFecha(fechaSinFormato) {

    let fechaNueva = "";

    let fechaDividida = fechaSinFormato.split("-");

    fechaNueva = fechaDividida[2] + "-" + fechaDividida[1] + "-" + fechaDividida[0];

    return fechaNueva;


}