Imports SubSonic
Imports System.IO
Imports VideoDAL
Imports VideoDAL.Objects
Imports System.Xml
Imports VideoController

Public Class Sync
    Dim strFtpServer1 As String
    Dim strUserName1 As String
    Dim strPassword1 As String

    Dim strFtpServer2 As String
    Dim strUserName2 As String
    Dim strPassword2 As String

    Dim strMediaDir As String
    Dim strVideoType As String
    Dim stFtpXml As String

    Dim ftp As FTP.FtpClient = Nothing

    Dim stLogPath As String
    Dim strDeleteStatus As String
    Dim strSendStatus As String
    Dim strDeleteResult As String

    '----------------------------------------------------------------------------------------------------
    'Muc dich: Ham khoi tao cac tham so duoc cau hinh trong file config va luu vao cac bien trong he thong
    'Nguoi tao: Duong Hai Phong
    'Ngay tao: 13/09/2010
    'Tham so dau vao: khong co
    'Ket qua tra ve: khong co
    '----------------------------------------------------------------------------------------------------
    Private Sub initMyProxy()
        Dim objReg As New MyRegistry
        objReg.getRegs()
        With objReg
            strFtpServer1 = .strFtpServer1
            strUserName1 = .strUserName1
            strPassword1 = .strPassword1

            strFtpServer2 = .strFtpServer2
            strUserName2 = .strUserName2
            strPassword2 = .strPassword2
            strMediaDir = .strMediaDir
            strVideoType = .strVideoType
            stLogPath = .stLogPath
            stFtpXml = .stFtpXml
            strSendStatus = .strSendStatus
            strDeleteStatus = .strDeleteStatus
            strDeleteResult = .strDeleteResult
        End With
        objReg = Nothing
    End Sub

    '----------------------------------------------------------------------------------------------------
    'Muc dich: Ham khoi dong dong bo du lieu video
    'Nguoi tao: Duong Hai Phong
    'Ngay tao: 13/09/2010
    'Tham so dau vao: khong co
    'Ket qua tra ve: khong co
    '----------------------------------------------------------------------------------------------------
    Public Sub SyncStart()
        Dim VideoCollects As ArticleMediumCollection = Nothing
        Dim strFile As String
        Dim ftpResult As Boolean
        Dim objArticleMedia As ArticleMedium = Nothing
        Dim FtpList As XmlNodeList
        Dim objFtp As objFtp = Nothing
        Dim Flag As String = ""
        Call initMyProxy()
        Try
            FtpList = Me.getFtpList()
            If (IsNothing(FtpList) Or FtpList.Count < 0) Then
                WriteLog(stLogPath, "FtpServer.xml does not exist or no data of FTP server", "getFtpList:Warning", _
                                                             DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"))
            Else
                VideoCollects = New VideoController.Sync().GetVideoSource(strSendStatus, "") 'Me.getVideoSource(strVideoType)
                If Not IsNothing(VideoCollects) Then
                    WriteLog(stLogPath, "Starting get video data from DB", "SyncStart:INFOR", _
                                                         DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"))
                    For Each ArticleMedia As ArticleMedium In VideoCollects
                        If String.IsNullOrEmpty(ArticleMedia.Flag) Then
                            Flag = ""
                        Else
                            Flag = ArticleMedia.Flag.ToString.Trim
                        End If
                        strFile = ArticleMedia.FileLink.ToString.Trim
                        If Not strFile.Equals("") And Not strFile.StartsWith("http") Then
                            For Each node As XmlNode In FtpList
                                objFtp = New objFtp()
                                With objFtp
                                    .FtpName = node("name").InnerText
                                    .User = node("user").InnerText
                                    .Pass = node("password").InnerText
                                End With
                                If isFileExist(Me.strMediaDir + strFile) Then
                                    ftpResult = Me.SendVideo2FtpServer(Me.strMediaDir, strFile, objFtp)
                                    'Neu gui ftp thanh cong thi update trong CSDL
                                    If ftpResult Then
                                        objArticleMedia = New ArticleMedium()
                                        objArticleMedia = ArticleMedia
                                        objArticleMedia.Flag = strSendStatus
                                        Me.UpateVideoAfterFTP(objArticleMedia)
                                    End If
                                End If
                            Next
                        End If
                        'End If

                    Next
                    WriteLog(stLogPath, "Finished get video data from DB", "SyncStart:INFOR", _
                                                          DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"))
                Else
                    WriteLog(stLogPath, "No video data from DB or Error", "SyncStart:EROR", _
                                                                         DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"))
                End If

                'Lay nhung file da bi xoa tren DB de xoa tren FTP server streaming
                VideoCollects = New VideoController.Sync().GetVideoSource4Del(strDeleteStatus)
                If Not IsNothing(VideoCollects) Then
                    WriteLog(stLogPath, "Starting delete file on FTp server", "SyncStart:INFOR", _
                                                         DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"))
                    For Each ArticleMedia As ArticleMedium In VideoCollects
                        If String.IsNullOrEmpty(ArticleMedia.Flag) Then
                            Flag = ""
                        Else
                            Flag = ArticleMedia.Flag.ToString.Trim
                        End If
                        strFile = ArticleMedia.FileLink.ToString.Trim
                        For Each node As XmlNode In FtpList
                            objFtp = New objFtp()
                            With objFtp
                                .FtpName = node("name").InnerText
                                .User = node("user").InnerText
                                .Pass = node("password").InnerText
                            End With
                            ftpResult = Me.DeleteVideoOnFtpServer(Me.strMediaDir, strFile, objFtp)
                            If ftpResult Then
                                objArticleMedia = New ArticleMedium()
                                objArticleMedia = ArticleMedia
                                objArticleMedia.Flag = strDeleteResult
                                Me.UpateVideoAfterFTP(objArticleMedia)
                            End If
                        Next
                    Next
                End If                
            End If
        Catch ex As Exception
            WriteLog(stLogPath, ex.ToString(), "SyncStart:ERROR", _
                                          DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"))
        Finally
            If Not IsNothing(VideoCollects) Then
                VideoCollects = Nothing
            End If
            If Not IsNothing(objArticleMedia) Then
                objArticleMedia = Nothing
            End If
        End Try
    End Sub

    '----------------------------------------------------------------------------------------------------
    'Muc dich: Lay danh sach FTP server tu file FtpServer.xml
    'Nguoi tao: Duong Hai Phong
    'Ngay tao: 14/09/2010
    'Tham so dau vao: Khong co
    'Ket qua tra ve: XmlNodeList
    '----------------------------------------------------------------------------------------------------
    Public Function getFtpList() As XmlNodeList
        Dim tblVideo As DataTable = Nothing
        Dim doc As XmlDocument = New XmlDocument()
        Dim FtpServer As XmlNodeList = Nothing
        Try
            Call initMyProxy()
            doc.Load(stFtpXml)
            Dim root As XmlElement = doc.DocumentElement
            FtpServer = root.SelectNodes("/VnnMedia/FtpServer")

            If (IsNothing(FtpServer) Or FtpServer.Count < 0) Then
                WriteLog(stLogPath, "FtpServer.xml does not exist or no data of FTP server", "getFtpList:Warning", _
                                                             DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"))
            End If
        Catch ex As Exception
            WriteLog(stLogPath, ex.ToString(), "getFtpList:ERROR", _
                                             DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"))
        Finally

        End Try
        Return FtpServer
    End Function
    '----------------------------------------------------------------------------------------------------
    'Muc dich: Upate truong Flag trong bang ArticleMedia de danh dau nhung ban ghi nao da duoc dong bo sang server Streaming
    'Nguoi tao: Duong Hai Phong
    'Ngay tao: 13/09/2010
    'Tham so dau vao:
    ' - Id: Id cua ban ghi can update
    ' - Flag: Gia tri can update cua truong Flag
    'Ket qua tra ve: Boolean - true: Upload thanh cong len server; False: ko thanh cong
    '----------------------------------------------------------------------------------------------------
    Public Function UpateVideoAfterFTP(ByVal objArticleMedia As ArticleMedium) As Boolean
        Dim ds As DataSet = Nothing
        Dim resultUpdate As Boolean = False
        Dim VideoController As ArticleMediumController
        Try
            Dim ArticleMedium As New ArticleMedium()
            VideoController = New ArticleMediumController()
            VideoController.Update(objArticleMedia.Id, objArticleMedia.ArticleId, objArticleMedia.MediaType, objArticleMedia.Ord, _
            objArticleMedia.FileLink, objArticleMedia.Thumbnail, objArticleMedia.Detail, objArticleMedia.CreatedAt, objArticleMedia.CreatedBy, _
            objArticleMedia.LastModifiedAt, objArticleMedia.LastModifiedBy, objArticleMedia.Flag)
            resultUpdate = True
        Catch ex As Exception
            WriteLog(stLogPath, ex.ToString(), "UpateVideoAfterFTP:ERROR", _
                                 DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"))
        Finally

        End Try
        Return resultUpdate
    End Function

    '----------------------------------------------------------------------------------------------------
    'Muc dich: Gui file media sang server streaming
    'Nguoi tao: Duong Hai Phong
    'Ngay tao: 13/09/2010
    'Tham so dau vao:
    ' - strMediaPath: Thu muc goc chua file media
    ' - strSource: Ten file can dong bo
    ' - ftpRemoteDir: Remote dir tren ftp server
    'Ket qua tra ve: Boolean;- True: Gui thanh cong; False: Khong gui dc
    '----------------------------------------------------------------------------------------------------

    Function SendVideo2FtpServer(ByVal strMediaPath As String, ByVal strSource As String, _
                    ByVal objFtp As objFtp) As Boolean
        Dim currentmonth As String = DateTime.Now.ToString("yyyy-MM")
        Dim result As Boolean = False
        Dim arrayDir As String()
        Try
            'Cat chuoi file media de tao cac thu muc con tren FTP
            If strSource.StartsWith("/") Then
                strSource = strSource.Substring(1)
            End If
            arrayDir = Util.Split(strSource, "/")
            If Not IsNothing(objFtp.FtpName) And Not ("".Equals(objFtp.FtpName)) Then
                WriteLog(stLogPath, "Start send file to ftp server " + objFtp.FtpName, "INFOR", _
                         DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"))
                Dim myFtp As New FTP.FTPclient(objFtp.FtpName, objFtp.User, objFtp.Pass)

                If objFtp.ftpRemoteDir.Trim <> "" Then
                    myFtp.CurrentDirectory = "/" + objFtp.ftpRemoteDir
                End If
                Try
                    'Tao thu muc clip tren Ftp server
                    Dim str As String = ""
                    For i As Integer = 0 To arrayDir.Length - 2
                        str = str + "/" + arrayDir(i).ToString
                        myFtp.FtpCreateDirectory(str)
                    Next
                Catch ex As Exception

                End Try
                'If (myFtp.FtpCreateDirectory("/" + arrayDir(0).ToString + "/" + arrayDir(1).ToString + "/" + arrayDir(2).ToString + "/" + arrayDir(3).ToString + "/" + arrayDir(4).ToString)) Then
                myFtp.CurrentDirectory = "/" + arrayDir(0).ToString + "/" + arrayDir(1).ToString + "/" + arrayDir(2).ToString + _
                                                         "/" + arrayDir(3).ToString + "/" + arrayDir(4).ToString
                Dim pos As Integer = strSource.LastIndexOf("/")
                Dim remotFileName As String = strSource.Substring(pos + 1)
                Dim f As String = strMediaPath + strSource
                WriteLog(stLogPath, "Starting send file@FileName = " + strMediaPath + strSource + "@ to ftp server " + objFtp.FtpName, "INFOR", _
                         DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"))
                result = myFtp.Upload(f, remotFileName)
                If (result) Then
                    WriteLog(stLogPath, _
                                             "Finished send file@FileName = " + strMediaPath + strSource + "@ to ftp server " + objFtp.FtpName, "INFOR", _
                                             DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"))
                Else
                    WriteLog(stLogPath, _
                                                                    "Cant not send file@FileName = " + strMediaPath + strSource + "@ to ftp server " + objFtp.FtpName, "INFOR", _
                                                                    DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"))
                End If
            End If
        Catch ex As Exception
            WriteLog(stLogPath, ex.ToString(), "SendVideo2FtpServer:ERROR", _
                     DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"))
            result = False
        Finally
            If (Not IsNothing(ftp)) Then
                ftp = Nothing
            End If
            'ftp = Nothing
        End Try
        Return result
    End Function
    '----------------------------------------------------------------------------------------------------
    'Muc dich: Xoa cac file tren server streaming khi da xoa tu DB
    'Nguoi tao: Duong Hai Phong
    'Ngay tao: 14/09/2010
    'Tham so dau vao:
    ' - strMediaPath: Thu muc goc chua file media
    ' - strSource: Ten file can dong bo
    ' - ftpRemoteDir: Remote dir tren ftp server
    'Ket qua tra ve: Boolean: True: xoa thanh cong; False: Ko xoa dc or file ko ton tai
    '----------------------------------------------------------------------------------------------------

    Function DeleteVideoOnFtpServer(ByVal strMediaPath As String, ByVal strSource As String, _
                    ByVal objFtp As objFtp) As Boolean
        Dim currentmonth As String = DateTime.Now.ToString("yyyy-MM")
        Dim result As Boolean = False
        Dim arrayDir As String()
        Try
            'Cat chuoi file media de tao cac thu muc con tren FTP
            If strSource.StartsWith("/") Then
                strSource = strSource.Substring(1)
            End If
            arrayDir = Util.Split(strSource, "/")
            If Not IsNothing(objFtp.FtpName) And Not ("".Equals(objFtp.FtpName)) Then
                WriteLog(stLogPath, "Start send file to ftp server " + objFtp.FtpName, "INFOR", _
                         DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"))
                Dim myFtp As New FTP.FTPclient(objFtp.FtpName, objFtp.User, objFtp.Pass)

                If objFtp.ftpRemoteDir.Trim <> "" Then
                    myFtp.CurrentDirectory = "/" + objFtp.ftpRemoteDir
                End If
                myFtp.CurrentDirectory = "/" + arrayDir(0).ToString + "/" + arrayDir(1).ToString + "/" + arrayDir(2).ToString + _
                                         "/" + arrayDir(3).ToString + "/" + arrayDir(4).ToString
                Dim pos As Integer = strSource.LastIndexOf("/")
                Dim remotFileName As String = strSource.Substring(pos + 1)
                If myFtp.FtpFileExists(remotFileName) Then
                    myFtp.FtpDelete(remotFileName)
                    WriteLog(stLogPath, _
                                             "File@FileName = " + "/" + arrayDir(0).ToString + "/" + arrayDir(1).ToString + "/" + arrayDir(2).ToString + _
                                         "/" + arrayDir(3).ToString + "/" + arrayDir(4).ToString + "/" + remotFileName + " was deleted on ftp server " + objFtp.FtpName, "INFOR", _
                                             DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"))
                    result = True
                Else
                    WriteLog(stLogPath, _
                                             "File@FileName = " + "/" + arrayDir(0).ToString + "/" + arrayDir(1).ToString + "/" + arrayDir(2).ToString + _
                                         "/" + arrayDir(3).ToString + "/" + arrayDir(4).ToString + "/" + remotFileName + " does not exist on ftp server " + objFtp.FtpName, "INFOR", _
                                             DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"))
                End If

            End If
        Catch ex As Exception
            WriteLog(stLogPath, ex.ToString(), "SendVideo2FtpServer:ERROR", _
                     DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"))
            result = False
        Finally
            If (Not IsNothing(ftp)) Then
                ftp = Nothing
            End If
            'ftp = Nothing
        End Try
        Return result
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

End Class
Public Class objFtp
    Public FtpName As String = ""
    Public User As String = ""
    Public Pass As String = ""
    Public ftpRemoteDir As String = ""
End Class