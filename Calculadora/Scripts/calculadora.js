$(document).ready(function () { console.log("ready!!!"); });
function btnUno() {
    write("1");
}
function btnDos() {
    write("2");
}
function btnTres() {
    write("3");
}
function btnCuatro() {
    write("4");
}
function btnCinco() {
    write("5");
}
function btnSeis() {
    write("6");
}
function btnSiete() {
    write("7");
}
function btnOcho() {
    write("8");
}
function btnNueve() {
    write("9");
}
function btnCero() {
    write("0");
}
function btnIgual() {
    write("=");
}
function btnMas() {
    write("+");
}
function btnMenos() {
    write("1");
}
function btnSigno() {
    write("-");
}
function btnX() {
    write("x");
}
function btnY() {
    write("y");
}
function btnClear() {
    display.value = "";
}
function btnEnter() {
    write("*** ");
}
let currentVal = "";
function write(btnValue) {
    
    $('#display').val($('#display').val() + btnValue);
    
}

function btnResolver() {
    alert("Guardar");
}


function btnMemory() {
    $.ajax({
        type: "GET",
        datatype: "json",
        url: "api/Calculadora/" + 1,
        success: function (result) {
            alert(result);
        },
        error: function () {
            alert("Error!!!");
        }
    });
}




