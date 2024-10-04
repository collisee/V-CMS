Imports Microsoft.ApplicationBlocks.Data
Imports System.Data.SqlClient
Imports System.Web.UI.WebControls

Namespace Data
    Public Class GoldInfor
        Public _GoldCode As String
        Public _Buy As String
        Public _Sell As String
        Public _GoldPriceDate As Date
        Public _tblGoldService As String = "vnn_infoservice"
        Public _inforType As String = "GV"
        Public _GoldContent As String = ""
        Public _GoldSource As String = ""
    End Class

    Public Class GoldController
        Public Shared Sub InsertGoldPrice (ByVal objConn As SqlConnection, ByVal objGoldPrice As GoldInfor)
            SqlHelper.ExecuteNonQuery (objConn, "InsertGoldPrice", objGoldPrice._GoldCode, _
                                       objGoldPrice._Buy, objGoldPrice._Sell, objGoldPrice._GoldPriceDate, _
                                       objGoldPrice._GoldSource)
        End Sub

        Public Shared Sub InsertGoldPriceGw (ByVal strGoldContent As String)
            Dim _
                connG As _
                    New MySql.Data.MySqlClient.MySqlConnection ( _
                                                                System.Configuration.ConfigurationManager.AppSettings ( _
                                                                                                                       "ConnectionStringGW"))
            Dim cmd As New MySql.Data.MySqlClient.MySqlCommand
            Dim objGoldPrice As New GoldInfor
            Try
                If connG.State = ConnectionState.Closed Then
                    connG.Open()
                End If
                With cmd
                    .CommandType = CommandType.Text
                    .CommandText = "insert into " & objGoldPrice._tblGoldService & _
                                   "(info_type,info_date,content,last_update,last_user)" & _
                                   " VALUES " & _
                                   "('" + objGoldPrice._inforType + "','" + String.Format ("{0:s}", DateTime.Now) + _
                                   "','" + strGoldContent + "','" + _
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

        Public Shared Sub DeleteGoldPriceGw()
            Dim _
                connG As _
                    New MySql.Data.MySqlClient.MySqlConnection ( _
                                                                System.Configuration.ConfigurationManager.AppSettings ( _
                                                                                                                       "ConnectionStringGW"))
            Dim cmd As New MySql.Data.MySqlClient.MySqlCommand
            Dim objGoldPrice As New GoldInfor
            Try
                If connG.State = ConnectionState.Closed Then
                    connG.Open()
                End If
                With cmd
                    .CommandType = CommandType.Text
                    .CommandText = "DELETE FROM " & objGoldPrice._tblGoldService & _
                                   " Where date_format(info_date,'%Y-%m-%d') = '" & _
                                   String.Format ("{0:yyyy-MM-dd}", DateTime.Now) + "'" & _
                                   " AND info_type = '" & objGoldPrice._inforType & "'"
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

        Public Shared Sub InsertGoldAndExPriceGw (ByVal objConn As SqlConnection, ByVal objGoldPrice As GoldInfor, _
                                                  ByVal objExPrice As ExRateInfor)
            Dim connG As New MySql.Data.MySqlClient.MySqlConnection ("")
            Dim cmd As New MySql.Data.MySqlClient.MySqlCommand

            Try
                If connG.State = ConnectionState.Closed Then
                    connG.Open()
                End If
                With cmd
                    .CommandType = CommandType.Text
                    .CommandText = "insert into " & objGoldPrice._tblGoldService & _
                                   "(info_type,info_date,content,last_update,last_user)" & _
                                   " VALUES " & _
                                   "('"
                    .Connection = connG
                    Try
                        .ExecuteNonQuery()
                    Catch ex As Exception
                        'Console.WriteLine(ex.Message)
                        'Console.ReadLine()
                    End Try
                End With
            Catch ex As Exception
                'Util.WriteLog("Error connect to databse Gateway. Code: " & ex.Message)
                'Console.ReadLine()
            Finally

            End Try


        End Sub

        Public Shared Sub DeleteGoldPrice (ByVal objConn As SqlConnection, ByVal ID As Integer)
            SqlHelper.ExecuteNonQuery (objConn, "DeleteGoldPrice", ID)
        End Sub

        Public Shared Sub DeleteGoldPrice (ByVal objConn As SqlConnection, ByVal GoldPriceDate As Date, _
                                           ByVal GoldSource As String)
            SqlHelper.ExecuteNonQuery (objConn, "DeleteGoldPriceByDate", GoldPriceDate, GoldSource.ToUpper.Trim)
        End Sub

        Public Shared Sub DeleteGoldPrice (ByVal objConn As SqlConnection, ByVal strHref As String)
            SqlHelper.ExecuteNonQuery (objConn, CommandType.Text, _
                                       "DELETE FROM dbo.ExchangeRate WHERE Href='" & strHref & "'")
        End Sub
    End Class
End Namespace