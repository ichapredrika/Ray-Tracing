<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.refreshBtn = New System.Windows.Forms.Button()
        Me.Lightx = New System.Windows.Forms.TrackBar()
        Me.Lighty = New System.Windows.Forms.TrackBar()
        Me.Lightz = New System.Windows.Forms.TrackBar()
        Me.TrackBar4 = New System.Windows.Forms.TrackBar()
        Me.Spherex = New System.Windows.Forms.TrackBar()
        Me.Spherey = New System.Windows.Forms.TrackBar()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.kaTB = New System.Windows.Forms.TrackBar()
        Me.kdTB = New System.Windows.Forms.TrackBar()
        Me.ksTB = New System.Windows.Forms.TrackBar()
        Me.sreTB = New System.Windows.Forms.TrackBar()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Lightx, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Lighty, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Lightz, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBar4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Spherex, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Spherey, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.kaTB, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.kdTB, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ksTB, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sreTB, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.White
        Me.PictureBox1.Location = New System.Drawing.Point(13, 13)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(483, 408)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'refreshBtn
        '
        Me.refreshBtn.Location = New System.Drawing.Point(879, 400)
        Me.refreshBtn.Name = "refreshBtn"
        Me.refreshBtn.Size = New System.Drawing.Size(75, 23)
        Me.refreshBtn.TabIndex = 1
        Me.refreshBtn.Text = "Refresh"
        Me.refreshBtn.UseVisualStyleBackColor = True
        '
        'Lightx
        '
        Me.Lightx.Location = New System.Drawing.Point(509, 46)
        Me.Lightx.Margin = New System.Windows.Forms.Padding(2)
        Me.Lightx.Maximum = 300
        Me.Lightx.Name = "Lightx"
        Me.Lightx.Size = New System.Drawing.Size(208, 45)
        Me.Lightx.TabIndex = 2
        '
        'Lighty
        '
        Me.Lighty.Location = New System.Drawing.Point(509, 96)
        Me.Lighty.Margin = New System.Windows.Forms.Padding(2)
        Me.Lighty.Maximum = 300
        Me.Lighty.Name = "Lighty"
        Me.Lighty.Size = New System.Drawing.Size(208, 45)
        Me.Lighty.TabIndex = 3
        '
        'Lightz
        '
        Me.Lightz.Location = New System.Drawing.Point(509, 146)
        Me.Lightz.Margin = New System.Windows.Forms.Padding(2)
        Me.Lightz.Maximum = 300
        Me.Lightz.Name = "Lightz"
        Me.Lightz.Size = New System.Drawing.Size(208, 45)
        Me.Lightz.TabIndex = 4
        '
        'TrackBar4
        '
        Me.TrackBar4.Location = New System.Drawing.Point(519, 208)
        Me.TrackBar4.Margin = New System.Windows.Forms.Padding(2)
        Me.TrackBar4.Maximum = 100
        Me.TrackBar4.Name = "TrackBar4"
        Me.TrackBar4.Size = New System.Drawing.Size(208, 45)
        Me.TrackBar4.TabIndex = 5
        Me.TrackBar4.Value = 100
        '
        'Spherex
        '
        Me.Spherex.Location = New System.Drawing.Point(745, 46)
        Me.Spherex.Margin = New System.Windows.Forms.Padding(2)
        Me.Spherex.Maximum = 300
        Me.Spherex.Name = "Spherex"
        Me.Spherex.Size = New System.Drawing.Size(209, 45)
        Me.Spherex.TabIndex = 6
        '
        'Spherey
        '
        Me.Spherey.Location = New System.Drawing.Point(745, 96)
        Me.Spherey.Margin = New System.Windows.Forms.Padding(2)
        Me.Spherey.Maximum = 100
        Me.Spherey.Minimum = -100
        Me.Spherey.Name = "Spherey"
        Me.Spherey.Size = New System.Drawing.Size(209, 45)
        Me.Spherey.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(516, 13)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Light Control"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(742, 13)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Sphere Control"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(516, 193)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Label3"
        '
        'kaTB
        '
        Me.kaTB.Location = New System.Drawing.Point(519, 282)
        Me.kaTB.Name = "kaTB"
        Me.kaTB.Size = New System.Drawing.Size(104, 45)
        Me.kaTB.TabIndex = 12
        '
        'kdTB
        '
        Me.kdTB.Location = New System.Drawing.Point(519, 334)
        Me.kdTB.Name = "kdTB"
        Me.kdTB.Size = New System.Drawing.Size(104, 45)
        Me.kdTB.TabIndex = 13
        '
        'ksTB
        '
        Me.ksTB.Location = New System.Drawing.Point(519, 386)
        Me.ksTB.Name = "ksTB"
        Me.ksTB.Size = New System.Drawing.Size(104, 45)
        Me.ksTB.TabIndex = 14
        '
        'sreTB
        '
        Me.sreTB.Location = New System.Drawing.Point(679, 282)
        Me.sreTB.Name = "sreTB"
        Me.sreTB.Size = New System.Drawing.Size(104, 45)
        Me.sreTB.TabIndex = 15
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(973, 433)
        Me.Controls.Add(Me.sreTB)
        Me.Controls.Add(Me.ksTB)
        Me.Controls.Add(Me.kdTB)
        Me.Controls.Add(Me.kaTB)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Spherey)
        Me.Controls.Add(Me.Spherex)
        Me.Controls.Add(Me.TrackBar4)
        Me.Controls.Add(Me.Lightz)
        Me.Controls.Add(Me.Lighty)
        Me.Controls.Add(Me.Lightx)
        Me.Controls.Add(Me.refreshBtn)
        Me.Controls.Add(Me.PictureBox1)
        Me.Name = "Form1"
        Me.Text = "Ray Tracing"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Lightx, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Lighty, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Lightz, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBar4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Spherex, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Spherey, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.kaTB, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.kdTB, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ksTB, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sreTB, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents refreshBtn As Button
    Friend WithEvents Lightx As TrackBar
    Friend WithEvents Lighty As TrackBar
    Friend WithEvents Lightz As TrackBar
    Friend WithEvents TrackBar4 As TrackBar
    Friend WithEvents Spherex As TrackBar
    Friend WithEvents Spherey As TrackBar
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents kaTB As TrackBar
    Friend WithEvents kdTB As TrackBar
    Friend WithEvents ksTB As TrackBar
    Friend WithEvents sreTB As TrackBar
End Class
