Imports System.Globalization
'Imports System.Data.SqlClient
'Imports System.Windows.Forms
Imports System.Web.UI.WebControls
Imports System.Web

Public Class WebContentInfor
    Public Title As String
    Public Description As String
    Public Content As String
    Public Source As String
    Public Image As String
    Public CategoryID As Integer
    Public Href As String
    Public ImgDownloadFlag As Boolean = True
End Class

Public Class WebImage
    Public OriginalPath As String
    Public imgNewFileName As String
    Public imgLink As String
End Class

Public Class Web
    Public Shared Function outDate(ByVal strDate As DateTime) As String
        If strDate.ToShortDateString.Trim = "01/01/1900" Then
            Return ""
        Else
            Return strDate.ToShortDateString
        End If
    End Function

    Public Shared Function inDate(ByVal strDate As String) As DateTime
        If strDate.Trim = "" Then
            Return Convert.ToDateTime("01/01/1900")
        Else
            Return Convert.ToDateTime(strDate)
        End If
    End Function

    Public Shared Function Navigate(Optional ByVal strURI As String = "") As String
        If strURI <> "" Then
            HttpContext.Current.Session("EPHNavigate") = strURI
        End If
        Return HttpContext.Current.Session("EPHNavigate")
    End Function

    Public Shared Function InvokePopupCal(ByVal Field As System.Web.UI.WebControls.TextBox) As String

        ' Define character array to trim from language strings
        Dim TrimChars As Char() = {","c, " "c}

        ' Get culture array of month names and convert to string for
        ' passing to the popup calendar
        Dim MonthNameString As String = ""
        Dim Month As String
        For Each Month In DateTimeFormatInfo.CurrentInfo.MonthNames
            MonthNameString += Month & ","
        Next
        MonthNameString = MonthNameString.TrimEnd(TrimChars)

        ' Get culture array of day names and convert to string for
        ' passing to the popup calendar
        Dim DayNameString As String = ""
        Dim Day As String
        For Each Day In DateTimeFormatInfo.CurrentInfo.DayNames
            DayNameString += Day.Substring(0, 3) & ","
        Next
        DayNameString = DayNameString.TrimEnd(TrimChars)

        ' Get the short date pattern for the culture
        Dim FormatString As String = DateTimeFormatInfo.CurrentInfo.ShortDatePattern.ToString

        Return _
            "javascript:popupCal('Cal','" & Field.ClientID & "','" & FormatString & "','" & MonthNameString & "','" & _
            DayNameString & "');"

    End Function

    'Customize the grid's pager bar
    Public Shared Sub setDataGridPagerBar(ByVal sender As Object, _
                                           ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs)
        Dim elemType As ListItemType = e.Item.ItemType
        If elemType = ListItemType.Pager Then
            Dim pager As TableCell = CType(e.Item.Controls(0), TableCell)

            Dim i As Byte
            For i = 0 To pager.Controls.Count - 1 Step 2
                Dim o As Object = pager.Controls(i)

                If TypeOf o Is LinkButton Then
                    Dim h As LinkButton = CType(o, LinkButton)
                    h.Text = "<font color='#0000FF' face='Arial' size=2> " + h.Text + "</font>"

                Else
                    Dim l As Label = CType(o, Label)
                    l.Text = "<font color='#FF0000' face='Arial' size=2>[" + l.Text + "]</font>"

                End If
            Next
            'Add title Trang here
            Dim pl As New Label
            pl.Text = "<b><font face='Tahoma' size='1'>Xem tin trang </font></b>"
            pager.Controls.AddAt(0, pl)
        End If
    End Sub

    Public Shared Function translateVnEn(ByVal strVn As String, ByVal strEn As String) As String
        If HttpContext.Current.Session("Language") Then
            Return strVn
        Else
            Return strEn
        End If
    End Function

    Public Shared Function displayVN() As Boolean
        If HttpContext.Current.Session("Language") Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
