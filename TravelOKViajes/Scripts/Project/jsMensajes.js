
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