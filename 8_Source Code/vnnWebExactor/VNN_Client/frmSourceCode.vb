Imports VNN_WEBEXTRACTOR

Public Class frmSourceCode
    Inherits System.Windows.Forms.Form

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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdStart As System.Windows.Forms.Button
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents txtChannel As System.Windows.Forms.TextBox
    Friend WithEvents txtSourceCode As System.Windows.Forms.TextBox

    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim _
            resources As System.Resources.ResourceManager = _
                New System.Resources.ResourceManager(GetType(frmSourceCode))
        Me.txtChannel = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtSourceCode = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmdStart = New System.Windows.Forms.Button
        Me.cmdClose = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'txtChannel
        '
        Me.txtChannel.Location = New System.Drawing.Point(0, 32)
        Me.txtChannel.Name = "txtChannel"
        Me.txtChannel.Size = New System.Drawing.Size(624, 20)
        Me.txtChannel.TabIndex = 0
        Me.txtChannel.Text = ""
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(0, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Data Channel"
        '
        'txtSourceCode
        '
        Me.txtSourceCode.Location = New System.Drawing.Point(0, 80)
        Me.txtSourceCode.Multiline = True
        Me.txtSourceCode.Name = "txtSourceCode"
        Me.txtSourceCode.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtSourceCode.Size = New System.Drawing.Size(624, 360)
        Me.txtSourceCode.TabIndex = 3
        Me.txtSourceCode.Text = ""
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(0, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 16)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Source code"
        '
        'cmdStart
        '
        Me.cmdStart.Location = New System.Drawing.Point(472, 448)
        Me.cmdStart.Name = "cmdStart"
        Me.cmdStart.TabIndex = 4
        Me.cmdStart.Text = "&Start"
        '
        'cmdClose
        '
        Me.cmdClose.Location = New System.Drawing.Point(552, 448)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.TabIndex = 5
        Me.cmdClose.Text = "&Close"
        '
        'frmSourceCode
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(632, 477)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.cmdStart)
        Me.Controls.Add(Me.txtSourceCode)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtChannel)
        Me.Controls.Add(Me.Label3)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSourceCode"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Web navigation"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub cmdStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdStart.Click
        Try
            Dim objExtractor As New Extractor
            txtSourceCode.Text = objExtractor.gettingTestSource(txtChannel.Text.Trim)
            MessageBox.Show("Finished!", WEBEXTRACTOR.MY_NOTICE_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Information)
            objExtractor = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.Message, WEBEXTRACTOR.MY_NOTICE_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
