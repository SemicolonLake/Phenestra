Imports WeifenLuo.WinFormsUI.Docking

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormProperties
    Inherits DockContent

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
        Me.PropertyGrid_Main = New System.Windows.Forms.PropertyGrid()
        Me.SuspendLayout()
        '
        'PropertyGrid_Main
        '
        Me.PropertyGrid_Main.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PropertyGrid_Main.Location = New System.Drawing.Point(0, 0)
        Me.PropertyGrid_Main.Name = "PropertyGrid_Main"
        Me.PropertyGrid_Main.Size = New System.Drawing.Size(472, 752)
        Me.PropertyGrid_Main.TabIndex = 0
        '
        'FormProperties
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(472, 752)
        Me.Controls.Add(Me.PropertyGrid_Main)
        Me.HideOnClose = True
        Me.Name = "FormProperties"
        Me.Text = "属性"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PropertyGrid_Main As PropertyGrid
End Class
