Imports VNN_WEBEXTRACTOR

Public Class frmTest
    Inherits System.Windows.Forms.Form
    Private objWebCols As Collection

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
    Friend WithEvents drSources As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtResult As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents cmdStart As System.Windows.Forms.Button

    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmTest))
        Me.drSources = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtResult = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmdClose = New System.Windows.Forms.Button
        Me.cmdStart = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'drSources
        '
        Me.drSources.Location = New System.Drawing.Point(104, 8)
        Me.drSources.Name = "drSources"
        Me.drSources.Size = New System.Drawing.Size(576, 21)
        Me.drSources.TabIndex = 0
        Me.drSources.Text = "ComboBox1"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(24, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Data channel"
        '
        'txtResult
        '
        Me.txtResult.Location = New System.Drawing.Point(104, 40)
        Me.txtResult.Multiline = True
        Me.txtResult.Name = "txtResult"
        Me.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtResult.Size = New System.Drawing.Size(576, 416)
        Me.txtResult.TabIndex = 2
        Me.txtResult.Text = ""
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(24, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 23)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Result"
        '
        'cmdClose
        '
        Me.cmdClose.Location = New System.Drawing.Point(608, 464)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.TabIndex = 4
        Me.cmdClose.Text = "&Close"
        '
        'cmdStart
        '
        Me.cmdStart.Location = New System.Drawing.Point(528, 464)
        Me.cmdStart.Name = "cmdStart"
        Me.cmdStart.TabIndex = 5
        Me.cmdStart.Text = "&Start"
        '
        'frmTest
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(688, 493)
        Me.Controls.Add(Me.cmdStart)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtResult)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.drSources)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTest"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Manual testing for data extraction"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub cmdStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdStart.Click
        Dim objExtractor As New Extractor
        Try
            objExtractor.initDataConnection(WEBEXTRACTOR.objConn.getConnection)
            objWebCols = objExtractor.doManualExtract(drSources.Text)
            objExtractor = Nothing
            Call displayNewsItem()
            MessageBox.Show("Finished", WEBEXTRACTOR.MY_NOTICE_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, WEBEXTRACTOR.MY_NOTICE_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub displayNewsItem()
        txtResult.Text = ""
        For i As Integer = 1 To objWebCols.Count
            txtResult.Text += "============NEWS ITEM COLLECTED==========" & vbCrLf & vbCrLf
            txtResult.Text += "TITLE: " & CType(objWebCols(i), VNN_WEBEXTRACTOR.WebContentInfor).Title & vbCrLf & _
                              vbCrLf
            txtResult.Text += "URL: " & CType(objWebCols(i), VNN_WEBEXTRACTOR.WebContentInfor).Href & vbCrLf & vbCrLf
            txtResult.Text += "DESCRIPTION: " & CType(objWebCols(i), VNN_WEBEXTRACTOR.WebContentInfor).Description & _
                              vbCrLf & vbCrLf
            txtResult.Text += "CONTENT: " & CType(objWebCols(i), VNN_WEBEXTRACTOR.WebContentInfor).Content & vbCrLf & _
                              vbCrLf
        Next
        For i As Integer = objWebCols.Count To 1 Step -1
            objWebCols.Remove(i)
        Next
    End Sub

    Private Sub loadSources()
        drSources.DataSource = _
            VNN_WEBEXTRACTOR.Data.SourceController.selectSources(WEBEXTRACTOR.objConn.getConnection, 0).Tables(0)
        drSources.DisplayMember = "Href"
    End Sub

    Private Sub frmTest_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loadSources()
    End Sub
End Class
