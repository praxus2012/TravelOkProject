$(document).ready(function () {
    CargaInicial();
});

function CargaInicial() {
    var url = $('#urlCargaInicial').val();
    $.ajax({
        url: url,
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        success: successCargaInicial,
        error: function (xmlHttpRequest, textStatus, errorThrown) {
            MensajeError(data.Mensaje);
        }
    });
}

function successCargaInicial(data) {
    if (data.Exito) {
        var valact = 0;
        $.each(data.LsSalidas, function (i) {
            $('#selViaje')
                .append($("<option></option>")
                    .attr("value", data.LsSalidas[i].Salida)
                    .text(data.LsSalidas[i].Ciudad));

        });
    } else {
        MensajeError('Ha ocurrido un error inesperado');
    }
}

$('#selViaje').on('change', function (e) {
    var oViaje{

    }
    ObtieneVentas();
});

function ObtieneVentas() {
    var url = $('#urlSalidaEliminaId').val();
    $.ajax({
        url: url,
        data: JSON.stringify({ idSalida }),
        type: "POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        success: SuccessLlamadaEliminaSalidaId,
        Advertencia: function (xmlHttpRequest, textStatus, errorThrown) {
            alert("error ", data.Mensaje, "verificar info");
        }
    });
}

function successObtieneVentas(data) {
    if (data.Exito) {
        if (data.LstFirmas1 != "") {
            $('#tbFirma1').append(data.lsViajeros);
            $('#tblFirma1').DataTable({
                select: false,
                "order": [[0, "desc"]],
                "language": {
                    "lengthMenu": "Muestra _MENU_ por página",
                    "zeroRecords": "No hay información para mostrar",
                    "info": "Mostrando _PAGE_ de _PAGES_",
                    "infoEmpty": "No hay información disponible",
                    "search": "Búsqueda:",
                    "infoFiltered": "(filtrada de _MAX_ de registros)",
                    "paginate": {
                        "first": "Primero",
                        "last": "Último",
                        "next": "Siguiente",
                        "previous": "Anterior"
                    }
                }
            });
        }
    } else {
        MensajeAdvertencia("Hubo un error al cargar la informacion");
    }
}