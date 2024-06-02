
function GetAll() {
    $.ajax({
        type: "GET",
        dataType: "json",
        url: "api/Calculadora",
        success: function (result) {
            FillTable(result);
        },
        error: function () {
            alert("error");
        }

    });
}

function GetByFilter() {
    filter = $("#txtSearchFilter").val();
    $.ajax({
        type: "GET",
        dataType: "json",
        url: "api/Calculadora/",
        data: { "filter": filter },
        success: function (result) {
            FillTable(result);
        },
        error: function () {
            alert("error");
        }

    });
}

function FillTable(data) {
    $('#tblEcuacion tbody').empty();

    if (data.length == 0) {
        $('#tblEcuacion tbody').append("<tr><td colspan='5' class='customertd' style='text-align:center !Important;'> Data not found.</td></tr>");
    }
    else {
        $.map(data, function (item) {
            var row = "<tr>"
                + "<td class='customertd'>" + item.PrimerEcuacion + "</td>"
                + "<td class='customertd'>" + item.SegundaEcuacion + "</td>"
                + "<td class='customertd'>" + item.ValorX + "</td>"
                + "<td class='customertd'>" + item.ValorY + "</td>"
                + "<td class='customertd'>" + "<input type='checkbox'  name='checkBoxAll' class='checkbox'  id='chkSave_" + item.Id + "' value='" + item.Id + "'   />" + "</td>"
                //  + "<td class='customertd'>" + "<input class='form-control'  name='date' placeholder='" + today + "' type='text' onclick='clickDate(" + item.AgentID + ")' id='date_" + item.AgentID + "'> " + "</td>"
                + "</tr>";
            $('#tblEcuacion tbody').append(row);

        });
    }
}

function DeleteById() {
    id = 0;
    SelectRowToDelete();
    _id = id;
    $.ajax({
        type: "Delete",
        dataType: "json",
        url: "api/Calculadora/" + id,
        success: function (result) {
            if (result == true) {
                GetAll();
                alert("Eliminado");
            } else {
                alert("No se pudo eliminar");
            }
        },
        error: function () {
            alert("error");
        }

    });
}
var id = 0;
function SelectRowToDelete() {
    var elementos = document.getElementsByName("checkBoxAll");
    
    for (x = 0; x < elementos.length; x++) {
        if (elementos[x].checked == true) {
            id = elementos[x].value;
        }
    }
}

function clickChkAll() {
    var chkAll = document.getElementsByName("checkBoxAll");

    if ($("#chkSaveAll").is(':checked')) {
        EnabledAction(chkAll);
    }
    else {
        DisabledAction(chkAll);
    }
}

function EnabledAction(elementos) {
    for (x = 0; x < elementos.length; x++) {
        elementos[x].checked = true;
    }
}

function DisabledAction(elementos) {
    for (x = 0; x < elementos.length; x++) {
        elementos[x].checked = false;
    }
}
