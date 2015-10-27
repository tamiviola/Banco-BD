@ModelType DepositarViewModel

<h2>Depositar</h2>

@Using (Html.BeginForm())
    @Html.AntiForgeryToken()

    @<div class="form-horizontal">
        <h4>DepositarViewModel</h4>
        <hr />
        @Html.ValidationSummary(True)
        <label>Monto</label>
        @Html.TextBoxFor(Function(model) model.Monto)
    <div class="form-group">
        <div class="col-md-offset-2 col-md-10">
            <input type="submit" value="Create" class="btn btn-default" />
        </div>
    </div>
</div>
End Using

<div>
    @Html.ActionLink("Back to List", "Index")
</div>
