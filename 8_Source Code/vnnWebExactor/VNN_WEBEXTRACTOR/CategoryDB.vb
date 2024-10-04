Imports Microsoft.ApplicationBlocks.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports DAL
Namespace Data
    Public Class CategoryInfor
        Inherits ListViewItem
        Public _ID As Integer
        Public _PartitionId As Integer
        Public _PID As Integer
        Public _Name As String
        Public _Alias As String
        Public _DisplayName As String
        Public _DisplayOrder As Integer


        Public Overrides Function ToString() As String
            Return _Name
        End Function
    End Class

    Public Class CategoryController
        'Public Shared Sub InsertCategory(ByVal objConn As SqlConnection, ByVal objCategory As CategoryInfor)
        '    SqlHelper.ExecuteNonQuery(objConn, "InsertCategory", objCategory._Name, objCategory._Description, _
        '    objCategory._DisplayPosition, objCategory._DisplayOrder)
        'End Sub
        'Public Shared Sub UpdateCategory(ByVal objConn As SqlConnection, ByVal objCategory As CategoryInfor)
        '    SqlHelper.ExecuteNonQuery(objConn, "UpdateCategory", objCategory._ID, objCategory._Name, objCategory._Description, _
        '    objCategory._DisplayPosition, objCategory._DisplayOrder)
        'End Sub
        Public Shared Sub DeleteCategory(ByVal objConn As SqlConnection, ByVal ID As Integer)
            SqlHelper.ExecuteNonQuery(objConn, "DeleteCategory", ID)
        End Sub

        Public Shared Function selectCategory(ByVal objConn As SqlConnection, ByVal ID As Integer) As CategoryInfor
            Dim objCategory As New CategoryInfor
            Dim objDr As SqlDataReader = SqlHelper.ExecuteReader(objConn, "SelectCategory", ID)
            While objDr.Read
                With objCategory
                    ._ID = ID
                    ._PartitionId = objDr.Item("PartitionId")
                    ._Name = objDr.Item("Name")
                    ._Alias = objDr.Item("Alias")
                    ._DisplayName = objDr.Item("DisplayName")
                    ._DisplayOrder = objDr.Item("Ord")
                    ._PID = objDr.Item("PId")
                End With
            End While
            objDr.Close()
            Return objCategory
        End Function

        Public Shared Function selectCategory(ByVal ID As Integer) As CategoryInfor
            Dim objDr As SqlDataReader = Nothing
            Dim objCategory As New CategoryInfor
            Try
                objDr = New SubSonic.Select().From(Category.Schema).Where(Category.Columns.Id).IsEqualTo(ID).ExecuteReader()
                While objDr.Read
                    With objCategory
                        ._ID = ID
                        ._PartitionId = objDr.Item("PartitionId")
                        ._Name = objDr.Item("Name")
                        ._Alias = objDr.Item("Alias")
                        ._DisplayName = objDr.Item("DisplayName")
                        ._DisplayOrder = objDr.Item("Ord")
                        ._PID = objDr.Item("PId")
                    End With
                End While
            Catch ex As Exception

            End Try

            objDr.Close()
            Return objCategory
        End Function

        Public Shared Function selectCategories(ByVal objConn As SqlConnection) As DataSet
            Return SqlHelper.ExecuteDataset(objConn, "SelectCategories")
        End Function

        Public Shared Function selectCategories(ByVal objConn As SqlConnection, ByVal strPos As String) As DataSet
            Return _
                SqlHelper.ExecuteDataset(objConn, CommandType.Text, _
                                          "SELECT * FROM Categories WHERE DisplayPosition='" & strPos & _
                                          "' ORDER BY DisplayOrder ASC")
        End Function

        Public Shared Function isCategoryNameExisted(ByVal objConn As SqlConnection, ByVal strName As String, _
                                                      Optional ByVal ID As Integer = 0) As Boolean

            Dim objFlag As Boolean = False
            Dim objDr As SqlDataReader
            If ID = 0 Then
                'Check for Insert
                objDr = _
                    SqlHelper.ExecuteReader(objConn, CommandType.Text, _
                                             "SELECT TOP 1 * FROM Categories WHERE Name=N'" & strName & "'")
            Else
                'Check for update
                objDr = _
                    SqlHelper.ExecuteReader(objConn, CommandType.Text, _
                                             "SELECT TOP 1 * FROM Categories WHERE Name=N'" & strName & "' AND [ID]<>" & _
                                             ID)
            End If
            objFlag = objDr.HasRows
            objDr.Close()
            Return objFlag

        End Function
    End Class
End Namespace