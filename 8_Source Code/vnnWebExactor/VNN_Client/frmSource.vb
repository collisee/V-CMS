Public Class frmSource
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
    Friend WithEvents dgrSources As System.Windows.Forms.DataGrid
    Friend WithEvents drCategory As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdAddNew As System.Windows.Forms.Button
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn3 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn4 As System.Windows.Forms.DataGridTextBoxColumn

    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager (GetType (frmSource))
        Me.dgrSources = New System.Windows.Forms.DataGrid
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle
        Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn3 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn4 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.drCategory = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdAddNew = New System.Windows.Forms.Button
        Me.cmdClose = New System.Windows.Forms.Button
        CType (Me.dgrSources, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgrSources
        '
        Me.dgrSources.CaptionText = "List of data channels"
        Me.dgrSources.DataMember = ""
        Me.dgrSources.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgrSources.Location = New System.Drawing.Point (0, 40)
        Me.dgrSources.Name = "dgrSources"
        Me.dgrSources.Size = New System.Drawing.Size (552, 272)
        Me.dgrSources.TabIndex = 0
        Me.dgrSources.TableStyles.AddRange (New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.dgrSources
        Me.DataGridTableStyle1.GridColumnStyles.AddRange ( _
                                                          New System.Windows.Forms.DataGridColumnStyle() _
                                                             {Me.DataGridTextBoxColumn1, Me.DataGridTextBoxColumn2, _
                                                              Me.DataGridTextBoxColumn3, Me.DataGridTextBoxColumn4})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "Table"
        Me.DataGridTableStyle1.ReadOnly = True
        '
        'DataGridTextBoxColumn1
        '
        Me.DataGridTextBoxColumn1.Format = ""
        Me.DataGridTextBoxColumn1.FormatInfo = Nothing
        Me.DataGridTextBoxColumn1.MappingName = "ID"
        Me.DataGridTextBoxColumn1.Width = 0
        '
        'DataGridTextBoxColumn2
        '
        Me.DataGridTextBoxColumn2.Format = ""
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.HeaderText = "Href"
        Me.DataGridTextBoxColumn2.MappingName = "Href"
        Me.DataGridTextBoxColumn2.Width = 250
        '
        'DataGridTextBoxColumn3
        '
        Me.DataGridTextBoxColumn3.Format = ""
        Me.DataGridTextBoxColumn3.FormatInfo = Nothing
        Me.DataGridTextBoxColumn3.HeaderText = "Source"
        Me.DataGridTextBoxColumn3.MappingName = "Source"
        Me.DataGridTextBoxColumn3.Width = 75
        '
        'DataGridTextBoxColumn4
        '
        Me.DataGridTextBoxColumn4.Format = ""
        Me.DataGridTextBoxColumn4.FormatInfo = Nothing
        Me.DataGridTextBoxColumn4.HeaderText = "Description"
        Me.DataGridTextBoxColumn4.MappingName = "Description"
        Me.DataGridTextBoxColumn4.Width = 200
        '
        'drCategory
        '
        Me.drCategory.Location = New System.Drawing.Point (64, 16)
        Me.drCategory.Name = "drCategory"
        Me.drCategory.Size = New System.Drawing.Size (488, 21)
        Me.drCategory.TabIndex = 1
        Me.drCategory.Text = "ComboBox1"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point (8, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size (56, 16)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Category"
        '
        'cmdAddNew
        '
        Me.cmdAddNew.Location = New System.Drawing.Point (392, 320)
        Me.cmdAddNew.Name = "cmdAddNew"
        Me.cmdAddNew.TabIndex = 3
        Me.cmdAddNew.Text = "&Add New"
        '
        'cmdClose
        '
        Me.cmdClose.Location = New System.Drawing.Point (472, 320)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.TabIndex = 4
        Me.cmdClose.Text = "&Close"
        '
        'frmSource
        '
        Me.AcceptButton = Me.cmdClose
        Me.AutoScaleBaseSize = New System.Drawing.Size (5, 13)
        Me.ClientSize = New System.Drawing.Size (552, 349)
        Me.Controls.Add (Me.cmdClose)
        Me.Controls.Add (Me.cmdAddNew)
        Me.Controls.Add (Me.Label1)
        Me.Controls.Add (Me.drCategory)
        Me.Controls.Add (Me.dgrSources)
        Me.Icon = CType (resources.GetObject ("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSource"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Edit data channel"
        CType (Me.dgrSources, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout (False)

    End Sub

#End Region

    Private Sub frmSource_Load (ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadCategories()
    End Sub

    Private Sub cmdClose_Click (ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub LoadCategories()
        Dim objCat As VNN_WEBEXTRACTOR.Data.CategoryInfor
        Dim objDS As DataSet

        objCat = New VNN_WEBEXTRACTOR.Data.CategoryInfor
        objCat._ID = 0
        objCat._Name = "All categories ..."
        drCategory.Items.Add (objCat)

        objDS = VNN_WEBEXTRACTOR.Data.CategoryController.selectCategories (WEBEXTRACTOR.objConn.getConnection)
        For i As Integer = 0 To objDS.Tables (0).Rows.Count - 1
            objCat = New VNN_WEBEXTRACTOR.Data.CategoryInfor
            objCat._ID = objDS.Tables (0).Rows (i).Item ("ID")
            objCat._Name = objDS.Tables (0).Rows (i).Item ("Name")
            drCategory.Items.Add (objCat)
        Next
        drCategory.SelectedIndex = 0
    End Sub

    Private Sub drCategory_SelectedIndexChanged (ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles drCategory.SelectedIndexChanged
        Dim intCatID As Integer
        intCatID = CType (drCategory.SelectedItem, VNN_WEBEXTRACTOR.Data.CategoryInfor)._ID
        LoadSources (intCatID)
    End Sub

    Private Sub LoadSources (ByVal CategoryID As Integer)
        Dim objDS As New DataSet
        objDS = VNN_WEBEXTRACTOR.Data.SourceController.selectSources (WEBEXTRACTOR.objConn.getConnection, CategoryID)
        dgrSources.SetDataBinding (objDS, "Table")
    End Sub

    Private Sub cmdAddNew_Click (ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddNew.Click
        Dim frmAdd As New frmSourceEdit
        frmAdd.strCategoryName = drCategory.Text
        frmAdd.ShowDialog()
        frmAdd = Nothing
        LoadSources (CType (drCategory.SelectedItem, VNN_WEBEXTRACTOR.Data.CategoryInfor)._ID)
    End Sub

    Private Sub dgrSources_DoubleClick (ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles dgrSources.DoubleClick
        Dim intSourceID As Integer
        Dim frmAdd As New frmSourceEdit
        If IsNumeric (dgrSources.Item (dgrSources.CurrentRowIndex, 0)) Then
            intSourceID = CType (dgrSources.Item (dgrSources.CurrentRowIndex, 0), Integer)
            frmAdd.strCategoryName = drCategory.Text
            frmAdd.intSourceID = intSourceID
            frmAdd.ShowDialog()
            frmAdd = Nothing
            LoadSources (CType (drCategory.SelectedItem, VNN_WEBEXTRACTOR.Data.CategoryInfor)._ID)
        End If
    End Sub
End Class
