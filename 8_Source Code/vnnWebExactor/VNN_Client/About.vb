
Public Class About
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
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents LinkLabel2 As System.Windows.Forms.LinkLabel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label

    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim _
            resources As System.ComponentModel.ComponentResourceManager = _
                New System.ComponentModel.ComponentResourceManager (GetType (About))
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
        Me.cmdClose = New System.Windows.Forms.Button
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        CType (Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add (Me.PictureBox1)
        Me.Panel1.Location = New System.Drawing.Point (0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size (88, 112)
        Me.Panel1.TabIndex = 0
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType (resources.GetObject ("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point (- 2, 8)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size (82, 80)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.Font = _
            New System.Drawing.Font ("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, _
                                     CType (0, Byte))
        Me.Label1.Location = New System.Drawing.Point (96, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size (344, 24)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Copyright © 2009 By VietNamNet"
        '
        'Label3
        '
        Me.Label3.Font = _
            New System.Drawing.Font ("Tahoma", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, _
                                     CType (0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point (96, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size (392, 40)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "INTERNET INFORMATION EXTRACTOR 1.0"
        '
        'Label4
        '
        Me.Label4.Font = _
            New System.Drawing.Font ("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, _
                                     CType (0, Byte))
        Me.Label4.Location = New System.Drawing.Point (96, 89)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size (72, 23)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Contacts:"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.Font = _
            New System.Drawing.Font ("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, _
                                     CType (0, Byte))
        Me.LinkLabel1.Location = New System.Drawing.Point (168, 89)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size (197, 23)
        Me.LinkLabel1.TabIndex = 4
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Technology Management Department"
        '
        'cmdClose
        '
        Me.cmdClose.Location = New System.Drawing.Point (424, 145)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size (80, 24)
        Me.cmdClose.TabIndex = 5
        Me.cmdClose.Text = "&Close"
        '
        'LinkLabel2
        '
        Me.LinkLabel2.Font = _
            New System.Drawing.Font ("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, _
                                     CType (0, Byte))
        Me.LinkLabel2.Location = New System.Drawing.Point (168, 65)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size (168, 23)
        Me.LinkLabel2.TabIndex = 4
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "http://www.vietnamnet.vn"
        '
        'Label5
        '
        Me.Label5.Font = _
            New System.Drawing.Font ("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, _
                                     CType (0, Byte))
        Me.Label5.Location = New System.Drawing.Point (96, 65)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size (72, 23)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "WebSites:"
        '
        'Label6
        '
        Me.Label6.Font = _
            New System.Drawing.Font ("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, _
                                     CType (0, Byte))
        Me.Label6.Location = New System.Drawing.Point (0, 143)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size (418, 40)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Warning: This service is a product of VietNamNet. It is used for the purpose of  " & _
                         "extracting information from internet. Don't use it for any other purposes. Thank" & _
                         " you!"
        '
        'Label7
        '
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.Location = New System.Drawing.Point (0, 121)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size (504, 3)
        Me.Label7.TabIndex = 7
        '
        'About
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size (5, 13)
        Me.ClientSize = New System.Drawing.Size (506, 185)
        Me.Controls.Add (Me.Label7)
        Me.Controls.Add (Me.Label6)
        Me.Controls.Add (Me.cmdClose)
        Me.Controls.Add (Me.LinkLabel1)
        Me.Controls.Add (Me.Label4)
        Me.Controls.Add (Me.Label1)
        Me.Controls.Add (Me.Panel1)
        Me.Controls.Add (Me.Label3)
        Me.Controls.Add (Me.LinkLabel2)
        Me.Controls.Add (Me.Label5)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType (resources.GetObject ("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "About"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "About"
        Me.Panel1.ResumeLayout (False)
        CType (Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout (False)

    End Sub

#End Region

    Private Sub LinkLabel1_LinkClicked (ByVal sender As System.Object, _
                                        ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) _
        Handles LinkLabel1.LinkClicked
        System.Diagnostics.Process.Start ("Mailto:phongdh@vietnamnet.vn")
    End Sub

    Private Sub cmdClose_Click (ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub About_Load (ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub LinkLabel2_LinkClicked (ByVal sender As System.Object, _
                                        ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) _
        Handles LinkLabel2.LinkClicked
        System.Diagnostics.Process.Start ("http://www.vietnamnet.vn")
    End Sub
End Class
