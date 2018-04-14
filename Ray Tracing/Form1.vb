Public Class Form1

    Public bmp As Bitmap
    Public gpx As Graphics

    Dim Light As Vec
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bmp = New Bitmap(PictureBox1.Width, PictureBox1.Height)
        gpx = Graphics.FromImage(bmp)

        Light = New Vec(bmp.Width / 2, 0, 50)

        Draw(Light)
    End Sub

    Public Sub Draw(Light As Vec)
        gpx.Clear(Color.Black)

        Dim Sphere As Sphere = New Sphere(New Vec(bmp.Width / 2, bmp.Height / 2, 50), 50)
        Dim clr As Color
        clr = Color.White

        Dim i, j As Double

        For i = 0 To bmp.Width - 1
            For j = 0 To bmp.Height - 1
                Dim Ray As Ray = New Ray(New Vec(i, j, 0), New Vec(0, 0, 1))

                Dim t As Double = Double.MaxValue

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

                    Dim newclr As Color

                    newclr = multiplicationCandD(clr, dt)

                    bmp.SetPixel(i, j, newclr)

                End If

            Next
        Next
        PictureBox1.Image = bmp
    End Sub

    Function sumColor(a As Color, b As Color) As Color
        Dim colRed, colGreen, colBlue As Double

        colRed = a.R + b.R
        colGreen = a.G + b.G
        colBlue = a.B + b.B

        Return Color.FromArgb(CInt(colRed), CInt(colGreen), CInt(colBlue))
    End Function

    Function multiplicationCandD(a As Color, b As Double) As Color
        Dim colRed, colGreen, colBlue As Double

        colRed = a.R * b
        colGreen = a.G * b
        colBlue = a.B * b

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
End Class

Public Class Sphere
    Public c As Vec 'center
    Public r As Double 'radius

    Sub New(c As Vec, r As Double)
        Me.c = c
        Me.r = r
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
