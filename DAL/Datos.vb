Imports System.Data.SqlClient

Public Class Datos

    Private str As String = "Data Source=.;Initial Catalog=Ejercicio4;Integrated Security=True"

    Private cn As New SqlConnection(str)

    Public Function Leer(ByVal consulta As String, ByVal parametros As Hashtable) As DataSet
        Dim cm As New SqlCommand
        cm.CommandText = consulta
        cm.Connection = cn
        cm.CommandType = CommandType.StoredProcedure

        Dim ds As New DataSet
        If parametros IsNot Nothing Then
            For Each p As String In parametros.Keys
                cm.Parameters.AddWithValue(p, parametros(p))
            Next
        End If

        Dim da As New SqlDataAdapter(cm)
        da.Fill(ds)
        Return ds
    End Function

    Public Function Escribir(ByVal consulta As String, ByVal parametros As Hashtable) As Boolean
        Dim tran As SqlTransaction
        Try
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If

            tran = cn.BeginTransaction

            Dim cm As New SqlCommand
            cm.Connection = cn
            cm.CommandText = consulta
            cm.CommandType = CommandType.StoredProcedure
            cm.Transaction = tran

            If parametros IsNot Nothing Then
                For Each p As String In parametros.Keys
                    cm.Parameters.AddWithValue(p, parametros(p))
                Next
            End If

            cm.ExecuteNonQuery()
            tran.Commit()
            Return True
        Catch ex As Exception
            tran.Rollback()
            Return False
        Finally
            cn.Close()
        End Try

    End Function

End Class
