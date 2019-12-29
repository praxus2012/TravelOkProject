$(document).ready(function () {
    ObtieneDestinoDet();
});

function ObtieneDestinoDet() {
    var url = $('#urlinicialSelVent').val();
    $.ajax({
        url: url,
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        success: successObtieneDestinos,
        error: function (xmlHttpRequest, textStatus, errorThrown) {
            MensajeError(data.Mensaje);
        }
    });
}

function successObtieneDestinos(data) {
    if (data.Exito) {
        $.each(data.LsDestinos, function (i) {
            $('.dvCards').append(
                '<div class="col-4 cor-' + data.LsDestinos[i]['IdDestino'] + '">' +
                '<div class= "card mb-3" style = "max-width: 540px;">' +
                '<div class="row no-gutters">' +
                '<div class="col-md-4">' +
                '<img src="/Img/ImgDestinos/' + data.LsDestinos[i]['sDestino'] + '.png" class="card-img" alt="...">' +
                '</div>' +
                '<div class="col-md-8">' +
                '<div class="card-body">' +
                '<h4 class="card-title">' + data.LsDestinos[i]['sDestino'] + '</h4>' +
                '<h3>Desde:</h3>' +
                '<h2>$' + data.LsDestinos[i]['dCostoLugar'] + '</h2>' +
                '<div class="btn btn-primary" id="bt-' + data.LsDestinos[i]['IdDestino'] + '-' + data.LsDestinos[i]['sDestino'] +'">ELIJE ESTE VIAJE</div>' +
                '</div>' +
                '</div>' +
                '</div>' +
                '<div class="row">' +
                '<img class="col-12 m-auto" src="../Img/Ventas/Salidas.PNG"/>' +
                '</div>' +
                '</div>' +
                '</div>'

            );
        });
    } else {
        MensajeError('Ha ocurrido un error inesperado');
    }
}