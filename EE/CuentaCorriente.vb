Public Class CuentaCorriente
    Inherits CuentaBancaria

    Private vDescubierto As Double = 1000
    Public Property Descubierto() As Double
        Get
            Return vDescubierto
        End Get
        Set(ByVal value As Double)
            vDescubierto = value
        End Set
    End Property

    Public Overrides Function Extraer(monto As Double) As Boolean
        If Me.Saldo + Me.Descubierto >= monto Then
            Me.Saldo = Me.Saldo - monto
            Return True
        Else
            Return False
        End If
    End Function

    Public Overrides Function Transferencia(cuentaDestino As CuentaBancaria, monto As Double) As Boolean
        If Me.Saldo + Me.Descubierto >= monto Then
            Me.Saldo = Me.Saldo - monto
            cuentaDestino.Saldo = cuentaDestino.Saldo + monto
            Return True
        Else
            Return False
        End If
    End Function
End Class
