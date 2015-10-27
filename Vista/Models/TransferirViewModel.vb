Public Class TransferirViewModel
    Private vMonto As Double
    Public Property Monto() As Double
        Get
            Return vMonto
        End Get
        Set(ByVal value As Double)
            vMonto = value
        End Set
    End Property

    Private vDestinoId As Integer
    Public Property DestinoId() As Integer
        Get
            Return vDestinoId
        End Get
        Set(ByVal value As Integer)
            vDestinoId = value
        End Set
    End Property

End Class
