Imports VideoSyncProcess
Imports System.Xml
Module Module1

    Sub Main()
        Dim objSync As New Sync
        objSync.SyncStart()

        'Dim FtpList As XmlNodeList = objSync.getFtpList()
        'For Each node As XmlNode In FtpList
        '    Dim objFtp As VideoSyncProcess.objFtp = New VideoSyncProcess.objFtp()
        '    With objFtp
        '        .FtpName = node("name").InnerText
        '        .User = node("user").InnerText
        '        .Pass = node("password").InnerText
        '    End With
        'Next

        'Dim objFtp As New objFtp
        'With objFtp
        '    .FtpName = "183.91.14.3"
        '    .User = "vnnclip"
        '    .Pass = "Vnn@)!)Clip"
        'End With

        'Dim myFtp As New FTP.FTPclient(objFtp.FtpName, objFtp.User, objFtp.Pass)

        'If objFtp.ftpRemoteDir.Trim <> "" Then
        '    myFtp.CurrentDirectory = "/" + objFtp.ftpRemoteDir
        'End If
        'Dim arrayDir As String() = "/clip/2010/09/14/10/2010_08_20296_avidieuconmai.flv".Substring(1).Split("/")
        'Dim chkCreate As Boolean
        'Dim str As String = ""
        'For i As Integer = 0 To arrayDir.Length - 2
        '    str = str + "/" + arrayDir(i).ToString
        '    myFtp.FtpCreateDirectory(str)
        'Next
        

    End Sub
End Module
