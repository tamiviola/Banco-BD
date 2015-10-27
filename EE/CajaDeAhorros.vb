Public Class CajaDeAhorros
    Inherits CuentaBancaria

    Public Overrides Function Extraer(monto As Double) As Boolean
        Dim CantidadCienes As Integer = Convert.ToInt16(monto / 100)
        Dim Interes As Double = (CantidadCienes * 0.01) * monto
        If Me.Saldo + Interes >= monto Then
            Me.Saldo = Me.Saldo - monto - Interes
            Return True
        Else
            Return False
        End If
    End Function

    Public Overrides Function Transferencia(cuentaDestino As CuentaBancaria, monto As Double) As Boolean
        If Me.Saldo >= monto Then
            Me.Saldo = Me.Saldo - monto
            cuentaDestino.Saldo = cuentaDestino.Saldo + monto
            Return True
        Else
            Return False
        End If
    End Function
End Class
