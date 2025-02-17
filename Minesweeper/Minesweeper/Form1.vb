Public Class Minesweeper

    Dim n As Integer = 5
    Dim mines As Integer = 2

    Dim btn(n, n) As Button
    Dim board(n, n) As Integer
    Dim positions As List(Of Integer)
    Dim ctr As Integer
    Dim gameOver As Boolean

    Private Sub loadGame()
        positions = New List(Of Integer)
        ctr = n * n - mines
        gameOver = False
        For i = 0 To n - 1
            For j = 0 To n - 1
                Dim k As Integer = i * n + j
                btn(i, j) = DirectCast(Me.Controls.Find("Button" & (k + 1), False).First(), Button)
                btn(i, j).Text = ""
                board(i, j) = 0
            Next
        Next
        positions.Clear()
        For k = 0 To n * n - 1
            positions.Add(k)
        Next
        For k = 1 To mines
            Dim rn As Random = New Random()
            Dim index As Integer = rn.Next(0, positions.Count)
            Dim pos = positions(index)
            Dim row As Integer = pos / n
            Dim col As Integer = pos Mod n
            board(row, col) = -1
            positions.RemoveAt(index)
        Next
        Dim dy() As Integer = {-1, -1, 0, 1, 1, 1, 0, -1}
        Dim dx() As Integer = {0, 1, 1, 1, 0, -1, -1, -1}
        For i = 0 To n - 1
            For j = 0 To n - 1
                If board(i, j) <> -1 Then
                    For k = 0 To 7
                        If i + dy(k) >= 0 And i + dy(k) <= n - 1 And j + dx(k) >= 0 And j + dx(k) <= n - 1 Then
                            If board(i + dy(k), j + dx(k)) = -1 Then
                                board(i, j) += 1
                            End If
                        End If
                    Next
                End If
            Next
        Next
    End Sub

    Private Sub Minesweeper_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadGame()
    End Sub

    Private Sub btn_click(sender As Object, e As EventArgs) Handles Button9.Click, Button8.Click, Button7.Click, Button6.Click, Button5.Click, Button4.Click, Button3.Click, Button25.Click, Button24.Click, Button23.Click, Button22.Click, Button21.Click, Button20.Click, Button2.Click, Button19.Click, Button18.Click, Button17.Click, Button16.Click, Button15.Click, Button14.Click, Button13.Click, Button12.Click, Button11.Click, Button10.Click, Button1.Click
        If Not gameOver Then
            Dim y As Integer = -1
            Dim x As Integer = -1
            For i = 0 To n - 1
                For j = 0 To n - 1
                    If btn(i, j) Is sender Then
                        y = i
                        x = j
                        Exit For
                    End If
                Next
            Next
            If board(y, x) <> -1 Then
                btn(y, x).Text = board(y, x).ToString()
                ctr -= 1
                If ctr = 0 Then
                    gameOver = True
                    MessageBox.Show("You win !")
                End If
            Else
                btn(y, x).Text = "#"
                gameOver = True
                MessageBox.Show("Game Over !")
            End If
        End If
    End Sub

    Private Sub restartBtn_Click(sender As Object, e As EventArgs) Handles restartBtn.Click
        loadGame()
    End Sub

End Class
