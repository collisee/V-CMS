Imports Microsoft.ApplicationBlocks.Data
Imports System.Data.SqlClient
Imports System.Web.UI.WebControls

Namespace Data
    Public Class StockInfor
        Public _StockDate As Date
        Public _VnIndexChartImg As String
        Public _VnIndex As String
        Public _VnIndexImg As String
        Public _VnIndexChangeValue As String
        Public _VnIndexPercentChangeValue As String
        Public _HaIndexChartImg As String
        Public _HaIndex As String
        Public _HaIndexImg As String
        Public _HaIndexChangeValue As String
        Public _HaIndexPercentChangeValue As String

        Public _tblStockService As String = "vnn_infoservice"
        Public _inforType As String = "ST"
    End Class

    Public Class StockController
        Public Shared Sub InsertStock (ByVal objConn As SqlConnection, ByVal objStock As StockInfor)
            SqlHelper.ExecuteNonQuery (objConn, "InsertStock", objStock._StockDate, objStock._VnIndexChartImg, _
                                       objStock._VnIndex, _
                                       objStock._VnIndexImg, objStock._VnIndexChangeValue, _
                                       objStock._VnIndexPercentChangeValue _
                                       , objStock._HaIndexChartImg, objStock._HaIndex, objStock._HaIndexChangeValue, _
                                       objStock._HaIndexPercentChangeValue)
        End Sub

        Public Shared Sub DeleteStockGw()
            Dim _
                connG As _
                    New MySql.Data.MySqlClient.MySqlConnection ( _
                                                                System.Configuration.ConfigurationManager.AppSettings ( _
                                                                                                                       "ConnectionStringGW"))
            Dim cmd As New MySql.Data.MySqlClient.MySqlCommand
            Dim objStock As New StockInfor
            Try
                If connG.State = ConnectionState.Closed Then
                    connG.Open()
                End If
                With cmd
                    .CommandType = CommandType.Text
                    .CommandText = "DELETE FROM " & objStock._tblStockService & _
                                   " Where date_format(info_date,'%Y-%m-%d') = '" & _
                                   String.Format ("{0:yyyy-MM-dd}", DateTime.Now) + "'" & _
                                   " AND info_type = '" & objStock._inforType & "'"
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

        Public Shared Sub InsertStockGw (ByVal strStockContent As String)
            Dim _
                connG As _
                    New MySql.Data.MySqlClient.MySqlConnection ( _
                                                                System.Configuration.ConfigurationManager.AppSettings ( _
                                                                                                                       "ConnectionStringGW"))
            Dim cmd As New MySql.Data.MySqlClient.MySqlCommand
            Dim objStock As New StockInfor
            Try
                If connG.State = ConnectionState.Closed Then
                    connG.Open()
                End If
                With cmd
                    .CommandType = CommandType.Text
                    .CommandText = "insert into " & objStock._tblStockService & _
                                   "(info_type,info_date,content,last_update,last_user)" & _
                                   " VALUES " & _
                                   "('" + objStock._inforType + "','" + String.Format ("{0:s}", DateTime.Now) + "','" + _
                                   strStockContent + "','" + _
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

        Public Shared Sub DeleteStock (ByVal objConn As SqlConnection, ByVal ID As Integer)
            SqlHelper.ExecuteNonQuery (objConn, "DeleteStock", ID)
        End Sub

        Public Shared Sub DeleteStock (ByVal objConn As SqlConnection, ByVal StockDate As Date)
            SqlHelper.ExecuteNonQuery (objConn, "DeleteStockByDate", StockDate)
        End Sub

        Public Shared Sub DeleteStock (ByVal objConn As SqlConnection, ByVal strHref As String)
            SqlHelper.ExecuteNonQuery (objConn, CommandType.Text, _
                                       "DELETE FROM dbo.ExchangeRate WHERE Href='" & strHref & "'")
        End Sub
    End Class
End Namespace