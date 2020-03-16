var asientosTot = 0;
$(document).ready(function () {
    GeneraRegistros();
});

function GeneraRegistros() {
    asientosTot = parseInt(sessionStorage.getItem("Adulto")) + parseInt(sessionStorage.getItem("Nino"));
    var AsSelec = sessionStorage.getItem("Asientos").split('|');
    var htmlOptions = '<option value="0">Seleccione el asiento donde viaja</option>';
    $.each(AsSelec, function (i) {
        htmlOptions = htmlOptions + '<option value="' + AsSelec[i] + '">Asiento-' + AsSelec[i] + '</option>';
    });
    var html = '';
    for (var i = 0; i < asientosTot; i++) {
        html = html + '<div class="mt-5">Traveler ' + (i+1) + '</div> <div id="dvPer-' + i + '">' +
            '<input type="text" placeholder="Nombre(s)" class="form-control mt-3 inNombre">' +
            '<input type="text" placeholder="Apellidos" class="form-control mt-3 inApellidos">' +
            '<select name="" class="form-control mt-3 selAsiento">' +
            htmlOptions +
            '</select>' +
            '<input type="email" placeholder="correo@ejemplo.com" class="form-control mt-3 inEmail">' +
            '<input type="number" pattern="[0-9]" placeholder="Edad" max="150" min="0" class="form-control mt-3 inEdad">' +
            '<input type="number" placeholder="Teléfono" class="form-control mt-3 inTel">' +
            '</div>';
    }
    $('.dvRegistro').append(html);
}


$(document).on('click', '#btnContinuar', function () {
    var bCorrecto = true;
    for (var i = 0; i < asientosTot; i++) {
        if ($('#dvPer-' + i).find('.inNombre').val() == ""
            || $('#dvPer-' + i).find('.selAsiento option:selected').val() == ""
            || $('#dvPer-' + i).find('.inEmail').val() == ""
            || $('#dvPer-' + i).find('.inApellidos').val() == ""
            || $('#dvPer-' + i).find('.inEdad').val() == ""
            || $('#dvPer-' + i).find('.inTel').val() == "") {
            bCorrecto = false;
            break;
        }
    }
    if (bCorrecto) {
        var selecAsientos = "";
        for (var j = 0; j < asientosTot; j++) {
            if (j == 0) {
                selecAsientos = $('#dvPer-' + j).find('.selAsiento option:selected').val();
            } else {
                var asAct = $('#dvPer-' + j).find('.selAsiento option:selected').val();
                var grAs = selecAsientos.split('|');
                var agregar = true;
                for (var x = 0; x < grAs.length; x++) {
                    if (grAs[x] == asAct) {
                        agregar = false;
                        break;
                    }
                }
                if (agregar) {
                    selecAsientos = selecAsientos + "|" + asAct;
                } else {
                    bCorrecto = false;
                    break;
                }                
            }
        }
        if (bCorrecto) {
            var oUsrViajeros = [];
            for (var y = 0; y < asientosTot; y++) {
                var oViajero = {
                    idViaje: sessionStorage.getItem('Fecha'),
                    sNombre: $('#dvPer-' + y).find('.inNombre').val(),
                    sApellido: $('#dvPer-' + y).find('.inApellidos').val(),
                    sCorreo: $('#dvPer-' + y).find('.inEmail').val(),
                    iEdad: $('#dvPer-' + y).find('.inEdad').val(),
                    iAsiento: $('#dvPer-' + y).find('.selAsiento option:selected').val(),
                    sTelefono: $('#dvPer-' + y).find('.inTel').val(),
                    sOpcionTour: sessionStorage.getItem('OpHab')
                };
                oUsrViajeros.push(
                    oViajero
                );
            }
            RegistraViajeros(oUsrViajeros);

        } else {
            MensajeAdvertencia('No puede repetir asientos');
            OcultaCarga();
        }
    } else {
        MensajeAdvertencia('No ha seleccionado todos los campos');
        OcultaCarga();
    }
});

function RegistraViajeros(oUsrViajeros) {
    var url = $('#urlInsertaViajeros').val();
    $.ajax({
        url: url,
        type: "POST",
        data: JSON.stringify({ oUsrViajeros }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        success: successRegistraViajeros,
        error: function (xmlHttpRequest, textStatus, errorThrown) {
            MensajeError('Problema al crear el registro, favor de acudir con un asistente');
            OcultaCarga();
        }
    });
}

function successRegistraViajeros(data) {
    if (data.Exito) {
        window.location.href = "/Venta/Pago";
    } else {
        MensajeAdvertencia("Ocurrio un error inesperado, favor de acudir con un administrador");
    }

}