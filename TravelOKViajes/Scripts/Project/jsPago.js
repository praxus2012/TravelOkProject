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


$("#btnPagar").click(function (e) {
    e.preventDefault();
    $("#modalDatosPago").modal();
});

$("#btnEnviarDatosTarjeta").click(function (e) {
    console.log(2);

    if (verificarCamposTarjeta()) {

        MensajeAdvertencia("Debe completar todos los campos para proceder con el pago");

    } else {


        enviarDatosTarjeta();


    }





});


function verificarCamposTarjeta() {

    let camposVacios = false;

    if ($("#idnumTarjeta").val().trim() == "" || $("#idTipoTarjeta").val() == 0 || $("#idmesVencimiento").val() == 0 || $("#idañoVencimiento").val() == 0 || $("#idcodigoSeguridad").val().trim() == "") {
        camposVacios = true;
    }
        

    return camposVacios;
}

function enviarDatosTarjeta() {

    var url = $('#urlDatosTarjeta').val();

    $.ajax({
        url: url,

        data: {
            numeroTarjeta: $("#idnumTarjeta").val(),
            tipoTarjeta: $("#idTipoTarjeta").val(),
            mesVencimiento: $("#idmesVencimiento").val(),
            anioVencimiento: $("#idañoVencimiento").val(),
            codigoSeguridad: $("#idcodigoSeguridad").val()
        },
        type: 'POST',
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        async: false,
        success: function (response) {
         

        }
    });

}





$(document).on('click', '.btRe', function () {
    MensajeExitoPago('Se ha realizado su apartado con exito, cualquier cancelacion con el equipo travel');    
});