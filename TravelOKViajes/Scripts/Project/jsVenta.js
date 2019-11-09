/*$(document).on('click', $('#ulPrimerAsiento').children(), function (e) {
    alert('texto' + $(this).attr('id'));
});*/

$('#ulPrimerAsiento').children().click(function (evt) {
    alert('texto ' + $(this).attr('id'));
});