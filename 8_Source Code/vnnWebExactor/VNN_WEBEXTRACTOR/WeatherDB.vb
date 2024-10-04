Imports Microsoft.ApplicationBlocks.Data
Imports System.Data.SqlClient
Imports System.Web.UI.WebControls

Namespace Data
    Public Class WeatherInfor
        Public _City As String
        Public _Temperature As String
        Public _WeatherDate As Date
        Public _ImageSrc As String
    End Class

    Public Class WeatherController
        Public Shared Sub InsertWeather (ByVal objConn As SqlConnection, ByVal objWeather As WeatherInfor)
            SqlHelper.ExecuteNonQuery (objConn, "InsertWeather", objWeather._City, objWeather._Temperature, _
                                       objWeather._WeatherDate, objWeather._ImageSrc)
        End Sub

        Public Shared Sub UpdateWeather (ByVal objConn As SqlConnection, ByVal objWeather As WeatherInfor)
            SqlHelper.ExecuteNonQuery (objConn, "UpdaeWeather", objWeather._City, objWeather._Temperature, _
                                       objWeather._WeatherDate, objWeather._ImageSrc)
        End Sub

        Public Shared Sub DeleteWeather (ByVal objConn As SqlConnection, ByVal ID As Integer)
            SqlHelper.ExecuteNonQuery (objConn, "DeleteWeather", ID)
        End Sub

        Public Shared Sub DeleteWeather (ByVal objConn As SqlConnection, ByVal WeatherDate As Date)
            SqlHelper.ExecuteNonQuery (objConn, "DeleteWeatherByDate", WeatherDate)
        End Sub

        Public Shared Sub DeleteWeather (ByVal objConn As SqlConnection, ByVal strHref As String)
            SqlHelper.ExecuteNonQuery (objConn, CommandType.Text, "DELETE FROM News WHERE Href='" & strHref & "'")
        End Sub

        Public Shared Function selectNew (ByVal objConn As SqlConnection, ByVal ID As Integer) As WeatherInfor
            Dim objWeather As New WeatherInfor
            Dim objDr As SqlDataReader = SqlHelper.ExecuteReader (objConn, "SelectWeather", ID)
            While objDr.Read
                With objWeather
                    '._ID = ID
                    '._CreatedDate = objDr.Item("CreatedDate")
                    '._Title = objDr.Item("Title")
                    '._Description = objDr.Item("Description")
                    '._Content = objDr.Item("Content")
                    '._Source = objDr.Item("Source")
                    '._CategoryID = objDr.Item("CategoryID")
                    '._Href = objDr.Item("Href")
                    '._Image = objDr.Item("Image")
                End With
            End While
            objDr.Close()
            Return objWeather
        End Function

        Public Shared Function isExisted (ByVal objConn As SqlConnection, ByVal strHref As String) As Boolean
            Dim objDr As SqlDataReader
            Dim boolFlag As Boolean = False
            objDr = _
                SqlHelper.ExecuteReader (objConn, CommandType.Text, _
                                         "SELECT TOP 1 * FROM News WHERE Href=N'" & strHref & "'")
            boolFlag = objDr.HasRows
            objDr.Close()
            Return boolFlag
        End Function

        Public Shared Function SelectNews (ByVal objConn As SqlConnection) As DataSet
            Return SqlHelper.ExecuteDataset (objConn, "SelectNews")
        End Function

        'Public Shared Function SelectNews (ByVal objConn As SqlConnection, ByVal objDG As DataGrid, _
        '                                   Optional ByVal strCondition As String = "", _
        '                                   Optional ByVal strFieldName As String = "ID", _
        '                                   Optional ByVal Order As Boolean = False) As DataSet
        '    Dim strSQL As String

        '    strSQL = WEBHelper.BuildCustomSQLString (objDG.PageSize, objDG.CurrentPageIndex, _
        '                                             objDG.VirtualItemCount, "News", strFieldName, Order, strCondition)

        '    Return SqlHelper.ExecuteDataset (objConn, CommandType.Text, strSQL)

        'End Function

        Public Shared Function SelectNewsNo (ByVal objConn As SqlConnection, Optional ByVal strCondition As String = "") _
            As Integer
            Dim strConditionTemp As String
            If strCondition <> "" Then
                strConditionTemp = " WHERE " & strCondition
            Else
                strConditionTemp = ""
            End If
            Return _
                CType ( _
                    SqlHelper.ExecuteScalar (objConn, CommandType.Text, "SELECT COUNT(*) FROM News " & strConditionTemp), _
                    Integer)
        End Function
    End Class
End Namespace