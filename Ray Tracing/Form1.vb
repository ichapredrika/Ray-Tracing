Public Class Form1

    Public bmp As Bitmap
    Public gpx As Graphics

    Public Light As Vec
    Public Sphere As Sphere
    Public tst As Double = 1.0


    Public ka As Double = 0.5
    Public kd As Double = 0.5
    Public ks As Double = 0.5
    Public ll As Double = 0.5
    Public la As Double = 0.5
    Public ex As Double = 0



    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bmp = New Bitmap(PictureBox1.Width, PictureBox1.Height)
        gpx = Graphics.FromImage(bmp)

        Light = New Vec(bmp.Width / 2, bmp.Height, 0)
        Sphere = New Sphere(New Vec(bmp.Width / 2, bmp.Height / 2, 0), 50, Color.Red)

        Lightx.SetRange(0, bmp.Width)
        Lightx.Value = bmp.Width / 2

        Lighty.SetRange(0, bmp.Height)
        Lighty.Value = 0

        Lightz.SetRange(-360, 360)
        Lightz.Value = 0

        Spherex.SetRange(0 + Sphere.r, bmp.Width - Sphere.r)
        Spherex.Value = bmp.Width / 2

        Spherey.SetRange(0 + Sphere.r, bmp.Height - Sphere.r)
        Spherey.Value = bmp.Height / 2


        'TrackBar1.SetRange(0, bmp.Width)
        'TrackBar1.Value = bmp.Width / 2

        'TrackBar2.SetRange(0, bmp.Height)
        'TrackBar1.Value = 0

        Draw(Light)
    End Sub

    Public Sub Draw(Light As Vec)
        gpx.Clear(Color.Azure)

        Dim i, j As Double
        Dim t As Double

        'for each pixel
        For j = 0 To bmp.Height - 1
            For i = 0 To bmp.Width - 1

                'Send a ray through each pixel
                Dim Ray As Ray = New Ray(New Vec(i, j, 0), New Vec(0, 0, 1))

                'check intersections
                If Sphere.Intersect(Ray, t) Then
                    'bmp.SetPixel(i, j, Color.White)

                    Dim pi, L, N, V, R As Vec
                    Dim dt As Double

                    'Point of intersection
                    pi = Ray.o + Ray.d * t

                    'Color the Pixel
                    L = Light - pi
                    N = Sphere.GetNormal(pi)
                    V = New Vec(0, 0, 100)
                    V = V - pi
                    R = MultiplyPointMatrix(pi, 2) - L.Normalize
                    dt = Sphere.Dot(L.Normalize, N.Normalize)

                    Dim red, green, blue As Double
                    Dim itotA As Double
                    'Dim itot As Vec




                    itotA = (ka * la) + (kd * ll * (Dot(L.Normalize, N.Normalize))) + (ks * ll) * ((Dot(V.Normalize, R.Normalize)) ^ ex)

                    'itot = (Sphere.Color + New Vec(255, 255, 255) * itotA)

                    'bmp.SetPixel(i, j, CreateColorVector(itot))

                    red = itotA
                    green = itotA
                    blue = 255 * itotA

                    If red < 0 Then
                        red = 0
                    ElseIf red > 255 Then
                        red = 255
                    End If
                    If green < 0 Then
                        green = 0
                    ElseIf green > 255 Then
                        green = 255
                    End If
                    If blue < 0 Then
                        blue = 0
                    ElseIf blue > 255 Then
                        blue = 255
                    End If
                    bmp.SetPixel(i, j, Color.FromArgb(red, green, blue))
                End If

            Next
        Next
        PictureBox1.Image = bmp
    End Sub
    Function MultiplyPointMatrix(Point As Vec, a As Double) As Vec
        Return New Vec(Point.x * a,
                       Point.y * a,
                       Point.z * a)
    End Function
    Public Function Dot(v As Vec, b As Vec) As Double
        Return (v.x * b.x + v.y * b.y + v.z * b.z)
    End Function

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

    Function MatrixMultiplication(Matrix1(,) As Double, Matrix2(,) As Double) As Double(,)
        Dim temp(3, 3) As Double
        For i = 0 To 3
            temp(i, 0) = Matrix1(i, 0) * Matrix2(0, 0) + Matrix1(i, 1) * Matrix2(1, 0) + Matrix1(i, 2) * Matrix2(2, 0) + Matrix1(i, 3) * Matrix2(3, 0)
            temp(i, 1) = Matrix1(i, 0) * Matrix2(0, 1) + Matrix1(i, 1) * Matrix2(1, 1) + Matrix1(i, 2) * Matrix2(2, 1) + Matrix1(i, 3) * Matrix2(3, 1)
            temp(i, 2) = Matrix1(i, 0) * Matrix2(0, 2) + Matrix1(i, 1) * Matrix2(1, 2) + Matrix1(i, 2) * Matrix2(2, 2) + Matrix1(i, 3) * Matrix2(3, 2)
            temp(i, 3) = Matrix1(i, 0) * Matrix2(0, 3) + Matrix1(i, 1) * Matrix2(1, 3) + Matrix1(i, 2) * Matrix2(2, 3) + Matrix1(i, 3) * Matrix2(3, 3)
        Next
        Return temp
    End Function

    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles Lightx.Scroll
        Light.Translate(bmp.Width - Lightx.Value, "x")
        Draw(Light)
    End Sub

    Private Sub TrackBar2_Scroll(sender As Object, e As EventArgs) Handles Lighty.Scroll
        Light.Translate(bmp.Height - Lighty.Value, "y")
        Draw(Light)
    End Sub

    Private Sub TrackBar3_Scroll(sender As Object, e As EventArgs) Handles Lightz.Scroll
        Light.Translate(Lightz.Value, "z")
        Draw(Light)
    End Sub

    Private Sub TrackBar4_Scroll(sender As Object, e As EventArgs) Handles TrackBar4.Scroll
        tst = TrackBar4.Value / 100
        Draw(Light)
    End Sub

    Private Sub TrackBar7_Scroll(sender As Object, e As EventArgs)

    End Sub

    Private Sub TrackBar5_Scroll(sender As Object, e As EventArgs) Handles Spherex.Scroll
        Sphere.c.Translate(Spherex.Value, "x")
        Draw(Light)
    End Sub

    Private Sub TrackBar6_Scroll(sender As Object, e As EventArgs) Handles Spherey.Scroll
        Sphere.c.Translate(Spherey.Value, "y")
        Draw(Light)
    End Sub

    Private Sub kaTB_Scroll(sender As Object, e As EventArgs) Handles kaTB.Scroll
        ka = kaTB.Value / 10
        Draw(Light)
    End Sub

    Private Sub kdTB_Scroll(sender As Object, e As EventArgs) Handles kdTB.Scroll
        kd = kdTB.Value / 10
        Draw(Light)
    End Sub

    Private Sub ksTB_Scroll(sender As Object, e As EventArgs) Handles ksTB.Scroll
        ks = ksTB.Value / 10
        Draw(Light)
    End Sub

    Private Sub sreTB_Scroll(sender As Object, e As EventArgs) Handles sreTB.Scroll
        ex = sreTB.Value
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

        b = 2 * Dot(oc, d)
        c = Dot(oc, oc) - r * r
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

    Public Function Dot(v As Vec, b As Vec) As Double
        Return (v.x * b.x + v.y * b.y + v.z * b.z)
    End Function

    Public Function GetNormal(pi As Vec)
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

    Public Shared Operator *(v As Vec, w(,) As Double) As Vec
        Return New Vec(v.x * w(0, 0) + v.y * w(1, 0) + v.z * w(2, 0) + 0 * w(3, 0),
                       v.x * w(0, 1) + v.y * w(1, 1) + v.z * w(2, 1) + 0 * w(3, 1),
                       v.x * w(0, 2) + v.y * w(1, 2) + v.z * w(2, 2) + 0 * w(3, 2))
    End Operator

    Public Shared Operator *(v As Vec, f As Double) As Vec
        Return New Vec(v.x * f, v.y * f, v.z * f)
    End Operator

    Public Shared Operator /(v As Vec, f As Double) As Vec
        Return New Vec(v.x / f, v.y / f, v.z / f)
    End Operator

End Class
