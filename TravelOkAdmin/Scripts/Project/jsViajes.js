$(document).ready(function () {
    GeneraClicks();
    localStorage.clear();
});

function GeneraClicks() {
    $(".btnCan").click(function () {
        $('#dv' + this.id.split('-')[1]).remove();
        $('#s' + this.id.split('-')[1]).remove();
        if (localStorage.getItem("counter") == 2) {
            localStorage.clear();
        }
    });
}

$(document).on("click", "#btnAgregarSalida", function (e) {
    AgregarSalida();
});

function AgregarSalida() {
    if (localStorage.getItem("counter") == null) {
        var counter = 2;
        $("#dvIotras").append('<div class="row" id="dv' + counter + '"><div id="diISalida"' + counter + '>Salida</div>' +
            '<select class="form-control" id="selISalidaCost' + counter + '">' +
            '<option value="0">Selecciona de donde salimos</option></select><div class="container">' +
            '<div class="row"><div class="col-5">' +
            '<div id="diIFechas' + counter + '">Fecha de Salida</div>' +
            '<input type="date" id="fISalida' + counter + '" />' +
            '<div id="diIhoras' + counter + '">Hora de Salida</div>' +
            '<input type="time" id="hISalida' + counter + '" />' +
            '</div><div class="col-5">' +
            '<div id="diIFechar' + counter + '">Fecha de Regreso</div>' +
            '<input type="date" id="fIRegreso' + counter + '" />' +
            '<div id="diIhorar' + counter + '">Hora de Regreso</div>' +
            '<input type="time" id="hIRegreso' + counter + '" />' +
            '</div></div></div>' +
            '<div id="btnCancViaje-' + counter + '" class="btn btn-primary btnCan mt-3">Cancelar</div></div><hr id="s' + counter + '" />'
        );
        localStorage.setItem("counter", counter);
    } else {
        var counter = localStorage.getItem("counter");
        counter++;
        $("#s" + (counter - 1)).after('<div class="row" id="dv' + counter + '"><div id="diISalida"' + counter + '>Salida</div>' +
            '<select class="form-control" id="selISalidaCost' + counter + '">' +
            '<option value="0">Selecciona de donde salimos</option></select><div class="container">' +
            '<div class="row"><div class="col-5">' +
            '<div id="diIFechas' + counter + '">Fecha de Salida</div>' +
            '<input type="date" id="fISalida' + counter + '" />' +
            '<div id="diIhoras' + counter + '">Hora de Salida</div>' +
            '<input type="time" id="hISalida' + counter + '" />' +
            '</div><div class="col-5">' +
            '<div id="diIFechar' + counter + '">Fecha de Regreso</div>' +
            '<input type="date" id="fIRegreso' + counter + '" />' +
            '<div id="diIhorar' + counter + '">Hora de Regreso</div>' +
            '<input type="time" id="hIRegreso' + counter + '" />' +
            '</div></div></div>' +
            '<div id="btnCancViaje-' + counter + '" class="btn btn-primary btnCan mt-3">Cancelar</div></div><hr id="s' + counter + '" />'
        );
        localStorage.setItem("counter",counter);
    }
    GeneraClicks();
}