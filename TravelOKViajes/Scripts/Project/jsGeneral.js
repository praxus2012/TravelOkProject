$(document).on('click', '.btn', function () {
    
    MuestraCarga();
});

function MuestraCarga() {
    $(window).scrollTop(0);
    $('html').css('overflow', 'hidden');
    $('#dvCarga').css('display', 'block');
}

function OcultaCarga() {
    $('html').css('overflow', 'scroll');
    $('#dvCarga').css('display', 'none');
}