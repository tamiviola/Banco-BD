@ModelType EE.Cliente

<h2>Crear</h2>

@Using (Html.BeginForm()) 
    @Html.AntiForgeryToken()
    
    @<div>
        <h4>Cliente</h4>
        <hr />
        @Html.ValidationSummary(true)
        <div class="form-group">
            @Html.LabelFor(Function(model) model.Nombre, New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Nombre)
                @Html.ValidationMessageFor(Function(model) model.Nombre)
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.Apellido, New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Apellido)
                @Html.ValidationMessageFor(Function(model) model.Apellido)
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.Direccion, New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Direccion)
                @Html.ValidationMessageFor(Function(model) model.Direccion)
            </div>
        </div>

         <div class="form-group">
             @Html.LabelFor(Function(model) model.Telefono.Tipo, New With {.class = "control-label col-md-2"})
             <div class="col-md-10">
                 @Html.EditorFor(Function(model) model.Telefono.Tipo)
                 @Html.ValidationMessageFor(Function(model) model.Telefono.Tipo)
             </div>
         </div>

         <div class="form-group">
             @Html.LabelFor(Function(model) model.Telefono.Numero, New With {.class = "control-label col-md-2"})
             <div class="col-md-10">
                 @Html.EditorFor(Function(model) model.Telefono.Numero)
                 @Html.ValidationMessageFor(Function(model) model.Telefono.Numero)
             </div>
         </div>

        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <input type="submit" value="Crear" class="btn btn-default" />
            </div>
        </div>
    </div>
End Using

<div>
    @Html.ActionLink("Volver", "Index")
</div>
