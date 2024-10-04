Imports VNN_WEBEXTRACTOR

Public Class frmSourceEdit
    Inherits System.Windows.Forms.Form
    Public strCategoryName As String = ""
    Public intSourceID As Integer = - 1

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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtHref As System.Windows.Forms.TextBox
    Friend WithEvents txtStartTags As System.Windows.Forms.TextBox
    Friend WithEvents txtEndTags As System.Windows.Forms.TextBox
    Friend WithEvents txtTitleStartTags As System.Windows.Forms.TextBox
    Friend WithEvents txtTitleEndTags As System.Windows.Forms.TextBox
    Friend WithEvents txtDescStartTags As System.Windows.Forms.TextBox
    Friend WithEvents txtDescEndTags As System.Windows.Forms.TextBox
    Friend WithEvents txtContentStartTags As System.Windows.Forms.TextBox
    Friend WithEvents txtContentEndTags As System.Windows.Forms.TextBox
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents txtSource As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents drCategory As System.Windows.Forms.ComboBox
    Friend WithEvents cmdUpdate As System.Windows.Forms.Button
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents rbNews As System.Windows.Forms.RadioButton
    Friend WithEvents rbNotNews As System.Windows.Forms.RadioButton
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents chkImgPath As System.Windows.Forms.CheckBox
    Friend WithEvents txtImagePath As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtImageDirectory As System.Windows.Forms.TextBox
    Friend WithEvents txtStartNewsHref As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label

    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim _
            resources As System.Resources.ResourceManager = _
                New System.Resources.ResourceManager (GetType (frmSourceEdit))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtStartNewsHref = New System.Windows.Forms.TextBox
        Me.txtImageDirectory = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.chkImgPath = New System.Windows.Forms.CheckBox
        Me.txtImagePath = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.rbNotNews = New System.Windows.Forms.RadioButton
        Me.rbNews = New System.Windows.Forms.RadioButton
        Me.drCategory = New System.Windows.Forms.ComboBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtHref = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtStartTags = New System.Windows.Forms.TextBox
        Me.txtEndTags = New System.Windows.Forms.TextBox
        Me.txtTitleStartTags = New System.Windows.Forms.TextBox
        Me.txtTitleEndTags = New System.Windows.Forms.TextBox
        Me.txtDescStartTags = New System.Windows.Forms.TextBox
        Me.txtDescEndTags = New System.Windows.Forms.TextBox
        Me.txtContentStartTags = New System.Windows.Forms.TextBox
        Me.txtContentEndTags = New System.Windows.Forms.TextBox
        Me.txtDescription = New System.Windows.Forms.TextBox
        Me.txtSource = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.cmdUpdate = New System.Windows.Forms.Button
        Me.cmdDelete = New System.Windows.Forms.Button
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
        Me.cmdClose = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox1.Controls.Add (Me.Label16)
        Me.GroupBox1.Controls.Add (Me.txtStartNewsHref)
        Me.GroupBox1.Controls.Add (Me.txtImageDirectory)
        Me.GroupBox1.Controls.Add (Me.Label15)
        Me.GroupBox1.Controls.Add (Me.chkImgPath)
        Me.GroupBox1.Controls.Add (Me.txtImagePath)
        Me.GroupBox1.Controls.Add (Me.Label14)
        Me.GroupBox1.Controls.Add (Me.rbNotNews)
        Me.GroupBox1.Controls.Add (Me.rbNews)
        Me.GroupBox1.Controls.Add (Me.drCategory)
        Me.GroupBox1.Controls.Add (Me.Label12)
        Me.GroupBox1.Controls.Add (Me.Label2)
        Me.GroupBox1.Controls.Add (Me.txtHref)
        Me.GroupBox1.Controls.Add (Me.Label1)
        Me.GroupBox1.Controls.Add (Me.Label3)
        Me.GroupBox1.Controls.Add (Me.Label4)
        Me.GroupBox1.Controls.Add (Me.Label5)
        Me.GroupBox1.Controls.Add (Me.Label6)
        Me.GroupBox1.Controls.Add (Me.Label7)
        Me.GroupBox1.Controls.Add (Me.Label8)
        Me.GroupBox1.Controls.Add (Me.Label9)
        Me.GroupBox1.Controls.Add (Me.Label10)
        Me.GroupBox1.Controls.Add (Me.Label11)
        Me.GroupBox1.Controls.Add (Me.txtStartTags)
        Me.GroupBox1.Controls.Add (Me.txtEndTags)
        Me.GroupBox1.Controls.Add (Me.txtTitleStartTags)
        Me.GroupBox1.Controls.Add (Me.txtTitleEndTags)
        Me.GroupBox1.Controls.Add (Me.txtDescStartTags)
        Me.GroupBox1.Controls.Add (Me.txtDescEndTags)
        Me.GroupBox1.Controls.Add (Me.txtContentStartTags)
        Me.GroupBox1.Controls.Add (Me.txtContentEndTags)
        Me.GroupBox1.Controls.Add (Me.txtDescription)
        Me.GroupBox1.Controls.Add (Me.txtSource)
        Me.GroupBox1.Controls.Add (Me.Label13)
        Me.GroupBox1.Location = New System.Drawing.Point (0, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size (712, 510)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Infromation Source Edit"
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point (8, 56)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size (88, 23)
        Me.Label16.TabIndex = 14
        Me.Label16.Text = "Start News URL"
        '
        'txtStartNewsHref
        '
        Me.txtStartNewsHref.Location = New System.Drawing.Point (104, 56)
        Me.txtStartNewsHref.Name = "txtStartNewsHref"
        Me.txtStartNewsHref.Size = New System.Drawing.Size (248, 20)
        Me.txtStartNewsHref.TabIndex = 1
        Me.txtStartNewsHref.Text = ""
        '
        'txtImageDirectory
        '
        Me.txtImageDirectory.Location = New System.Drawing.Point (416, 448)
        Me.txtImageDirectory.Name = "txtImageDirectory"
        Me.txtImageDirectory.Size = New System.Drawing.Size (264, 20)
        Me.txtImageDirectory.TabIndex = 16
        Me.txtImageDirectory.Text = ""
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point (416, 432)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size (280, 16)
        Me.Label15.TabIndex = 11
        Me.Label15.Text = "Physical image holding directory name (Just name)"
        '
        'chkImgPath
        '
        Me.chkImgPath.Location = New System.Drawing.Point (104, 424)
        Me.chkImgPath.Name = "chkImgPath"
        Me.chkImgPath.Size = New System.Drawing.Size (264, 24)
        Me.chkImgPath.TabIndex = 14
        Me.chkImgPath.Text = "Image path is the same as news' detail URL"
        '
        'txtImagePath
        '
        Me.txtImagePath.Location = New System.Drawing.Point (104, 448)
        Me.txtImagePath.Name = "txtImagePath"
        Me.txtImagePath.Size = New System.Drawing.Size (280, 20)
        Me.txtImagePath.TabIndex = 15
        Me.txtImagePath.Text = ""
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point (32, 448)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size (64, 16)
        Me.Label14.TabIndex = 8
        Me.Label14.Text = "Image path"
        '
        'rbNotNews
        '
        Me.rbNotNews.Location = New System.Drawing.Point (224, 400)
        Me.rbNotNews.Name = "rbNotNews"
        Me.rbNotNews.Size = New System.Drawing.Size (136, 24)
        Me.rbNotNews.TabIndex = 13
        Me.rbNotNews.Text = "Not News information"
        '
        'rbNews
        '
        Me.rbNews.Checked = True
        Me.rbNews.Location = New System.Drawing.Point (104, 400)
        Me.rbNews.Name = "rbNews"
        Me.rbNews.Size = New System.Drawing.Size (112, 24)
        Me.rbNews.TabIndex = 12
        Me.rbNews.TabStop = True
        Me.rbNews.Text = "News information"
        '
        'drCategory
        '
        Me.drCategory.Location = New System.Drawing.Point (104, 480)
        Me.drCategory.Name = "drCategory"
        Me.drCategory.Size = New System.Drawing.Size (600, 21)
        Me.drCategory.TabIndex = 17
        Me.drCategory.Text = "ComboBox1"
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label12.Location = New System.Drawing.Point (0, 392)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size (728, 2)
        Me.Label12.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point (8, 120)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size (64, 23)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Start Tags"
        '
        'txtHref
        '
        Me.txtHref.Location = New System.Drawing.Point (104, 24)
        Me.txtHref.Name = "txtHref"
        Me.txtHref.Size = New System.Drawing.Size (248, 20)
        Me.txtHref.TabIndex = 0
        Me.txtHref.Text = "http://"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point (8, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size (72, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "URL Address"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point (8, 176)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size (64, 23)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "End Tags"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point (8, 248)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size (88, 23)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Title Start Tags"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point (32, 480)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size (56, 23)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Category"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point (392, 24)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size (72, 24)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Desciption Start Tags"
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point (392, 96)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size (64, 32)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Desciption End Tags"
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point (392, 168)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size (64, 40)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "Content Start Tags"
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point (392, 248)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size (64, 32)
        Me.Label9.TabIndex = 2
        Me.Label9.Text = "Content End Tags"
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point (392, 320)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size (64, 23)
        Me.Label10.TabIndex = 2
        Me.Label10.Text = "Description"
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point (8, 88)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size (56, 23)
        Me.Label11.TabIndex = 2
        Me.Label11.Text = "Source"
        '
        'txtStartTags
        '
        Me.txtStartTags.Location = New System.Drawing.Point (104, 120)
        Me.txtStartTags.Multiline = True
        Me.txtStartTags.Name = "txtStartTags"
        Me.txtStartTags.Size = New System.Drawing.Size (248, 56)
        Me.txtStartTags.TabIndex = 3
        Me.txtStartTags.Text = ""
        '
        'txtEndTags
        '
        Me.txtEndTags.Location = New System.Drawing.Point (104, 184)
        Me.txtEndTags.Multiline = True
        Me.txtEndTags.Name = "txtEndTags"
        Me.txtEndTags.Size = New System.Drawing.Size (248, 56)
        Me.txtEndTags.TabIndex = 4
        Me.txtEndTags.Text = ""
        '
        'txtTitleStartTags
        '
        Me.txtTitleStartTags.Location = New System.Drawing.Point (104, 248)
        Me.txtTitleStartTags.Multiline = True
        Me.txtTitleStartTags.Name = "txtTitleStartTags"
        Me.txtTitleStartTags.Size = New System.Drawing.Size (248, 64)
        Me.txtTitleStartTags.TabIndex = 5
        Me.txtTitleStartTags.Text = ""
        '
        'txtTitleEndTags
        '
        Me.txtTitleEndTags.Location = New System.Drawing.Point (104, 320)
        Me.txtTitleEndTags.Multiline = True
        Me.txtTitleEndTags.Name = "txtTitleEndTags"
        Me.txtTitleEndTags.Size = New System.Drawing.Size (248, 64)
        Me.txtTitleEndTags.TabIndex = 6
        Me.txtTitleEndTags.Text = ""
        '
        'txtDescStartTags
        '
        Me.txtDescStartTags.Location = New System.Drawing.Point (480, 24)
        Me.txtDescStartTags.Multiline = True
        Me.txtDescStartTags.Name = "txtDescStartTags"
        Me.txtDescStartTags.Size = New System.Drawing.Size (224, 64)
        Me.txtDescStartTags.TabIndex = 7
        Me.txtDescStartTags.Text = ""
        '
        'txtDescEndTags
        '
        Me.txtDescEndTags.Location = New System.Drawing.Point (480, 96)
        Me.txtDescEndTags.Multiline = True
        Me.txtDescEndTags.Name = "txtDescEndTags"
        Me.txtDescEndTags.Size = New System.Drawing.Size (224, 64)
        Me.txtDescEndTags.TabIndex = 8
        Me.txtDescEndTags.Text = ""
        '
        'txtContentStartTags
        '
        Me.txtContentStartTags.Location = New System.Drawing.Point (480, 168)
        Me.txtContentStartTags.Multiline = True
        Me.txtContentStartTags.Name = "txtContentStartTags"
        Me.txtContentStartTags.Size = New System.Drawing.Size (224, 64)
        Me.txtContentStartTags.TabIndex = 9
        Me.txtContentStartTags.Text = ""
        '
        'txtContentEndTags
        '
        Me.txtContentEndTags.Location = New System.Drawing.Point (480, 240)
        Me.txtContentEndTags.Multiline = True
        Me.txtContentEndTags.Name = "txtContentEndTags"
        Me.txtContentEndTags.Size = New System.Drawing.Size (224, 64)
        Me.txtContentEndTags.TabIndex = 10
        Me.txtContentEndTags.Text = ""
        '
        'txtDescription
        '
        Me.txtDescription.Location = New System.Drawing.Point (480, 312)
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size (224, 72)
        Me.txtDescription.TabIndex = 11
        Me.txtDescription.Text = ""
        '
        'txtSource
        '
        Me.txtSource.Location = New System.Drawing.Point (104, 88)
        Me.txtSource.Name = "txtSource"
        Me.txtSource.Size = New System.Drawing.Size (248, 20)
        Me.txtSource.TabIndex = 2
        Me.txtSource.Text = ""
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point (8, 320)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size (88, 23)
        Me.Label13.TabIndex = 2
        Me.Label13.Text = "Title End Tags"
        '
        'cmdUpdate
        '
        Me.cmdUpdate.Location = New System.Drawing.Point (472, 520)
        Me.cmdUpdate.Name = "cmdUpdate"
        Me.cmdUpdate.Size = New System.Drawing.Size (75, 24)
        Me.cmdUpdate.TabIndex = 0
        Me.cmdUpdate.Text = "&Update"
        '
        'cmdDelete
        '
        Me.cmdDelete.Location = New System.Drawing.Point (552, 520)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size (75, 24)
        Me.cmdDelete.TabIndex = 1
        Me.cmdDelete.Text = "&Delete"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'cmdClose
        '
        Me.cmdClose.Location = New System.Drawing.Point (632, 520)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size (75, 24)
        Me.cmdClose.TabIndex = 2
        Me.cmdClose.Text = "&Close"
        '
        'frmSourceEdit
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size (5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size (712, 549)
        Me.Controls.Add (Me.cmdDelete)
        Me.Controls.Add (Me.cmdUpdate)
        Me.Controls.Add (Me.GroupBox1)
        Me.Controls.Add (Me.cmdClose)
        Me.Icon = CType (resources.GetObject ("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSourceEdit"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Infromation Source Editting"
        Me.GroupBox1.ResumeLayout (False)
        Me.ResumeLayout (False)

    End Sub

#End Region

    Private Sub LoadCategories()
        Dim objCat As VNN_WEBEXTRACTOR.data.CategoryInfor
        Dim objDS As DataSet

        objDS = VNN_WEBEXTRACTOR.Data.CategoryController.selectCategories (WEBEXTRACTOR.objConn.getConnection)
        For i As Integer = 0 To objDS.Tables (0).Rows.Count - 1
            objCat = New VNN_WEBEXTRACTOR.Data.CategoryInfor
            objCat._ID = objDS.Tables (0).Rows (i).Item ("ID")
            objCat._Name = objDS.Tables (0).Rows (i).Item ("Name")
            drCategory.Items.Add (objCat)
            If objCat._Name = strCategoryName Then
                drCategory.Text = strCategoryName
            End If
        Next

        If strCategoryName = "All categories ..." Then
            drCategory.SelectedIndex = 0
        End If

    End Sub

    Private Sub frmSourceEdit_Load (ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadCategories()
        If intSourceID <> - 1 Then
            LoadOldData()
        End If

    End Sub

    Private Sub LoadOldData()
        Dim objSource As New VNN_WEBEXTRACTOR.Data.SourceInfor
        objSource = _
            VNN_WEBEXTRACTOR.Data.SourceController.selectSource (WEBEXTRACTOR.objConn.getConnection, intSourceID)
        With objSource
            txtHref.Text = ._Href.Trim
            txtStartTags.Text = ._StartTags.Trim
            txtEndTags.Text = ._EndTags.Trim
            txtTitleStartTags.Text = ._TitleStartTags.Trim
            txtTitleEndTags.Text = ._TitleEndTags.Trim
            txtDescStartTags.Text = ._DescStartTags.Trim
            txtDescEndTags.Text = ._DescEndTags.Trim
            txtContentStartTags.Text = ._ContentStartTags.Trim
            txtContentEndTags.Text = ._ContentEndTags.Trim
            txtDescription.Text = ._Description.Trim
            txtSource.Text = ._Source.Trim
            txtImageDirectory.Text = ._ImageDirectory.Trim
            txtStartNewsHref.Text = ._StartNewsHref.Trim


            For i As Integer = 0 To drCategory.Items.Count - 1
                If CType (drCategory.Items.Item (i), VNN_WEBEXTRACTOR.Data.CategoryInfor)._ID = ._CategoryID Then
                    drCategory.SelectedIndex = i
                    Exit For
                End If
            Next

            If ._NewsFlag Then
                rbNews.Checked = True
            Else
                rbNotNews.Checked = True
            End If

            txtImagePath.Text = objSource._WholeImagePath.Trim
            If txtImagePath.Text.Trim = "VNN" Then
                chkImgPath.Checked = True
                txtImagePath.Enabled = False
            Else
                chkImgPath.Checked = False
                txtImagePath.Enabled = True
            End If

            objSource = Nothing

        End With
    End Sub

    Private Sub cmdUpdate_Click (ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
        If Not CheckDataForUpdate() Then
            Exit Sub
        End If

        Dim objSource As New VNN_WEBEXTRACTOR.Data.SourceInfor
        With objSource
            ._ID = intSourceID
            ._Href = txtHref.Text.Trim
            ._StartTags = txtStartTags.Text.Trim
            ._EndTags = txtEndTags.Text.Trim
            ._TitleStartTags = txtTitleStartTags.Text.Trim
            ._TitleEndTags = txtTitleEndTags.Text.Trim
            ._DescStartTags = txtDescStartTags.Text.Trim
            ._DescEndTags = txtDescEndTags.Text.Trim
            ._ContentStartTags = txtContentStartTags.Text.Trim
            ._ContentEndTags = txtContentEndTags.Text.Trim
            ._Description = txtDescription.Text.Trim
            ._CategoryID = CType (drCategory.SelectedItem, VNN_WEBEXTRACTOR.Data.CategoryInfor)._ID
            ._Source = txtSource.Text.Trim
            ._WholeImagePath = txtImagePath.Text.Trim
            ._ImageDirectory = txtImageDirectory.Text.Trim
            ._StartNewsHref = txtStartNewsHref.Text.Trim

            If rbNews.Checked Then
                ._NewsFlag = True
            Else
                ._NewsFlag = False
            End If
        End With

        If intSourceID = - 1 Then
            'Insert new source channel 
            If _
                Not _
                VNN_WEBEXTRACTOR.Data.SourceController.isSourceHrefExisted (WEBEXTRACTOR.objConn.getConnection, _
                                                                            objSource._Href) Then
                VNN_WEBEXTRACTOR.Data.SourceController.InsertSource (WEBEXTRACTOR.objConn.getConnection, objSource)
            Else
                MessageBox.Show ("The Source Href is already existed!", WEBEXTRACTOR.MY_NOTICE_TITLE, _
                                 MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtHref.Select()
                Exit Sub
            End If
        Else
            'Update existing source channel
            If _
                Not _
                VNN_WEBEXTRACTOR.Data.SourceController.isSourceHrefExisted (WEBEXTRACTOR.objConn.getConnection, _
                                                                            objSource._Href, intSourceID) Then
                VNN_WEBEXTRACTOR.Data.SourceController.UpdateSource (WEBEXTRACTOR.objConn.getConnection, objSource)
            Else
                MessageBox.Show ("The Source Href is already existed!", WEBEXTRACTOR.MY_NOTICE_TITLE, _
                                 MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtHref.Select()
                Exit Sub
            End If
        End If
        Me.Close()
    End Sub

    Private Sub cmdDelete_Click (ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        If _
            MessageBox.Show ("Do you really want to delete this item ?", WEBEXTRACTOR.MY_NOTICE_TITLE, _
                             MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = DialogResult.OK Then
            VNN_WEBEXTRACTOR.Data.SourceController.DeleteSource (WEBEXTRACTOR.objConn.getConnection, intSourceID)
            Me.Close()
        End If
    End Sub

    'Check for data input
    Private Function CheckDataForUpdate() As Boolean
        Dim Flag As Boolean = True
        If txtHref.Text = "" Then
            ErrorProvider1.SetError (txtHref, "Href address can not be empty!")
            Flag = False
        Else
            ErrorProvider1.SetError (txtHref, "")
        End If
        If txtSource.Text = "" Then
            ErrorProvider1.SetError (txtSource, "Href address can not be empty!")
            Flag = False
        Else
            ErrorProvider1.SetError (txtSource, "")
        End If

        If txtImageDirectory.Text = "" Then
            ErrorProvider1.SetError (txtImageDirectory, "Image Direcory name can not be empty!")
            Flag = False
        Else
            ErrorProvider1.SetError (txtImageDirectory, "")
        End If

        If txtStartNewsHref.Text = "" Then
            ErrorProvider1.SetError (txtStartNewsHref, "Start news URL can not be empty!")
            Flag = False
        Else
            ErrorProvider1.SetError (txtStartNewsHref, "")
        End If

        Return Flag
    End Function

    Private Sub cmdClose_Click (ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub chkImgPath_CheckedChanged (ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles chkImgPath.CheckedChanged
        If chkImgPath.Checked Then
            txtImagePath.Text = "VNN"
            txtImagePath.Enabled = False
        Else
            txtImagePath.Text = ""
            txtImagePath.Enabled = True
        End If
    End Sub
End Class
