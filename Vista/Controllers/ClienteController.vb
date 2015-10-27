Imports System.Web.Mvc

Public Class ClienteController
    Inherits Controller

    Private vBLL As BLL.ClienteBLL

    Sub New()
        Me.vBLL = New BLL.ClienteBLL
    End Sub

    ' GET: /Cliente
    Function Index() As ActionResult
        Dim vlistaCli As List(Of EE.Cliente) = vBLL.Listar
        Return View(vlistaCli)
    End Function

    ' GET: /Cliente/Details/5
    Function Details(ByVal id As Integer) As ActionResult
        Return View()
    End Function

    ' GET: /Cliente/Create
    Function Crear() As ActionResult
        Return View()
    End Function

    ' POST: /Cliente/Create
    <HttpPost()>
    Function Crear(ByVal cli As EE.Cliente) As ActionResult
        If ModelState.IsValid Then
            Me.vBLL.Crear(cli)
            Return RedirectToAction("Index")
        End If
        Return View(cli)
    End Function

    ' GET: /Cliente/Edit/5
    Function Edit(ByVal id As Integer) As ActionResult
        Return View()
    End Function

    ' POST: /Cliente/Edit/5
    <HttpPost()>
    Function Edit(ByVal id As Integer, ByVal collection As FormCollection) As ActionResult
        Try
            ' TODO: Add update logic here

            Return RedirectToAction("Index")
        Catch
            Return View()
        End Try
    End Function

    ' GET: /Cliente/Delete/5
    Function Delete(ByVal id As Integer) As ActionResult
        Return View()
    End Function

    ' POST: /Cliente/Delete/5
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