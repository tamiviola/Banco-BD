Public Class CuentaBancariaBLL

    Private vCuentabMPP As MPP.CuentaBancariaMPP

    Sub New()
        Me.vCuentabMPP = New MPP.CuentaBancariaMPP
    End Sub

    Public Function Crear(ByVal cuentab As EE.CuentaBancaria) As Boolean
        Return Me.vCuentabMPP.Crear(cuentab)
    End Function

    Public Function Editar(ByVal cuentab As EE.CuentaBancaria) As Boolean
        Return Me.vCuentabMPP.Editar(cuentab)
    End Function

    Public Function Eliminar(ByVal id As Integer) As Boolean
        Return Me.vCuentabMPP.Eliminar(id)
    End Function

    Public Function ConsultaPorId(ByVal id As Integer) As EE.CuentaBancaria
        Return Me.vCuentabMPP.ConsultaPorId(id)
    End Function

    Public Function Listar() As List(Of EE.CuentaBancaria)
        Return Me.vCuentabMPP.Listar
    End Function

    Public Function Depositar(ByVal id As Integer, ByVal monto As Double) As Boolean
        Dim cuentab As EE.CuentaBancaria
        cuentab = Me.vCuentabMPP.ConsultaPorId(id)
        cuentab.Depositar(monto)
        Me.vCuentabMPP.Editar(cuentab)
        Return True
    End Function

    Public Function Extraer(ByVal id As Integer, ByVal monto As Double) As Boolean
        Dim cuentab As EE.CuentaBancaria
        cuentab = Me.vCuentabMPP.ConsultaPorId(id)
        If cuentab.Extraer(monto) Then
            Return Me.vCuentabMPP.Editar(cuentab)
        Else
            Return False
        End If
    End Function

    Public Function Transferir(ByVal idOrigen As Integer, ByVal idDestino As Integer, ByVal monto As Double) As Boolean
        Dim cuentaO As EE.CuentaBancaria
        Dim cuentaD As EE.CuentaBancaria
        cuentaO = Me.vCuentabMPP.ConsultaPorId(idOrigen)
        cuentaD = Me.vCuentabMPP.ConsultaPorId(idDestino)
        If cuentaO.Transferencia(cuentaD, monto) Then
            If Me.vCuentabMPP.Editar(cuentaD) Then
                If Me.vCuentabMPP.Editar(cuentaO) Then
                    Return True
                End If
            End If
            Return False
        Else
            Return False
        End If
    End Function
End Class
