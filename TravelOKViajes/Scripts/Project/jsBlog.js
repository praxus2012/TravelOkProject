$(document).ready(function () {
    MuestraCarga();
    CargaInicial();
    OcultaCarga();
});

    
function CargaInicial() {
    obtenerPublicaciones();
}

function obtenerPublicaciones() {
    var url = $('#urlInicioBlog').val();
    $.ajax({
        url: url,
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        success: successObtienePublicaciones,
        error: function (xmlHttpRequest, textStatus, errorThrown) {
            MensajeError(data.Mensaje);
            //alert('error');
        }
    });
}

function successObtienePublicaciones(data) {
    console.log(data.publicaciones);
    
    if (data.publicaciones[0].sNombre = ! null) {

           $.each(data.publicaciones, function (i) {
               $('.dvValues').
                  // append('<div class="dvPublicacion"' + 'id="' + data.publicaciones[i].idBlog +'" data-toggle="modal" data-target="#modal">'
                   append('<div class="dvPublicacion"' + 'id="' + data.publicaciones[i].idBlog + '" data-toggle="modal">'
                              // + '<div class="divTitulo" >' 
                   + '<div class="divTitulo"' + 'id="' + data.publicaciones[i].idBlog + '">' 
                   + '<h2 class="tituloPublicacion">' + data.publicaciones[i].sTitulo + '</h2>'
                               + '</div>'

                               +'<div class="divImagen">' 
                   +'<img width="800" height="350" src="/Img/Publicaciones/' + data.publicaciones[i].idBlog + '.png" alt="img-' + data.publicaciones[i].sImgBlog + '" class="rounded"/>'
                               +'</div>'
                         +'</div>');

           });
   
        $('.dvPublicacion').click(function () {
            obtenerDatosPublicacion(Publicacion = { idBlog: $(this).children().attr('id') });
        });
    }
}

function MuestraCarga() {
    $(window).scrollTop(0);
    $('html').css('overflow', 'hidden');
    $('#dvCarga').css('display', 'block');
}

function OcultaCarga() {
    $('html').css('overflow', 'scroll');
    $('#dvCarga').css('display', 'none');
}

function obtenerDatosPublicacion(Publicacion) {
    var url = $('#urlDetallePublicacion').val();
    $.ajax({
        url: url,
        data: Publicacion,
        dataType: "json",
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        success: mostrarInformacionPublicacion,
        error: function (xmlHttpRequest, textStatus, errorThrown) {
            MensajeError(data.Mensaje);
            //alert('error');
        }
    });
    
}

function mostrarInformacionPublicacion(data) {
    console.log(data);
    console.log(data.publicacion.idBlog);
    $(".modalTitulo").text(data.publicacion.sTitulo);
    $("#texto").text(data.publicacion.sTexto);
    $("#imagenModal").attr("src", '/Img/Publicaciones/' + data.publicacion.idBlog + '.png');
    var nuevaFecha = data.publicacion.fechaConvertida.slice(0, 10);
    $(".modalFecha").text(nuevaFecha);
    $("#modalDetalle").modal("show");


}