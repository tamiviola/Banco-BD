@ModelType EE.CuentaBancaria

<h2>Detalle</h2>

<div>
    <h4>CuentaBancaria</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Id)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Id)
        </dd>
        <dt>
            @Html.DisplayNameFor(Function(model) model.Saldo)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Saldo)
        </dd>
        <dt>
            Tipo
        </dt>

        <dd>
            @Code
                If Model.GetType() = GetType(EE.CuentaCorriente) Then
                    @: Cuenta Corriente
                Else
                    @: Caja de Ahorro
                End If
            End Code
        </dd>
        <dt>
            Clientes
        </dt>

        <dd>
            @Code
                For Each c As EE.Cliente In Model.ListaClientes
                    @c.Nombre @c.Apellido
                Next
            End Code
        </dd>
    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.Id }) |
    @Html.ActionLink("Back to List", "Index")
</p>
