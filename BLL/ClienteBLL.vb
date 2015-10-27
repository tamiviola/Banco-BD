Public Class ClienteBLL

    Private vClienteMPP As MPP.ClienteMPP

    Sub New()
        Me.vClienteMPP = New MPP.ClienteMPP
    End Sub

    Public Function Crear(ByVal cliente As EE.Cliente) As Boolean
        Return Me.vClienteMPP.Crear(cliente)
    End Function

    Public Function Listar() As List(Of EE.Cliente)
        Return Me.vClienteMPP.Listar()
    End Function

End Class
