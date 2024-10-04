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

    'Public Function getIMGs(ByRef objIMGs As Collection, ByRef strContent As String, ByVal strSource As String) As String
    '    Dim intStart, intStop, intIMGStart As Integer
    '    Dim strTmp As String = ""

    '    intIMGStart = strContent.IndexOf("<IMG", 0)
    '    If intIMGStart < 0 Then
    '        intIMGStart = strContent.IndexOf("<img", 0)
    '    End If

    '    If intIMGStart >= 0 Then
    '        intStart = strContent.IndexOf("src=""", intIMGStart)
    '    Else
    '        intStart = -1
    '    End If
    '    Dim objWebImage As WebImage
    '    Dim strTime As String
    '    Dim strLeft, strRight As String
    '    While intStart >= 0
    '        intStop = strContent.IndexOf("""", intStart + 5)
    '        If intStop >= 0 Then
    '            strTmp = ""
    '            strTmp = strContent.Substring(intStart + 5, intStop - intStart - 5)
    '            objWebImage = New WebImage
    '            objWebImage.OriginalPath = strTmp.Replace("..", "")
    '            strTime = DateTime.Now.ToString() & DateTime.Now.Millisecond.ToString
    '            strTime = strTime.Replace("/", "")
    '            strTime = strTime.Replace(":", "")
    '            strTime = strTime.Replace(" ", "")
    '            objWebImage.imgNewFileName = "NNKSOFT_IIE" & strTime & getFileName(strTmp)

    '            '-----------------------------------------------------------
    '            'Replace image with the source at local computer
    '            strLeft = ""
    '            strRight = ""
    '            strLeft = strContent.Substring(0, intStart + 5)
    '            strRight = strContent.Substring(intStop, strContent.Length - 1 - intStop)
    '            strContent = strLeft & "./INTERNETIMAGES/" & strSource & "/" & objWebImage.imgNewFileName & strRight
    '            'strContent = strContent.Replace(strTmp, "./" & strSource & "/" & objWebImage.imgNewFileName)
    '            '------------------------------------------------------------
    '            objIMGs.Add(objWebImage)
    '        End If

    '        intIMGStart = strContent.IndexOf("<IMG", intStop)
    '        If intIMGStart < 0 Then
    '            intIMGStart = strContent.IndexOf("<img", intStop)
    '        End If
    '        If intIMGStart >= 0 Then
    '            intStart = strContent.IndexOf("src=""", intIMGStart)
    '        Else
    '            intStart = -1
    '        End If
    '    End While
    'End Function

    Public Function getIMGs4Weather(ByRef objIMGs As Collection, ByRef strContent As String, ByVal strSource As String, _
                                     ByVal strWebPath As String) As String
        Dim intStart, intStop, intIMGStart As Integer
        Dim strTmp As String = ""
        Dim strContentTEMP As String
        'Dim strFileName As String = strWebPath & "\INTERNETIMAGES\" & strWebPath & "\" & getFileName(strURL)
        strContentTEMP = strContent.ToUpper

        intIMGStart = strContentTEMP.IndexOf("<IMG", 0)

        If intIMGStart >= 0 Then
            intStart = strContentTEMP.IndexOf("SRC='", intIMGStart)
        Else
            intStart = -1
        End If

        Dim objWebImage As WebImage
        Dim strTime As String
        strTime = DateTime.Now.ToString("ddMMyyyy")
        strTime = strTime.Replace("/", "")
        strTime = strTime.Replace(":", "")
        strTime = strTime.Replace(" ", "")
        Dim strLeft, strRight As String
        While intStart >= 0
            intStop = strContentTEMP.IndexOf("'", intStart + 5)
            If intStop >= 0 Then
                strTmp = ""
                strTmp = strContent.Substring(intStart + 5, intStop - intStart - 5)
                objWebImage = New WebImage
                objWebImage.OriginalPath = strTmp.Replace("..", "")
                objWebImage.OriginalPath = objWebImage.OriginalPath.Replace("%20", " ")
                'strTime = DateTime.Now.ToString() & DateTime.Now.Millisecond.ToString
                'strTime = strTime.Replace("/", "")
                'strTime = strTime.Replace(":", "")
                'strTime = strTime.Replace(" ", "")
                objWebImage.imgNewFileName = "image/" & strSource & "/VNN_IIE_" & strTime & _
                                             getFileName(strTmp, "/").Replace("%20", "1")
                '"VNN_IIE" & strTime & getFileName(strTmp).Replace("%20", "1")

                '-----------------------------------------------------------
                'Replace image with the source at local computer
                strLeft = ""
                strRight = ""
                strLeft = strContent.Substring(0, intStart + 5)
                strRight = strContent.Substring(intStop, strContent.Length - intStop)
                strContent = strLeft & objWebImage.imgNewFileName & strRight
                'strContent = strContent.Replace(strTmp, "./" & strSource & "/" & objWebImage.imgNewFileName)
                '------------------------------------------------------------
                objIMGs.Add(objWebImage)
            End If
            strContentTEMP = strContent.ToUpper

            intIMGStart = strContentTEMP.IndexOf("<IMG", intStop)
            If intIMGStart >= 0 Then
                intStart = strContentTEMP.IndexOf("SRC='", intIMGStart)
            Else
                intStart = -1
            End If

        End While
    End Function

    Public Sub getIMGs_Old(ByRef objIMGs As Collection, ByRef strContent As String, ByVal objWebImage As WebImage, _
                            ByVal strSource As String, ByVal strImgUrl As String, ByVal stLogPath As String)

        Dim strTmp As String = ""
        Try
            objIMGs.Add(objWebImage)
        Catch ex As Exception
            WriteLog(stLogPath, "getIMGs_Old::Error-->" + ex.ToString, "INFOR", _
                      DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"))
        End Try
        'Try
        '    While intStart >= 0
        '        strTmp = ""
        '        If (intStop >= 0) Then
        '            i = i + 1
        '            intStop = strContentTEMP.IndexOf("'", intStart + 5)
        '            strTmp = strContent.Substring(intStart + 5, intStop - intStart - 5)
        '            If (i = 1) Then
        '                objWebImage = New WebImage
        '                objWebImage.OriginalPath = strTmp.Replace("..", "")
        '                objWebImage.OriginalPath = objWebImage.OriginalPath.Replace("%20", " ")
        '                strTime = DateTime.Now.ToString() & DateTime.Now.Millisecond.ToString
        '                strTime = strTime.Replace("/", "")
        '                strTime = strTime.Replace(":", "")
        '                strTime = strTime.Replace(" ", "")
        '                objWebImage.imgNewFileName = "VNN_IIE" & strTime & getFileName(strTmp, "/").Replace("%20", "1")

        '                Dim tagStartImg As Integer = strContent.IndexOf("<IMG", intStart - 100)
        '                Dim tagEndImg As Integer = strContent.IndexOf(">", intStart + 5)

        '                '-----------------------------------------------------------
        '                'Replace image with the source at local computer
        '                strLeft = ""
        '                strRight = ""

        '                tagStartImg = strContent.IndexOf("<IMG", intStart - 100)
        '                tagEndImg = strContent.IndexOf(">", intStart + 5)
        '                strLeft = strContent.Substring(0, tagStartImg + 4) + " SRC='"
        '                'strRight = strContent.Substring(intStop, strContent.Length - intStop)
        '                strRight = strContent.Substring(tagEndImg)
        '                'strContent = strLeft & strImgUrl.Replace("{link}", "/INTERNETIMAGES/" & strSource & "/" & objWebImage.imgNewFileName) & strRight
        '                'Ghi thang truc tiep vao thu muc goc cua FTP SERVER
        '                strContent = strLeft & strImgUrl.Replace("{link}", "/INTERNETIMAGES/" & currentmonth & "/" & objWebImage.imgNewFileName & "'") & strRight

        '                'strContent = strContent.Replace(strTmp, "./" & strSource & "/" & objWebImage.imgNewFileName)
        '                '------------------------------------------------------------
        '                objIMGs.Add(objWebImage)
        '            Else '-----------------------------------------------------------
        '                'Remove other images except the first image
        '                intStop = strContentTEMP.IndexOf(">", intStart + 5)

        '                strLeft = ""
        '                strRight = ""
        '                strLeft = strContent.Substring(0, intIMGStart - 1)
        '                strRight = strContent.Substring(intStop, strContent.Length - intStop)
        '                strContent = strLeft & strRight
        '                'strContent = strContent.Replace(strTmp, "./" & strSource & "/" & objWebImage.imgNewFileName)
        '                '------------------------------------------------------------

        '            End If

        '        End If
        '        strContentTEMP = strContent.ToUpper

        '        intIMGStart = strContentTEMP.IndexOf("<IMG", intStop)
        '        If intIMGStart >= 0 Then
        '            intStart = strContentTEMP.IndexOf("SRC='", intIMGStart)
        '        Else
        '            intStart = -1
        '        End If

        '    End While
        'Catch ex As Exception
        '    WriteLog(stLogPath, "getIMGs_Old::Error-->" + ex.ToString, "INFOR", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"))
        'End Try

    End Sub

    Public Function getRelateInfor(ByRef strContent As String) As String
        Dim intStart, intStop, intIMGStart As Integer
        Dim strTmp As String = ""
        Dim strContentTEMP As String
        Dim currentmonth As String = DateTime.Now.ToString("yyyy-MM")
        'Dim strFileName As String = MY_WEB_PATH & "\INTERNETIMAGES\" & strImageDirectory & "\" & getFileName(strURL)
        strContentTEMP = strContent.ToUpper
        strContentTEMP = strContentTEMP.Replace("""", "'")
        intIMGStart = strContentTEMP.IndexOf("<IMG", 0)

        If intIMGStart >= 0 Then
            intStart = strContentTEMP.IndexOf("SRC='", intIMGStart)
        Else
            intStart = -1
        End If

        Dim objWebImage As WebImage
        Dim strTime As String
        Dim strLeft, strRight As String
        Dim i As Integer = 0
        While intStart >= 0
            strTmp = ""
            If (intStop >= 0) Then
                i = i + 1
                intStop = strContentTEMP.IndexOf("'", intStart + 5)
                strTmp = strContent.Substring(intStart + 5, intStop - intStart - 5)
                If (i = 1) Then
                    objWebImage = New WebImage
                    objWebImage.OriginalPath = strTmp.Replace("..", "")
                    objWebImage.OriginalPath = objWebImage.OriginalPath.Replace("%20", " ")
                    strTime = DateTime.Now.ToString() & DateTime.Now.Millisecond.ToString
                    strTime = strTime.Replace("/", "")
                    strTime = strTime.Replace(":", "")
                    strTime = strTime.Replace(" ", "")
                    objWebImage.imgNewFileName = "VNN_IIE" & strTime & getFileName(strTmp, "/").Replace("%20", "1")

                    '-----------------------------------------------------------
                    'Replace image with the source at local computer
                    strLeft = ""
                    strRight = ""
                    strLeft = strContent.Substring(0, intStart + 5)
                    Dim tagEndImg As Integer = strContent.IndexOf(">", intStart + 5)
                    'strRight = strContent.Substring(intStop, strContent.Length - intStop)
                    strRight = strContent.Substring(tagEndImg)
                    'strContent = strLeft & strImgUrl.Replace("{link}", "/INTERNETIMAGES/" & strSource & "/" & objWebImage.imgNewFileName) & strRight
                    'Ghi thang truc tiep vao thu muc goc cua FTP SERVER
                    'strContent = strLeft & strImgUrl.Replace("{link}", "/INTERNETIMAGES/" & currentmonth & "/" & objWebImage.imgNewFileName & "'") & strRight

                    'strContent = strContent.Replace(strTmp, "./" & strSource & "/" & objWebImage.imgNewFileName)
                    '------------------------------------------------------------
                    'objIMGs.Add(objWebImage)
                Else '-----------------------------------------------------------
                    'Remove other images except the first image
                    intStop = strContentTEMP.IndexOf(">", intStart + 5)

                    strLeft = ""
                    strRight = ""
                    strLeft = strContent.Substring(0, intIMGStart - 1)
                    strRight = strContent.Substring(intStop, strContent.Length - intStop)
                    strContent = strLeft & strRight
                    'strContent = strContent.Replace(strTmp, "./" & strSource & "/" & objWebImage.imgNewFileName)
                    '------------------------------------------------------------

                End If

            End If
            strContentTEMP = strContent.ToUpper

            intIMGStart = strContentTEMP.IndexOf("<IMG", intStop)
            If intIMGStart >= 0 Then
                intStart = strContentTEMP.IndexOf("SRC='", intIMGStart)
            Else
                intStart = -1
            End If

        End While
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

