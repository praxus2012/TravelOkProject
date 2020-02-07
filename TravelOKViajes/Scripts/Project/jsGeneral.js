$(document).on('click', '.btn', function () {
    MuestraCarga();
});

function MuestraCarga() {
    $('#dvCarga').css('display', 'block');
}

function OcultaCarga() {
    $('#dvCarga').css('display', 'none');
}