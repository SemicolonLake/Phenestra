Imports System.Reflection
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports LQUSMLib.Windows
Friend Class FormProperties2
    Public wnd As WindowManager
    Dim lastWidth As Integer = 0
    Dim lastHeight As Integer = 0
    Dim lastX As Integer = 0
    Dim lastY As Integer = 0
    Dim lastWindowState As FormWindowState = FormWindowState.Normal
    Dim lasthandle As IntPtr = 0
    Dim last_gwl_style As IntPtr = 0
    Dim last_gwl_exstyle As IntPtr = 0
    Dim last_gwl_hinstance As IntPtr = 0
    Dim last_gwl_hwndparent As IntPtr = 0
    Dim last_gwl_userdata As IntPtr = 0
    Dim last_gwl_wndproc As IntPtr = 0
    Dim last_pid As IntPtr = 0
    Dim last_gwl_id As IntPtr = 0
    Dim lastFileName As String = ""
    Dim lastScaleFactor As Single = 0
    Dim lastmaxloc As Point = New Point(0, 0)
    Dim lastrstloc As Point = New Point(0, 0)
    Dim lastminloc As Point = New Point(0, 0)
    Private Sub mainTimer_Tick(sender As Object, e As EventArgs) Handles mainTimer.Tick
        If wnd IsNot Nothing Then
            If lastWidth <> wnd.Size.Width Or lastHeight <> wnd.Size.Height Then
                lastWidth = wnd.Size.Width
                lastHeight = wnd.Size.Height
                TextBox_Size_W.Text = lastWidth
                TextBox_Size_H.Text = lastHeight
            End If
            If lastX <> wnd.Location.X Or lastY <> wnd.Location.Y Then
                lastX = wnd.Location.X
                lastY = wnd.Location.Y
                TextBox_Location_X.Text = lastX
                TextBox_Location_Y.Text = lastY
            End If
            If lastWindowState <> wnd.WindowState Then
                lastWindowState = wnd.WindowState
                Try : RadioButton_WindowState_Maximized.Checked = wnd.WindowState = FormWindowState.Maximized : Catch : End Try
                Try : RadioButton_WindowState_Minimized.Checked = wnd.WindowState = FormWindowState.Minimized : Catch : End Try
                Try : RadioButton_WindowState_Normal.Checked = wnd.WindowState = FormWindowState.Normal : Catch : End Try
            End If
            If lasthandle <> wnd.Handle Then
                lasthandle = wnd.Handle
                TextBox_Handle.Text = lasthandle
            End If
            If last_gwl_style <> wnd.StyleHandle Then
                last_gwl_style = wnd.StyleHandle
                TextBox_GWL_Style.Text = last_gwl_style
            End If
            If last_gwl_exstyle <> wnd.ExtendedStyleHandle Then
                last_gwl_exstyle = wnd.ExtendedStyleHandle
                TextBox_GWL_EXSTYLE.Text = last_gwl_exstyle
            End If
            If last_gwl_hinstance <> wnd.InstanceHandle Then
                last_gwl_hinstance = wnd.InstanceHandle
                TextBox_GWL_HINSTANCE.Text = last_gwl_hinstance
            End If
            If last_gwl_hwndparent <> wnd.ParentHandle Then
                last_gwl_hwndparent = wnd.ParentHandle
                TextBox_GWL_HWNDPARENT.Text = last_gwl_hwndparent
            End If
            If last_gwl_userdata <> wnd.UserDataHandle Then
                last_gwl_userdata = wnd.UserDataHandle
                TextBox_GWL_USERDATA.Text = last_gwl_userdata
            End If
            If last_gwl_wndproc <> wnd.WndProc Then
                last_gwl_wndproc = wnd.WndProc
                TextBox_GWL_WNDPROC.Text = last_gwl_wndproc
            End If
            If last_gwl_id <> wnd.ID Then
                last_gwl_id = wnd.ID
                TextBox_gwl_id.Text = last_gwl_id
            End If
            Try
                If lastFileName <> wnd.FileName Then
                    lastFileName = wnd.FileName
                    TextBox_FileName.Text = lastFileName
                End If
            Catch
                lastFileName = ""
                TextBox_FileName.Text = lastFileName
            End Try
            Try
                If lastScaleFactor <> wnd.GetCurrentWindowScaleFactor Then
                    lastScaleFactor = wnd.GetCurrentWindowScaleFactor
                    TextBox_ScaleFactor.Text = lastScaleFactor * 100 & "%"
                End If
            Catch
                TextBox_ScaleFactor.Text = "NOT SUPPORT"
            End Try
            Try : CheckBox_Hunging.Enabled = True : CheckBox_Hunging.Checked = wnd.Hunging : Catch : CheckBox_Hunging.Enabled = False : End Try
            Try : CheckBox_Focused.Enabled = True : CheckBox_Focused.Checked = wnd.Focused : Catch : CheckBox_Focused.Enabled = False : End Try
            Try : CheckBox_Arranged.Enabled = True : CheckBox_Arranged.Checked = wnd.Arranged : Catch : CheckBox_Arranged.Enabled = False : End Try
            Try : CheckBox_IsPopupWindow.Enabled = True : CheckBox_IsPopupWindow.Checked = wnd.IsPopupWindow : Catch : CheckBox_IsPopupWindow.Enabled = False : End Try
            TabControl_Main.Visible = wnd.Handle <> 0
            If lastmaxloc.X <> wnd.MaximumLocation.X Or lastmaxloc.Y <> wnd.MaximumLocation.Y Then
                    lastmaxloc = wnd.MaximumLocation
                    TextBox_MaximumLocation_X.Text = lastmaxloc.X
                    TextBox_MaximumLocation_Y.Text = lastmaxloc.Y
                End If
                If lastminloc.X <> wnd.MinimumLocation.X Or lastmaxloc.Y <> wnd.MinimumLocation.Y Then
                lastminloc = wnd.MinimumLocation
                TextBox_MinimumLocation_X.Text = lastminloc.X
                TextBox_MinimumLocation_Y.Text = lastminloc.Y
            End If
            If lastrstloc.X <> wnd.RestoreLocation.X Or lastrstloc.Y <> wnd.RestoreLocation.Y Then
                    lastrstloc = wnd.RestoreLocation
                    TextBox_RestoreLocation_X.Text = lastrstloc.X
                    TextBox_RestoreLocation_Y.Text = lastrstloc.Y
                End If
            Try
                If last_pid <> wnd.Process.Id Then
                    last_pid = wnd.Process.Id
                    TextBox_PID.Text = last_pid
                End If
            Catch
                TextBox_PID.Text = ""
            End Try
        Else
            TabControl_Main.Visible = False
        End If
    End Sub
    'Style
    Private Sub CheckBox_HelpButton_Click(sender As Object, e As EventArgs) Handles CheckBox_HelpButton.Click
        mainWindow.SetProperties(wnd)
    End Sub
    Private Sub CheckBox_CloseBox_Click(sender As Object, e As EventArgs) Handles CheckBox_CloseBox.Click
        mainWindow.SetProperties(wnd)
    End Sub
    Private Sub CheckBox_MaximizedBox_Click(sender As Object, e As EventArgs) Handles CheckBox_MaximizedBox.Click
        mainWindow.SetProperties(wnd)
    End Sub
    Private Sub CheckBox_MinimizedBox_Click(sender As Object, e As EventArgs) Handles CheckBox_MinimizedBox.Click
        mainWindow.SetProperties(wnd)
    End Sub
    Private Sub CheckBox_TitleBar_Click(sender As Object, e As EventArgs) Handles CheckBox_TitleBar.Click
        mainWindow.SetProperties(wnd)
    End Sub
    Private Sub CheckBox_ControlBox_Click(sender As Object, e As EventArgs) Handles CheckBox_ControlBox.Click
        mainWindow.SetProperties(wnd)
    End Sub
    Private Sub CheckBox_Border_Click(sender As Object, e As EventArgs) Handles CheckBox_Border.Click
        mainWindow.SetProperties(wnd)
    End Sub
    Private Sub CheckBox_DialogFrame_Click(sender As Object, e As EventArgs) Handles CheckBox_DialogFrame.Click
        mainWindow.SetProperties(wnd)
    End Sub
    Private Sub CheckBox_DialogModalFrame_Click(sender As Object, e As EventArgs) Handles CheckBox_DialogModalFrame.Click
        mainWindow.SetProperties(wnd)
    End Sub
    Private Sub CheckBox_Fixed3DBorder_Click(sender As Object, e As EventArgs) Handles CheckBox_Fixed3DBorder.Click
        mainWindow.SetProperties(wnd)
    End Sub
    Private Sub CheckBox_IsToolWindow_Click(sender As Object, e As EventArgs) Handles CheckBox_IsToolWindow.Click
        mainWindow.SetProperties(wnd)
    End Sub
    Private Sub CheckBox_Layered_Click(sender As Object, e As EventArgs) Handles CheckBox_Layered.Click
        mainWindow.SetProperties(wnd)
    End Sub
    Private Sub CheckBox_StaticEdge_Click(sender As Object, e As EventArgs) Handles CheckBox_StaticEdge.Click
        mainWindow.SetProperties(wnd)
    End Sub
    Private Sub CheckBox_Transparent_Click(sender As Object, e As EventArgs) Handles CheckBox_Transparent.Click
        mainWindow.SetProperties(wnd)
    End Sub
    Private Sub CheckBox_DoNotInheritLayout_Click(sender As Object, e As EventArgs) Handles CheckBox_DoNotInheritLayout.Click
        mainWindow.SetProperties(wnd)
    End Sub
    Private Sub CheckBox_HorizontalScrollBar_Click(sender As Object, e As EventArgs) Handles CheckBox_HorizontalScrollBar.Click
        mainWindow.SetProperties(wnd)
    End Sub
    Private Sub CheckBox_LeftVerticalScrollBar_Click(sender As Object, e As EventArgs) Handles CheckBox_LeftVerticalScrollBar.Click
        mainWindow.SetProperties(wnd)
    End Sub
    Private Sub CheckBox_RightAlign_Click(sender As Object, e As EventArgs) Handles CheckBox_RightAlign.Click
        mainWindow.SetProperties(wnd)
    End Sub
    Private Sub CheckBox_RightToLeftLayout_Click(sender As Object, e As EventArgs) Handles CheckBox_RightToLeftLayout.Click
        mainWindow.SetProperties(wnd)
    End Sub
    Private Sub CheckBox_VerticalScrollBar_Click(sender As Object, e As EventArgs) Handles CheckBox_VerticalScrollBar.Click
        mainWindow.SetProperties(wnd)
    End Sub
    Private Sub NumericUpDown_Opacity_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown_Opacity.ValueChanged
        mainWindow.SetProperties(wnd)
    End Sub
    Private Sub CheckBox_RightToLeftReading_Click(sender As Object, e As EventArgs) Handles CheckBox_RightToLeftReading.Click
        mainWindow.SetProperties(wnd)
    End Sub
    Private Sub CheckBox_WindowEdge_Click(sender As Object, e As EventArgs) Handles CheckBox_WindowEdge.Click
        mainWindow.SetProperties(wnd)
    End Sub
    'Basic
    Private Sub TextBox_Text_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox_Text.KeyDown
        If e.KeyCode = Keys.Enter Then
            mainWindow.SetProperties(wnd)
        End If
    End Sub
    Private Sub TextBox_Text_LostFocus(sender As Object, e As EventArgs) Handles TextBox_Text.LostFocus
        mainWindow.UpdateProperties(wnd)
    End Sub
    Private Sub TextBox_Size_W_LostFocus(sender As Object, e As EventArgs) Handles TextBox_Size_W.LostFocus
        mainWindow.UpdateProperties(wnd)
    End Sub
    Private Sub TextBox_Size_H_LostFocus(sender As Object, e As EventArgs) Handles TextBox_Size_H.LostFocus
        mainWindow.UpdateProperties(wnd)
    End Sub
    Private Sub TextBox_Location_X_LostFocus(sender As Object, e As EventArgs) Handles TextBox_Location_X.LostFocus
        mainWindow.UpdateProperties(wnd)
    End Sub
    Private Sub TextBox_Location_Y_LostFocus(sender As Object, e As EventArgs) Handles TextBox_Location_Y.LostFocus
        mainWindow.UpdateProperties(wnd)
    End Sub
    Private Sub TextBox_Size_W_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox_Size_W.KeyDown
        If e.KeyCode = Keys.Enter Then
            If IsNumeric(TextBox_Size_W.Text) = True Then
                mainWindow.SetProperties(wnd)
            Else
                mainWindow.UpdateProperties(wnd)
            End If
        End If
    End Sub
    Private Sub TextBox_Size_H_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox_Size_H.KeyDown
        If e.KeyCode = Keys.Enter Then
            If IsNumeric(TextBox_Size_H.Text) = True Then
                mainWindow.SetProperties(wnd)
            Else
                mainWindow.UpdateProperties(wnd)
            End If
        End If
    End Sub
    Private Sub TextBox_Location_X_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox_Location_X.KeyDown
        If e.KeyCode = Keys.Enter Then
            If IsNumeric(TextBox_Location_X.Text) = True Then
                mainWindow.SetProperties(wnd)
            Else
                mainWindow.UpdateProperties(wnd)
            End If
        End If
    End Sub
    Private Sub TextBox_Location_Y_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox_Location_Y.KeyDown
        If e.KeyCode = Keys.Enter Then
            If IsNumeric(TextBox_Location_Y.Text) = True Then
                mainWindow.SetProperties(wnd)
            Else
                mainWindow.UpdateProperties(wnd)
            End If
        End If
    End Sub
    Private Sub CheckBox_TopMost_Click(sender As Object, e As EventArgs) Handles CheckBox_TopMost.Click
        mainWindow.SetProperties(wnd)
    End Sub
    Private Sub RadioButton_WindowState_Normal_Click(sender As Object, e As EventArgs) Handles RadioButton_WindowState_Normal.Click
        mainWindow.SetProperties(wnd)
    End Sub
    Private Sub RadioButton_WindowState_Maximized_Click(sender As Object, e As EventArgs) Handles RadioButton_WindowState_Maximized.Click
        mainWindow.SetProperties(wnd)
    End Sub
    Private Sub RadioButton_WindowState_Minimized_Click(sender As Object, e As EventArgs) Handles RadioButton_WindowState_Minimized.Click
        mainWindow.SetProperties(wnd)
    End Sub
    Private Sub CheckBox_Visible_Click(sender As Object, e As EventArgs) Handles CheckBox_Visible.Click
        mainWindow.SetProperties(wnd)
    End Sub
    Private Sub CheckBox_Resizable_Click(sender As Object, e As EventArgs) Handles CheckBox_Resizable.Click
        mainWindow.SetProperties(wnd)
    End Sub
    Private Sub CheckBox_Enabled_Click(sender As Object, e As EventArgs) Handles CheckBox_Enabled.Click
        mainWindow.SetProperties(wnd)
    End Sub
    Private Sub CheckBox_IsApplicationWindow_Click(sender As Object, e As EventArgs) Handles CheckBox_IsApplicationWindow.Click
        mainWindow.SetProperties(wnd)
    End Sub
    Private Sub CheckBox_IsChildWindow_Click(sender As Object, e As EventArgs) Handles CheckBox_IsChildWindow.Click
        mainWindow.SetProperties(wnd)
    End Sub
    Private Sub CheckBox_IsMDIChildWindow_Click(sender As Object, e As EventArgs) Handles CheckBox_IsMDIChildWindow.Click
        mainWindow.SetProperties(wnd)
    End Sub

    'Behavior
    Private Sub CheckBox_AllowDragDropFiles_Click(sender As Object, e As EventArgs) Handles CheckBox_AllowDragDropFiles.Click
        mainWindow.SetProperties(wnd)
    End Sub
    Private Sub CheckBox_ClipChildren_Click(sender As Object, e As EventArgs) Handles CheckBox_ClipChildren.Click
        mainWindow.SetProperties(wnd)
    End Sub
    Private Sub CheckBox_ClipSiblings_Click(sender As Object, e As EventArgs) Handles CheckBox_ClipSiblings.Click
        mainWindow.SetProperties(wnd)
    End Sub
    Private Sub CheckBox_Composited_Click(sender As Object, e As EventArgs) Handles CheckBox_Composited.Click
        mainWindow.SetProperties(wnd)
    End Sub
    Private Sub CheckBox_ControlParent_Click(sender As Object, e As EventArgs) Handles CheckBox_ControlParent.Click
        mainWindow.SetProperties(wnd)
    End Sub
    Private Sub CheckBox_NoActivate_Click(sender As Object, e As EventArgs) Handles CheckBox_NoActivate.Click
        mainWindow.SetProperties(wnd)
    End Sub
    Private Sub CheckBox_NoParentNotify_Click(sender As Object, e As EventArgs) Handles CheckBox_NoParentNotify.Click
        mainWindow.SetProperties(wnd)
    End Sub
    Private Sub CheckBox_NoRedirectionBitmap_Click(sender As Object, e As EventArgs) Handles CheckBox_NoRedirectionBitmap.Click
        mainWindow.SetProperties(wnd)
    End Sub
End Class