@ModelType EE.CuentaCorriente

<h2>Crear</h2>

@Using (Html.BeginForm())
    @Html.AntiForgeryToken()

    @<div>
        <h4>CuentaBancaria</h4>
        <hr />
        @Html.ValidationSummary(True)
        <div class="form-group">
            <label>
                Clientes
            </label>
            <br />
            @Html.ListBoxFor(Function(model) model.ListaClientesSeleccionados, New MultiSelectList(DirectCast(ViewBag.Clientes, IEnumerable(Of EE.Cliente)), "Id", "Nombre"))
            <br />
        </div>
        <div class="form-group">
            <div>
                <input type="submit" value="Crear" />
            </div>
        </div>
    </div>
End Using

<div>
    @Html.ActionLink("Volver", "Index")
</div>
