Imports System.Configuration
Imports System

Public Class MyRegistry
    Public strFtpServer1 As String
    Public strUserName1 As String
    Public strPassword1 As String

    Public strFtpServer2 As String
    Public strUserName2 As String
    Public strPassword2 As String

    Public strVideoType As String

    Public boolCurrentState As Boolean
    Public strMediaDir As String
    Public intTimeInterval As Integer
    Public stLogPath As String
    Public stFtpXml As String
    Public strDeleteStatus As String
    Public strSendStatus As String
    Public strDeleteResult As String

    Public Sub getRegs()
        Try
            strFtpServer1 = ConfigurationManager.AppSettings("FtpServer1")
            strUserName1 = ConfigurationManager.AppSettings("UserName1")
            strPassword1 = ConfigurationManager.AppSettings("Password1")

            strFtpServer2 = ConfigurationManager.AppSettings("FtpServer2")
            strUserName2 = ConfigurationManager.AppSettings("UserName2")
            strPassword2 = ConfigurationManager.AppSettings("Password2")
            strMediaDir = ConfigurationManager.AppSettings("rootMediaDir")
            strVideoType = ConfigurationManager.AppSettings("VideoType")
            intTimeInterval = ConfigurationManager.AppSettings("TimeInterval")
            stLogPath = ConfigurationManager.AppSettings("FileLogPath")
            stFtpXml = ConfigurationManager.AppSettings("FtpServer")
            strSendStatus = ConfigurationManager.AppSettings("SendStatus")
            strDeleteStatus = ConfigurationManager.AppSettings("DeleteStatus")
            strDeleteResult = ConfigurationManager.AppSettings("DeleteResult")

            boolCurrentState = True
        Catch ex As Exception

            boolCurrentState = False
        End Try
    End Sub

    Public Sub SaveRegs()
        SaveSetting("VNN", "VideoSyncProcess", "FtpServer1", strFtpServer1)
        SaveSetting("VNN", "VideoSyncProcess", "UserName1", strUserName1)
        SaveSetting("VNN", "VideoSyncProcess", "Password1", strPassword1)
        SaveSetting("VNN", "VideoSyncProcess", "FtpServer2", strFtpServer2)
        SaveSetting("VNN", "VideoSyncProcess", "UserName2", strUserName2)
        SaveSetting("VNN", "VideoSyncProcess", "Password2", strPassword2)
        SaveSetting("VNN", "VideoSyncProcess", "MediaDir", strMediaDir)
        SaveSetting("VNN", "VideoSyncProcess", "CurrentState", boolCurrentState)
        SaveSetting("VNN", "VideoSyncProcess", "FtpServer", stFtpXml)
        SaveSetting("VNN", "VideoSyncProcess", "SendStatus", strSendStatus)
        SaveSetting("VNN", "VideoSyncProcess", "DeleteStatus", strDeleteStatus)
        SaveSetting("VNN", "VideoSyncProcess", "DeleteResult", strDeleteResult)

    End Sub
End Class
