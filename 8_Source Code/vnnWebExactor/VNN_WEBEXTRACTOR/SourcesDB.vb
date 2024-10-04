Imports Microsoft.ApplicationBlocks.Data
Imports System.Data.SqlClient

Namespace Data
    Public Class SourceInfor
        Public _ID As Integer
        Public _Href As String
        Public _StartTags As String
        Public _EndTags As String
        Public _TitleStartTags As String
        Public _TitleEndTags As String
        Public _DescStartTags As String
        Public _DescEndTags As String
        Public _ContentStartTags As String
        Public _ContentEndTags As String
        Public _Description As String
        Public _CategoryID As Integer
        Public _Source As String
        Public _NewsFlag As Boolean
        Public _WholeImagePath As String
        Public _ImageDirectory As String
        Public _StartNewsHref As String
        Public _ServiceName As String
    End Class

    Public Class SourceController
        Public Shared Sub InsertSource(ByVal objConn As SqlConnection, ByVal objSource As SourceInfor)
            SqlHelper.ExecuteNonQuery(objConn, "InsertSource", objSource._Href, _
                                       objSource._StartTags, objSource._EndTags, objSource._TitleStartTags, _
                                       objSource._TitleEndTags, _
                                       objSource._DescStartTags, objSource._DescEndTags, objSource._ContentStartTags, _
                                       objSource._ContentEndTags, _
                                       objSource._Description, objSource._CategoryID, objSource._Source, _
                                       objSource._NewsFlag, objSource._WholeImagePath, objSource._ImageDirectory, _
                                       objSource._StartNewsHref)
        End Sub

        Public Shared Sub UpdateSource(ByVal objConn As SqlConnection, ByVal objSource As SourceInfor)
            SqlHelper.ExecuteNonQuery(objConn, "UpdateSource", objSource._ID, objSource._Href, _
                                       objSource._StartTags, objSource._EndTags, objSource._TitleStartTags, _
                                       objSource._TitleEndTags, _
                                       objSource._DescStartTags, objSource._DescEndTags, objSource._ContentStartTags, _
                                       objSource._ContentEndTags, _
                                       objSource._Description, objSource._CategoryID, objSource._Source, _
                                       objSource._NewsFlag, objSource._WholeImagePath, objSource._ImageDirectory, _
                                       objSource._StartNewsHref)
        End Sub

        Public Shared Sub DeleteSource(ByVal objConn As SqlConnection, ByVal ID As Integer)
            SqlHelper.ExecuteNonQuery(objConn, "DeleteSource", ID)
        End Sub

        Public Shared Function selectSource(ByVal objConn As SqlConnection, ByVal ID As Integer) As SourceInfor
            Dim objSource As New SourceInfor
            Dim objDr As SqlDataReader = SqlHelper.ExecuteReader(objConn, "SelectSource", ID)
            While objDr.Read
                With objSource
                    ._ID = ID
                    ._Href = objDr.Item("Href")
                    ._StartTags = objDr.Item("StartTags")
                    ._EndTags = objDr.Item("EndTags")
                    ._TitleStartTags = objDr.Item("TitleStartTags")
                    ._TitleEndTags = objDr.Item("TitleEndTags")
                    ._DescStartTags = objDr.Item("DescStartTags")
                    ._DescEndTags = objDr.Item("DescEndTags")
                    ._ContentStartTags = objDr.Item("ContentStartTags")
                    ._ContentEndTags = objDr.Item("ContentEndTags")
                    ._Description = objDr.Item("Description")
                    ._CategoryID = objDr.Item("CategoryID")
                    ._Source = objDr.Item("Source")
                    ._NewsFlag = objDr.Item("NewsFlag")
                    ._WholeImagePath = objDr.Item("WholeImagePath")
                    ._ImageDirectory = objDr.Item("ImageDirectory")
                    ._StartNewsHref = objDr.Item("StartNewsHref")
                End With
            End While
            objDr.Close()
            Return objSource
        End Function

        Public Shared Function selectSource(ByVal objConn As SqlConnection, ByVal strHref As String) As SourceInfor
            Dim objSource As New SourceInfor
            Dim _
                objDr As SqlDataReader = _
                    SqlHelper.ExecuteReader(objConn, CommandType.Text, _
                                             "SELECT TOP 1 * FROM Sources WHERE Href=N'" & strHref & "'")
            While objDr.Read
                With objSource
                    ._ID = objDr.Item("ID")
                    ._Href = objDr.Item("Href")
                    ._StartTags = objDr.Item("StartTags")
                    ._EndTags = objDr.Item("EndTags")
                    ._TitleStartTags = objDr.Item("TitleStartTags")
                    ._TitleEndTags = objDr.Item("TitleEndTags")
                    ._DescStartTags = objDr.Item("DescStartTags")
                    ._DescEndTags = objDr.Item("DescEndTags")
                    ._ContentStartTags = objDr.Item("ContentStartTags")
                    ._ContentEndTags = objDr.Item("ContentEndTags")
                    ._Description = objDr.Item("Description")
                    ._CategoryID = objDr.Item("CategoryID")
                    ._Source = objDr.Item("Source")
                    ._NewsFlag = objDr.Item("NewsFlag")
                    ._WholeImagePath = objDr.Item("WholeImagePath")
                    ._ImageDirectory = objDr.Item("ImageDirectory")
                    ._StartNewsHref = ""
                    'objDr.Item("StartNewsHref")
                    ._ServiceName = objDr.Item("ServiceName")
                End With
            End While
            objDr.Close()
            Return objSource
        End Function

        Public Shared Function selectSources(ByVal objConn As SqlConnection, ByVal CategoryID As Integer) As DataSet
            Return SqlHelper.ExecuteDataset(objConn, "SelectSources", CategoryID)
        End Function

        Public Shared Function selectSourcesByNewsFlag(ByVal objConn As SqlConnection, ByVal intNewsFlag As Byte, _
                                                        ByVal stLogPath As String) As DataSet
            Dim ds As DataSet = New DataSet
            Try
                ds = _
                    SqlHelper.ExecuteDataset(objConn, CommandType.Text, _
                                              "SELECT * FROM Sources WHERE NewsFlag=" & intNewsFlag)
                WriteLog(stLogPath, "selectSourcesByNewsFlag is sucessfull", "INFO", _
                          DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"))
            Catch ex As Exception
                ds = Nothing
                WriteLog(stLogPath, "selectSourcesByNewsFlag::Error-->" + ex.ToString, "ERROR", _
                          DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"))
            Finally

            End Try
            Return ds
        End Function

        Public Shared Function selectSourcesByNewsFlag(ByVal intNewsFlag As Byte, _
                                                       ByVal stLogPath As String) As DataSet
            Dim ds As DataSet = New DataSet
            Try
                Dim qry As SubSonic.SqlQuery = New SubSonic.Select().From(DAL.Source.Schema).Where(DAL.Source.Columns.NewsFlag).IsEqualTo(intNewsFlag).OrderAsc(DAL.Source.Columns.Id)
                ds = qry.ExecuteDataSet()

                WriteLog(stLogPath, "selectSourcesByNewsFlag is sucessfull", "INFO", _
                          DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"))
            Catch ex As Exception
                ds = Nothing
                WriteLog(stLogPath, "selectSourcesByNewsFlag::Error-->" + ex.ToString, "ERROR", _
                          DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"))
            Finally

            End Try
            Return ds
        End Function

        Public Shared Function isSourceHrefExisted(ByVal objConn As SqlConnection, ByVal strHref As String, _
                                                    Optional ByVal ID As Integer = 0) As Boolean

            Dim objFlag As Boolean = False
            Dim objDr As SqlDataReader
            If ID = 0 Then
                'Check for Insert
                objDr = _
                    SqlHelper.ExecuteReader(objConn, CommandType.Text, _
                                             "SELECT TOP 1 * FROM Sources WHERE Href=N'" & strHref & "'")
            Else
                'Check for update
                objDr = _
                    SqlHelper.ExecuteReader(objConn, CommandType.Text, _
                                             "SELECT TOP 1 * FROM Sources WHERE Href=N'" & strHref & "' AND [ID]<>" & ID)
            End If
            objFlag = objDr.HasRows
            objDr.Close()
            Return objFlag

        End Function

        Public Shared Function HasSource(ByVal objConn As SqlConnection, ByVal CategoryID As Integer) As Boolean
            Dim objDr As SqlDataReader
            Dim boolFlag As Boolean = False
            objDr = _
                SqlHelper.ExecuteReader(objConn, CommandType.Text, _
                                         "SELECT TOP 1 * FROM Sources WHERE CategoryID=" & CategoryID)
            boolFlag = objDr.HasRows
            objDr.Close()
            Return boolFlag
        End Function

        Public Shared Function belongToCategory(ByVal objConn As SqlConnection, ByVal SourceID As Integer, _
                                                 ByVal CategoryID As Integer) As Boolean
            Dim objDr As SqlDataReader
            Dim boolFlag As Boolean = False
            objDr = _
                SqlHelper.ExecuteReader(objConn, CommandType.Text, _
                                         "SELECT TOP 1 * FROM Sources WHERE CategoryID=" & CategoryID & " AND ID=" & _
                                         SourceID)
            boolFlag = objDr.HasRows
            objDr.Close()
            Return boolFlag
        End Function

        Public Shared Function getSourceTitle(ByVal objConn As SqlConnection, ByVal CategoryID As Integer) As String
            Dim objSource As New SourceInfor
            Dim strTmp, strTmp1 As String
            objSource = Data.SourceController.selectSource(objConn, CategoryID)
            strTmp = _
                SqlHelper.ExecuteScalar(objConn, CommandType.Text, _
                                         "SELECT Name FROM Categories WHERE [ID]=" & objSource._CategoryID)
            strTmp1 = objSource._Source
            objSource = Nothing
            Return strTmp & " >> " & strTmp1
        End Function

        Public Shared Function isNewsSource(ByVal objConn As SqlConnection, ByVal strHref As String) As Boolean
            Dim objDr As SqlDataReader = Nothing
            Dim boolFlag As Boolean = False
            Try
                objDr = _
                    SqlHelper.ExecuteReader(objConn, CommandType.Text, _
                                             "SELECT TOP 1 * FROM Sources WHERE Href='" & strHref & "' AND NewsFlag=1")
                boolFlag = objDr.HasRows
            Catch ex As Exception
                boolFlag = False
            Finally
                objDr.Close()
                objDr = Nothing
            End Try

            Return boolFlag
        End Function

        Public Shared Function getImagePath(ByVal objConn As SqlConnection, ByVal strHref As String) As String

            Return _
                SqlHelper.ExecuteScalar(objConn, CommandType.Text, _
                                         "SELECT TOP 1 WholeImagePath FROM Sources WHERE Href='" & strHref & "'")

        End Function

        Public Shared Function isNewsSourceByCatID(ByVal objConn As SqlConnection, ByVal CategoryID As Integer) _
            As Boolean
            Dim objDr As SqlDataReader
            Dim boolFlag As Boolean = False
            objDr = _
                SqlHelper.ExecuteReader(objConn, CommandType.Text, _
                                         "SELECT TOP 1 * FROM Sources WHERE ID=" & CategoryID & " AND NewsFlag=1")
            boolFlag = objDr.HasRows
            objDr.Close()
            Return boolFlag
        End Function

        Public Shared Function getNotNewsCollection(ByVal objConn As SqlConnection) As Collection
            Dim objCols As New Collection
            Dim objDr As SqlDataReader
            objDr = SqlHelper.ExecuteReader(objConn, CommandType.Text, "SELECT [ID] FROM Sources WHERE NewsFlag=0")
            While objDr.Read
                objCols.Add(objDr.Item("ID"))
            End While
            objDr.Close()
            Return objCols
        End Function
    End Class
End Namespace