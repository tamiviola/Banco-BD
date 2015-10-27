Imports System.Web.Mvc

Public Class CuentaController
    Inherits Controller

    Private vbll As BLL.CuentaBancariaBLL
    Private vbllCliente As BLL.ClienteBLL

    Sub New()
        Me.vbll = New BLL.CuentaBancariaBLL
        Me.vbllCliente = New BLL.ClienteBLL
    End Sub

    ' GET: /Cuenta
    Function Index() As ActionResult
        Dim vLista As List(Of EE.CuentaBancaria) = Me.vbll.Listar()
        Return View(vLista)
    End Function

    ' GET: /Cuenta/Details/5
    Function Detalle(ByVal id As Integer) As ActionResult
        Return View(Me.vbll.ConsultaPorId(id))
    End Function

    Function CrearCajaDeAhorro() As ActionResult
        ViewBag.Clientes = Me.vbllCliente.Listar()
        Return View()
    End Function

    <HttpPost()>
    Function CrearCajaDeAhorro(ByVal c As EE.CajaDeAhorros) As ActionResult
        If ModelState.IsValid Then
            For Each id As Integer In c.ListaClientesSeleccionados
                Dim cliente As New EE.Cliente
                cliente.Id = id
                c.ListaClientes.Add(cliente)
            Next
            Me.vbll.Crear(c)
            Return RedirectToAction("Index")
        End If

        ViewBag.Clientes = Me.vbllCliente.Listar()
        Return View(c)
    End Function

    Function CrearCuentaCorriente() As ActionResult
        ViewBag.Clientes = Me.vbllCliente.Listar()
        Return View()
    End Function

    <HttpPost()>
    Function CrearCuentaCorriente(ByVal c As EE.CuentaCorriente) As ActionResult
        If ModelState.IsValid Then
            For Each id As Integer In c.ListaClientesSeleccionados
                Dim cliente As New EE.Cliente
                cliente.Id = id
                c.ListaClientes.Add(cliente)
            Next
            Me.vbll.Crear(c)
            Return RedirectToAction("Index")
        End If

        ViewBag.Clientes = Me.vbllCliente.Listar()
        Return View(c)
    End Function

    Function Depositar() As ActionResult
        Return View()
    End Function

    <HttpPost()>
    Function Depositar(ByVal id As Integer, ByVal model As DepositarViewModel) As ActionResult
        If ModelState.IsValid Then
            Me.vbll.Depositar(id, model.Monto)
            Return RedirectToAction("Index")
        End If

        Return View(model)
    End Function

    Function Extraer() As ActionResult
        Return View()
    End Function

    <HttpPost()>
    Function Extraer(ByVal id As Integer, ByVal model As DepositarViewModel) As ActionResult
        If ModelState.IsValid Then
            Me.vbll.Extraer(id, model.Monto)
            Return RedirectToAction("Index")
        End If

        Return View(model)
    End Function

    Function Transferir() As ActionResult
        ViewBag.Cuentas = Me.vbll.Listar()
        Return View()
    End Function

    <HttpPost()>
    Function Transferir(ByVal id As Integer, ByVal model As TransferirViewModel) As ActionResult
        If ModelState.IsValid Then
            Me.vbll.Transferir(id, model.DestinoId, model.Monto)
            Return RedirectToAction("Index")
        End If
        ViewBag.Cuentas = Me.vbll.Listar()
        Return View(model)
    End Function

    ' GET: /Cuenta/Edit/5
    Function Edit(ByVal id As Integer) As ActionResult
        Return View()
    End Function

    ' POST: /Cuenta/Edit/5
    <HttpPost()>
    Function Edit(ByVal id As Integer, ByVal collection As FormCollection) As ActionResult
        Try
            ' TODO: Add update logic here

            Return RedirectToAction("Index")
        Catch
            Return View()
        End Try
    End Function

    ' GET: /Cuenta/Delete/5
    Function Delete(ByVal id As Integer) As ActionResult
        Return View()
    End Function

    ' POST: /Cuenta/Delete/5
    <HttpPost()>
    Function Delete(ByVal id As Integer, ByVal collection As FormCollection) As ActionResult
        Try
            ' TODO: Add delete logic here

            Return RedirectToAction("Index")
        Catch
            Return View()
        End Try
    End Function
End Class