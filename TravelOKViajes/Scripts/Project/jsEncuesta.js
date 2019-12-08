
$(document).ready(function() {
    Inicial();
    ObtenerFecha();
});

function Inicial() {
    ObtieneDestinos();
}

function ObtieneDestinos() {
    var url = $('#urlDestinoInicial').val();
    $.ajax({
        url: url,
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        success: successObtieneDestinos,
        error: function(xmlHttpRequest, textStatus, errorThrown) {
            MensajeError(data.Mensaje);
        }
    });
}
function successObtieneDestinos(data) {
    if (data.Exito) {
        $.each(data.LsDestinos, function(i) {
            $('#selDestinos')
                .append($("<option></option>")
                    .attr("value", data.LsDestinos[i].Viaje)
                    .text(data.LsDestinos[i].Destino));
        });
    } else {
        MensajeError('Ha ocurrido un error inesperado');
    }
}


function ObtenerFecha() {
    let today = new Date().toLocaleDateString()
    var lbFecha = document.getElementById('lbFecha');
    lbFecha.innerHTML = today;
}