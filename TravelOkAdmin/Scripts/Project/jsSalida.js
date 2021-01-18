const btnAgregar = document.getElementById('btnAgregarSal');
const inSalida = document.getElementById('inSalida');
const urlSalidaInserta = document.getElementById('urlSalidaInserta').value;
const urlDestinoInicial = document.getElementById('urlDestinoInicial').value;
//const formSesion = document.getElementById('formSesion');

const ObtieneSalidas = async () => {
    const data = await customFetch(urlDestinoInicial, 'GET');
    successObtieneSaalidas(data);
}

function successObtieneSaalidas(data) {
    if (data.Exito) {
        const selSalida = document.getElementById('selSalida');
        renderCombo(data.LsSalidas, selSalida, 'Salida', 'Ciudad');
    } else {
        MensajeError('Ha ocurrido un error inesperado');
    }
}


//formSesion.addEventListener('submit', async function (ev) {
//    ev.preventDefault();
//    const formdata = new FormData(this);
//    let data = {};
//    formdata.forEach(function (value, key) {
//        data[key] = value;
//    });
//    const respuesta = await customFetch(api_route, data);
//    if (respuesta.Success) {
//        
//    } else {
//        
//    }
//});

//-- Agregar

btnAgregar.addEventListener('click', () => {
    if (inSalida.value === "") {
        MensajeAdvertencia("No has ingresado una salida");
    } else {
        LlamaInsertaSalida(inSalida.value);
    }
})


const LlamaInsertaSalida = async (sSalida) => {
    const request = await customFetch(urlSalidaInserta, 'POST', { ssalida: sSalida });
    SuccessLlamadaInsertaSalida(request);
}

function SuccessLlamadaInsertaSalida(data) {
    if (data.Exito) {
        MensajeExito("Se ha agregado la salida correctamente");
        $('#inSalida').val('');

        $('#selSalida').empty();
        ObtieneSalidas();

    } else {
        MensajeAdvertencia("Ha ocurrido un error inesperado, intentelo mas tarde.");
    }
}


//-- Modificar

const ObtieneSalidasModif = async () => {
    const request = await customFetch(urlDestinoInicial, 'GET');
    successObtieneSaalidasModif(request);
}

function successObtieneSaalidasModif(data) {
    if (data.Exito) {
        const selSalidaM = document.getElementById('selSalidaM');
        renderCombo(data.LsSalidas, selSalidaM, 'Salida', 'Ciudad');
    } else {
        MensajeError('Ha ocurrido un error inesperado');
    }
}

$('#selSalidaM').on('change', function (e) {
    $('#inMSalida').val($("#selSalidaM option:selected").text());
    $('#dvMSalida').removeClass("d-none");
});

$(document).on('click', '#btnMdifCiudad', function (e) {
    if ($('#inMSalida').val() === "") {
        MensajeAdvertencia("No has ingresado el nombre de salida");
    } else {
        //var CDsalida = {
        IdSalida = $('#selSalidaM').val();
        Ciudad = $('#inMSalida').val();
        //}
        LlamaModificaSalida(IdSalida, Ciudad);
    }
});

function LlamaModificaSalida(IdSalida, Ciudad) {
    var url = $('#urlSalidaModif').val();
    $.ajax({
        url: url,
        data: JSON.stringify({ IdSalida, Ciudad }),
        type: "POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        success: SuccessLlamadaModificaSalida,
        Advertencia: function (xmlHttpRequest, textStatus, errorThrown) {
            alert("error ", data.Mensaje, "verificar info");
        }
    });
}

function SuccessLlamadaModificaSalida(data) {
    if (data.Exito) {
        MensajeExito("Se ha modificado la salida correctamente");
       // $('#inMSalida').val('');

        $('#selSalidaM').empty();
        ObtieneSalidasModif();

    } else {
        MensajeAdvertencia("Ha ocurrido un error inesperado, intentelo mas tarde.");
    }
}

//--Eliminar

$(document).on('click', '#btnEliminaCiudad', function (e) {
    if ($('#selSalida').val() === "") {
        MensajeAdvertencia("No has ingresado una salida");
    } else {
        var idCiudad = $('#selSalida').val();
        LLamaEliminaSalidaId(idCiudad);
    }
});

function LLamaEliminaSalidaId(idSalida) {
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

function SuccessLlamadaEliminaSalidaId(data) {
    if (data.Exito) {
        MensajeExito('Se ha eliminado correctamente');
        $('#selSalida').empty();
        ObtieneSalidas();
        // $('#selSalida').val(0);
    } else {
        MensajeAdvertencia('Ha ocurrido un error');
    }

}

ObtieneSalidas();
ObtieneSalidasModif();