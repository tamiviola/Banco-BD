Public Class ClienteMPP

    Private vDatos As DAL.Datos

    Sub New()
        Me.vDatos = New DAL.Datos
    End Sub

    Public Function Crear(ByVal cliente As EE.Cliente) As Boolean
        Dim parametros As New Hashtable

        parametros.Add("@Nombre", cliente.Nombre)
        parametros.Add("@Apellido", cliente.Apellido)
        parametros.Add("@Direccion", cliente.Direccion)
        parametros.Add("@TelefonoTipo", cliente.Telefono.Tipo)
        parametros.Add("@TelefonoNumero", cliente.Telefono.Numero)

        Return Me.vDatos.Escribir("s_CrearCliente", parametros)
    End Function

    Public Function Listar() As List(Of EE.Cliente)
        Dim ds As DataSet
        ds = Me.vDatos.Leer("s_ListarCliente", Nothing)

        Dim lista As New List(Of EE.Cliente)
        If ds.Tables(0).Rows.Count > 0 Then
            For Each dr As DataRow In ds.Tables(0).Rows
                Dim c As New EE.Cliente
                c.Id = dr.Item("Id")
                c.Nombre = dr.Item("Nombre")
                c.Apellido = dr.Item("Apellido")
                c.Direccion = dr.Item("Direccion")
                c.Telefono.Tipo = dr.Item("Tipo")
                c.Telefono.Numero = dr.Item("Numero")
                lista.Add(c)
            Next
        End If
        Return lista
    End Function

End Class
