Public Class DepositarViewModel

    Private vMonto As Double
    Public Property Monto() As Double
        Get
            Return vMonto
        End Get
        Set(ByVal value As Double)
            vMonto = value
        End Set
    End Property

End Class
