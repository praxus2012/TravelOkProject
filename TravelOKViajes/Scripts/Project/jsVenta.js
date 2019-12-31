/*$(document).on('click', $('#ulPrimerAsiento').children(), function (e) {
    alert('texto' + $(this).attr('id'));
});*/

$('#ulPrimerAsiento').children().click(function (evt) {
    alert('texto ' + $(this).attr('id'));
});

$(document).ready(function () {
    GeneraAutobus();
});

function GeneraAutobus() {
    var detVenta = {
        idVenta: sessionStorage.getItem("Fecha")
    };
    ObtieneAutobus(detVenta);
}

function ObtieneAutobus(detVenta) {
    var url = $('#urlinicialTrans').val();
    $.ajax({
        url: url,
        type: "POST",
        data: JSON.stringify({ detVenta }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        success: successObtieneAutobus,
        error: function (xmlHttpRequest, textStatus, errorThrown) {
            alert('Error de datos');
        }
    });
}

function successObtieneAutobus(data) {
    if (data.Exito) {
        //alert(data.oTransporte.IdTransporte);
        var i,j,asiento=1;
        for (i = 0; i < data.oTransporte.NumFilColUno; i++) {
            $('#ulIzq').append('<li class="f-' + i + ' fila"><ul class="ui-f-' + i + ' columnas ci"></ul></li>');
            //alert(data.oTransporte.NumColUno);
            for (j = 0; j < data.oTransporte.NumColUno; j++) {
                $('.ui-f-' + i ).append('<li class="asiento a-' + asiento + '">' + asiento + '</li>');
                asiento++;
            }
        }
        for (i = 0; i < data.oTransporte.NumFilcolDos; i++) {
            $('#ulDer').append('<li class="f-' + i + ' fila"><ul class="ud-f-' + i + ' columnas ci"></ul></li>');
            //alert(data.oTransporte.NumColUno);
            for (j = 0; j < data.oTransporte.NumColDos; j++) {
                $('.ud-f-' + i).append('<li class="asiento a-' + asiento + '">' + asiento + '</li>');
                asiento++;
            }
        }
        if (data.oTransporte.FilaTrasera) {
            for (i = 0; i < data.oTransporte.NumAsTrasera; i++) {
                $('#ulAtras').append('<li class="asiento atras a-' + asiento + '">' + asiento + '</li>');
                asiento++;
            }
        }
        if (data.oTransporte.SaniTrasero) {
            $('#ulAtras').append('<li class="bano atras"></li>');
        }
    }
}