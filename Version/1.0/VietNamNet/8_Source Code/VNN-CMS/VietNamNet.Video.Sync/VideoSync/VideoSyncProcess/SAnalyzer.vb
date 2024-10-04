Imports System.IO

Module StringAnalyzer
    Public webCols As New Collection

    Public Function removeHTMLTags(ByVal strContent As String) As String
        Dim _
            arrHTMLTags() As String = _
                {"<B>", "<b>", "</B>", "</b>", "</TR>", "/tr", "</TD>", "</td>", "</TABLE>", "</table>", _
                 "</TBODY>", "</tbody>", "</A>", "</a>", "</FONT>", "</font>", _
                 "<TBODY>", "<tbody>", "</SPAN>", "</span>", "<BR>", "<br>", "<>"}
        Dim arrHTMLOpenTags() As String = {"<A", "<a", "<TR", "<tr", "<TD", "<td", "<TABLE", "<table", _
                                           "<FONT", "<font", "<IMG", "<img", "<TBODY", "<tbody", "<SPAN", "<span"}
        Dim strTmp As String
        strTmp = strContent
        For i As Integer = 0 To arrHTMLTags.GetUpperBound(0)
            strTmp = strTmp.Replace(arrHTMLTags(i), "")
        Next
        strTmp = strTmp.Trim

        Dim intStart, intStop As Integer
        For i As Integer = 0 To arrHTMLOpenTags.GetUpperBound(0)
            intStart = strTmp.IndexOf(arrHTMLOpenTags(i), 0)
            While intStart >= 0
                intStop = strTmp.IndexOf(">", intStart + 1)
                If intStop > 0 Then
                    strTmp = strTmp.Replace(strTmp.Substring(intStart, intStop - intStart + 1), "")
                End If
                intStart = strTmp.IndexOf(arrHTMLOpenTags(i), 0)
            End While
        Next
        Return strTmp.Trim
    End Function

    Public Function splitContent(ByVal strContent As String, ByVal strTitleEnd As String, _
                                  Optional ByVal titleFlag As Boolean = True) As String
        Dim strTmp As String
        Dim intStart, intStop As Integer
        strTmp = strContent
        intStart = 0
        intStop = strTmp.IndexOf(strTitleEnd, 0)
        Select Case titleFlag
            Case True
                strTmp = strTmp.Substring(intStart, intStop - intStart + strTitleEnd.Length)
            Case False
                strTmp = strTmp.Substring(intStop + strTitleEnd.Length, strTmp.Length - intStop - strTitleEnd.Length)
        End Select
        Return strTmp.Trim
    End Function

    Public Function splitContent(ByVal strContent As String, ByVal strStartTag As String, ByVal strStopTag As String) _
        As String
        Dim strTmp As String = ""
        Dim intStart, intStop As Integer

        intStart = strContent.IndexOf(strStartTag, 0)
        intStop = strContent.IndexOf(strStopTag, intStart + 1)
        If intStart >= 0 And intStop > intStart Then
            strTmp = strContent.Substring(intStart, intStop - intStart + strStopTag.Length)
        End If

        Return strTmp.Trim
    End Function

    Public Function getTheFirstLink(ByVal strContentIn As String) As String
        Dim intStart, intStop As Integer
        Dim strTmp As String = ""
        Dim strQuote As String
        Dim strContent As String
        strContent = strContentIn.ToLower

        intStart = strContent.IndexOf("href=", 0)
        If intStart > 0 Then
            strQuote = strContent.Substring(intStart + 5, 1)
            intStop = strContent.IndexOf(strQuote, intStart + 6)
            If intStop > 0 Then
                strTmp = strContent.Substring(intStart + 6, intStop - intStart - 6)
            End If
        End If

        If strTmp.IndexOf("/", 0) = 0 Then
            strTmp = strTmp.Substring(1, strTmp.Length - 1)
        End If

        Return strTmp.Trim
    End Function

    Public Function AnalyzeHREF(ByVal strHref As String) As String
        Dim intStop As Integer
        intStop = strHref.IndexOf("/", 8)
        Return strHref.Substring(0, intStop + 1)
    End Function

    Public Function getFileName(ByVal strURL As String, ByVal strSplit As String) As String
        Dim intStop As Integer
        intStop = strURL.LastIndexOf(strSplit)
        Return strURL.Substring(intStop + 1, strURL.Length - intStop - 1)
    End Function

    Public Sub isFolderExist(ByVal strSource As String)
        If Not System.IO.Directory.Exists(strSource) Then
            System.IO.Directory.CreateDirectory(strSource)
        End If
    End Sub

    Public Function isFileExist(ByVal strPath As String) As Boolean
        Return File.Exists(strPath)
    End Function

    Public Function DeleFileExist(ByVal strPath As String) As Boolean
        Try
            File.Delete(strPath)
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function AnalyzeAndFixHTML(ByVal strContent As String) As String
        Dim strStartHTML() As String = {"<img", "<br"}
        Dim strStopHTML() As String = {"</img>", "</br>"}
        Dim strStartHTML1() As String = {"<br"}
        Dim strStopHTML1() As String = {"</br>"}

        'Dim strStartHTML() As String = {"<img", "<TR", "<tr", "<TD", "<td", "<TABLE", "<table", "<SCRIPT", "<script", "<Script"}
        'Dim strStopHTML() As String = {"</img>", "</TR>", "</tr>", "</TD>", "</td>", "</TABLE>", "</table>", "</SCRIPT>", "</script>", "</Script>"}
        'Dim strStartHTML1() As String = {"</TR>", "</tr>", "</TD>", "</td>"}
        'Dim strStopHTML1() As String = {"</TABLE>", "</table>", "</TR></TABLE>", "</tr></table>"}
        'Dim strStartHTML2() As String = {"<TR>", "<tr>", "<TD>", "<td>"}
        'Dim strStopHTML2() As String = {"<TABLE>", "<table>", "<TABLE><TR>", "<table><tr>"}
        Dim intStart, intStop, intMiddle As Integer
        Dim strTemp As String
        strTemp = strContent

        'Add the ending img tag
        For i As Byte = 0 To strStartHTML.Length - 1
            intStart = strTemp.IndexOf(strStartHTML.GetValue(i))
            If intStart >= 0 Then
                intMiddle = strTemp.IndexOf(">", intStart + 1)
                intStop = strTemp.IndexOf(strStopHTML.GetValue(i), intStart + 1)
                If intStop < 0 Then
                    If intMiddle < 0 Then
                        strTemp = strTemp & ">"
                    End If
                    strTemp = strTemp.Substring(0, intMiddle + 1) & strStopHTML.GetValue(i) & _
                              strTemp.Substring(intMiddle + 1)
                End If
            End If
        Next

        ''Add the ending <br> tag
        'For i As Byte = 0 To strStartHTML1.GetLowerBound(0)
        '    intStart = strTemp.IndexOf(strStartHTML1.GetValue(i))
        '    If intStart >= 0 Then
        '        intMiddle = strTemp.IndexOf(">", intStart + 1)
        '        intStop = strTemp.IndexOf(strStopHTML1.GetValue(i), intStart + 1)
        '        If intStop < 0 Then
        '            If intMiddle < 0 Then
        '                strTemp = strTemp & ">"
        '            End If
        '            strTemp = strTemp.Substring(0, intMiddle + 1) & strStopHTML1.GetValue(i) & strTemp.Substring(intMiddle + 1)
        '        End If
        '    End If
        'Next


        ''try to add the closing task of a table
        'For i As Byte = 0 To strStartHTML1.GetLowerBound(0)
        '    intStart = strTemp.LastIndexOf(strStartHTML1.GetValue(i))
        '    If intStart >= 0 Then
        '        strTemp = strTemp & strStopHTML1.GetValue(i)
        '        Exit For
        '    End If
        'Next

        ''try to add the openning task of a table
        'For i As Byte = 0 To strStartHTML2.GetLowerBound(0)
        '    intStart = strTemp.IndexOf(strStartHTML2.GetValue(i))
        '    If intStart >= 0 Then
        '        strTemp = strStopHTML2.GetValue(i) & strTemp
        '        Exit For
        '    End If
        'Next
        Return strTemp
    End Function

    Sub WriteLog(ByVal logFile As String, ByVal LogContent As String, ByVal LogLevel As String, ByVal LogTime As String)
        Try
            logFile = logFile + DateTime.Now.ToString("yyyy-MM-dd") + ".log"
            Dim fs As FileStream = New FileStream(logFile, FileMode.OpenOrCreate, FileAccess.Write)
            Dim m_streamWriter As StreamWriter = New StreamWriter(fs)
            m_streamWriter.BaseStream.Seek(0, SeekOrigin.End)
            m_streamWriter.WriteLine(LogTime & ":" & LogLevel & "-->" & LogContent)
            m_streamWriter.Flush()
            m_streamWriter.Close()
        Catch ex As Exception

        End Try
    End Sub
End Module

