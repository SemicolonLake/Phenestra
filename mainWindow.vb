Imports System.Drawing.Imaging
Imports System.IO
Imports System.Reflection
Imports System.Text
Imports LQUSMLib.Configuration
Imports LQUSMLib.Windows
Imports LQUSMLib.Windows.Dialogs
Imports LQUSMLib.Windows.Dialogs.Internal
Imports LQUSMLib.Windows.Settings
Imports LQUSMLib
Imports System.ComponentModel
Imports WeifenLuo.WinFormsUI.Docking
Friend Class mainWindow
    'Lang
    Public LK_Root As String = "ROOT"
    Public LK_NoTitle As String = "(无标题)"
    Public LK_About As String = "关于 {0}"
    Public LK_STATUSBAR_WNDNUM As String = "总共 {0} 个窗口"
    Public LK_STATUSBAR_CHDWNDNUM As String = "共 {0} 个子窗口"
    Public LK_STATUSBAR_MAINWNDNUM As String = "共 {0} 个主窗口"
    Public LK_MESSAGE_GLOBALSHORTCUT_DEBUG As String = "调试快捷键可能会导致程序无法获取焦点或无法退出的情况，如要设置调试快捷键必须设置退出快捷键！"
    'Search
    Public Search As String = ""
    Public MatchCase As Boolean = False
    'Common
    Public config As New IniParser(False)
    Public ShortcutDetector As New ShortcutDetector
    Public PropertiesLoaded As Boolean = False
    Public LastSelectHWND As IntPtr = 0
    Public CountWnd As Integer = 0
    Public CountChildWnd As Integer = 0
    Public CountDisplayedWnd As Integer = 0
    Public PauseShortcutDetection As Boolean = False
    Public ShortcutPauseTimems As Integer = 500
    'Path
    Public Path_ConfigPath As String = "%localappdata%\LQUSM Software\Phenestra\".ParseEnviromentVariable
    Public Path_ConfigFilePath As String = Path_ConfigPath & "\Phenestra.cfg"
    'Shortcut
    Public Shortcut_Focus As String = "WIN+F9"
    Public Shortcut_TopMost As String = "WIN+F12"
    Public Shortcut_NoActivate As String = "WIN+F11"
    Public Shortcut_Exit As String = "WIN+F10"
    'Helper
    Private Class WindowNodeInfo
        Public Handle As IntPtr
        Public Title As String
        Public ClassName As String
    End Class
    Private ReadOnly NodeInfoMap As New Dictionary(Of TreeNode, WindowNodeInfo)()
    Public Sub Helper_AddWndToTreeView(ByVal TreeviewNode As TreeNode)
        If TreeviewNode Is Nothing Then Return
        If TreeviewNode.Tag Is Nothing Then
            For Each w As WindowManager In WindowManager.GetWindows()
                If w.Handle <> Me.Handle Then
                    AddWindowNode(TreeviewNode, w)
                    CountWnd += 1
                End If
            Next
        Else
            Dim parentHandle As IntPtr
            Try
                parentHandle = CType(TreeviewNode.Tag, IntPtr)
            Catch
                Return
            End Try

            Dim parentWm As WindowManager = WindowManager.From(parentHandle)
            Try
                For Each child As WindowManager In parentWm.ChildWindows
                    Dim childParentHandle As IntPtr = IntPtr.Zero
                    Try
                        childParentHandle = child.ParentWindow.Handle
                    Catch
                        childParentHandle = IntPtr.Zero
                    End Try
                    If childParentHandle = parentHandle Then
                        CountChildWnd += 1
                        AddWindowNode(TreeviewNode, child)
                    End If
                Next
            Catch
            End Try
        End If
    End Sub
    Private Sub AddWindowNode(ByVal parentNode As TreeNode, ByVal wm As WindowManager)
        Dim title As String = ""
        Dim cls As String = ""
        Try
            title = wm.Text
        Catch
            title = ""
        End Try
        Try
            cls = wm.ClassName()
        Catch
            cls = ""
        End Try
        Dim displayTitle As String = title
        If String.IsNullOrWhiteSpace(displayTitle) Then displayTitle = LK_NoTitle
        Dim text As String = String.Format("{0} [{1}] 0x{2:X}", displayTitle, cls, wm.Handle.ToInt64())
        Dim node As New TreeNode(text)
        node.Tag = wm.Handle
        NodeInfoMap(node) = New WindowNodeInfo With {
            .Handle = wm.Handle,
            .Title = title,
            .ClassName = cls
        }

        parentNode.Nodes.Add(node)
        Helper_AddWndToTreeView(node)
    End Sub
    Public Sub RefreshWindowList()
        FormWindowTree.TreeView_Main.Nodes.Clear()
        NodeInfoMap.Clear()
        CountChildWnd = 0
        CountWnd = 0
        Dim root As TreeNode = FormWindowTree.TreeView_Main.Nodes.Add(LK_Root)
        Helper_AddWndToTreeView(root)

        If Not String.IsNullOrWhiteSpace(Search) Then
            FilterNodes(FormWindowTree.TreeView_Main.Nodes)
            FormWindowTree.TreeView_Main.ExpandAll()
        Else
            root.Expand()
        End If
    End Sub
    Private Function FilterNodes(nodes As TreeNodeCollection) As Boolean
        Dim anyKeep As Boolean = False
        Dim toRemove As New List(Of TreeNode)

        For Each node As TreeNode In nodes
            Dim childKeep As Boolean = False
            If node.Nodes.Count > 0 Then
                childKeep = FilterNodes(node.Nodes)
            End If

            Dim selfMatch As Boolean = NodeMatches(node)

            If selfMatch OrElse childKeep Then
                anyKeep = True
            Else
                toRemove.Add(node)
            End If
        Next

        For Each n As TreeNode In toRemove
            NodeInfoMap.Remove(n)
            nodes.Remove(n)
        Next

        Return anyKeep
    End Function
    Private Function NodeMatches(node As TreeNode) As Boolean
        If String.IsNullOrWhiteSpace(Search) Then Return True

        Dim cmp As StringComparison = If(MatchCase, StringComparison.Ordinal, StringComparison.OrdinalIgnoreCase)
        Dim info As WindowNodeInfo = Nothing
        If NodeInfoMap.TryGetValue(node, info) Then
            If Not String.IsNullOrEmpty(info.Title) AndAlso info.Title.IndexOf(Search, cmp) >= 0 Then Return True
            If String.IsNullOrWhiteSpace(info.Title) AndAlso Not String.IsNullOrEmpty(LK_NoTitle) AndAlso LK_NoTitle.IndexOf(Search, cmp) >= 0 Then Return True
            If Not String.IsNullOrEmpty(info.ClassName) AndAlso info.ClassName.IndexOf(Search, cmp) >= 0 Then Return True
        End If
        If node.Tag IsNot Nothing Then
            Dim h As Long
            Try
                h = CType(node.Tag, IntPtr).ToInt64()
            Catch
                h = 0L
            End Try
            If h <> 0L Then
                Dim hex As String = h.ToString("X")
                Dim dec As String = h.ToString()
                If hex.IndexOf(Search, cmp) >= 0 Then Return True
                If ("0x" & hex).IndexOf(Search, cmp) >= 0 Then Return True
                If dec.IndexOf(Search, cmp) >= 0 Then Return True
            End If
        End If
        If node.Text IsNot Nothing AndAlso node.Text.IndexOf(Search, cmp) >= 0 Then Return True

        Return False
    End Function
    Public Sub UpdateProperties(window As WindowManager)
        If window IsNot Nothing Then
            PropertiesLoaded = False
            'Style
            On Error Resume Next
            FormProperties2.CheckBox_HelpButton.Checked = window.HelpButton
            On Error Resume Next
            FormProperties2.CheckBox_CloseBox.Checked = window.CloseBox
            On Error Resume Next
            FormProperties2.CheckBox_MaximizedBox.Checked = window.MaximizeBox
            On Error Resume Next
            FormProperties2.CheckBox_MinimizedBox.Checked = window.MinimizeBox
            On Error Resume Next
            FormProperties2.CheckBox_TitleBar.Checked = window.TitleBar
            On Error Resume Next
            FormProperties2.CheckBox_ControlBox.Checked = window.ControlBox
            On Error Resume Next
            FormProperties2.CheckBox_Border.Checked = window.Border
            On Error Resume Next
            FormProperties2.CheckBox_DialogFrame.Checked = window.DialogFrame
            On Error Resume Next
            FormProperties2.CheckBox_DialogModalFrame.Checked = window.DialogModalFrame
            On Error Resume Next
            FormProperties2.CheckBox_Fixed3DBorder.Checked = window.Fixed3DBorder
            On Error Resume Next
            FormProperties2.CheckBox_IsToolWindow.Checked = window.IsToolWindow
            On Error Resume Next
            FormProperties2.CheckBox_Layered.Checked = window.Layered
            On Error Resume Next
            FormProperties2.CheckBox_StaticEdge.Checked = window.StaticEdge
            On Error Resume Next
            FormProperties2.CheckBox_Transparent.Checked = window.Transparent
            On Error Resume Next
            FormProperties2.CheckBox_DoNotInheritLayout.Checked = window.DoNotInheritLayout
            On Error Resume Next
            FormProperties2.CheckBox_HorizontalScrollBar.Checked = window.HorizontalScrollBar
            On Error Resume Next
            FormProperties2.CheckBox_LeftVerticalScrollBar.Checked = window.LeftVerticalScrollBar
            On Error Resume Next
            FormProperties2.CheckBox_RightAlign.Checked = window.RightAlign
            On Error Resume Next
            FormProperties2.CheckBox_RightToLeftLayout.Checked = window.RightToLeftLayout
            On Error Resume Next
            FormProperties2.CheckBox_VerticalScrollBar.Checked = window.VerticalScrollBar
            On Error Resume Next
            FormProperties2.NumericUpDown_Opacity.Value = window.Opacity
            On Error Resume Next
            FormProperties2.CheckBox_RightToLeftReading.Checked = window.RightToLeftReading
            On Error Resume Next
            FormProperties2.CheckBox_WindowEdge.Checked = window.WindowEdge
            'Basic
            On Error Resume Next
            FormProperties2.TextBox_Text.Text = window.Text
            On Error Resume Next
            FormProperties2.TextBox_Size_W.Text = window.Size.Width
            On Error Resume Next
            FormProperties2.TextBox_Size_H.Text = window.Size.Height
            On Error Resume Next
            FormProperties2.TextBox_Location_X.Text = window.Location.X
            On Error Resume Next
            FormProperties2.TextBox_Location_Y.Text = window.Location.Y
            On Error Resume Next
            FormProperties2.RadioButton_WindowState_Maximized.Checked = window.WindowState = FormWindowState.Maximized
            On Error Resume Next
            FormProperties2.RadioButton_WindowState_Minimized.Checked = window.WindowState = FormWindowState.Minimized
            On Error Resume Next
            FormProperties2.RadioButton_WindowState_Normal.Checked = window.WindowState = FormWindowState.Normal
            On Error Resume Next
            FormProperties2.CheckBox_TopMost.Checked = window.TopMost
            On Error Resume Next
            FormProperties2.CheckBox_Resizable.Checked = window.Resizable
            On Error Resume Next
            FormProperties2.CheckBox_Visible.Checked = window.Visible
            On Error Resume Next
            FormProperties2.CheckBox_Enabled.Checked = window.Enabled
            On Error Resume Next
            FormProperties2.CheckBox_IsApplicationWindow.Checked = window.IsApplicationWindow
            On Error Resume Next
            FormProperties2.CheckBox_IsChildWindow.Checked = window.IsChildWindow
            On Error Resume Next
            FormProperties2.CheckBox_IsMDIChildWindow.Checked = window.IsMDIChildWindow
            On Error Resume Next
            FormProperties2.CheckBox_AllowDragDropFiles.Checked = window.AllowDragDropFiles
            On Error Resume Next
            FormProperties2.CheckBox_ClipChildren.Checked = window.ClipChildren
            On Error Resume Next
            FormProperties2.CheckBox_ClipSiblings.Checked = window.ClipSiblings
            On Error Resume Next
            FormProperties2.CheckBox_Composited.Checked = window.Composited
            On Error Resume Next
            FormProperties2.CheckBox_ControlParent.Checked = window.ControlParent
            On Error Resume Next
            FormProperties2.CheckBox_NoActivate.Checked = window.NoActivate
            On Error Resume Next
            FormProperties2.CheckBox_NoParentNotify.Checked = window.NoParentNotify
            On Error Resume Next
            FormProperties2.CheckBox_NoRedirectionBitmap.Checked = window.NoRedirectionBitmap
            On Error Resume Next
            FormProperties2.CheckBox_RightToLeftReading.Checked = window.RightToLeftReading
            PropertiesLoaded = True
        End If
    End Sub
    Public Sub SetProperties(window As WindowManager, Optional update As Boolean = True)
        If PropertiesLoaded = True And window IsNot Nothing Then
            On Error Resume Next
            window.HelpButton = FormProperties2.CheckBox_HelpButton.Checked
            On Error Resume Next
            window.CloseBox = FormProperties2.CheckBox_CloseBox.Checked
            On Error Resume Next
            window.MaximizeBox = FormProperties2.CheckBox_MaximizedBox.Checked
            On Error Resume Next
            window.MinimizeBox = FormProperties2.CheckBox_MinimizedBox.Checked
            On Error Resume Next
            window.TitleBar = FormProperties2.CheckBox_TitleBar.Checked
            On Error Resume Next
            window.ControlBox = FormProperties2.CheckBox_ControlBox.Checked
            On Error Resume Next
            window.Border = FormProperties2.CheckBox_Border.Checked
            On Error Resume Next
            window.DialogFrame = FormProperties2.CheckBox_DialogFrame.Checked
            On Error Resume Next
            window.DialogModalFrame = FormProperties2.CheckBox_DialogModalFrame.Checked
            On Error Resume Next
            window.Fixed3DBorder = FormProperties2.CheckBox_Fixed3DBorder.Checked
            On Error Resume Next
            window.IsToolWindow = FormProperties2.CheckBox_IsToolWindow.Checked
            On Error Resume Next
            window.Layered = FormProperties2.CheckBox_Layered.Checked
            On Error Resume Next
            window.StaticEdge = FormProperties2.CheckBox_StaticEdge.Checked
            On Error Resume Next
            window.Transparent = FormProperties2.CheckBox_Transparent.Checked
            On Error Resume Next
            window.DoNotInheritLayout = FormProperties2.CheckBox_DoNotInheritLayout.Checked
            On Error Resume Next
            window.HorizontalScrollBar = FormProperties2.CheckBox_HorizontalScrollBar.Checked
            On Error Resume Next
            window.LeftVerticalScrollBar = FormProperties2.CheckBox_LeftVerticalScrollBar.Checked
            On Error Resume Next
            window.RightAlign = FormProperties2.CheckBox_RightAlign.Checked
            On Error Resume Next
            window.RightToLeftLayout = FormProperties2.CheckBox_RightToLeftLayout.Checked
            On Error Resume Next
            window.VerticalScrollBar = FormProperties2.CheckBox_VerticalScrollBar.Checked
            On Error Resume Next
            window.Opacity = FormProperties2.NumericUpDown_Opacity.Value
            On Error Resume Next
            window.RightToLeftReading = FormProperties2.CheckBox_RightToLeftReading.Checked
            On Error Resume Next
            window.WindowEdge = FormProperties2.CheckBox_WindowEdge.Checked
            'Basic
            On Error Resume Next
            window.Text = FormProperties2.TextBox_Text.Text
            On Error Resume Next
            window.Size = New Size(FormProperties2.TextBox_Size_W.Text, FormProperties2.TextBox_Size_H.Text)
            On Error Resume Next
            window.Location = New Point(FormProperties2.TextBox_Location_X.Text, FormProperties2.TextBox_Location_Y.Text)
            On Error Resume Next
            window.TopMost = FormProperties2.CheckBox_TopMost.Checked
            If FormProperties2.RadioButton_WindowState_Maximized.Checked Then
                On Error Resume Next
                window.WindowState = FormWindowState.Maximized
                WindowManager.From(Me).Focus()
            ElseIf FormProperties2.RadioButton_WindowState_Minimized.Checked Then
                On Error Resume Next
                window.WindowState = FormWindowState.Minimized
                WindowManager.From(Me).Focus()
            ElseIf FormProperties2.RadioButton_WindowState_Normal.Checked Then
                On Error Resume Next
                window.WindowState = FormWindowState.Normal
                WindowManager.From(Me).Focus()
            End If
            On Error Resume Next
            window.Resizable = FormProperties2.CheckBox_Resizable.Checked
            On Error Resume Next
            window.Visible = FormProperties2.CheckBox_Visible.Checked
            On Error Resume Next
            window.Enabled = FormProperties2.CheckBox_Enabled.Checked
            On Error Resume Next
            window.IsApplicationWindow = FormProperties2.CheckBox_IsApplicationWindow.Checked
            On Error Resume Next
            window.IsChildWindow = FormProperties2.CheckBox_IsChildWindow.Checked
            On Error Resume Next
            window.IsMDIChildWindow = FormProperties2.CheckBox_IsMDIChildWindow.Checked
            'Behavior
            On Error Resume Next
            window.AllowDragDropFiles = FormProperties2.CheckBox_AllowDragDropFiles.Checked
            On Error Resume Next
            window.ClipChildren = FormProperties2.CheckBox_ClipChildren.Checked
            On Error Resume Next
            window.ClipSiblings = FormProperties2.CheckBox_ClipSiblings.Checked
            On Error Resume Next
            window.Composited = FormProperties2.CheckBox_Composited.Checked
            On Error Resume Next
            window.ControlParent = FormProperties2.CheckBox_ControlParent.Checked
            On Error Resume Next
            window.NoActivate = FormProperties2.CheckBox_NoActivate.Checked
            On Error Resume Next
            window.NoParentNotify = FormProperties2.CheckBox_NoParentNotify.Checked
            On Error Resume Next
            window.NoRedirectionBitmap = FormProperties2.CheckBox_NoRedirectionBitmap.Checked
            On Error Resume Next
            window.RightToLeftReading = FormProperties2.CheckBox_RightToLeftReading.Checked
            If update = True Then
                UpdateProperties(window)
            End If
        End If
    End Sub
    Public Sub SaveSettings()
        On Error Resume Next
        IO.Directory.CreateDirectory(Path_ConfigPath)
        With config
            If WindowState = FormWindowState.Normal Then
                .SetValue("MainWindow", "X", Location.X)
                .SetValue("MainWindow", "Y", Location.Y)
                .SetValue("MainWindow", "Height", Size.Height)
                .SetValue("MainWindow", "Width", Size.Width)
            End If
            .SetValue("MainWindow", "Maximized", WindowState = FormWindowState.Maximized)
            .SetValue("MainWindow", "Search", Search)
            .SetValue("MainWindow", "MatchCase", MatchCase)
            On Error Resume Next
            .Save(Path_ConfigFilePath)
        End With
    End Sub
    Public Sub LoadSettings()
        With config
            On Error Resume Next
            .Open(Path_ConfigFilePath)
            On Error Resume Next
            Location = New Point(.Default("MainWindow", "X", Location.X), .Default("MainWindow", "Y", Location.Y))
            On Error Resume Next
            Size = New Point(.Default("MainWindow", "Width", Size.Width), .Default("MainWindow", "Height", Size.Height))
            On Error Resume Next
            If .Default("MainWindow", "Maximized", WindowState = FormWindowState.Maximized) = True Then WindowState = FormWindowState.Maximized Else WindowState = FormWindowState.Normal
            On Error Resume Next
            Search = .Default("MainWindow", "Search", Search)
            On Error Resume Next
            MatchCase = .Default("MainWindow", "MatchCase", MatchCase)
        End With
    End Sub
    'Events
    Private Sub mainWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadSettings()
        Call MenuItem_View_Properties_Click(Nothing, Nothing)
        Call MenuItem_View_WindowTree_Click(Nothing, Nothing)
        RefreshWindowList()
    End Sub
    Private Sub mainWindow_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        SaveSettings()
    End Sub
    Private Sub mainTimer_Tick(sender As Object, e As EventArgs) Handles mainTimer.Tick
        'Shortcut
        If ShortcutDetector.DetectShortcut(Shortcut_Exit) = True Then
            Close()
        End If
        'StatusBar
        StatusBarPanel_TotalWndNum.Text = LK_STATUSBAR_WNDNUM.Replace("{0}", CountWnd + CountChildWnd)
        StatusBarPanel_MainWndNum.Text = LK_STATUSBAR_MAINWNDNUM.Replace("{0}", CountWnd)
        StatusBarPanel_ChildWndNum.Text = LK_STATUSBAR_CHDWNDNUM.Replace("{0}", CountChildWnd)

        '
        If FormWindowTree.TreeView_Main.SelectedNode IsNot Nothing AndAlso FormWindowTree.TreeView_Main.SelectedNode.Tag IsNot Nothing Then
            Dim handle As IntPtr = CType(FormWindowTree.TreeView_Main.SelectedNode.Tag, IntPtr)
            If handle <> LastSelectHWND Then
                LastSelectHWND = handle
                If handle <> 0 Then
                    Text = $"{My.Application.Info.Title} - [{handle.ToInt64} (0x{Hex(handle.ToInt64)})]"
                Else
                    Text = My.Application.Info.Title
                End If
            End If
            MenuItem_Files_Save.Enabled = handle <> 0
            MenuItem_Window_Close.Enabled = handle <> 0
            MenuItem_Window_Destroy.Enabled = handle <> 0
            MenuItem_Window_ForceClose.Enabled = handle <> 0
            MenuItem_Window_Focus.Enabled = handle <> 0
        Else
            Try : MenuItem_Files_Save.Enabled = False                          : catch : end try
                Try : MenuItem_Window_Close.Enabled = False                    : catch : end try
                    Try : MenuItem_Window_Destroy.Enabled = False              : catch : end try
                        Try : MenuItem_Window_ForceClose.Enabled = False       : catch : end try
                            Try : MenuItem_Window_Focus.Enabled = False        : catch : end try
                                Text = My.Application.Info.Title
        End If
        'MenuItem_View
        MenuItem_View_StatusBar.Checked = MainStatusBar.Visible
    End Sub
    Private Sub ShortcutTimer_Tick(sender As Object, e As EventArgs) Handles ShortcutTimer.Tick

        If PauseShortcutDetection = False Then
            If ShortcutDetector.DetectShortcut(Shortcut_Focus) = True Then
                WindowManager.From(Me).Focus()
                System.Threading.Thread.Sleep(ShortcutPauseTimems)
            End If
            If ShortcutDetector.DetectShortcut(Shortcut_TopMost) = True Then
                Me.TopMost = Not Me.TopMost
                System.Threading.Thread.Sleep(ShortcutPauseTimems)
            End If
            If ShortcutDetector.DetectShortcut(Shortcut_NoActivate) = True Then
                WindowManager.From(Me).NoActivate = Not WindowManager.From(Me).NoActivate
                System.Threading.Thread.Sleep(ShortcutPauseTimems)
            End If

        End If
    End Sub
    'MenuItem_Window
    Public Sub MenuItem_Window_RefreshList_Click(sender As Object, e As EventArgs) Handles MenuItem_Window_RefreshList.Click
        RefreshWindowList()
    End Sub
    Public Sub MenuItem_Window_Close_Click(sender As Object, e As EventArgs) Handles MenuItem_Window_Close.Click
        If FormProperties2.wnd IsNot Nothing Then
            Try
                FormProperties2.wnd.Close()
                RefreshWindowList()
                WindowManager.From(Me).Focus()
            Catch ex As Exception
                MsgBox(ex.Message, 16, My.Application.Info.Title)
            End Try
        End If
    End Sub
    Public Sub MenuItem_Window_Destroy_Click(sender As Object, e As EventArgs) Handles MenuItem_Window_Destroy.Click
        If FormProperties2.wnd IsNot Nothing Then
            Try
                FormProperties2.wnd.Destroy()
                RefreshWindowList()
                WindowManager.From(Me).Focus()
            Catch ex As Exception
                MsgBox(ex.Message, 16, My.Application.Info.Title)
            End Try
        End If
    End Sub
    Public Sub MenuItem_Window_Focus_Click(sender As Object, e As EventArgs) Handles MenuItem_Window_Focus.Click
        If FormProperties2.wnd IsNot Nothing Then
            Try
                FormProperties2.wnd.Focus()
            Catch ex As Exception
                MsgBox(ex.Message, 16, My.Application.Info.Title)
            End Try
        End If
    End Sub
    Public Sub MenuItem_Window_ForceClose_Click(sender As Object, e As EventArgs) Handles MenuItem_Window_ForceClose.Click
        If FormProperties2.wnd IsNot Nothing Then
            Try
                FormProperties2.wnd.ForceClose()
                RefreshWindowList()
                WindowManager.From(Me).Focus()
            Catch ex As Exception
                MsgBox(ex.Message, 16, My.Application.Info.Title)
            End Try
        End If
    End Sub
    'MenuItem_View
    Private Sub MenuItem_View_WindowTree_Click(sender As Object, e As EventArgs) Handles MenuItem_View_WindowTree.Click
        FormWindowTree.Show(MainDockPanel, WeifenLuo.WinFormsUI.Docking.DockState.Document)
    End Sub
    Private Sub MenuItem_View_Properties_Click(sender As Object, e As EventArgs) Handles MenuItem_View_Properties.Click
        FormProperties2.Show(MainDockPanel, WeifenLuo.WinFormsUI.Docking.DockState.DockLeft)
        With FormProperties2.DockPanel
            .DockLeftPortion = 266 * (DisplaySettings.GetCurrentMonitorDisplaySettings.GetScreenScaling / 100)
            .DockRightPortion = 266 * (DisplaySettings.GetCurrentMonitorDisplaySettings.GetScreenScaling / 100)
            .DockTopPortion = 266 * (DisplaySettings.GetCurrentMonitorDisplaySettings.GetScreenScaling / 100)
            .DockBottomPortion = 266 * (DisplaySettings.GetCurrentMonitorDisplaySettings.GetScreenScaling / 100)
        End With
    End Sub
    'MenuItem_Help
    Private Sub MenuItem_Help_About_Click(sender As Object, e As EventArgs) Handles MenuItem_Help_About.Click
        Dim dialog As New AboutAppDialog
        dialog.ApplicationName = My.Application.Info.Title
        dialog.Version = My.Application.Info.Version.ToString
        dialog.Title = LK_About.Replace("{0}", My.Application.Info.Title)
        dialog.Copyright = My.Application.Info.Copyright
        dialog.Author = My.Application.Info.CompanyName
        dialog.DialogIcon = Me.Icon
        On Error Resume Next
        dialog.LoadLicensesFrom(My.Application.Info.DirectoryPath & "\Licenses")
        On Error Resume Next
        dialog.ApplicationIcon = Image.FromFile(My.Application.Info.DirectoryPath & "\Phenestra.png")
        dialog.ShowDialog()
    End Sub
    'MenuItem_Files
    Private Sub MenuItem_Files_Exit_Click(sender As Object, e As EventArgs) Handles MenuItem_Files_Exit.Click
        Close()
    End Sub
    Private Sub MenuItem_Files_Save_Click(sender As Object, e As EventArgs) Handles MenuItem_Files_Save.Click
        Dim dialog As New SaveFileDialog
        dialog.DereferenceLinks = False
        Dim lk_WindowConfigInfo As String = "窗口信息" '.ini
        Dim lk_WindowSmallIcon As String = "窗口小图标" '.ico
        Dim lk_WindowLargeIcon As String = "窗口大图标" '.ico
        Dim lk_WindowImage As String = "窗口客户区图像" '.jpg;png
        Dim builder As New StringBuilder
        builder.Append($"|{lk_WindowConfigInfo}|.ini")
        Dim smallicon_ As Boolean = False
        Dim largeicon_ As Boolean = False
        Dim image_ As Boolean = False
        If FormProperties2.wnd IsNot Nothing Then
            dialog.FileName = $"{FormProperties2.wnd.Text}[{FormProperties2.wnd.Handle}][{FormProperties2.wnd.ClassName}].ini"
            For Each i As Char In IO.Path.GetInvalidFileNameChars
                dialog.FileName = dialog.FileName.Replace(i, "_")
            Next
            Try
                If FormProperties2.wnd.SmallIcon IsNot Nothing Then
                    builder.Append($"|{lk_WindowSmallIcon}|.ico")
                    smallicon_ = True
                End If
            Catch : End Try
            Try
                If FormProperties2.wnd.LargeIcon IsNot Nothing Then
                    builder.Append($"|{lk_WindowLargeIcon}|.ico")
                    largeicon_ = True
                End If
            Catch : End Try
            Try
                If FormProperties2.wnd.ClientImage IsNot Nothing Then
                    builder.Append($"|{lk_WindowImage}|.png;*.jpg;*.jpeg")
                    image_ = True
                End If
            Catch : End Try
        Else
            '
        End If
        dialog.Filter = builder.ToString.Trim("|")
        If dialog.ShowDialog = DialogResult.OK Then
            If dialog.FilterIndex = 1 Then
                ExportWindowInfo(dialog.FileName)
            Else
                If smallicon_ = True And largeicon_ = True And image_ = True Then
                    Select Case dialog.FilterIndex
                        Case 2
                            ExportSmallIcon(dialog.FileName)
                        Case 3
                            ExportLargeIcon(dialog.FileName)
                        Case 4
                            SaveWndImg(dialog.FileName)
                    End Select
                ElseIf smallicon_ = False And largeicon_ = False And image_ = False Then
                    'Do Noting
                ElseIf smallicon_ = False And largeicon_ = True And image_ = True Then
                    Select Case dialog.FilterIndex
                        Case 2
                            ExportLargeIcon(dialog.FileName)
                        Case 3
                            SaveWndImg(dialog.FileName)
                    End Select
                ElseIf smallicon_ = True And largeicon_ = False And image_ = True Then
                    Select Case dialog.FilterIndex
                        Case 2
                            ExportSmallIcon(dialog.FileName)
                        Case 3
                            SaveWndImg(dialog.FileName)
                    End Select
                ElseIf smallicon_ = False And largeicon_ = False And image_ = True Then
                    Select Case dialog.FilterIndex
                        Case 2
                            SaveWndImg(dialog.FileName)
                    End Select
                ElseIf smallicon_ = True And largeicon_ = True And image_ = False Then
                    Select Case dialog.FilterIndex
                        Case 2
                            ExportSmallIcon(dialog.FileName)
                        Case 3
                            ExportLargeIcon(dialog.FileName)
                    End Select
                End If
            End If
        End If
    End Sub
    Public Sub SaveWndImg(fileName As String)
        Try
            FormProperties2.wnd.ClientImage.Save(fileName)
        Catch ex As Exception
            MsgBox(ex.Message, 16, My.Application.Info.Title)
        End Try
    End Sub
    Public Sub ExportWindowInfo(filename As String)
        Dim ini As New IniParser(False)
        Try : ini.SetValue("Basic", "Title", FormProperties2.wnd.Text) : Catch : End Try
        Try : ini.SetValue("Basic", "Width", FormProperties2.wnd.Size.Width) : Catch : End Try
        Try : ini.SetValue("Basic", "Height", FormProperties2.wnd.Size.Height) : Catch : End Try
        Try : ini.SetValue("Basic", "X", FormProperties2.wnd.Location.X) : Catch : End Try
        Try : ini.SetValue("Basic", "Y", FormProperties2.wnd.Location.Y) : Catch : End Try
        Try : ini.SetValue("Basic", "WindowState", FormProperties2.wnd.WindowState) : Catch : End Try
        Try : ini.SetValue("Basic", "TopMost", FormProperties2.wnd.TopMost) : Catch : End Try
        Try : ini.SetValue("Basic", "Visible", FormProperties2.wnd.Visible) : Catch : End Try
        Try : ini.SetValue("Basic", "Resizable", FormProperties2.wnd.Resizable) : Catch : End Try
        Try : ini.SetValue("Basic", "Enabled", FormProperties2.wnd.Enabled) : Catch : End Try
        Try : ini.SetValue("Basic", "IsApplicationWindow", FormProperties2.wnd.IsApplicationWindow) : Catch : End Try
        Try : ini.SetValue("Basic", "IsChildWindow", FormProperties2.wnd.IsChildWindow) : Catch : End Try
        Try : ini.SetValue("Basic", "IsMDIChildWindow", FormProperties2.wnd.IsMDIChildWindow) : Catch : End Try
        '
        Try : ini.SetValue("Style", "HelpButton", FormProperties2.wnd.HelpButton) : Catch : End Try
        Try : ini.SetValue("Style", "CloseBox", FormProperties2.wnd.CloseBox) : Catch : End Try
        Try : ini.SetValue("Style", "MaximizeBox", FormProperties2.wnd.MaximizeBox) : Catch : End Try
        Try : ini.SetValue("Style", "MinimizeBox", FormProperties2.wnd.MinimizeBox) : Catch : End Try
        Try : ini.SetValue("Style", "TitleBar", FormProperties2.wnd.TitleBar) : Catch : End Try
        Try : ini.SetValue("Style", "ControlBox", FormProperties2.wnd.ControlBox) : Catch : End Try
        Try : ini.SetValue("Style", "Border", FormProperties2.wnd.Border) : Catch : End Try
        Try : ini.SetValue("Style", "DialogFrame", FormProperties2.wnd.DialogFrame) : Catch : End Try
        Try : ini.SetValue("Style", "DialogModalFrame", FormProperties2.wnd.DialogModalFrame) : Catch : End Try
        Try : ini.SetValue("Style", "Fixed3DBorder", FormProperties2.wnd.Fixed3DBorder) : Catch : End Try
        Try : ini.SetValue("Style", "IsToolWindow", FormProperties2.wnd.IsToolWindow) : Catch : End Try
        Try : ini.SetValue("Style", "Layered", FormProperties2.wnd.Layered) : Catch : End Try
        Try : ini.SetValue("Style", "StaticEdge", FormProperties2.wnd.StaticEdge) : Catch : End Try
        Try : ini.SetValue("Style", "WindowEdge", FormProperties2.wnd.WindowEdge) : Catch : End Try
        Try : ini.SetValue("Style", "RightAlign", FormProperties2.wnd.RightAlign) : Catch : End Try
        Try : ini.SetValue("Style", "DoNotInheritLayout", FormProperties2.wnd.DoNotInheritLayout) : Catch : End Try
        Try : ini.SetValue("Style", "RightToLeftLayout", FormProperties2.wnd.RightToLeftLayout) : Catch : End Try
        Try : ini.SetValue("Style", "RightToLeftReading", FormProperties2.wnd.RightToLeftReading) : Catch : End Try
        Try : ini.SetValue("Style", "HorizontalScrollBar", FormProperties2.wnd.HorizontalScrollBar) : Catch : End Try
        Try : ini.SetValue("Style", "LeftVerticalScrollBar", FormProperties2.wnd.LeftVerticalScrollBar) : Catch : End Try
        Try : ini.SetValue("Style", "VerticalScrollBar", FormProperties2.wnd.VerticalScrollBar) : Catch : End Try
        Try : ini.SetValue("Style", "Transparent", FormProperties2.wnd.Transparent) : Catch : End Try
        Try : ini.SetValue("Style", "Opacity", FormProperties2.wnd.Opacity) : Catch : End Try
        ' 
        Try : ini.SetValue("Behavior", "AllowDragDropFiles", FormProperties2.wnd.AllowDragDropFiles) : Catch : End Try
        Try : ini.SetValue("Behavior", "ClipChildren", FormProperties2.wnd.ClipChildren) : Catch : End Try
        Try : ini.SetValue("Behavior", "ClipSiblings", FormProperties2.wnd.ClipSiblings) : Catch : End Try
        Try : ini.SetValue("Behavior", "Composited", FormProperties2.wnd.Composited) : Catch : End Try
        Try : ini.SetValue("Behavior", "ControlParent", FormProperties2.wnd.ControlParent) : Catch : End Try
        Try : ini.SetValue("Behavior", "NoParentNotify", FormProperties2.wnd.NoParentNotify) : Catch : End Try
        Try : ini.SetValue("Behavior", "NoRedirectionBitmap", FormProperties2.wnd.NoRedirectionBitmap) : Catch : End Try
        Try : ini.SetValue("Behavior", "Arranged", FormProperties2.wnd.Arranged) : Catch : End Try
        Try : ini.SetValue("Behavior", "Focused", FormProperties2.wnd.Focused) : Catch : End Try
        Try : ini.SetValue("Behavior", "Hung", FormProperties2.wnd.Hunging) : Catch : End Try
        Try : ini.SetValue("Behavior", "IsPopupWindow", FormProperties2.wnd.IsPopupWindow) : Catch : End Try
        '
        Try : ini.SetValue("Info", "Handle", FormProperties2.wnd.Handle) : Catch : End Try
        Try : ini.SetValue("Info", "FileName", FormProperties2.wnd.FileName) : Catch : End Try
        Try : ini.SetValue("Info", "ScaleFactor", FormProperties2.wnd.GetCurrentWindowScaleFactor) : Catch : End Try
        Try : ini.SetValue("Info", "GWL_STYLE", FormProperties2.wnd.StyleHandle) : Catch : End Try
        Try : ini.SetValue("Info", "GWL_EXSTYLE", FormProperties2.wnd.ExtendedStyleHandle) : Catch : End Try
        Try : ini.SetValue("Info", "GWL_HINSTANCE", FormProperties2.wnd.InstanceHandle) : Catch : End Try
        Try : ini.SetValue("Info", "GWL_HWNDPARENT", FormProperties2.wnd.ParentHandle) : Catch : End Try
        Try : ini.SetValue("Info", "GWL_USERDATA", FormProperties2.wnd.UserDataHandle) : Catch : End Try
        Try : ini.SetValue("Info", "GWL_WNDPROC", FormProperties2.wnd.WndProc) : Catch : End Try
        Try : ini.SetValue("Info", "GWL_ID", FormProperties2.wnd.ID) : Catch : End Try
        ini.Text = $"Export time : {Now.ToString} {vbCrLf}{ini.Text}"
        Try
            ini.Save(filename)
        Catch ex As Exception
            MsgBox(ex.Message, 16, My.Application.Info.Title)
        End Try
    End Sub
    Public Sub ExportSmallIcon(filename As String)
        Try
            FormProperties2.wnd.SmallIcon.ToBitmap.Save(filename, ImageFormat.Icon)
        Catch ex As Exception
            MsgBox(ex.Message, 16, My.Application.Info.Title)
        End Try
    End Sub
    Public Sub ExportLargeIcon(filename As String)
        Try
            FormProperties2.wnd.LargeIcon.ToBitmap.Save(filename, ImageFormat.Icon)
        Catch ex As Exception
            MsgBox(ex.Message, 16, My.Application.Info.Title)
        End Try
    End Sub
    Private Sub MenuItem_View_StatusBar_Click(sender As Object, e As EventArgs) Handles MenuItem_View_StatusBar.Click
        MainStatusBar.Visible = Not MainStatusBar.Visible
    End Sub
    'MenuItem_Configuration
    Private Sub MenuItem_Configuration_GlobalShortcut_Click(sender As Object, e As EventArgs) Handles MenuItem_Configuration_GlobalShortcut.Click
        DialogGlobalShortcut.ShowDialog()
    End Sub
End Class