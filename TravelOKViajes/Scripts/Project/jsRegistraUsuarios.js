var asientosTot = 0;
$(document).ready(function () {
    GeneraRegistros();
});

function GeneraRegistros() {
    asientosTot = parseInt(sessionStorage.getItem("Adulto")) + parseInt(sessionStorage.getItem("Nino"));
    var AsSelec = sessionStorage.getItem("Asientos").split('|');
    var htmlOptions = '';
    $.each(AsSelec, function (i) {
        htmlOptions = htmlOptions + '<option>Asiento-' + AsSelec[i] + '</option>';
    });
    var html = '';
    for (var i = 0; i < asientosTot; i++) {
        html = html + '<div class="mt-5">Traveler ' + (i+1) + '</div> <div id="dvPer-' + i + '">' +
            '<input type="text" placeholder="Nombre completo" class="form-control mt-3">' +
            '<select name="" id="selAsiento" class="form-control mt-3">' +
            htmlOptions +
            '</select>' +
            '<input type="email" placeholder="correo@ejemplo.com" class="form-control mt-3">' +
            '<input type="number" placeholder="Edad" max="150" min="0" class="form-control mt-3">' +
            '<input type="tel" placeholder="Teléfono" class="form-control mt-3">' +
            '</div>';
    }
    $('.dvRegistro').append(html);
}
