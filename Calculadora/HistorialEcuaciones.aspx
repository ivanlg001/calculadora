<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HistorialEcuaciones.aspx.cs" Inherits="Calculadora.HistorialEcuaciones" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/HistorialEcuaciones.js"></script>
    <script src="Scripts/jquery-3.1.1.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="text-bg-light text-center">
            <p style="font-size:300%;">Historial de ecuaciones</p>
        </div>
        <div class="container-sm text-center">
		    <input type="text" class="form-control" id="txtSearchFilter" />
            <table>
                <tr>
                    <td><input type="button" value="Buscar" id="btnSearch" class="btn btn-primary" data-loading-text="Buscando..." onclick="GetAll();" /></td>
                    <td><input type="button" value="Buscar por filtro" id="btnSearchByFilter" class="btn btn-primary" data-loading-text="Buscando..." onclick="GetByFilter();" /></td>
                    <td><input type="button" value="Eliminar" id="btnDelete" class="btn btn-danger" data-loading-text="Eliminando..." onclick="DeleteById();" /></td>
                </tr>
            </table>
            
 		</div>
        <div id="gridViewEcuacion" class="container-sm">
            <table id="tblEcuacion" data-show-refresh="true" data-search="true" class="table table-striped table-bordered table-hover table-condensed">
                <thead>
                    <tr>
                        <th style="" data-field="PrimerEcuacion">
                            <div class="th-inner ">Primer Ecuacion</div>
                            <div class="fht-cell"></div>
                        </th>
                        <th style="" data-field="SegundaEcuacion">
                            <div class="th-inner ">Segunda Ecuacion</div>
                            <div class="fht-cell"></div>
                        </th>
                        <th style="" data-field="ValorX">
                            <div class="th-inner ">Valor X</div>
                            <div class="fht-cell"></div>
                        </th>
                        <th style="" data-field="ValorY">
                            <div class="th-inner ">Valor Y</div>
                            <div class="fht-cell"></div>
                        </th>

                        <th style="width: 100px;" >
                            <div class="th-inner ">Eliminar</div>
                            <div class="fht-cell"></div>
                            <%--<div class="th-inner "><input type="checkbox"  class="checkbox" onchange="clickChkAll();" id="clickChkAll" /></div>
                            <div class="fht-cell"></div>--%>
                        </th>
                    </tr>
                </thead>
                <tbody>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>
