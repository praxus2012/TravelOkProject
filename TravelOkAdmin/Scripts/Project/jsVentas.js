$(document).ready(function () {
    CargaInicial();
});

function CargaInicial() {

}

$();

function successObtieneVentas(data) {
    if (data.Exito) {
        if (data.LstFirmas1 != "") {
            $('#tbFirma1').append(data.LstFirmas1);
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