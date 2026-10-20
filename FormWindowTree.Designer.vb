Imports WeifenLuo.WinFormsUI.Docking

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormWindowTree
    Inherits DockContent

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
        Me.TreeView_Main = New System.Windows.Forms.TreeView()
        Me.Panel_Main = New System.Windows.Forms.Panel()
        Me.CheckBox_MatchCase = New System.Windows.Forms.CheckBox()
        Me.Panel_Search = New System.Windows.Forms.Panel()
        Me.TextBox_Search = New System.Windows.Forms.TextBox()
        Me.Button_Search = New System.Windows.Forms.Button()
        Me.ContextMenu_Main = New System.Windows.Forms.ContextMenu()
        Me.MenuItem_Refresh = New System.Windows.Forms.MenuItem()
        Me.MenuItem_1 = New System.Windows.Forms.MenuItem()
        Me.MenuItem_Close = New System.Windows.Forms.MenuItem()
        Me.MenuItem_Destroy = New System.Windows.Forms.MenuItem()
        Me.MenuItem_Focus = New System.Windows.Forms.MenuItem()
        Me.MenuItem_ForceClose = New System.Windows.Forms.MenuItem()
        Me.mainTimer = New System.Windows.Forms.Timer(Me.components)
        Me.Panel_Main.SuspendLayout()
        Me.Panel_Search.SuspendLayout()
        Me.SuspendLayout()
        '
        'TreeView_Main
        '
        Me.TreeView_Main.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeView_Main.Location = New System.Drawing.Point(0, 36)
        Me.TreeView_Main.Margin = New System.Windows.Forms.Padding(4)
        Me.TreeView_Main.Name = "TreeView_Main"
        Me.TreeView_Main.Size = New System.Drawing.Size(1244, 764)
        Me.TreeView_Main.TabIndex = 0
        '
        'Panel_Main
        '
        Me.Panel_Main.Controls.Add(Me.CheckBox_MatchCase)
        Me.Panel_Main.Controls.Add(Me.Panel_Search)
        Me.Panel_Main.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel_Main.Location = New System.Drawing.Point(0, 0)
        Me.Panel_Main.Name = "Panel_Main"
        Me.Panel_Main.Size = New System.Drawing.Size(1244, 36)
        Me.Panel_Main.TabIndex = 1
        '
        'CheckBox_MatchCase
        '
        Me.CheckBox_MatchCase.AutoSize = True
        Me.CheckBox_MatchCase.Dock = System.Windows.Forms.DockStyle.Right
        Me.CheckBox_MatchCase.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CheckBox_MatchCase.Location = New System.Drawing.Point(684, 0)
        Me.CheckBox_MatchCase.Name = "CheckBox_MatchCase"
        Me.CheckBox_MatchCase.Size = New System.Drawing.Size(162, 36)
        Me.CheckBox_MatchCase.TabIndex = 1
        Me.CheckBox_MatchCase.Text = "匹配大小写(&C)"
        Me.CheckBox_MatchCase.UseVisualStyleBackColor = True
        '
        'Panel_Search
        '
        Me.Panel_Search.Controls.Add(Me.TextBox_Search)
        Me.Panel_Search.Controls.Add(Me.Button_Search)
        Me.Panel_Search.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel_Search.Location = New System.Drawing.Point(846, 0)
        Me.Panel_Search.Name = "Panel_Search"
        Me.Panel_Search.Size = New System.Drawing.Size(398, 36)
        Me.Panel_Search.TabIndex = 0
        '
        'TextBox_Search
        '
        Me.TextBox_Search.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox_Search.Location = New System.Drawing.Point(0, 0)
        Me.TextBox_Search.Name = "TextBox_Search"
        Me.TextBox_Search.Size = New System.Drawing.Size(304, 31)
        Me.TextBox_Search.TabIndex = 0
        '
        'Button_Search
        '
        Me.Button_Search.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button_Search.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button_Search.Location = New System.Drawing.Point(304, 0)
        Me.Button_Search.Name = "Button_Search"
        Me.Button_Search.Size = New System.Drawing.Size(94, 36)
        Me.Button_Search.TabIndex = 1
        Me.Button_Search.Text = "搜索(&S)"
        Me.Button_Search.UseVisualStyleBackColor = True
        '
        'ContextMenu_Main
        '
        Me.ContextMenu_Main.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem_Refresh, Me.MenuItem_1, Me.MenuItem_Close, Me.MenuItem_Destroy, Me.MenuItem_Focus, Me.MenuItem_ForceClose})
        '
        'MenuItem_Refresh
        '
        Me.MenuItem_Refresh.Index = 0
        Me.MenuItem_Refresh.Text = "刷新(&R)"
        '
        'MenuItem_1
        '
        Me.MenuItem_1.Index = 1
        Me.MenuItem_1.Text = "-"
        '
        'MenuItem_Close
        '
        Me.MenuItem_Close.Index = 2
        Me.MenuItem_Close.Text = "关闭(&C)"
        '
        'MenuItem_Destroy
        '
        Me.MenuItem_Destroy.Index = 3
        Me.MenuItem_Destroy.Text = "销毁(&D)"
        '
        'MenuItem_Focus
        '
        Me.MenuItem_Focus.Index = 4
        Me.MenuItem_Focus.Text = "切换至(&F)"
        '
        'MenuItem_ForceClose
        '
        Me.MenuItem_ForceClose.Index = 5
        Me.MenuItem_ForceClose.Text = "强制关闭(&O)"
        '
        'mainTimer
        '
        Me.mainTimer.Enabled = True
        Me.mainTimer.Interval = 1
        '
        'FormWindowTree
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(144.0!, 144.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(1244, 800)
        Me.Controls.Add(Me.TreeView_Main)
        Me.Controls.Add(Me.Panel_Main)
        Me.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.HideOnClose = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FormWindowTree"
        Me.Text = "窗口树"
        Me.Panel_Main.ResumeLayout(False)
        Me.Panel_Main.PerformLayout()
        Me.Panel_Search.ResumeLayout(False)
        Me.Panel_Search.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TreeView_Main As TreeView
    Friend WithEvents Panel_Main As Panel
    Friend WithEvents Panel_Search As Panel
    Friend WithEvents TextBox_Search As TextBox
    Friend WithEvents Button_Search As Button
    Friend WithEvents ContextMenu_Main As ContextMenu
    Friend WithEvents MenuItem_Refresh As MenuItem
    Friend WithEvents MenuItem_1 As MenuItem
    Friend WithEvents MenuItem_Close As MenuItem
    Friend WithEvents MenuItem_Destroy As MenuItem
    Friend WithEvents MenuItem_Focus As MenuItem
    Friend WithEvents MenuItem_ForceClose As MenuItem
    Friend WithEvents mainTimer As Timer
    Friend WithEvents CheckBox_MatchCase As CheckBox
End Class
