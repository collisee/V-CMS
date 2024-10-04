Imports System.IO
Imports System.Security.Cryptography
Imports System.Text
Imports System.Configuration

Public Class Util
    Public Shared Sub WriteLog (ByVal strlog As String)
        Dim filename As String
        filename = DateTime.Now.ToShortDateString.Replace ("/", "-") & ".txt"
        Dim w As StreamWriter = File.AppendText (filename)
        w.WriteLine (Now.ToString & ":" & strlog)
        w.Flush()
        w.Close()
    End Sub

    Public Shared Function formatdate (ByVal str As String)
        Dim vdate As String = str.Substring (6, 2) & "-" & str.Substring (4, 2) & "-" & str.Substring (0, 4)
        Return vdate
    End Function
End Class
