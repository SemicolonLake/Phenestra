Imports LQUSMLib.Windows
Imports LQUSMLib.Windows.Settings

Friend Class FormWindowTree
    Private Sub TreeView_Main_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView_Main.AfterSelect
        Try : FormProperties.PropertyGrid_Main.SelectedObject = WindowManager.From(CType(TreeView_Main.SelectedNode.Tag, IntPtr)) : Catch : FormProperties.PropertyGrid_Main.SelectedObject = Nothing : End Try
        FormProperties2.wnd = WindowManager.From(CType(TreeView_Main.SelectedNode.Tag, IntPtr))
        mainWindow.UpdateProperties(WindowManager.From(CType(TreeView_Main.SelectedNode.Tag, IntPtr)))
    End Sub

    Private Sub TextBox_Search_TextChanged(sender As Object, e As EventArgs) Handles TextBox_Search.TextChanged
        mainWindow.Search = TextBox_Search.Text
    End Sub
    Private Sub Button_Search_Click(sender As Object, e As EventArgs) Handles Button_Search.Click
        mainWindow.RefreshWindowList()
    End Sub

    Private Sub MenuItem_Refresh_Click(sender As Object, e As EventArgs) Handles MenuItem_Refresh.Click
        mainWindow.MenuItem_Window_RefreshList_Click(Nothing, Nothing)
    End Sub

    Private Sub MenuItem_Close_Click(sender As Object, e As EventArgs) Handles MenuItem_Close.Click
        mainWindow.MenuItem_Window_Close_Click(Nothing, Nothing)
    End Sub

    Private Sub MenuItem_Destroy_Click(sender As Object, e As EventArgs) Handles MenuItem_Destroy.Click
        mainWindow.MenuItem_Window_Destroy_Click(Nothing, Nothing)
    End Sub

    Private Sub MenuItem_Focus_Click(sender As Object, e As EventArgs) Handles MenuItem_Focus.Click
        mainWindow.MenuItem_Window_Focus_Click(Nothing, Nothing)
    End Sub

    Private Sub MenuItem_ForceClose_Click(sender As Object, e As EventArgs) Handles MenuItem_ForceClose.Click
        mainWindow.MenuItem_Window_ForceClose_Click(Nothing, Nothing)
    End Sub

    Private Sub mainTimer_Tick(sender As Object, e As EventArgs) Handles mainTimer.Tick
        MenuItem_Close.Enabled = mainWindow.MenuItem_Window_Close.Enabled
        MenuItem_ForceClose.Enabled = mainWindow.MenuItem_Window_ForceClose.Enabled
        MenuItem_Destroy.Enabled = mainWindow.MenuItem_Window_Destroy.Enabled
        MenuItem_Focus.Enabled = mainWindow.MenuItem_Window_Focus.Enabled
    End Sub

    Private Sub FormWindowTree_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TreeView_Main.ContextMenu = ContextMenu_Main
        TextBox_Search.Text = mainWindow.Search
        CheckBox_MatchCase.Checked = mainWindow.MatchCase
    End Sub

    Private Sub TextBox_Search_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox_Search.KeyDown
        If e.KeyCode = Keys.Enter Then
            mainWindow.RefreshWindowList()
        End If
    End Sub

    Private Sub CheckBox_MatchCase_click(sender As Object, e As EventArgs) Handles CheckBox_MatchCase.Click
        mainWindow.MatchCase = CheckBox_MatchCase.Checked
    End Sub
End Class