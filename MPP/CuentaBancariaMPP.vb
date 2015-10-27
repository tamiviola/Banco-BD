Public Class CuentaBancariaMPP

    Private vDatos As DAL.Datos

    Sub New()
        Me.vDatos = New DAL.Datos
    End Sub

    Public Function Crear(ByVal cuentab As EE.CuentaBancaria) As Boolean
        Dim parametros As New Hashtable

        If cuentab.GetType = GetType(EE.CajaDeAhorros) Then
            parametros.Add("@Tipo", "CajaDeAhorro")
        Else
            parametros.Add("@Tipo", "CuentaCorriente")
        End If

        Dim dt As New DataTable
        dt.Columns.Add("Id")
        For Each cliente As EE.Cliente In cuentab.ListaClientes
            Dim dr As DataRow = dt.NewRow
            dr.Item("Id") = cliente.Id
            dt.Rows.Add(dr)
        Next
        parametros.Add("@Clientes", dt)

        Return Me.vDatos.Escribir("s_CrearCuenta", parametros)
    End Function

    Public Function Editar(ByVal cuentab As EE.CuentaBancaria) As Boolean
        Dim parametros As New Hashtable

        parametros.Add("@Id", cuentab.Id)
        parametros.Add("@Saldo", cuentab.Saldo)
        If cuentab.GetType = GetType(EE.CajaDeAhorros) Then
            parametros.Add("@Tipo", "CajaDeAhorro")
        Else
            parametros.Add("@Tipo", "CuentaCorriente")
        End If

        Dim dt As New DataTable
        dt.Columns.Add("Id")
        For Each cliente As EE.Cliente In cuentab.ListaClientes
            Dim dr As DataRow = dt.NewRow
            dr.Item("Id") = cliente.Id
            dt.Rows.Add(dr)
        Next
        parametros.Add("@Clientes", dt)

        Return Me.vDatos.Escribir("s_EditarCuenta", parametros)
    End Function

    Public Function Eliminar(ByVal id As Integer) As Boolean
        Return Nothing
    End Function

    Public Function ConsultaPorId(ByVal id As Integer) As EE.CuentaBancaria
        Dim parametros As New Hashtable
        parametros.Add("@Id", id)
        Dim ds As DataSet = Me.vDatos.Leer("s_ConsultarPorIdCuenta", parametros)
        If ds.Tables(0).Rows.Count > 0 Then
            Dim dr As DataRow = ds.Tables(0).Rows(0)
            Dim c As EE.CuentaBancaria
            If dr.Item("Tipo") = "CuentaCorriente" Then
                c = New EE.CuentaCorriente
            Else
                c = New EE.CajaDeAhorros
            End If
            c.Id = dr.Item("Id")
            c.Saldo = dr.Item("Saldo")
            If ds.Tables(1).Rows.Count > 0 Then
                For Each row As DataRow In ds.Tables(1).Rows
                    Dim cli As New EE.Cliente
                    cli.Id = row.Item("Id")
                    cli.Nombre = row.Item("Nombre")
                    cli.Apellido = row.Item("Apellido")
                    cli.Direccion = row.Item("Direccion")
                    cli.Telefono.Tipo = row.Item("Tipo")
                    cli.Telefono.Numero = row.Item("Numero")
                    c.ListaClientes.Add(cli)
                Next
            End If
            Return c
        End If
        Return Nothing
    End Function

    Public Function Listar() As List(Of EE.CuentaBancaria)
        Dim ds As DataSet
        ds = Me.vDatos.Leer("s_ListarCuenta", Nothing)

        Dim lista As New List(Of EE.CuentaBancaria)
        If ds.Tables(0).Rows.Count > 0 Then
            For Each dr As DataRow In ds.Tables(0).Rows
                Dim cb As EE.CuentaBancaria
                If dr.Item("Tipo") = "CuentaCorriente" Then
                    cb = New EE.CuentaCorriente
                Else
                    cb = New EE.CajaDeAhorros
                End If
                cb.Id = dr.Item("Id")
                cb.Saldo = dr.Item("Saldo")
                lista.Add(cb)
            Next
        End If
        Return lista
    End Function

End Class
