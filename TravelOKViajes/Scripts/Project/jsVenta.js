/*$(document).on('click', $('#ulPrimerAsiento').children(), function (e) {
    alert('texto' + $(this).attr('id'));
});*/

var asientosTot = 0;
var seleccion = "";
$(document).ready(function () {
    asientosTot = parseInt(sessionStorage.getItem("Adulto")) + parseInt(sessionStorage.getItem("Nino"));
    if (asientosTot > 0) {
        GeneraAutobus();
        $('#hdes').text($('#hdes').text() + sessionStorage.getItem("DestinoDes"));
        $('#txDis').text($('#txDis').text() + asientosTot);
    } else {
        window.location.href = '/Home/Index';
    }
    
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
                $('.ui-f-' + i).append('<li class="asiento del" id="a-' + asiento + '">' + asiento + '</li>');
                asiento++;
            }
        }
        for (i = 0; i < data.oTransporte.NumFilcolDos; i++) {
            $('#ulDer').append('<li class="f-' + i + ' fila"><ul class="ud-f-' + i + ' columnas ci"></ul></li>');
            //alert(data.oTransporte.NumColUno);
            for (j = 0; j < data.oTransporte.NumColDos; j++) {
                $('.ud-f-' + i).append('<li class="asiento del" id="a-' + asiento + '">' + asiento + '</li>');
                asiento++;
            }
        }
        if (data.oTransporte.FilaTrasera) {
            for (i = 0; i < data.oTransporte.NumAsTrasera; i++) {
                $('#ulAtras').append('<li class="asiento atras" id="a-' + asiento + '">' + asiento + '</li>');
                asiento++;
            }
        }
        if (data.oTransporte.SaniTrasero) {
            $('#ulAtras').append('<li class="bano atras"></li>');
        }
        GeneraClick();
    }
}

function GeneraClick() {
    $('.asiento').click(function (evt) {
        if ($(this).attr('class').split(' ').length > 2) {
            alert('Asiento ocupado');
        } else {
            //alert($('#' + $(this).attr('id')).css('background-image').split('/')[$('#' + $(this).attr('id')).css('background-image').split('/').length - 1]);
            if ($('#' + $(this).attr('id')).css('background-image').split('/')[$('#' + $(this).attr('id')).css('background-image').split('/').length - 1] == 'ASeleccionado.jpg")') {
                $('#' + $(this).attr('id')).css("background-image", "url('../../Img/Asientos/ALibre.jpg')");
                asientosTot = asientosTot + 1;
                var sSafar = seleccion.split('|');
                seleccion = '';
                for (var i = 0; i < sSafar.length; i++) {
                    if (sSafar[i] != $(this).attr('id').split('-')[1]) {
                        if (seleccion == "") {
                            seleccion = sSafar[i];
                        } else {
                            seleccion = seleccion + '|' + sSafar[i];
                        }
                    }
                }
            } else {
                if (asientosTot > 0) {
                    $('#' + $(this).attr('id')).css("background-image", "url('../../Img/Asientos/ASeleccionado.jpg')");
                    asientosTot = asientosTot - 1;
                    if (seleccion == "") {
                        seleccion = $(this).attr('id').split('-')[1];
                    } else {
                        seleccion = seleccion + '|' + $(this).attr('id').split('-')[1];
                    }
                }
            }
        }
    });
}