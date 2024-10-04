Imports System.Configuration
Imports System

Public Class MyRegistry
    Public strUserName As String
    Public strPassword As String
    Public strDomain As String
    Public boolProxy As Boolean
    Public strProxyAddress As String
    Public strProxyPort As String
    Public strConnection As String
    Public intTimeInterval As Integer
    Public strWebPath As String
    Public boolCurrentState As Boolean
    Public strLogPath As String
    Public strImgUrl As String

    Public Sub getRegs()
        strUserName = ""
        'GetSetting("VNN", "VNN_WEBEXTRACTOR", "UserName", "")
        strPassword = ""
        'GetSetting("VNN", "VNN_WEBEXTRACTOR", "Password", "")
        strDomain = ""
        'GetSetting("VNN", "VNN_WEBEXTRACTOR", "Domain", "")
        boolProxy = False
        ' GetSetting("VNN", "VNN_WEBEXTRACTOR", "Proxy", False)
        strProxyAddress = ""
        'GetSetting("VNN", "VNN_WEBEXTRACTOR", "ProxyAddress", "")
        strProxyPort = ""
        'GetSetting("VNN", "VNN_WEBEXTRACTOR", "ProxyPort", "")
        strConnection = ""
        'GetSetting("VNN", "VNN_WEBEXTRACTOR", "SQLConnection", "")
        intTimeInterval = 10
        'GetSetting("VNN", "VNN_WEBEXTRACTOR", "TimeInterval", 10) / 60000
        strWebPath = ""
        'GetSetting("VNN", "VNN_WEBEXTRACTOR", "WebPath", "")
        boolCurrentState = False
        'GetSetting("VNN", "VNN_WEBEXTRACTOR", "CurrentState", False)
        strLogPath = ""
        strImgUrl = ""
        'strUserName = GetSetting("VNN", "VNN_WEBEXTRACTOR", "UserName", "")
        'strPassword = GetSetting("VNN", "VNN_WEBEXTRACTOR", "Password", "")
        'strDomain = GetSetting("VNN", "VNN_WEBEXTRACTOR", "Domain", "")
        'boolProxy = GetSetting("VNN", "VNN_WEBEXTRACTOR", "Proxy", False)
        'strProxyAddress = GetSetting("VNN", "VNN_WEBEXTRACTOR", "ProxyAddress", "")
        'strProxyPort = GetSetting("VNN", "VNN_WEBEXTRACTOR", "ProxyPort", "")
        'strConnection = GetSetting("VNN", "VNN_WEBEXTRACTOR", "SQLConnection", "")
        'intTimeInterval = GetSetting("VNN", "VNN_WEBEXTRACTOR", "TimeInterval", 10) / 60000
        'strWebPath = GetSetting("VNN", "VNN_WEBEXTRACTOR", "WebPath", "")
        'boolCurrentState = GetSetting("VNN", "VNN_WEBEXTRACTOR", "CurrentState", False)
        Try
            strUserName = ConfigurationManager.AppSettings ("UserName")
            strPassword = ConfigurationManager.AppSettings ("Password")
            strDomain = ConfigurationManager.AppSettings ("Domain")
            boolProxy = IIf (ConfigurationManager.AppSettings ("Proxy").Equals ("1"), True, False)
            strProxyAddress = ConfigurationManager.AppSettings ("ProxyAddress")
            strProxyPort = ConfigurationManager.AppSettings ("ProxyPort")
            strConnection = ConfigurationManager.AppSettings ("ConnectionString")
            intTimeInterval = Integer.Parse (ConfigurationManager.AppSettings ("TimeInterval"))
            strWebPath = ConfigurationManager.AppSettings ("WebPath")
            boolCurrentState = IIf (ConfigurationManager.AppSettings ("CurrentState").Equals ("1"), True, False)
            strLogPath = ConfigurationManager.AppSettings ("FileLogPath")
            strImgUrl = ConfigurationManager.AppSettings ("ImageUrl")
        Catch ex As Exception
            strUserName = ""
            strPassword = ""
            strDomain = ""
            boolProxy = False
            strProxyAddress = ""
            strProxyPort = ""
            strConnection = ""
            intTimeInterval = 10
            strWebPath = ""
            strImgUrl = ""
            boolCurrentState = False
        End Try
    End Sub


    Public Sub SaveRegs()
        SaveSetting ("VNN", "VNN_WEBEXTRACTOR", "UserName", strUserName)
        SaveSetting ("VNN", "VNN_WEBEXTRACTOR", "Password", strPassword)
        SaveSetting ("VNN", "VNN_WEBEXTRACTOR", "Domain", strDomain)
        SaveSetting ("VNN", "VNN_WEBEXTRACTOR", "Proxy", boolProxy)
        SaveSetting ("VNN", "VNN_WEBEXTRACTOR", "ProxyAddress", strProxyAddress)
        SaveSetting ("VNN", "VNN_WEBEXTRACTOR", "ProxyPort", strProxyPort)
        SaveSetting ("VNN", "VNN_WEBEXTRACTOR", "SQLConnection", strConnection.Replace ("Provider=SQLOLEDB.1;", ""))
        SaveSetting ("VNN", "VNN_WEBEXTRACTOR", "TimeInterval", intTimeInterval*60000)
        SaveSetting ("VNN", "VNN_WEBEXTRACTOR", "WebPath", strWebPath)
        SaveSetting ("VNN", "VNN_WEBEXTRACTOR", "ImgUrl", strImgUrl)
        SaveSetting ("VNN", "VNN_WEBEXTRACTOR", "CurrentState", boolCurrentState)
    End Sub
End Class
