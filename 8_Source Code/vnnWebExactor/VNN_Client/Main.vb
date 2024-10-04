Imports VNN_WEBEXTRACTOR
Imports System.Windows.Forms
Imports Microsoft.Win32

Public Class Form1
    Inherits System.Windows.Forms.Form
    Private objReg As New VNN_WEBEXTRACTOR.MyRegistry


#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents ContextMenu1 As System.Windows.Forms.ContextMenu
    Friend WithEvents MenuItem18 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem21 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem23 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuCategory As System.Windows.Forms.MenuItem
    Friend WithEvents mnuSource As System.Windows.Forms.MenuItem
    Friend WithEvents mnuCheck As System.Windows.Forms.MenuItem
    Friend WithEvents mnuTest As System.Windows.Forms.MenuItem
    Friend WithEvents mnuOption As System.Windows.Forms.MenuItem
    Friend WithEvents mnuExit As System.Windows.Forms.MenuItem
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem6 As System.Windows.Forms.MenuItem
    Friend WithEvents ServiceController1 As System.ServiceProcess.ServiceController
    Friend WithEvents EventLog1 As System.Diagnostics.EventLog
    Friend WithEvents mnuInstall As System.Windows.Forms.MenuItem
    Friend WithEvents mnuUninstall As System.Windows.Forms.MenuItem
    Friend WithEvents mnuStart As System.Windows.Forms.MenuItem
    Friend WithEvents mnuStop As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuAbout As System.Windows.Forms.MenuItem
    Friend WithEvents mnuRunAutoExtract As System.Windows.Forms.MenuItem

    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim _
            resources As System.ComponentModel.ComponentResourceManager = _
                New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ContextMenu1 = New System.Windows.Forms.ContextMenu
        Me.mnuCategory = New System.Windows.Forms.MenuItem
        Me.mnuSource = New System.Windows.Forms.MenuItem
        Me.MenuItem18 = New System.Windows.Forms.MenuItem
        Me.mnuCheck = New System.Windows.Forms.MenuItem
        Me.mnuTest = New System.Windows.Forms.MenuItem
        Me.mnuRunAutoExtract = New System.Windows.Forms.MenuItem
        Me.MenuItem21 = New System.Windows.Forms.MenuItem
        Me.mnuOption = New System.Windows.Forms.MenuItem
        Me.MenuItem23 = New System.Windows.Forms.MenuItem
        Me.mnuStart = New System.Windows.Forms.MenuItem
        Me.mnuStop = New System.Windows.Forms.MenuItem
        Me.MenuItem6 = New System.Windows.Forms.MenuItem
        Me.mnuInstall = New System.Windows.Forms.MenuItem
        Me.mnuUninstall = New System.Windows.Forms.MenuItem
        Me.MenuItem1 = New System.Windows.Forms.MenuItem
        Me.mnuAbout = New System.Windows.Forms.MenuItem
        Me.MenuItem2 = New System.Windows.Forms.MenuItem
        Me.mnuExit = New System.Windows.Forms.MenuItem
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ServiceController1 = New System.ServiceProcess.ServiceController
        Me.EventLog1 = New System.Diagnostics.EventLog
        CType(Me.EventLog1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.ContextMenu = Me.ContextMenu1
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "Internet Information Extractor V1.0 (VNN)"
        Me.NotifyIcon1.Visible = True
        '
        'ContextMenu1
        '
        Me.ContextMenu1.MenuItems.AddRange( _
                                            New System.Windows.Forms.MenuItem() _
                                               {Me.mnuCategory, Me.mnuSource, Me.MenuItem18, Me.mnuCheck, Me.mnuTest, _
                                                Me.mnuRunAutoExtract, Me.MenuItem21, Me.mnuOption, Me.MenuItem23, _
                                                Me.mnuStart, Me.mnuStop, Me.MenuItem6, Me.mnuInstall, Me.mnuUninstall, _
                                                Me.MenuItem1, Me.mnuAbout, Me.MenuItem2, Me.mnuExit})
        '
        'mnuCategory
        '
        Me.mnuCategory.Index = 0
        Me.mnuCategory.Text = "Manage Information &Category"
        '
        'mnuSource
        '
        Me.mnuSource.Index = 1
        Me.mnuSource.Text = "Management Information Ch&annel"
        '
        'MenuItem18
        '
        Me.MenuItem18.Index = 2
        Me.MenuItem18.Text = "-"
        '
        'mnuCheck
        '
        Me.mnuCheck.Index = 3
        Me.mnuCheck.Text = "Check Web &Navigation "
        '
        'mnuTest
        '
        Me.mnuTest.Index = 4
        Me.mnuTest.Text = "Check Data &Extraction"
        '
        'mnuRunAutoExtract
        '
        Me.mnuRunAutoExtract.Index = 5
        Me.mnuRunAutoExtract.Text = "&Run Extraction"
        '
        'MenuItem21
        '
        Me.MenuItem21.Index = 6
        Me.MenuItem21.Text = "-"
        '
        'mnuOption
        '
        Me.mnuOption.Enabled = False
        Me.mnuOption.Index = 7
        Me.mnuOption.Text = "S&ystem Setting"
        '
        'MenuItem23
        '
        Me.MenuItem23.Index = 8
        Me.MenuItem23.Text = "-"
        '
        'mnuStart
        '
        Me.mnuStart.Index = 9
        Me.mnuStart.Text = "&Start Service"
        '
        'mnuStop
        '
        Me.mnuStop.Index = 10
        Me.mnuStop.Text = "S&top Service"
        '
        'MenuItem6
        '
        Me.MenuItem6.Index = 11
        Me.MenuItem6.Text = "-"
        '
        'mnuInstall
        '
        Me.mnuInstall.Index = 12
        Me.mnuInstall.Text = "&Install Service"
        '
        'mnuUninstall
        '
        Me.mnuUninstall.Index = 13
        Me.mnuUninstall.Text = "&Uninstall service"
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 14
        Me.MenuItem1.Text = "-"
        '
        'mnuAbout
        '
        Me.mnuAbout.Index = 15
        Me.mnuAbout.Text = "&About"
        '
        'MenuItem2
        '
        Me.MenuItem2.Index = 16
        Me.MenuItem2.Text = "-"
        '
        'mnuExit
        '
        Me.mnuExit.Index = 17
        Me.mnuExit.Text = "&Exit"
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'EventLog1
        '
        Me.EventLog1.SynchronizingObject = Me
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(496, 181)
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.WindowState = System.Windows.Forms.FormWindowState.Minimized
        CType(Me.EventLog1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub mnuCategory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCategory.Click
        'Call AuthorizedCheck()
        Dim frmCategory As New frmCategory
        frmCategory.Show()
        frmCategory = Nothing
    End Sub

    Private Sub mnuSource_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSource.Click
        'Call AuthorizedCheck()
        Dim frmSource As New frmSource
        frmSource.ShowDialog()
        frmSource = Nothing
    End Sub

    Private Sub mnuTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTest.Click
        'Call AuthorizedCheck()
        Dim frmTest As New frmTest
        frmTest.ShowDialog()
        frmTest = Nothing
    End Sub

    Private Sub mnuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuExit.Click
        Me.Close()
        End
    End Sub

    Private Sub mnuCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCheck.Click
        'Call AuthorizedCheck()
        Dim frmSourceCode As New frmSourceCode
        frmSourceCode.ShowDialog()
        frmSourceCode = Nothing
    End Sub

    Private Sub mnuOption_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuOption.Click
        'Call AuthorizedCheck()
        Dim frmOption As New frmSetting
        frmOption.ShowDialog()
        frmOption = Nothing
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If Integer.Parse(GetSetting("VNN", "VNN_WEBEXTRACTOR", "Installed", "10")) = 1 Then
            mnuInstall.Enabled = False
            mnuUninstall.Enabled = True
            ServiceController1.Refresh()
            If ServiceController1.Status = ServiceProcess.ServiceControllerStatus.Running Then
                mnuStart.Enabled = False
                mnuStop.Enabled = True
            Else
                mnuStart.Enabled = True
                mnuStop.Enabled = False
            End If
        Else
            mnuInstall.Enabled = True
            mnuUninstall.Enabled = False
            mnuStart.Enabled = False
            mnuStop.Enabled = False
        End If
        Me.Hide()
    End Sub

    Private Sub mnuInstallService_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles mnuInstall.Click

        Try
            Dim _
                key3 As String = _
                    Registry.LocalMachine.OpenSubKey("SOFTWARE").OpenSubKey("Microsoft").OpenSubKey(".NETFramework"). _
                    OpenSubKey("Policy").OpenSubKey("v2.0").GetValue("50727").ToString()
            Dim v20 As Boolean = (key3 = "50727-50727")
            Dim dotnetInsDir As String = System.Runtime.InteropServices.RuntimeEnvironment.GetRuntimeDirectory()

            'Service install
            Shell(dotnetInsDir & "InstallUtil.exe VNN_WEBEXTRACTSVC.exe", AppWinStyle.NormalFocus, True)
            If checkServiceExist() Then
                SaveSetting("VNN", "VNN_WEBEXTRACTOR", "Installed", "1")
                MessageBox.Show("Service is installed successfully", WEBEXTRACTOR.MY_NOTICE_TITLE, MessageBoxButtons.OK, _
                                 MessageBoxIcon.Information)
                ServiceController1.ServiceName = "VNN_WEBEXTRACTSVC"
                Timer1.Enabled = True
            Else
                Throw _
                    New System.Exception( _
                                          "Service is not installed ! You must install service by using InstallUtil.exe tool of NetFramework before doing anything")
            End If

        Catch ex As Exception
            MessageBox.Show("Service can not be installed", WEBEXTRACTOR.MY_NOTICE_TITLE, MessageBoxButtons.OK, _
                             MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub mnuUninstallService_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles mnuUninstall.Click
        'Call AuthorizedCheck()
        Try
            Dim _
                key3 As String = _
                    Registry.LocalMachine.OpenSubKey("SOFTWARE").OpenSubKey("Microsoft").OpenSubKey(".NETFramework"). _
                    OpenSubKey("Policy").OpenSubKey("v2.0").GetValue("50727").ToString()
            Dim v20 As Boolean = (key3 = "50727-50727")
            Dim dotnetInsDir As String = System.Runtime.InteropServices.RuntimeEnvironment.GetRuntimeDirectory()

            'Service Uninstall
            Shell(dotnetInsDir & "InstallUtil.exe VNN_WEBEXTRACTSVC.exe /u", AppWinStyle.NormalFocus, True)

            If Not checkServiceExist() Then
                SaveSetting("VNN", "VNN_WEBEXTRACTOR", "Installed", "0")
                MessageBox.Show("Service is uninstalled successfully", WEBEXTRACTOR.MY_NOTICE_TITLE, _
                                 MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                Throw _
                    New System.Exception( _
                                          "Service is not uninstalled ! You must uninstall service by using InstallUtil.exe tool of NetFramework before doing anything")
            End If
        Catch ex As Exception
            MessageBox.Show("Service can not be uninstalled: " & ex.Message, "VNN_WEBEXTRACTSVC Notice", _
                             MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub mnuStartService_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles mnuStart.Click
        Try
            ServiceController1.Refresh()
            ServiceController1.WaitForStatus(ServiceProcess.ServiceControllerStatus.Stopped)
            ServiceController1.Start()
            ServiceController1.WaitForStatus(ServiceProcess.ServiceControllerStatus.Running)
            MessageBox.Show("Service is started successfully!", WEBEXTRACTOR.MY_NOTICE_TITLE, MessageBoxButtons.OK, _
                             MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Service can not start. PLease open System Event log for error description", _
                             WEBEXTRACTOR.MY_NOTICE_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            EventLog1.Source = "VNN_WEBEXTRACTSVC"
            EventLog1.WriteEntry("VNN_WEBEXTRACTSVC :" & ex.Message)
        End Try
    End Sub

    Private Sub mnuStopService_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuStop.Click
        'Call AuthorizedCheck()
        Try
            ServiceController1.Refresh()
            ServiceController1.WaitForStatus(ServiceProcess.ServiceControllerStatus.Running)
            ServiceController1.Stop()
            ServiceController1.WaitForStatus(ServiceProcess.ServiceControllerStatus.Stopped)
            MessageBox.Show("Service is stopped successfully!", WEBEXTRACTOR.MY_NOTICE_TITLE, MessageBoxButtons.OK, _
                             MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Service can not stop. PLease open System Event log for error description", _
                             WEBEXTRACTOR.MY_NOTICE_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            EventLog1.Source = "VNN_WEBEXTRACTSVC"
            EventLog1.WriteEntry("VNN_WEBEXTRACTSVC :" & ex.Message)
        End Try
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Hide()
        'Call AuthorizedCheck()

        If Not EventLog1.SourceExists("VNN_WEBEXTRACTSVC") Then
            EventLog1.CreateEventSource("VNN_WEBEXTRACTSVC", "Application")
        End If
        objReg.getRegs()
        'Try
        '    If checkServiceExist() Then
        '        ServiceController1.ServiceName = "VNN_WEBEXTRACTSVC"
        '        Timer1.Enabled = True
        '    Else
        '        mnuInstall.Enabled = True
        '        mnuUninstall.Enabled = False
        '        mnuStart.Enabled = False
        '        mnuStop.Enabled = False
        '        Throw New System.Exception
        '    End If
        'Catch ex As Exception
        '    MessageBox.Show("Service is not installed. PLease Select 'Install service' item  by right click on program icon on task bar or open System Event log for error description", WEBEXTRACTOR.MY_NOTICE_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    mnuStart.Enabled = False
        '    mnuStop.Enabled = False
        '    EventLog1.Source = "VNN_WEBEXTRACTSVC"
        '    EventLog1.WriteEntry("VNN_WEBEXTRACTSVC :" & ex.Message)
        'End Try
        'Me.Hide()
    End Sub

    Private Sub mnuAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAbout.Click
        Dim frmAbout As New About
        frmAbout.ShowDialog()
        frmAbout = Nothing
    End Sub

    Private Sub mnuRunAutoExtract_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles mnuRunAutoExtract.Click
        'Call AuthorizedCheck()
        Try
            mnuRunAutoExtract.Enabled = False
            mnuExit.Enabled = False
            DoExtract()
            mnuRunAutoExtract.Enabled = True
            mnuExit.Enabled = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DoExtract()
        Dim objExtractor As New Extractor
        objExtractor.initDataConnection(WEBEXTRACTOR.objConn.getConnection)
        objExtractor.doAutoExtract()
        'objExtractor.doAutoNotNewsExtract()
        objExtractor = Nothing
    End Sub

    Private Function checkServiceExist() As Boolean
        Dim Flag As Boolean = False
        Dim objSC As ServiceProcess.ServiceController
        For Each objSC In ServiceController1.GetServices
            If objSC.ServiceName = "VNN_WEBEXTRACTSVC" Then
                Flag = True
                Exit For
            End If
        Next
        Return Flag
    End Function

    Private Sub AuthorizedCheck()
        If Not InputBox("Enter your key:", WEBEXTRACTOR.MY_NOTICE_TITLE, "").Trim.ToUpper = "VNN2009" Then
            MessageBox.Show("You are not authorized to use this system", WEBEXTRACTOR.MY_NOTICE_TITLE, _
                             MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End
        End If
    End Sub
End Class
