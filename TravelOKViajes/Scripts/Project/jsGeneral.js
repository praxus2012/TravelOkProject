$(document).on('click', '.btn', function () {
    
    MuestraCarga();
});

$(document).on('click', 'a', function () {

    MuestraCarga();
});

$(document).on('click', '#afb', function () {
    OcultaCarga();
});

$(document).on('click', '#aig', function () {
    OcultaCarga();
});
$(document).on('click', '#awp', function () {
    OcultaCarga();
});

$(document).on('click', '.close', function () {
    OcultaCarga();
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