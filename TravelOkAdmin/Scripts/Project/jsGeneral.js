function getAsDate(day, time) {
    var hours = Number(time.match(/^(\d+)/)[1]);
    var minutes = Number(time.match(/:(\d+)/)[1]);
    var sHours = hours.toString();
    var sMinutes = minutes.toString();
    if (hours < 10) sHours = "0" + sHours;
    if (minutes < 10) sMinutes = "0" + sMinutes;
    time = sHours + ":" + sMinutes + ":00";
    var d = new Date(day);
    var n = d.toISOString().substring(0, 10);
    var newDate = new Date(n + "T" + time);
    return newDate;
}

const customFetch = async (url, metodo, body) => {
    const requestInfo = {
        method: metodo,
        headers: { 'Content-Type': 'application/json; charset=utf-8' }
    };
    requestInfo.body = metodo === 'POST' ? JSON.stringify({ body }) : null;
    return await fetch(url).then(res => res.json()).catch(err => MensajeError(err.Message));
}

const renderCombo = async (datos, referenciaHTML, id, text) => {
    referenciaHTML.options.length = 0;
    if (datos.length > 0) {
        const fragment = document.createDocumentFragment();
        const opt = document.createElement('option');
        opt.value = '';
        opt.text = 'Seleccionar';
        fragment.appendChild(opt);

        for (let i = 0; i < datos.length; i++) {
            const opt = document.createElement('option');
            opt.value = datos[i][id];
            opt.text = datos[i][text];

            fragment.appendChild(opt);
        }
        referenciaHTML.appendChild(fragment);
    }
}