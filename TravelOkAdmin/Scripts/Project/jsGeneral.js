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