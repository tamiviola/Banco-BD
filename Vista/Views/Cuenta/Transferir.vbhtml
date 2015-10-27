@ModelType TransferirViewModel
@Code
    ViewData("Title") = "Transferir"
End Code

<h2>Transferir</h2>

@Using (Html.BeginForm()) 
    @Html.AntiForgeryToken()
    
    @<div class="form-horizontal">
        <h4>TransferirViewModel</h4>
        <hr />
        @Html.ValidationSummary(true)
        <div class="form-group">
            @Html.LabelFor(Function(model) model.Monto, New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Monto)
                @Html.ValidationMessageFor(Function(model) model.Monto)
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.DestinoId, New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.DestinoId)
                @Html.ValidationMessageFor(Function(model) model.DestinoId)
            </div>
        </div>

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
