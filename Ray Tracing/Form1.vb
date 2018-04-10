Public Class Form1
    Dim gr As Graphics
    Dim image As Bitmap
    Dim pen As Pen
    Dim lpoint1 As New List(Of TPoint)
    Dim lpoint2 As New List(Of TPoint)
    Dim ListPolygon As New List(Of TPolygon)
    Dim m As Integer = 10 'latitude
    Dim n As Integer = 10 'longitude
    Dim r As Double = 100
    Dim theta As Double
    Dim u, screen(3, 3) As Single
    Dim dtheta, du As Double
    Dim m1, m2, m3, m4, m5, m6, m11, m22, m33, m44, m55, m66 As Double
    Dim x, y, z, w As Double
    Dim p1, p2, p3 As Double

    Structure TPoint
        Public x, y, z, w As Single
    End Structure

    Structure TPolygon
        Public p1, p2, p3 As Integer
    End Structure

    Sub setpoint(ByRef P As TPoint, x As Single, y As Single, z As Single)
        P.x = x
        P.y = y
        P.z = z
        P.w = 1
    End Sub

    Sub setpoly(ByRef P As TPolygon, p1 As Single, p2 As Single, p3 As Single)
        P.p1 = p1
        P.p2 = p2
        P.p3 = p3

    End Sub

    Private Sub setMatrix(M(,) As Single, col As Integer, a As Single, b As Single, c As Single, d As Single)
        M(col, 0) = a
        M(col, 1) = b
        M(col, 2) = c
        M(col, 3) = d
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        image = New Bitmap(PictureBox1.Width, PictureBox1.Height)
        gr = Graphics.FromImage(image)
        drawSphere()

    End Sub

    Sub calculate()
        Dim L, N, R, V, Lu, Vu, Nu, Ru, f As TPoint
        Dim ls, p, viewer As TPoint
        Dim lel, lev, len, ler, LN, VR, ex As Single

        ls.x = 10 'lsX.Text
        ls.y = 10 'lsY.Text
        ls.z = 10 'lsZ.Text

        p.x = 0
        p.y = 0
        p.z = 0

        viewer.x = 0
        viewer.y = 0
        viewer.z = 5

        'L = ls -p
        L.x = ls.x - p.x
        L.y = ls.y - p.y
        L.z = ls.z - p.z
        lel = Math.Sqrt((L.x * L.x) + (L.y * L.y) + (L.z * L.z))
        Lu.x = (L.x / lel)
        Lu.y = (L.y / lel)
        Lu.z = (L.z / lel)

        'V =viewer -p
        V.x = viewer.x - p.x
        V.y = viewer.y - p.y
        V.z = viewer.z - p.z
        lev = Math.Sqrt((V.x * V.x) + (V.y * V.y) + (V.z * V.z))
        Vu.x = (V.x / lev)
        Vu.y = (V.y / lev)
        Vu.z = (V.z / lev)

        ' N = p1p2 X p1p3 counter clockwise
        N.x = 1
        N.y = 1
        N.z = 1
        len = Math.Sqrt((V.x * V.x) + (V.y * V.y) + (V.z * V.z))
        Nu.x = (N.x / len)
        Nu.y = (N.y / len)
        Nu.z = (N.z / len)

        'R = - L + 2 * N(L . N)
        'N(N . L)
        LN = Nu.x * Lu.x + Nu.y * Lu.y + Nu.z * Lu.z
        f.x = 2 * (Nu.x * (LN))
        f.y = 2 * (Nu.y * (LN))
        f.z = 2 * (Nu.z * (LN))

        R.x = -Lu.x + f.x
        R.y = -Lu.y + f.y
        R.x = -Lu.z + f.z
        ler = Math.Sqrt((R.x * R.x) + (R.y * R.y) + (R.z * R.z))
        Ru.x = (R.x / ler)
        Ru.y = (R.y / ler)
        Ru.z = (R.z / ler)
        VR = Vu.x * Ru.x + Vu.y * Ru.y + Vu.z * Ru.z

        Dim ka, la, kd, ll, ks, Itot As Single
        'specular reflection exponent
        ex = 1
        Itot = ka * la + kd * ll * (LN) + ks * ll * (VR ^ ex)

    End Sub
    Private Sub drawSphere()
        Dim newp(20) As TPoint
        Dim newpl(1000) As TPolygon

        'lpoint1 = New ArPoint
        'lpoint2 = New ArPoint
        'ListPolygon = New ArPoly


        dtheta = 180 / m
        du = 360 / n

        For i = 0 To m / 2 - 1
            theta = dtheta * i
            For j = 0 To n - 1
                u = du * j
                x = r * Math.Cos(theta * Math.PI / 180) * Math.Sin(u * Math.PI / 180)
                y = r * Math.Sin(theta * Math.PI / 180)
                z = r * Math.Cos(theta * Math.PI / 180) * Math.Cos(u * Math.PI / 180)
                w = 1

                setpoint(newp(j), x, y, z)
                lpoint1.Add(newp(j))
                setpoint(newp(j), x, -y, z)
                lpoint2.Add(newp(j))

            Next
        Next
        setpoint(newp(newp.Count - 1), 0, r, 0)
        lpoint1.Add(newp(newp.Count - 1))
        setpoint(newp(newp.Count - 1), 0, -r, 0)
        lpoint2.Add(newp(newp.Count - 1))

        For i = 0 To m / 2 - 1
            If i <= m / 2 - 2 Then
                For j = 0 To n - 2
                    p1 = n * i + j
                    p2 = n * (i + 1) + j + 1
                    p3 = n * (i + 1) + j
                    setpoly(newpl(j), p1, p2, p3)
                    ListPolygon.Add(newpl(j))
                    p1 = n * i + j
                    p2 = n * i + j + 1
                    p3 = n * (i + 1) + j + 1
                    setpoly(newpl(j), p1, p2, p3)
                    ListPolygon.Add(newpl(j))
                Next
                p1 = n * (i + 1) - 1
                p2 = n * (i + 1)
                p3 = n * (i + 2) - 1
                setpoly(newpl(i), p1, p2, p3)
                ListPolygon.Add(newpl(i))
                p1 = n * (i + 1) - 1
                p2 = n * i
                p3 = n * (i + 1)
                setpoly(newpl(i), p1, p2, p3)
                ListPolygon.Add(newpl(i))
            Else
                For j = 0 To n - 2
                    p1 = n * i + j
                    p2 = n * i + j + 1
                    p3 = m / 2 * n
                    setpoly(newpl(j), p1, p2, p3)
                    ListPolygon.Add(newpl(j))
                Next
                p1 = n * (i + 1) - 1
                p2 = n * i
                p3 = n * (i + 1)
                setpoly(newpl(i), p1, p2, p3)
                ListPolygon.Add(newpl(i))
            End If
        Next
        DrawPoly()
        PictureBox1.Image = image
    End Sub

    Sub DrawPoly()
        Dim pen As New Pen(Color.Red, 1)
        Dim vs, vs2 As New List(Of TPoint)
        setMatrix(screen, 0, 1, 0, 0, 200 + 0) 'transx.Text)
        setMatrix(screen, 1, 0, -1, 0, 200 + 0) 'transy.Text)
        setMatrix(screen, 2, 0, 0, 0, 0 + 0) 'transz.Text)
        setMatrix(screen, 3, 0, 0, 0, 1)

        For Each point As TPoint In lpoint1
            Dim pxsc As New TPoint With {
                .x = (point.x * screen(0, 0)) + (point.y * screen(0, 1)) + (point.z * screen(0, 2)) + (point.w * screen(0, 3)),
                .y = (point.x * screen(1, 0)) + (point.y * screen(1, 1)) + (point.z * screen(1, 2)) + (point.w * screen(1, 3)),
                .z = (point.x * screen(2, 0)) + (point.y * screen(2, 1)) + (point.z * screen(2, 2)) + (point.w * screen(2, 3)),
                .w = (point.x * screen(3, 0)) + (point.y * screen(3, 1)) + (point.z * screen(3, 2)) + (point.w * screen(3, 3))
                }
            vs.Add(pxsc)
        Next

        For Each point As TPoint In lpoint2
            Dim pxsc As New TPoint With {
                .x = (point.x * screen(0, 0)) + (point.y * screen(0, 1)) + (point.z * screen(0, 2)) + (point.w * screen(0, 3)),
                .y = (point.x * screen(1, 0)) + (point.y * screen(1, 1)) + (point.z * screen(1, 2)) + (point.w * screen(1, 3)),
                .z = (point.x * screen(2, 0)) + (point.y * screen(2, 1)) + (point.z * screen(2, 2)) + (point.w * screen(2, 3)),
                .w = (point.x * screen(3, 0)) + (point.y * screen(3, 1)) + (point.z * screen(3, 2)) + (point.w * screen(3, 3))
                }
            vs2.Add(pxsc)
        Next

        For Each Poly As TPolygon In ListPolygon
            Dim u, v, N As New TPoint

            u.x = vs(Poly.p1).x - vs(Poly.p3).x
            u.y = vs(Poly.p1).y - vs(Poly.p3).y
            u.z = vs(Poly.p1).z - vs(Poly.p3).z
            u.w = 1

            v.x = vs(Poly.p1).x - vs(Poly.p2).x
            v.y = vs(Poly.p1).y - vs(Poly.p2).y
            v.z = vs(Poly.p1).z - vs(Poly.p2).z
            v.w = 1

            N.x = u.y * v.z - u.z * v.y
            N.y = u.z * v.x - u.x * v.z
            N.z = u.x * v.y - u.y * v.x
            N.w = 1

            Dim norm As New TPoint With {
        .x = 0 * N.x,
        .y = 0 * N.y,
        .z = -1 * N.z,
        .w = 1
        }
            Dim identifier As New Single
            identifier = norm.x + norm.y + norm.z

            Dim temp As List(Of Point) = New List(Of Point)
            Dim tempP As Point
            If identifier < 0 Then
                tempP.X = vs(Poly.p1).x
                tempP.Y = vs(Poly.p1).y
                temp.Add(tempP)

                tempP.X = vs(Poly.p2).x
                tempP.Y = vs(Poly.p2).y
                temp.Add(tempP)

                tempP.X = vs(Poly.p3).x
                tempP.Y = vs(Poly.p3).y
                temp.Add(tempP)


                'gr.DrawPolygon(pen, temp.ToArray)
                Dim blueBrush As New SolidBrush(Color.Red)
                gr.FillPolygon(blueBrush, temp.ToArray)

                gr.DrawLine(pen, vs(Poly.p1).x, vs(Poly.p1).y, vs(Poly.p2).x, vs(Poly.p2).y)
                gr.DrawLine(pen, vs(Poly.p2).x, vs(Poly.p2).y, vs(Poly.p3).x, vs(Poly.p3).y)
                gr.DrawLine(pen, vs(Poly.p3).x, vs(Poly.p3).y, vs(Poly.p1).x, vs(Poly.p1).y)
            End If
        Next

        For Each Poly As TPolygon In ListPolygon
            Dim u, v, N As New TPoint

            u.x = vs2(Poly.p1).x - vs2(Poly.p3).x
            u.y = vs2(Poly.p1).y - vs2(Poly.p3).y
            u.z = vs2(Poly.p1).z - vs2(Poly.p3).z
            u.w = 1

            v.x = vs2(Poly.p1).x - vs2(Poly.p2).x
            v.y = vs2(Poly.p1).y - vs2(Poly.p2).y
            v.z = vs2(Poly.p1).z - vs2(Poly.p2).z
            v.w = 1

            N.x = u.y * v.z - u.z * v.y
            N.y = u.z * v.x - u.x * v.z
            N.z = u.x * v.y - u.y * v.x
            N.w = 1

            Dim norm As New TPoint With {
        .x = 0 * N.x,
        .y = 0 * N.y,
        .z = -1 * N.z,
        .w = 1
        }
            Dim identifier As New Single
            identifier = norm.x + norm.y + norm.z

            Dim temp As List(Of Point) = New List(Of Point)
            Dim tempP As Point
            If identifier < 0 Then
                tempP.X = vs2(Poly.p1).x
                tempP.Y = vs2(Poly.p1).y
                temp.Add(tempP)

                tempP.X = vs2(Poly.p2).x
                tempP.Y = vs2(Poly.p2).y
                temp.Add(tempP)

                tempP.X = vs2(Poly.p3).x
                tempP.Y = vs2(Poly.p3).y
                temp.Add(tempP)


                'gr.DrawPolygon(pen, temp.ToArray)
                Dim blueBrush As New SolidBrush(Color.Red)
                gr.FillPolygon(blueBrush, temp.ToArray)

                gr.DrawLine(pen, vs2(Poly.p1).x, vs2(Poly.p1).y, vs2(Poly.p2).x, vs2(Poly.p2).y)
                gr.DrawLine(pen, vs2(Poly.p2).x, vs2(Poly.p2).y, vs2(Poly.p3).x, vs2(Poly.p3).y)
                gr.DrawLine(pen, vs2(Poly.p3).x, vs2(Poly.p3).y, vs2(Poly.p1).x, vs2(Poly.p1).y)
            End If
        Next

    End Sub


    Private Sub refresh_Click(sender As Object, e As EventArgs) Handles refreshBtn.Click
        image = New Bitmap(PictureBox1.Width, PictureBox1.Height)
        gr = Graphics.FromImage(image)
        gr.Clear(Color.White)
        drawSphere()
    End Sub

End Class
