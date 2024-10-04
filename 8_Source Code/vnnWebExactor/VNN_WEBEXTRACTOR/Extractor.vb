Imports System.Net
Imports System.Collections.ObjectModel
Imports System.Configuration
Imports System.Text
Imports System.IO
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Data.SqlClient
Imports System.Xml
Imports vnnRssFramework


Public Class Extractor
    Const REQUEST_TIMEOUT As Integer = 60000
    Private objConn As New SqlConnection
    Private MY_WEB_PATH As String
    Private myProxy As WebProxy
    Private boolProxy As Boolean = False
    Private objRequest As HttpWebRequest
    Private objResponse As HttpWebResponse
    Dim intCategoryID As Integer
    Dim strSourceContent As String
    Public strGoldContent As String = ""
    Public strExRateContent As String = ""

    Dim strHref, _
        strStartTags, _
        strEndTags, _
        strTitleStartTags, _
        strTitleEndTags, _
        strDescStartTags, _
        strDescEndTags, _
        strContentStartTags, _
        strContentEndTags, _
        strSource, _
        strSourceDescription, _
        strServiceName, _
        strImgUrl As String

    Dim strImageDirectory As String
    Dim strImageDownload As String
    Dim strStartNewsHref As String
    Dim ftp As FTP.FtpClient = Nothing
    Public strWeatherHTML As StringBuilder
    Public strGoldHTML As StringBuilder
    Public strCkHTML As StringBuilder
    Public VNN_WEATHER_DETAIL As String = ""
    Public VNN_GOLD_DETAIL As String = ""
    Public VNN_CK_DETAIL As String = ""
    Public VNN_EXRATE_DETAIL As String = ""
    Public VNN_WEATHER_DATE As String = ""
    Public VNN_GOLD_DATE As String = ""
    Public VNN_CK_DATE As String = ""
    Public VNN_EXRATE_DATE As String = ""
    Public stLogPath As String

    Public Sub initDataConnection(ByVal objConnection As SqlConnection)
        objConn = objConnection
    End Sub

    Private Sub initMyProxy()
        Dim objReg As New MyRegistry
        objReg.getRegs()
        Dim netCredential As NetworkCredential
        If CType(objReg.boolProxy, Boolean) Then
            netCredential = New NetworkCredential(objReg.strUserName, objReg.strPassword, objReg.strDomain)
            myProxy = New WebProxy(objReg.strProxyAddress & ":" & objReg.strProxyPort, True)
            myProxy.Credentials = netCredential
            boolProxy = True
        End If
        MY_WEB_PATH = objReg.strWebPath
        stLogPath = objReg.strLogPath
        strImgUrl = objReg.strImgUrl
        objReg = Nothing
    End Sub

    Private Sub getSourceInfor(ByVal strURL As String)
        Dim objSource As New Data.SourceInfor
        objSource = Data.SourceController.selectSource(objConn, strURL)
        With objSource
            strHref = ._Href
            strStartTags = ._StartTags
            strEndTags = ._EndTags
            strTitleStartTags = ._TitleStartTags
            strTitleEndTags = ._TitleEndTags
            strDescStartTags = ._DescStartTags
            strDescEndTags = ._DescEndTags
            strContentStartTags = ._ContentStartTags
            strContentEndTags = ._ContentEndTags
            strSource = ._Source
            intCategoryID = ._CategoryID
            strSourceDescription = ._Description
            strImageDirectory = ._ImageDirectory
            strImageDownload = ._WholeImagePath
            strStartNewsHref = ._StartNewsHref
            strServiceName = ._ServiceName
        End With
        objSource = Nothing
    End Sub

   
    Public Sub doAutoExtract()
        Dim objDs As New DataSet
        'Dim strContent As String
        
        Dim url As String = ""
        Dim lRss As ReadOnlyCollection(Of RssEntry)
        'Dim rssEntry As RssEntry
        Dim lRss1 As Collection = New Collection()
        Try
            Dim strLink As String
            Dim strTitle As String
            Dim clsWeb As WebContentInfor
            Dim doc As HtmlAgilityPack.HtmlDocument = New HtmlAgilityPack.HtmlDocument()
            Dim strXpathTitle As String = ""
            Dim htmlCollect As HtmlAgilityPack.HtmlNodeCollection
            Call initMyProxy()
            objDs = Data.SourceController.selectSourcesByNewsFlag(1, stLogPath)
            Dim rssGreader As RssReader
            Dim dtRows As DataRow
            For i As Integer = 0 To objDs.Tables(0).Rows.Count - 1
                Try
                    dtRows = objDs.Tables(0).Rows(i)
                    'Read the source information from database
                    url = dtRows.Item("Href").ToString.ToLower.Trim
                    With dtRows
                        strHref = .Item("Href")
                        strStartTags = .Item("StartTags")
                        strEndTags = .Item("EndTags")
                        strTitleStartTags = .Item("TitleStartTags")
                        strTitleEndTags = .Item("TitleEndTags")
                        strDescStartTags = .Item("DescStartTags")
                        strDescEndTags = .Item("DescEndTags")
                        strContentStartTags = .Item("ContentStartTags")
                        strContentEndTags = .Item("ContentEndTags")
                        strSource = .Item("Source")
                        intCategoryID = .Item("CategoryID")
                        strSourceDescription = .Item("Description")
                        strImageDirectory = .Item("ImageDirectory")
                        strImageDownload = .Item("WholeImagePath")
                        strStartNewsHref = ""
                        strServiceName = .Item("ServiceName")
                    End With
                    If url.Trim.ToLower.Equals("http://www.oil-price.net/COMMODITIES/gen.php?lang=en".ToLower) Then
                        If gettingSource("http://www.oil-price.net/COMMODITIES/gen.php?lang=en", strStartTags) Then
                            If getNewsItem(strSourceContent) Then
                                Dim OilUrl As String = System.Configuration.ConfigurationManager.AppSettings("OilUrl")
                                Dim imgUrl As String = "http://oil-price.net/COMMODITIES/gradient.png"
                                Dim OilScript As String = MY_WEB_PATH + "\oil.js"
                                strSourceContent = strSourceContent.Replace("http://oil-price.net/COMMODITIES/gradient.png", OilUrl.Replace("{link}", "gradient.png"))
                                strSourceContent = strSourceContent.Replace("http://oil-price.net/COMMODITIES/static/gradient.png", OilUrl.Replace("{link}", "gradient.png"))

                                If (SaveTextToFile(strSourceContent, OilScript, "")) Then
                                    SendOilScript2FtpServer(OilScript, "", "", System.Configuration.ConfigurationManager.AppSettings("OilFtpRemoteDir"))
                                End If

                            End If
                        End If
                    Else
                        'Neu la du lieu duoc lay tu RSS
                        If "rss".Equals(url.Substring(url.Length - 3)) Then
                            rssGreader = New RssReader(url)
                            lRss = rssGreader.Entries

                            For Each rssEntry As RssEntry In lRss
                                clsWeb = New WebContentInfor
                                clsWeb.Title = rssEntry.Title
                                clsWeb.Description = rssEntry.Description
                                clsWeb.Content = ""
                                clsWeb.Href = rssEntry.Link
                                clsWeb.Image = ""
                                clsWeb.CategoryID = intCategoryID
                                clsWeb.Source = strSource
                                webCols.Add(clsWeb)
                            Next

                            If getNewsContent(strServiceName) Then
                                UpdateNews()
                            End If
                        Else
                            If gettingSource(url, strStartTags) Then
                                doc = New HtmlAgilityPack.HtmlDocument()
                                doc.LoadHtml(strSourceContent)
                                strXpathTitle = strContentStartTags
                                If Not strXpathTitle.StartsWith("//") Then
                                    strXpathTitle = "//" + strXpathTitle
                                End If
                                htmlCollect = doc.DocumentNode.SelectNodes(strXpathTitle)
                                If Not IsNothing(htmlCollect) Then
                                    If strServiceName.Trim.Equals("2sao") Then
                                        For Each element As HtmlAgilityPack.HtmlNode In htmlCollect
                                            strLink = element.Attributes("href").Value
                                            If strLink.IndexOf("2sao.vietnamnet.vn") >= 0 Then
                                                strTitle = element.InnerHtml.ToString()
                                                clsWeb = New WebContentInfor
                                                clsWeb.Title = strTitle
                                                clsWeb.Description = ""
                                                clsWeb.Content = ""
                                                clsWeb.Href = strLink
                                                clsWeb.Image = ""
                                                clsWeb.CategoryID = intCategoryID
                                                clsWeb.Source = strSource
                                                webCols.Add(clsWeb)
                                            End If
                                        Next
                                    ElseIf strServiceName.Trim.Equals("ttol") Then
                                        For Each element As HtmlAgilityPack.HtmlNode In htmlCollect
                                            strLink = element.Attributes("href").Value
                                            If strLink.IndexOf("tintuconline.vietnamnet.vn") >= 0 Then
                                                strTitle = element.InnerHtml.ToString()
                                                clsWeb = New WebContentInfor
                                                clsWeb.Title = strTitle
                                                clsWeb.Description = ""
                                                clsWeb.Content = ""
                                                clsWeb.Href = strLink
                                                clsWeb.Image = ""
                                                clsWeb.CategoryID = intCategoryID
                                                clsWeb.Source = strSource
                                                webCols.Add(clsWeb)
                                            End If
                                        Next
                                    Else
                                        For Each element As HtmlAgilityPack.HtmlNode In htmlCollect
                                            strLink = element.Attributes("href").Value
                                            strTitle = element.InnerHtml.ToString()
                                            clsWeb = New WebContentInfor
                                            clsWeb.Title = strTitle
                                            clsWeb.Description = ""
                                            clsWeb.Content = ""
                                            clsWeb.Href = strLink
                                            clsWeb.Image = ""
                                            clsWeb.CategoryID = intCategoryID
                                            clsWeb.Source = strSource
                                            webCols.Add(clsWeb)
                                        Next
                                    End If

                                    If getNewsContent4TOP(strServiceName, stLogPath) Then
                                        UpdateNews()
                                    End If
                                End If
                            End If

                        End If
                    End If
                Catch ex As Exception
                    WriteLog(stLogPath, "doAutoExtract@error::" + ex.ToString(), "ERROR:", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"))
                End Try

            Next
        Catch ex As Exception

            'Exit Sub
        Finally
            If Not IsNothing(objConn) Then
                objConn.Close()
                objConn = Nothing
            End If

        End Try


    End Sub

    'Connect to URL and get content of the main page
    Private Function gettingSource(ByVal strURL As String, ByVal strStartXPath As String) As Boolean
        Dim strContent As New StringBuilder
        Dim doc As HtmlAgilityPack.HtmlDocument = New HtmlAgilityPack.HtmlDocument()
        Dim strXpathTitle As String = ""
        Dim htmlCollect As HtmlAgilityPack.HtmlNodeCollection
        strSourceContent = ""
        Try
            'WriteLog(stLogPath, "Start connect to URL: " & strURL, "INFOR:", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"))
            objRequest = Nothing
            objRequest = WebRequest.Create(strURL)
            objRequest.Timeout = REQUEST_TIMEOUT

            If boolProxy Then
                objRequest.Proxy = myProxy
            End If

            objResponse = objRequest.GetResponse

            If objResponse.StatusCode = HttpStatusCode.OK Then
                Dim encode As Encoding = System.Text.Encoding.GetEncoding("utf-8")
                Dim readStream As New StreamReader(objResponse.GetResponseStream, encode)
                strContent.Append(readStream.ReadToEnd)

                doc = New HtmlAgilityPack.HtmlDocument()
                doc.LoadHtml(strContent.ToString)
                If Not (strURL.StartsWith("http://www.oil-price.net/")) Then
                    strXpathTitle = strStartXPath
                    If strXpathTitle.Equals("html") Then
                        strXpathTitle = "//" + strXpathTitle
                    Else
                        If Not strXpathTitle.StartsWith("//") Then
                            strXpathTitle = "//" + strXpathTitle
                        End If
                    End If
                    htmlCollect = doc.DocumentNode.SelectNodes(strXpathTitle)
                    If Not IsNothing(htmlCollect) Then
                        For Each element As HtmlAgilityPack.HtmlNode In htmlCollect
                            strSourceContent = strSourceContent + element.InnerHtml.ToString() + vbCrLf
                        Next
                    End If
                Else
                    strSourceContent = strContent.ToString
                End If
               
                'strSourceContent = strContent.ToString
                'WriteLog(stLogPath, "Finished get data from URL: " & strURL, "INFOR:", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"))
                Return True
            Else
                WriteLog(stLogPath, "Can not connect to URL: " & strURL, "ERROR:", _
                         DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"))
                Return False
            End If
        Catch ex As Exception
            WriteLog(stLogPath, "gettingSource@urr-->" + strURL + " has error::" + ex.ToString(), "ERROR:", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"))
            Return False
        Finally
            If Not IsNothing(objResponse) Then
                objResponse.Close()
            End If
        End Try

    End Function
    
    Private Function getNewsContentFromRSS(ByVal strContent As String) As Boolean
        Dim intStart, intStop As Integer
        Dim clsWeb As WebContentInfor
        Dim strTmp As String
        Try

            intStart = strContent.IndexOf(strStartTags, 0)

            While intStart >= 0
                intStop = strContent.IndexOf(strEndTags, intStart + 1)
                If intStop > 0 Then
                    strTmp = strContent.Substring(intStart, intStop - intStart)
                    clsWeb = New WebContentInfor
                    clsWeb.Title = splitContent(strTmp, strTitleStartTags, strTitleEndTags)
                    clsWeb.Description = splitContent(strTmp, strDescStartTags, strDescEndTags)
                    clsWeb.Content = ""
                    clsWeb.Href = strStartNewsHref.Trim & getTheFirstLink(strTmp)
                    clsWeb.Image = ""
                    clsWeb.CategoryID = intCategoryID
                    clsWeb.Source = strSource
                    intStart = strContent.IndexOf(strStartTags, intStop)
                    webCols.Add(clsWeb)
                Else
                    Exit While
                End If
            End While

            Return True

        Catch ex As Exception
            Return False
        End Try

    End Function

    'Analyze source content  of the main page and update collection
    Private Function getNewsItemFromRss(ByVal strContent As String) As Boolean
        Dim intStart, intStop As Integer
        Dim clsWeb As WebContentInfor
        Dim strTmp As String
        Try

            intStart = strContent.IndexOf(strStartTags, 0)

            While intStart >= 0
                intStop = strContent.IndexOf(strEndTags, intStart + 1)
                If intStop > 0 Then
                    strTmp = strContent.Substring(intStart, intStop - intStart)
                    clsWeb = New WebContentInfor
                    clsWeb.Title = splitContent(strTmp, strTitleStartTags, strTitleEndTags)
                    clsWeb.Description = splitContent(strTmp, strDescStartTags, strDescEndTags)
                    clsWeb.Content = ""
                    clsWeb.Href = strStartNewsHref.Trim & getTheFirstLink(strTmp)
                    clsWeb.Image = ""
                    clsWeb.CategoryID = intCategoryID
                    clsWeb.Source = strSource
                    intStart = strContent.IndexOf(strStartTags, intStop)
                    webCols.Add(clsWeb)
                Else
                    Exit While
                End If
            End While

            Return True

        Catch ex As Exception
            Return False
        End Try

    End Function

    Private Function getNewsItem(ByVal strContent As String) As Boolean
        Dim intStart, intStop As Integer
        Dim clsWeb As WebContentInfor
        Dim strTmp As String
        Try

            intStart = strContent.IndexOf(strStartTags, 0)

            While intStart >= 0
                intStop = strContent.IndexOf(strEndTags, intStart + 1)
                If intStop > 0 Then
                    strTmp = strContent.Substring(intStart, intStop - intStart)
                    clsWeb = New WebContentInfor
                    clsWeb.Title = splitContent(strTmp, strTitleStartTags, strTitleEndTags)
                    clsWeb.Description = splitContent(strTmp, strDescStartTags, strDescEndTags)
                    clsWeb.Content = ""
                    clsWeb.Href = strStartNewsHref.Trim & getTheFirstLink(strTmp)
                    clsWeb.Image = ""
                    clsWeb.CategoryID = intCategoryID
                    clsWeb.Source = strSource
                    intStart = strContent.IndexOf(strStartTags, intStop)
                    webCols.Add(clsWeb)
                Else
                    Exit While
                End If
            End While

            Return True

        Catch ex As Exception
            Return False
        End Try

    End Function

    Private Function getNewsContentFromTuanVN() As Boolean

    End Function

    Private Function getNewsContent4TOP(ByVal strServiceName As String, ByVal strLogPath As String) As Boolean
        Dim strTmp As String = ""
        Dim strHref As String = ""
        Dim strContentXpath As String = ""
        Dim strImgDownload As String = ""
        Dim strDesc As String = ""
        Try
            For i As Integer = 1 To webCols.Count
                'Analyze Content if News is not existed ?
                strHref = CType(webCols(i), WebContentInfor).Href
                If Not NewsController.isExisted(strHref, CType(webCols(i), WebContentInfor).CategoryID) Then
                    If (strHref.StartsWith("/")) Then
                        strHref = "http://vietnamnet.vn" + strHref
                    End If
                    'If _
                    '    strHref.IndexOf("http://203.162.71.75:9999/") >= 0 Or _
                    '    strHref.IndexOf("http://vietnamnet.vn/") >= 0 Then
                    '    strContentXpath = "//*[@id=""content""]"
                    '    strImgDownload = "http://images.vietnamnet.vn/"
                    'ElseIf (strHref.IndexOf("tuanvietnam.net") >= 0) Then
                    '    strContentXpath = "//*[@id=""CtxText""]"
                    '    strImgDownload = "tuanvietnam"
                    'ElseIf (strHref.IndexOf("vnr500.vietnamnet.vn") >= 0) Then
                    '    strContentXpath = "//*[@id=""ctl00_ContentPlaceHolder1_news1_txtContent""]"
                    '    strImgDownload = "http://vnr500.vietnamnet.vn/"
                    'ElseIf (strHref.IndexOf("tintuconline.vietnamnet.vn") >= 0) Then
                    '    strContentXpath = "//*[@id=""newsContent""]"
                    '    strImgDownload = "http://tintuconline.vietnamnet.vn/"
                    'ElseIf (strHref.IndexOf("2sao.vietnamnet.vn") >= 0) Then
                    '    strContentXpath = "//div[@class='detail_content']"
                    '    strImgDownload = "http://2sao.vietnamnet.v/"
                    'End If
                    If _
                        strHref.IndexOf("http://203.162.71.75:9999/") >= 0 Or _
                        strHref.IndexOf("http://vietnamnet.vn/") >= 0 Then
                        strContentXpath = "//*[@id=""content""]"
                        strImgDownload = "http://images.vietnamnet.vn/"
                    ElseIf (strHref.IndexOf("tuanvietnam") >= 0) Then
                        strContentXpath = "//*[@id=""CtxText""]"
                        strImgDownload = "http://tuanvietnam.vietnamnet.vn"
                    ElseIf (strHref.IndexOf("vnr500") >= 0) Then
                        strContentXpath = "//*[@id=""CtxText""]"
                        strImgDownload = "http://vnr500.vietnamnet.vn/"
                    ElseIf (strHref.IndexOf("tintuconline.vietnamnet.vn") >= 0) Then
                        strContentXpath = "//*[@id=""newsContent""]"
                        strImgDownload = "http://tintuconline.vietnamnet.vn/"
                    ElseIf (strHref.IndexOf("2sao.vietnamnet.vn") >= 0) Then
                        strContentXpath = "//div[@class=""detail_content""]"
                        strImgDownload = "http://2sao.vietnamnet.v/"
                    Else
                        strContentXpath = strContentStartTags
                    End If
                    If Not strContentXpath.StartsWith("//") Then
                        strContentXpath = "//" + strContentXpath
                    End If
                    objRequest = WebRequest.Create(strHref)
                    objRequest.Timeout = REQUEST_TIMEOUT

                    If boolProxy Then
                        objRequest.Proxy = myProxy
                    End If

                    objResponse = objRequest.GetResponse
                    Dim encode As Encoding = System.Text.Encoding.GetEncoding("utf-8")
                    Dim readStream As New StreamReader(objResponse.GetResponseStream, encode)
                    strTmp = readStream.ReadToEnd

                    If objResponse.StatusCode = HttpStatusCode.OK Then
                        Dim objIMGs As New Collection

                        strTmp = AnalyzeContent(strTmp, strContentXpath, objIMGs, strImgDownload)
                        strDesc = AnalyzeContent4Desc(strTmp, strContentXpath, objIMGs, strImgDownload)
                        CType(webCols.Item(i), WebContentInfor).Content = strTmp
                        CType(webCols.Item(i), WebContentInfor).Description = strDesc
                        'Get Image and Save to Disk
                        If Not strTmp.Trim.Equals("") Then
                            If (Not IsNothing(objIMGs)) And (objIMGs.Count > 0) Then
                                For j As Integer = 1 To objIMGs.Count
                                    If j = 1 Then
                                        CType(webCols(i), WebContentInfor).Image = CType(objIMGs.Item(j), VNN_WEBEXTRACTOR.WebImage).imgLink
                                        '"./INTERNETIMAGES/" & strImageDirectory & "/" & CType(objIMGs.Item(j), VNN_WEBEXTRACTOR.WebImage).imgNewFileName
                                    End If

                                    CType(webCols.Item(i), WebContentInfor).ImgDownloadFlag = _
                                        getAndsaveImg( _
                                                      CType(objIMGs.Item(j), VNN_WEBEXTRACTOR.WebImage). _
                                                         OriginalPath, _
                                                      CType(objIMGs.Item(j), VNN_WEBEXTRACTOR.WebImage). _
                                                         imgNewFileName)

                                Next
                                For k As Integer = objIMGs.Count To 1 Step -1
                                    objIMGs.Remove(k)
                                Next
                                WriteLog(stLogPath, _
                                         "getNewsContent is sucessfull with url-->" + _
                                         CType(webCols.Item(i), WebContentInfor).Href, "INFOR", _
                                         DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"))
                            End If

                        Else
                            WriteLog(stLogPath, _
                                     "getNewsContent with url-->" + CType(webCols.Item(i), WebContentInfor).Href + _
                                     "@was failed: Could not get the news content ", "ERROR", _
                                     DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"))
                        End If

                        '----------------------------
                    Else
                        WriteLog(stLogPath, _
                                 "getNewsContent was failed with url-->" + _
                                 CType(webCols.Item(i), WebContentInfor).Href, "ERROR", _
                                 DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"))
                        Return False
                    End If
                End If
            Next
            Return True
        Catch ex As Exception
            WriteLog(stLogPath, "getNewsContent:Error-->" + ex.ToString, "ERROR", _
                     DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"))
            Return False
        Finally
            If (Not objResponse Is Nothing) Then
                objResponse.Close()
            End If
        End Try
    End Function

    Private Function getNewsContent(ByVal strServiceName As String) As Boolean
        Dim strTmp As String
        Dim strHref As String = ""
        Dim strContentXpath As String = ""
        Try
            For i As Integer = 1 To webCols.Count

                'Analyze Content if News is not existed ?
                strHref = CType(webCols(i), WebContentInfor).Href

                'Analyze Content if News is not existed ?
                If Not NewsController.isExisted(strHref, CType(webCols(i), WebContentInfor).CategoryID) Then
                    objRequest = WebRequest.Create(CType(webCols.Item(i), WebContentInfor).Href)
                    objRequest.Timeout = REQUEST_TIMEOUT

                    If boolProxy Then
                        objRequest.Proxy = myProxy
                    End If

                    objResponse = objRequest.GetResponse
                    Dim encode As Encoding = System.Text.Encoding.GetEncoding("utf-8")
                    Dim readStream As New StreamReader(objResponse.GetResponseStream, encode)
                    strTmp = readStream.ReadToEnd

                    If objResponse.StatusCode = HttpStatusCode.OK Then
                        'CType(webCols.Item(i), WebContentInfor).Content = AnalyzeContent(strTmp)

                        Dim doc As HtmlAgilityPack.HtmlDocument = New HtmlAgilityPack.HtmlDocument()
                        doc.LoadHtml(strTmp)
                        'For Each element As HtmlAgilityPack.HtmlNode In doc.DocumentNode.SelectNodes("//*" + strContentStartTags)
                        Dim objIMGs As New Collection
                        strTmp = _
                            AnalyzeContent(strTmp, "//*" + strContentStartTags.Replace("'", """"), objIMGs, _
                                           strImageDownload)
                        CType(webCols.Item(i), WebContentInfor).Content = strTmp

                        'Get Image and Save to Disk
                        If Not strTmp.Trim.Equals("") Then
                            If (Not IsNothing(objIMGs)) And (objIMGs.Count > 0) Then
                                For j As Integer = 1 To objIMGs.Count
                                    If j = 1 Then
                                        CType(webCols(i), WebContentInfor).Image = CType(objIMGs.Item(j), VNN_WEBEXTRACTOR.WebImage).imgLink
                                        '"./INTERNETIMAGES/" & strImageDirectory & "/" & CType(objIMGs.Item(j), VNN_WEBEXTRACTOR.WebImage).imgNewFileName
                                    End If

                                    CType(webCols.Item(i), WebContentInfor).ImgDownloadFlag = _
                                        getAndsaveImg( _
                                                      CType(objIMGs.Item(j), VNN_WEBEXTRACTOR.WebImage). _
                                                         OriginalPath, _
                                                      CType(objIMGs.Item(j), VNN_WEBEXTRACTOR.WebImage). _
                                                         imgNewFileName)

                                Next
                                For k As Integer = objIMGs.Count To 1 Step -1
                                    objIMGs.Remove(k)
                                Next
                                WriteLog(stLogPath, _
                                         "getNewsContent is sucessfull with url-->" + _
                                         CType(webCols.Item(i), WebContentInfor).Href, "INFOR", _
                                         DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"))
                            End If

                        Else
                            WriteLog(stLogPath, _
                                     "getNewsContent with url-->" + CType(webCols.Item(i), WebContentInfor).Href + _
                                     "@was failed: Could not get the news content ", "ERROR", _
                                     DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"))
                        End If
                        '----------------------------
                    Else
                        WriteLog(stLogPath, "getNewsContent was failed with url-->" + strHref, "INFOR", _
                                 DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"))
                        Return False
                    End If
                End If
            Next
            Return True
        Catch ex As Exception
            WriteLog(stLogPath, "getNewsContent:Error-->" + ex.ToString + " At Url = " + strHref, "ERROR", _
                     DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"))
            Return False
        Finally
            If (Not objResponse Is Nothing) Then
                objResponse.Close()
            End If
        End Try
    End Function

    Private Function AnalyzeContent(ByVal strContent As String, ByVal strContentXpath As String, _
                                    ByRef objIMGs As Collection, ByVal strImgDownload As String) As String
        Dim strTmp As String = ""
        Dim strReturn As String
        Dim i As Integer
        strTmp = strContent.Replace("<IMG ", "<img ")

        Try
            Dim doc As HtmlAgilityPack.HtmlDocument = New HtmlAgilityPack.HtmlDocument()
            Dim htmlCollect As HtmlAgilityPack.HtmlNodeCollection
            doc.LoadHtml(strTmp)
            strReturn = ""
            htmlCollect = doc.DocumentNode.SelectNodes(strContentXpath)
            If Not IsNothing(htmlCollect) Then
                For Each element As HtmlAgilityPack.HtmlNode In htmlCollect
                    Dim NodeCollect As HtmlAgilityPack.HtmlNodeCollection
                    'Loai bo tag ve Video
                    NodeCollect = element.SelectNodes(element.XPath + "//div[@class=""video""]")
                    If Not IsNothing(NodeCollect) Then
                        For Each objVideo As HtmlAgilityPack.HtmlNode In NodeCollect
                            objVideo.Remove()
                        Next
                    End If
                    'Loai bo cac anh quang cao ve mobi
                    NodeCollect = element.SelectNodes(element.XPath + "//tbody/tr/th[2]")
                    If Not IsNothing(NodeCollect) Then
                        For Each objAdvMobi As HtmlAgilityPack.HtmlNode In NodeCollect
                            objAdvMobi.Remove()
                        Next
                    End If
                    'Loai bo cac anh logo
                    NodeCollect = element.SelectNodes(element.XPath + "//img")
                    If Not IsNothing(NodeCollect) Then
                        For Each objimgLogo As HtmlAgilityPack.HtmlNode In NodeCollect
                            Dim imgSrc As HtmlAgilityPack.HtmlAttribute

                            imgSrc = objimgLogo.Attributes("src")
                            If imgSrc.Value = "/common/v3/images/vietnamnet.gif" Or imgSrc.Value = "/Images/nut.gif" Then
                                objimgLogo.Remove()
                            Else
                                objimgLogo.Attributes.RemoveAll()
                                objimgLogo.Attributes("src") = imgSrc
                            End If
                        Next
                    End If
                    'Lay 1 anh duy nhat
                    NodeCollect = element.SelectNodes(element.XPath + "//img")
                    If Not IsNothing(NodeCollect) Then
                        i = 0
                        For Each objimg As HtmlAgilityPack.HtmlNode In NodeCollect
                            i = i + 1
                            If i > 1 Then
                                objimg.Remove()
                            Else

                                Dim objWebImage As WebImage
                                Dim imgSrc As HtmlAgilityPack.HtmlAttribute
                                imgSrc = objimg.Attributes("src")

                                objWebImage = New WebImage
                                objWebImage.OriginalPath = imgSrc.Value.Replace("..", "")
                                objWebImage.OriginalPath = objWebImage.OriginalPath.Replace("%20", " ")
                                If (Not objWebImage.OriginalPath.StartsWith("http://")) Then
                                    objWebImage.OriginalPath = strImgDownload + objWebImage.OriginalPath
                                End If
                                Dim strTime As String = DateTime.Now.ToString() & DateTime.Now.Millisecond.ToString
                                strTime = strTime.Replace("/", "")
                                strTime = strTime.Replace(":", "")
                                strTime = strTime.Replace(" ", "")

                                Dim _
                                    imgNewName As String = "VNN_IIE" & strTime & _
                                                           getFileName(imgSrc.Value, "/").Replace("%20", "1")
                                objWebImage.imgNewFileName = imgNewName
                                objWebImage.imgLink = strImgUrl.Replace("{link}", _
                                                      "/INTERNETIMAGES/" & DateTime.Now.ToString("yyyy-MM") & "/" & _
                                                      imgNewName)
                                objIMGs.Add(objWebImage)
                                imgSrc.Value = _
                                    strImgUrl.Replace("{link}", _
                                                      "/INTERNETIMAGES/" & DateTime.Now.ToString("yyyy-MM") & "/" & _
                                                      imgNewName)

                            End If
                        Next
                    End If
                    'Loai bo thuoc tinh class cho nhung td chu thich anh
                    NodeCollect = element.SelectNodes(element.XPath + "//td[@class=""image_desc""]")
                    If Not IsNothing(NodeCollect) Then
                        i = 0
                        For Each objimgNote As HtmlAgilityPack.HtmlNode In NodeCollect
                            i = i + 1
                            If i > 1 Then
                                objimgNote.Remove()
                            Else
                                'Dim imgSrc As HtmlAgilityPack.HtmlAttribute
                                'imgSrc = objimgNote.Attributes("class")
                                objimgNote.Attributes.Remove("class")
                            End If
                        Next
                    End If

                    'Loai bo tin lien quan cua TTOL
                    NodeCollect = _
                        element.SelectNodes( _
                                            element.XPath + _
                                            "//table[@class=""newsRelate""]")
                    If Not IsNothing(NodeCollect) Then
                        For Each objRelativeNews As HtmlAgilityPack.HtmlNode In NodeCollect
                            objRelativeNews.Remove()
                        Next
                    End If
                    'Loai bo tin lien quan
                    NodeCollect = _
                        element.SelectNodes( _
                                            element.XPath + _
                                            "//table[@class=""rl left"" or @class=""rl right"" or @class=""rl center""]")
                    If Not IsNothing(NodeCollect) Then
                        For Each objRelativeNews As HtmlAgilityPack.HtmlNode In NodeCollect
                            objRelativeNews.Remove()
                        Next
                    End If
                    'Loai bo cac link co chua anh
                    NodeCollect = element.SelectNodes(element.XPath + "//a[@onclick and @href]")
                    If Not IsNothing(NodeCollect) Then
                        i = 0
                        For Each objRelativeNews As HtmlAgilityPack.HtmlNode In NodeCollect
                            i = i + 1
                            If (i > 1) Then
                                objRelativeNews.Remove()
                            Else
                                objRelativeNews.Attributes("href").Value = "#"
                                objRelativeNews.Attributes("onclick").Remove()
                            End If
                        Next
                    End If

                    'Loai bo thuoc tinh width cho nhung table chua anh
                    NodeCollect = element.SelectNodes(element.XPath + "//table[@class=""image center"" or @class=""image left"" or @class=""image leftside"" or @class=""image right"" or @class=""image rightside""]")
                    If Not IsNothing(NodeCollect) Then
                        For Each objimgNote As HtmlAgilityPack.HtmlNode In NodeCollect
                            objimgNote.Attributes.Remove("width")
                            objimgNote.Attributes.Remove("class")
                        Next
                    End If

                    'Fix lai do rong cac bang co dat thuoc tinh width > 320
                    NodeCollect = element.SelectNodes(element.XPath + "//table[@width > 320]")
                    If Not IsNothing(NodeCollect) Then
                        For Each objimgNote As HtmlAgilityPack.HtmlNode In NodeCollect
                            objimgNote.Attributes("width").Value = "320"
                        Next
                    End If
                    'Loai bo cac doan nhung flash player
                    NodeCollect = element.SelectNodes(element.XPath + "//embed[@type=""application/x-shockwave-flash""]")
                    If Not IsNothing(NodeCollect) Then
                        For Each objimgNote As HtmlAgilityPack.HtmlNode In NodeCollect
                            objimgNote.Remove()
                        Next
                    End If

                    strReturn = strReturn + element.InnerHtml.ToString()
                Next
            End If


        Catch ex As Exception
            WriteLog(stLogPath, "AnalyzeContent::ERROR-->" + ex.ToString, "ERROR", _
                     DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"))
            strReturn = ""
        End Try
        strReturn = AnalyzeAndFixHTML(strReturn)
        Return strReturn
        ''intStart = strTmp.IndexOf("<p")
        ''intStop = strTmp.LastIndexOf("</div>")
        ''If (intStart > 0 And intStop > 0) Then
        ''    strTmp = strTmp.Substring(intStart, intStop)
        ''End If

        'strTmp = strTmp.Replace("""", "'").Replace("<img", "<img".ToUpper).Replace("src='", "src='".ToUpper)

        'intIMGStart = strTmp.IndexOf("<IMG", 0)
        'If intIMGStart >= 0 Then
        '    intStart = strTmp.IndexOf("SRC='", intIMGStart)
        'Else
        '    intStart = -1
        'End If
        'If (intStart >= 0) Then
        '    intStop = strTmp.IndexOf("'", intStart + 5)
        '    Dim strImg As String = strTmp.Substring(intStart + 5, intStop - intStart - 5).ToLower.Trim

        '    If ("/common/v3/images/vietnamnet.gif".Equals(strImg)) Then
        '        'Remove other images except the first image
        '        intStop = strTmp.IndexOf(">", intStart + 5)

        '        Dim strLeft As String = ""
        '        Dim strRight As String = ""
        '        strLeft = strTmp.Substring(0, intIMGStart - 1)
        '        strRight = strTmp.Substring(intStop, strTmp.Length - intStop)
        '        strTmp = strLeft & strRight
        '    End If
        'End If

        'strContent = strContent.Replace(strTmp, "./" & strSource & "/" & objWebImage.imgNewFileName)

        'Old code


    End Function

    Private Function AnalyzeContent4Desc(ByVal strContent As String, ByVal strContentXpath As String, _
                                    ByRef objIMGs As Collection, ByVal strImgDownload As String) As String
        Dim strTmp As String = ""
        Dim strReturn As String
        Dim i As Integer
        strTmp = strContent.Replace("<IMG ", "<img ")

        Try
            Dim doc As HtmlAgilityPack.HtmlDocument = New HtmlAgilityPack.HtmlDocument()
            Dim htmlCollect As HtmlAgilityPack.HtmlNodeCollection
            doc.LoadHtml(strTmp)
            strReturn = ""
            htmlCollect = doc.DocumentNode.SelectNodes("/")
            If Not IsNothing(htmlCollect) Then
                For Each objimgNote As HtmlAgilityPack.HtmlNode In htmlCollect
                    strReturn = objimgNote.InnerText.ToString
                Next

            End If
            If strReturn.Length > 0 And strReturn.IndexOf(".") >= 0 Then
                strReturn = strReturn.Substring(0, strReturn.IndexOf("."))
            End If
        Catch ex As Exception
            WriteLog(stLogPath, "AnalyzeContent4Desc::ERROR-->" + ex.ToString, "ERROR", _
                     DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"))
            strReturn = ""
        End Try
        Return strReturn
    End Function

    Private Function getAndsaveImgWeather(ByVal strURL As String, ByVal strNewFileName As String) As Boolean
        Dim picImage As New PictureBox
        Dim strTime As String = DateTime.Now.ToString("ddMMyyyy")
        strTime = strTime.Replace("/", "")
        strTime = strTime.Replace(":", "")
        strTime = strTime.Replace(" ", "")
        Dim _
            strFileName As String = MY_WEB_PATH & "\image\" & strImageDirectory & "\VNN_IIE_" & strTime & _
                                    getFileName(strURL, "/")
        If Not isFileExist(strFileName) Then
            Try
                objRequest = WebRequest.Create(strURL)
                objRequest.Timeout = REQUEST_TIMEOUT

                If boolProxy Then
                    objRequest.Proxy = myProxy
                End If
                objResponse = objRequest.GetResponse
                If objResponse.StatusCode = HttpStatusCode.OK Then
                    picImage.Image = New Bitmap(objResponse.GetResponseStream)
                Else
                    Return False
                End If
                isFolderExist(MY_WEB_PATH & "\image\" & strImageDirectory)
                picImage.Image.Save(strFileName)
                'picImage.Image.Save(MY_WEB_PATH & "\INTERNETIMAGES\" & strImageDirectory & "\" & strNewFileName)


                objResponse.Close()

            Catch ex As Exception
                Return False
            End Try
        End If
        picImage = Nothing
        Return True
    End Function

    Private Function getAndsaveImg(ByVal strURL As String, ByVal strNewFileName As String) As Boolean
        Dim picImage As New PictureBox
        Dim strTime As String = DateTime.Now.ToString("ddMMyyyy")
        strTime = strTime.Replace("/", "")
        strTime = strTime.Replace(":", "")
        strTime = strTime.Replace(" ", "")
        'Dim strFileName As String = MY_WEB_PATH & "\INTERNETIMAGES\" & strImageDirectory & "\VNN_IIE_" & strTime & getFileName(strNewFileName, "\")
        Dim _
            strFileName As String = MY_WEB_PATH & "\INTERNETIMAGES\" & strImageDirectory & "\" & _
                                    getFileName(strNewFileName, "\")
        If Not isFileExist(strFileName) Then
            Try
                objRequest = WebRequest.Create(strURL)
                objRequest.Timeout = REQUEST_TIMEOUT

                If boolProxy Then
                    objRequest.Proxy = myProxy
                End If
                objResponse = objRequest.GetResponse
                If objResponse.StatusCode = HttpStatusCode.OK Then
                    picImage.Image = New Bitmap(objResponse.GetResponseStream)
                Else
                    Return False
                End If
                isFolderExist(MY_WEB_PATH & "\INTERNETIMAGES\" & strImageDirectory)
                picImage.Image.Save(strFileName)

                'picImage.Image.Save(MY_WEB_PATH & "\INTERNETIMAGES\" & strImageDirectory & "\" & strNewFileName)
                objResponse.Close()
                WriteLog(stLogPath, "getAndsaveImg is sucessfull with url-->" + strURL, "INFOR", _
                         DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"))
            Catch ex As Exception
                WriteLog(stLogPath, "getAndsaveImg was failed with url-->" + strURL, "ERROR", _
                         DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"))
                Return False
            End Try
        End If
        'Send the image to FTP server if need
        SendImgs2FtpServer(strFileName, "", "", "")

        picImage = Nothing
        Return True
    End Function

    Private Function getAndsaveImgStock(ByVal strURL As String, ByVal strNewFileName As String) As Boolean
        Dim picImage As New PictureBox
        Dim strTime As String = DateTime.Now.ToString("ddMMyyyy")
        strTime = strTime.Replace("/", "")
        strTime = strTime.Replace(":", "")
        strTime = strTime.Replace(" ", "")
        Dim _
            strFileName As String = MY_WEB_PATH & "\INTERNETIMAGES\" & strImageDirectory & "\VNN_IIE_" & strTime & _
                                    strNewFileName
        If isFileExist(strFileName) Then
            DeleFileExist(strFileName)
        End If
        Try

            Dim downloadedData(0) As Byte
            Dim buffer(1024) As Byte

            objRequest = WebRequest.Create(strURL)
            objRequest.AllowWriteStreamBuffering = True
            objRequest.Timeout = REQUEST_TIMEOUT
            If boolProxy Then
                objRequest.Proxy = myProxy
            End If
            objResponse = objRequest.GetResponse

            Dim stream As Stream = objResponse.GetResponseStream
            Dim dataLength As Integer = CType(objResponse.ContentLength, Integer)
            Dim memStream As MemoryStream = New MemoryStream()
            '//Try to read the data
            Dim bytesRead As Integer = stream.Read(buffer, 0, buffer.Length)
            '//Write the downloaded data
            memStream.Write(buffer, 0, bytesRead)
            '//Convert the downloaded stream to a byte array
            downloadedData = memStream.ToArray()
            '//Clean up
            stream.Close()
            memStream.Close()

            '//Write the bytes to a file
            Dim newFile As FileStream = New FileStream(strFileName, FileMode.Create)
            newFile.Write(downloadedData, 0, downloadedData.Length)
            newFile.Close()

            'If objResponse.StatusCode = HttpStatusCode.OK Then
            '    'picImage.Image = New Bitmap(objResponse.GetResponseStream)
            'Else
            '    Return False
            'End If
            'isFolderExist(MY_WEB_PATH & "\INTERNETIMAGES\" & strImageDirectory)
            'picImage.Image.Save(strFileName)
            objResponse.Close()

        Catch ex As Exception
            Return False
        End Try
        picImage = Nothing
        Return True
    End Function

    Private Sub UpdateNews(ByRef RssEntry As RssEntry)
        Dim objNews As New NewsInfor
        For i As Integer = webCols.Count To 1 Step -1
            Try
                objNews._Title = removeHTMLTags(RssEntry.Title)
                'removeHTMLTags(CType(webCols(i), WebContentInfor).Title)
                objNews._Description = removeHTMLTags(RssEntry.Description)
                'removeHTMLTags(CType(webCols(i), WebContentInfor).Description)
                objNews._Content = CType(webCols(i), WebContentInfor).Content
                objNews._Source = CType(webCols(i), WebContentInfor).Source
                objNews._CategoryID = CType(webCols(i), WebContentInfor).CategoryID
                objNews._Href = CType(webCols(i), WebContentInfor).Href
                objNews._Image = CType(webCols(i), WebContentInfor).Image
                If _
                    CType(webCols(i), WebContentInfor).ImgDownloadFlag AndAlso objNews._Content.Trim <> "" AndAlso _
                    (Not NewsController.isExisted(objConn, objNews._Href)) Then
                    NewsController.InsertNew(objConn, objNews, stLogPath)
                End If
            Catch ex As Exception
                Exit For
            End Try
        Next
        objNews = Nothing
        For i As Integer = webCols.Count To 1 Step -1
            webCols.Remove(i)
        Next
    End Sub

    Private Sub UpdateNews()
        Dim objNews As New NewsInfor
        Dim objCate As New Data.CategoryInfor
        For i As Integer = webCols.Count To 1 Step -1
            Try
                objNews._ID = 0
                objNews._Title = removeHTMLTags(CType(webCols(i), WebContentInfor).Title)
                objNews._Description = removeHTMLTags(CType(webCols(i), WebContentInfor).Description)
                objNews._Content = CType(webCols(i), WebContentInfor).Content
                objNews._Source = CType(webCols(i), WebContentInfor).Source
                objNews._CategoryID = CType(webCols(i), WebContentInfor).CategoryID
                objNews._Href = CType(webCols(i), WebContentInfor).Href
                objNews._Image = CType(webCols(i), WebContentInfor).Image
                If _
                    (objNews._Content.Trim <> "") AndAlso _
                    (Not NewsController.isExisted(objNews._Href, objNews._CategoryID)) Then
                    objNews._ID = NewsController.InsertNew(objNews, stLogPath)
                    If (objNews._ID > 0) Then
                        objCate = Data.CategoryController.selectCategory(objNews._CategoryID)
                        NewsController.InsertArticleCate(objNews, objCate, stLogPath)
                    End If
                End If
            Catch ex As Exception
                WriteLog(stLogPath, ex.ToString, "UpdateNews::ERROR", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"))
                'Exit For
            End Try
        Next
        objNews = Nothing
        For i As Integer = webCols.Count To 1 Step -1
            webCols.Remove(i)
        Next
    End Sub

    'Connect to URL and get content of the main page
    Public Function gettingTestSource(ByVal strURL As String) As String
        Dim strContent As New StringBuilder
        Call initMyProxy()
        Try
            objRequest = WebRequest.Create(strURL)
            objRequest.Timeout = REQUEST_TIMEOUT

            If boolProxy Then
                objRequest.Proxy = myProxy
            End If

            objResponse = objRequest.GetResponse

            If objResponse.StatusCode = HttpStatusCode.OK Then
                Dim encode As Encoding = System.Text.Encoding.GetEncoding("utf-8")
                Dim readStream As New StreamReader(objResponse.GetResponseStream, encode)
                strContent.Append(readStream.ReadToEnd)
                objResponse.Close()
                Return strContent.ToString
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function doManualExtract(ByVal strURL As String) As Collection
        Dim objDs As New DataSet
        Dim strContent As String
        Dim imgDownloadFlag As Boolean = False
        Call initMyProxy()
        Try
            If Data.SourceController.isNewsSource(objConn, strURL) Then
                'Read the source information from database
                Call getSourceInfor(strURL)
                'Getting Source content
                If gettingSource(strURL, strStartTags) Then
                    If getNewsItem(strSourceContent) Then
                        If getNewsContent(strServiceName) Then
                            Return webCols
                        End If
                    End If
                End If
            Else
                Dim objWebContentInforTmp As New WebContentInfor
                'Read the source information from database
                Call getSourceInfor(strURL)
                'Getting Source content
                If gettingSource(strURL, strStartTags) Then
                    objWebContentInforTmp.Content = _
                        splitContent(strSourceContent, strContentStartTags, strContentEndTags)
                    If objWebContentInforTmp.Content <> "" Then
                        webCols.Add(objWebContentInforTmp)
                    End If
                End If
                Return webCols
            End If
        Catch ex As Exception
            Exit Function
        End Try
    End Function

    Public Sub doAutoNotNewsExtract()
        Dim html As VNN_WEBEXTRACTOR.Html2Xml = New VNN_WEBEXTRACTOR.Html2Xml
        Dim htmlFile As New VNN_WEBEXTRACTOR.textFileOperator
        Dim objDs As New DataSet
        objDs = Nothing
        'Dim strContent As String
        Dim imgDownloadFlag As Boolean = True

        Try
            Call initMyProxy()
            objDs = Data.SourceController.selectSourcesByNewsFlag(objConn, 0, stLogPath)

            strWeatherHTML = New StringBuilder()
            strGoldHTML = New StringBuilder()
            strCkHTML = New StringBuilder()

            strWeatherHTML.Append( _
                                  Me.GetFileContents( _
                                                     System.Configuration.ConfigurationManager.AppSettings( _
                                                                                                           "WeatherTemplateHtml")))
            strGoldHTML.Append( _
                               Me.GetFileContents( _
                                                  System.Configuration.ConfigurationManager.AppSettings( _
                                                                                                        "ExRateTemplateHtml")))
            strCkHTML.Append( _
                             Me.GetFileContents( _
                                                System.Configuration.ConfigurationManager.AppSettings( _
                                                                                                      "CkTemplateHtml")))
            For i As Integer = 0 To objDs.Tables(0).Rows.Count - 1
                'Read the source information from database
                Call getSourceInfor(objDs.Tables(0).Rows(i).Item("Href"))
                'Neu ko phai la link lay ty gia ngoai te
                If Not strServiceName.Equals("EXRATE") Then
                    'Getting Source content
                    If gettingSource(objDs.Tables(0).Rows(i).Item("Href"), strStartTags) Then
                        ' Analyze content and Update to Database
                        Dim objNewsInfor As New NewsInfor
                        objNewsInfor._Content = _
                            splitContent(strSourceContent, strContentStartTags, strContentEndTags)
                        objNewsInfor._Content = objNewsInfor._Content.Replace("""", "'")
                        If Not strServiceName.StartsWith("GOLD") Then
                            Select Case strServiceName
                                Case "STOCK" 'Stock
                                    'htmlFile.file_write(MY_WEB_PATH & "\HTML\Stock.html", objNewsInfor._Content)
                                    'html.SaveHtml2Xml(MY_WEB_PATH & "\HTML\Stock.html", MY_WEB_PATH & "\HTML\Stock.xml")
                                    'InsertStock(MY_WEB_PATH & "\HTML\Stock.xml", strServiceName, strHref)
                                Case "WEATHER" 'WEATHER
                                    'Get Image and Save to Disk
                                    Dim objIMGs As New Collection
                                    getIMGs4Weather(objIMGs, objNewsInfor._Content, strImageDirectory, MY_WEB_PATH)

                                    For j As Integer = 1 To objIMGs.Count
                                        Dim strImagePath As String
                                        strImagePath = _
                                            VNN_WEBEXTRACTOR.Data.SourceController.getImagePath(objConn, strHref). _
                                                Trim
                                        If strImagePath = "VNN" Then
                                            strImagePath = CType(webCols.Item(j), WebContentInfor).Href
                                        End If

                                        'imgDownloadFlag = getAndsaveImg(strImagePath & CType(objIMGs.Item(j), VNN_WEBEXTRACTOR.WebImage).OriginalPath, CType(objIMGs.Item(j), VNN_WEBEXTRACTOR.WebImage).imgNewFileName)
                                        imgDownloadFlag = _
                                            getAndsaveImgWeather( _
                                                                 CType(objIMGs.Item(j), VNN_WEBEXTRACTOR.WebImage) _
                                                                    .OriginalPath, _
                                                                 CType(objIMGs.Item(j), VNN_WEBEXTRACTOR.WebImage) _
                                                                    .imgNewFileName)
                                        'If imgDownloadFlag Then
                                        'SendImgs2FtpServer(MY_WEB_PATH & CType(objIMGs.Item(j), VNN_WEBEXTRACTOR.WebImage).imgNewFileName.Replace("/", "\"), "", "", "/image/weather")
                                        'End If

                                        If Not imgDownloadFlag Then
                                            Exit For
                                        End If
                                    Next

                                    htmlFile.file_write(MY_WEB_PATH & "\HTML\Weather.html", objNewsInfor._Content)
                                    html.SaveHtml2Xml(MY_WEB_PATH & "\HTML\Weather.html", _
                                                      MY_WEB_PATH & "\HTML\Weather.xml")
                                    InsertWeather(MY_WEB_PATH & "\HTML\Weather.xml", strServiceName, objIMGs, _
                                                  strImageDirectory)
                                    '-----------------------------

                                    For k As Integer = objIMGs.Count To 1 Step -1
                                        objIMGs.Remove(k)
                                    Next
                            End Select
                        Else
                            htmlFile.file_write(MY_WEB_PATH & "\HTML\GoldPrice.html", objNewsInfor._Content)
                            html.SaveHtml2Xml(MY_WEB_PATH & "\HTML\GoldPrice.html", _
                                              MY_WEB_PATH & "\HTML\GoldPrice.xml")
                            InsertGoldPrice(MY_WEB_PATH & "\HTML\GoldPrice.xml", strServiceName)

                        End If
                    End If
                Else
                    Select Case strServiceName
                        Case "EXRATE"
                            Call InsertExRate(objDs.Tables(0).Rows(i).Item("Href"))
                    End Select
                End If

            Next
            If Not Me.strGoldContent.Equals("") Then
                InsertGoldPriceGW()
            End If
            If Not Me.strExRateContent.Equals("") Then
                InsertExtRateGW()
            End If
            If Not Me.VNN_GOLD_DETAIL.Equals("") Then
                Dim strTmp As String = Me.strGoldHTML.ToString()
                strTmp = _
                    strTmp.Replace("VNN_GOLD_DETAIL", Me.VNN_GOLD_DETAIL).Replace("VNN_GOLD_DATE", _
                                                                                  Me.VNN_GOLD_DATE)
                strTmp = _
                    strTmp.Replace("VNN_EXRATE_DETAIL", Me.VNN_EXRATE_DETAIL).Replace("VNN_EXRATE_DATE", _
                                                                                      Me.VNN_EXRATE_DATE)
                htmlFile.file_write(System.Configuration.ConfigurationManager.AppSettings("ExRateHtmlPath"), _
                                    strTmp)
                SendImgs2FtpServer(System.Configuration.ConfigurationManager.AppSettings("ExRateHtmlPath"), "", "", _
                                   "")
                'Me.strGoldHTML.Replace("VNN_GOLD_DETAIL", Me.VNN_GOLD_DETAIL).Replace("VNN_GOLD_DATE", Me.VNN_GOLD_DATE)
                'Me.strGoldHTML.Replace("VNN_EXRATE_DETAIL", Me.VNN_EXRATE_DETAIL).Replace("VNN_EXRATE_DATE", Me.VNN_EXRATE_DATE)
                'Else
                '    htmlFile.file_write(System.Configuration.ConfigurationManager.AppSettings("ExRateHtmlPath"), "<div id='tygia'></div>")
            Else
                WriteLog(stLogPath, "Can not get Gold Data", "WARN", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"))
            End If
            If Not Me.VNN_WEATHER_DETAIL.Equals("") Then
                htmlFile.file_write(System.Configuration.ConfigurationManager.AppSettings("WeatherHtmlPath"), _
                                    Me.strWeatherHTML.ToString().Replace("VNN_WEATHER_DETAIL", _
                                                                         Me.VNN_WEATHER_DETAIL).Replace( _
                                                                                                        "VNN_WEATHER_DATE", _
                                                                                                        Me. _
                                                                                                           VNN_WEATHER_DATE))
                'Me.strWeatherHTML.Replace("VNN_WEATHER_DETAIL", Me.VNN_WEATHER_DETAIL).Replace("VNN_WEATHER_DATE", Me.VNN_WEATHER_DATE)
            End If


        Catch ex As Exception
            WriteLog(stLogPath, ex.ToString(), "ERROR", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"))
            Exit Sub
        End Try
    End Sub

    Sub SendImgs2FtpServer(ByVal imgPath As String, ByVal strImageDirectory As String, ByVal strSource As String, _
                           Optional ByVal ftpRemoteDir As String = "")
        'Dim fNew As FtpClient.clsFtp
        'Dim callback As AsyncCallback = New AsyncCallback(CloseConnection()
        Dim currentmonth As String = DateTime.Now.ToString("yyyy-MM")

        Try
            Dim FtpServer As String = System.Configuration.ConfigurationManager.AppSettings("FtpServer")
            If Not ("".Equals(FtpServer.Trim)) Then
                Dim FtpUserName As String = System.Configuration.ConfigurationManager.AppSettings("FtpUserName")
                Dim FtpPassword As String = System.Configuration.ConfigurationManager.AppSettings("FtpPassword")
                WriteLog(stLogPath, "Start send file to ftp server " + FtpServer, "INFOR", _
                         DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"))
                Dim myFtp As New FTP.FTPclient(FtpServer, FtpUserName, FtpPassword)
                'fNew = New FtpClient.clsFtp(FtpServer, FtpUserName, FtpPassword)
                'fNew.Login()


                ' Check FTP Folder exist
                'Dim chkFolder As Boolean = fNew.isDirExist(currentmonth)
                'If Not chkFolder Then
                '    fNew.MakeDir(currentmonth)
                'End If
                If ftpRemoteDir <> "" Then
                    myFtp.CurrentDirectory = ftpRemoteDir
                    'fNew.ChangeDir(ftpRemoteDir)
                End If

                'Dim strCurrDir As String = myFtp.GetDirectory("/" + currentmonth)
                'If (strCurrDir.Equals("") Or (strCurrDir Is Nothing)) Then
                '    myFtp.FtpCreateDirectory(strCurrDir)
                'End If
                Try
                    myFtp.FtpCreateDirectory(currentmonth)
                Catch ex As Exception

                End Try
                myFtp.CurrentDirectory = "/" + currentmonth
                'will upload to file ...
                WriteLog(stLogPath, imgPath, "SendImgs2FtpServer:imgPath-->", _
                         DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"))
                Dim pos As Integer = imgPath.LastIndexOf("\")
                Dim remotFileName As String = imgPath.Substring(pos + 1)
                WriteLog(stLogPath, remotFileName, "remotFileName-->", _
                         DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"))
                myFtp.Upload(imgPath, remotFileName)
                'fNew.Upload(imgPath)
                WriteLog(stLogPath, _
                         "Finished send file@FileName = " + remotFileName + "@ to ftp server " + FtpServer, "INFOR", _
                         DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"))
            End If
        Catch ex As Exception
            WriteLog(stLogPath, ex.ToString(), "SendImgs2FtpServer:ERROR", _
                     DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"))
        Finally
            If (Not IsNothing(ftp)) Then
                ftp = Nothing
            End If
            'ftp = Nothing
        End Try
    End Sub

    Sub SendOilScript2FtpServer(ByVal imgPath As String, ByVal strImageDirectory As String, ByVal strSource As String, _
                           Optional ByVal ftpRemoteDir As String = "")
        'Dim fNew As FtpClient.clsFtp
        'Dim callback As AsyncCallback = New AsyncCallback(CloseConnection()
        Dim currentmonth As String = DateTime.Now.ToString("yyyy-MM")

        Try
            Dim FtpServer As String = System.Configuration.ConfigurationManager.AppSettings("OilFtpServer")
            If Not ("".Equals(FtpServer.Trim)) Then
                Dim FtpUserName As String = System.Configuration.ConfigurationManager.AppSettings("OilFtpUserName")
                Dim FtpPassword As String = System.Configuration.ConfigurationManager.AppSettings("OilFtpPassword")
                WriteLog(stLogPath, "Start send file to oil ftp server " + FtpServer, "INFOR", _
                         DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"))
                Dim myFtp As New FTP.FTPclient(FtpServer, FtpUserName, FtpPassword)
                'fNew = New FtpClient.clsFtp(FtpServer, FtpUserName, FtpPassword)
                'fNew.Login()


                ' Check FTP Folder exist
                'Dim chkFolder As Boolean = fNew.isDirExist(currentmonth)
                'If Not chkFolder Then
                '    fNew.MakeDir(currentmonth)
                'End If
                If ftpRemoteDir <> "" Then
                    myFtp.CurrentDirectory = ftpRemoteDir

                    'fNew.ChangeDir(ftpRemoteDir)
                End If

                'Dim strCurrDir As String = myFtp.GetDirectory("/" + currentmonth)
                'If (strCurrDir.Equals("") Or (strCurrDir Is Nothing)) Then
                '    myFtp.FtpCreateDirectory(strCurrDir)
                'End If
                'Try
                '    myFtp.FtpCreateDirectory(currentmonth)
                'Catch ex As Exception

                'End Try
                'myFtp.CurrentDirectory = "/" + currentmonth
                'will upload to file ...
                WriteLog(stLogPath, imgPath, "SendOilScript2FtpServer:imgPath-->", _
                         DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"))
                Dim pos As Integer = imgPath.LastIndexOf("\")
                Dim remotFileName As String = imgPath.Substring(pos + 1)
                WriteLog(stLogPath, remotFileName, "remotFileName-->", _
                         DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"))
                If (myFtp.FtpFileExists(remotFileName)) Then
                    myFtp.FtpDelete(remotFileName)
                End If
                myFtp.Upload(imgPath, remotFileName)
                'fNew.Upload(imgPath)
                WriteLog(stLogPath, _
                         "Finished send file@FileName = " + remotFileName + "@ to oil ftp server " + FtpServer, "INFOR", _
                         DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"))
            End If
        Catch ex As Exception
            WriteLog(stLogPath, ex.ToString(), "SendOilScript2FtpServer:ERROR", _
                     DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"))
        Finally
            If (Not IsNothing(ftp)) Then
                ftp = Nothing
            End If
            'ftp = Nothing
        End Try
    End Sub

    Sub InsertStock(ByVal xmlFile As String, ByVal strServiceName As String, ByVal rootUrl As String)
        Dim objStockInfor As New Data.StockInfor
        Dim doc As XmlDocument = New XmlDocument()
        Dim nodes As XmlNodeList
        Try
            Dim strVnIndexCharImg As String = "//*[@id='ctl00_PageContent_WebChartViewer1']"
            '"//img/@src"
            Dim strVnIndex As String = "//*[@id='ctl00_PageContent_LatestVNIValue']"
            Dim strVnIndexImg As String = "//*[@id='ctl00_PageContent_arrowHO']"
            Dim strVnIndexChangeValue As String = "//*[@id='ctl00_PageContent_LatestVNIChange']"
            Dim strVnIndexPercentChangeValue As String = "//*[@id='ctl00_PageContent_LatestVNIPercentChange']"
            Dim strHaIndexCharImg As String = "//[@id='ctl00_PageContent_WebChartViewer2']"
            Dim strHaIndex As String = "//*[@id='ctl00_PageContent_arrowHA']"
            Dim strHaIndexImg As String = "//*[@id='ctl00_PageContent_LatestHASTCIndexValue']"
            Dim strHaIndexChangeValue As String = "//*[@id='ctl00_PageContent_LatestHASTCIndexChange']"
            Dim _
                strHaIndexPercentChangeValue As String = _
                    "//*[@id='ctl00_PageContent_LatestHASTCIndexPercentChange']"

            Dim isGetImg As Boolean = False
            Dim strOutnerXml As String
            Dim imgSrc As String
            Dim objIMGs As New Collection
            Dim OriginalPath As String
            doc.Load(xmlFile)
            'Lay anh bieu do VnIndex
            nodes = doc.SelectNodes(strVnIndexCharImg)

            For Each node As XmlNode In nodes
                strOutnerXml = node.OuterXml.ToString().Replace("""", "'")
                'Get Image and Save to Disk
                'http://vcbs.com.vn/Default.aspx?ChartDirectorChartImage=chart_ctl00$PageContent$WebChartViewer1&amp;cacheId=4b985dddb0ab4f43a949a60332c969ce"

                getIMGs4Weather(objIMGs, strOutnerXml, strImageDirectory, MY_WEB_PATH)
                'imgSrc = strOutnerXml.Substring(strOutnerXml.IndexOf(""))
                OriginalPath = rootUrl & CType(objIMGs.Item(1), VNN_WEBEXTRACTOR.WebImage).OriginalPath
                OriginalPath = OriginalPath.Substring(0, OriginalPath.IndexOf("&amp;cacheId"))
                isGetImg = getAndsaveImgStock(OriginalPath, "HoChart.gif")
                'If isGetImg Then
                objStockInfor._VnIndexChartImg = OriginalPath
                'Else
                'objStockInfor._VnIndexChartImg = ""
                'End If

                'Console.WriteLine(node.InnerText)
            Next
            'Lay VnIndex
            nodes = doc.SelectNodes(strVnIndex)
            For Each node As XmlNode In nodes
                If _
                    Not (node.InnerText.ToString().Trim.Equals("")) And Not (node Is Nothing) And _
                    Not node.InnerText.ToString().Trim.Equals("&nbsp;") Then
                    objStockInfor._VnIndex = _
                        node.InnerText.ToString().Replace("&nbsp;", "").Replace(",", ".").Trim
                Else
                    objStockInfor._VnIndex = ""
                End If
            Next
            'Lay anh bieu thi tang giam VnIndex
            nodes = doc.SelectNodes(strVnIndexImg)
            isGetImg = False
            For Each node As XmlNode In nodes
                strOutnerXml = node.OuterXml.ToString().Replace("""", "'")
                'Get Image and Save to Disk
                getIMGs4Weather(objIMGs, strOutnerXml, strImageDirectory, MY_WEB_PATH)
                OriginalPath = rootUrl & CType(objIMGs.Item(1), VNN_WEBEXTRACTOR.WebImage).OriginalPath
                isGetImg = getAndsaveImg(OriginalPath, "")
                If isGetImg Then
                    objStockInfor._VnIndexImg = CType(objIMGs.Item(1), VNN_WEBEXTRACTOR.WebImage).imgNewFileName
                Else
                    objStockInfor._VnIndexImg = ""
                End If

                'Console.WriteLine(node.InnerText)
            Next
            'Lay gia tri tang giam VnIndex
            nodes = doc.SelectNodes(strVnIndexChangeValue)
            For Each node As XmlNode In nodes
                If _
                    Not (node.InnerText.ToString().Trim.Equals("")) And Not (node Is Nothing) And _
                    Not node.InnerText.ToString().Trim.Equals("&nbsp;") Then
                    objStockInfor._VnIndexChangeValue = _
                        node.InnerText.ToString().Replace("&nbsp;", "").Replace(",", ".").Trim
                Else
                    objStockInfor._VnIndexChangeValue = ""
                End If

                'Console.WriteLine(node.InnerText)
            Next

            'Lay % tang giam VnIndex
            nodes = doc.SelectNodes(strVnIndexPercentChangeValue)
            For Each node As XmlNode In nodes
                If _
                    Not (node.InnerText.ToString().Trim.Equals("")) And Not (node Is Nothing) And _
                    Not node.InnerText.ToString().Trim.Equals("&nbsp;") Then
                    objStockInfor._VnIndexPercentChangeValue = _
                        node.InnerText.ToString().Replace("&nbsp;", "").Replace(",", ".").Trim & "%"
                Else
                    objStockInfor._VnIndexPercentChangeValue = ""
                End If

                'Console.WriteLine(node.InnerText)
            Next


            '---------------------Start HA-----------------------

            'Lay anh bieu do HaIndex
            nodes = doc.SelectNodes(strHaIndexCharImg)
            isGetImg = False
            For Each node As XmlNode In nodes
                strOutnerXml = node.OuterXml.ToString().Replace("""", "'")
                'Get Image and Save to Disk
                'http://vcbs.com.vn/Default.aspx?ChartDirectorChartImage=chart_ctl00$PageContent$WebChartViewer1&amp;cacheId=4b985dddb0ab4f43a949a60332c969ce"

                getIMGs4Weather(objIMGs, strOutnerXml, strImageDirectory, MY_WEB_PATH)
                'imgSrc = strOutnerXml.Substring(strOutnerXml.IndexOf(""))
                OriginalPath = rootUrl & CType(objIMGs.Item(1), VNN_WEBEXTRACTOR.WebImage).OriginalPath
                OriginalPath = OriginalPath.Substring(0, OriginalPath.IndexOf("&amp;cacheId"))
                'isGetImg = getAndsaveImgStock(OriginalPath, "HoChart.gif")
                'If isGetImg Then
                objStockInfor._HaIndexChartImg = OriginalPath
                'Console.WriteLine(node.InnerText)
            Next
            'Lay HaIndex
            nodes = doc.SelectNodes(strHaIndex)
            For Each node As XmlNode In nodes
                If _
                    Not (node.InnerText.ToString().Trim.Equals("")) And Not (node Is Nothing) And _
                    Not node.InnerText.ToString().Trim.Equals("&nbsp;") Then
                    objStockInfor._HaIndex = _
                        node.InnerText.ToString().Replace("&nbsp;", "").Replace(",", ".").Trim
                Else
                    objStockInfor._HaIndex = ""
                End If

                'Console.WriteLine(node.InnerText)
            Next
            'Lay anh bieu thi tang giam HaIndex
            nodes = doc.SelectNodes(strHaIndexImg)
            isGetImg = False
            For Each node As XmlNode In nodes
                strOutnerXml = node.OuterXml.ToString().Replace("""", "'")
                'Get Image and Save to Disk
                getIMGs4Weather(objIMGs, strOutnerXml, strImageDirectory, MY_WEB_PATH)
                OriginalPath = rootUrl & CType(objIMGs.Item(1), VNN_WEBEXTRACTOR.WebImage).OriginalPath
                isGetImg = getAndsaveImg(OriginalPath, "")
                If isGetImg Then
                    objStockInfor._HaIndexImg = CType(objIMGs.Item(1), VNN_WEBEXTRACTOR.WebImage).imgNewFileName
                Else
                    objStockInfor._HaIndexImg = ""
                End If

                'Console.WriteLine(node.InnerText)
            Next
            'Lay gia tri tang giam HaIndex
            nodes = doc.SelectNodes(strHaIndexChangeValue)
            For Each node As XmlNode In nodes
                If _
                    Not (node.InnerText.ToString().Trim.Equals("")) And Not (node Is Nothing) And _
                    Not node.InnerText.ToString().Trim.Equals("&nbsp;") Then
                    objStockInfor._HaIndexChangeValue = _
                        node.InnerText.ToString().Replace("&nbsp;", "").Replace(",", ".").Trim
                Else
                    objStockInfor._HaIndexChangeValue = ""
                End If

                'Console.WriteLine(node.InnerText)
            Next
            'Lay % tang giam HaIndex
            nodes = doc.SelectNodes(strHaIndexPercentChangeValue)
            For Each node As XmlNode In nodes
                If _
                    Not (node.InnerText.ToString().Trim.Equals("")) And Not (node Is Nothing) And _
                    Not node.InnerText.ToString().Trim.Equals("&nbsp;") Then
                    objStockInfor._HaIndexPercentChangeValue = _
                        node.InnerText.ToString().Replace("&nbsp;", "").Replace(",", ".").Trim & "%"
                Else
                    objStockInfor._HaIndexPercentChangeValue = ""
                End If

                'Console.WriteLine(node.InnerText)
            Next
            '---------------------End HA-----------------------
            Dim StockDate As Date = DateTime.Now
            If objStockInfor._HaIndex.Equals("") And objStockInfor._VnIndex.Equals("") Then
                objStockInfor._StockDate = StockDate
                Data.StockController.DeleteStock(objConn, StockDate)
                Data.StockController.InsertStock(objConn, objStockInfor)
            End If
        Catch ex As Exception
            WriteLog(stLogPath, ex.ToString(), "InsertStock:ERROR", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"))
        End Try
    End Sub

    Sub InsertGoldPrice(ByVal xmlFile As String, ByVal strServiceName As String)
        Dim objGoldInfor As New Data.GoldInfor
        Dim doc As XmlDocument = New XmlDocument()
        Dim strGoldSource As String = ""
        Try
            doc.Load(xmlFile)
            Dim strGoldXPath As String = ""
            'dsWeather.ReadXml(xmlFile)
            If (strServiceName.Equals("GOLD_EX")) Then
                strGoldXPath = _
                    IIf(System.Configuration.ConfigurationManager.AppSettings("GoldXPathEXIM").Equals("") _
                        Or System.Configuration.ConfigurationManager.AppSettings("GoldXPathEXIM") Is Nothing, _
                        "//span//td", _
                        System.Configuration.ConfigurationManager.AppSettings("GoldXPathEXIM"))
                strGoldSource = "EXIMBANK"
            End If
            If (strServiceName.Equals("GOLD_SJC")) Then
                strGoldXPath = _
                    IIf(System.Configuration.ConfigurationManager.AppSettings("GoldXPathSJC").Equals("") _
                        Or System.Configuration.ConfigurationManager.AppSettings("GoldXPathSJC") Is Nothing, _
                        "//span//div//table//tr//td", _
                        System.Configuration.ConfigurationManager.AppSettings("GoldXPathSJC"))

                strGoldSource = "SJC"
            End If
            Dim nodes As XmlNodeList

            Dim i As Integer = 0
            Dim GoldDate As Date = DateTime.Now

            If (strServiceName.Equals("GOLD_SJC")) Then
                nodes = doc.SelectNodes(strGoldXPath)
                If nodes.Count > 0 Then
                    Data.GoldController.DeleteGoldPrice(objConn, GoldDate, strGoldSource.ToUpper.Trim)
                End If
                If (Me.strGoldContent.Equals("")) Then
                    strGoldContent = "SJC: "
                Else
                    strGoldContent &= "\r\nSJC: "
                End If
                i = 0
                For Each node As XmlNode In nodes
                    If _
                        Not (node.InnerText.ToString().Trim.Equals("")) And Not (node Is Nothing) And _
                        Not node.InnerText.ToString().Trim.Equals("&nbsp;") Then
                        Console.WriteLine(node.InnerText)
                        i = i + 1
                        If i = 1 Then
                            objGoldInfor._GoldCode = "SJC"
                            'node.InnerText.ToString().Replace("&nbsp;", "").Trim
                        End If
                        If i = 2 Then
                            objGoldInfor._Buy = node.InnerText.ToString().Replace("&nbsp;", "").Trim
                            strGoldContent &= " Mua:" & objGoldInfor._Buy
                        End If
                        If i = 3 Then
                            objGoldInfor._Sell = node.InnerText.ToString().Replace("&nbsp;", "").Trim
                            strGoldContent &= " Ban:" & objGoldInfor._Sell
                        End If
                    End If

                Next
                objGoldInfor._GoldPriceDate = GoldDate
                Me.GenHTML(strServiceName, objGoldInfor)
            End If
            If (strServiceName.Equals("GOLD_EX")) Then
                Dim strGoldXPathCode As String = "//*[@id='GoldRateRepeater_ctl01_lblGold_Name']"
                Dim strGoldXPathBuy As String = "//*[@id='GoldRateRepeater_ctl01_lblCSHBUYRT']"
                Dim strGoldXPathSell As String = "//*[@id='GoldRateRepeater_ctl01_lblCSHSELLRT']"

                If (Me.strGoldContent.Equals("")) Then
                    strGoldContent = "EXIMBANK: "
                Else
                    strGoldContent &= "\r\nEXIMBANK: "
                End If
                'Lay ma vang
                nodes = doc.SelectNodes(strGoldXPathCode)
                For Each node As XmlNode In nodes
                    If _
                        Not (node.InnerText.ToString().Trim.Equals("")) And Not (node Is Nothing) And _
                        Not node.InnerText.ToString().Trim.Equals("&nbsp;") Then
                        objGoldInfor._GoldCode = _
                            node.InnerText.ToString().Replace("&nbsp;", "").Replace(",", ".").Trim
                    End If

                    'Console.WriteLine(node.InnerText)
                Next
                If nodes.Count > 0 Then
                    Data.GoldController.DeleteGoldPrice(objConn, GoldDate, strGoldSource.ToUpper.Trim)
                End If
                'Lay gia vang mua
                nodes = doc.SelectNodes(strGoldXPathBuy)
                For Each node As XmlNode In nodes
                    If _
                        Not (node.InnerText.ToString().Trim.Equals("")) And Not (node Is Nothing) And _
                        Not node.InnerText.ToString().Trim.Equals("&nbsp;") Then
                        objGoldInfor._Buy = node.InnerText.ToString().Replace("&nbsp;", "").Replace(",", ".").Trim
                        strGoldContent &= " Mua:" & objGoldInfor._Buy
                    End If
                    'Console.WriteLine(node.InnerText)

                Next
                'Lay gia vang ban
                nodes = doc.SelectNodes(strGoldXPathSell)
                For Each node As XmlNode In nodes
                    If _
                        Not (node.InnerText.ToString().Trim.Equals("")) And Not (node Is Nothing) And _
                        Not node.InnerText.ToString().Trim.Equals("&nbsp;") Then
                        objGoldInfor._Sell = _
                            node.InnerText.ToString().Replace("&nbsp;", "").Replace(",", ".").Trim
                        strGoldContent &= " Ban:" & objGoldInfor._Sell
                    End If
                    'Console.WriteLine(node.InnerText)

                Next
            End If
            If Not objGoldInfor._GoldCode.Equals("") And Not objGoldInfor._GoldCode Is Nothing Then
                objGoldInfor._GoldPriceDate = GoldDate
                objGoldInfor._GoldSource = strGoldSource
                Data.GoldController.InsertGoldPrice(objConn, objGoldInfor)
            End If
        Catch ex As Exception
            Util.WriteLog("Exactor.InserPrice.Error: " & ex.ToString)
        End Try
    End Sub

    Sub InsertExtRateGW()
        Try
            Data.ExRateController.DeleteExRateGw()
            Data.ExRateController.InsertExRateGw(Me.strExRateContent)

        Catch ex As Exception

        End Try
    End Sub

    Sub InsertGoldPriceGW()
        Try
            Data.GoldController.DeleteGoldPriceGw()
            Data.GoldController.InsertGoldPriceGw(Me.strGoldContent)

        Catch ex As Exception

        End Try
    End Sub

    Sub InsertWeather(ByVal xmlFile As String, ByVal ServiceName As String, ByVal objImgs As Collection, _
                      ByVal strImgSrc As String)
        'Dim dsWeather As DataSet = New DataSet
        Dim objWeatherInfor As New Data.WeatherInfor
        Dim doc As XmlDocument = New XmlDocument()
        Dim strCity As String
        Dim strTemperature As String
        Dim strTemp As String

        Try
            doc.Load(xmlFile)
            'dsWeather.ReadXml(xmlFile)
            Dim _
                strWeatherXPath As String = _
                    IIf( _
                        System.Configuration.ConfigurationManager.AppSettings("WeatherXPath").Equals("") Or _
                        System.Configuration.ConfigurationManager.AppSettings("WeatherXPath") Is Nothing, _
                        "//span//table//tr//td//table//tr", _
                        System.Configuration.ConfigurationManager.AppSettings("WeatherXPath"))
            Dim nodes As XmlNodeList = doc.SelectNodes(strWeatherXPath)
            Dim i As Integer = 0
            Dim WeatherDate As Date = DateTime.Now
            If nodes.Count > 0 Then
                Data.WeatherController.DeleteWeather(objConn, WeatherDate)
            End If
            For Each node As XmlNode In nodes
                If Not (node.InnerText.ToString().Trim.Equals("")) And Not (node Is Nothing) Then
                    i = i + 1
                    strTemp = node.InnerText.ToString().Trim
                    strTemperature = strTemp.Substring(strTemp.Length - 4)
                    strCity = strTemp.Substring(0, strTemp.Length - 4)
                    With objWeatherInfor
                        ._City = strCity
                        ._Temperature = strTemperature
                        ._ImageSrc = CType(objImgs.Item(i), VNN_WEBEXTRACTOR.WebImage).imgNewFileName
                        ._WeatherDate = WeatherDate
                    End With
                    Data.WeatherController.InsertWeather(objConn, objWeatherInfor)
                    Me.GenHTML(ServiceName, objWeatherInfor)
                    'Console.WriteLine(strCity + ":" + strTemperature + "-->" + "./INTERNETIMAGES/" & strImgSrc & "/" + CType(objImgs.Item(i), VNN_WEBEXTRACTOR.WebImage).imgNewFileName)
                End If

            Next
        Catch ex As Exception

        End Try

    End Sub

    Sub InsertExRate(ByVal xmlFile As String)
        Dim objWeatherInfor As New Data.WeatherInfor
        Dim doc As XmlDocument = New XmlDocument()
        Dim objExRateInfor As New Data.ExRateInfor

        Try
            Dim _
                strExRateNodes As String = _
                    IIf( _
                        System.Configuration.ConfigurationManager.AppSettings("ExRateNodes").Equals("") Or _
                        System.Configuration.ConfigurationManager.AppSettings("ExRateNodes") Is Nothing, _
                        "//ExrateList//Exrate", _
                        System.Configuration.ConfigurationManager.AppSettings("ExRateNodes"))
            doc.Load(xmlFile)
            'dsWeather.ReadXml(xmlFile)
            Dim nodes As XmlNodeList = doc.SelectNodes(strExRateNodes)
            Dim i As Integer = 0
            Dim ExRateDate As Date = DateTime.Now
            If nodes.Count > 0 Then
                Data.ExRateController.DeleteExRate(objConn, ExRateDate)
            End If
            Me.strExRateContent = ""
            For Each node As XmlNode In nodes
                With objExRateInfor
                    ._CurrencyCode = node.Attributes("CurrencyCode").InnerText
                    ._CurrencyName = node.Attributes("CurrencyName").InnerText
                    ._Buy = node.Attributes("Buy").InnerText
                    ._Sell = node.Attributes("Sell").InnerText
                    ._Transfer = node.Attributes("Transfer").InnerText
                    ._ExRateDate = ExRateDate

                    If _
                        (._CurrencyCode.ToUpper.Equals("EUR") Or ._CurrencyCode.ToUpper.Equals("USD") Or _
                         ._CurrencyCode.ToUpper.Equals("JPY") Or ._CurrencyCode.ToUpper.Equals("GBP")) Then
                        If Not strExRateContent.Equals("") Then
                            strExRateContent &= "-"
                        End If
                        strExRateContent &= ._CurrencyCode & ": Mua:" & ._Buy & " Ban:" & ._Sell
                    End If
                    Me.GenHTML(strServiceName, objExRateInfor)
                End With
                Data.ExRateController.InsertExRate(objConn, objExRateInfor)
            Next
        Catch ex As Exception
            Console.WriteLine("Insert Exchange Rate Error:" + ex.ToString)
        End Try
    End Sub

    Public Function GetFileContents(ByVal FullPath As String, _
                                    Optional ByRef ErrInfo As String = "") As String

        Dim strContents As String = ""
        Dim objReader As StreamReader
        Try

            objReader = New StreamReader(FullPath)
            strContents = objReader.ReadToEnd()
            objReader.Close()
            Return strContents
        Catch Ex As Exception
            ErrInfo = Ex.Message
        End Try
    End Function

    Public Function SaveTextToFile(ByVal strData As String, _
                                   ByVal FullPath As String, _
                                   Optional ByVal ErrInfo As String = "") As Boolean

        Dim Contents As String
        Dim bAns As Boolean = False
        Dim objReader As StreamWriter
        Dim objFile As File
        Try
            If (objFile.Exists(FullPath)) Then
                objFile.Delete(FullPath)
            End If
            objReader = New StreamWriter(FullPath)
            objReader.Write(strData)
            objReader.Close()
            bAns = True
        Catch Ex As Exception
            ErrInfo = Ex.Message

        End Try
        Return bAns
    End Function

    Function StringUtl(ByVal str As String) As String
        Try
            If IsNothing(str) Or str.Trim = "" Then
                Return ""
            End If
            Return str.Trim
        Catch ex As Exception
            Return ""
        End Try
    End Function


    Public Sub GenHTML(ByVal strServiceName As String, ByVal objService As Object)

        Try
            Select Case strServiceName
                Case "WEATHER" 'WEATHER
                    Dim objWeatherInfor As Data.WeatherInfor = CType(objService, Data.WeatherInfor)
                    Me.VNN_WEATHER_DETAIL &= _
                        "<table width='300px' cellpadding='0' cellspacing='0' class='thoitiet_des' >" & vbCrLf
                    Me.VNN_WEATHER_DETAIL &= "<tr>" & vbCrLf
                    Me.VNN_WEATHER_DETAIL &= "<td width='148' align='left' valign='middle' class='tt_thanhpho'>" & _
                                             StringUtl(objWeatherInfor._City) & "</td>" & vbCrLf
                    Me.VNN_WEATHER_DETAIL &= "<td width='150' align='left' valign='middle' class='tt_nhietdo'>" & _
                                             StringUtl(objWeatherInfor._Temperature) & _
                                             "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src='" & _
                                             objWeatherInfor._ImageSrc & _
                                             "' width='31' height='22' />												  										  </td>" & vbCrLf
                    'Me.VNN_WEATHER_DETAIL &= "<td width='150' align='left' valign='middle' class='tt_nhietdo'>" & StringUtl(objWeatherInfor._Temperature) & "<img src='image/thoitiet_c.gif' />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src='" & objWeatherInfor._ImageSrc & "' width='31' height='22' />												  										  </td>"
                    Me.VNN_WEATHER_DETAIL &= "</tr>"
                    Me.VNN_WEATHER_DETAIL &= "</table>" & vbCrLf
                    Me.VNN_WEATHER_DATE = objWeatherInfor._WeatherDate.ToString("dd/MM/yyyy hh:mm:ss:tt")
                Case "EXRATE" 'Ti gia ngoai te
                    Dim objExRateInfor As Data.ExRateInfor = CType(objService, Data.ExRateInfor)
                    Me.VNN_EXRATE_DETAIL &= "<tr>" & vbCrLf
                    Me.VNN_EXRATE_DETAIL &= "<td valign='top' align='center' class='gv_text'>" & _
                                            StringUtl(objExRateInfor._CurrencyCode) & "</td>" & vbCrLf
                    Me.VNN_EXRATE_DETAIL &= "<td valign='top' align='center' class='gv_text'>" & _
                                            StringUtl(objExRateInfor._Buy) & "</td>" & vbCrLf
                    Me.VNN_EXRATE_DETAIL &= "<td valign='top' align='center' class='gv_text'>" & _
                                            StringUtl(objExRateInfor._Transfer) & "</td>" & vbCrLf
                    Me.VNN_EXRATE_DETAIL &= "<td valign='top' align='center' class='gv_text'>" & _
                                            StringUtl(objExRateInfor._Sell) & "</td>" & vbCrLf
                    Me.VNN_EXRATE_DETAIL &= "</tr>" & vbCrLf
                    Me.VNN_EXRATE_DATE = objExRateInfor._ExRateDate.ToString("dd/MM/yyyy hh:mm:ss:tt")
                Case "GOLD_SJC" 'Or "GOLD_EX"  'Gia vang
                    Dim objGoldInfor As Data.GoldInfor = CType(objService, Data.GoldInfor)
                    Me.VNN_GOLD_DETAIL &= "<tr>" & vbCrLf
                    Me.VNN_GOLD_DETAIL &= "<td class='gv_text' align='center' valign='top'>" & _
                                          StringUtl(objGoldInfor._GoldCode) & " </td>" & vbCrLf
                    Me.VNN_GOLD_DETAIL &= "<td valign='top' align='center' class='gv_text'>" & _
                                          StringUtl(objGoldInfor._Buy) & " </td>" & vbCrLf
                    Me.VNN_GOLD_DETAIL &= "<td valign='top' align='center' class='gv_text'>" & _
                                          StringUtl(objGoldInfor._Sell) & " </td>" & vbCrLf
                    Me.VNN_GOLD_DETAIL &= "</tr>" & vbCrLf
                    Me.VNN_GOLD_DATE = objGoldInfor._GoldPriceDate.ToString("dd/MM/yyyy hh:mm:ss:tt")
                Case "STOCK" 'Chung Khoan
                    Dim objGoldInfor As Data.GoldInfor = CType(objService, Data.GoldInfor)
            End Select
        Catch ex As Exception

        End Try
    End Sub
End Class