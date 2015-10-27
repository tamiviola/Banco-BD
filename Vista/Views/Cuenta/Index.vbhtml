@ModelType IEnumerable(Of EE.CuentaBancaria)

<h2>Listar</h2>

<p>
    @Html.ActionLink("Crear Nuevo CA", "CrearCajaDeAhorro")
    <br />
    @Html.ActionLink("Crear Nuevo CC", "CrearCuentaCorriente")
</p>
<table class="table">
    <tr>
        <th>
            Número de cuenta
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Saldo)
        </th>
        <th>
            Tipo
        </th>
        <th></th>
    </tr>

    @For Each item In Model
        @<tr>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Id)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Saldo)
            </td>
            <td>
                @code
                If item.GetType() = GetType(EE.CajaDeAhorros) Then
                @: Caja de ahorro
                Else
                @: Cuenta corriente
                End If
                End Code
            </td>
            <td>
                @Html.ActionLink("Transferir", "Transferir", New With {.id = item.Id}) |
                @Html.ActionLink("Extraer", "Extraer", New With {.id = item.Id}) |
                @Html.ActionLink("Depositar", "Depositar", New With {.id = item.Id}) |
                @Html.ActionLink("Edit", "Edit", New With {.id = item.Id}) |
                @Html.ActionLink("Detalle", "Detalle", New With {.id = item.Id}) |
                @Html.ActionLink("Delete", "Delete", New With {.id = item.Id})
            </td>
        </tr>
    Next

</table>
