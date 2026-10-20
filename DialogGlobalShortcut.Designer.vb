<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DialogGlobalShortcut
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TabControl_Main = New System.Windows.Forms.TabControl()
        Me.TabPage_Commands = New System.Windows.Forms.TabPage()
        Me.FlowLayoutPanel_Comamnds = New System.Windows.Forms.FlowLayoutPanel()
        Me.S_Commands_Focus = New LQUSMLib.Controls.ShortcutDetectorControl()
        Me.S_Commands_Exit = New LQUSMLib.Controls.ShortcutDetectorControl()
        Me.TabPage_Debug = New System.Windows.Forms.TabPage()
        Me.FlowLayoutPanel_Debug = New System.Windows.Forms.FlowLayoutPanel()
        Me.S_Debug_TopMost = New LQUSMLib.Controls.ShortcutDetectorControl()
        Me.S_Debug_NoActivate = New LQUSMLib.Controls.ShortcutDetectorControl()
        Me.OKBtn = New System.Windows.Forms.Button()
        Me.CancelBtn = New System.Windows.Forms.Button()
        Me.TabControl_Main.SuspendLayout()
        Me.TabPage_Commands.SuspendLayout()
        Me.FlowLayoutPanel_Comamnds.SuspendLayout()
        Me.TabPage_Debug.SuspendLayout()
        Me.FlowLayoutPanel_Debug.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl_Main
        '
        Me.TabControl_Main.Controls.Add(Me.TabPage_Commands)
        Me.TabControl_Main.Controls.Add(Me.TabPage_Debug)
        Me.TabControl_Main.Location = New System.Drawing.Point(12, 12)
        Me.TabControl_Main.Name = "TabControl_Main"
        Me.TabControl_Main.SelectedIndex = 0
        Me.TabControl_Main.Size = New System.Drawing.Size(754, 676)
        Me.TabControl_Main.TabIndex = 0
        '
        'TabPage_Commands
        '
        Me.TabPage_Commands.Controls.Add(Me.FlowLayoutPanel_Comamnds)
        Me.TabPage_Commands.Location = New System.Drawing.Point(4, 34)
        Me.TabPage_Commands.Name = "TabPage_Commands"
        Me.TabPage_Commands.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage_Commands.Size = New System.Drawing.Size(746, 638)
        Me.TabPage_Commands.TabIndex = 0
        Me.TabPage_Commands.Text = "命令"
        Me.TabPage_Commands.UseVisualStyleBackColor = True
        '
        'FlowLayoutPanel_Comamnds
        '
        Me.FlowLayoutPanel_Comamnds.AutoScroll = True
        Me.FlowLayoutPanel_Comamnds.Controls.Add(Me.S_Commands_Focus)
        Me.FlowLayoutPanel_Comamnds.Controls.Add(Me.S_Commands_Exit)
        Me.FlowLayoutPanel_Comamnds.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel_Comamnds.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.FlowLayoutPanel_Comamnds.Location = New System.Drawing.Point(3, 3)
        Me.FlowLayoutPanel_Comamnds.Name = "FlowLayoutPanel_Comamnds"
        Me.FlowLayoutPanel_Comamnds.Size = New System.Drawing.Size(740, 632)
        Me.FlowLayoutPanel_Comamnds.TabIndex = 0
        Me.FlowLayoutPanel_Comamnds.WrapContents = False
        '
        'S_Commands_Focus
        '
        Me.S_Commands_Focus.DefaultDisplay = "[Please press any key...]"
        Me.S_Commands_Focus.Description = "将焦点切换至Phenestra"
        Me.S_Commands_Focus.EnableDescription = True
        Me.S_Commands_Focus.Expression = ""
        Me.S_Commands_Focus.Location = New System.Drawing.Point(3, 3)
        Me.S_Commands_Focus.Name = "S_Commands_Focus"
        Me.S_Commands_Focus.Size = New System.Drawing.Size(705, 36)
        Me.S_Commands_Focus.TabIndex = 0
        Me.S_Commands_Focus.UseWinKey = True
        '
        'S_Commands_Exit
        '
        Me.S_Commands_Exit.DefaultDisplay = "[Please press any key...]"
        Me.S_Commands_Exit.Description = "退出"
        Me.S_Commands_Exit.EnableDescription = True
        Me.S_Commands_Exit.Expression = ""
        Me.S_Commands_Exit.Location = New System.Drawing.Point(3, 45)
        Me.S_Commands_Exit.Name = "S_Commands_Exit"
        Me.S_Commands_Exit.Size = New System.Drawing.Size(705, 36)
        Me.S_Commands_Exit.TabIndex = 3
        Me.S_Commands_Exit.UseWinKey = True
        '
        'TabPage_Debug
        '
        Me.TabPage_Debug.Controls.Add(Me.FlowLayoutPanel_Debug)
        Me.TabPage_Debug.Location = New System.Drawing.Point(4, 34)
        Me.TabPage_Debug.Name = "TabPage_Debug"
        Me.TabPage_Debug.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage_Debug.Size = New System.Drawing.Size(746, 638)
        Me.TabPage_Debug.TabIndex = 1
        Me.TabPage_Debug.Text = "调试"
        Me.TabPage_Debug.UseVisualStyleBackColor = True
        '
        'FlowLayoutPanel_Debug
        '
        Me.FlowLayoutPanel_Debug.AutoScroll = True
        Me.FlowLayoutPanel_Debug.Controls.Add(Me.S_Debug_TopMost)
        Me.FlowLayoutPanel_Debug.Controls.Add(Me.S_Debug_NoActivate)
        Me.FlowLayoutPanel_Debug.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel_Debug.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.FlowLayoutPanel_Debug.Location = New System.Drawing.Point(3, 3)
        Me.FlowLayoutPanel_Debug.Name = "FlowLayoutPanel_Debug"
        Me.FlowLayoutPanel_Debug.Size = New System.Drawing.Size(740, 632)
        Me.FlowLayoutPanel_Debug.TabIndex = 1
        Me.FlowLayoutPanel_Debug.WrapContents = False
        '
        'S_Debug_TopMost
        '
        Me.S_Debug_TopMost.DefaultDisplay = "[Please press any key...]"
        Me.S_Debug_TopMost.Description = "置于顶层/恢复"
        Me.S_Debug_TopMost.EnableDescription = True
        Me.S_Debug_TopMost.Expression = ""
        Me.S_Debug_TopMost.Location = New System.Drawing.Point(3, 3)
        Me.S_Debug_TopMost.Name = "S_Debug_TopMost"
        Me.S_Debug_TopMost.Size = New System.Drawing.Size(705, 36)
        Me.S_Debug_TopMost.TabIndex = 0
        Me.S_Debug_TopMost.UseWinKey = True
        '
        'S_Debug_NoActivate
        '
        Me.S_Debug_NoActivate.DefaultDisplay = "[Please press any key...]"
        Me.S_Debug_NoActivate.Description = "使Phenestra无法通过用户点击获取焦点"
        Me.S_Debug_NoActivate.EnableDescription = True
        Me.S_Debug_NoActivate.Expression = ""
        Me.S_Debug_NoActivate.Location = New System.Drawing.Point(3, 45)
        Me.S_Debug_NoActivate.Name = "S_Debug_NoActivate"
        Me.S_Debug_NoActivate.Size = New System.Drawing.Size(705, 36)
        Me.S_Debug_NoActivate.TabIndex = 1
        Me.S_Debug_NoActivate.UseWinKey = True
        '
        'OKBtn
        '
        Me.OKBtn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OKBtn.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.OKBtn.Location = New System.Drawing.Point(530, 694)
        Me.OKBtn.Name = "OKBtn"
        Me.OKBtn.Size = New System.Drawing.Size(115, 38)
        Me.OKBtn.TabIndex = 1
        Me.OKBtn.Text = "确定(&O)"
        Me.OKBtn.UseVisualStyleBackColor = True
        '
        'CancelBtn
        '
        Me.CancelBtn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CancelBtn.Location = New System.Drawing.Point(651, 694)
        Me.CancelBtn.Name = "CancelBtn"
        Me.CancelBtn.Size = New System.Drawing.Size(115, 38)
        Me.CancelBtn.TabIndex = 2
        Me.CancelBtn.Text = "取消(&C)"
        Me.CancelBtn.UseVisualStyleBackColor = True
        '
        'DialogGlobalShortcut
        '
        Me.AcceptButton = Me.OKBtn
        Me.AutoScaleDimensions = New System.Drawing.SizeF(144.0!, 144.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.CancelBtn
        Me.ClientSize = New System.Drawing.Size(778, 744)
        Me.Controls.Add(Me.TabControl_Main)
        Me.Controls.Add(Me.OKBtn)
        Me.Controls.Add(Me.CancelBtn)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DialogGlobalShortcut"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "全局快捷键"
        Me.TabControl_Main.ResumeLayout(False)
        Me.TabPage_Commands.ResumeLayout(False)
        Me.FlowLayoutPanel_Comamnds.ResumeLayout(False)
        Me.TabPage_Debug.ResumeLayout(False)
        Me.FlowLayoutPanel_Debug.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControl_Main As TabControl
    Friend WithEvents TabPage_Commands As TabPage
    Friend WithEvents FlowLayoutPanel_Comamnds As FlowLayoutPanel
    Friend WithEvents S_Commands_Focus As LQUSMLib.Controls.ShortcutDetectorControl
    Friend WithEvents OKBtn As Button
    Friend WithEvents CancelBtn As Button
    Friend WithEvents TabPage_Debug As TabPage
    Friend WithEvents FlowLayoutPanel_Debug As FlowLayoutPanel
    Friend WithEvents S_Debug_TopMost As LQUSMLib.Controls.ShortcutDetectorControl
    Friend WithEvents S_Debug_NoActivate As LQUSMLib.Controls.ShortcutDetectorControl
    Friend WithEvents S_Commands_Exit As LQUSMLib.Controls.ShortcutDetectorControl
End Class
