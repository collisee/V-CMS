Imports Microsoft.ApplicationBlocks.Data
Imports System.Data.SqlClient
Imports SubSonic
Imports SubSonic.Utilities
Imports DAL

Public Class NewsInfor
    Public _ID As Integer
    Public _CreatedDate As Date
    Public _Title As String
    Public _Description As String
    Public _Content As String
    Public _Source As String
    Public _CategoryID As Integer
    Public _Href As String
    Public _Image As String
    Public _ImageLink As String 'Anh dai dien
End Class

Public Class NewsController
    Public Shared Function InsertNew(ByVal objConn As SqlConnection, ByVal objNew As NewsInfor, _
                                     ByVal stLogPath As String) As Integer
        Dim _Id As Integer

        Try
            If (objConn.State = ConnectionState.Open) Then
                objConn.Close()
            End If
            _Id = SqlHelper.ExecuteScalar(objConn, "InsertNew", objNew._Title, objNew._Title, objNew._Image, _
                                          objNew._Description, objNew._Content, objNew._Source, objNew._Href, _
                                          "Đã xuất bản", 4)
            'SqlHelper.ExecuteNonQuery(objConn, "InsertNew", "News is crawled from " + objNew._Source, objNew._Title, objNew._Image, _
            '            objNew._Description, objNew._Content, objNew._Source, objNew._Href)
            Return _Id
            WriteLog(stLogPath, "InsertNew the Article With ID = " + _Id + " was successful", "INFOR", _
                     DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"))
        Catch ex As Exception
            WriteLog(stLogPath, ex.ToString, "InsertNew::ERROR", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"))
            Return -1
        End Try

    End Function
    Public Shared Function InsertNew(ByVal objNew As NewsInfor, ByVal stLogPath As String) As Integer
        Dim _Id As Double
        Dim sp As StoredProcedure = Nothing
        Try
            sp = SPs.InsertNew(objNew._Title, objNew._Title, objNew._Image, _
                                          objNew._Description, objNew._Content, objNew._Source, objNew._Href, "Đã xuất bản", 4)

            _Id = sp.ExecuteScalar()
            WriteLog(stLogPath, "InsertNew the Article With ID = " + _Id + " was successful", "INFOR", _
                     DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"))
        Catch ex As Exception
            WriteLog(stLogPath, ex.ToString, "InsertNew::ERROR", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"))
            'Return -1
        End Try
        Return Integer.Parse(_Id.ToString)
    End Function
    Public Shared Sub InsertArticleCate(ByVal objConn As SqlConnection, ByVal objNew As NewsInfor, _
                                        ByVal objCate As Data.CategoryInfor, ByVal stLogPath As String)
        Try
            Dim sp As StoredProcedure = SPs.InsertArticleCate(objCate._ID, objCate._PartitionId, objNew._ID, _
                                      objCate._DisplayOrder)
            sp.Execute()
        Catch ex As Exception
            WriteLog(stLogPath, ex.ToString, "InsertArticleCate:ERROR", _
                     DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"))
        End Try
    End Sub
    Public Shared Sub InsertArticleCate(ByVal objNew As NewsInfor, _
                                            ByVal objCate As Data.CategoryInfor, ByVal stLogPath As String)
        Try
            Dim sp As StoredProcedure = SPs.InsertArticleCate(objCate._ID, objCate._PartitionId, objNew._ID, _
                                      objCate._DisplayOrder)
            sp.Execute()
        Catch ex As Exception
            WriteLog(stLogPath, ex.ToString, "InsertArticleCate:ERROR", _
                     DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"))
        End Try

    End Sub

    Public Shared Sub UpdateNew(ByVal objConn As SqlConnection, ByVal objNew As NewsInfor)
        SqlHelper.ExecuteNonQuery(objConn, "InsertNew", objNew._ID, objNew._Title, objNew._Description, _
                                  objNew._Content, objNew._Source, objNew._CategoryID, objNew._Href, objNew._Image)
    End Sub

    Public Shared Sub DeleteNew(ByVal objConn As SqlConnection, ByVal ID As Integer)
        SqlHelper.ExecuteNonQuery(objConn, "DeleteNew", ID)
    End Sub

    Public Shared Sub DeleteNew(ByVal objConn As SqlConnection, ByVal strHref As String)
        SqlHelper.ExecuteNonQuery(objConn, CommandType.Text, "DELETE FROM News WHERE Href='" & strHref & "'")
    End Sub

    Public Shared Function selectNew(ByVal objConn As SqlConnection, ByVal ID As Integer) As NewsInfor
        Dim objNew As New NewsInfor
        Dim objDr As SqlDataReader = SqlHelper.ExecuteReader(objConn, "SelectNew", ID)
        While objDr.Read
            With objNew
                ._ID = ID
                ._CreatedDate = objDr.Item("CreatedDate")
                ._Title = objDr.Item("Title")
                ._Description = objDr.Item("Description")
                ._Content = objDr.Item("Content")
                ._Source = objDr.Item("Source")
                ._CategoryID = objDr.Item("CategoryID")
                ._Href = objDr.Item("Href")
                ._Image = objDr.Item("Image")
            End With
        End While
        objDr.Close()
        Return objNew
    End Function

    Public Shared Function isExisted(ByVal objConn As SqlConnection, ByVal strHref As String) As Boolean
        Dim objDr As SqlDataReader
        Dim boolFlag As Boolean = False
        objDr = _
            SqlHelper.ExecuteReader(objConn, CommandType.Text, _
                                    "SELECT TOP 1 Id FROM dbo.Article WHERE Href=N'" & strHref & "'")
        boolFlag = objDr.HasRows
        objDr.Close()
        Return boolFlag
    End Function
    Public Shared Function isExisted(ByVal strHref As String, ByVal CateId As Integer) As Boolean
        Dim objDr As SqlDataReader = Nothing
        Dim boolFlag As Boolean = False

        Try
            Dim qry As SubSonic.SqlQuery = New SubSonic.Select().From(DAL.Article.Schema). _
                    InnerJoin(DAL.ArticleCategory.Schema). _
                    Where(DAL.Article.Columns.Href).IsEqualTo(strHref). _
                    AndExpression(DAL.ArticleCategory.Columns.CategoryId).IsEqualTo(CateId)
            objDr = qry.ExecuteReader()
            boolFlag = objDr.HasRows
            objDr.Close()
            Return boolFlag
        Catch ex As Exception

        Finally
            If Not IsNothing(objDr) Then
                objDr.Close()
                objDr = Nothing
            End If
        End Try

    End Function
    Public Shared Function SelectNews(ByVal objConn As SqlConnection) As DataSet
        Return SqlHelper.ExecuteDataset(objConn, "SelectNews")
    End Function

    'Public Shared Function SelectNews(ByVal objConn As SqlConnection, ByVal objDG As DataGrid, _
    '                                   Optional ByVal strCondition As String = "", _
    '                                   Optional ByVal strFieldName As String = "ID", _
    '                                   Optional ByVal Order As Boolean = False) As DataSet
    '    Dim strSQL As String

    '    strSQL = WEBHelper.BuildCustomSQLString(objDG.PageSize, objDG.CurrentPageIndex, _
    '                                             objDG.VirtualItemCount, "News", strFieldName, Order, strCondition)

    '    Return SqlHelper.ExecuteDataset(objConn, CommandType.Text, strSQL)

    'End Function

    Public Shared Function SelectNewsNo(ByVal objConn As SqlConnection, Optional ByVal strCondition As String = "") _
        As Integer
        Dim strConditionTemp As String
        If strCondition <> "" Then
            strConditionTemp = " WHERE " & strCondition
        Else
            strConditionTemp = ""
        End If
        Return _
            CType( _
                SqlHelper.ExecuteScalar(objConn, CommandType.Text, "SELECT COUNT(*) FROM News " & strConditionTemp), _
                Integer)
    End Function
End Class