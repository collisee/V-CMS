Imports System.Globalization
Imports System.Data.SqlClient
Imports System.Web.UI.WebControls
Imports System.Web
Imports System.Configuration
Imports System


Public Class Connection
    Private objConn As New SqlConnection

    Private Function OpenConnection() As Boolean
        'Dim objReg As New MyRegistry
        'objReg.getRegs()
        If objConn.State = ConnectionState.Closed Then
            objConn.ConnectionString = getConnectionStr()
            'objReg.strConnection
            objConn.Open()
        End If
        'objReg = Nothing
        If objConn.State = ConnectionState.Open Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Function OpenConnectionOra() As Boolean
        Try
            If objConn.State = ConnectionState.Closed Then
                objConn.ConnectionString = getConnectionStr()
                objConn.Open()
            End If
            If objConn.State = ConnectionState.Open Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try

    End Function

    Private Function getConnectionStr() As String
        Dim connectString As String = ""
        Try
            connectString = ConfigurationManager.AppSettings("ConnectionString")
            'connectString = ConfigurationSettings.AppSettings("ConnectionString")
        Catch ex As Exception
            connectString = ""
        End Try
        Return connectString
    End Function

    Public Sub CloseConnection()
        If objConn.State = ConnectionState.Open Then
            objConn.Close()
            objConn = Nothing
        End If
    End Sub

    Public Function getConnection() As SqlConnection
        If OpenConnection() Then
            Return objConn
        Else
            Return Nothing
        End If
    End Function
End Class