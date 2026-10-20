Imports System.Windows.Forms

Friend Class DialogGlobalShortcut
    Private Sub OKBtn_Click(sender As Object, e As EventArgs) Handles OKBtn.Click
        If S_Commands_Exit.Expression = "" And (S_Debug_NoActivate.Expression <> "" Or S_Debug_TopMost.Expression <> "") Then
            MsgBox(mainWindow.LK_MESSAGE_GLOBALSHORTCUT_DEBUG, 48, My.Application.Info.Title)
            TabControl_Main.SelectedTab = TabPage_Commands
            S_Commands_Exit.Focus()
        Else
            mainWindow.Shortcut_Focus = S_Commands_Focus.Expression
            mainWindow.Shortcut_NoActivate = S_Debug_TopMost.Expression
            mainWindow.Shortcut_TopMost = S_Debug_TopMost.Expression
            Close()
        End If
    End Sub

    Private Sub CancelBtn_Click(sender As Object, e As EventArgs) Handles CancelBtn.Click
        Close()
    End Sub

    Private Sub DialogGlobalShortcut_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        On Error Resume Next
        S_Debug_TopMost.Expression = mainWindow.Shortcut_TopMost
        On Error Resume Next
        S_Debug_NoActivate.Expression = mainWindow.Shortcut_NoActivate
        On Error Resume Next
        S_Commands_Focus.Expression = mainWindow.Shortcut_Focus
        On Error Resume Next
        S_Commands_Exit.Expression = mainWindow.Shortcut_Exit
    End Sub
End Class
