<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Paket
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Paket))
        Me.dgpaket = New System.Windows.Forms.DataGridView()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtkodepaket = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtnamapaket = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtharga = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtdurasi = New System.Windows.Forms.TextBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.btnedit = New System.Windows.Forms.Button()
        Me.btntambah = New System.Windows.Forms.Button()
        Me.btnlihat = New System.Windows.Forms.Button()
        CType(Me.dgpaket, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgpaket
        '
        Me.dgpaket.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgpaket.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgpaket.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dgpaket.GridColor = System.Drawing.SystemColors.Control
        Me.dgpaket.Location = New System.Drawing.Point(0, 167)
        Me.dgpaket.Name = "dgpaket"
        Me.dgpaket.Size = New System.Drawing.Size(521, 150)
        Me.dgpaket.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(57, 16)
        Me.Label5.TabIndex = 55
        Me.Label5.Text = "PAKET"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.Panel1.Location = New System.Drawing.Point(9, 10)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(5, 15)
        Me.Panel1.TabIndex = 54
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(23, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 16)
        Me.Label1.TabIndex = 57
        Me.Label1.Text = "Kode Paket"
        '
        'txtkodepaket
        '
        Me.txtkodepaket.Location = New System.Drawing.Point(107, 49)
        Me.txtkodepaket.Name = "txtkodepaket"
        Me.txtkodepaket.Size = New System.Drawing.Size(134, 20)
        Me.txtkodepaket.TabIndex = 56
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(23, 94)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 16)
        Me.Label2.TabIndex = 59
        Me.Label2.Text = "Nama Paket"
        '
        'txtnamapaket
        '
        Me.txtnamapaket.Location = New System.Drawing.Point(107, 93)
        Me.txtnamapaket.Name = "txtnamapaket"
        Me.txtnamapaket.Size = New System.Drawing.Size(134, 20)
        Me.txtnamapaket.TabIndex = 58
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(258, 93)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 16)
        Me.Label3.TabIndex = 63
        Me.Label3.Text = "Harga Paket"
        '
        'txtharga
        '
        Me.txtharga.Location = New System.Drawing.Point(348, 93)
        Me.txtharga.Name = "txtharga"
        Me.txtharga.Size = New System.Drawing.Size(134, 20)
        Me.txtharga.TabIndex = 62
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(258, 49)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(85, 32)
        Me.Label4.TabIndex = 61
        Me.Label4.Text = "Durasi Paket" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(Detik)"
        '
        'txtdurasi
        '
        Me.txtdurasi.Location = New System.Drawing.Point(349, 48)
        Me.txtdurasi.Name = "txtdurasi"
        Me.txtdurasi.Size = New System.Drawing.Size(134, 20)
        Me.txtdurasi.TabIndex = 60
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.ForeColor = System.Drawing.Color.White
        Me.Button3.Location = New System.Drawing.Point(382, 138)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(80, 23)
        Me.Button3.TabIndex = 67
        Me.Button3.Text = "HAPUS"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'btnedit
        '
        Me.btnedit.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.btnedit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnedit.ForeColor = System.Drawing.Color.White
        Me.btnedit.Location = New System.Drawing.Point(296, 138)
        Me.btnedit.Name = "btnedit"
        Me.btnedit.Size = New System.Drawing.Size(80, 23)
        Me.btnedit.TabIndex = 66
        Me.btnedit.Text = "EDIT"
        Me.btnedit.UseVisualStyleBackColor = False
        '
        'btntambah
        '
        Me.btntambah.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.btntambah.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btntambah.ForeColor = System.Drawing.Color.White
        Me.btntambah.Location = New System.Drawing.Point(210, 138)
        Me.btntambah.Name = "btntambah"
        Me.btntambah.Size = New System.Drawing.Size(80, 23)
        Me.btntambah.TabIndex = 65
        Me.btntambah.Text = "TAMBAH"
        Me.btntambah.UseVisualStyleBackColor = False
        '
        'btnlihat
        '
        Me.btnlihat.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.btnlihat.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnlihat.ForeColor = System.Drawing.Color.White
        Me.btnlihat.Image = CType(resources.GetObject("btnlihat.Image"), System.Drawing.Image)
        Me.btnlihat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnlihat.Location = New System.Drawing.Point(26, 138)
        Me.btnlihat.Name = "btnlihat"
        Me.btnlihat.Size = New System.Drawing.Size(118, 23)
        Me.btnlihat.TabIndex = 64
        Me.btnlihat.Text = "REFRESH DATA"
        Me.btnlihat.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnlihat.UseVisualStyleBackColor = False
        '
        'Paket
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(521, 317)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.btnedit)
        Me.Controls.Add(Me.btntambah)
        Me.Controls.Add(Me.btnlihat)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtharga)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtdurasi)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtnamapaket)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtkodepaket)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.dgpaket)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Paket"
        Me.Text = "Paket"
        CType(Me.dgpaket, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgpaket As System.Windows.Forms.DataGridView
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtkodepaket As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtnamapaket As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtharga As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtdurasi As System.Windows.Forms.TextBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents btnedit As System.Windows.Forms.Button
    Friend WithEvents btntambah As System.Windows.Forms.Button
    Friend WithEvents btnlihat As System.Windows.Forms.Button
End Class
