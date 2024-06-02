$(document).ready(function () { console.log("ready!!!"); });

function write(btnValue) {
    $('#display').val($('#display').val() + btnValue);
    //$('#display').val($('#display').val() + btnValue);
    console.log($('#display').val());
    
}

function btnResolver() {
    SplitEcuacion();
    Resolver();
    $('#display').val($('#display').val() + " *x=" + resX + "*y=" + resY);
}

var currentEcuacion = {};
function btnMemory() {
    
    SplitEcuacion();

    $.ajax({
        type: "POST",
        dataType: "json",
        url: "api/Calculadora/",
        data: currentEcuacion,
        success: function (result) {
            if (result == true) {
                alert("Registro Guardado");
                btnClear();
            } else {
                alert("Registro Sin guardar");
            }
        },
        error: function () {
            alert("error");
        }
    });
}



function SplitEcuacion() {
    const value = $('#display').val();

    const myArray = value.split("*");
    currentEcuacion.Id = 0;
    currentEcuacion.PrimerEcuacion = myArray[0];
    currentEcuacion.SegundaEcuacion = myArray[1];
    if (myArray.length > 2) {
        currentEcuacion.ValorX = myArray[2];
        currentEcuacion.ValorY = myArray[3];
    }
    
}

var resX = 0; var resY = 0;
function Resolver() {
    ValuesPrimerEcuacion(currentEcuacion.PrimerEcuacion);
    ValuesSegundaEcuacion(currentEcuacion.SegundaEcuacion);

    var determinante = (X1 * Y2) - (X2 * Y1);
    var determinanteX = (res1 * Y2) - (res2 * Y1);
    var determinanteY = (X1 * res2) - (X2 * res1);

    resX = determinanteX / determinante;
    resY = determinanteY / determinante;

}

var X1 = 0; var Y1 = 0; var res1 = 0;
var X2 = 0; var Y2 = 0; var res2 = 0;

function ValuesPrimerEcuacion(myEcuacion) {
    //values X
    var valueX1 = myEcuacion.split("x");
    X1 = valueX1[0];
    //Values Y
    if (myEcuacion.includes("+") == true) {
        var valueY1 = myEcuacion.split("+");
        var valueY2 = valueY1[1].split("=");
        var valueY3 = valueY2[0].split("y");

        Y1 = valueY3[0];
    } else {
        var valueY11 = myEcuacion.split("-");
        var valueY21 = valueY11[1].split("=");
        var valueY31 = valueY21[0].split("y");

        Y1 = valueY31[0];
    }
    //Values Res
    var valueR1 = myEcuacion.split("=");
    res1 = valueR1[1];

}

function ValuesSegundaEcuacion(myEcuacion) {
    //values X
    var valueX2 = myEcuacion.split("x");
    X2 = valueX2[0];
    //Values Y
    if (myEcuacion.includes("+") == true) {
        var valueY21 = myEcuacion.split("+");
        var valueY22 = valueY21[1].split("=");
        var valueY23 = valueY22[0].split("y");

        Y2 = valueY23[0];
    } else {
        var valueY211 = myEcuacion.split("-");
        var valueY221 = valueY211[1].split("=");
        var valueY231 = valueY221[0].split("y");

        Y2 = valueY231[0];
    }
    //Values Res
    var valueR2 = myEcuacion.split("=");
    res2 = valueR2[1];

}
/*Using in Historial de ecuaciones
function GetAll() {
    $.ajax({
        type: "GET",
        dataType: "json",
        url: "api/Calculadora",
        success: function (result) {
            alert(result);
        },
        error: function () {
            alert("error");
        }

    });
}

function GetByFilter(filter) {
    $.ajax({
        type: "GET",
        dataType: "json",
        url: "api/Calculadora" + filter,
        success: function (result) {
            alert(result);
        },
        error: function () {
            alert("error");
        }

    });
}

function DeleteById(id) {
    $.ajax({
        type: "Delete",
        dataType: "json",
        url: "api/Calculadora/",
        data: { "id": id },
        success: function (result) {
            alert(result);
        },
        error: function () {
            alert("error");
        }

    });
}

*/

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
    write("-");
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
    write(" * ");
}


