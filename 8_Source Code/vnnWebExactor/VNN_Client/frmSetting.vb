Imports System
Imports Microsoft.Win32
Imports MSDASC
Imports ADODB

Public Class frmSetting
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose (ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose (disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents grpProxy As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtUserName As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtDomain As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents grpInternetProxyPara As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdConnection As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtConnection As System.Windows.Forms.TextBox
    Friend WithEvents txtTimeInterval As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtProxyAddress As System.Windows.Forms.TextBox
    Friend WithEvents txtProxyPort As System.Windows.Forms.TextBox
    Friend WithEvents chkboolProxy As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtWebPath As System.Windows.Forms.TextBox

    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager (GetType (frmSetting))
        Me.cmdOK = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.grpProxy = New System.Windows.Forms.GroupBox
        Me.txtUserName = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtDomain = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtPassword = New System.Windows.Forms.TextBox
        Me.grpInternetProxyPara = New System.Windows.Forms.GroupBox
        Me.txtProxyAddress = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtProxyPort = New System.Windows.Forms.TextBox
        Me.chkboolProxy = New System.Windows.Forms.CheckBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmdConnection = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtConnection = New System.Windows.Forms.TextBox
        Me.txtTimeInterval = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtWebPath = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.grpProxy.SuspendLayout()
        Me.grpInternetProxyPara.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdOK
        '
        Me.cmdOK.Location = New System.Drawing.Point (264, 400)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.TabIndex = 1
        Me.cmdOK.Text = "&OK"
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point (344, 400)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.TabIndex = 2
        Me.cmdCancel.Text = "&Cancel"
        '
        'grpProxy
        '
        Me.grpProxy.Controls.Add (Me.txtUserName)
        Me.grpProxy.Controls.Add (Me.Label5)
        Me.grpProxy.Controls.Add (Me.Label6)
        Me.grpProxy.Controls.Add (Me.txtDomain)
        Me.grpProxy.Controls.Add (Me.Label7)
        Me.grpProxy.Controls.Add (Me.txtPassword)
        Me.grpProxy.Font = _
            New System.Drawing.Font ("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, _
                                     System.Drawing.GraphicsUnit.Point, CType (0, Byte))
        Me.grpProxy.Location = New System.Drawing.Point (0, 96)
        Me.grpProxy.Name = "grpProxy"
        Me.grpProxy.Size = New System.Drawing.Size (424, 128)
        Me.grpProxy.TabIndex = 3
        Me.grpProxy.TabStop = False
        Me.grpProxy.Text = "Network Credential"
        '
        'txtUserName
        '
        Me.txtUserName.Font = _
            New System.Drawing.Font ("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, _
                                     System.Drawing.GraphicsUnit.Point, CType (0, Byte))
        Me.txtUserName.Location = New System.Drawing.Point (128, 24)
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.Size = New System.Drawing.Size (160, 20)
        Me.txtUserName.TabIndex = 2
        Me.txtUserName.Text = ""
        '
        'Label5
        '
        Me.Label5.Font = _
            New System.Drawing.Font ("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, _
                                     System.Drawing.GraphicsUnit.Point, CType (0, Byte))
        Me.Label5.Location = New System.Drawing.Point (8, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size (88, 16)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Network account"
        '
        'Label6
        '
        Me.Label6.Font = _
            New System.Drawing.Font ("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, _
                                     System.Drawing.GraphicsUnit.Point, CType (0, Byte))
        Me.Label6.Location = New System.Drawing.Point (8, 56)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size (88, 16)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Password"
        '
        'txtDomain
        '
        Me.txtDomain.Font = _
            New System.Drawing.Font ("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, _
                                     System.Drawing.GraphicsUnit.Point, CType (0, Byte))
        Me.txtDomain.Location = New System.Drawing.Point (128, 88)
        Me.txtDomain.Name = "txtDomain"
        Me.txtDomain.Size = New System.Drawing.Size (160, 20)
        Me.txtDomain.TabIndex = 2
        Me.txtDomain.Text = ""
        '
        'Label7
        '
        Me.Label7.Font = _
            New System.Drawing.Font ("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, _
                                     System.Drawing.GraphicsUnit.Point, CType (0, Byte))
        Me.Label7.Location = New System.Drawing.Point (8, 88)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size (88, 16)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Domain"
        '
        'txtPassword
        '
        Me.txtPassword.Font = _
            New System.Drawing.Font ("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, _
                                     System.Drawing.GraphicsUnit.Point, CType (0, Byte))
        Me.txtPassword.Location = New System.Drawing.Point (128, 56)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Microsoft.VisualBasic.ChrW (42)
        Me.txtPassword.Size = New System.Drawing.Size (160, 20)
        Me.txtPassword.TabIndex = 2
        Me.txtPassword.Text = ""
        '
        'grpInternetProxyPara
        '
        Me.grpInternetProxyPara.Controls.Add (Me.txtProxyAddress)
        Me.grpInternetProxyPara.Controls.Add (Me.Label10)
        Me.grpInternetProxyPara.Controls.Add (Me.Label11)
        Me.grpInternetProxyPara.Controls.Add (Me.txtProxyPort)
        Me.grpInternetProxyPara.Controls.Add (Me.chkboolProxy)
        Me.grpInternetProxyPara.Font = _
            New System.Drawing.Font ("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, _
                                     System.Drawing.GraphicsUnit.Point, CType (0, Byte))
        Me.grpInternetProxyPara.Location = New System.Drawing.Point (0, 16)
        Me.grpInternetProxyPara.Name = "grpInternetProxyPara"
        Me.grpInternetProxyPara.Size = New System.Drawing.Size (424, 80)
        Me.grpInternetProxyPara.TabIndex = 4
        Me.grpInternetProxyPara.TabStop = False
        Me.grpInternetProxyPara.Text = "Internet Proxy (IP:http://10.0.0.24 Port:80)"
        '
        'txtProxyAddress
        '
        Me.txtProxyAddress.Font = _
            New System.Drawing.Font ("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, _
                                     System.Drawing.GraphicsUnit.Point, CType (0, Byte))
        Me.txtProxyAddress.Location = New System.Drawing.Point (128, 24)
        Me.txtProxyAddress.Name = "txtProxyAddress"
        Me.txtProxyAddress.Size = New System.Drawing.Size (144, 20)
        Me.txtProxyAddress.TabIndex = 1
        Me.txtProxyAddress.Text = ""
        '
        'Label10
        '
        Me.Label10.Font = _
            New System.Drawing.Font ("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, _
                                     System.Drawing.GraphicsUnit.Point, CType (0, Byte))
        Me.Label10.Location = New System.Drawing.Point (16, 24)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size (64, 23)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "IP Address"
        '
        'Label11
        '
        Me.Label11.Font = _
            New System.Drawing.Font ("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, _
                                     System.Drawing.GraphicsUnit.Point, CType (0, Byte))
        Me.Label11.Location = New System.Drawing.Point (288, 32)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size (40, 16)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "Port"
        '
        'txtProxyPort
        '
        Me.txtProxyPort.Font = _
            New System.Drawing.Font ("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, _
                                     System.Drawing.GraphicsUnit.Point, CType (0, Byte))
        Me.txtProxyPort.Location = New System.Drawing.Point (328, 24)
        Me.txtProxyPort.Name = "txtProxyPort"
        Me.txtProxyPort.Size = New System.Drawing.Size (64, 20)
        Me.txtProxyPort.TabIndex = 1
        Me.txtProxyPort.Text = ""
        '
        'chkboolProxy
        '
        Me.chkboolProxy.Font = _
            New System.Drawing.Font ("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, _
                                     System.Drawing.GraphicsUnit.Point, CType (0, Byte))
        Me.chkboolProxy.ForeColor = System.Drawing.Color.Black
        Me.chkboolProxy.Location = New System.Drawing.Point (16, 56)
        Me.chkboolProxy.Name = "chkboolProxy"
        Me.chkboolProxy.Size = New System.Drawing.Size (240, 16)
        Me.chkboolProxy.TabIndex = 0
        Me.chkboolProxy.Text = "Kết nối Internet thông qua Proxy"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add (Me.cmdConnection)
        Me.GroupBox1.Controls.Add (Me.Label1)
        Me.GroupBox1.Controls.Add (Me.txtConnection)
        Me.GroupBox1.Controls.Add (Me.txtTimeInterval)
        Me.GroupBox1.Controls.Add (Me.Label3)
        Me.GroupBox1.Controls.Add (Me.Label2)
        Me.GroupBox1.Controls.Add (Me.txtWebPath)
        Me.GroupBox1.Controls.Add (Me.Label4)
        Me.GroupBox1.Font = _
            New System.Drawing.Font ("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, _
                                     System.Drawing.GraphicsUnit.Point, CType (0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point (0, 232)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size (424, 160)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Service setting"
        '
        'cmdConnection
        '
        Me.cmdConnection.Location = New System.Drawing.Point (392, 72)
        Me.cmdConnection.Name = "cmdConnection"
        Me.cmdConnection.Size = New System.Drawing.Size (24, 23)
        Me.cmdConnection.TabIndex = 2
        Me.cmdConnection.Text = "..."
        '
        'Label1
        '
        Me.Label1.Font = _
            New System.Drawing.Font ("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, _
                                     System.Drawing.GraphicsUnit.Point, CType (0, Byte))
        Me.Label1.Location = New System.Drawing.Point (8, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size (100, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Connection string"
        '
        'txtConnection
        '
        Me.txtConnection.Font = _
            New System.Drawing.Font ("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, _
                                     System.Drawing.GraphicsUnit.Point, CType (0, Byte))
        Me.txtConnection.Location = New System.Drawing.Point (8, 72)
        Me.txtConnection.Name = "txtConnection"
        Me.txtConnection.Size = New System.Drawing.Size (384, 20)
        Me.txtConnection.TabIndex = 0
        Me.txtConnection.Text = ""
        '
        'txtTimeInterval
        '
        Me.txtTimeInterval.Font = _
            New System.Drawing.Font ("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, _
                                     System.Drawing.GraphicsUnit.Point, CType (0, Byte))
        Me.txtTimeInterval.Location = New System.Drawing.Point (136, 24)
        Me.txtTimeInterval.Name = "txtTimeInterval"
        Me.txtTimeInterval.Size = New System.Drawing.Size (104, 20)
        Me.txtTimeInterval.TabIndex = 0
        Me.txtTimeInterval.Text = "10"
        Me.txtTimeInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.Font = _
            New System.Drawing.Font ("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, _
                                     System.Drawing.GraphicsUnit.Point, CType (0, Byte))
        Me.Label3.Location = New System.Drawing.Point (248, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size (56, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "(Minute)"
        '
        'Label2
        '
        Me.Label2.Font = _
            New System.Drawing.Font ("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, _
                                     System.Drawing.GraphicsUnit.Point, CType (0, Byte))
        Me.Label2.Location = New System.Drawing.Point (8, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size (120, 23)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Scanning time interval"
        '
        'txtWebPath
        '
        Me.txtWebPath.Font = _
            New System.Drawing.Font ("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, _
                                     System.Drawing.GraphicsUnit.Point, CType (0, Byte))
        Me.txtWebPath.Location = New System.Drawing.Point (8, 128)
        Me.txtWebPath.Name = "txtWebPath"
        Me.txtWebPath.Size = New System.Drawing.Size (408, 20)
        Me.txtWebPath.TabIndex = 0
        Me.txtWebPath.Text = "C:\Inetpub\wwwroot\InternetNews"
        '
        'Label4
        '
        Me.Label4.Font = _
            New System.Drawing.Font ("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, _
                                     System.Drawing.GraphicsUnit.Point, CType (0, Byte))
        Me.Label4.Location = New System.Drawing.Point (8, 104)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size (56, 16)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Web Path"
        '
        'frmSetting
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size (5, 13)
        Me.ClientSize = New System.Drawing.Size (424, 431)
        Me.Controls.Add (Me.GroupBox1)
        Me.Controls.Add (Me.grpProxy)
        Me.Controls.Add (Me.grpInternetProxyPara)
        Me.Controls.Add (Me.cmdCancel)
        Me.Controls.Add (Me.cmdOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType (resources.GetObject ("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmSetting"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "System setting"
        Me.grpProxy.ResumeLayout (False)
        Me.grpInternetProxyPara.ResumeLayout (False)
        Me.GroupBox1.ResumeLayout (False)
        Me.ResumeLayout (False)

    End Sub

#End Region

    Private Sub cmdCancel_Click (ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub cmdConnection_Click (ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles cmdConnection.Click
        Dim Instance As DataLinksClass = New DataLinksClass
        Dim connection As ConnectionClass = New ConnectionClass
        If (Instance.PromptEdit (connection)) Then
            txtConnection.Text = connection.ConnectionString
        End If
        connection = Nothing
        Instance = Nothing
    End Sub

    Private Sub cmdOK_Click (ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        Dim objReg As New VNN_WEBEXTRACTOR.MyRegistry
        With objReg
            .boolProxy = chkboolProxy.Checked
            .strProxyAddress = txtProxyAddress.Text.Trim
            .strProxyPort = txtProxyPort.Text.Trim
            .strUserName = txtUserName.Text.Trim
            .strPassword = txtPassword.Text.Trim
            .strDomain = txtDomain.Text.Trim
            .strConnection = txtConnection.Text.Trim
            .intTimeInterval = Integer.Parse (txtTimeInterval.Text.Trim)
            .strWebPath = txtWebPath.Text.Trim
        End With
        objReg.SaveRegs()
        objReg = Nothing
        MessageBox.Show ("You must restart service to apply new setting", WEBEXTRACTOR.MY_NOTICE_TITLE, _
                         MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Me.Close()
    End Sub

    Private Sub frmSetting_Load (ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim objReg As New VNN_WEBEXTRACTOR.MyRegistry
        objReg.getRegs()
        With objReg
            txtProxyAddress.Text = .strProxyAddress
            txtProxyPort.Text = .strProxyPort
            chkboolProxy.Checked = .boolProxy
            txtUserName.Text = .strUserName
            txtPassword.Text = .strPassword
            txtDomain.Text = .strDomain
            txtConnection.Text = .strConnection
            txtTimeInterval.Text = .intTimeInterval.ToString
            txtWebPath.Text = .strWebPath
        End With
        If chkboolProxy.Checked Then
            txtProxyAddress.Enabled = True
            txtProxyPort.Enabled = True
        Else
            txtProxyAddress.Enabled = False
            txtProxyPort.Enabled = False
        End If
        objReg = Nothing
    End Sub

    Private Sub chkboolProxy_CheckedChanged (ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles chkboolProxy.CheckedChanged
        If chkboolProxy.Checked Then
            txtProxyAddress.Enabled = True
            txtProxyPort.Enabled = True
        Else
            txtProxyAddress.Enabled = False
            txtProxyPort.Enabled = False
        End If
    End Sub
End Class
