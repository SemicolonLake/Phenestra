<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class mainWindow
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
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

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(mainWindow))
        Me.VS2015LightTheme1 = New WeifenLuo.WinFormsUI.Docking.VS2015LightTheme()
        Me.AppMenu = New System.Windows.Forms.MainMenu(Me.components)
        Me.MenuItem_Files = New System.Windows.Forms.MenuItem()
        Me.MenuItem_Files_Save = New System.Windows.Forms.MenuItem()
        Me.MenuItem_Files_1 = New System.Windows.Forms.MenuItem()
        Me.MenuItem_Files_Exit = New System.Windows.Forms.MenuItem()
        Me.MenuItem_Window = New System.Windows.Forms.MenuItem()
        Me.MenuItem_Window_RefreshList = New System.Windows.Forms.MenuItem()
        Me.MenuItem_Window_1 = New System.Windows.Forms.MenuItem()
        Me.MenuItem_Window_Close = New System.Windows.Forms.MenuItem()
        Me.MenuItem_Window_Destroy = New System.Windows.Forms.MenuItem()
        Me.MenuItem_Window_Focus = New System.Windows.Forms.MenuItem()
        Me.MenuItem_Window_ForceClose = New System.Windows.Forms.MenuItem()
        Me.MenuItem_View = New System.Windows.Forms.MenuItem()
        Me.MenuItem_View_WindowTree = New System.Windows.Forms.MenuItem()
        Me.MenuItem_View_Properties = New System.Windows.Forms.MenuItem()
        Me.MenuItem1 = New System.Windows.Forms.MenuItem()
        Me.MenuItem_View_StatusBar = New System.Windows.Forms.MenuItem()
        Me.MenuItem_Configuration = New System.Windows.Forms.MenuItem()
        Me.MenuItem_Configuration_GlobalShortcut = New System.Windows.Forms.MenuItem()
        Me.MenuItem_Help = New System.Windows.Forms.MenuItem()
        Me.MenuItem_Help_About = New System.Windows.Forms.MenuItem()
        Me.MainDockPanel = New WeifenLuo.WinFormsUI.Docking.DockPanel()
        Me.mainTimer = New System.Windows.Forms.Timer(Me.components)
        Me.MainStatusBar = New System.Windows.Forms.StatusBar()
        Me.StatusBarPanel_TotalWndNum = New System.Windows.Forms.StatusBarPanel()
        Me.StatusBarPanel_MainWndNum = New System.Windows.Forms.StatusBarPanel()
        Me.StatusBarPanel_ChildWndNum = New System.Windows.Forms.StatusBarPanel()
        Me.ShortcutTimer = New System.Windows.Forms.Timer(Me.components)
        CType(Me.StatusBarPanel_TotalWndNum, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StatusBarPanel_MainWndNum, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StatusBarPanel_ChildWndNum, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'AppMenu
        '
        Me.AppMenu.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem_Files, Me.MenuItem_Window, Me.MenuItem_View, Me.MenuItem_Configuration, Me.MenuItem_Help})
        '
        'MenuItem_Files
        '
        Me.MenuItem_Files.Index = 0
        Me.MenuItem_Files.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem_Files_Save, Me.MenuItem_Files_1, Me.MenuItem_Files_Exit})
        Me.MenuItem_Files.Text = "文件(&F)"
        '
        'MenuItem_Files_Save
        '
        Me.MenuItem_Files_Save.Index = 0
        Me.MenuItem_Files_Save.Shortcut = System.Windows.Forms.Shortcut.CtrlS
        Me.MenuItem_Files_Save.Text = "保存(&S)"
        '
        'MenuItem_Files_1
        '
        Me.MenuItem_Files_1.Index = 1
        Me.MenuItem_Files_1.Text = "-"
        '
        'MenuItem_Files_Exit
        '
        Me.MenuItem_Files_Exit.Index = 2
        Me.MenuItem_Files_Exit.Shortcut = System.Windows.Forms.Shortcut.AltF4
        Me.MenuItem_Files_Exit.Text = "退出(&X)"
        '
        'MenuItem_Window
        '
        Me.MenuItem_Window.Index = 1
        Me.MenuItem_Window.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem_Window_RefreshList, Me.MenuItem_Window_1, Me.MenuItem_Window_Close, Me.MenuItem_Window_Destroy, Me.MenuItem_Window_Focus, Me.MenuItem_Window_ForceClose})
        Me.MenuItem_Window.Text = "窗口(&W)"
        '
        'MenuItem_Window_RefreshList
        '
        Me.MenuItem_Window_RefreshList.Index = 0
        Me.MenuItem_Window_RefreshList.Shortcut = System.Windows.Forms.Shortcut.F5
        Me.MenuItem_Window_RefreshList.Text = "刷新(&R)"
        '
        'MenuItem_Window_1
        '
        Me.MenuItem_Window_1.Index = 1
        Me.MenuItem_Window_1.Text = "-"
        '
        'MenuItem_Window_Close
        '
        Me.MenuItem_Window_Close.Index = 2
        Me.MenuItem_Window_Close.Shortcut = System.Windows.Forms.Shortcut.F4
        Me.MenuItem_Window_Close.Text = "关闭(&C)"
        '
        'MenuItem_Window_Destroy
        '
        Me.MenuItem_Window_Destroy.Index = 3
        Me.MenuItem_Window_Destroy.Shortcut = System.Windows.Forms.Shortcut.CtrlD
        Me.MenuItem_Window_Destroy.Text = "销毁(&D)"
        '
        'MenuItem_Window_Focus
        '
        Me.MenuItem_Window_Focus.Index = 4
        Me.MenuItem_Window_Focus.Shortcut = System.Windows.Forms.Shortcut.CtrlQ
        Me.MenuItem_Window_Focus.Text = "切换至(&F)"
        '
        'MenuItem_Window_ForceClose
        '
        Me.MenuItem_Window_ForceClose.Index = 5
        Me.MenuItem_Window_ForceClose.Shortcut = System.Windows.Forms.Shortcut.CtrlShiftX
        Me.MenuItem_Window_ForceClose.Text = "强制关闭(&O)"
        '
        'MenuItem_View
        '
        Me.MenuItem_View.Index = 2
        Me.MenuItem_View.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem_View_WindowTree, Me.MenuItem_View_Properties, Me.MenuItem1, Me.MenuItem_View_StatusBar})
        Me.MenuItem_View.Text = "视图(&V)"
        '
        'MenuItem_View_WindowTree
        '
        Me.MenuItem_View_WindowTree.Index = 0
        Me.MenuItem_View_WindowTree.Shortcut = System.Windows.Forms.Shortcut.Alt1
        Me.MenuItem_View_WindowTree.Text = "窗口树"
        '
        'MenuItem_View_Properties
        '
        Me.MenuItem_View_Properties.Index = 1
        Me.MenuItem_View_Properties.Shortcut = System.Windows.Forms.Shortcut.Alt2
        Me.MenuItem_View_Properties.Text = "标记/属性"
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 2
        Me.MenuItem1.Text = "-"
        '
        'MenuItem_View_StatusBar
        '
        Me.MenuItem_View_StatusBar.Index = 3
        Me.MenuItem_View_StatusBar.Text = "状态栏(&S)"
        '
        'MenuItem_Configuration
        '
        Me.MenuItem_Configuration.Index = 3
        Me.MenuItem_Configuration.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem_Configuration_GlobalShortcut})
        Me.MenuItem_Configuration.Text = "配置(&C)"
        '
        'MenuItem_Configuration_GlobalShortcut
        '
        Me.MenuItem_Configuration_GlobalShortcut.Index = 0
        Me.MenuItem_Configuration_GlobalShortcut.Shortcut = System.Windows.Forms.Shortcut.F12
        Me.MenuItem_Configuration_GlobalShortcut.Text = "设置全局快捷键(S)"
        '
        'MenuItem_Help
        '
        Me.MenuItem_Help.Index = 4
        Me.MenuItem_Help.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem_Help_About})
        Me.MenuItem_Help.Text = "帮助(&H)"
        '
        'MenuItem_Help_About
        '
        Me.MenuItem_Help_About.Index = 0
        Me.MenuItem_Help_About.Text = "关于 Phenestra (&A)"
        '
        'MainDockPanel
        '
        Me.MainDockPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainDockPanel.DockBackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.MainDockPanel.Location = New System.Drawing.Point(0, 0)
        Me.MainDockPanel.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MainDockPanel.Name = "MainDockPanel"
        Me.MainDockPanel.Padding = New System.Windows.Forms.Padding(6)
        Me.MainDockPanel.ShowAutoHideContentOnHover = False
        Me.MainDockPanel.Size = New System.Drawing.Size(968, 573)
        Me.MainDockPanel.TabIndex = 0
        Me.MainDockPanel.Theme = Me.VS2015LightTheme1
        '
        'mainTimer
        '
        Me.mainTimer.Enabled = True
        Me.mainTimer.Interval = 1
        '
        'MainStatusBar
        '
        Me.MainStatusBar.Location = New System.Drawing.Point(0, 573)
        Me.MainStatusBar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MainStatusBar.Name = "MainStatusBar"
        Me.MainStatusBar.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.StatusBarPanel_TotalWndNum, Me.StatusBarPanel_MainWndNum, Me.StatusBarPanel_ChildWndNum})
        Me.MainStatusBar.ShowPanels = True
        Me.MainStatusBar.Size = New System.Drawing.Size(968, 31)
        Me.MainStatusBar.TabIndex = 1
        '
        'StatusBarPanel_TotalWndNum
        '
        Me.StatusBarPanel_TotalWndNum.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents
        Me.StatusBarPanel_TotalWndNum.Name = "StatusBarPanel_TotalWndNum"
        Me.StatusBarPanel_TotalWndNum.Text = "StatusBarPanel1"
        Me.StatusBarPanel_TotalWndNum.Width = 156
        '
        'StatusBarPanel_MainWndNum
        '
        Me.StatusBarPanel_MainWndNum.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents
        Me.StatusBarPanel_MainWndNum.Name = "StatusBarPanel_MainWndNum"
        Me.StatusBarPanel_MainWndNum.Text = "StatusBarPanel2"
        Me.StatusBarPanel_MainWndNum.Width = 156
        '
        'StatusBarPanel_ChildWndNum
        '
        Me.StatusBarPanel_ChildWndNum.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents
        Me.StatusBarPanel_ChildWndNum.Name = "StatusBarPanel_ChildWndNum"
        Me.StatusBarPanel_ChildWndNum.Text = "StatusBarPanel3"
        Me.StatusBarPanel_ChildWndNum.Width = 156
        '
        'ShortcutTimer
        '
        Me.ShortcutTimer.Enabled = True
        Me.ShortcutTimer.Interval = 1
        '
        'mainWindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(144.0!, 144.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(968, 604)
        Me.Controls.Add(Me.MainDockPanel)
        Me.Controls.Add(Me.MainStatusBar)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Menu = Me.AppMenu
        Me.MinimumSize = New System.Drawing.Size(990, 660)
        Me.Name = "mainWindow"
        Me.Text = "Phenestra"
        CType(Me.StatusBarPanel_TotalWndNum, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StatusBarPanel_MainWndNum, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StatusBarPanel_ChildWndNum, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents VS2015LightTheme1 As WeifenLuo.WinFormsUI.Docking.VS2015LightTheme
    Friend WithEvents AppMenu As MainMenu
    Friend WithEvents MainDockPanel As WeifenLuo.WinFormsUI.Docking.DockPanel
    Friend WithEvents MenuItem_Window As MenuItem
    Friend WithEvents MenuItem_Window_RefreshList As MenuItem
    Friend WithEvents mainTimer As Timer
    Friend WithEvents MenuItem_Window_1 As MenuItem
    Friend WithEvents MenuItem_Window_Close As MenuItem
    Friend WithEvents MenuItem_Window_Destroy As MenuItem
    Friend WithEvents MenuItem_Window_Focus As MenuItem
    Friend WithEvents MenuItem_Window_ForceClose As MenuItem
    Friend WithEvents MenuItem_View As MenuItem
    Friend WithEvents MenuItem_View_WindowTree As MenuItem
    Friend WithEvents MenuItem_View_Properties As MenuItem
    Friend WithEvents MenuItem_Help As MenuItem
    Friend WithEvents MenuItem_Help_About As MenuItem
    Friend WithEvents MenuItem_Files As MenuItem
    Friend WithEvents MenuItem_Files_Save As MenuItem
    Friend WithEvents MenuItem_Files_1 As MenuItem
    Friend WithEvents MenuItem_Files_Exit As MenuItem
    Friend WithEvents MainStatusBar As StatusBar
    Friend WithEvents ShortcutTimer As Timer
    Friend WithEvents StatusBarPanel_TotalWndNum As StatusBarPanel
    Friend WithEvents StatusBarPanel_MainWndNum As StatusBarPanel
    Friend WithEvents StatusBarPanel_ChildWndNum As StatusBarPanel
    Friend WithEvents MenuItem1 As MenuItem
    Friend WithEvents MenuItem_View_StatusBar As MenuItem
    Friend WithEvents MenuItem_Configuration As MenuItem
    Friend WithEvents MenuItem_Configuration_GlobalShortcut As MenuItem
End Class
