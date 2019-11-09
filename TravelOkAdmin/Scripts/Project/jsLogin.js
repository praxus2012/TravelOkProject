$(document).on('click', '#btnIniciarSesion', function () {
    //validador();
    var url = $('#urlHome').val();
    window.location.href = url;
});

function validador() {
    if ($('#inUsuario').val() === "" || $('#inContrasena').val() === "") {
        alert("favor de llenar los campos");
    } else {
        var datosUsuario = {
            nvUsuario: $('#inUsuario').val(),
            nvContraseña: $('#inContrasena').val()
        };
        LlamadaIniciarSesion(datosUsuario);
    }
}

function LlamadaIniciarSesion(datosUsuario) {
    var url = $('#urlLogeo').val();
    $("#imagenCargando").css("visibility", "visible");
    $.ajax({
        url: url,
        data: JSON.stringify({ datosUsuario }),
        type: "POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        success: SuccessLlamadaIniciarSesion,
        Advertencia: function (xmlHttpRequest, textStatus, errorThrown) {
            alert("error ", data.Mensaje, "verificar info");
        }
    });
}

function SuccessLlamadaIniciarSesion(data) {
    console.log(data.Exito);

    if (data.Exito) {
        var url = $('#urlHome').val();
        window.location.href = url;
    }
    else if (data.Advertencia) {
        alert("Algo salio mal");
        $("#imagenCargando").css("visibility", "hidden");
    }
    else {
        alert("Error");
    }
}
