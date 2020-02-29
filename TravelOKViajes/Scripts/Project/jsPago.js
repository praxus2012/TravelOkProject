$(document).ready(function () {
    if (parseInt(sessionStorage.getItem("Adulto"))
        + parseInt(sessionStorage.getItem("Nino") > 1)){
        $('.dvAs').text(parseInt(sessionStorage.getItem("Adulto"))
            + parseInt(sessionStorage.getItem("Nino")) + " Personas");
    } else {
        $('.dvAs').text(parseInt(sessionStorage.getItem("Adulto"))
            + parseInt(sessionStorage.getItem("Nino")) + " Persona");
    }
    
});

$(document).on('click', '.btn-link', function () {
    OcultaCarga();
});

$(document).on('click', '.btRe', function () {
    MensajeExitoPago('Se ha realizado su apartado con exito, cualquier cancelacion con el equipo travel');    
});