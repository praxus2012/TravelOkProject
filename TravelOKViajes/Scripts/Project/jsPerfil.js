$(document).ready(function () {
    MuestraCarga();
    CargaInicial();
    OcultaCarga();
});


function CargaInicial() {
    ObtieneDeudas();
}

function ObtieneDeudas() {
    var url = $('#urlInicialPerfil').val();
    $.ajax({
        url: url,
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        success: successObtieneDeudas,
        error: function (xmlHttpRequest, textStatus, errorThrown) {
            MensajeError(data.Mensaje);
            //alert('error');
        }
    });
}

function successObtieneDeudas(data) {
    if (data.Exito) {
        $.each(data.olsDeudaViaje, function (i) {
            $('#dvDeudas').
                append('<div class="card"><div class="card-header">' + data.olsDeudaViaje[i]['sDestino'] + ' - ' + convertirFecha(data.olsDeudaViaje[i]['dtFechaSalida'].split('T')[0]) + '</div>'+
                '<div class="card-body"><p>Usted tiene un adeudo de : ' + ('$' + data.olsDeudaViaje[i]['dAdeudo'].toFixed(2).replace(/(\d)(?=(\d\d\d)+(?!\d))/g, "$1,")) + '</p><p>Costo por boleto : ' + ('$' + data.olsDeudaViaje[i]['dCostoViajero'].toFixed(2).replace(/(\d)(?=(\d\d\d)+(?!\d))/g, "$1,")) + '</p>' +
                '<p>Seleccione el archivo con el pago correspondiente</p><input type="file" id="Arch-' + data.olsDeudaViaje[i]['idViaje'] + '" name="Archivo" data-inpunt="false" data-show-preview="false" accept="image/png, image/jpeg" placeholder="Subir Archivo">' +
                '<div id="dvPago-' + data.olsDeudaViaje[i]['idViaje'] + '" class="btn btn-EnvPg mt-2 mb-2 btn-primary form-control">Enviar Pago</div><footer class="blockquote-footer">Se evaluara la informacion y se cambiara el estatus del pago.</footer></div></div>');
        });
        GeneraClick();
    } else {
        if (NoViaje) {
            MensajeAdvertencia('Usted no tiene viajes pendientes.');
        } else {
            MensajeError('Ha ocurrido un error inesperado.');
        }        
    }
}

function GeneraClick() {
    $('.btn-EnvPg').click(function () {
        var DatosPago = new FormData();
        DatosPago.append("idViaje", this.id.split('-')[1]);
        DatosPago.append("sNomArch", $("#Arch-" + this.id.split('-')[1]).prop("files")[0]);
        InsertaPago(DatosPago);
    });
}


function InsertaPago(DatosPago) {
    var url = $('#urlInsertaPago').val();
    $.ajax({
        url: url,
        data: DatosPago,
        type: "POST",
        contentType: false,
        processData: false,
        async: true,
        success: successInsertaPago,
        error: function (xmlHttpRequest, textStatus, errorThrown) {
            MensajeError(data.Mensaje);
        }
    });
}

function successInsertaPago(data) {
    var Respuesta = JSON.parse(data);
    if (Respuesta.Exito) {
        OcultaCarga();
        MensajeExito('Se ha actualizado su pago con éxito.');
    } else {
        MensajeError(Respuesta.Mensaje);
    }
}

function convertirFecha(fechaSinFormato) {

    let fechaNueva = "";

    let fechaDividida = fechaSinFormato.split("-");

    fechaNueva = fechaDividida[2] + "-" + fechaDividida[1] + "-" + fechaDividida[0];

    return fechaNueva;


}