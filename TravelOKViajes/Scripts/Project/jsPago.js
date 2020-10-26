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



paypal.Buttons({
    createOrder: function (data, actions) {
        // This function sets up the details of the transaction, including the amount and line item details.
        return actions.order.create({
            purchase_units: [{
                amount: {
                    value: sessionStorage.getItem("Tot")
                }
            }]
        });
    },
    onApprove: function (data, actions) {
        // This function captures the funds from the transaction.
        return actions.order.capture().then(function (details) {
            // This function shows a transaction success message to your buyer.
            OcultaCarga();
            MensajeExitoPago2('Pago completado ' + details.payer.name.given_name);
        });
    },
    onError: function (err) {
        OcultaCarga();
        // Show an error page here, when an error occurs
        MensajeError('Ocurrió un problema al realizar el pago');
    }
}).render('#paypal-button-container');
  //This function displays Smart Payment Buttons on your web page.


$(document).on('click', '.btRe', function () {
    ConfirmarPago();      
});

function ConfirmarPago() {
    var url = $('#urlConfirmarPago').val();
    $.ajax({
        url: url,
        type: 'GET',
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        async: false,
        success: function (response) {
            successConfirmaPago()
        }
    });
}

function successConfirmaPago(data) {
    if (data.Exito) {
        MensajeExitoPago('Se ha realizado su apartado con exito, cualquier cancelacion con el equipo travel');
    } else {
        MensajeError('Ha ocurrido un error inesperado, consulte con el equipo travel, la información se encuentra disponible en la sección de contacto')
    }
}