Public Class Form1

    Public bmp As Bitmap
    Public gpx As Graphics

    Public Light As Vec
    Public Sphere As Sphere
    Public tst As Double = 1.0

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bmp = New Bitmap(PictureBox1.Width, PictureBox1.Height)
        gpx = Graphics.FromImage(bmp)

        Light = New Vec(bmp.Width / 2, bmp.Height, 0)
        Sphere = New Sphere(New Vec(bmp.Width / 2, bmp.Height / 2, 0), 50, Color.Red)

        TrackBar1.SetRange(0, bmp.Width)
        TrackBar1.Value = bmp.Width / 2

        TrackBar2.SetRange(0, bmp.Height)
        TrackBar1.Value = 0

        Draw(Light)
    End Sub

    Public Sub Draw(Light As Vec)
        gpx.Clear(Color.Azure)

        Dim i, j As Double

        'for each pixel
        For i = 0 To bmp.Width - 1
            For j = 0 To bmp.Height - 1

                'Send a ray through each pixel
                Dim Ray As Ray = New Ray(New Vec(i, j, 0), New Vec(0, 0, 1))

                Dim t As Double

                'check intersections
                If Sphere.Intersect(Ray, t) Then
                    'bmp.SetPixel(i, j, Color.White)

                    Dim pi, L, N As Vec
                    Dim dt As Double
                    'Point of intersection
                    pi = Ray.o + Ray.d * t

                    'Color the Pixel
                    L = Light - pi
                    N = Sphere.getNormal(pi)
                    dt = Sphere.dot(L.Normalize, N.Normalize)

                    Dim newclr As Vec

                    newclr = (Sphere.Color + New Vec(255, 255, 255) * dt) * tst

                    bmp.SetPixel(i, j, CreateColorVector(newclr))

                End If

            Next
        Next
        PictureBox1.Image = bmp
    End Sub

    Function CreateColorVector(clr As Vec) As Color
        Dim colRed, colGreen, colBlue As Double

        colRed = clr.x
        colGreen = clr.y
        colBlue = clr.z

        If colRed > 255 Then
            colRed = 255
        ElseIf colRed < 0 Then
            colRed = 0
        End If

        If colGreen > 255 Then
            colGreen = 255
        ElseIf colGreen < 0 Then
            colGreen = 0
        End If

        If colBlue > 255 Then
            colBlue = 255
        ElseIf colBlue < 0 Then
            colBlue = 0
        End If

        Return Color.FromArgb(CInt(colRed), CInt(colGreen), CInt(colBlue))
    End Function

    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles TrackBar1.Scroll
        Light.Translate(TrackBar1.Value, "x")
        Draw(Light)
    End Sub

    Private Sub TrackBar2_Scroll(sender As Object, e As EventArgs) Handles TrackBar2.Scroll
        Light.Translate(TrackBar2.Value, "y")
        Draw(Light)
    End Sub

    Private Sub TrackBar3_Scroll(sender As Object, e As EventArgs) Handles TrackBar3.Scroll
        Light.Translate(TrackBar3.Value, "z")
        Draw(Light)
    End Sub

    Private Sub TrackBar4_Scroll(sender As Object, e As EventArgs) Handles TrackBar4.Scroll
        tst = TrackBar4.Value / 100
        Draw(Light)
    End Sub

    Private Sub TrackBar7_Scroll(sender As Object, e As EventArgs) Handles TrackBar7.Scroll

    End Sub

    Private Sub TrackBar5_Scroll(sender As Object, e As EventArgs) Handles TrackBar5.Scroll
        Sphere.c.Translate(TrackBar5.Value, "x")
        Draw(Light)
    End Sub

    Private Sub TrackBar6_Scroll(sender As Object, e As EventArgs) Handles TrackBar6.Scroll
        Sphere.c.Translate(TrackBar6.Value, "y")
        Draw(Light)
    End Sub
End Class

Public Class Sphere
    Public c As Vec 'center
    Public r As Double 'radius
    Public Color As Vec ' init rgb=xyz

    Sub New(c As Vec, r As Double, Color As Color)
        Me.c = c
        Me.r = r
        Me.Color = New Vec(Color.R, Color.G, Color.B)
    End Sub

    Public Function Intersect(ray As Ray, ByRef t As Double) As Boolean
        Dim o, d, oc As Vec
        Dim b, c, disc As Double

        o = ray.o
        d = ray.d
        oc = o - Me.c

        b = 2 * dot(oc, d)
        c = dot(oc, oc) - r * r
        disc = b * b - 4 * c

        If disc < 0 Then
            Return False
        Else
            disc = Math.Sqrt(disc)

            Dim t0, t1 As Double
            t0 = -b - disc
            t1 = -b + disc

            If t0 < t1 Then
                t = t0
            Else
                t = t1
            End If

            Return True
        End If
    End Function

    Public Function dot(v As Vec, b As Vec) As Double
        Return (v.x * b.x + v.y * b.y + v.z * b.z)
    End Function

    Public Function getNormal(pi As Vec)
        Return (c - pi) / r
    End Function
End Class

Public Class Ray
    Public o, d As Vec

    Sub New(o As Vec, d As Vec)
        Me.o = o
        Me.d = d
    End Sub
End Class

Public Class Vec
    Public x, y, z As Double

    Public Sub New()
        x = 0
        y = 0
        z = 0
    End Sub

    Public Sub New(x As Double, y As Double, z As Double)
        Me.x = x
        Me.y = y
        Me.z = z
    End Sub

    Public Sub Translate(val As Double, axis As String)
        If axis = "x" Then
            x = val
        ElseIf axis = "y" Then
            y = val
        ElseIf axis = "z" Then
            z = val
        End If
    End Sub

    Public Function Normalize()
        Dim mg As Double
        mg = Math.Sqrt(x * x + y * y + z * z)
        Return New Vec(x / mg, y / mg, z / mg)
    End Function

    Public Shared Operator +(v As Vec, w As Vec) As Vec
        Return New Vec(v.x + w.x, v.y + w.y, v.z + w.z)
    End Operator

    Public Shared Operator -(v As Vec, w As Vec) As Vec
        Return New Vec(v.x - w.x, v.y - w.y, v.z - w.z)
    End Operator

    Public Shared Operator *(v As Vec, w As Vec) As Vec
        Return New Vec(v.x * w.x, v.y * w.y, v.z * w.z)
    End Operator

    Public Shared Operator *(v As Vec, f As Double) As Vec
        Return New Vec(v.x * f, v.y * f, v.z * f)
    End Operator

    Public Shared Operator /(v As Vec, f As Double) As Vec
        Return New Vec(v.x / f, v.y / f, v.z / f)
    End Operator
End Class
