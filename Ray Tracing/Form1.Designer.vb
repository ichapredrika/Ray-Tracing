﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
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
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Lightx, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Lighty, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Lightz, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBar4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Spherex, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Spherey, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.White
        Me.PictureBox1.Location = New System.Drawing.Point(17, 16)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(644, 502)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'refreshBtn
        '
        Me.refreshBtn.Location = New System.Drawing.Point(1172, 492)
        Me.refreshBtn.Margin = New System.Windows.Forms.Padding(4)
        Me.refreshBtn.Name = "refreshBtn"
        Me.refreshBtn.Size = New System.Drawing.Size(100, 28)
        Me.refreshBtn.TabIndex = 1
        Me.refreshBtn.Text = "Refresh"
        Me.refreshBtn.UseVisualStyleBackColor = True
        '
        'Lightx
        '
        Me.Lightx.Location = New System.Drawing.Point(679, 56)
        Me.Lightx.Maximum = 300
        Me.Lightx.Name = "Lightx"
        Me.Lightx.Size = New System.Drawing.Size(278, 56)
        Me.Lightx.TabIndex = 2
        '
        'Lighty
        '
        Me.Lighty.Location = New System.Drawing.Point(679, 118)
        Me.Lighty.Maximum = 300
        Me.Lighty.Name = "Lighty"
        Me.Lighty.Size = New System.Drawing.Size(278, 56)
        Me.Lighty.TabIndex = 3
        '
        'Lightz
        '
        Me.Lightz.Location = New System.Drawing.Point(679, 180)
        Me.Lightz.Maximum = 300
        Me.Lightz.Name = "Lightz"
        Me.Lightz.Size = New System.Drawing.Size(278, 56)
        Me.Lightz.TabIndex = 4
        '
        'TrackBar4
        '
        Me.TrackBar4.Location = New System.Drawing.Point(834, 296)
        Me.TrackBar4.Maximum = 100
        Me.TrackBar4.Name = "TrackBar4"
        Me.TrackBar4.Size = New System.Drawing.Size(278, 56)
        Me.TrackBar4.TabIndex = 5
        Me.TrackBar4.Value = 100
        '
        'Spherex
        '
        Me.Spherex.Location = New System.Drawing.Point(993, 56)
        Me.Spherex.Maximum = 300
        Me.Spherex.Name = "Spherex"
        Me.Spherex.Size = New System.Drawing.Size(279, 56)
        Me.Spherex.TabIndex = 6
        '
        'Spherey
        '
        Me.Spherey.Location = New System.Drawing.Point(993, 118)
        Me.Spherey.Maximum = 100
        Me.Spherey.Minimum = -100
        Me.Spherey.Name = "Spherey"
        Me.Spherey.Size = New System.Drawing.Size(279, 56)
        Me.Spherey.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(688, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 17)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Light Control"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(990, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 17)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Sphere Control"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(834, 260)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 17)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Label3"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1297, 533)
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
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Form1"
        Me.Text = "Ray Tracing"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Lightx, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Lighty, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Lightz, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBar4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Spherex, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Spherey, System.ComponentModel.ISupportInitialize).EndInit()
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
End Class
