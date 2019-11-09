$(document).ready(function () {
    CargaInicial();
});


function CargaInicial() {
    ObtieneDestinos();
}

function ObtieneDestinos() {
    var url = $('#urlInicioDestinos').val();
    $.ajax({
        url: url,
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        success: successObtieneDestinos,
        error: function (xmlHttpRequest, textStatus, errorThrown) {
            MensajeError(data.Mensaje);
            //alert('error');
        }
    });
}

function successObtieneDestinos(data) {
    if (data.Exito) {
        $.each(data.lsDestinosImg, function (i) {
            $('.dvValues').
                append('<div class="d-flex justify-content-start dvDestino" data-size="865x1280" data-toggle="modal" data-target="#modal">' +
                '<img src="/Img/ImgDestinos/' + data.lsDestinosImg[i]['sTitulo'] + '.png" alt="img-' + data.lsDestinosImg[i]['idViaje'] + '" class="rounded"/>' +
                    '</div>');
        });
        $('.dvDestino').click(function () {
            ObtieneDestinoDet(Destino = { idViaje: $(this).children().attr('alt').split('-')[1] });
        });
    } else {
        MensajeError('Ha ocurrido un error inesperado');
    }
}


function ObtieneDestinoDet(Destino) {
    var url = $('#urlObtieneCarrDestino').val();
    $.ajax({
        url: url,
        data: JSON.stringify(Destino),
        type: "POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        success: successObtieneDestinosDet,
        error: function (xmlHttpRequest, textStatus, errorThrown) {
            MensajeError(data.Mensaje);
            //alert('error');
        }
    });
}


function successObtieneDestinosDet(data) {
    if (data.Exito) {
        $('.hTitmodal').text(data.DestinoDet['sTitulo']);
        $('.hSubTmodal').text(data.DestinoDet['sSubTit']);
        $('#dvInfo').text(data.DestinoDet['sDescrip']);
        var contador = 0;
        $('.carousel-indicators').empty();
        $('.carousel-inner').empty();
        $.each(data.LsCarrDestinos, function (i) {
            if (i === 0) {
                $('.carousel-indicators').append('<li data-target="#carouselExampleIndicators" data-slide-to="' + contador + '" class="active"></li>');
                $('.carousel-inner').append('<div class="carousel-item active">' +
                    '<div class= "d-block Im-' + data.LsCarrDestinos[i]['Id_Detalle'] + '"></div>' +
                    '</div>');
                $('.Im-' + data.LsCarrDestinos[i]['Id_Detalle']).css('background-image', 'url("../../Img/ImgDestDetalle/' + data.LsCarrDestinos[i]['sDestino'] + '/' + data.LsCarrDestinos[i]['sRutaImg']+'")');
            } else {
                $('.carousel-indicators').append('<li data-target="#carouselExampleIndicators" data-slide-to="' + contador + '"></li>');
                $('.carousel-inner').append('<div class="carousel-item">' +
                    '<div class= "d-block Im-' + data.LsCarrDestinos[i]['Id_Detalle'] + '"></div>' +
                    '</div>');
                $('.Im-' + data.LsCarrDestinos[i]['Id_Detalle']).css('background-image', 'url("../../Img/ImgDestDetalle/' + data.LsCarrDestinos[i]['sDestino'] + '/' + data.LsCarrDestinos[i]['sRutaImg'] + '")');
            }
            contador++;
        });

    } else {
        MensajeError('Ha ocurrido un error inesperado');
    }
}



//$(document).on('click', '.dvHuas', function (e) {
    //if(data.LsDestinos.count==1){
    /*$('.carousel-indicators').append('<li data-target="#carouselExampleIndicators" data-slide-to="0" class="active"></li>');
    $('.carousel-indicators').append('<div class="carousel-item active">' +
        '<div class= "d-block fsh"> holi crayoli</div>'+
                                    '</div>');*/
    
    //}
//});