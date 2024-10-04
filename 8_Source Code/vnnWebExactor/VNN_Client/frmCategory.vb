Imports Microsoft.ApplicationBlocks.Data
Imports VNN_WEBEXTRACTOR

Public Class frmCategory
    Inherits System.Windows.Forms.Form
    Public intID As Integer = 0

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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents drDisplayPosition As System.Windows.Forms.ComboBox
    Friend WithEvents txtDisplayOrder As System.Windows.Forms.TextBox
    Friend WithEvents dgrCategory As System.Windows.Forms.DataGrid
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents cmdAddNew As System.Windows.Forms.Button
    Friend WithEvents cmdUpdate As System.Windows.Forms.Button
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn3 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn4 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn5 As System.Windows.Forms.DataGridTextBoxColumn

    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager (GetType (frmCategory))
        Me.dgrCategory = New System.Windows.Forms.DataGrid
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle
        Me.DataGridTextBoxColumn5 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn3 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn4 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtDisplayOrder = New System.Windows.Forms.TextBox
        Me.drDisplayPosition = New System.Windows.Forms.ComboBox
        Me.txtName = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtDescription = New System.Windows.Forms.TextBox
        Me.cmdClose = New System.Windows.Forms.Button
        Me.cmdDelete = New System.Windows.Forms.Button
        Me.cmdAddNew = New System.Windows.Forms.Button
        Me.cmdUpdate = New System.Windows.Forms.Button
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
        CType (Me.dgrCategory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgrCategory
        '
        Me.dgrCategory.CaptionBackColor = System.Drawing.SystemColors.HotTrack
        Me.dgrCategory.CaptionText = "Categories' List"
        Me.dgrCategory.DataMember = ""
        Me.dgrCategory.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgrCategory.Location = New System.Drawing.Point (0, 184)
        Me.dgrCategory.Name = "dgrCategory"
        Me.dgrCategory.Size = New System.Drawing.Size (544, 160)
        Me.dgrCategory.TabIndex = 0
        Me.dgrCategory.TableStyles.AddRange (New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.dgrCategory
        Me.DataGridTableStyle1.GridColumnStyles.AddRange ( _
                                                          New System.Windows.Forms.DataGridColumnStyle() _
                                                             {Me.DataGridTextBoxColumn5, Me.DataGridTextBoxColumn1, _
                                                              Me.DataGridTextBoxColumn2, Me.DataGridTextBoxColumn3, _
                                                              Me.DataGridTextBoxColumn4})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "Table"
        Me.DataGridTableStyle1.ReadOnly = True
        '
        'DataGridTextBoxColumn5
        '
        Me.DataGridTextBoxColumn5.Format = ""
        Me.DataGridTextBoxColumn5.FormatInfo = Nothing
        Me.DataGridTextBoxColumn5.HeaderText = "ID"
        Me.DataGridTextBoxColumn5.MappingName = "ID"
        Me.DataGridTextBoxColumn5.Width = 0
        '
        'DataGridTextBoxColumn1
        '
        Me.DataGridTextBoxColumn1.Format = ""
        Me.DataGridTextBoxColumn1.FormatInfo = Nothing
        Me.DataGridTextBoxColumn1.HeaderText = "Name"
        Me.DataGridTextBoxColumn1.MappingName = "Name"
        Me.DataGridTextBoxColumn1.ReadOnly = True
        Me.DataGridTextBoxColumn1.Width = 165
        '
        'DataGridTextBoxColumn2
        '
        Me.DataGridTextBoxColumn2.Format = ""
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.HeaderText = "Description"
        Me.DataGridTextBoxColumn2.MappingName = "Description"
        Me.DataGridTextBoxColumn2.ReadOnly = True
        Me.DataGridTextBoxColumn2.Width = 200
        '
        'DataGridTextBoxColumn3
        '
        Me.DataGridTextBoxColumn3.Format = ""
        Me.DataGridTextBoxColumn3.FormatInfo = Nothing
        Me.DataGridTextBoxColumn3.HeaderText = "Position"
        Me.DataGridTextBoxColumn3.MappingName = "DisplayPosition"
        Me.DataGridTextBoxColumn3.NullText = ""
        Me.DataGridTextBoxColumn3.ReadOnly = True
        Me.DataGridTextBoxColumn3.Width = 75
        '
        'DataGridTextBoxColumn4
        '
        Me.DataGridTextBoxColumn4.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn4.Format = ""
        Me.DataGridTextBoxColumn4.FormatInfo = Nothing
        Me.DataGridTextBoxColumn4.HeaderText = "Order"
        Me.DataGridTextBoxColumn4.MappingName = "DisplayOrder"
        Me.DataGridTextBoxColumn4.ReadOnly = True
        Me.DataGridTextBoxColumn4.Width = 50
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add (Me.txtDisplayOrder)
        Me.GroupBox1.Controls.Add (Me.drDisplayPosition)
        Me.GroupBox1.Controls.Add (Me.txtName)
        Me.GroupBox1.Controls.Add (Me.Label4)
        Me.GroupBox1.Controls.Add (Me.Label3)
        Me.GroupBox1.Controls.Add (Me.Label2)
        Me.GroupBox1.Controls.Add (Me.Label1)
        Me.GroupBox1.Controls.Add (Me.txtDescription)
        Me.GroupBox1.Location = New System.Drawing.Point (0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size (544, 144)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Category Edit"
        '
        'txtDisplayOrder
        '
        Me.txtDisplayOrder.Location = New System.Drawing.Point (392, 112)
        Me.txtDisplayOrder.Name = "txtDisplayOrder"
        Me.txtDisplayOrder.Size = New System.Drawing.Size (120, 20)
        Me.txtDisplayOrder.TabIndex = 6
        Me.txtDisplayOrder.Text = ""
        '
        'drDisplayPosition
        '
        Me.drDisplayPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.drDisplayPosition.Items.AddRange (New Object() {"Top", "Left", "Center", "Right", "Bottom"})
        Me.drDisplayPosition.Location = New System.Drawing.Point (128, 112)
        Me.drDisplayPosition.Name = "drDisplayPosition"
        Me.drDisplayPosition.Size = New System.Drawing.Size (136, 21)
        Me.drDisplayPosition.TabIndex = 5
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point (128, 24)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size (384, 20)
        Me.txtName.TabIndex = 4
        Me.txtName.Text = ""
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point (304, 112)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size (80, 23)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Display order"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point (16, 112)
        Me.Label3.Name = "Label3"
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Display position"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point (16, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Description"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point (16, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size (48, 23)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Name"
        '
        'txtDescription
        '
        Me.txtDescription.Location = New System.Drawing.Point (128, 48)
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size (384, 56)
        Me.txtDescription.TabIndex = 4
        Me.txtDescription.Text = ""
        '
        'cmdClose
        '
        Me.cmdClose.Location = New System.Drawing.Point (464, 352)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.TabIndex = 3
        Me.cmdClose.Text = "&Close"
        '
        'cmdDelete
        '
        Me.cmdDelete.Location = New System.Drawing.Point (464, 152)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.TabIndex = 4
        Me.cmdDelete.Text = "&Delete"
        '
        'cmdAddNew
        '
        Me.cmdAddNew.Location = New System.Drawing.Point (304, 152)
        Me.cmdAddNew.Name = "cmdAddNew"
        Me.cmdAddNew.TabIndex = 5
        Me.cmdAddNew.Text = "&Add New"
        '
        'cmdUpdate
        '
        Me.cmdUpdate.Location = New System.Drawing.Point (384, 152)
        Me.cmdUpdate.Name = "cmdUpdate"
        Me.cmdUpdate.TabIndex = 6
        Me.cmdUpdate.Text = "&Update"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'frmCategory
        '
        Me.AcceptButton = Me.cmdClose
        Me.AutoScaleBaseSize = New System.Drawing.Size (5, 13)
        Me.ClientSize = New System.Drawing.Size (544, 381)
        Me.Controls.Add (Me.cmdClose)
        Me.Controls.Add (Me.GroupBox1)
        Me.Controls.Add (Me.dgrCategory)
        Me.Controls.Add (Me.cmdAddNew)
        Me.Controls.Add (Me.cmdUpdate)
        Me.Controls.Add (Me.cmdDelete)
        Me.Icon = CType (resources.GetObject ("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCategory"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Edit Category "
        CType (Me.dgrCategory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout (False)
        Me.ResumeLayout (False)

    End Sub

#End Region

    Private Sub cmdClose_Click (ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    'Update data to database
    Private Sub cmdUpdate_Click (ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
        'If Not CheckDataForUpdate() Then
        '    Exit Sub
        'End If

        'Dim objCategory As New Data.CategoryInfor
        'With objCategory
        '    ._ID = intID
        '    ._Name = txtName.Text.Trim
        '    ._Description = txtDescription.Text.Trim
        '    ._DisplayPosition = drDisplayPosition.Text
        '    ._DisplayOrder = txtDisplayOrder.Text.Trim
        'End With

        'If Null.IsNull(intID) Then
        '    If Not VNN_WEBEXTRACTOR.Data.CategoryController.isCategoryNameExisted(WEBEXTRACTOR.objConn.getConnection, objCategory._Name) Then
        '        VNN_WEBEXTRACTOR.Data.CategoryController.InsertCategory(WEBEXTRACTOR.objConn.getConnection, objCategory)
        '    Else
        '        MessageBox.Show("The Category name is already existed!", WEBEXTRACTOR.MY_NOTICE_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error)
        '        txtName.Select()
        '        Exit Sub
        '    End If
        'Else
        '    If Not VNN_WEBEXTRACTOR.Data.CategoryController.isCategoryNameExisted(WEBEXTRACTOR.objConn.getConnection, objCategory._Name, intID) Then
        '        VNN_WEBEXTRACTOR.Data.CategoryController.UpdateCategory(WEBEXTRACTOR.objConn.getConnection, objCategory)
        '    Else
        '        MessageBox.Show("The Category name is already existed!", WEBEXTRACTOR.MY_NOTICE_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error)
        '        txtName.Select()
        '        Exit Sub
        '    End If
        'End If
        'intID = Null.NullInteger
        'clearEditForm()
        'cmdAddNew.Enabled = True
        'cmdDelete.Enabled = False
        'LoadCategories()
    End Sub

    'Check for data input
    Private Function CheckDataForUpdate() As Boolean
        Dim Flag As Boolean = True
        If Not IsNumeric (txtDisplayOrder.Text.Trim) Then
            ErrorProvider1.SetError (txtDisplayOrder, "Not a numeric value.")
            Flag = False
        Else
            ErrorProvider1.SetError (txtDisplayOrder, "")
        End If
        If txtName.Text.Trim = "" Then
            ErrorProvider1.SetError (txtName, "Name can not be empty.")
            Flag = False
        Else
            ErrorProvider1.SetError (txtName, "")
        End If
        If drDisplayPosition.SelectedIndex = - 1 Then
            ErrorProvider1.SetError (drDisplayPosition, "You must select a display position from list.")
            Flag = False
        Else
            ErrorProvider1.SetError (drDisplayPosition, "")
        End If

        Return Flag

    End Function

    'Clear the editting form
    Private Sub clearEditForm()
        txtName.Text = ""
        txtDescription.Text = ""
        drDisplayPosition.SelectedIndex = - 1
        txtDisplayOrder.Text = ""
        cmdUpdate.Enabled = False
        cmdAddNew.Enabled = True
    End Sub

    Private Sub cmdAddNew_Click (ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddNew.Click
        clearEditForm()
        cmdUpdate.Enabled = True
        cmdAddNew.Enabled = False
    End Sub

    Private Sub frmCategory_Load (ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmdUpdate.Enabled = False
        cmdDelete.Enabled = False
        LoadCategories()
    End Sub

    Private Sub LoadCategories()
        Dim objDS As New DataSet
        objDS = VNN_WEBEXTRACTOR.Data.CategoryController.selectCategories (WEBEXTRACTOR.objConn.getConnection)
        dgrCategory.SetDataBinding (objDS, "Table")
    End Sub

    Private Sub LoadExistCategory()
        'Dim objCategory As New VNN_WEBEXTRACTOR.Data.CategoryInfor
        'objCategory = VNN_WEBEXTRACTOR.Data.CategoryController.selectCategory(WEBEXTRACTOR.objConn.getConnection, intID)
        'With objCategory
        '    txtName.Text = ._Name
        '    txtDescription.Text = ._Description
        '    txtDisplayOrder.Text = ._DisplayOrder
        '    drDisplayPosition.Text = ._DisplayPosition
        'End With
        'objCategory = Nothing
    End Sub

    Private Sub cmdDelete_Click (ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        If _
            MessageBox.Show ("Do you really want to delete this item ?", WEBEXTRACTOR.MY_NOTICE_TITLE, _
                             MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = DialogResult.OK Then
            VNN_WEBEXTRACTOR.Data.CategoryController.DeleteCategory (WEBEXTRACTOR.objConn.getConnection, intID)
            cmdAddNew.Enabled = True
            cmdDelete.Enabled = False
            cmdUpdate.Enabled = False
            LoadCategories()
        End If
    End Sub

    Private Sub dgrCategory_DoubleClick (ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles dgrCategory.DoubleClick
        If IsNumeric (dgrCategory.Item (dgrCategory.CurrentRowIndex, 0)) Then
            intID = CType (dgrCategory.Item (dgrCategory.CurrentRowIndex, 0), Integer)
            cmdAddNew.Enabled = False
            cmdDelete.Enabled = True
            cmdUpdate.Enabled = True
            LoadExistCategory()
            CheckDataForUpdate()
        End If
    End Sub

    Private Sub txtName_LostFocus (ByVal sender As Object, ByVal e As System.EventArgs) Handles txtName.LostFocus
        CheckDataForUpdate()
    End Sub

    Private Sub txtDisplayOrder_LostFocus (ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles txtDisplayOrder.LostFocus
        CheckDataForUpdate()
    End Sub

    Private Sub drDisplayPosition_LostFocus (ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles drDisplayPosition.LostFocus
        CheckDataForUpdate()
    End Sub
End Class
