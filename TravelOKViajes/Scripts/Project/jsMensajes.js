
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

        let adultos = sessionStorage.getItem("Adulto");
        let ninos = sessionStorage.getItem("Nino");

        adultos = parseInt(adultos);
        ninos = parseInt(ninos);


/*
        
        
        let destino = sessionStorage.getItem("Destino");
        let salida = sessionStorage.getItem("Salida");
        let opHab = sessionStorage.getItem("OpHab");
        let total = sessionStorage.getItem("Tot");
        let destinoDes = sessionStorage.getItem("DestinoDes");
        let asientos = sessionStorage.getItem("Asientos");
        let fecha = sessionStorage.getItem("Fecha");
        */

        var datosCorreo = {
            numeroViajeros: adultos + ninos,
            fechaSalida: parseInt(sessionStorage.getItem("Fecha")),
            lugarSalida: parseInt(sessionStorage.getItem("Salida")),
            montoOperacion: sessionStorage.getItem("Tot")
        };

//        console.log(adultos);


        var url = $('#urlConfirmarPago2').val();
        $.ajax({
            url: url,
            data: datosCorreo,
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