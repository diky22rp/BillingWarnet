<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Beranda
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Beranda))
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblpemasukanisi = New System.Windows.Forms.Label()
        Me.lblsoisi = New System.Windows.Forms.Label()
        Me.lblpc = New System.Windows.Forms.Label()
        Me.lblpemasukan = New System.Windows.Forms.Label()
        Me.lblso = New System.Windows.Forms.Label()
        Me.lbljumlahpc = New System.Windows.Forms.Label()
        Me.lblnama = New System.Windows.Forms.Label()
        Me.lblnm = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnedit = New System.Windows.Forms.Button()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblusername = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnlihat = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.Panel3.Location = New System.Drawing.Point(14, 299)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(493, 3)
        Me.Panel3.TabIndex = 22
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.Panel2.Location = New System.Drawing.Point(24, 268)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(143, 10)
        Me.Panel2.TabIndex = 25
        '
        'lblpemasukanisi
        '
        Me.lblpemasukanisi.AutoSize = True
        Me.lblpemasukanisi.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblpemasukanisi.Location = New System.Drawing.Point(331, 208)
        Me.lblpemasukanisi.Name = "lblpemasukanisi"
        Me.lblpemasukanisi.Size = New System.Drawing.Size(64, 16)
        Me.lblpemasukanisi.TabIndex = 35
        Me.lblpemasukanisi.Text = "1000000"
        '
        'lblsoisi
        '
        Me.lblsoisi.AutoSize = True
        Me.lblsoisi.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsoisi.Location = New System.Drawing.Point(331, 182)
        Me.lblsoisi.Name = "lblsoisi"
        Me.lblsoisi.Size = New System.Drawing.Size(16, 16)
        Me.lblsoisi.TabIndex = 34
        Me.lblsoisi.Text = "2"
        '
        'lblpc
        '
        Me.lblpc.AutoSize = True
        Me.lblpc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblpc.Location = New System.Drawing.Point(331, 153)
        Me.lblpc.Name = "lblpc"
        Me.lblpc.Size = New System.Drawing.Size(16, 16)
        Me.lblpc.TabIndex = 33
        Me.lblpc.Text = "5"
        '
        'lblpemasukan
        '
        Me.lblpemasukan.AutoSize = True
        Me.lblpemasukan.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblpemasukan.Location = New System.Drawing.Point(179, 208)
        Me.lblpemasukan.Name = "lblpemasukan"
        Me.lblpemasukan.Size = New System.Drawing.Size(142, 16)
        Me.lblpemasukan.TabIndex = 32
        Me.lblpemasukan.Text = "Jumlah Pemasukan"
        '
        'lblso
        '
        Me.lblso.AutoSize = True
        Me.lblso.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblso.Location = New System.Drawing.Point(179, 182)
        Me.lblso.Name = "lblso"
        Me.lblso.Size = New System.Drawing.Size(110, 16)
        Me.lblso.TabIndex = 31
        Me.lblso.Text = "Sedang Online"
        '
        'lbljumlahpc
        '
        Me.lbljumlahpc.AutoSize = True
        Me.lbljumlahpc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbljumlahpc.Location = New System.Drawing.Point(179, 153)
        Me.lbljumlahpc.Name = "lbljumlahpc"
        Me.lbljumlahpc.Size = New System.Drawing.Size(81, 16)
        Me.lbljumlahpc.TabIndex = 30
        Me.lbljumlahpc.Text = "Jumlah PC"
        '
        'lblnama
        '
        Me.lblnama.AutoSize = True
        Me.lblnama.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblnama.Location = New System.Drawing.Point(331, 125)
        Me.lblnama.Name = "lblnama"
        Me.lblnama.Size = New System.Drawing.Size(71, 16)
        Me.lblnama.TabIndex = 29
        Me.lblnama.Text = "namanya"
        '
        'lblnm
        '
        Me.lblnm.AutoSize = True
        Me.lblnm.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblnm.Location = New System.Drawing.Point(179, 125)
        Me.lblnm.Name = "lblnm"
        Me.lblnm.Size = New System.Drawing.Size(102, 16)
        Me.lblnm.TabIndex = 28
        Me.lblnm.Text = "Nama Warnet"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(32, 125)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(125, 128)
        Me.PictureBox1.TabIndex = 27
        Me.PictureBox1.TabStop = False
        '
        'btnedit
        '
        Me.btnedit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnedit.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.btnedit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnedit.ForeColor = System.Drawing.Color.White
        Me.btnedit.Location = New System.Drawing.Point(447, 122)
        Me.btnedit.Name = "btnedit"
        Me.btnedit.Size = New System.Drawing.Size(47, 23)
        Me.btnedit.TabIndex = 26
        Me.btnedit.Text = "Edit"
        Me.btnedit.UseVisualStyleBackColor = False
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.Panel4.Location = New System.Drawing.Point(24, 90)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(143, 10)
        Me.Panel4.TabIndex = 23
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(20, 67)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(147, 20)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "Informasi Warnet"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.Panel1.Location = New System.Drawing.Point(14, 38)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(493, 3)
        Me.Panel1.TabIndex = 21
        '
        'lblusername
        '
        Me.lblusername.AutoSize = True
        Me.lblusername.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblusername.Location = New System.Drawing.Point(69, 15)
        Me.lblusername.Name = "lblusername"
        Me.lblusername.Size = New System.Drawing.Size(88, 20)
        Me.lblusername.TabIndex = 20
        Me.lblusername.Text = "username"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(20, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 20)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Hallo,"
        '
        'btnlihat
        '
        Me.btnlihat.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnlihat.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.btnlihat.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnlihat.ForeColor = System.Drawing.Color.White
        Me.btnlihat.Image = CType(resources.GetObject("btnlihat.Image"), System.Drawing.Image)
        Me.btnlihat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnlihat.Location = New System.Drawing.Point(185, 77)
        Me.btnlihat.Name = "btnlihat"
        Me.btnlihat.Size = New System.Drawing.Size(147, 23)
        Me.btnlihat.TabIndex = 36
        Me.btnlihat.Text = "REFRESH INFORMASI"
        Me.btnlihat.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnlihat.UseVisualStyleBackColor = False
        '
        'Beranda
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(521, 317)
        Me.Controls.Add(Me.btnlihat)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.lblpemasukanisi)
        Me.Controls.Add(Me.lblsoisi)
        Me.Controls.Add(Me.lblpc)
        Me.Controls.Add(Me.lblpemasukan)
        Me.Controls.Add(Me.lblso)
        Me.Controls.Add(Me.lbljumlahpc)
        Me.Controls.Add(Me.lblnama)
        Me.Controls.Add(Me.lblnm)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.btnedit)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lblusername)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Beranda"
        Me.Text = "Beranda"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lblpemasukanisi As System.Windows.Forms.Label
    Friend WithEvents lblsoisi As System.Windows.Forms.Label
    Friend WithEvents lblpc As System.Windows.Forms.Label
    Friend WithEvents lblpemasukan As System.Windows.Forms.Label
    Friend WithEvents lblso As System.Windows.Forms.Label
    Friend WithEvents lbljumlahpc As System.Windows.Forms.Label
    Friend WithEvents lblnama As System.Windows.Forms.Label
    Friend WithEvents lblnm As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents btnedit As System.Windows.Forms.Button
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblusername As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnlihat As System.Windows.Forms.Button
End Class
