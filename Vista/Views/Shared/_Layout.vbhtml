<!DOCTYPE html>
<html>
<head>

    <title>@ViewBag.Title - Ejercicio 4 Banco</title>

</head>
<body>
    <ul>
        <li>
            @Html.ActionLink("Cuentas", "Index", "Cuenta")
        </li>
        <li>
            @Html.ActionLink("Clientes", "Index", "Cliente")
        </li>
    </ul>
    <div>
        @RenderBody()
    </div>

</body>
</html>
