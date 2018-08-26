<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class vb_course
    Inherits System.Windows.Forms.Form

    'Form 覆寫 Dispose 以清除元件清單。
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

    '為 Windows Form 設計工具的必要項
    Private components As System.ComponentModel.IContainer

    '注意: 以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請不要使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.AnsTextBox = New System.Windows.Forms.TextBox()
        Me.AnsLabel = New System.Windows.Forms.Label()
        Me.AnsGroupBox = New System.Windows.Forms.GroupBox()
        Me.AnsButton = New System.Windows.Forms.Button()
        Me.CodeTextBoxA = New System.Windows.Forms.TextBox()
        Me.CallFuncLabel = New System.Windows.Forms.Label()
        Me.CodeTextBoxB = New System.Windows.Forms.TextBox()
        Me.CodeTextBoxC = New System.Windows.Forms.TextBox()
        Me.SwitchButton = New System.Windows.Forms.Button()
        Me.AnsGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'AnsTextBox
        '
        Me.AnsTextBox.Font = New System.Drawing.Font("新細明體", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.AnsTextBox.Location = New System.Drawing.Point(178, 35)
        Me.AnsTextBox.Name = "AnsTextBox"
        Me.AnsTextBox.Size = New System.Drawing.Size(100, 40)
        Me.AnsTextBox.TabIndex = 1
        '
        'AnsLabel
        '
        Me.AnsLabel.AutoSize = True
        Me.AnsLabel.Font = New System.Drawing.Font("新細明體", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.AnsLabel.Location = New System.Drawing.Point(13, 43)
        Me.AnsLabel.Name = "AnsLabel"
        Me.AnsLabel.Size = New System.Drawing.Size(147, 27)
        Me.AnsLabel.TabIndex = 2
        Me.AnsLabel.Text = "輸入答案："
        '
        'AnsGroupBox
        '
        Me.AnsGroupBox.Controls.Add(Me.AnsButton)
        Me.AnsGroupBox.Controls.Add(Me.AnsLabel)
        Me.AnsGroupBox.Controls.Add(Me.AnsTextBox)
        Me.AnsGroupBox.Location = New System.Drawing.Point(280, 609)
        Me.AnsGroupBox.Name = "AnsGroupBox"
        Me.AnsGroupBox.Size = New System.Drawing.Size(536, 99)
        Me.AnsGroupBox.TabIndex = 3
        Me.AnsGroupBox.TabStop = False
        '
        'AnsButton
        '
        Me.AnsButton.Font = New System.Drawing.Font("新細明體", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.AnsButton.Location = New System.Drawing.Point(318, 34)
        Me.AnsButton.Name = "AnsButton"
        Me.AnsButton.Size = New System.Drawing.Size(204, 45)
        Me.AnsButton.TabIndex = 3
        Me.AnsButton.Text = "送出答案"
        Me.AnsButton.UseVisualStyleBackColor = True
        '
        'CodeTextBoxA
        '
        Me.CodeTextBoxA.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.CodeTextBoxA.Location = New System.Drawing.Point(12, 12)
        Me.CodeTextBoxA.Multiline = True
        Me.CodeTextBoxA.Name = "CodeTextBoxA"
        Me.CodeTextBoxA.ReadOnly = True
        Me.CodeTextBoxA.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.CodeTextBoxA.Size = New System.Drawing.Size(300, 587)
        Me.CodeTextBoxA.TabIndex = 4
        Me.CodeTextBoxA.TabStop = False
        '
        'CallFuncLabel
        '
        Me.CallFuncLabel.AutoSize = True
        Me.CallFuncLabel.Font = New System.Drawing.Font("新細明體", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.CallFuncLabel.Location = New System.Drawing.Point(12, 639)
        Me.CallFuncLabel.Name = "CallFuncLabel"
        Me.CallFuncLabel.Size = New System.Drawing.Size(103, 27)
        Me.CallFuncLabel.TabIndex = 6
        Me.CallFuncLabel.Text = "Function"
        '
        'CodeTextBoxB
        '
        Me.CodeTextBoxB.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.CodeTextBoxB.Location = New System.Drawing.Point(318, 12)
        Me.CodeTextBoxB.Multiline = True
        Me.CodeTextBoxB.Name = "CodeTextBoxB"
        Me.CodeTextBoxB.ReadOnly = True
        Me.CodeTextBoxB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.CodeTextBoxB.Size = New System.Drawing.Size(300, 587)
        Me.CodeTextBoxB.TabIndex = 5
        Me.CodeTextBoxB.TabStop = False
        '
        'CodeTextBoxC
        '
        Me.CodeTextBoxC.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.CodeTextBoxC.Location = New System.Drawing.Point(624, 12)
        Me.CodeTextBoxC.Multiline = True
        Me.CodeTextBoxC.Name = "CodeTextBoxC"
        Me.CodeTextBoxC.ReadOnly = True
        Me.CodeTextBoxC.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.CodeTextBoxC.Size = New System.Drawing.Size(300, 587)
        Me.CodeTextBoxC.TabIndex = 7
        Me.CodeTextBoxC.TabStop = False
        '
        'SwitchButton
        '
        Me.SwitchButton.Location = New System.Drawing.Point(822, 617)
        Me.SwitchButton.Name = "SwitchButton"
        Me.SwitchButton.Size = New System.Drawing.Size(102, 87)
        Me.SwitchButton.TabIndex = 8
        Me.SwitchButton.Text = "切換顯示模式"
        Me.SwitchButton.UseVisualStyleBackColor = True
        '
        'vb_course
        '
        Me.AcceptButton = Me.AnsButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(934, 716)
        Me.Controls.Add(Me.SwitchButton)
        Me.Controls.Add(Me.CodeTextBoxC)
        Me.Controls.Add(Me.CallFuncLabel)
        Me.Controls.Add(Me.CodeTextBoxB)
        Me.Controls.Add(Me.CodeTextBoxA)
        Me.Controls.Add(Me.AnsGroupBox)
        Me.Name = "vb_course"
        Me.Text = "vb_course"
        Me.AnsGroupBox.ResumeLayout(False)
        Me.AnsGroupBox.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents AnsTextBox As System.Windows.Forms.TextBox
    Friend WithEvents AnsLabel As System.Windows.Forms.Label
    Friend WithEvents AnsGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents AnsButton As System.Windows.Forms.Button
    Friend WithEvents CodeTextBoxA As System.Windows.Forms.TextBox
    Friend WithEvents CallFuncLabel As System.Windows.Forms.Label
    Friend WithEvents CodeTextBoxB As System.Windows.Forms.TextBox
    Friend WithEvents CodeTextBoxC As System.Windows.Forms.TextBox
    Friend WithEvents SwitchButton As System.Windows.Forms.Button

End Class
