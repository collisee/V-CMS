Imports Microsoft.ApplicationBlocks.Data
Imports System.Data.SqlClient
Imports System.Web.UI.WebControls

Namespace Data
    Public Class ExRateInfor
        Public _CurrencyCode As String
        Public _CurrencyName As String
        Public _Buy As String
        Public _Sell As String
        Public _Transfer As String
        Public _ExRateDate As Date
        Public _tblExRateService As String = "vnn_infoservice"
        Public _inforType As String = "NT"
    End Class

    Public Class ExRateController
        Public Shared Sub InsertExRate (ByVal objConn As SqlConnection, ByVal objExRate As ExRateInfor)
            SqlHelper.ExecuteNonQuery (objConn, "InsertExRate", objExRate._CurrencyCode, objExRate._CurrencyName, _
                                       objExRate._Buy, objExRate._Transfer, objExRate._Sell, objExRate._ExRateDate)
        End Sub

        Public Shared Sub DeleteExRateGw()
            Dim _
                connG As _
                    New MySql.Data.MySqlClient.MySqlConnection ( _
                                                                System.Configuration.ConfigurationManager.AppSettings ( _
                                                                                                                       "ConnectionStringGW"))
            Dim cmd As New MySql.Data.MySqlClient.MySqlCommand
            Dim objExRate As New ExRateInfor
            Try
                If connG.State = ConnectionState.Closed Then
                    connG.Open()
                End If
                With cmd
                    .CommandType = CommandType.Text
                    .CommandText = "DELETE FROM " & objExRate._tblExRateService & _
                                   " Where date_format(info_date,'%Y-%m-%d') = '" & _
                                   String.Format ("{0:yyyy-MM-dd}", DateTime.Now) + "'" & _
                                   " AND info_type = '" & objExRate._inforType & "'"
                    .Connection = connG

                    .ExecuteNonQuery()

                End With
            Catch ex As Exception
                Util.WriteLog ("InsertGoldPriceGw.Error: " & ex.ToString)
                'Console.ReadLine()
            Finally
                connG.Close()
                connG = Nothing
            End Try

        End Sub

        Public Shared Sub InsertExRateGw (ByVal strExRateContent As String)
            Dim _
                connG As _
                    New MySql.Data.MySqlClient.MySqlConnection ( _
                                                                System.Configuration.ConfigurationManager.AppSettings ( _
                                                                                                                       "ConnectionStringGW"))
            Dim cmd As New MySql.Data.MySqlClient.MySqlCommand
            Dim objExRate As New ExRateInfor
            Try
                If connG.State = ConnectionState.Closed Then
                    connG.Open()
                End If
                With cmd
                    .CommandType = CommandType.Text
                    .CommandText = "insert into " & objExRate._tblExRateService & _
                                   "(info_type,info_date,content,last_update,last_user)" & _
                                   " VALUES " & _
                                   "('" + objExRate._inforType + "','" + String.Format ("{0:s}", DateTime.Now) + "','" + _
                                   strExRateContent + "','" + _
                                   String.Format ("{0:s}", DateTime.Now) + "'," + "'Administrator'" + _
                                   ")"
                    .Connection = connG

                    .ExecuteNonQuery()

                End With
            Catch ex As Exception
                Util.WriteLog ("InsertGoldPriceGw.Error: " & ex.ToString)
                'Console.ReadLine()
            Finally
                connG.Close()
                connG = Nothing
            End Try


        End Sub

        Public Shared Sub DeleteExRate (ByVal objConn As SqlConnection, ByVal ID As Integer)
            SqlHelper.ExecuteNonQuery (objConn, "DeleteExRate", ID)
        End Sub

        Public Shared Sub DeleteExRate (ByVal objConn As SqlConnection, ByVal ExRateDate As Date)
            SqlHelper.ExecuteNonQuery (objConn, "DeleteExRateByDate", ExRateDate)
        End Sub

        Public Shared Sub DeleteExRate (ByVal objConn As SqlConnection, ByVal strHref As String)
            SqlHelper.ExecuteNonQuery (objConn, CommandType.Text, _
                                       "DELETE FROM dbo.ExchangeRate WHERE Href='" & strHref & "'")
        End Sub
    End Class
End Namespace