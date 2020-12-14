function MensajeErrorBase(mensaje) {
    Swal.fire(
        'Ha ocurrido un error',
        mensaje,
        'error'
    );
}


function MensajeError(mensaje) {
    Swal.fire(
        'Ha ocurrido un error',
        mensaje,
        'error'
    ).then((result) => {
        window.location.href = "/Home/Index";
    });
}


function MensajeAdvertencia(mensaje) {
    Swal.fire(
        'Advertencia',
        mensaje,
        'warning',
    ).then((result) => {
        if (result.value) {
            OcultaCarga();
        }
    });
}


function MensajeExito(mensaje) {
    Swal.fire(
        'Completado',
        mensaje,
        'success'
    );
}



function MensajeExitoPago(mensaje) {
    Swal.fire(
        'Completado',
        mensaje,
        'success'
    ).then((result) => {
        window.location.href = "/Home/Index";
    });
}

function MensajeExitoPago2(mensaje) {
    Swal.fire(
        'Completado',
        mensaje,
        'success'
    ).then((result) => {
        var url = $('#urlConfirmarPago2').val();
        $.ajax({
            url: url,
            type: 'GET',
            dataType: 'json',
            contentType: "application/json; charset=utf-8",
            async: false,
            success: function (response) {
                window.location.href = "/Home/Index";
            }
        });
    });
}