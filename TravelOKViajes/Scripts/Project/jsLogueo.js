
$(document).on('click', '#btnIniciar', function () {
    if ($('#inUsr').val() == ''
        || $('#inPass').val() == ''){
        MensajeAdvertencia('No ha ingresado todos los datos');
        OcultaCarga();
    } else {
        var Usr = {
            Correo: $('#inUsr').val(),
            Contra: $('#inPass').val()
        };
        IniciaSesion(Usr);
    }
});

function IniciaSesion(Usr) {
    var url = $('#urlIniciaSesion').val();
    $.ajax({
        url: url,
        type: "POST",
        data: JSON.stringify({ Usr }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        success: sucessIniciaSesion,
        error: function (xmlHttpRequest, textStatus, errorThrown) {
            MensajeError('Error al Loguearse');
            OcultaCarga();
        }
    });
}

function sucessIniciaSesion(data) {
    if (data.Exito) {
        if (sessionStorage.getItem("Destino") != null) {
            window.location.href = '/Venta/DetalleVenta';
        } else {
            window.location.href = '/Home/Index';
        }
        OcultaCarga();
    } else {
        MensajeError(data.Mensaje);
        OcultaCarga();
    }
}




$(document).ready(function () {


    $('#inTel').on('keydown keypress', function (e) {
        if (e.key.length === 1) {
            if ($(this).val().length < 12 && !isNaN(parseFloat(e.key))) {
                $(this).val($(this).val() + e.key);

            }
            return false;
        }
    });

    $('#inTel2').on('keydown keypress', function (e) {
        if (e.key.length === 1) {
            if ($(this).val().length < 12 && !isNaN(parseFloat(e.key))) {
                $(this).val($(this).val() + e.key);

            }
            return false;
        }
    });

    $('#inTelEmerg').on('keydown keypress', function (e) {
        if (e.key.length === 1) {
            if ($(this).val().length < 12 && !isNaN(parseFloat(e.key))) {
                $(this).val($(this).val() + e.key);

            }
            return false;
        }
    });


});

$(document).on('click', '#btnRegistro', function () {
    if ($('#inCorreo').val() != ''
        && $('#inCorreo2').val() != ''
        && $('#inContra').val() != ''
        && $('#inContra2').val() != ''
        && $('#inTel').val() != ''
        && $('#inTel2').val() != ''
        && $('#inNom').val() != ''
        && $('#inApp').val() != ''
        && $('#inGen option:selected').text() != 'Selecciona'
        && $('#inCumple').val() != ''
        && $('#inPais').val() != ''
        && $('#inEstado').val() != ''
        && $('#inTelEmerg').val() != ''
        && $('#inParentesco').val() != '') {
        if ($('#inCorreo').val() == $('#inCorreo2').val()
            && $('#inContra').val() == $('#inContra2').val()
            && $('#inTel').val() == $('#inTel2').val()
        ) {
            var Usr = {
                Correo: $('#inCorreo').val(),
                Contra: $('#inContra').val(),
                Nombre: $('#inNom').val(),
                Apellidos: $('#inApp').val(),
                Genero: $('#inGen option:selected').text(),
                FechNac: $('#inCumple').val(),
                Pais: $('#inPais').val(),
                Estado: $('#inEstado').val(),
                Municipio: null,
                Telefono: $('#inTel').val(),
                Activo: true,
                TelefonoEmerg: $('#inTelEmerg').val(),
                ParentescoTelEmerg: $('#inParentesco').val()
            };
            Registro(Usr);
        } else {
            MensajeAdvertencia('Error en confirmar correo, contraseña o telefono');
            OcultaCarga();
        }
    } else {
        MensajeAdvertencia('No ha llenado todos los campos requeridos');
        OcultaCarga();
    }
});

function Registro(Usr) {
    var url = $('#urlRegistro').val();
    $.ajax({
        url: url,
        type: "POST",
        data: JSON.stringify({ Usr }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        success: sucessRegistro,
        error: function (xmlHttpRequest, textStatus, errorThrown) {
            MensajeError('Error');
            OcultaCarga();
        }
    });
}

function sucessRegistro(data) {
    if (data.Exito) {
        window.location.href = '/Home/Index';
    } else {
        MensajeError(data.Mensaje);
        OcultaCarga();
    }
}
